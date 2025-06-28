import 'dart:async';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:shared_preferences/shared_preferences.dart';
import '../../core/exceptions.dart';
import '../../core/enums.dart';
import '../../core/result.dart';
import '../../models/user.dart';
import '../../services/database_service.dart';
import '../../services/email_service.dart';
import 'auth_event.dart';
import 'auth_state.dart';

/// BLoC for managing authentication state
class AuthBloc extends Bloc<AuthEvent, AuthState> {
  final DatabaseService _databaseService;
  final EmailService _emailService;
  
  // Keys for SharedPreferences
  static const String _keyRememberMe = 'remember_me';
  static const String _keyUserId = 'user_id';
  static const String _keyUserEmail = 'user_email';

  AuthBloc({
    required DatabaseService databaseService,
    required EmailService emailService,
  })  : _databaseService = databaseService,
        _emailService = emailService,
        super(const AuthInitial()) {
    
    // Register event handlers
    on<AuthStatusRequested>(_onAuthStatusRequested);
    on<LoginRequested>(_onLoginRequested);
    on<RegisterRequested>(_onRegisterRequested);
    on<PasswordResetRequested>(_onPasswordResetRequested);
    on<LogoutRequested>(_onLogoutRequested);
    on<UserProfileUpdateRequested>(_onUserProfileUpdateRequested);
    on<EmailVerificationRequested>(_onEmailVerificationRequested);
    on<VerificationEmailResendRequested>(_onVerificationEmailResendRequested);
    on<AuthErrorCleared>(_onAuthErrorCleared);
    on<UserRefreshRequested>(_onUserRefreshRequested);
  }

  /// Handle authentication status check
  Future<void> _onAuthStatusRequested(
    AuthStatusRequested event,
    Emitter<AuthState> emit,
  ) async {
    emit(const AuthLoading(message: 'Đang kiểm tra trạng thái đăng nhập...'));

    try {
      final prefs = await SharedPreferences.getInstance();
      final rememberMe = prefs.getBool(_keyRememberMe) ?? false;
      
      if (rememberMe) {
        final userId = prefs.getInt(_keyUserId);
        if (userId != null) {
          final result = await _databaseService.getUserById(userId);
          
          result.fold(
            (user) {
              if (user != null) {
                emit(AuthAuthenticated(user: user));
              } else {
                emit(const AuthUnauthenticated());
              }
            },
            (exception) => emit(const AuthUnauthenticated()),
          );
        } else {
          emit(const AuthUnauthenticated());
        }
      } else {
        emit(const AuthUnauthenticated());
      }
    } catch (e) {
      emit(const AuthUnauthenticated());
    }
  }

  /// Handle login request
  Future<void> _onLoginRequested(
    LoginRequested event,
    Emitter<AuthState> emit,
  ) async {
    emit(const AuthLoginInProgress());

    try {
      final result = await _databaseService.authenticateUser(
        event.email,
        event.password,
      );

      await result.fold(
        (user) async {
          if (user != null) {
            // Save login preferences
            if (event.rememberMe) {
              await _saveUserPreferences(user);
            }

            // Check if this is first login
            final isFirstLogin = user.lastLoginAt == null;

            emit(AuthAuthenticated(
              user: user,
              isFirstLogin: isFirstLogin,
            ));
          } else {
            emit(const AuthError(
              exception: InvalidCredentialsException(),
            ));
          }
        },
        (exception) {
          emit(AuthError(exception: exception));
        },
      );
    } catch (e) {
      emit(AuthError(
        exception: AuthenticationException(
          'Đã xảy ra lỗi không mong muốn',
          originalError: e,
        ),
      ));
    }
  }

  /// Handle registration request
  Future<void> _onRegisterRequested(
    RegisterRequested event,
    Emitter<AuthState> emit,
  ) async {
    emit(const AuthRegistrationInProgress());

    try {
      final user = User(
        name: event.name,
        email: event.email,
        phone: event.phone,
        birthDate: event.birthDate,
        gender: event.gender,
        password: event.password,
      );

      final result = await _databaseService.createUser(user);

      await result.fold(
        (createdUser) async {
          // Send welcome email
          final emailResult = await _emailService.sendWelcomeEmail(
            createdUser.email,
            createdUser.name,
          );

          emailResult.fold(
            (_) {
              emit(AuthRegistrationSuccess(
                email: createdUser.email,
                message: 'Đăng ký thành công! Email chào mừng đã được gửi.',
              ));
            },
            (_) {
              emit(AuthRegistrationSuccess(
                email: createdUser.email,
                message: 'Đăng ký thành công! Bạn có thể đăng nhập ngay.',
              ));
            },
          );
        },
        (exception) {
          emit(AuthError(exception: exception));
        },
      );
    } catch (e) {
      emit(AuthError(
        exception: AuthenticationException(
          'Đã xảy ra lỗi không mong muốn',
          originalError: e,
        ),
      ));
    }
  }

  /// Handle password reset request
  Future<void> _onPasswordResetRequested(
    PasswordResetRequested event,
    Emitter<AuthState> emit,
  ) async {
    emit(const AuthPasswordResetInProgress());

    try {
      // Generate new password and update in database
      final passwordResult = await _databaseService.generateNewPassword(event.email);
      
      await passwordResult.fold(
        (newPassword) async {
          // Get user info for email
          final userResult = await _databaseService.getUserByEmail(event.email);
          
          await userResult.fold(
            (user) async {
              if (user != null) {
                // Send new password via email
                final emailResult = await _emailService.sendNewPasswordEmail(
                  event.email,
                  user.name,
                  newPassword,
                );

                emailResult.fold(
                  (_) {
                    emit(AuthPasswordResetEmailSent(
                      email: event.email,
                      message: 'Mật khẩu mới đã được gửi qua email.',
                    ));
                  },
                  (exception) {
                    emit(AuthError(exception: exception));
                  },
                );
              } else {
                emit(const AuthError(
                  exception: UserNotFoundException(),
                ));
              }
            },
            (exception) {
              emit(AuthError(exception: exception));
            },
          );
        },
        (exception) {
          emit(AuthError(exception: exception));
        },
      );
    } catch (e) {
      emit(AuthError(
        exception: AuthenticationException(
          'Đã xảy ra lỗi không mong muốn',
          originalError: e,
        ),
      ));
    }
  }



  /// Handle logout request
  Future<void> _onLogoutRequested(
    LogoutRequested event,
    Emitter<AuthState> emit,
  ) async {
    try {
      // Clear saved preferences
      await _clearUserPreferences();
      
      emit(const AuthUnauthenticated(
        message: 'Đăng xuất thành công.',
      ));
    } catch (e) {
      emit(const AuthUnauthenticated());
    }
  }

  /// Handle user profile update
  Future<void> _onUserProfileUpdateRequested(
    UserProfileUpdateRequested event,
    Emitter<AuthState> emit,
  ) async {
    emit(const AuthUserUpdateInProgress());

    try {
      final result = await _databaseService.updateUser(event.user);

      result.fold(
        (success) {
          if (success) {
            emit(AuthUserUpdateSuccess(
              user: event.user,
              message: 'Cập nhật thông tin thành công.',
            ));
          } else {
            emit(const AuthError(
              exception: DatabaseException('Không thể cập nhật thông tin'),
            ));
          }
        },
        (exception) {
          emit(AuthError(exception: exception));
        },
      );
    } catch (e) {
      emit(AuthError(
        exception: AuthenticationException(
          'Đã xảy ra lỗi không mong muốn',
          originalError: e,
        ),
      ));
    }
  }

  /// Handle email verification
  Future<void> _onEmailVerificationRequested(
    EmailVerificationRequested event,
    Emitter<AuthState> emit,
  ) async {
    emit(const AuthEmailVerificationInProgress());

    try {
      final userResult = await _databaseService.getUserByEmail(event.email);
      
      await userResult.fold(
        (user) async {
          if (user != null) {
            final updatedUser = user.copyWith(isEmailVerified: true);
            final updateResult = await _databaseService.updateUser(updatedUser);
            
            updateResult.fold(
              (success) {
                if (success) {
                  emit(const AuthEmailVerificationSuccess(
                    message: 'Email đã được xác thực thành công.',
                  ));
                } else {
                  emit(const AuthError(
                    exception: DatabaseException('Không thể cập nhật trạng thái xác thực'),
                  ));
                }
              },
              (exception) {
                emit(AuthError(exception: exception));
              },
            );
          } else {
            emit(const AuthError(
              exception: UserNotFoundException(),
            ));
          }
        },
        (exception) {
          emit(AuthError(exception: exception));
        },
      );
    } catch (e) {
      emit(AuthError(
        exception: AuthenticationException(
          'Đã xảy ra lỗi không mong muốn',
          originalError: e,
        ),
      ));
    }
  }

  /// Handle verification email resend
  Future<void> _onVerificationEmailResendRequested(
    VerificationEmailResendRequested event,
    Emitter<AuthState> emit,
  ) async {
    emit(const AuthEmailVerificationInProgress());

    try {
      final verificationCode = _emailService.generateVerificationCode();
      
      final emailResult = await _emailService.sendVerificationEmail(
        event.email,
        verificationCode,
      );

      emailResult.fold(
        (_) {
          emit(AuthVerificationEmailSent(
            email: event.email,
            message: 'Email xác thực đã được gửi lại.',
          ));
        },
        (exception) {
          emit(AuthError(exception: exception));
        },
      );
    } catch (e) {
      emit(AuthError(
        exception: EmailException(
          'Không thể gửi email xác thực',
          originalError: e,
        ),
      ));
    }
  }

  /// Handle clearing auth errors
  Future<void> _onAuthErrorCleared(
    AuthErrorCleared event,
    Emitter<AuthState> emit,
  ) async {
    if (state is AuthError) {
      final errorState = state as AuthError;
      switch (errorState.previousStatus) {
        case AuthStatus.authenticated:
          // Get current user and restore authenticated state
          final prefs = await SharedPreferences.getInstance();
          final userId = prefs.getInt(_keyUserId);
          if (userId != null) {
            final result = await _databaseService.getUserById(userId);
            result.fold(
              (user) {
                if (user != null) {
                  emit(AuthAuthenticated(user: user));
                } else {
                  emit(const AuthUnauthenticated());
                }
              },
              (_) => emit(const AuthUnauthenticated()),
            );
          } else {
            emit(const AuthUnauthenticated());
          }
          break;
        default:
          emit(const AuthUnauthenticated());
      }
    }
  }

  /// Handle user refresh
  Future<void> _onUserRefreshRequested(
    UserRefreshRequested event,
    Emitter<AuthState> emit,
  ) async {
    if (state.currentUser != null) {
      final currentUser = state.currentUser!;
      final result = await _databaseService.getUserById(currentUser.id!);
      
      result.fold(
        (user) {
          if (user != null) {
            emit(AuthAuthenticated(user: user));
          }
        },
        (_) {
          // If refresh fails, keep current state
        },
      );
    }
  }

  /// Save user preferences for remember me functionality
  Future<void> _saveUserPreferences(User user) async {
    final prefs = await SharedPreferences.getInstance();
    await prefs.setBool(_keyRememberMe, true);
    await prefs.setInt(_keyUserId, user.id!);
    await prefs.setString(_keyUserEmail, user.email);
  }

  /// Clear user preferences
  Future<void> _clearUserPreferences() async {
    final prefs = await SharedPreferences.getInstance();
    await prefs.remove(_keyRememberMe);
    await prefs.remove(_keyUserId);
    await prefs.remove(_keyUserEmail);
  }

  @override
  Future<void> close() {
    return super.close();
  }
}

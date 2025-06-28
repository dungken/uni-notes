import 'package:equatable/equatable.dart';
import '../../core/enums.dart';
import '../../core/exceptions.dart';
import '../../models/user.dart';

/// Base class for all authentication states
abstract class AuthState extends Equatable {
  const AuthState();

  @override
  List<Object?> get props => [];
}

/// Initial state when app starts
class AuthInitial extends AuthState {
  const AuthInitial();
}

/// State when checking authentication status
class AuthLoading extends AuthState {
  final String? message;

  const AuthLoading({this.message});

  @override
  List<Object?> get props => [message];
}

/// State when user is authenticated
class AuthAuthenticated extends AuthState {
  final User user;
  final bool isFirstLogin;

  const AuthAuthenticated({
    required this.user,
    this.isFirstLogin = false,
  });

  @override
  List<Object?> get props => [user, isFirstLogin];
}

/// State when user is not authenticated
class AuthUnauthenticated extends AuthState {
  final String? message;

  const AuthUnauthenticated({this.message});

  @override
  List<Object?> get props => [message];
}

/// State when authentication fails
class AuthError extends AuthState {
  final AppException exception;
  final AuthStatus previousStatus;

  const AuthError({
    required this.exception,
    this.previousStatus = AuthStatus.unauthenticated,
  });

  @override
  List<Object?> get props => [exception, previousStatus];
}

/// State during login process
class AuthLoginInProgress extends AuthState {
  const AuthLoginInProgress();
}

/// State during registration process
class AuthRegistrationInProgress extends AuthState {
  const AuthRegistrationInProgress();
}

/// State when registration is successful
class AuthRegistrationSuccess extends AuthState {
  final String email;
  final String message;

  const AuthRegistrationSuccess({
    required this.email,
    required this.message,
  });

  @override
  List<Object?> get props => [email, message];
}

/// State during password reset process
class AuthPasswordResetInProgress extends AuthState {
  const AuthPasswordResetInProgress();
}

/// State when password reset email is sent
class AuthPasswordResetEmailSent extends AuthState {
  final String email;
  final String message;

  const AuthPasswordResetEmailSent({
    required this.email,
    required this.message,
  });

  @override
  List<Object?> get props => [email, message];
}

/// State when password reset is successful
class AuthPasswordResetSuccess extends AuthState {
  final String message;

  const AuthPasswordResetSuccess({required this.message});

  @override
  List<Object?> get props => [message];
}

/// State during email verification process
class AuthEmailVerificationInProgress extends AuthState {
  const AuthEmailVerificationInProgress();
}

/// State when email verification is successful
class AuthEmailVerificationSuccess extends AuthState {
  final String message;

  const AuthEmailVerificationSuccess({required this.message});

  @override
  List<Object?> get props => [message];
}

/// State when verification email is sent
class AuthVerificationEmailSent extends AuthState {
  final String email;
  final String message;

  const AuthVerificationEmailSent({
    required this.email,
    required this.message,
  });

  @override
  List<Object?> get props => [email, message];
}

/// State during user profile update
class AuthUserUpdateInProgress extends AuthState {
  const AuthUserUpdateInProgress();
}

/// State when user profile is updated successfully
class AuthUserUpdateSuccess extends AuthState {
  final User user;
  final String message;

  const AuthUserUpdateSuccess({
    required this.user,
    required this.message,
  });

  @override
  List<Object?> get props => [user, message];
}

/// Extension to get current user from auth state
extension AuthStateExtension on AuthState {
  /// Get current user if authenticated
  User? get currentUser {
    return switch (this) {
      AuthAuthenticated(user: final user) => user,
      AuthUserUpdateSuccess(user: final user) => user,
      _ => null,
    };
  }

  /// Check if user is authenticated
  bool get isAuthenticated {
    return switch (this) {
      AuthAuthenticated() => true,
      AuthUserUpdateSuccess() => true,
      _ => false,
    };
  }

  /// Check if in loading state
  bool get isLoading {
    return switch (this) {
      AuthLoading() => true,
      AuthLoginInProgress() => true,
      AuthRegistrationInProgress() => true,
      AuthPasswordResetInProgress() => true,
      AuthEmailVerificationInProgress() => true,
      AuthUserUpdateInProgress() => true,
      _ => false,
    };
  }

  /// Get error message if in error state
  String? get errorMessage {
    return switch (this) {
      AuthError(exception: final exception) => exception.message,
      _ => null,
    };
  }

  /// Get success message
  String? get successMessage {
    return switch (this) {
      AuthRegistrationSuccess(message: final message) => message,
      AuthPasswordResetEmailSent(message: final message) => message,
      AuthPasswordResetSuccess(message: final message) => message,
      AuthEmailVerificationSuccess(message: final message) => message,
      AuthVerificationEmailSent(message: final message) => message,
      AuthUserUpdateSuccess(message: final message) => message,
      _ => null,
    };
  }
}

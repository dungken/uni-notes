import 'package:equatable/equatable.dart';
import '../../core/enums.dart';
import '../../models/user.dart';

/// Base class for all authentication events
abstract class AuthEvent extends Equatable {
  const AuthEvent();

  @override
  List<Object?> get props => [];
}

/// Event to check authentication status on app start
class AuthStatusRequested extends AuthEvent {
  const AuthStatusRequested();
}

/// Event for user login
class LoginRequested extends AuthEvent {
  final String email;
  final String password;
  final bool rememberMe;

  const LoginRequested({
    required this.email,
    required this.password,
    this.rememberMe = false,
  });

  @override
  List<Object?> get props => [email, password, rememberMe];
}

/// Event for user registration
class RegisterRequested extends AuthEvent {
  final String name;
  final String email;
  final String phone;
  final String birthDate;
  final Gender gender;
  final String password;

  const RegisterRequested({
    required this.name,
    required this.email,
    required this.phone,
    required this.birthDate,
    required this.gender,
    required this.password,
  });

  @override
  List<Object?> get props => [name, email, phone, birthDate, gender, password];
}

/// Event for password reset request
class PasswordResetRequested extends AuthEvent {
  final String email;

  const PasswordResetRequested({required this.email});

  @override
  List<Object?> get props => [email];
}



/// Event for user logout
class LogoutRequested extends AuthEvent {
  const LogoutRequested();
}

/// Event to update user profile
class UserProfileUpdateRequested extends AuthEvent {
  final User user;

  const UserProfileUpdateRequested({required this.user});

  @override
  List<Object?> get props => [user];
}

/// Event to verify email
class EmailVerificationRequested extends AuthEvent {
  final String email;
  final String verificationCode;

  const EmailVerificationRequested({
    required this.email,
    required this.verificationCode,
  });

  @override
  List<Object?> get props => [email, verificationCode];
}

/// Event to resend verification email
class VerificationEmailResendRequested extends AuthEvent {
  final String email;

  const VerificationEmailResendRequested({required this.email});

  @override
  List<Object?> get props => [email];
}

/// Event to clear authentication errors
class AuthErrorCleared extends AuthEvent {
  const AuthErrorCleared();
}

/// Event to refresh user data
class UserRefreshRequested extends AuthEvent {
  const UserRefreshRequested();
}

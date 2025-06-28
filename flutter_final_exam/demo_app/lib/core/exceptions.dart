/// Base exception class
abstract class AppException implements Exception {
  final String message;
  final String? code;
  final dynamic originalError;

  const AppException(this.message, {this.code, this.originalError});

  @override
  String toString() => message;
}

/// Database exceptions
class DatabaseException extends AppException {
  const DatabaseException(String message, {String? code, dynamic originalError})
      : super(message, code: code, originalError: originalError);
}

/// Authentication exceptions
class AuthenticationException extends AppException {
  const AuthenticationException(String message, {String? code, dynamic originalError})
      : super(message, code: code, originalError: originalError);
}

/// Email exceptions
class EmailException extends AppException {
  const EmailException(String message, {String? code, dynamic originalError})
      : super(message, code: code, originalError: originalError);
}

/// Specific authentication exceptions
class InvalidCredentialsException extends AuthenticationException {
  const InvalidCredentialsException()
      : super('Email hoặc mật khẩu không đúng', code: 'INVALID_CREDENTIALS');
}

class UserNotFoundException extends AuthenticationException {
  const UserNotFoundException()
      : super('Người dùng không tồn tại', code: 'USER_NOT_FOUND');
}

class DuplicateEmailException extends AuthenticationException {
  const DuplicateEmailException()
      : super('Email đã được sử dụng', code: 'DUPLICATE_EMAIL');
}

class InvalidTokenException extends AuthenticationException {
  const InvalidTokenException()
      : super('Mã xác thực không hợp lệ', code: 'INVALID_TOKEN');
}

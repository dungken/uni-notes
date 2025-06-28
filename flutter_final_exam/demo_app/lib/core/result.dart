import 'exceptions.dart';

/// Result wrapper for success/failure states
sealed class Result<T> {
  const Result();
}

final class Success<T> extends Result<T> {
  final T data;
  const Success(this.data);
}

final class Failure<T> extends Result<T> {
  final AppException exception;
  const Failure(this.exception);
}

/// Result extensions
extension ResultExtension<T> on Result<T> {
  bool get isSuccess => this is Success<T>;
  bool get isFailure => this is Failure<T>;
  
  T? get dataOrNull => switch (this) {
    Success<T>(data: final data) => data,
    Failure<T>() => null,
  };
  
  AppException? get exceptionOrNull => switch (this) {
    Success<T>() => null,
    Failure<T>(exception: final exception) => exception,
  };
  
  R fold<R>(
    R Function(T data) onSuccess,
    R Function(AppException exception) onFailure,
  ) => switch (this) {
    Success<T>(data: final data) => onSuccess(data),
    Failure<T>(exception: final exception) => onFailure(exception),
  };
}

/// Result helpers
abstract class ResultHelper {
  static Result<T> success<T>(T data) => Success(data);
  static Result<T> failure<T>(AppException exception) => Failure(exception);
  
  static Future<Result<T>> safeCall<T>(Future<T> Function() call) async {
    try {
      final result = await call();
      return Success(result);
    } on AppException catch (e) {
      return Failure(e);
    } catch (e) {
      return Failure(AuthenticationException('Đã xảy ra lỗi không mong muốn', originalError: e));
    }
  }
}

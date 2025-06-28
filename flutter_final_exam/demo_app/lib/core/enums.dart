/// User gender options
enum Gender {
  male('Nam'),
  female('Nữ'),
  other('Khác');

  const Gender(this.displayName);
  final String displayName;

  static Gender? fromString(String value) {
    return Gender.values
        .where((gender) => gender.displayName == value)
        .firstOrNull;
  }
}

/// Authentication status
enum AuthStatus {
  initial,
  loading,
  authenticated,
  unauthenticated,
  error,
  registrationSuccess,
  passwordResetEmailSent,
  passwordResetSuccess,
  emailVerificationSuccess,
  userUpdateSuccess;
}

/// Form validation status
enum ValidationStatus {
  initial,
  valid,
  invalid;
}

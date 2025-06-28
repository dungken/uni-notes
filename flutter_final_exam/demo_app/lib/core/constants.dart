/// Application constants
class AppConstants {
  // Database
  static const String databaseName = 'demo_app.db';
  static const String usersTable = 'users';
  static const int databaseVersion = 1;
  
  // Email Configuration
  static const String smtpHost = 'smtp.gmail.com';
  static const int smtpPort = 587;
  static const String fromEmail = 'brave2112love@gmail.com';
  static const String fromPassword = 'lnrcqhxvobowhcci';
  static const String fromName = 'Demo App';
  
  // Validation Rules
  static const int minPasswordLength = 6;
  static const int maxPasswordLength = 50;
  static const int minNameLength = 2;
  static const int maxNameLength = 50;
  static const int minAge = 5;
  static const int maxAge = 120;
  
  // Token Expiry
  static const Duration resetTokenExpiry = Duration(hours: 1);
  static const Duration verificationCodeExpiry = Duration(minutes: 15);
  
  // UI Constants
  static const double defaultPadding = 16.0;
  static const double defaultBorderRadius = 12.0;
  static const double buttonHeight = 50.0;
  
  // Regex Patterns
  static const String emailPattern = r'^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$';
  static const String vietnamesePhonePattern = r'^(0[3|5|7|8|9]|84[3|5|7|8|9])[0-9]{8,9}$';
  static const String namePattern = r'^[a-zA-ZÀ-ỹ\s]+$';
  
  // App Info
  static const String appName = 'Demo App';
  static const String appVersion = '1.0.0';
  static const String supportEmail = 'brave2112love@gmail.com';
  
  AppConstants._();
}

import 'package:equatable/equatable.dart';
import '../core/enums.dart';

/// User model representing a registered user in the system
class User extends Equatable {
  /// Unique identifier for the user
  final int? id;
  
  /// User's full name
  final String name;
  
  /// User's email address (used for login)
  final String email;
  
  /// User's phone number
  final String phone;
  
  /// User's birth date in ISO format (YYYY-MM-DD)
  final String birthDate;
  
  /// User's gender
  final Gender gender;
  
  /// Hashed password (never store plain text)
  final String password;
  
  /// Password reset token (nullable)
  final String? resetToken;
  
  /// Reset token expiry timestamp
  final DateTime? resetTokenExpiry;
  
  /// Account creation timestamp
  final DateTime? createdAt;
  
  /// Last login timestamp
  final DateTime? lastLoginAt;
  
  /// Whether the email is verified
  final bool isEmailVerified;
  
  /// Account status (active, suspended, etc.)
  final bool isActive;

  const User({
    this.id,
    required this.name,
    required this.email,
    required this.phone,
    required this.birthDate,
    required this.gender,
    required this.password,
    this.resetToken,
    this.resetTokenExpiry,
    this.createdAt,
    this.lastLoginAt,
    this.isEmailVerified = false,
    this.isActive = true,
  });

  /// Convert User to Map for database storage
  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'name': name,
      'email': email,
      'phone': phone,
      'birth_date': birthDate,
      'gender': gender.displayName,
      'password': password,
      'reset_token': resetToken,
      'reset_token_expiry': resetTokenExpiry?.millisecondsSinceEpoch,
      'created_at': createdAt?.millisecondsSinceEpoch ?? DateTime.now().millisecondsSinceEpoch,
      'last_login_at': lastLoginAt?.millisecondsSinceEpoch,
      'is_email_verified': isEmailVerified ? 1 : 0,
      'is_active': isActive ? 1 : 0,
    };
  }

  /// Create User from Map (database row)
  factory User.fromMap(Map<String, dynamic> map) {
    return User(
      id: map['id']?.toInt(),
      name: map['name'] ?? '',
      email: map['email'] ?? '',
      phone: map['phone'] ?? '',
      birthDate: map['birth_date'] ?? '',
      gender: Gender.fromString(map['gender']) ?? Gender.other,
      password: map['password'] ?? '',
      resetToken: map['reset_token'],
      resetTokenExpiry: map['reset_token_expiry'] != null 
          ? DateTime.fromMillisecondsSinceEpoch(map['reset_token_expiry'])
          : null,
      createdAt: map['created_at'] != null 
          ? DateTime.fromMillisecondsSinceEpoch(map['created_at'])
          : null,
      lastLoginAt: map['last_login_at'] != null 
          ? DateTime.fromMillisecondsSinceEpoch(map['last_login_at'])
          : null,
      isEmailVerified: (map['is_email_verified'] ?? 0) == 1,
      isActive: (map['is_active'] ?? 1) == 1,
    );
  }

  /// Create a copy of User with modified fields
  User copyWith({
    int? id,
    String? name,
    String? email,
    String? phone,
    String? birthDate,
    Gender? gender,
    String? password,
    String? resetToken,
    DateTime? resetTokenExpiry,
    DateTime? createdAt,
    DateTime? lastLoginAt,
    bool? isEmailVerified,
    bool? isActive,
  }) {
    return User(
      id: id ?? this.id,
      name: name ?? this.name,
      email: email ?? this.email,
      phone: phone ?? this.phone,
      birthDate: birthDate ?? this.birthDate,
      gender: gender ?? this.gender,
      password: password ?? this.password,
      resetToken: resetToken ?? this.resetToken,
      resetTokenExpiry: resetTokenExpiry ?? this.resetTokenExpiry,
      createdAt: createdAt ?? this.createdAt,
      lastLoginAt: lastLoginAt ?? this.lastLoginAt,
      isEmailVerified: isEmailVerified ?? this.isEmailVerified,
      isActive: isActive ?? this.isActive,
    );
  }

  /// Clear sensitive data for safe serialization
  User withoutSensitiveData() {
    return copyWith(
      password: '***',
      resetToken: null,
    );
  }

  /// Get user's age from birth date
  int? get age {
    try {
      final birthDateTime = DateTime.parse(birthDate);
      final now = DateTime.now();
      int age = now.year - birthDateTime.year;
      
      if (now.month < birthDateTime.month || 
          (now.month == birthDateTime.month && now.day < birthDateTime.day)) {
        age--;
      }
      
      return age;
    } catch (e) {
      return null;
    }
  }

  /// Check if reset token is still valid
  bool get isResetTokenValid {
    if (resetToken == null || resetTokenExpiry == null) return false;
    return DateTime.now().isBefore(resetTokenExpiry!);
  }

  /// Get formatted birth date (DD/MM/YYYY)
  String get formattedBirthDate {
    try {
      final date = DateTime.parse(birthDate);
      return '${date.day.toString().padLeft(2, '0')}/${date.month.toString().padLeft(2, '0')}/${date.year}';
    } catch (e) {
      return birthDate;
    }
  }

  /// Get display name (first part of full name)
  String get firstName {
    final parts = name.trim().split(' ');
    return parts.isNotEmpty ? parts.first : name;
  }

  @override
  List<Object?> get props => [
        id,
        name,
        email,
        phone,
        birthDate,
        gender,
        password,
        resetToken,
        resetTokenExpiry,
        createdAt,
        lastLoginAt,
        isEmailVerified,
        isActive,
      ];

  @override
  String toString() {
    return 'User(id: $id, name: $name, email: $email, gender: ${gender.displayName}, isActive: $isActive)';
  }
}

import 'package:email_validator/email_validator.dart';
import '../core/constants.dart';
import '../core/enums.dart';

/// Password strength levels
enum PasswordStrength {
  veryWeak('Rất yếu', 0),
  weak('Yếu', 1),
  fair('Trung bình', 2),
  good('Tốt', 3),
  strong('Mạnh', 4);

  const PasswordStrength(this.label, this.score);
  final String label;
  final int score;
}

/// Comprehensive validation utilities
class ValidationUtils {
  // Private constructor to prevent instantiation
  ValidationUtils._();

  /// Validate email address
  static String? validateEmail(String? email) {
    if (email == null || email.trim().isEmpty) {
      return 'Email không được để trống';
    }

    final trimmedEmail = email.trim().toLowerCase();
    
    if (!EmailValidator.validate(trimmedEmail)) {
      return 'Email không đúng định dạng';
    }

    // Check for common typos
    final emailParts = trimmedEmail.split('@');
    if (emailParts.length == 2) {
      final domain = emailParts[1];
      // Suggest corrections for common typos
      if (domain == 'gmial.com' || domain == 'gmai.com') {
        return 'Có phải bạn muốn nhập gmail.com?';
      }
      if (domain == 'yahoo.co' || domain == 'yahooo.com') {
        return 'Có phải bạn muốn nhập yahoo.com?';
      }
    }

    if (trimmedEmail.length > 254) {
      return 'Email quá dài (tối đa 254 ký tự)';
    }

    return null;
  }

  /// Validate password with strength checking
  static String? validatePassword(String? password) {
    if (password == null || password.isEmpty) {
      return 'Mật khẩu không được để trống';
    }

    if (password.length < AppConstants.minPasswordLength) {
      return 'Mật khẩu phải có ít nhất ${AppConstants.minPasswordLength} ký tự';
    }

    if (password.length > AppConstants.maxPasswordLength) {
      return 'Mật khẩu không được vượt quá ${AppConstants.maxPasswordLength} ký tự';
    }

    // Check for common weak passwords
    final weakPasswords = [
      '123456', 'password', 'admin', 'qwerty', 'abc123',
      '111111', '123123', 'admin123', 'root', 'user'
    ];
    
    if (weakPasswords.contains(password.toLowerCase())) {
      return 'Mật khẩu quá yếu, vui lòng chọn mật khẩu khác';
    }

    return null;
  }

  /// Get password strength level
  static PasswordStrength getPasswordStrength(String? password) {
    if (password == null || password.isEmpty) {
      return PasswordStrength.veryWeak;
    }

    int score = 0;
    
    // Length check
    if (password.length >= 8) score++;
    if (password.length >= 12) score++;
    
    // Character variety
    if (RegExp(r'[a-z]').hasMatch(password)) score++;
    if (RegExp(r'[A-Z]').hasMatch(password)) score++;
    if (RegExp(r'[0-9]').hasMatch(password)) score++;
    if (RegExp(r'[!@#$%^&*(),.?":{}|<>]').hasMatch(password)) score++;
    
    // Penalize common patterns
    if (RegExp(r'(.)\1{2,}').hasMatch(password)) score--; // Repeated characters
    if (RegExp(r'(012|123|234|345|456|567|678|789|890)').hasMatch(password)) score--; // Sequential numbers
    if (RegExp(r'(abc|bcd|cde|def|efg|fgh|ghi|hij|ijk|jkl|klm|lmn|mno|nop|opq|pqr|qrs|rst|stu|tuv|uvw|vwx|wxy|xyz)', caseSensitive: false).hasMatch(password)) score--; // Sequential letters
    
    // Ensure minimum score
    score = score.clamp(0, 5);
    
    switch (score) {
      case 0:
      case 1:
        return PasswordStrength.veryWeak;
      case 2:
        return PasswordStrength.weak;
      case 3:
        return PasswordStrength.fair;
      case 4:
        return PasswordStrength.good;
      case 5:
      default:
        return PasswordStrength.strong;
    }
  }

  /// Validate name
  static String? validateName(String? name) {
    if (name == null || name.trim().isEmpty) {
      return 'Họ tên không được để trống';
    }

    final trimmedName = name.trim();
    
    if (trimmedName.length < AppConstants.minNameLength) {
      return 'Họ tên phải có ít nhất ${AppConstants.minNameLength} ký tự';
    }

    if (trimmedName.length > AppConstants.maxNameLength) {
      return 'Họ tên không được vượt quá ${AppConstants.maxNameLength} ký tự';
    }

    // Check for valid Vietnamese name pattern
    if (!RegExp(AppConstants.namePattern).hasMatch(trimmedName)) {
      return 'Họ tên chỉ được chứa chữ cái và khoảng trắng';
    }

    // Check for excessive spaces
    if (RegExp(r'\s{2,}').hasMatch(trimmedName)) {
      return 'Họ tên không được chứa nhiều khoảng trắng liên tiếp';
    }

    // Check for numbers
    if (RegExp(r'\d').hasMatch(trimmedName)) {
      return 'Họ tên không được chứa số';
    }

    return null;
  }

  /// Validate Vietnamese phone number
  static String? validatePhone(String? phone) {
    if (phone == null || phone.trim().isEmpty) {
      return 'Số điện thoại không được để trống';
    }

    // Remove all non-digit characters
    final cleanPhone = phone.replaceAll(RegExp(r'[^0-9]'), '');
    
    if (cleanPhone.isEmpty) {
      return 'Số điện thoại không hợp lệ';
    }

    // Check length
    if (cleanPhone.length < 10 || cleanPhone.length > 11) {
      return 'Số điện thoại phải có 10-11 chữ số';
    }
    
    // Check Vietnamese phone number format
    if (!RegExp(AppConstants.vietnamesePhonePattern).hasMatch(cleanPhone)) {
      return 'Số điện thoại không đúng định dạng Việt Nam';
    }

    return null;
  }

  /// Validate birth date
  static String? validateBirthDate(String? birthDate) {
    if (birthDate == null || birthDate.trim().isEmpty) {
      return 'Ngày sinh không được để trống';
    }
    
    try {
      DateTime parsedDate;
      
      // Try different date formats
      if (birthDate.contains('/')) {
        // DD/MM/YYYY format
        final parts = birthDate.split('/');
        if (parts.length != 3) {
          return 'Định dạng ngày sinh không hợp lệ (DD/MM/YYYY)';
        }
        
        final day = int.parse(parts[0]);
        final month = int.parse(parts[1]);
        final year = int.parse(parts[2]);
        
        parsedDate = DateTime(year, month, day);
      } else {
        // ISO format YYYY-MM-DD
        parsedDate = DateTime.parse(birthDate);
      }
      
      final now = DateTime.now();
      
      // Check if date is in the future
      if (parsedDate.isAfter(now)) {
        return 'Ngày sinh không thể là ngày trong tương lai';
      }
      
      // Calculate age
      int age = now.year - parsedDate.year;
      if (now.month < parsedDate.month || 
          (now.month == parsedDate.month && now.day < parsedDate.day)) {
        age--;
      }
      
      if (age < AppConstants.minAge) {
        return 'Tuổi phải lớn hơn ${AppConstants.minAge}';
      }
      
      if (age > AppConstants.maxAge) {
        return 'Tuổi không được vượt quá ${AppConstants.maxAge}';
      }
      
      // Check for reasonable birth year
      if (parsedDate.year < 1900) {
        return 'Năm sinh không hợp lệ';
      }
      
    } catch (e) {
      return 'Ngày sinh không đúng định dạng';
    }
    
    return null;
  }

  /// Validate gender
  static String? validateGender(Gender? gender) {
    if (gender == null) {
      return 'Vui lòng chọn giới tính';
    }
    return null;
  }

  /// Validate confirm password
  static String? validateConfirmPassword(String? password, String? confirmPassword) {
    if (confirmPassword == null || confirmPassword.isEmpty) {
      return 'Xác nhận mật khẩu không được để trống';
    }
    
    if (password != confirmPassword) {
      return 'Mật khẩu xác nhận không khớp';
    }
    
    return null;
  }

  /// Format phone number for display
  static String formatPhoneNumber(String phone) {
    final cleanPhone = phone.replaceAll(RegExp(r'[^0-9]'), '');
    
    if (cleanPhone.length >= 10) {
      if (cleanPhone.startsWith('84') && cleanPhone.length == 11) {
        // International format: +84 xxx xxx xxx
        return '+84 ${cleanPhone.substring(2, 5)} ${cleanPhone.substring(5, 8)} ${cleanPhone.substring(8)}';
      } else if (cleanPhone.startsWith('0') && cleanPhone.length == 10) {
        // Local format: 0xxx xxx xxx
        return '${cleanPhone.substring(0, 4)} ${cleanPhone.substring(4, 7)} ${cleanPhone.substring(7)}';
      }
    }
    
    return phone; // Return original if can't format
  }

  /// Format date from ISO to display format
  static String formatDateForDisplay(String isoDate) {
    try {
      final date = DateTime.parse(isoDate);
      return '${date.day.toString().padLeft(2, '0')}/${date.month.toString().padLeft(2, '0')}/${date.year}';
    } catch (e) {
      return isoDate;
    }
  }

  /// Convert display date to ISO format
  static String formatDateForStorage(String displayDate) {
    try {
      final parts = displayDate.split('/');
      if (parts.length == 3) {
        final day = parts[0].padLeft(2, '0');
        final month = parts[1].padLeft(2, '0');
        final year = parts[2];
        return '$year-$month-$day';
      }
    } catch (e) {
      // If conversion fails, try to parse as-is
    }
    return displayDate;
  }

  /// Sanitize input by removing extra whitespace and special characters
  static String sanitizeInput(String input) {
    return input.trim().replaceAll(RegExp(r'\s+'), ' ');
  }

  /// Check if string contains only Vietnamese characters, letters and spaces
  static bool isValidVietnameseName(String name) {
    return RegExp(r'^[a-zA-ZÀ-ỹ\s]+$').hasMatch(name);
  }

  /// Remove Vietnamese accents for comparison purposes
  static String removeVietnameseAccents(String str) {
    const vietnamese = 'àáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđ';
    const english = 'aaaaaaaaaaaaaaaaaeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyd';
    
    String result = str.toLowerCase();
    for (int i = 0; i < vietnamese.length; i++) {
      result = result.replaceAll(vietnamese[i], english[i]);
    }
    
    return result;
  }

  /// Validate form field generically
  static String? validateRequired(String? value, String fieldName) {
    if (value == null || value.trim().isEmpty) {
      return '$fieldName không được để trống';
    }
    return null;
  }

  /// Check if email domain is from a disposable email service
  static bool isDisposableEmail(String email) {
    final disposableDomains = [
      '10minutemail.com', 'tempmail.org', 'guerrillamail.com',
      'mailinator.com', 'yopmail.com', 'temp-mail.org'
    ];
    
    final domain = email.split('@').last.toLowerCase();
    return disposableDomains.contains(domain);
  }

  /// Get validation error message for common validation scenarios
  static String getValidationMessage(ValidationStatus status, String fieldName) {
    switch (status) {
      case ValidationStatus.initial:
        return '';
      case ValidationStatus.valid:
        return '';
      case ValidationStatus.invalid:
        return '$fieldName không hợp lệ';
    }
  }
}

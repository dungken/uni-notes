# Hướng dẫn cấu hình Email cho Demo App

## 📧 Tổng quan
Ứng dụng Demo App sử dụng SMTP để gửi email tự động bao gồm:
- Email chào mừng sau khi đăng ký
- Email đặt lại mật khẩu
- Email xác thực tài khoản

## 🔧 Cấu hình Email

### Bước 1: Chọn phương thức gửi email

#### Option A: Sử dụng Gmail (Production)
1. Tạo App Password cho Gmail:
   - Đăng nhập Gmail > Cài đặt > Bảo mật
   - Bật xác thực 2 bước
   - Tạo App Password (16 ký tự)

2. Cấu hình trong `lib/core/constants.dart`:
```dart
static const bool useTestEmail = false;
static const String fromEmail = 'your-email@gmail.com';
static const String fromPassword = 'your-16-char-app-password';
```

#### Option B: Sử dụng Mailtrap (Testing)
1. Đăng ký tại https://mailtrap.io
2. Tạo inbox mới
3. Copy thông tin SMTP

4. Cấu hình trong `lib/core/constants.dart`:
```dart
static const bool useTestEmail = true;
static const String testSmtpHost = 'smtp.mailtrap.io';
static const int testSmtpPort = 587;
static const String testSmtpUser = 'your-mailtrap-user';
static const String testSmtpPassword = 'your-mailtrap-password';
```

### Bước 2: Cập nhật constants.dart
Mở file `lib/core/constants.dart` và thay đổi các giá trị sau:

```dart
// Email Configuration
static const String fromEmail = 'YOUR_EMAIL@gmail.com'; 
static const String fromPassword = 'YOUR_APP_PASSWORD'; 

// For testing
static const bool useTestEmail = true; // false for production
static const String testSmtpUser = 'YOUR_MAILTRAP_USER';
static const String testSmtpPassword = 'YOUR_MAILTRAP_PASSWORD';
```

### Bước 3: Test cấu hình email
Trong ứng dụng, bạn có thể test email bằng cách:
1. Đăng ký tài khoản mới
2. Thử chức năng quên mật khẩu
3. Kiểm tra email được gửi

## 🚀 Chạy ứng dụng

### Bước 1: Cài đặt dependencies
```bash
cd /path/to/demo_app
flutter pub get
```

### Bước 2: Chạy ứng dụng
```bash
flutter run
```

## 📱 Tính năng đã hoàn thiện

### ✅ Authentication Flow với BLoC
- [x] Đăng ký tài khoản với validation đầy đủ
- [x] Đăng nhập với ghi nhớ thông tin
- [x] Quên mật khẩu với email reset
- [x] Đăng xuất an toàn

### ✅ Database Management
- [x] SQLite database với migration
- [x] CRUD operations cho User
- [x] Password hashing với SHA256
- [x] Token management cho password reset

### ✅ Email System
- [x] Welcome email sau đăng ký
- [x] Password reset email với token
- [x] Email verification system
- [x] Beautiful HTML email templates
- [x] Support cả Gmail và test SMTP

### ✅ UI/UX
- [x] Material Design 3
- [x] Responsive design
- [x] Smooth animations
- [x] Loading states
- [x] Error handling
- [x] Success notifications
- [x] Vietnamese localization

### ✅ State Management
- [x] BLoC pattern implementation
- [x] Clean architecture
- [x] Error handling với Result pattern
- [x] Loading states management

### ✅ Validation & Security
- [x] Comprehensive form validation
- [x] Vietnamese phone number validation
- [x] Email format validation
- [x] Password strength checking
- [x] Input sanitization

## 🛠️ Các file quan trọng đã hoàn thiện

### Core Architecture
- `lib/main.dart` - App entry point với BLoC setup
- `lib/core/constants.dart` - App constants và config
- `lib/core/result.dart` - Result pattern implementation
- `lib/core/exceptions.dart` - Custom exception classes
- `lib/core/enums.dart` - App enums

### Models & Data
- `lib/models/user.dart` - User model với validation
- `lib/services/database_service.dart` - SQLite operations
- `lib/services/email_service.dart` - SMTP email service

### State Management
- `lib/blocs/auth/auth_bloc.dart` - Authentication BLoC
- `lib/blocs/auth/auth_event.dart` - Auth events
- `lib/blocs/auth/auth_state.dart` - Auth states

### UI Screens
- `lib/screens/login_screen.dart` - Login with animations
- `lib/screens/register_screen.dart` - Registration form
- `lib/screens/forgot_password_screen.dart` - Password reset
- `lib/screens/home_screen.dart` - User dashboard

### Reusable Widgets
- `lib/widgets/custom_button.dart` - Styled buttons
- `lib/widgets/custom_text_field.dart` - Form inputs
- `lib/widgets/loading_overlay.dart` - Loading states

### Utilities
- `lib/utils/validation_utils.dart` - Form validation

## 🎯 Cách sử dụng

### 1. Đăng ký tài khoản
- Nhập đầy đủ thông tin: tên, email, số điện thoại, ngày sinh, giới tính, mật khẩu
- Validation real-time cho tất cả fields
- Nhận email chào mừng sau khi đăng ký thành công

### 2. Đăng nhập
- Nhập email và mật khẩu
- Tùy chọn "Ghi nhớ đăng nhập"
- Auto-login lần sau nếu đã chọn ghi nhớ

### 3. Quên mật khẩu
- Nhập email đã đăng ký
- Nhận email với link reset password
- Link có hiệu lực 1 giờ

### 4. Trang chủ
- Hiển thị thông tin tài khoản
- Thống kê sử dụng
- Các thao tác nhanh
- Đăng xuất an toàn

## 🔧 Troubleshooting

### Lỗi Email không gửi được
1. Kiểm tra thông tin SMTP trong constants.dart
2. Đảm bảo App Password đúng cho Gmail
3. Kiểm tra kết nối internet
4. Thử dùng Mailtrap cho testing

### Lỗi Database
1. Xóa app data và cài lại
2. Kiểm tra permissions trên device
3. Restart app

### Lỗi Build
1. Chạy `flutter clean`
2. Chạy `flutter pub get`
3. Restart IDE

## 📧 Support
Nếu gặp vấn đề, vui lòng:
1. Kiểm tra log console
2. Đảm bảo đã cấu hình email đúng
3. Test trên device thật thay vì emulator

## 🚀 Next Steps (Tính năng có thể mở rộng)
- [ ] Edit profile functionality
- [ ] Change password in-app
- [ ] Email verification với OTP
- [ ] Social login (Google, Facebook)
- [ ] Dark/Light theme toggle
- [ ] Multi-language support
- [ ] Push notifications
- [ ] Biometric authentication
- [ ] Export user data
- [ ] Account deletion

---

**Demo App v1.0.0**  
© 2025 - Ứng dụng demo với đầy đủ tính năng authentication và email system

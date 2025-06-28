# 🚀 Demo App - Flutter Authentication System

<div align="center">

![Flutter](https://img.shields.io/badge/Flutter-02569B?style=for-the-badge&logo=flutter&logoColor=white)
![Dart](https://img.shields.io/badge/Dart-0175C2?style=for-the-badge&logo=dart&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-07405E?style=for-the-badge&logo=sqlite&logoColor=white)
![BLoC](https://img.shields.io/badge/BLoC-FF6B35?style=for-the-badge)

Ứng dụng Flutter demo hoàn chỉnh với authentication, email tự động và SQLite database

</div>

## ✨ Tính năng

### 🔐 Authentication System
- **Đăng ký tài khoản** với validation đầy đủ
- **Đăng nhập** với tùy chọn ghi nhớ
- **Quên mật khẩu** với email reset link
- **Đăng xuất** an toàn

### 📧 Email System (Đã cấu hình Gmail)
- ✅ **Gmail SMTP:** brave2112love@gmail.com
- ✅ **Welcome email** sau đăng ký thành công  
- ✅ **New password email** - Tự động tạo mật khẩu mới
- ✅ **Email verification** với OTP code
- ✅ **Beautiful responsive HTML templates**

### 💾 Database Management
- **SQLite database** với auto-migration
- **Password hashing** với SHA256
- **Secure token management**
- **CRUD operations** hoàn chỉnh

### 🎨 UI/UX Excellence
- **Material Design 3** với gradient backgrounds
- **Smooth animations** và micro-interactions
- **Loading states** user-friendly
- **Vietnamese localization** hoàn chỉnh

## 🚀 Cài đặt & Chạy

### 1. Clone & Setup
```bash
git clone <repo-url>
cd demo_app
flutter pub get
```

### 2. Chạy ứng dụng
```bash
flutter run
```

**📧 Email đã được cấu hình sẵn và sẵn sàng sử dụng!**

## 🎯 Cách sử dụng

### 1. 👤 Đăng ký tài khoản
- Điền form đăng ký đầy đủ
- Nhận welcome email tự động
- Chuyển về màn hình đăng nhập

### 2. 🔑 Đăng nhập  
- Nhập email + mật khẩu
- Chọn "Ghi nhớ" nếu muốn
- Vào dashboard cá nhân

### 3. 🔒 Quên mật khẩu (Mới cải tiến!)
- Nhập email đã đăng ký
- **Hệ thống tự động tạo mật khẩu mới**
- **Nhận mật khẩu qua email ngay lập tức**
- Đăng nhập bằng mật khẩu mới và có thể đổi lại

### 4. 🏠 Trang chủ
- Xem thông tin tài khoản
- Thống kê sử dụng
- Đăng xuất an toàn

## 🛠️ Tech Stack

| Component | Technology |
|-----------|------------|
| **Framework** | Flutter 3.24+ |
| **State Management** | BLoC Pattern |
| **Database** | SQLite + sqflite |
| **Email** | Gmail SMTP |
| **Architecture** | Clean Architecture |

## 📱 Screenshots

Demo các màn hình chính:
- Login Screen với smooth animations
- Register Form với validation real-time  
- Home Dashboard với user info
- Forgot Password với email integration

## 🎉 Tính năng nổi bật

- 🚀 **Production Ready** - Sử dụng Gmail thật
- 🔒 **Security First** - Password hashing + token management
- 🎨 **Modern UI** - Material Design 3 + animations
- 📧 **Real Email** - Welcome, reset, verification emails
- 🏗️ **Clean Code** - BLoC pattern + clean architecture
- 📱 **Cross Platform** - Android, iOS, Web, Desktop

## 🔧 Customization

Để thay đổi email configuration:
1. Mở `lib/core/constants.dart`
2. Cập nhật `fromEmail` và `fromPassword`
3. Restart app

## 🤝 Contributing

1. Fork the project
2. Create feature branch
3. Commit changes
4. Push to branch
5. Open Pull Request

---

<div align="center">

**⭐ Star this repo if you find it helpful! ⭐**

Made with ❤️ using Flutter & BLoC

</div>

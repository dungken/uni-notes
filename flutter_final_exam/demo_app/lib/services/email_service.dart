import 'dart:math';
import 'package:mailer/mailer.dart';
import 'package:mailer/smtp_server.dart';

import '../core/constants.dart';
import '../core/result.dart';

class EmailService {
  static EmailService? _instance;
  EmailService._internal();
  factory EmailService() => _instance ??= EmailService._internal();

  SmtpServer get _smtpServer {
    return gmail(AppConstants.fromEmail, AppConstants.fromPassword);
  }

  String generateVerificationCode() {
    final random = Random();
    return (100000 + random.nextInt(900000)).toString();
  }

  String generateResetToken() {
    const chars = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
    final random = Random();
    return String.fromCharCodes(
      Iterable.generate(32, (_) => chars.codeUnitAt(random.nextInt(chars.length)))
    );
  }

  Message _createMessage({
    required String to,
    required String subject,
    required String htmlBody,
  }) {
    return Message()
      ..from = const Address(AppConstants.fromEmail, AppConstants.fromName)
      ..recipients.add(to)
      ..subject = subject
      ..html = _wrapWithTemplate(htmlBody);
  }

  String _wrapWithTemplate(String content) {
    return '''
    <!DOCTYPE html>
    <html>
    <head>
        <meta charset="UTF-8">
        <style>
            body { font-family: Arial, sans-serif; line-height: 1.6; color: #333; margin: 0; padding: 0; }
            .container { max-width: 600px; margin: 0 auto; background: #fff; }
            .header { 
                background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); 
                padding: 30px; 
                text-align: center; 
                color: white; 
            }
            .header h1 { 
                margin: 0; 
                font-size: 28px; 
                font-weight: bold;
                text-shadow: 0 2px 4px rgba(0,0,0,0.3);
            }
            .content { 
                padding: 30px; 
                background: #ffffff;
            }
            .content h2 {
                color: #333;
                margin-bottom: 20px;
                font-size: 24px;
            }
            .content p {
                color: #666;
                margin-bottom: 15px;
                font-size: 16px;
                line-height: 1.6;
            }
            .footer { 
                background: #333; 
                padding: 20px; 
                text-align: center; 
                color: #999; 
                font-size: 12px; 
            }
            .button { 
                display: inline-block; 
                background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
                color: white !important; 
                padding: 15px 30px; 
                text-decoration: none; 
                border-radius: 25px; 
                font-weight: bold; 
                margin: 20px 0;
                box-shadow: 0 4px 15px rgba(102, 126, 234, 0.4);
            }
            .code { 
                background: linear-gradient(135deg, #f8f9fa 0%, #e9ecef 100%);
                padding: 25px; 
                border-radius: 12px; 
                text-align: center; 
                margin: 25px 0;
                border: 2px solid #667eea;
            }
            .code h1 { 
                color: #667eea; 
                font-size: 36px; 
                margin: 0; 
                letter-spacing: 4px; 
                font-family: monospace;
            }
            .alert-success {
                background: #d4edda;
                color: #155724;
                padding: 15px;
                border-radius: 8px;
                margin: 20px 0;
                border-left: 4px solid #28a745;
            }
            .alert-warning {
                background: #fff3cd;
                color: #856404;
                padding: 15px;
                border-radius: 8px;
                margin: 20px 0;
                border-left: 4px solid #ffc107;
            }
            .info-box {
                background: #f8f9fa;
                padding: 20px;
                border-radius: 8px;
                margin: 20px 0;
                border: 1px solid #e9ecef;
            }
            @media only screen and (max-width: 600px) {
                .container { margin: 0 10px; }
                .header, .content, .footer { padding: 20px; }
                .code h1 { font-size: 28px; letter-spacing: 2px; }
            }
        </style>
    </head>
    <body>
        <div class="container">
            <div class="header">
                <h1>${AppConstants.appName}</h1>
                <p>Ứng dụng quản lý tài khoản thông minh</p>
            </div>
            <div class="content">
                $content
            </div>
            <div class="footer">
                <p><strong>© 2025 ${AppConstants.appName}</strong> - Tất cả quyền được bảo lưu.</p>
                <p>Email tự động, vui lòng không trả lời trực tiếp.</p>
                <p>Liên hệ hỗ trợ: ${AppConstants.supportEmail}</p>
            </div>
        </div>
    </body>
    </html>
    ''';
  }

  Future<Result<bool>> sendWelcomeEmail(String toEmail, String userName) async {
    return ResultHelper.safeCall(() async {
      final content = '''
        <h2>🎉 Chào mừng $userName!</h2>
        <p>Cảm ơn bạn đã đăng ký tài khoản <strong>${AppConstants.appName}</strong>. 
        Tài khoản của bạn đã được tạo thành công và sẵn sàng sử dụng!</p>
        
        <div class="alert-success">
          <p style="margin: 0;"><strong>✅ Tài khoản đã được kích hoạt thành công</strong></p>
        </div>
        
        <div class="info-box">
          <h3 style="margin-top: 0;">📋 Thông tin tài khoản</h3>
          <p style="margin: 5px 0;"><strong>📧 Email:</strong> $toEmail</p>
          <p style="margin: 5px 0;"><strong>👤 Tên:</strong> $userName</p>
          <p style="margin: 5px 0;"><strong>📅 Ngày đăng ký:</strong> ${_getCurrentDate()}</p>
          <p style="margin: 5px 0;"><strong>🔐 Bảo mật:</strong> Tài khoản được mã hóa an toàn</p>
        </div>
        
        <div class="alert-warning">
          <p style="margin: 0;"><strong>🛡️ Lưu ý bảo mật:</strong><br>
          • Không chia sẻ mật khẩu với bất kỳ ai<br>
          • Sử dụng mật khẩu mạnh và độc đáo<br>
          • Đăng xuất khi sử dụng máy tính chung</p>
        </div>
        
        <p>Nếu bạn có bất kỳ câu hỏi nào, đừng ngần ngại liên hệ với chúng tôi tại 
        <a href="mailto:${AppConstants.supportEmail}" style="color: #667eea;">${AppConstants.supportEmail}</a></p>
        
        <p>Chúc bạn có trải nghiệm tuyệt vời! 🌟<br>
        <strong>Đội ngũ ${AppConstants.appName}</strong></p>
      ''';

      final message = _createMessage(
        to: toEmail,
        subject: 'Chào mừng bạn đến với ${AppConstants.appName}! 🎉',
        htmlBody: content,
      );

      await send(message, _smtpServer);
      return true;
    });
  }

  Future<Result<bool>> sendNewPasswordEmail(String toEmail, String userName, String newPassword) async {
    return ResultHelper.safeCall(() async {
      final content = '''
        <h2>🔑 Mật khẩu mới</h2>
        <p>Chào <strong>$userName</strong>,</p>
        <p>Chúng tôi đã tạo mật khẩu mới cho tài khoản <strong>$toEmail</strong> theo yêu cầu của bạn.</p>
        
        <div class="code">
          <p style="color: #667eea; font-size: 14px; margin-bottom: 10px; font-weight: 600;">
            MẬT KHẨU MỚI
          </p>
          <h1>$newPassword</h1>
          <p style="color: #666; font-size: 12px; margin-top: 10px;">
            Vui lòng đổi mật khẩu sau khi đăng nhập
          </p>
        </div>
        
        <div class="alert-warning">
          <p style="margin: 0;"><strong>⚠️ Lưu ý bảo mật:</strong><br>
          • Sử dụng mật khẩu này để <strong>đăng nhập ngay</strong><br>
          • Đổi mật khẩu mạnh hơn sau khi đăng nhập<br>
          • Không chia sẻ mật khẩu với bất kỳ ai<br>
          • Xóa email này sau khi đăng nhập thành công</p>
        </div>
        
        <div class="info-box">
          <h3 style="margin-top: 0;">📅 Thông tin yêu cầu</h3>
          <p style="margin: 5px 0;">
            <strong>Thời gian:</strong> ${_getCurrentDateTime()}<br>
            <strong>Email:</strong> $toEmail<br>
            <strong>Tình trạng:</strong> Mật khẩu đã được đặt lại
          </p>
        </div>
        
        <div class="alert-success">
          <p style="margin: 0;">
            <strong>✅ Hướng dẫn đăng nhập:</strong><br>
            1. Mở ứng dụng ${AppConstants.appName}<br>
            2. Nhập email: <code>$toEmail</code><br>
            3. Nhập mật khẩu: <code>$newPassword</code><br>
            4. Đăng nhập và đổi mật khẩu mới
          </p>
        </div>
        
        <p><strong>Không phải bạn yêu cầu?</strong><br>
        Vui lòng liên hệ hỗ trợ ngay lập tức tại 
        <a href="mailto:${AppConstants.supportEmail}" style="color: #667eea;">${AppConstants.supportEmail}</a></p>
        
        <p>Trân trọng,<br>
        <strong>Đội ngũ ${AppConstants.appName}</strong></p>
      ''';

      final message = _createMessage(
        to: toEmail,
        subject: 'Mật khẩu mới cho tài khoản ${AppConstants.appName} 🔑',
        htmlBody: content,
      );

      await send(message, _smtpServer);
      return true;
    });
  }

  Future<Result<bool>> sendVerificationEmail(String toEmail, String verificationCode) async {
    return ResultHelper.safeCall(() async {
      final content = '''
        <h2>✨ Xác thực tài khoản</h2>
        <p>Để hoàn tất quá trình đăng ký tài khoản <strong>${AppConstants.appName}</strong>, 
        vui lòng xác thực địa chỉ email của bạn.</p>
        <p>Sử dụng mã xác thực bên dưới trong ứng dụng:</p>
        
        <div class="code">
          <p style="color: #667eea; font-size: 14px; margin-bottom: 10px; font-weight: 600;">
            MÃ XÁC THỰC
          </p>
          <h1>$verificationCode</h1>
          <p style="color: #666; font-size: 12px; margin-top: 10px;">
            Có hiệu lực trong 15 phút
          </p>
        </div>
        
        <div class="info-box">
          <h3 style="margin-top: 0;">📝 Hướng dẫn sử dụng</h3>
          <p style="margin: 8px 0;">
            <strong>Bước 1:</strong> Mở ứng dụng ${AppConstants.appName}<br>
            <strong>Bước 2:</strong> Nhập mã xác thực <code style="background: #f1f3f4; padding: 2px 6px; border-radius: 4px;">$verificationCode</code><br>
            <strong>Bước 3:</strong> Nhấn "Xác thực" để hoàn tất
          </p>
        </div>
        
        <div class="alert-warning">
          <p style="margin: 0;"><strong>⏰ Thông tin quan trọng:</strong><br>
          • Mã này sẽ hết hạn sau <strong>15 phút</strong><br>
          • Mỗi mã chỉ được sử dụng <strong>một lần</strong><br>
          • Không chia sẻ mã với bất kỳ ai<br>
          • Yêu cầu mã mới nếu mã hiện tại đã hết hạn</p>
        </div>
        
        <div class="alert-success">
          <p style="margin: 0;"><strong>🔐 Cam kết bảo mật:</strong><br>
          ${AppConstants.appName} sẽ không bao giờ yêu cầu mã xác thực qua điện thoại. 
          Chỉ nhập mã trong ứng dụng chính thức.</p>
        </div>
        
        <p><strong>Không nhận được mã?</strong><br>
        Kiểm tra thư mục spam hoặc yêu cầu gửi lại mã trong ứng dụng.</p>
      ''';

      final message = _createMessage(
        to: toEmail,
        subject: 'Mã xác thực tài khoản ${AppConstants.appName} ✨',
        htmlBody: content,
      );

      await send(message, _smtpServer);
      return true;
    });
  }

  Future<Result<bool>> sendCustomEmail(String toEmail, String subject, String body) async {
    return ResultHelper.safeCall(() async {
      final message = _createMessage(to: toEmail, subject: subject, htmlBody: body);
      await send(message, _smtpServer);
      return true;
    });
  }

  /// Test email configuration
  Future<Result<bool>> testEmailConfiguration() async {
    return ResultHelper.safeCall(() async {
      final testContent = '''
        <h2>🧪 Test Email Configuration</h2>
        <p>Email service đang hoạt động tốt với Gmail!</p>
        
        <div class="alert-success">
          <p style="margin: 0;">
            <strong>✅ Kết nối Gmail thành công!</strong><br>
            Cấu hình SMTP đã được thiết lập đúng.
          </p>
        </div>
        
        <div class="info-box">
          <h3 style="margin-top: 0;">📧 Thông tin cấu hình</h3>
          <p style="margin: 5px 0;">
            <strong>SMTP Host:</strong> ${AppConstants.smtpHost}<br>
            <strong>SMTP Port:</strong> ${AppConstants.smtpPort}<br>
            <strong>From Email:</strong> ${AppConstants.fromEmail}<br>
            <strong>Thời gian test:</strong> ${_getCurrentDateTime()}
          </p>
        </div>
      ''';

      final testMessage = _createMessage(
        to: AppConstants.fromEmail, // Send to self
        subject: '${AppConstants.appName} - Email Test Successful ✅',
        htmlBody: testContent,
      );

      await send(testMessage, _smtpServer);
      return true;
    });
  }

  String _getCurrentDate() {
    final now = DateTime.now();
    return '${now.day.toString().padLeft(2, '0')}/${now.month.toString().padLeft(2, '0')}/${now.year}';
  }

  String _getCurrentDateTime() {
    final now = DateTime.now();
    return '${now.day.toString().padLeft(2, '0')}/${now.month.toString().padLeft(2, '0')}/${now.year} ${now.hour.toString().padLeft(2, '0')}:${now.minute.toString().padLeft(2, '0')}';
  }
}

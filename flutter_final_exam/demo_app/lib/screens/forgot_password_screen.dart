import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../blocs/auth/auth_bloc.dart';
import '../blocs/auth/auth_event.dart';
import '../blocs/auth/auth_state.dart';
import '../utils/validation_utils.dart';
import '../widgets/custom_button.dart';
import '../widgets/custom_text_field.dart';
import 'login_screen.dart';

/// Forgot password screen with BLoC integration
class ForgotPasswordScreen extends StatefulWidget {
  const ForgotPasswordScreen({super.key});

  @override
  State<ForgotPasswordScreen> createState() => _ForgotPasswordScreenState();
}

class _ForgotPasswordScreenState extends State<ForgotPasswordScreen> with TickerProviderStateMixin {
  // Form and controllers
  final _formKey = GlobalKey<FormState>();
  final _emailController = TextEditingController();
  
  // Animation controllers
  late AnimationController _fadeController;
  late AnimationController _slideController;
  late Animation<double> _fadeAnimation;
  late Animation<Offset> _slideAnimation;

  @override
  void initState() {
    super.initState();
    _initializeAnimations();
  }

  @override
  void dispose() {
    _emailController.dispose();
    _fadeController.dispose();
    _slideController.dispose();
    super.dispose();
  }

  /// Initialize animations
  void _initializeAnimations() {
    _fadeController = AnimationController(
      duration: const Duration(milliseconds: 1000),
      vsync: this,
    );
    
    _slideController = AnimationController(
      duration: const Duration(milliseconds: 800),
      vsync: this,
    );

    _fadeAnimation = Tween<double>(
      begin: 0.0,
      end: 1.0,
    ).animate(CurvedAnimation(
      parent: _fadeController,
      curve: Curves.easeInOut,
    ));

    _slideAnimation = Tween<Offset>(
      begin: const Offset(0, 0.3),
      end: Offset.zero,
    ).animate(CurvedAnimation(
      parent: _slideController,
      curve: Curves.easeOutCubic,
    ));

    // Start animations
    _fadeController.forward();
    _slideController.forward();
  }

  /// Handle password reset request using BLoC
  void _handlePasswordReset() {
    if (!_formKey.currentState!.validate()) return;

    // Dispatch password reset event to BLoC
    context.read<AuthBloc>().add(
      PasswordResetRequested(
        email: _emailController.text.trim().toLowerCase(),
      ),
    );
  }

  /// Navigate to login screen
  void _navigateToLogin() {
    Navigator.pushReplacement(
      context,
      PageRouteBuilder(
        pageBuilder: (context, animation, secondaryAnimation) => 
            const LoginScreen(),
        transitionsBuilder: (context, animation, secondaryAnimation, child) {
          return FadeTransition(opacity: animation, child: child);
        },
        transitionDuration: const Duration(milliseconds: 300),
      ),
    );
  }

  /// Clear errors when user starts typing
  void _clearErrorsOnChange() {
    final currentState = context.read<AuthBloc>().state;
    if (currentState is AuthError) {
      context.read<AuthBloc>().add(const AuthErrorCleared());
    }
  }

  @override
  Widget build(BuildContext context) {
    return BlocListener<AuthBloc, AuthState>(
      listener: (context, state) {
        // Navigate to login after successful email sent
        if (state is AuthPasswordResetEmailSent) {
          // Small delay to show success message then navigate
          Future.delayed(const Duration(seconds: 3), () {
            if (mounted) {
              _navigateToLogin();
            }
          });
        }
        
        // Clear errors when user starts typing again
        if (state is AuthError) {
          // Auto clear error after 5 seconds
          Future.delayed(const Duration(seconds: 5), () {
            if (mounted && context.read<AuthBloc>().state is AuthError) {
              context.read<AuthBloc>().add(const AuthErrorCleared());
            }
          });
        }
      },
      child: Scaffold(
        body: Container(
          decoration: const BoxDecoration(
            gradient: LinearGradient(
              begin: Alignment.topCenter,
              end: Alignment.bottomCenter,
              colors: [
                Color(0xFF667eea),
                Color(0xFF764ba2),
              ],
            ),
          ),
          child: SafeArea(
            child: Column(
              children: [
                // Header section
                _buildHeader(),
                
                // Form section
                Expanded(
                  child: _buildFormSection(),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }

  /// Build header section
  Widget _buildHeader() {
    return FadeTransition(
      opacity: _fadeAnimation,
      child: Container(
        padding: const EdgeInsets.all(40),
        child: Column(
          children: [
            Container(
              width: 80,
              height: 80,
              decoration: const BoxDecoration(
                color: Colors.yellow,
                shape: BoxShape.circle,
              ),
              child: const Icon(
                Icons.lock_reset,
                size: 40,
                color: Colors.black,
              ),
            ),
            const SizedBox(height: 20),
            const Text(
            'Quên mật khẩu?',
            style: TextStyle(
            fontSize: 24,
            fontWeight: FontWeight.bold,
            color: Colors.white,
            ),
            ),
            const SizedBox(height: 8),
            const Text(
            'Chúng tôi sẽ tạo mật khẩu mới và gửi cho bạn',
            style: TextStyle(
            fontSize: 14,
            color: Colors.white70,
            ),
            textAlign: TextAlign.center,
            ),
          ],
        ),
      ),
    );
  }

  /// Build form section
  Widget _buildFormSection() {
    return SlideTransition(
      position: _slideAnimation,
      child: Container(
        decoration: const BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.only(
            topLeft: Radius.circular(30),
            topRight: Radius.circular(30),
          ),
        ),
        child: SingleChildScrollView(
          padding: const EdgeInsets.all(30),
          child: Form(
            key: _formKey,
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                const Text(
                'Hướng dẫn',
                style: TextStyle(
                fontSize: 18,
                fontWeight: FontWeight.bold,
                color: Color(0xFF333333),
                ),
                ),
                const SizedBox(height: 10),
                Container(
                padding: const EdgeInsets.all(15),
                decoration: BoxDecoration(
                color: const Color(0xFFF8F9FA),
                borderRadius: BorderRadius.circular(10),
                border: Border.all(color: const Color(0xFFE9ECEF)),
                ),
                child: const Text(
                'Nhập địa chỉ email đã đăng ký. Chúng tôi sẽ tạo mật khẩu mới và gửi qua email cho bạn. Bạn có thể đăng nhập bằng mật khẩu mới và thay đổi sau.',
                style: TextStyle(
                fontSize: 14,
                color: Color(0xFF666666),
                height: 1.4,
                ),
                ),
                ),
                const SizedBox(height: 30),

                // Email field
                CustomTextField(
                  controller: _emailController,
                  labelText: 'Địa chỉ email',
                  hintText: 'Nhập email đã đăng ký',
                  prefixIcon: Icons.email_outlined,
                  keyboardType: TextInputType.emailAddress,
                  validator: ValidationUtils.validateEmail,
                  textInputAction: TextInputAction.done,
                  onFieldSubmitted: (_) => _handlePasswordReset(),
                  onChanged: (_) => _clearErrorsOnChange(),
                ),
                const SizedBox(height: 30),

                // Send button with BLoC state
                BlocBuilder<AuthBloc, AuthState>(
                  buildWhen: (previous, current) {
                    return previous.isLoading != current.isLoading;
                  },
                  builder: (context, state) {
                    return CustomButton(
                      onPressed: state.isLoading ? null : _handlePasswordReset,
                      text: 'Tạo mật khẩu mới',
                      icon: Icons.refresh,
                      isLoading: state is AuthPasswordResetInProgress,
                      buttonType: ButtonType.primary,
                    );
                  },
                ),
                const SizedBox(height: 30),

                // Back to login button
                CustomButton(
                  onPressed: _navigateToLogin,
                  text: 'Quay lại đăng nhập',
                  icon: Icons.arrow_back,
                  buttonType: ButtonType.outlined,
                ),
                const SizedBox(height: 20),

                // Help text
                const Center(
                  child: Text(
                    'Vẫn gặp vấn đề? Liên hệ hỗ trợ',
                    style: TextStyle(
                      color: Colors.grey,
                      fontSize: 12,
                    ),
                  ),
                ),

                // Status messages
                _buildStatusMessages(),
              ],
            ),
          ),
        ),
      ),
    );
  }

  /// Build status messages (error and success)
  Widget _buildStatusMessages() {
    return Column(
      children: [
        // Error display
        BlocBuilder<AuthBloc, AuthState>(
          buildWhen: (previous, current) {
            return current is AuthError || previous is AuthError;
          },
          builder: (context, state) {
            if (state is AuthError) {
              return Container(
                margin: const EdgeInsets.only(top: 16),
                padding: const EdgeInsets.all(12),
                decoration: BoxDecoration(
                  color: Colors.red[50],
                  borderRadius: BorderRadius.circular(8),
                  border: Border.all(color: Colors.red[200]!),
                ),
                child: Row(
                  children: [
                    Icon(
                      Icons.error_outline,
                      color: Colors.red[700],
                      size: 20,
                    ),
                    const SizedBox(width: 8),
                    Expanded(
                      child: Text(
                        state.exception.message,
                        style: TextStyle(
                          color: Colors.red[700],
                          fontSize: 14,
                        ),
                      ),
                    ),
                    IconButton(
                      icon: Icon(
                        Icons.close,
                        color: Colors.red[700],
                        size: 18,
                      ),
                      onPressed: () {
                        context.read<AuthBloc>().add(const AuthErrorCleared());
                      },
                    ),
                  ],
                ),
              );
            }
            return const SizedBox.shrink();
          },
        ),

        // Success message display
        BlocBuilder<AuthBloc, AuthState>(
          buildWhen: (previous, current) {
            return current is AuthPasswordResetEmailSent ||
                   previous is AuthPasswordResetEmailSent;
          },
          builder: (context, state) {
            if (state is AuthPasswordResetEmailSent) {
              return Container(
                margin: const EdgeInsets.only(top: 16),
                padding: const EdgeInsets.all(12),
                decoration: BoxDecoration(
                  color: Colors.green[50],
                  borderRadius: BorderRadius.circular(8),
                  border: Border.all(color: Colors.green[200]!),
                ),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Row(
                      children: [
                        Icon(
                          Icons.check_circle_outline,
                          color: Colors.green[700],
                          size: 20,
                        ),
                        const SizedBox(width: 8),
                        Expanded(
                          child: Text(
                            'Email đã được gửi!',
                            style: TextStyle(
                              color: Colors.green[700],
                              fontSize: 14,
                              fontWeight: FontWeight.w600,
                            ),
                          ),
                        ),
                      ],
                    ),
                    const SizedBox(height: 4),
                    Padding(
                      padding: const EdgeInsets.only(left: 28),
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Text(
                            state.message,
                            style: TextStyle(
                              color: Colors.green[700],
                              fontSize: 12,
                            ),
                          ),
                          const SizedBox(height: 4),
                          Text(
                            'Kiểm tra email: ${state.email}',
                            style: TextStyle(
                              color: Colors.green[600],
                              fontSize: 11,
                              fontStyle: FontStyle.italic,
                            ),
                          ),
                          const SizedBox(height: 8),
                          Container(
                            padding: const EdgeInsets.symmetric(
                              horizontal: 8,
                              vertical: 4,
                            ),
                            decoration: BoxDecoration(
                              color: Colors.blue[50],
                              borderRadius: BorderRadius.circular(4),
                            ),
                            child: Text(
                              'Tự động chuyển về đăng nhập sau 3 giây...',
                              style: TextStyle(
                                color: Colors.blue[700],
                                fontSize: 10,
                              ),
                            ),
                          ),
                        ],
                      ),
                    ),
                  ],
                ),
              );
            }
            return const SizedBox.shrink();
          },
        ),
      ],
    );
  }
}

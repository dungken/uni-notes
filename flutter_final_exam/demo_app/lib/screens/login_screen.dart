import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../blocs/auth/auth_bloc.dart';
import '../blocs/auth/auth_event.dart';
import '../blocs/auth/auth_state.dart';
import '../utils/validation_utils.dart';
import '../widgets/custom_button.dart';
import '../widgets/custom_text_field.dart';
import 'register_screen.dart';
import 'forgot_password_screen.dart';

/// Login screen for user authentication with BLoC
class LoginScreen extends StatefulWidget {
  const LoginScreen({super.key});

  @override
  State<LoginScreen> createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> with TickerProviderStateMixin {
  // Form and controllers
  final _formKey = GlobalKey<FormState>();
  final _emailController = TextEditingController();
  final _passwordController = TextEditingController();
  
  // State variables
  bool _isPasswordVisible = false;
  bool _rememberMe = false;
  
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
    _passwordController.dispose();
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

  /// Handle login action using BLoC
  void _handleLogin() {
    if (!_formKey.currentState!.validate()) return;

    // Dispatch login event to BLoC
    context.read<AuthBloc>().add(
      LoginRequested(
        email: _emailController.text.trim(),
        password: _passwordController.text,
        rememberMe: _rememberMe,
      ),
    );
  }

  /// Navigate to register screen
  void _navigateToRegister() {
    Navigator.pushReplacement(
      context,
      PageRouteBuilder(
        pageBuilder: (context, animation, secondaryAnimation) => 
            const RegisterScreen(),
        transitionsBuilder: (context, animation, secondaryAnimation, child) {
          return FadeTransition(opacity: animation, child: child);
        },
        transitionDuration: const Duration(milliseconds: 300),
      ),
    );
  }

  /// Navigate to forgot password screen
  void _navigateToForgotPassword() {
    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (context) => const ForgotPasswordScreen(),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return BlocListener<AuthBloc, AuthState>(
      listener: (context, state) {
        // Clear form on successful registration redirect
        if (state is AuthRegistrationSuccess) {
          _emailController.text = state.email;
          _passwordController.clear();
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

  /// Build header section with logo and title
  Widget _buildHeader() {
    return FadeTransition(
      opacity: _fadeAnimation,
      child: Container(
        padding: const EdgeInsets.all(40),
        child: Column(
          children: [
            // Logo
            Container(
              width: 80,
              height: 80,
              decoration: const BoxDecoration(
                color: Colors.yellow,
                shape: BoxShape.circle,
              ),
              child: const Icon(
                Icons.person,
                size: 40,
                color: Colors.black,
              ),
            ),
            const SizedBox(height: 24),
            
            // Title
            const Text(
              'Chào mừng trở lại',
              style: TextStyle(
                fontSize: 24,
                fontWeight: FontWeight.bold,
                color: Colors.white,
              ),
            ),
            const SizedBox(height: 8),
            
            // Subtitle
            const Text(
              'Đăng nhập vào tài khoản của bạn',
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
              children: [
                const SizedBox(height: 20),
                
                // Email field
                CustomTextField(
                  controller: _emailController,
                  labelText: 'Email',
                  hintText: 'Nhập địa chỉ email',
                  prefixIcon: Icons.email_outlined,
                  keyboardType: TextInputType.emailAddress,
                  validator: ValidationUtils.validateEmail,
                  textInputAction: TextInputAction.next,
                  onChanged: (_) {
                    // Clear errors when user types
                    final currentState = context.read<AuthBloc>().state;
                    if (currentState is AuthError) {
                      context.read<AuthBloc>().add(const AuthErrorCleared());
                    }
                  },
                ),
                const SizedBox(height: 20),

                // Password field
                CustomTextField(
                  controller: _passwordController,
                  labelText: 'Mật khẩu',
                  hintText: 'Nhập mật khẩu',
                  prefixIcon: Icons.lock_outline,
                  obscureText: !_isPasswordVisible,
                  suffixIcon: _isPasswordVisible ? Icons.visibility : Icons.visibility_off,
                  onSuffixTap: () => setState(() => _isPasswordVisible = !_isPasswordVisible),
                  validator: ValidationUtils.validatePassword,
                  textInputAction: TextInputAction.done,
                  onFieldSubmitted: (_) => _handleLogin(),
                  onChanged: (_) {
                    // Clear errors when user types
                    final currentState = context.read<AuthBloc>().state;
                    if (currentState is AuthError) {
                      context.read<AuthBloc>().add(const AuthErrorCleared());
                    }
                  },
                ),
                const SizedBox(height: 16),

                // Remember me and forgot password row
                Row(
                  children: [
                    // Remember me checkbox
                    Checkbox(
                      value: _rememberMe,
                      onChanged: (value) => setState(() => _rememberMe = value ?? false),
                      activeColor: Theme.of(context).colorScheme.primary,
                    ),
                    const Text('Ghi nhớ đăng nhập'),
                    
                    const Spacer(),
                    
                    // Forgot password link
                    TextButton(
                      onPressed: _navigateToForgotPassword,
                      child: Text(
                        'Quên mật khẩu?',
                        style: TextStyle(
                          color: Theme.of(context).colorScheme.primary,
                          fontWeight: FontWeight.w500,
                        ),
                      ),
                    ),
                  ],
                ),
                const SizedBox(height: 30),

                // Login button with BLoC state
                BlocBuilder<AuthBloc, AuthState>(
                  buildWhen: (previous, current) {
                    // Only rebuild when loading state changes
                    return previous.isLoading != current.isLoading;
                  },
                  builder: (context, state) {
                    return CustomButton(
                      onPressed: state.isLoading ? null : _handleLogin,
                      text: 'Đăng nhập',
                      icon: Icons.login,
                      isLoading: state is AuthLoginInProgress,
                      buttonType: ButtonType.primary,
                    );
                  },
                ),
                const SizedBox(height: 30),

                // Divider
                const Row(
                  children: [
                    Expanded(child: Divider()),
                    Padding(
                      padding: EdgeInsets.symmetric(horizontal: 15),
                      child: Text(
                        'hoặc',
                        style: TextStyle(color: Colors.grey),
                      ),
                    ),
                    Expanded(child: Divider()),
                  ],
                ),
                const SizedBox(height: 30),

                // Register button
                CustomButton(
                  onPressed: _navigateToRegister,
                  text: 'Đăng ký ngay',
                  icon: Icons.person_add,
                  buttonType: ButtonType.outlined,
                ),
                const SizedBox(height: 20),

                // Footer text
                const Text(
                  'Chưa có tài khoản?',
                  style: TextStyle(
                    color: Colors.grey,
                    fontSize: 12,
                  ),
                ),

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
                    return current.successMessage != null || 
                           previous.successMessage != null;
                  },
                  builder: (context, state) {
                    final message = state.successMessage;
                    if (message != null) {
                      return Container(
                        margin: const EdgeInsets.only(top: 16),
                        padding: const EdgeInsets.all(12),
                        decoration: BoxDecoration(
                          color: Colors.green[50],
                          borderRadius: BorderRadius.circular(8),
                          border: Border.all(color: Colors.green[200]!),
                        ),
                        child: Row(
                          children: [
                            Icon(
                              Icons.check_circle_outline,
                              color: Colors.green[700],
                              size: 20,
                            ),
                            const SizedBox(width: 8),
                            Expanded(
                              child: Text(
                                message,
                                style: TextStyle(
                                  color: Colors.green[700],
                                  fontSize: 14,
                                ),
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
            ),
          ),
        ),
      ),
    );
  }
}

import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../blocs/auth/auth_bloc.dart';
import '../blocs/auth/auth_event.dart';
import '../blocs/auth/auth_state.dart';
import '../core/enums.dart';
import '../utils/validation_utils.dart';
import '../widgets/custom_button.dart';
import '../widgets/custom_text_field.dart';
import 'login_screen.dart';

/// Register screen with BLoC integration
class RegisterScreen extends StatefulWidget {
  const RegisterScreen({super.key});

  @override
  State<RegisterScreen> createState() => _RegisterScreenState();
}

class _RegisterScreenState extends State<RegisterScreen> with TickerProviderStateMixin {
  // Form and controllers
  final _formKey = GlobalKey<FormState>();
  final _nameController = TextEditingController();
  final _emailController = TextEditingController();
  final _phoneController = TextEditingController();
  final _birthDateController = TextEditingController();
  final _passwordController = TextEditingController();
  
  // State variables
  Gender? _selectedGender;
  bool _isPasswordVisible = false;
  bool _acceptTerms = false;
  
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
    _nameController.dispose();
    _emailController.dispose();
    _phoneController.dispose();
    _birthDateController.dispose();
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

  /// Handle birth date selection
  Future<void> _selectBirthDate() async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: DateTime(2000),
      firstDate: DateTime(1900),
      lastDate: DateTime.now(),
      builder: (context, child) {
        return Theme(
          data: Theme.of(context).copyWith(
            colorScheme: const ColorScheme.light(
              primary: Color(0xFF667eea),
              onPrimary: Colors.white,
              onSurface: Colors.black,
            ),
          ),
          child: child!,
        );
      },
    );

    if (picked != null) {
      setState(() {
        _birthDateController.text = ValidationUtils.formatDateForDisplay(
          "${picked.year}-${picked.month.toString().padLeft(2, '0')}-${picked.day.toString().padLeft(2, '0')}"
        );
      });
    }
  }

  /// Handle registration using BLoC
  void _handleRegister() {
    if (!_formKey.currentState!.validate()) return;
    
    if (_selectedGender == null) {
      _showErrorSnackBar('Vui lòng chọn giới tính');
      return;
    }
    
    if (!_acceptTerms) {
      _showErrorSnackBar('Vui lòng đồng ý với điều khoản sử dụng');
      return;
    }

    // Convert birth date to storage format
    final birthDate = ValidationUtils.formatDateForStorage(_birthDateController.text);

    // Dispatch register event to BLoC
    context.read<AuthBloc>().add(
      RegisterRequested(
        name: _nameController.text.trim(),
        email: _emailController.text.trim().toLowerCase(),
        phone: _phoneController.text.trim(),
        birthDate: birthDate,
        gender: _selectedGender!,
        password: _passwordController.text,
      ),
    );
  }

  /// Show error snackbar
  void _showErrorSnackBar(String message) {
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(
        content: Row(
          children: [
            const Icon(Icons.error_outline, color: Colors.white),
            const SizedBox(width: 12),
            Expanded(child: Text(message)),
          ],
        ),
        backgroundColor: Colors.red[600],
        behavior: SnackBarBehavior.floating,
        shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(8)),
        duration: const Duration(seconds: 4),
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
        // Navigate to login on successful registration
        if (state is AuthRegistrationSuccess) {
          // Small delay to show success message then navigate
          Future.delayed(const Duration(seconds: 2), () {
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
                Icons.person_add,
                size: 40,
                color: Colors.black,
              ),
            ),
            const SizedBox(height: 20),
            const Text(
              'Tạo tài khoản mới',
              style: TextStyle(
                fontSize: 24,
                fontWeight: FontWeight.bold,
                color: Colors.white,
              ),
            ),
            const SizedBox(height: 8),
            const Text(
              'Đăng ký để sử dụng ứng dụng hoàn toàn miễn phí',
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
                // Name field
                CustomTextField(
                  controller: _nameController,
                  labelText: 'Họ và tên',
                  hintText: 'Nhập họ và tên đầy đủ',
                  prefixIcon: Icons.person_outline,
                  validator: ValidationUtils.validateName,
                  textInputAction: TextInputAction.next,
                  textCapitalization: TextCapitalization.words,
                  inputFormatters: [
                    FilteringTextInputFormatter.allow(RegExp(r'[a-zA-ZÀ-ỹ\s]')),
                  ],
                  onChanged: (_) => _clearErrorsOnChange(),
                ),
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
                  onChanged: (_) => _clearErrorsOnChange(),
                ),
                const SizedBox(height: 20),

                // Phone field
                CustomTextField(
                  controller: _phoneController,
                  labelText: 'Số điện thoại',
                  hintText: 'Nhập số điện thoại',
                  prefixIcon: Icons.phone_outlined,
                  keyboardType: TextInputType.phone,
                  validator: ValidationUtils.validatePhone,
                  textInputAction: TextInputAction.next,
                  inputFormatters: [
                    FilteringTextInputFormatter.digitsOnly,
                    LengthLimitingTextInputFormatter(11),
                  ],
                  onChanged: (_) => _clearErrorsOnChange(),
                ),
                const SizedBox(height: 20),

                // Birth date field
                CustomTextField(
                  controller: _birthDateController,
                  labelText: 'Ngày sinh',
                  hintText: 'Chọn ngày sinh',
                  prefixIcon: Icons.calendar_today_outlined,
                  suffixIcon: Icons.arrow_drop_down,
                  readOnly: true,
                  onTap: _selectBirthDate,
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Vui lòng chọn ngày sinh';
                    }
                    return ValidationUtils.validateBirthDate(
                      ValidationUtils.formatDateForStorage(value)
                    );
                  },
                ),
                const SizedBox(height: 20),

                // Gender dropdown
                DropdownButtonFormField<Gender>(
                  value: _selectedGender,
                  decoration: InputDecoration(
                    labelText: 'Giới tính',
                    prefixIcon: const Icon(Icons.wc_outlined),
                    border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(12),
                    ),
                    focusedBorder: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(12),
                      borderSide: const BorderSide(color: Color(0xFF667eea)),
                    ),
                  ),
                  items: Gender.values.map((gender) => DropdownMenuItem(
                    value: gender,
                    child: Text(gender.displayName),
                  )).toList(),
                  onChanged: (value) {
                    setState(() {
                      _selectedGender = value;
                    });
                    _clearErrorsOnChange();
                  },
                  validator: (value) => ValidationUtils.validateGender(value),
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
                  onChanged: (_) => _clearErrorsOnChange(),
                ),
                const SizedBox(height: 20),

                // Terms checkbox
                Row(
                  children: [
                    Checkbox(
                      value: _acceptTerms,
                      onChanged: (value) {
                        setState(() {
                          _acceptTerms = value ?? false;
                        });
                      },
                      activeColor: const Color(0xFF667eea),
                    ),
                    const Expanded(
                      child: Text(
                        'Tôi đồng ý với điều khoản sử dụng và chính sách bảo mật',
                        style: TextStyle(fontSize: 12),
                      ),
                    ),
                  ],
                ),
                const SizedBox(height: 30),

                // Register button with BLoC state
                BlocBuilder<AuthBloc, AuthState>(
                  buildWhen: (previous, current) {
                    return previous.isLoading != current.isLoading;
                  },
                  builder: (context, state) {
                    return CustomButton(
                      onPressed: state.isLoading ? null : _handleRegister,
                      text: 'Đăng ký tài khoản',
                      icon: Icons.person_add,
                      isLoading: state is AuthRegistrationInProgress,
                      buttonType: ButtonType.primary,
                    );
                  },
                ),
                const SizedBox(height: 20),

                // Login link
                const Text('hoặc', style: TextStyle(color: Colors.grey)),
                const SizedBox(height: 20),
                
                TextButton(
                  onPressed: _navigateToLogin,
                  child: const Text(
                    'Đã có tài khoản? Đăng nhập ngay',
                    style: TextStyle(
                      color: Color(0xFF667eea),
                      fontWeight: FontWeight.w500,
                    ),
                  ),
                ),

                // Error and success messages
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
            return current is AuthRegistrationSuccess ||
                   previous is AuthRegistrationSuccess;
          },
          builder: (context, state) {
            if (state is AuthRegistrationSuccess) {
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
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Text(
                            'Đăng ký thành công!',
                            style: TextStyle(
                              color: Colors.green[700],
                              fontSize: 14,
                              fontWeight: FontWeight.w600,
                            ),
                          ),
                          Text(
                            state.message,
                            style: TextStyle(
                              color: Colors.green[700],
                              fontSize: 12,
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

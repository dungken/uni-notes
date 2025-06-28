import 'package:flutter/material.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'services/database_service.dart';
import 'services/email_service.dart';
import 'blocs/auth/auth_bloc.dart';
import 'blocs/auth/auth_event.dart';
import 'blocs/auth/auth_state.dart';
import 'screens/login_screen.dart';
import 'screens/home_screen.dart';
import 'widgets/loading_overlay.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await DatabaseService.initialize();
  
  if (kDebugMode) {
    Bloc.observer = AppBlocObserver();
  }
  
  runApp(const MyApp());
}

class AppBlocObserver extends BlocObserver {
  @override
  void onEvent(BlocBase bloc, Object? event) {
    if (bloc is Bloc && kDebugMode) {
      super.onEvent(bloc, event);
      print('${bloc.runtimeType}: $event');
    }
  }

  @override
  void onError(BlocBase bloc, Object error, StackTrace stackTrace) {
    super.onError(bloc, error, stackTrace);
    if (kDebugMode) print('${bloc.runtimeType}: $error');
  }
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MultiRepositoryProvider(
      providers: [
        RepositoryProvider<DatabaseService>(create: (_) => DatabaseService()),
        RepositoryProvider<EmailService>(create: (_) => EmailService()),
      ],
      child: BlocProvider(
        create: (context) => AuthBloc(
          databaseService: context.read<DatabaseService>(),
          emailService: context.read<EmailService>(),
        )..add(const AuthStatusRequested()),
        child: MaterialApp(
          title: 'Demo App',
          debugShowCheckedModeBanner: false,
          theme: _buildTheme(),
          home: const AppNavigator(),
        ),
      ),
    );
  }

  ThemeData _buildTheme() {
    const primaryColor = Color(0xFF667eea);
    return ThemeData(
      useMaterial3: true,
      colorScheme: ColorScheme.fromSeed(
        seedColor: primaryColor,
        primary: primaryColor,
        secondary: const Color(0xFF764ba2),
      ),
      appBarTheme: const AppBarTheme(
        centerTitle: true,
        elevation: 0,
        backgroundColor: primaryColor,
        foregroundColor: Colors.white,
      ),
      elevatedButtonTheme: ElevatedButtonThemeData(
        style: ElevatedButton.styleFrom(
          elevation: 2,
          shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(25)),
          padding: const EdgeInsets.symmetric(horizontal: 24, vertical: 12),
        ),
      ),
      inputDecorationTheme: InputDecorationTheme(
        filled: true,
        fillColor: Colors.grey[50],
        border: OutlineInputBorder(borderRadius: BorderRadius.circular(12)),
        focusedBorder: OutlineInputBorder(
          borderRadius: BorderRadius.circular(12),
          borderSide: const BorderSide(color: primaryColor, width: 2),
        ),
        contentPadding: const EdgeInsets.symmetric(horizontal: 16, vertical: 12),
      ),
    );
  }
}

class AppNavigator extends StatelessWidget {
  const AppNavigator({super.key});

  @override
  Widget build(BuildContext context) {
    return BlocConsumer<AuthBloc, AuthState>(
      listener: (context, state) {
        if (state is AuthError) {
          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              content: Text(state.exception.message),
              backgroundColor: Colors.red[600],
              behavior: SnackBarBehavior.floating,
            ),
          );
        }
        
        if (state.successMessage != null) {
          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              content: Text(state.successMessage!),
              backgroundColor: Colors.green[600],
              behavior: SnackBarBehavior.floating,
            ),
          );
        }
      },
      builder: (context, state) {
        return switch (state) {
          AuthInitial() || AuthLoading() => const LoadingScreen(),
          AuthAuthenticated(user: final user) => HomeScreen(user: user),
          _ when state.isLoading => LoadingOverlay(
              isLoading: true,
              loadingText: _getLoadingMessage(state),
              child: const LoginScreen(),
            ),
          _ => const LoginScreen(),
        };
      },
    );
  }

  String _getLoadingMessage(AuthState state) {
    return switch (state) {
      AuthLoginInProgress() => 'Đang đăng nhập...',
      AuthRegistrationInProgress() => 'Đang tạo tài khoản...',
      AuthPasswordResetInProgress() => 'Đang xử lý...',
      _ => 'Đang xử lý...',
    };
  }
}

class LoadingScreen extends StatelessWidget {
  const LoadingScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        decoration: const BoxDecoration(
          gradient: LinearGradient(
            colors: [Color(0xFF667eea), Color(0xFF764ba2)],
          ),
        ),
        child: const Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              CircleAvatar(
                radius: 40,
                backgroundColor: Colors.yellow,
                child: Icon(Icons.star, size: 40, color: Colors.black),
              ),
              SizedBox(height: 32),
              CircularProgressIndicator(color: Colors.white),
              SizedBox(height: 16),
              Text(
                'Demo App',
                style: TextStyle(
                  fontSize: 24,
                  fontWeight: FontWeight.bold,
                  color: Colors.white,
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}

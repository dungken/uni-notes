import 'dart:async';
import 'dart:io';
import 'dart:math';
import 'package:sqflite/sqflite.dart';
import 'package:sqflite_common_ffi/sqflite_ffi.dart';
import 'package:path/path.dart';
import 'package:crypto/crypto.dart';
import 'dart:convert';
import 'package:flutter/foundation.dart';

import '../core/constants.dart';
import '../core/exceptions.dart' as app_exceptions;
import '../core/result.dart';
import '../models/user.dart';

/// Repository interface for user operations
abstract class IUserRepository {
  Future<Result<User>> createUser(User user);
  Future<Result<User?>> authenticateUser(String email, String password);
  Future<Result<User?>> getUserByEmail(String email);
  Future<Result<User?>> getUserById(int id);
  Future<Result<bool>> updateUser(User user);
  Future<Result<bool>> deleteUser(int id);
  Future<Result<bool>> updateLastLogin(int userId);
  Future<Result<List<User>>> getAllUsers();
  Future<Result<String>> generateNewPassword(String email);
}

/// SQLite implementation of user repository
class DatabaseService implements IUserRepository {
  static DatabaseService? _instance;
  static Database? _database;
  
  // Singleton pattern
  DatabaseService._internal();
  
  factory DatabaseService() {
    _instance ??= DatabaseService._internal();
    return _instance!;
  }

  /// Initialize database connection
  static Future<void> initialize() async {
    if (!kIsWeb && (Platform.isWindows || Platform.isLinux || Platform.isMacOS)) {
      sqfliteFfiInit();
      databaseFactory = databaseFactoryFfi;
    }
  }

  /// Get database instance
  Future<Database> get database async {
    _database ??= await _initDatabase();
    return _database!;
  }

  /// Initialize the database
  Future<Database> _initDatabase() async {
    try {
      final dbPath = await getDatabasesPath();
      final path = join(dbPath, AppConstants.databaseName);

      return await openDatabase(
        path,
        version: AppConstants.databaseVersion,
        onCreate: _onCreate,
        onUpgrade: _onUpgrade,
        onOpen: _onOpen,
      );
    } catch (e) {
      throw app_exceptions.DatabaseException(
        'Không thể khởi tạo database',
        originalError: e,
      );
    }
  }

  /// Create database tables
  Future<void> _onCreate(Database db, int version) async {
    await db.execute('''
      CREATE TABLE ${AppConstants.usersTable} (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        name TEXT NOT NULL,
        email TEXT UNIQUE NOT NULL,
        phone TEXT NOT NULL,
        birth_date TEXT NOT NULL,
        gender TEXT NOT NULL,
        password TEXT NOT NULL,
        reset_token TEXT,
        reset_token_expiry INTEGER,
        created_at INTEGER NOT NULL,
        last_login_at INTEGER,
        is_email_verified INTEGER DEFAULT 0,
        is_active INTEGER DEFAULT 1
      )
    ''');

    // Create indexes for better performance
    await db.execute('''
      CREATE INDEX idx_users_email ON ${AppConstants.usersTable}(email)
    ''');
    
    await db.execute('''
      CREATE INDEX idx_users_reset_token ON ${AppConstants.usersTable}(reset_token)
    ''');
  }

  /// Handle database upgrades
  Future<void> _onUpgrade(Database db, int oldVersion, int newVersion) async {
    // Handle schema migrations here
    if (oldVersion < 2) {
      // Example migration
      // await db.execute('ALTER TABLE users ADD COLUMN new_field TEXT');
    }
  }

  /// Configure database when opened
  Future<void> _onOpen(Database db) async {
    // Enable foreign keys
    await db.execute('PRAGMA foreign_keys = ON');
  }

  /// Hash password securely
  String _hashPassword(String password) {
    final bytes = utf8.encode(password);
    final digest = sha256.convert(bytes);
    return digest.toString();
  }

  /// Generate secure random token
  String _generateToken() {
    final timestamp = DateTime.now().millisecondsSinceEpoch;
    final random = DateTime.now().microsecondsSinceEpoch;
    final combined = '$timestamp$random';
    final bytes = utf8.encode(combined);
    final digest = sha256.convert(bytes);
    return digest.toString().substring(0, 32);
  }

  @override
  Future<Result<User>> createUser(User user) async {
    return ResultHelper.safeCall(() async {
      final db = await database;
      
      // Check if email already exists
      final existingUser = await getUserByEmail(user.email);
      if (existingUser.isSuccess && existingUser.dataOrNull != null) {
        throw const app_exceptions.DuplicateEmailException();
      }

      // Hash password
      final hashedPassword = _hashPassword(user.password);
      final userWithHashedPassword = user.copyWith(
        password: hashedPassword,
        createdAt: DateTime.now(),
      );

      final id = await db.insert(
        AppConstants.usersTable,
        userWithHashedPassword.toMap(),
        conflictAlgorithm: ConflictAlgorithm.abort,
      );

      return userWithHashedPassword.copyWith(id: id);
    });
  }

  @override
  Future<Result<User?>> authenticateUser(String email, String password) async {
    return ResultHelper.safeCall(() async {
      final db = await database;
      final hashedPassword = _hashPassword(password);

      final result = await db.query(
        AppConstants.usersTable,
        where: 'email = ? AND password = ? AND is_active = 1',
        whereArgs: [email.toLowerCase().trim(), hashedPassword],
        limit: 1,
      );

      if (result.isEmpty) {
        throw const app_exceptions.InvalidCredentialsException();
      }

      final user = User.fromMap(result.first);
      
      // Update last login
      await updateLastLogin(user.id!);
      
      return user.copyWith(lastLoginAt: DateTime.now());
    });
  }

  @override
  Future<Result<User?>> getUserByEmail(String email) async {
    return ResultHelper.safeCall(() async {
      final db = await database;

      final result = await db.query(
        AppConstants.usersTable,
        where: 'email = ?',
        whereArgs: [email.toLowerCase().trim()],
        limit: 1,
      );

      if (result.isEmpty) {
        return null;
      }

      return User.fromMap(result.first);
    });
  }

  @override
  Future<Result<User?>> getUserById(int id) async {
    return ResultHelper.safeCall(() async {
      final db = await database;

      final result = await db.query(
        AppConstants.usersTable,
        where: 'id = ?',
        whereArgs: [id],
        limit: 1,
      );

      if (result.isEmpty) {
        return null;
      }

      return User.fromMap(result.first);
    });
  }

  @override
  Future<Result<bool>> updateUser(User user) async {
    return ResultHelper.safeCall(() async {
      final db = await database;

      final rowsAffected = await db.update(
        AppConstants.usersTable,
        user.toMap(),
        where: 'id = ?',
        whereArgs: [user.id],
      );

      return rowsAffected > 0;
    });
  }

  @override
  Future<Result<bool>> deleteUser(int id) async {
    return ResultHelper.safeCall(() async {
      final db = await database;

      final rowsAffected = await db.delete(
        AppConstants.usersTable,
        where: 'id = ?',
        whereArgs: [id],
      );

      return rowsAffected > 0;
    });
  }



  @override
  Future<Result<bool>> updateLastLogin(int userId) async {
    return ResultHelper.safeCall(() async {
      final db = await database;

      final rowsAffected = await db.update(
        AppConstants.usersTable,
        {'last_login_at': DateTime.now().millisecondsSinceEpoch},
        where: 'id = ?',
        whereArgs: [userId],
      );

      return rowsAffected > 0;
    });
  }

  @override
  Future<Result<List<User>>> getAllUsers() async {
    return ResultHelper.safeCall(() async {
      final db = await database;

      final result = await db.query(
        AppConstants.usersTable,
        orderBy: 'created_at DESC',
      );

      return result.map((row) => User.fromMap(row)).toList();
    });
  }

  /// Generate new password and update user
  Future<Result<String>> generateNewPassword(String email) async {
    return ResultHelper.safeCall(() async {
      // Check if user exists
      final userResult = await getUserByEmail(email);
      if (userResult.isFailure || userResult.dataOrNull == null) {
        throw const app_exceptions.UserNotFoundException();
      }

      // Generate new password (8 characters: letters + numbers)
      final newPassword = _generateRandomPassword();
      final hashedPassword = _hashPassword(newPassword);

      final db = await database;
      final rowsAffected = await db.update(
        AppConstants.usersTable,
        {
          'password': hashedPassword,
          'reset_token': null,
          'reset_token_expiry': null,
        },
        where: 'email = ?',
        whereArgs: [email.toLowerCase().trim()],
      );

      if (rowsAffected > 0) {
        return newPassword; // Return plain password to send via email
      } else {
        throw const app_exceptions.DatabaseException('Không thể cập nhật mật khẩu');
      }
    });
  }

  /// Generate random password
  String _generateRandomPassword() {
    const chars = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
    final random = Random();
    return String.fromCharCodes(
      Iterable.generate(8, (_) => chars.codeUnitAt(random.nextInt(chars.length)))
    );
  }

  /// Generate a secure reset token
  String generateResetToken() {
    return _generateToken();
  }

  /// Close database connection
  Future<void> close() async {
    final db = _database;
    if (db != null) {
      await db.close();
      _database = null;
    }
  }
}

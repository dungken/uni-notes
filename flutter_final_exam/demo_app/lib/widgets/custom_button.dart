import 'package:flutter/material.dart';

enum ButtonType { primary, secondary, outlined, text }

class CustomButton extends StatelessWidget {
  final VoidCallback? onPressed;
  final String text;
  final IconData? icon;
  final bool isLoading;
  final ButtonType buttonType;
  final double? width;
  final double height;
  final double fontSize;

  const CustomButton({
    super.key,
    required this.onPressed,
    required this.text,
    this.icon,
    this.isLoading = false,
    this.buttonType = ButtonType.primary,
    this.width,
    this.height = 50.0,
    this.fontSize = 16.0,
  });

  @override
  Widget build(BuildContext context) {
    final isEnabled = onPressed != null && !isLoading;
    
    Widget buttonChild = isLoading
        ? SizedBox(
            width: 20,
            height: 20,
            child: CircularProgressIndicator(
              strokeWidth: 2,
              valueColor: AlwaysStoppedAnimation<Color>(
                buttonType == ButtonType.primary ? Colors.white : Theme.of(context).colorScheme.primary,
              ),
            ),
          )
        : icon != null
            ? Row(
                mainAxisAlignment: MainAxisAlignment.center,
                mainAxisSize: MainAxisSize.min,
                children: [
                  Icon(icon, size: fontSize + 2),
                  const SizedBox(width: 8),
                  Text(text, style: TextStyle(fontSize: fontSize, fontWeight: FontWeight.w600)),
                ],
              )
            : Text(text, style: TextStyle(fontSize: fontSize, fontWeight: FontWeight.w600));

    return SizedBox(
      width: width ?? double.infinity,
      height: height,
      child: switch (buttonType) {
        ButtonType.primary => ElevatedButton(
            onPressed: isEnabled ? onPressed : null,
            style: ElevatedButton.styleFrom(
              backgroundColor: const Color(0xFFFF6B35),
              foregroundColor: Colors.white,
              disabledBackgroundColor: Colors.grey[300],
              elevation: isEnabled ? 2 : 0,
              shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(25)),
            ),
            child: buttonChild,
          ),
        ButtonType.outlined => OutlinedButton(
            onPressed: isEnabled ? onPressed : null,
            style: OutlinedButton.styleFrom(
              foregroundColor: const Color(0xFF667eea),
              side: BorderSide(
                color: isEnabled ? const Color(0xFF667eea) : Colors.grey[400]!,
                width: 1.5,
              ),
              shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(25)),
            ),
            child: buttonChild,
          ),
        ButtonType.text => TextButton(
            onPressed: isEnabled ? onPressed : null,
            style: TextButton.styleFrom(
              foregroundColor: Theme.of(context).colorScheme.primary,
              shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(8)),
            ),
            child: buttonChild,
          ),
        ButtonType.secondary => ElevatedButton(
            onPressed: isEnabled ? onPressed : null,
            style: ElevatedButton.styleFrom(
              backgroundColor: Theme.of(context).colorScheme.secondary,
              foregroundColor: Colors.white,
              elevation: isEnabled ? 2 : 0,
              shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(25)),
            ),
            child: buttonChild,
          ),
      },
    );
  }
}

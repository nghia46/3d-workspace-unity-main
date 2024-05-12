using UnityEngine;

namespace Tools
{
    public abstract class CustomTools
    {
        public enum LogColor
        {
            Red,
            Blue,
            Yellow,
            White
        }

        public static void Log<T>(T logMessage, LogColor? color = null)
        {
            var colorCode = color?.ToString().ToLower() ?? LogColor.White.ToString().ToLower();
            Debug.Log(string.IsNullOrWhiteSpace(logMessage.ToString())
                ? $"<color=red>You log is empty</color>"
                : $"<color={colorCode}>{logMessage}</color>");
        }
    }
}
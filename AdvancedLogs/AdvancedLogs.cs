using System;

namespace EasyLog.AdvancedLogs
{
    public static class RequestAdvancedLogs
    {
        private static string GetTimestamp() => DateTime.Now.ToString("HH:mm:ss");

        // Info Log
        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{GetTimestamp()}] [ℹ INFO] {message}");
            Console.ResetColor();
        }

        // Debug Log
        public static void Debug(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[{GetTimestamp()}] [🐞 DEBUG] {message}");
            Console.ResetColor();
        }

        // Warning Log
        public static void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[{GetTimestamp()}] [⚠ WARNING] {message}");
            Console.ResetColor();
        }

        // Error Log
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{GetTimestamp()}] [❌ ERROR] {message}");
            Console.ResetColor();
        }

        // Variable Loaded Info
        public static void VariableLoadedInfo<T>(T variableValue, string variableName)
        {
            string safeName = string.IsNullOrWhiteSpace(variableName) ? "UnknownVariable" : variableName;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{GetTimestamp()}] [✔ VARIABLE] {safeName} loaded with value: {variableValue}");
            Console.ResetColor();
        }

        // Variable Loaded Error
        public static void VariableLoadedError<T>(T variableValue, string variableName)
        {
            string safeName = string.IsNullOrWhiteSpace(variableName) ? "UnknownVariable" : variableName;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{GetTimestamp()}] [❌ VARIABLE] {safeName} failed to load! Value: {variableValue}");
            Console.ResetColor();
        }

        // Timer log: mede tempo de execução de um Action
        public static void Time(string taskName, Action action)
        {
            var start = DateTime.Now;
            try
            {
                action.Invoke();
                var duration = DateTime.Now - start;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"[{GetTimestamp()}] [⏱ TIME] Task '{taskName}' completed in {duration.TotalMilliseconds} ms");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{GetTimestamp()}] [❌ TIME] Task '{taskName}' failed: {ex.Message}");
            }
            finally
            {
                Console.ResetColor();
            }
        }

        // Generic log with custom emoji and color
        public static void CustomLog(string message, ConsoleColor color, string emoji = "💬")
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"[{GetTimestamp()}] [{emoji}] {message}");
            Console.ResetColor();
        }
    }
}

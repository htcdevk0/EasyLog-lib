using System;

namespace EasyLog.BasicLogs
{
    public static class RequestLogs
    {
        public static void ProjectLoadedInfo()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"[{Environment.UserName}] <Program> Program Loaded");
            Console.ResetColor();
        }

        public static void VariableLoadedInfo<T>(T variableValue, string variableName)
        {
            string safeName = string.IsNullOrWhiteSpace(variableName) ? "UnknownVariable" : variableName;

            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[{safeName}] <Program> Variable Loaded without errors");
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{safeName}] <Program> Variable Loaded with errors, please check your code!");
            }
            finally
            {
                Console.ResetColor();
            }
        }

        public static void VariableLoadedError<T>(T variableValue, string variableName)
        {
            string safeName = string.IsNullOrWhiteSpace(variableName) ? "UnknownVariable" : variableName;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{safeName}] <Program> Variable Loaded with errors");
            Console.ResetColor();
        }

        public static void WarnLog(string message = "Warning Log")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARN] {message}");
            Console.ResetColor();
        }
    }
}
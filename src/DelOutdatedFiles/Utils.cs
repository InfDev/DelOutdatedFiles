using DelOutdatedFiles.Config;

namespace DelOutdatedFiles
{
    internal static class Utils
    {
        public static void ConsoleWriteLine(ConsoleColor foregroundColor, string message, params object[]? args)
        {
            var msg = $"{DateTime.Now.ToString("HH:mm:ss.fff")} {message}";
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(msg, args);
            Console.ResetColor();
        }
    }
}

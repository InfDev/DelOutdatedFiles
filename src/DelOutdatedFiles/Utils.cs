using DelOutdatedFiles.Config;

namespace DelOutdatedFiles
{
    internal static class Utils
    {
        public static void ConsoleWriteLine(ConsoleColor foregroundColor, string message, params object[]? args)
        {
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(message, args);
            Console.ResetColor();
        }
    }
}

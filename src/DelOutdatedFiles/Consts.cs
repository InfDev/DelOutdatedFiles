namespace DelOutdatedFiles
{
    internal static class Consts
    {
        public static readonly ConsoleColor ConsoleDefBackgroundColorColor = Console.BackgroundColor;
        public static readonly ConsoleColor ConsoleDefForegroundColor = Console.ForegroundColor;
        public static readonly ConsoleColor InfoColor = ConsoleDefForegroundColor;
        public const ConsoleColor WarningColor = ConsoleColor.Yellow;
        public const ConsoleColor ErrorColor = ConsoleColor.Red;

        public const string NormalConfigFileName = ".DelOutdatedFiles";
        public const int MinimumAllowedKeepDays = 1;
        public const int MinimumAllowedKeepCount = 1;
        public const int DefaultKeepDays = 40;
        public const int DefaultKeepCount = 40;

    }
}

using System.CommandLine;
using DelOutdatedFiles.Handlers;

namespace DelOutdatedFiles.Commands
{
    internal static partial class Commands
    {

        public static Command ClearningCommand()
        {
            var command = new Command("cleaning", Strings.HelpDescription_Command_Cleaning)
                {
                    CleaningDirectoryPathOption //, KeepDaysOption, KeepCountOption, TimestampLengthOption
                };

            command.SetHandler(async context =>
            {
                context.ExitCode = await CleaningCommandHandler.Invoke(
                    context.ParseResult.GetValueForOption<string?>(CleaningDirectoryPathOption));
        });

            return command;
        }

        private static Option<string?> CleaningDirectoryPathOption =
            new Option<string?>(
                aliases: new[] { "-d", "--directory" },
                getDefaultValue: () => Directory.GetCurrentDirectory(),
                description: Strings.HelpDescription_Option_CleaningDirectoryPath
            )
            {
                ArgumentHelpName = "directory"
            };

        //private static Option<int> KeepDaysOption =
        //    new Option<int>(
        //        aliases: new[] { "-kd", "--keep-days" },
        //        getDefaultValue: () => 40,
        //        description: Strings.HelpDescription_Option_KeepDays
        //    )
        //    {
        //        ArgumentHelpName = "keep-days"
        //    };

        //private static Option<int> KeepCountOption =
        //    new Option<int>(
        //        aliases: new[] { "-kc", "--keep-count" },
        //        getDefaultValue: () => 40,
        //        description: Strings.HelpDescription_Option_KeepCount
        //    )
        //    {
        //        ArgumentHelpName = "keep-count"
        //    };

        //private static Option<int> TimestampLengthOption =
        //    new Option<int>(
        //        aliases: new[] { "-tl", "--timestamp-length" },
        //        getDefaultValue: () => 13,
        //        description: Strings.HelpDescription_Option_TimestampLength
        //    )
        //    {
        //        ArgumentHelpName = "timestamp-length"
        //    };
    }


}

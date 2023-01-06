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
                    context.ParseResult.GetValueForOption<string[]?>(CleaningDirectoryPathOption));
        });

            return command;
        }

        private static Option<string[]?> CleaningDirectoryPathOption =
            new Option<string[]?>(
                aliases: new[] { "-d", "--directory" },
                //getDefaultValue: () => Directory.GetCurrentDirectory(),
                description: Strings.HelpDescription_Option_CleaningDirectoryPath
            )
            {
                ArgumentHelpName = "directory",
                Arity = ArgumentArity.OneOrMore
            };

    }
}

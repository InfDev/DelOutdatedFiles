using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using System.Globalization;
using DelOutdatedFiles.Commands;

// https://learn.microsoft.com/en-us/dotnet/standard/commandline/get-started-tutorial

var lang = Environment.GetEnvironmentVariable("DOTNET_CLI_UI_LANGUAGE");
if (lang != null)
    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);

var parser = new CommandLineBuilder(new RootCommand("Deleting outdated files")
{
    Commands.InitCommand(),
    Commands.ClearningCommand()
})
.UseDefaults()
.Build();

await parser.InvokeAsync(args);

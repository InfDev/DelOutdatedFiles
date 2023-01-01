using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using DelOutdatedFiles.Commands;

// https://learn.microsoft.com/en-us/dotnet/standard/commandline/get-started-tutorial

var parser = new CommandLineBuilder(new RootCommand("Deleting outdated files")
{
    Commands.InitCommand()
})
.UseDefaults()
.Build();

await parser.InvokeAsync(args);

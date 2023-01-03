using DelOutdatedFiles.Config;
using System.Collections.Specialized;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DelOutdatedFiles.Handlers;

internal sealed class CleaningCommandHandler
{
    public static async Task<int> Invoke(string? directory)
    {
        var oldColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        if (directory != null && !Directory.Exists(directory))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Strings.InvalidDirectory, directory);
            Console.ForegroundColor = oldColor;
            return 2;
        }
        var dir = directory == null ? Directory.GetCurrentDirectory() : directory;
        var filePath = Path.Combine(dir, Consts.NormalConfigFileName);
        if (!File.Exists(filePath))
        {
            Console.WriteLine(Strings.ConfigurationFile_NotExists, filePath);
            Console.ForegroundColor = oldColor;
            return 1;
        }

        string json = string.Empty;
        try
        {
            json = File.ReadAllText(filePath);
        }
        catch(Exception ex)
        {
            Console.WriteLine(Strings.СonfigurationFile_ErrorReading, filePath, ex.Message);
            Console.ForegroundColor = oldColor;
            return 3;
        }

        CleanupRules? rules = null;
        try
        {
            rules = JsonSerializer.Deserialize<CleanupRules>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine(Strings.СonfigurationFile_InvalidFormat, filePath, ex.Message);
            Console.ForegroundColor = oldColor;
            return 4;
        }
        Console.ForegroundColor = oldColor;
        await Cleaning(directory!, rules!);

        return 0;
    }

    static async Task Cleaning(string directory, CleanupRules rules)
    {
        await Task.Run(() =>
        {
            var oldColor = Console.ForegroundColor;
            foreach (var item in rules.Items)
            {
                var files = Directory.EnumerateFiles(directory, item.FileNameMask, SearchOption.TopDirectoryOnly);
                var oldDate = DateTime.UtcNow.AddDays(-(item.KeepDays ?? rules.Defaults.KeepDays));
                files = files.Select(x => new { Path = x, LastWriteTimeUtc = File.GetLastWriteTimeUtc(x) })
                    .Where(x => x.LastWriteTimeUtc <= oldDate)
                    .OrderBy(x => x.Path)
                    .ThenByDescending(x => x.LastWriteTimeUtc)
                    .Select(x => x.Path)
                    .ToList();

                if (files.Count() > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine(Strings.DeletedFiles, directory);
                    foreach (var file in files)
                    {
                        File.Delete(file);
                        Console.WriteLine($"\t{Path.GetFileName(file)}");
                    }
                }
                else
                {
                    Console.ForegroundColor = oldColor;
                    var path = Path.Combine(directory, item.FileNameMask);
                    Console.WriteLine(Strings.NoOutdatedFiles, path);
                }
            }
            Console.ForegroundColor = oldColor;
            return;
        });
    }    
}


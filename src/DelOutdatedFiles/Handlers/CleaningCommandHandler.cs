using DelOutdatedFiles.Config;
using System.Text.Json;

namespace DelOutdatedFiles.Handlers;

internal sealed class CleaningCommandHandler
{
    public static async Task<int> Invoke(string? directory)
    {
        if (directory != null && !Directory.Exists(directory))
        {
            Utils.ConsoleWriteLine(Consts.ErrorColor, Strings.InvalidDirectory, directory);
            return 2;
        }
        var dir = directory == null ? Directory.GetCurrentDirectory() : directory;
        var filePath = Path.Combine(dir, Consts.NormalConfigFileName);
        if (!File.Exists(filePath))
        {
            Utils.ConsoleWriteLine(Consts.ErrorColor, Strings.ConfigurationFile_NotExists, filePath);
            return 1;
        }

        string json = string.Empty;
        try
        {
            json = File.ReadAllText(filePath);
        }
        catch(Exception ex)
        {
            Utils.ConsoleWriteLine(Consts.ErrorColor, Strings.СonfigurationFile_ErrorReading, filePath, ex.Message);
            return 3;
        }

        CleanupRules? rules = null;
        try
        {
            rules = JsonSerializer.Deserialize<CleanupRules>(json);
        }
        catch (Exception ex)
        {
            Utils.ConsoleWriteLine(Consts.ErrorColor, Strings.СonfigurationFile_InvalidFormat, filePath, ex.Message);
            return 4;
        }
        await Cleaning(directory!, rules!);

        return 0;
    }

    static async Task Cleaning(string directory, CleanupRules rules)
    {
        await Task.Run(() =>
        {
            foreach (var item in rules.Items)
            {                
                var filesAll = Directory.EnumerateFiles(directory, item.FileNameMask, SearchOption.TopDirectoryOnly);

                var olderSinceDate = DateTime.UtcNow.AddDays(-(item.KeepDays ?? rules.Defaults.KeepDays));
                var outdatedFiles = filesAll.Select(x => new { Path = x, LastWriteTimeUtc = File.GetLastWriteTimeUtc(x) })
                    .Where(x => x.LastWriteTimeUtc <= olderSinceDate)
                    .OrderByDescending(x => x.LastWriteTimeUtc)                    
                    .Select(x => x.Path)
                    .ToList();

                int minKeepCount = item.KeepCount ?? rules.Defaults.KeepCount;
                var allCount = filesAll.Count();
                var oldCount = outdatedFiles.Count();
                var nonOldCount = allCount - oldCount;
                List<string>? delFiles = null;
                if (nonOldCount >= minKeepCount)
                    delFiles = outdatedFiles;
                else
                    delFiles = outdatedFiles.Skip(minKeepCount - nonOldCount).ToList();

                if (delFiles.Count() > 0)
                {
                    Utils.ConsoleWriteLine(Consts.WarningColor, Strings.DeletedFiles, directory);
                    for (var i=delFiles.Count()-1; i >= 0; i--)
                    {
                        var file = delFiles[i];
                        File.Delete(file);
                        Utils.ConsoleWriteLine(Consts.WarningColor, $"\t{Path.GetFileName(file)}");
                    }
                }
                else
                {
                    var path = Path.Combine(directory, item.FileNameMask);
                    Utils.ConsoleWriteLine(Consts.WarningColor, Strings.NoOutdatedFiles, path);
                }
            }
            return;
        });
    }    
}


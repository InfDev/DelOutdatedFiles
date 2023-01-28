using DelOutdatedFiles.Config;
using System.Text.Json;

namespace DelOutdatedFiles.Handlers;

internal sealed class CleaningCommandHandler
{
    public static async Task<int> Invoke(string[]? directories)
    {
        Utils.ConsoleWriteLine(ConsoleColor.DarkGray, "Begin cleaning...");

        int exitCode = 0;
        string[] dirLists = directories ?? new string[] { Directory.GetCurrentDirectory() };
        foreach (var list in dirLists)
        {
            string[] dirs = list.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            foreach (var directory in dirs)
            {
                if (!Directory.Exists(directory))
                {
                    Utils.ConsoleWriteLine(Consts.ErrorColor, Strings.InvalidDirectory, directory);
                    ++exitCode;
                    continue;
                }
                var filePath = Path.Combine(directory, Consts.NormalConfigFileName);
                if (!File.Exists(filePath))
                {
                    Utils.ConsoleWriteLine(Consts.ErrorColor, Strings.ConfigurationFile_NotExists, filePath);
                    ++exitCode;
                    continue;
                }
                string json = string.Empty;
                try
                {
                    json = File.ReadAllText(filePath);
                }
                catch (Exception ex)
                {
                    Utils.ConsoleWriteLine(Consts.ErrorColor, Strings.СonfigurationFile_ErrorReading, filePath, ex.Message);
                    ++exitCode;
                }

                CleanupRules? rules = null;
                try
                {
                    rules = JsonSerializer.Deserialize<CleanupRules>(json);
                    await Cleaning(directory!, rules!);
                }
                catch (Exception ex)
                {
                    Utils.ConsoleWriteLine(Consts.ErrorColor, Strings.СonfigurationFile_InvalidFormat, filePath, ex.Message);
                    ++exitCode;
                }
            }
        }
        return exitCode;
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
                    Utils.ConsoleWriteLine(Consts.InfoColor, Strings.NoOutdatedFiles, path);
                }
            }
            return;
        });
    }    
}


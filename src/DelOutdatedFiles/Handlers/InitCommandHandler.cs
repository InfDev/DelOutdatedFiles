using DelOutdatedFiles.Config;

namespace DelOutdatedFiles.Handlers;

internal sealed class InitCommandHandler
{
    public static async Task<int> Invoke(string? directory, int keepDays, int keepCount, int timestampLength)
    {
        if (directory != null && !Directory.Exists(directory))
        {
            Utils.ConsoleWriteLine(Consts.ErrorColor, Strings.InvalidDirectory, directory);
            return 2;
        }
        var dir = directory == null ? Directory.GetCurrentDirectory() : directory;
        var filePath = Path.Combine(dir, Consts.NormalConfigFileName);
        if (File.Exists(filePath))
        {
            Utils.ConsoleWriteLine(Consts.WarningColor, Strings.ConfigurationFile_AlreadyExists, filePath);
            return 0;
        }

        var rules = new CleanupRules();
        rules.Defaults.KeepDays = keepDays;
        rules.Defaults.KeepCount = keepCount;
        rules.Items = await GetCleanupItems(dir, timestampLength);

        var json = rules.ToJson();
        await File.WriteAllTextAsync(filePath!, json);

        Utils.ConsoleWriteLine(Consts.InfoColor, Strings.NotifyOk_InitCommand, directory!);
        return 0;
    }
        
    static async Task<List<CleanupItem>> GetCleanupItems(string dir, int timestampLength)
    {
        return await Task.Run(() =>
        {
            var list = new List<CleanupItem>();

            var ts = "".PadRight(timestampLength, '?');
            var mask = "?*" + "".PadRight(timestampLength, '?') + ".*";
            var files = Directory.EnumerateFiles(dir, mask, SearchOption.TopDirectoryOnly);
            var fileNames = files.Select(x => Path.GetFileName(x));
            var fileMasks = new List<string>();
            foreach (var file in fileNames)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                if (fileName.Length <= timestampLength)
                    continue;
                var fileMask = fileName.Substring(0, fileName.Length - timestampLength) + "*" + Path.GetExtension(file);
                fileMasks.Add(fileMask);
            }
            fileMasks = fileMasks.Distinct().ToList();
            foreach (var item in fileMasks)
            {
                list.Add(new CleanupItem
                {
                    FileNameMask = item
                });
            }

            return list;
        });
    }
}

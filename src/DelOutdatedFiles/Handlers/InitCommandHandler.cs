using DelOutdatedFiles.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelOutdatedFiles.Handlers
{
    internal sealed class InitCommandHandler
    {
        public static async Task<int> Invoke(string? directory, int keepDays, int keepCount, int timestampLength)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (directory != null && !Directory.Exists(directory))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Strings.InvalidDirectory, directory);
                Console.ForegroundColor = oldColor;
                return 2;
            }
            var dir = directory == null ? Directory.GetCurrentDirectory() : directory;
            var filePath = Path.Combine(dir, Consts.NormalConfigFileName);
            if (File.Exists(filePath))
            {
                Console.WriteLine(Strings.ConfigurationFileAlreadyExists, filePath);
                Console.ForegroundColor = oldColor;
                return 1;
            }

            var rules = new CleanupRules();
            rules.Defaults.KeepDays = keepDays;
            rules.Defaults.KeepCount = keepCount;
            rules.Items = await GetCleanupItems(dir, timestampLength);

            var json = rules.ToJson();
            await File.WriteAllTextAsync(filePath!, json);

            Console.WriteLine(Strings.NotifyOk_InitCommand, directory);
            Console.ForegroundColor = oldColor;
            //Console.ReadKey();

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
                fileMasks = fileMasks.Distinct().ToList(); //GroupBy(x => x).Select(kv => kv.Key).ToList();
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
}

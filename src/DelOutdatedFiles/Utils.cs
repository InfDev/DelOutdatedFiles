using DelOutdatedFiles.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelOutdatedFiles
{
    internal static class Utils
    {

        //public static (bool ok, string? directory) SafeDirectoryName(string? path)
        //{
        //    var ok = true;
        //    if (string.IsNullOrWhiteSpace(path))
        //        return (ok, null);
        //    try
        //    {
        //        if (!Directory.Exists(path))
        //        {
        //            Console.WriteLine(Strings.InvalidDirectory, path);
        //            return (false, null);
        //        }
        //        return (ok, path);
        //    }
        //    catch { 
        //        Console.WriteLine(Strings.InvalidDirectory, path);
        //        return(false, null);
        //    }
        //}

        //public static async Task<bool> CleanupRulesToFile(this CleanupRules cleanupRules, string? path = null, bool fileNameNormal = true)
        //{
        //    var (ok, dir) = SafeDirectoryName(path);
        //    if (!ok)
        //        return false;

        //    var json = cleanupRules.ToJson();
        //    string? filePath = path;
        //    if (fileNameNormal)
        //    {
        //        if (path == null)
        //            filePath = NormalConfigFileName;
        //        else
        //        {
        //            if (!Directory.Exists(path))
        //            {
        //                Console.WriteLine(Strings.InvalidDirectory, path);
        //                return false;
        //            }
        //        }
        //        filePath = Path.Combine(dir!, NormalConfigFileName);
        //    }
        //    if (File.Exists(filePath))
        //    {
        //        Console.WriteLine(Strings.ConfigurationFileAlreadyExists, filePath);
        //        return false;
        //    }
        //    await File.WriteAllTextAsync(filePath!, json);
        //    return true;
        //}
    }
}

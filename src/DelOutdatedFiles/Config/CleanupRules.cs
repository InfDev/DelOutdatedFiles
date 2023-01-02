using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace DelOutdatedFiles.Config
{
    internal class CleanupRules
    {
        public CleanupDefaults Defaults { get; set; } = new CleanupDefaults();
        public CleanupItem ItemSample { get; set; } = new CleanupItem { 
            FileNameMask = "AppDb.*.bak",
            KeepDays = 1,
            KeepCount = 1
        };
        public List<CleanupItem> Items { get; set; } = new List<CleanupItem>();

        public string ToJson()
        {
            var json = JsonSerializer.Serialize(this, new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                });
            return json;
        }
    }
}

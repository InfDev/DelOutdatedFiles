namespace DelOutdatedFiles.Config
{
    internal class CleanupItem
    {
        private int? _keepDays = null;
        private int? _keepCount = null;

        public string FileNameMask { get; set; } = string.Empty;
        public int? KeepDays
        {
            get => _keepDays;
            set => _keepDays = value.HasValue ?
                (value >= Consts.MinimumAllowedKeepDays ? value : Consts.MinimumAllowedKeepDays) : null;
        }

        public int? KeepCount
        {
            get => _keepCount;
            set => _keepCount = value.HasValue ?
                (value >= Consts.MinimumAllowedKeepCount ? value : Consts.MinimumAllowedKeepCount) : null;
        }
    }
}

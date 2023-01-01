namespace DelOutdatedFiles.Config
{
    internal class CleanupDefaults
    {
        private int _keepDays = Consts.DefaultKeepDays;
        private int _keepCount = Consts.DefaultKeepCount;

        public int KeepDays {
            get => _keepDays;
            set => _keepDays = value < Consts.MinimumAllowedKeepDays ? Consts.MinimumAllowedKeepDays : value;
        }

        public int KeepCount
        {
            get => _keepCount;
            set => _keepCount = value < Consts.MinimumAllowedKeepCount ? Consts.MinimumAllowedKeepCount : value;
        }
    }
}

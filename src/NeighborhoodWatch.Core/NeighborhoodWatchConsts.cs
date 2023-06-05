using NeighborhoodWatch.Debugging;

namespace NeighborhoodWatch
{
    public class NeighborhoodWatchConsts
    {
        public const string LocalizationSourceName = "NeighborhoodWatch";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "927613eb604d495baf0b21014f9b622b";
    }
}

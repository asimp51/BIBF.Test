using BIBF.Test.Debugging;

namespace BIBF.Test
{
    public class TestConsts
    {
        public const string LocalizationSourceName = "Test";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "d852dd06348346379c5d47b16a5eed0e";
    }
}

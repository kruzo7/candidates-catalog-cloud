namespace StaticWebApp.CVGatorBetaBlazorWasm.Commons
{
    internal static class KeyboardKeys
    {
        public const string NumpadEnter = "NumpadEnter";
        public const string Enter = "Enter";

        public static bool IsEnter(string keyCode)
        {
            return keyCode.ToLower() == Enter.ToLower() || keyCode.ToLower() == NumpadEnter.ToLower();
        }
    }
}

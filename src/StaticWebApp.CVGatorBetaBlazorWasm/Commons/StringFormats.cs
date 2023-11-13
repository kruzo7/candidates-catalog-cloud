namespace StaticWebApp.CVGatorBetaBlazorWasm.Commons
{
    internal static class StringFormats
    {
        public static string FromList(ICollection<string>? stringList)
        {
            if (stringList == null || !stringList.Any())
                return "Empty";

            return string.Join(", ", stringList);
        }
    }
}

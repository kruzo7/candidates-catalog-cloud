namespace StaticWebApp.CVGatorBetaBlazorWasm.Commons
{
    internal static class DateTimeFormats
    {
        private static readonly string _dateFormat = "dd.MM.yyyy";

        public static string GetDate(DateTimeOffset? dateTimeOffset)
        {
            if(!dateTimeOffset.HasValue)
                return "Unknown date.";

            return dateTimeOffset!.Value.Date.ToString(_dateFormat);
        }
    }
}

namespace StaticWebApp.CVGatorBetaBlazorWasm.Commons
{
    internal class PagingLink
    {   
        public int Page { get; set; }
        public bool Enabled { get; set; }
        public bool Active { get; set; }
        public PagingLink(int page, bool enabled)
        {
            Page = page;
            Enabled = enabled;
        }
    }
}

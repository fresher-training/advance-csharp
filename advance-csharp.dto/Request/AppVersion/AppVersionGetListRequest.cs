namespace advance_csharp.dto.Request.AppVersion
{
    /// <summary>
    /// App version get list
    /// </summary>
    public class AppVersionGetListRequest : IPagingRequest
    {
        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Page Index
        /// </summary>
        public int PageIndex { get; set; } = 1;

        public string Version { get; set; } = string.Empty;
    }
}

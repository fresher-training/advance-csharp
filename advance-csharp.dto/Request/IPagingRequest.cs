namespace advance_csharp.dto.Request
{
    public interface IPagingRequest
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}

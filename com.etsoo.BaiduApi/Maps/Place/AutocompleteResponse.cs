namespace com.etsoo.BaiduApi.Maps.Place
{
    /// <summary>
    /// Autocomplete response
    /// 自动填充响应
    /// </summary>
    public record AutocompleteResponse : BaseResponse
    {
        public required IEnumerable<Place> Result { get; init; }
    }
}

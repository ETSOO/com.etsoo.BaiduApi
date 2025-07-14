namespace com.etsoo.BaiduApi.Maps.Place
{
    /// <summary>
    /// Search place response
    /// 查询地址响应
    /// </summary>
    public record SearchPlaceResponse : BaseResponse
    {
        public IEnumerable<Place> Results { get; init; } = [];
    }
}

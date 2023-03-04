namespace com.etsoo.BaiduApi.Options
{
    /// <summary>
    /// Baidu Maps API options
    /// 百度地图接口参数
    /// </summary>
    public record MapsOptions
    {
        /// <summary>
        /// API key
        /// 接口密钥
        /// </summary>
        public required string ApiKey { get; init; }

        /// <summary>
        /// API base address
        /// 接口基地址
        /// </summary>
        public string BaseAddress { get; init; } = "https://api.map.baidu.com/place/v2/";
    }
}

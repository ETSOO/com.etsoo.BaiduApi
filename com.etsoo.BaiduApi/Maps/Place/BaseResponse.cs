namespace com.etsoo.BaiduApi.Maps.Place
{
    /// <summary>
    /// Base response
    /// 基本响应
    /// </summary>
    public record BaseResponse
    {
        /// <summary>
        /// Status
        /// 本次API访问状态
        /// </summary>
        public required PlaceApiStatus Status { get; init; }

        /// <summary>
        /// Message
        /// 对API访问状态值的英文说明，如果成功返回"ok"，并返回结果字段，如果失败返回错误说明
        /// </summary>
        public required string Message { get; init; }
    }
}

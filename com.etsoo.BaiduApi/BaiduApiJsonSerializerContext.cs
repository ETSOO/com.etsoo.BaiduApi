using System.Text.Json.Serialization;

namespace com.etsoo.BaiduApi
{
    /// <summary>
    /// Baidu API JSON serializer context
    /// 百度API JSON序列化上下文
    /// </summary>
    [JsonSerializable(typeof(Maps.Place.RQ.MapBaseRQ))]
    public partial class BaiduApiJsonSerializerContext : JsonSerializerContext
    {
    }

    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower)]
    [JsonSerializable(typeof(Maps.Place.BaseResponse))]
    internal partial class BaiduApiCallJsonSerializerContext : JsonSerializerContext
    {
    }
}

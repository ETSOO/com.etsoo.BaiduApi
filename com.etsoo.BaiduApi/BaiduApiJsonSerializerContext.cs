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

    /// <summary>
    /// Baidu API call JSON serializer context
    /// 百度API调用JSON序列化上下文
    /// </summary>
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower)]
    [JsonSerializable(typeof(Maps.Place.BaseResponse))]
    public partial class BaiduApiCallJsonSerializerContext : JsonSerializerContext
    {
    }
}

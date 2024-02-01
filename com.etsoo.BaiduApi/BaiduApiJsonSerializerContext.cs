using System.Text.Json.Serialization;

namespace com.etsoo.BaiduApi
{
    /// <summary>
    /// Baidu API JSON serializer context
    /// 百度API JSON序列化上下文
    /// </summary>
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, DictionaryKeyPolicy = JsonKnownNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true)]
    [JsonSerializable(typeof(Maps.Place.RQ.MapBaseRQ))]
    [JsonSerializable(typeof(Maps.Place.BaseResponse))]
    public partial class BaiduApiJsonSerializerContext : JsonSerializerContext
    {
    }

    /// <summary>
    /// Baidu API call JSON serializer context
    /// 百度API调用JSON序列化上下文
    /// </summary>
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower, DictionaryKeyPolicy = JsonKnownNamingPolicy.SnakeCaseLower, PropertyNameCaseInsensitive = true)]
    [JsonSerializable(typeof(Maps.Place.BaseResponse))]
    internal partial class BaiduApiCallJsonSerializerContext : JsonSerializerContext
    {
    }
}

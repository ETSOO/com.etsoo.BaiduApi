using com.etsoo.BaiduApi.Maps.Place.RQ;
using com.etsoo.Utils.String;

namespace com.etsoo.BaiduApi.Maps.Place
{
    /// <summary>
    /// Base request
    /// 基本请求
    /// </summary>
    public record BaseRequest
    {
        /// <summary>
        /// Parameters
        /// 参数
        /// </summary>
        protected readonly Dictionary<string, string> Parameters = [];

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="key">API Key</param>
        /// <param name="rq">Base request data</param>
        protected BaseRequest(string key, MapBaseRQ rq)
        {
            Parameters["output"] = rq.Output.ToString().ToLower();
            Parameters["ak"] = key;
            Parameters["query"] = rq.Query;
            Parameters["region"] = rq.Region;
            Parameters["coord_type"] = ((byte)rq.CoordType).ToString();
            if (rq.CityLimit.HasValue) Parameters["city_limit"] = rq.CityLimit.ToJson();
        }

        /// <summary>
        /// To query string
        /// 输出查询字符串
        /// </summary>
        /// <returns>Result</returns>
        public virtual string ToQuery()
        {
            return Parameters.JoinAsQuery().TrimEnd('&');
        }
    }
}

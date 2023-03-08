using com.etsoo.ApiModel.RQ.Maps;

namespace com.etsoo.BaiduApi.Maps.Place.RQ
{
    /// <summary>
    /// Autocomplete request data
    /// https://lbsyun.baidu.com/index.php?title=webapi/place-suggestion-api
    /// </summary>
    public record AutocompleteRQ : MapBaseRQ
    {
        /// <summary>
        /// Create from common query request data
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Result</returns>
        public static AutocompleteRQ CreateFrom(PlaceQueryRQ rq)
        {
            return new AutocompleteRQ
            {
                Output = rq.Output,
                Query = rq.Query,
                Location= rq.Location
            };
        }
    }
}

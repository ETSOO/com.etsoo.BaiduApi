using com.etsoo.BaiduApi.Maps.Place;
using com.etsoo.BaiduApiModel.Maps.RQ;

namespace com.etsoo.BaiduApi.Maps
{
    /// <summary>
    /// Map place service interface
    /// 地图地址服务接口
    /// </summary>
    public interface IMapPlaceService
    {
        /// <summary>
        /// Async autocomplete
        /// 异步自动填充
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Result</returns>
        Task<AutocompleteResponse?> AutoCompleteAsync(AutocompleteRQ rq);

        /// <summary>
        /// Async search place
        /// 异步查询地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Result</returns>
        Task<SearchPlaceResponse?> SearchPlaceAsync(SearchPlaceRQ rq);
    }
}
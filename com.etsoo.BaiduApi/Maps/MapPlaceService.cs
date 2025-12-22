using com.etsoo.ApiModel.Dto.Maps;
using com.etsoo.BaiduApi.Maps.Place;
using com.etsoo.BaiduApi.Maps.Place.RQ;
using com.etsoo.BaiduApi.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace com.etsoo.BaiduApi.Maps
{
    /// <summary>
    /// Map place service
    /// 地图地址服务
    /// </summary>
    public class MapPlaceService : IMapPlaceService
    {
        private readonly MapsOptions options;
        private readonly HttpClient client;

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="options">Options</param>
        /// <param name="httpClient">HTTP client</param>
        public MapPlaceService(MapsOptions options, HttpClient client)
        {
            client.BaseAddress = new Uri(options.BaseAddress);

            this.options = options;
            this.client = client;
        }

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="options">Options</param>
        /// <param name="httpClient">HTTP client</param>
        [ActivatorUtilitiesConstructor]
        public MapPlaceService(IOptions<MapsOptions> options, HttpClient httpClient)
            : this(options.Value, httpClient)
        {
        }

        /// <summary>
        /// Async autocomplete
        /// 异步自动填充
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<AutocompleteResponse?> AutoCompleteAsync(AutocompleteRQ rq, CancellationToken token = default)
        {
            var request = new AutocompleteRequest(options.ApiKey, rq);

            var api = $"suggestion?{request.ToQuery()}";

            return await client.GetFromJsonAsync(api, BaiduApiCallJsonSerializerContext.Default.AutocompleteResponse, token);
        }

        /// <summary>
        /// Async search place
        /// 异步查询地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<SearchPlaceResponse?> SearchPlaceAsync(SearchPlaceRQ rq, CancellationToken token = default)
        {
            var request = new SearchPlaceRequest(options.ApiKey, rq);

            var method = rq.Bounds?.Any() is true ? "polygon" : (rq.Location != null && rq.Radius != null ? "around" : "region");

            var api = $"{method}?{request.ToQuery()}";

            return await client.GetFromJsonAsync(api, BaiduApiCallJsonSerializerContext.Default.SearchPlaceResponse, token);
        }

        /// <summary>
        /// Async search common place
        /// 异步查询通用地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<IEnumerable<PlaceCommon>?> SearchCommonPlaceAsync(SearchPlaceRQ rq, CancellationToken token = default)
        {
            var response = await SearchPlaceAsync(rq, token);
            var results = response?.Results;
            if (results == null) return null;

            return results.Select(item => item.CreateCommon(rq.Query));
        }
    }
}

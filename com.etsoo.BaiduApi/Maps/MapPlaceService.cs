using com.etsoo.BaiduApi.Maps.Place;
using com.etsoo.BaiduApi.Options;
using com.etsoo.BaiduApiModel.Maps.RQ;
using com.etsoo.Utils.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;

namespace com.etsoo.BaiduApi.Maps
{
    /// <summary>
    /// Map place service
    /// 地图地址服务
    /// </summary>
    public class MapPlaceService : IMapPlaceService
    {
        private readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive= true,
            PropertyNamingPolicy = new JsonSnakeNamingPolicy()
        };

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
        /// <returns>Result</returns>
        public async Task<AutocompleteResponse?> AutoCompleteAsync(AutocompleteRQ rq)
        {
            var request = new AutocompleteRequest(options.ApiKey, rq);

            var api = $"place/suggestion?{request.ToQuery()}";

            return await client.GetFromJsonAsync<AutocompleteResponse>(api, jsonSerializerOptions);
        }

        /// <summary>
        /// Async search place
        /// 异步查询地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Result</returns>
        public async Task<SearchPlaceResponse?> SearchPlaceAsync(SearchPlaceRQ rq)
        {
            var request = new SearchPlaceRequest(options.ApiKey, rq);

            var api = $"place/search?{request.ToQuery()}";

            return await client.GetFromJsonAsync<SearchPlaceResponse>(api, jsonSerializerOptions);
        }
    }
}

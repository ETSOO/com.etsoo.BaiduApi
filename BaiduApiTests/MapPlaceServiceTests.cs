using com.etsoo.BaiduApi.Maps;
using com.etsoo.BaiduApi.Options;
using com.etsoo.BaiduApiModel.Maps.RQ;

namespace BaiduApi.Tests
{
    [TestClass]
    public class MapPlaceServiceTests
    {
        readonly MapPlaceService service;

        public MapPlaceServiceTests()
        {
            service = new MapPlaceService(new MapsOptions
            {
                ApiKey = File.ReadAllText("C:\\api\\BaiduMaps.txt")
            }, new HttpClient());
        }

        [TestMethod]
        public async Task SearchPlaceAsyncTest()
        {
            var response = await service.SearchPlaceAsync(new SearchPlaceRQ
            {
                Query = "清溪路88号玫瑰庭院11号楼",
                WithDetails = true
            });
            Assert.IsNotNull(response);

            var first = response.Results.First();
            Assert.IsNotNull(first);

            Assert.IsTrue(response.Results.Any(result => result.City == "青岛市"));

            Assert.IsNotNull(first.DetailInfo);
        }

        [TestMethod]
        public async Task AutocompleteAsyncTest()
        {
            var response = await service.AutoCompleteAsync(new AutocompleteRQ
            {
                Query = "玫瑰庭院"
            });

            Assert.IsNotNull(response);

            var first = response.Result.First();
            Assert.IsNotNull(first);

            Assert.IsTrue(response.Result.Any(result => result.City == "青岛市"));
        }
    }
}

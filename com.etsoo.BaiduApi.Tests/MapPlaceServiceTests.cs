using com.etsoo.ApiModel.RQ.Maps;
using com.etsoo.BaiduApi.Maps;
using com.etsoo.BaiduApi.Maps.Place;
using com.etsoo.BaiduApi.Maps.Place.RQ;
using com.etsoo.BaiduApi.Options;

namespace com.etsoo.BaiduApi.Tests
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
        public async Task NoApiKeyTest()
        {
            var tempService = new MapPlaceService(new MapsOptions
            {
                ApiKey = string.Empty
            }, new HttpClient());

            var response = await tempService.SearchPlaceAsync(new SearchPlaceRQ
            {
                Query = "清溪路88号玫瑰庭院11号楼",
                WithDetails = true
            }, TestContext.CancellationToken);

            Assert.IsNotNull(response);
            Assert.AreEqual(PlaceApiStatus.AKNotExists, response.Status);
        }

        [TestMethod]
        public async Task SearchPlaceAsyncTest()
        {
            var response = await service.SearchPlaceAsync(new SearchPlaceRQ
            {
                Query = "清溪路88号玫瑰庭院11号楼",
                PageSize = 3,
                WithDetails = true
            }, TestContext.CancellationToken);

            Assert.IsNotNull(response);

            Assert.AreEqual(3, response.Results.Count());

            var first = response.Results.First();
            Assert.IsNotNull(first);

            Assert.IsTrue(response.Results.Any(result => result.City == "青岛市"));

            Assert.IsNotNull(first.DetailInfo);
        }

        [TestMethod]
        public async Task SearchCommonPlaceAsyncTest()
        {
            var result = await service.SearchCommonPlaceAsync(new SearchPlaceRQ
            {
                Query = "清溪路88号玫瑰庭院9号楼3单元502",
                WithDetails = true
            }, TestContext.CancellationToken);
            Assert.IsNotNull(result);

            var first = result.Where(a => a.Name.Equals("玫瑰庭院")).First();

            Assert.IsNotNull(first);
            Assert.AreEqual("CN", first.Region);
            Assert.AreEqual("山东省", first.State);
            Assert.AreEqual("青岛市", first.City);
            Assert.AreEqual("玫瑰庭院", first.Name);
            Assert.AreEqual("山东省青岛市李沧区清溪路88号玫瑰庭院9号楼3单元502", first.FormattedAddress);
        }

        [TestMethod]
        public async Task SearchCommonPlaceFullAsyncTest()
        {
            var result = await service.SearchCommonPlaceAsync(new SearchPlaceRQ
            {
                Query = "山东省青岛李沧清溪路88号玫瑰庭院10号楼二单元501室",
                WithDetails = true
            }, TestContext.CancellationToken);

            Assert.IsNotNull(result);

            var first = result.Where(a => a.District == "李沧区").First();

            Assert.IsNotNull(first);
            Assert.AreEqual("CN", first.Region);
            Assert.AreEqual("山东省", first.State);
            Assert.AreEqual("青岛市", first.City);
            Assert.AreEqual("李沧区", first.District);
            Assert.AreEqual("玫瑰庭院", first.Name.Split('-')[0]);
            Assert.AreEqual("山东省青岛市李沧区清溪路88号玫瑰庭院10号楼二单元501室", first.FormattedAddress);
        }

        [TestMethod]
        public async Task SearchCommonAsyncExample1Test()
        {
            var result = await service.SearchCommonPlaceAsync(new SearchPlaceRQ
            {
                Query = "广东省佛山市季华西路中国陶瓷总部基地中区E座",
                WithDetails = true
            }, TestContext.CancellationToken);
            Assert.IsNotNull(result);

            var first = result.Where(a => a.City == "佛山市" && a.Name.Contains("基地中区")).First();

            Assert.IsNotNull(first);
            Assert.AreEqual("CN", first.Region);
            Assert.AreEqual("广东省", first.State);
            Assert.AreEqual("禅城区", first.District);
            Assert.AreEqual("中国陶瓷产业总部基地中区", first.Name.Split('-')[0]);
            Assert.AreEqual("佛山市禅城区广场东路中国陶瓷产业总部基地总部基地中区E座", first.FormattedAddress);
        }

        [TestMethod]
        public async Task AutocompleteAsyncTest()
        {
            var response = await service.AutoCompleteAsync(new AutocompleteRQ
            {
                Query = "玫瑰庭院"
            }, TestContext.CancellationToken);

            Assert.IsNotNull(response);

            var first = response.Results.First();
            Assert.IsNotNull(first);

            Assert.IsTrue(response.Results.Any(result => result.City == "青岛市"));
        }

        [TestMethod]
        public async Task QueryAroundTest()
        {
            var response = await service.SearchPlaceAsync(new SearchPlaceRQ
            {
                Query = "民生银行",
                Location = new(39.915F, 116.404F),
                Radius = 1000,
                PageSize = 3,
                WithDetails = true
            }, TestContext.CancellationToken);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Results.Any(result => result.Name.StartsWith("中国民生银行")));
        }

        [TestMethod]
        public async Task LanguageSpecifiedTest()
        {
            var rq = new PlaceQueryRQ
            {
                Query = "青岛数码科技中心-A座1008室",
                PageSize = 3,
                Language = "zh-Hans"
            };

            var results = await service.SearchCommonPlaceAsync(SearchPlaceRQ.CreateFrom(rq), TestContext.CancellationToken);
            
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count());
        }

        public TestContext TestContext { get; set; }
    }
}

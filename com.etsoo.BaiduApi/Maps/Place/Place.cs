using com.etsoo.ApiModel.Dto.Maps;
using CommonPlace = com.etsoo.ApiModel.Dto.Maps.Place;

namespace com.etsoo.BaiduApi.Maps.Place
{
    /// <summary>
    /// Place detail information
    /// </summary>
    public record PlaceDetailInfo
    {
        public required string Tag { get; init; }
        public required string Type { get; init; }
        public required string DetailUrl { get; init; }
        public string? ShopHours { get; init; }
    }

    /// <summary>
    /// Place
    /// 地点
    /// </summary>
    public record Place
    {
        public required string Name { get; init; }
        public required Location Location { get; init; }
        public required string Uid { get; init; }
        public required string Province { get; init; }
        public required string City { get; init; }
        public string? CityId { get; init; }
        public string? District { get; init; }
        public string? Area { get; init; }
        public required string Address { get; init; }
        public string? Adcode { get; init; }
        public PlaceDetailInfo? DetailInfo { get; init; }

        /// <summary>
        /// Create autocomplete place
        /// 创建自动填充地点
        /// </summary>
        /// <returns>Result</returns>
        public PlaceAutocomplete CreateAutocomplete()
        {
            return new PlaceAutocomplete
            {
                Name = $"{Name}, {Address}",
                PlaceId = Uid,
                Place = new PlaceBase
                {
                    Location = Location,
                    Region = "CN",
                    State = Province,
                    City = City,
                    District = District ?? Area
                }
            };
        }

        /// <summary>
        /// Create common place
        /// 创建通用地点
        /// </summary>
        /// <returns>Result</returns>
        public CommonPlace CreateCommon()
        {
            return new CommonPlace
            {
                Name = Name,
                Location = Location,
                PlaceId = Uid,
                FormattedAddress = Address,
                Region = "CN",
                State = Province,
                City = City,
                District = District ?? Area
            };
        }
    }
}

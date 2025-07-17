using com.etsoo.ApiModel.Dto.Maps;
using com.etsoo.Utils.String;

namespace com.etsoo.BaiduApi.Maps.Place
{
    /// <summary>
    /// Place detail information
    /// </summary>
    public record PlaceDetailInfo
    {
        public string? Tag { get; init; }
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
        /// <param name="query">Original query</param>
        /// <returns>Result</returns>
        public PlaceCommon CreateCommon(string query)
        {
            var district = District ?? Area;
            var formattedAddress = Address;

            var lcs = StringUtils.GetLCS(query, Name).ToString();

            var pos = lcs.Length < 5 ? -1 : query.LastIndexOf(lcs);
            if (pos == -1)
            {
                var first = Name.Split('-')[0];
                pos = query.LastIndexOf(first);
                if (pos == -1)
                {
                    if (!formattedAddress.Contains(Name))
                    {
                        formattedAddress += Name;
                    }
                }
                else
                {
                    if (!formattedAddress.Contains(first))
                    {
                        formattedAddress += first;
                    }

                    formattedAddress += query[(pos + first.Length)..];
                }
            }
            else
            {
                formattedAddress += query[pos..];
            }

            return new PlaceCommon
            {
                Name = Name,
                Location = Location,
                PlaceId = Uid,
                FormattedAddress = formattedAddress,
                Region = "CN",
                State = Province,
                City = City,
                District = district
            };
        }
    }
}

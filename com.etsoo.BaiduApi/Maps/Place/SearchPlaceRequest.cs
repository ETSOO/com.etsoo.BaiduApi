using com.etsoo.BaiduApi.Maps.Place.RQ;
using com.etsoo.Utils.String;

namespace com.etsoo.BaiduApi.Maps.Place
{
    /// <summary>
    /// Search place request
    /// </summary>
    public record SearchPlaceRequest : BaseRequest
    {
        public SearchPlaceRequest(string key, SearchPlaceRQ rq) : base(key, rq)
        {
            if (rq.Tags is not null) Parameters["tag"] = string.Join(",", rq.Tags);
            if (rq.AdCode.HasValue) Parameters["extensions_adcod"] = rq.AdCode.ToJson();
            if (rq.WithDetails.HasValue) Parameters["scope"] = rq.WithDetails.Value ? "2" : "1";

            var bounds = rq.Bounds;
            if (bounds is not null)
            {
                if (bounds.Count() > 2)
                {
                    // 多边形为矩形时，可传入左上右下两顶点坐标对
                    // 首尾坐标对需相同
                    var first = bounds.First();
                    var last = bounds.Last();
                    if (first.Lat != last.Lat || first.Lng != last.Lng)
                    {
                        var firstRepeat = first with { };
                        bounds = bounds.Append(firstRepeat);
                    }
                }

                Parameters["bounds"] = string.Join(",", bounds.Select(b => b.ToString()));
            }
            else if (rq.Location is not null)
            {
                if (rq.Radius.HasValue)
                {
                    Parameters["radius"] = rq.Radius.Value.ToString();
                    Parameters["location"] = rq.Location.ToString();
                }
                else
                {
                    Parameters["center"] = rq.Location.ToString();
                }
            }

            if (rq.PageSize.HasValue) Parameters["page_size"] = rq.PageSize.Value.ToString();
            if (rq.PageNum.HasValue) Parameters["page_num"] = rq.PageNum.Value.ToString();
            if (rq.PhotoShow.HasValue) Parameters["photo_show"] = rq.PhotoShow.ToJson();
            if (rq.AddressResult.HasValue) Parameters["address_result"] = rq.AddressResult.ToJson();
            if (!string.IsNullOrEmpty(rq.FromLanguage)) Parameters["from_language"] = rq.FromLanguage;
        }
    }
}

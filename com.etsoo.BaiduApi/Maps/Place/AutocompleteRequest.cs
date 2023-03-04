using com.etsoo.BaiduApiModel.Maps.RQ;

namespace com.etsoo.BaiduApi.Maps.Place
{
    /// <summary>
    /// Autocomplete request
    /// </summary>
    public record AutocompleteRequest : BaseRequest
    {
        public AutocompleteRequest(string key, AutocompleteRQ rq) : base(key, rq)
        {
            if (rq.Location is not null) Parameters["center"] = rq.Location.ToString();
        }
    }
}

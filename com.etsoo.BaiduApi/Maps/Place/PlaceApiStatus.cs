namespace com.etsoo.BaiduApi.Maps.Place
{
    /// <summary>
    /// Places API status
    /// </summary>
    public enum PlaceApiStatus : byte
    {
        OK = 0,
        ParameterInvalid = 2,
        VerifyFailure = 3,
        QuotaFailure = 4,
        AKFailure = 5,
        ParseProtoFailure = 8,
        PermissionDenied = 9,
        AKNotExists = 101
    }
}

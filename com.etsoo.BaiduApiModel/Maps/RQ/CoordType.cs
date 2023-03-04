namespace com.etsoo.BaiduApiModel.Maps.RQ
{
    /// <summary>
    /// Coordinate System Type
    /// 坐标系统类型
    /// </summary>
    public enum CoordType
    {
        /// <summary>
        /// GPS经纬度
        /// </summary>
        wgs84ll = 1,

        /// <summary>
        /// 国测局经纬度
        /// </summary>
        gcj02ll = 2,

        /// <summary>
        /// 百度经纬度
        /// </summary>
        bd09ll = 3,

        /// <summary>
        /// 百度米制坐标
        /// </summary>
        bd09mc = 4
    }
}

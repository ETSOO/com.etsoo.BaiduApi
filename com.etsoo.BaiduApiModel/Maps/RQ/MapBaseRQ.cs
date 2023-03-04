using com.etsoo.ApiModel.Dto.Maps;
using com.etsoo.ApiModel.RQ.Maps;

namespace com.etsoo.BaiduApiModel.Maps.RQ
{
    /// <summary>
    /// Map base request data
    /// 地图基础请求数据
    /// </summary>
    public abstract record MapBaseRQ
    {
        /// <summary>
        /// Output format
        /// 输出格式
        /// </summary>
        public ApiOutput Output { get; init; } = ApiOutput.JSON;

        /// <summary>
        /// Query input
        /// 查询输入
        /// </summary>
        public required string Query { get; init; }

        /// <summary>
        /// Region
        /// 区域
        /// </summary>
        public string Region { get; init; } = "全国";

        /// <summary>
        /// 取值为"true"，仅返回region中指定城市检索结果
        /// </summary>
        public bool? CityLimit { get; init; }

        /// <summary>
        /// Coordinate System Type
        /// 坐标系统类型
        /// </summary>
        public CoordType CoordType { get; init; } = CoordType.wgs84ll;

        /// <summary>
        /// Center location
        /// 中心地点
        /// </summary>
        public Location? Location { get; init; }
    }
}

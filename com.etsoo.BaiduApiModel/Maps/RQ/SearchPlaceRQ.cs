﻿using com.etsoo.ApiModel.Dto.Maps;

namespace com.etsoo.BaiduApiModel.Maps.RQ
{
    /// <summary>
    /// Search place request data
    /// https://lbsyun.baidu.com/index.php?title=webapi/guide/webservice-placeapi
    /// </summary>
    public record SearchPlaceRQ : MapBaseRQ
    {
        /// <summary>
        /// Tags
        /// 检索分类偏好
        /// </summary>
        public IEnumerable<string>? Tags { get; init; }

        /// <summary>
        /// Is return AdCode
        /// 是否返回国标行政区划编码
        /// </summary>
        public bool? AdCode { get; init; }

        /// <summary>
        /// With details or not
        /// 是否包含细节
        /// </summary>
        public bool? WithDetails { get; init; }

        /// <summary>
        /// Circle area radius, in meters, default is 1000
        /// 圆形区域检索半径，单位为米
        /// </summary>
        public int? Radius { get; init; }

        /// <summary>
        /// Is limit to radius
        /// 是否严格限定召回结果在设置检索半径范围内
        /// </summary>
        public bool? RadiusLimit { get; init; }

        /// <summary>
        /// The area of the polygon
        /// 检索多边形区域。需传入多个坐标对集合，坐标对用","分割，首尾坐标对需相同。多边形为矩形时，可传入左上右下两顶点坐标对
        /// </summary>
        public IEnumerable<Location>? Bounds { get; init; }

        /// <summary>
        /// Page size
        /// 单次召回POI数量
        /// </summary>
        public int? PageSize { get; init; }

        /// <summary>
        /// Page number
        /// 分页页码，默认为0，0代表第一页
        /// </summary>
        public int? PageNum { get; init; }

        /// <summary>
        /// Show photo or not
        /// 是否输出图片信息：true(输出) 、false(不输出)
        /// </summary>
        public bool? PhotoShow { get; init; }

        /// <summary>
        /// Show address result or not
        /// 若不传入该字段，默认召回门址数据，仅当address_result=false时，召回相应的POI数据
        /// </summary>
        public bool? AddressResult { get; init; }
    }
}

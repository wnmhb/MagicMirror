using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace MagicMirror.Models
{
    [Serializable]
    public class Clothing
    {
        /// <summary>
        /// 服装参考标识码
        /// </summary>
        public string RefId { set; get; }
        /// <summary>
        /// 服装名称
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 产品品牌
        /// </summary>
        public string Brand { set; get; }
        /// <summary>
        /// 服装类型
        /// </summary>
        public ClothingType Type { set; get; }
        /// <summary>
        /// 服装展示使用的图片列表
        /// </summary>
        public List<string> Photos { set; get; }
        /// <summary>
        /// 服装展示的主要图片
        /// </summary>
        public string MainPhoto { set; get; }

        /// <summary>
        /// 服装价格
        /// </summary>
        public double Price { set; get; }
        /// <summary>
        /// 价格单位
        /// </summary>
        public PriceUnit Unit { set; get; }
        /// <summary>
        /// 服装的相关描述信息
        /// </summary>
        public string Descrition { set; get; }
        /// <summary>
        /// 服装的大小种类
        /// </summary>
        public List<Size> Sizes { set; get; }
        //服装的颜色
        public List<Color> Colors { set; get; }


    }
}

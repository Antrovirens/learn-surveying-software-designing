using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数字摄影测量
{
    /// <summary>
    /// 同名像点
    /// </summary>
    class CPoints
    {
        //像片上控制点点号
        public int id { get; set; }

        //左像片点x1y1
        public double x1 { get; set; }
        public double y1 { get; set; }

        //右像片点x2y2
        public double x2 { get; set; }
        public double y2 { get; set; }

        //空间三维控制点xtytzt
        public double xt { get; set; }
        public double yt { get; set; }
        public double zt { get; set; }

        //模型点坐标xm ym zm
        public double xm { get; set; }
        public double ym { get; set; }
        public double zm { get; set; }

        //空间坐标精度
        public double m0 { get; set; }
        public double mx { get; set; }
        public double my { get; set; }
        public double mz { get; set; }
    }
}

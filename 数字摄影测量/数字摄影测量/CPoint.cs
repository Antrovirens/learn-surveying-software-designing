using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数字摄影测量
{
    /// <summary>
    /// 保存坐标点
    /// </summary>
    class CPoint
    {
        //像片上控制点点号 
        public int id { get; set; }

        //像片上控制点x        
        public double xp { get; set; }

        //像片上控制点Y       
        public double yp { get; set; }

        //空间三维控制点x        
        public double xt { get; set; }

        //空间三维控制点Y       
        public double yt { get; set; }

        //空间三维控制点Z       
        public double zt { get; set; }
    }
}

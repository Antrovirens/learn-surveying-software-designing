using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    class CSatellites
    {
        ////电离层参数
        //public double[] Alpha { set; get; } = new double[4]
        //{
        //    1.8626451492e-09,
        //    -8.881784197e-16,
        //    432000,
        //    2049
        //};//默认测试数据
        //
        //public double[] Beta { set; get; } = new double[4] 
        //{
        //    -6.6938810050e-10,
        //    -8.437694987e-15,
        //    518400,
        //    2049
        //};
      
        //卫星列表
        public List<CSatellite> EpochSats = new List<CSatellite>();
    }
}

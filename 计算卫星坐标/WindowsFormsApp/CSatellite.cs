using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    class CSatellite
    {
        public ArrayList List0 { set; get; } = new ArrayList();
        public string Name { set; get; } = "000";

        public int Year { set; get; } = 2019;//默认测试数据
        public int Month { set; get; } = 4;
        public int Day { set; get; } = 20;
        public int Hour { set; get; } = 0;
        public int Min { set; get; } = 0;
        public int Sec { set; get; } = 0;

        public double X { set; get; } = -1;
        public double Y { set; get; } = -1;
        public double Z { set; get; } = -1;
        //17个参数
        public double[] Paras { set; get; } = new double[17]
        {
            7.800000000000e+01,
            5.734375000000e+01,
            4.378039505776e-09,
            1.949954226209e+00,
            2.935528755188e-06,
            8.662494830787e-03,
            1.033395528793e-05,
            5.153654804230e+03,
            5.184000000000e+05,
            -2.216547727585e-07,
            -2.230311975275e+00,
            1.490116119385e-08,
            9.751050277355e-01,
            1.887500000000e+02,
            6.889766110528e-01,
            -7.922472859938e-09,
            6.664563320099e-10
        };//默认测试数据

        public void InitParas(double r)
        {
            if (r < 3 || r >= 4)
                MessageBox.Show("renix版本不为3");
            Name = List0[0].ToString().Substring(0, 3);
            Year = Convert.ToInt32(List0[0].ToString().Substring(4, 4));
            Month = Convert.ToInt32(List0[0].ToString().Substring(9, 2));
            Day = Convert.ToInt32(List0[0].ToString().Substring(12, 2));
            Hour = Convert.ToInt32(List0[0].ToString().Substring(15, 2));
            Min = Convert.ToInt32(List0[0].ToString().Substring(18, 2));
            Sec = Convert.ToInt32(List0[0].ToString().Substring(21, 2));

            string str = List0[1].ToString().Substring(4, 19);
            Paras[0] = St2d(str);
            str = List0[1].ToString().Substring(23, 19);
            Paras[1] = St2d(str);
            str = List0[1].ToString().Substring(42, 19);
            Paras[2] = St2d(str);
            str = List0[1].ToString().Substring(61, 19);
            Paras[3] = St2d(str);

            str = List0[2].ToString().Substring(4, 19);
            Paras[4] = St2d(str);
            str = List0[2].ToString().Substring(23, 19);
            Paras[5] = St2d(str);
            str = List0[2].ToString().Substring(42, 19);
            Paras[6] = St2d(str);
            str = List0[2].ToString().Substring(61, 19);
            Paras[7] = St2d(str);

            str = List0[3].ToString().Substring(4, 19);
            Paras[8] = St2d(str);
            str = List0[3].ToString().Substring(23, 19);
            Paras[9] = St2d(str);
            str = List0[3].ToString().Substring(42, 19);
            Paras[10] = St2d(str);
            str = List0[3].ToString().Substring(61, 19);
            Paras[11] = St2d(str);

            str = List0[4].ToString().Substring(4, 19);
            Paras[12] = St2d(str);
            str = List0[4].ToString().Substring(23, 19);
            Paras[13] = St2d(str);
            str = List0[4].ToString().Substring(42, 19);
            Paras[14] = St2d(str);
            str = List0[4].ToString().Substring(61, 19);
            Paras[15] = St2d(str);

            str = List0[5].ToString().Substring(61, 19);
            Paras[16] = St2d(str);
        }

        private double St2d(string str)
        {
            double d;
            str.Replace('D', 'e');
            d = Convert.ToDouble(str);
            return d;
        }

    }
}

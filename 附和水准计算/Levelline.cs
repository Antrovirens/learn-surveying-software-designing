class Leveline
    {
        public double FH { get; set; }

        public double FH0 { get; set; }

        public double D { get; set; }

        public ArrayList LevelCal(ArrayList listin)
        {
            ArrayList listout = new ArrayList();
            double Ha, Hb;
            int m = listin.Count - 2;  //  测站数目
            double[] h = new double[m];  //高程    0~m+1   m
            double[] d = new double[m];  //导线长   0~m-1   km

            string line = System.Convert.ToString(listin[0]);
            Ha = System.Convert.ToDouble(line);
            line= System.Convert.ToString(listin[1]);
            Hb = System.Convert.ToDouble(line);                //录入前两行

            string[] splits = null;

            int i;
            for (i = 0; i < m; i++)
            {
                line = System.Convert.ToString(listin[i + 2]);  //角度，边长
                splits = line.Split(',');
                d[i] = System.Convert.ToDouble(splits[0]);
                h[i] = System.Convert.ToDouble(splits[1]);
            }
            ////////////////////////////////////////////////////////////////////////////
            ///
            double fh = Ha - Hb;
            double d1 = 0;
            for (i = 0; i < m; i++)
            {
                fh += h[i];
                d1 += d[i];
            }

            FH = fh * 1000;                   //闭合差 mm
            D = d1;                   //总路程  km
            FH0 = 20 * Math.Sqrt(D);   //四等水准容许值  mm

            for (i = 0; i < m; i++)
                h[i] -= fh * d[i] / D;      //加上改正数


         ////////////////////////////////////////
         ///计算高程

            double[] H = new double[m+1];
            H[0] = Ha;
            for (i = 0; i < m; i++)
                H[i+1] =H[i] + h[i];


         // MessageBox.Show("数据已计算完成~", "程序进程提示", MessageBoxButtons.OK);

         /////准备输出
            listout.Add("A: " + Ha.ToString());
            listout.Add("B: " + Hb.ToString());
            for (i = 0; i < m; i++)
            {
                string linexy = d[i].ToString() + ',' + H[i+1].ToString();
                listout.Add(linexy);
            }
            return listout;
        }
    }

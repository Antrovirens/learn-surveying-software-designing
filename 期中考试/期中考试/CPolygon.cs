using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 期中考试
{
    class CPolygon
    {
        public double[] X { get; set; }  //每行x坐标 
        public double[] Y { get; set; }  //y坐标 

        //public double[] Length { get; set; }  //边长数组
        //public double[] Alpha { get; set; }  //方位角数组
        //public int N { get; set; }  //总单点数目
        //public double Area { get; set; }  //面积
        //public double C { get; set; }  //周长

        //计算多边形各边边长
        public double[] PolygonLength ()
        {
            double[] Length = new double[X.Length];
            for (int i = 0; i < X.Length - 1; i++)
            {
                Length[i] = Math.Sqrt((X[i]-X[i+1])* (X[i] - X[i+1])+ (Y[i] - Y[i + 1]) * (Y[i] - Y[i + 1]));
            }
            Length[X.Length-1] = Math.Sqrt((X[X.Length-1] - X[0]) * (X[X.Length-1] - X[0]) + (Y[X.Length-1] - Y[0]) * (Y[X.Length-1] - Y[0]));
            return Length;
         }

        ////查询单边长度
        //private double PolygonLength(int n)
        //{
        //    if (n <= 0 || n > N)
        //        return 0;
        //    return Length[n - 1];
        //}

        //读取list中的数据到类里面


        //统计周长
        public double PolygonPerimeter(double[] Length)
        {
            double C = new double();
            for (int i = 0; i < Length.Length; i++)
            {
                C += Length[i];
            }
            return C;
        }

        //
        public double PolygonArea()
        {
            double s = new double();
            for (int i = 0; i < X.Length -1 ; i++)
            {
                s += area(X[i], Y[i], X[i + 1], Y[i + 1]);
            }
            s += area(X[X.Length - 1], Y[Y.Length - 1], X[0], Y[0]);
            return s;
        }

        //各边方位角
        public double[] Azimuth()
        {
            double[] Azimuth = new double[X.Length];
            for (int i = 0; i < X.Length - 1; i++)
            {
                Azimuth[i] = azimuth(X[i], Y[i], X[i + 1], Y[i + 1]);
            }
            Azimuth[X.Length - 1] = azimuth(X[X.Length - 1], Y[Y.Length - 1], X[0], Y[0]);
            return Azimuth;
        }

        //求面积公式
        private double area(double x1, double y1, double x2, double y2)
        {
            double s;
            s = (x2 + x1) * (y2 - y1) / 2; 
            return s;
        }

        //求方位角公式
        private double azimuth(double x1, double y1, double x2, double y2)
        {
            double a;
            double dx = x2 - x1; double dy = y2 - y1;
            if (dx == 0)//东西方向
            {
                if (dy >= 0)
                { a = Math.PI / 2; }
                else
                { a = Math.PI * 3 / 2; }
            }
            else if (dy == 0)//南北方向
            {
                if (dx >= 0)
                { a = 0; }
                else
                { a = Math.PI; }
            }
            else//任意方向
            {
                a = Math.Atan(dy / dx);
                if (dx <= 0)//二、三象限
                { a = a + Math.PI; }
                else if (dy <= 0)//第四象限
                { a = a + 2 * Math.PI; }
            }
            return a;
        }

    }
}

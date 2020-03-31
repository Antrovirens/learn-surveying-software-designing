using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数字摄影测量
{
    /// <summary>
    /// 保存相片的外方位元素
    /// </summary>
    class CImage
    {
        //像片编号       
        public string id { get; set; }
        //
        public double f { get; set; }
        public double x0 { get; set; }
        public double y0 { get; set; }
        public double m { get; set; } //缩放比例
        //外方位元素
        public double xs { get; set; }
        public double ys { get; set; }
        public double zs { get; set; }
        public double fiu { get; set; }
        public double omg { get; set; }
        public double kaf { get; set; }
        //精度评定
        public double m0 { get; set; }
        public double mxs { get; set; }
        public double mys { get; set; }
        public double mzs { get; set; }
        public double mfiu { get; set; }
        public double momg { get; set; }
        public double mkaf { get; set; }
        //计算外方位元素方法，量测相机解算，6参数

        public void ImageCal6(double ee, CPoint[] p)
        {

            //读取
            int i, j, k;
            int num = p.GetLength(0);
            double a1, a2, a3, b1, b2, b3, c1, c2, c3; //R矩阵
            double xh, yh, zh;  //像空间坐标
            fiu = 0; omg = 0; kaf = 0; //外方位元素
            double sx = 0, sy = 0, sz = 0;  //求和
            for (i = 0; i < p.GetLength(0); i++)
            { sx = sx + p[i].xt; sy = sy + p[i].yt; sz = sz + p[i].zt; }
            xs = sx / p.GetLength(0); ys = sy / p.GetLength(0); zs = sz / p.GetLength(0) + m * f / 1000; //设置初始值
            double dmax = 1;

            //迭代
            CMat mat = new CMat();
            double[,] b = null;
            double[] x = null;
            double[] l = null;

            do
            {
                a1 = Math.Cos(fiu) * Math.Cos(kaf) - Math.Sin(fiu) * Math.Sin(omg) * Math.Sin(kaf);
                a2 = -Math.Cos(fiu) * Math.Sin(kaf) - Math.Sin(fiu) * Math.Sin(omg) * Math.Cos(kaf);
                a3 = -Math.Sin(fiu) * Math.Cos(omg);
                b1 = Math.Cos(omg) * Math.Sin(kaf);
                b2 = Math.Cos(omg) * Math.Cos(kaf);
                b3 = -Math.Sin(omg);
                c1 = Math.Sin(fiu) * Math.Cos(kaf) + Math.Cos(fiu) * Math.Sin(omg) * Math.Sin(kaf);
                c2 = -Math.Sin(fiu) * Math.Sin(kaf) + Math.Cos(fiu) * Math.Sin(omg) * Math.Cos(kaf);
                c3 = Math.Cos(fiu) * Math.Cos(omg);
                CMat mat1 = new CMat();

                x = mat1.MatZero(6);
                double[,] n = mat1.MatZero(6, 6);
                double[] w = mat1.MatZero(6);
                for (k = 0; k < p.GetLength(0); k++)
                {
                    b = mat1.MatZero(2, 6);
                    l = mat1.MatZero(2);
                    double[,] n1 = mat1.MatZero(6, 6);
                    double[] w1 = mat1.MatZero(6);
                    xh = a1 * (p[k].xt - xs) + b1 * (p[k].yt - ys) + c1 * (p[k].zt - zs);
                    yh = a2 * (p[k].xt - xs) + b2 * (p[k].yt - ys) + c2 * (p[k].zt - zs);
                    zh = a3 * (p[k].xt - xs) + b3 * (p[k].yt - ys) + c3 * (p[k].zt - zs);

                    double xp0 = -f * (xh / zh);
                    double yp0 = -f * (yh / zh);
                    l[0] = p[k].xp - x0 - xp0;
                    l[1] = p[k].yp - y0 - yp0;
                    b[0, 0] = (a1 * f + a3 * (p[k].xp - x0)) / zh;
                    b[0, 1] = (b1 * f + b3 * (p[k].xp - x0)) / zh;
                    b[0, 2] = (c1 * f + c3 * (p[k].xp - x0)) / zh;
                    b[1, 0] = (a2 * f + a3 * (p[k].yp - y0)) / zh;
                    b[1, 1] = (b2 * f + b3 * (p[k].yp - y0)) / zh;
                    b[1, 2] = (c2 * f + c3 * (p[k].yp - y0)) / zh;
                    b[0, 3] = (p[k].yp - y0) * Math.Sin(omg) - ((p[k].xp - x0) / f * ((p[k].xp - x0) * Math.Cos(kaf) - (p[k].yp - y0) * Math.Sin(kaf)) + f * Math.Cos(kaf)) * Math.Cos(omg);
                    b[0, 4] = -f * Math.Sin(kaf) - (p[k].xp - x0) / f * ((p[k].xp - x0) * Math.Sin(kaf) + (p[k].yp - y0) * Math.Cos(kaf));
                    b[0, 5] = (p[k].yp - y0);
                    b[1, 3] = -(p[k].xp - x0) * Math.Sin(omg) - ((p[k].yp - y0) / f * ((p[k].xp - x0) * Math.Cos(kaf) - (p[k].yp - y0) * Math.Sin(kaf)) - f * Math.Sin(kaf)) * Math.Cos(omg);
                    b[1, 4] = -f * Math.Cos(kaf) - (p[k].yp - y0) / f * ((p[k].xp - x0) * Math.Sin(kaf) + (p[k].yp - y0) * Math.Cos(kaf));
                    b[1, 5] = -(p[k].xp - x0);
                    n1 = mat1.MatMulti(mat1.MatTrans(b), b);
                    w1 = mat1.MatMulti(mat1.MatTrans(b), l);
                    n = mat1.MatAddTo(n1, n, 0, 0);
                    w = mat1.MatAddTo(w1, w, 0);
                }
                double[,] q = mat1.MatInver(n);
                x = mat1.MatMulti(q, w);
                dmax = mat1.MatMax(x);

                xs = xs + x[0]; ys = ys + x[1]; zs = zs + x[2];
                fiu = fiu + x[3]; omg = omg + x[4]; kaf = kaf + x[5];

            } while (dmax >= ee);
            ////精度评定

            

            double[] V = mat.MatZero(2);
            double[,] Qii = mat.MatZero(6,6);


            V = mat.MatMulti(b, x);

            double VTV = V[0] * V[0] + V[1] * V[1];

            m0 = Math.Sqrt(VTV / (2 * p.GetLength(0) - 2));

            Qii = mat.MatMulti(mat.MatTrans(b), b);

            mxs = m0 * Math.Sqrt(Qii[0, 0]);
            mys = m0 * Math.Sqrt(Qii[1, 1]);
            mzs = m0 * Math.Sqrt(Qii[2, 2]);
            mfiu = m0 * Math.Sqrt(Qii[3, 3]);
            momg = m0 * Math.Sqrt(Qii[4, 4]);
            mkaf = m0 * Math.Sqrt(Qii[5, 5]);

        }
    }
}

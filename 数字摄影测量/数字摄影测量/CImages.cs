using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数字摄影测量
{
    class CImages
    {
        //计算单点坐标近似值
        public void cal0(CImage image1, CImage image2, CPoints cps)
        {
            double a1, a2, a3, b1, b2, b3, c1, c2, c3;
            double d1, d2, d3, e1, e2, e3, f1, f2, f3;
            double u1, v1, w1;
            double u2, v2, w2;
            double bx, by, bz;
            double n1, n2;
            //左像点计算

            a1 = Math.Cos(image1.fiu) * Math.Cos(image1.kaf) - Math.Sin(image1.fiu) * Math.Sin(image1.omg) * Math.Sin(image1.kaf);
            a2 = -Math.Cos(image1.fiu) * Math.Sin(image1.kaf) - Math.Sin(image1.fiu) * Math.Sin(image1.omg) * Math.Cos(image1.kaf);
            a3 = -Math.Sin(image1.fiu) * Math.Cos(image1.omg);
            b1 = Math.Cos(image1.omg) * Math.Sin(image1.kaf);
            b2 = Math.Cos(image1.omg) * Math.Cos(image1.kaf);
            b3 = -Math.Sin(image1.omg);
            c1 = Math.Sin(image1.fiu) * Math.Cos(image1.kaf) + Math.Cos(image1.fiu) * Math.Sin(image1.omg) * Math.Sin(image1.kaf);
            c2 = -Math.Sin(image1.fiu) * Math.Sin(image1.kaf) + Math.Cos(image1.fiu) * Math.Sin(image1.omg) * Math.Cos(image1.kaf);
            c3 = Math.Cos(image1.fiu) * Math.Cos(image1.omg);

            u1 = a1 * (cps.x1 - image1.x0) + a2 * (cps.y1 - image1.y0) - a3 * image1.f;
            v1 = b1 * (cps.x1 - image1.x0) + b2 * (cps.y1 - image1.y0) - b3 * image1.f;
            w1 = c1 * (cps.x1 - image1.x0) + c2 * (cps.y1 - image1.y0) - c3 * image1.f;


            //右像点计算

            d1 = Math.Cos(image2.fiu) * Math.Cos(image2.kaf) - Math.Sin(image2.fiu) * Math.Sin(image2.omg) * Math.Sin(image2.kaf);
            d2 = -Math.Cos(image2.fiu) * Math.Sin(image2.kaf) - Math.Sin(image2.fiu) * Math.Sin(image2.omg) * Math.Cos(image2.kaf);
            d3 = -Math.Sin(image2.fiu) * Math.Cos(image2.omg);
            e1 = Math.Cos(image2.omg) * Math.Sin(image2.kaf);
            e2 = Math.Cos(image2.omg) * Math.Cos(image2.kaf);
            e3 = -Math.Sin(image2.omg);
            f1 = Math.Sin(image2.fiu) * Math.Cos(image2.kaf) + Math.Cos(image2.fiu) * Math.Sin(image2.omg) * Math.Sin(image2.kaf);
            f2 = -Math.Sin(image2.fiu) * Math.Sin(image2.kaf) + Math.Cos(image2.fiu) * Math.Sin(image2.omg) * Math.Cos(image2.kaf);
            f3 = Math.Cos(image2.fiu) * Math.Cos(image2.omg);

            u2 = d1 * (cps.x2 - image2.x0) + d2 * (cps.y2 - image2.y0) - d3 * image2.f;
            v2 = e1 * (cps.x2 - image2.x0) + e2 * (cps.y2 - image2.y0) - e3 * image2.f;
            w2 = f1 * (cps.x2 - image2.x0) + f2 * (cps.y2 - image2.y0) - f3 * image2.f;

            //坐标计算
            bx = image2.xs - image1.xs;
            by = image2.ys - image1.ys;
            bz = image2.zs - image1.zs;

            n1 = (bx * w2 - bz * u2) / (u1 * w2 - u2 * w1);
            n2 = (bx * w1 - bz * u1) / (u1 * w2 - u2 * w1);

            cps.xt = image1.xs + n1 * u1;
            cps.yt = ((image1.ys + n1 * v1) + (image2.ys + n2 * v2)) / 2;
            cps.zt = image1.zs + n1 * w1;

        }

        //计算多点坐标近似值
        public void cal0(CImage image1, CImage image2, CPoints[] cps)
        {
            int i, num;
            num = cps.GetLength(0);
            for (i = 0; i <= num - 1; i++)
            {
                cal0(image1, image2, cps[i]);
            }
        }

        //单点精确计算
        public void cal1(CImage image1, CImage image2, CPoints cps)
        {
            CMat mat = new CMat();
            //定义平差计算变量
            int i, j;
            double[,] b = mat.MatZero(4, 3);
            double[] l = mat.MatZero(4);
            double[,] n = mat.MatZero(3, 3);
            double[] w = mat.MatZero(3);
            double[,] q = mat.MatZero(3, 3);
            double[] x = mat.MatZero(3);

            double a1, a2, a3, b1, b2, b3, c1, c2, c3;
            double d1, d2, d3, e1, e2, e3, f1, f2, f3;
            double xh, yh, zh;
            double xp0, yp0;

            //左像点计算

            a1 = Math.Cos(image1.fiu) * Math.Cos(image1.kaf) - Math.Sin(image1.fiu) * Math.Sin(image1.omg) * Math.Sin(image1.kaf);
            a2 = -Math.Cos(image1.fiu) * Math.Sin(image1.kaf) - Math.Sin(image1.fiu) * Math.Sin(image1.omg) * Math.Cos(image1.kaf);
            a3 = -Math.Sin(image1.fiu) * Math.Cos(image1.omg);
            b1 = Math.Cos(image1.omg) * Math.Sin(image1.kaf);
            b2 = Math.Cos(image1.omg) * Math.Cos(image1.kaf);
            b3 = -Math.Sin(image1.omg);
            c1 = Math.Sin(image1.fiu) * Math.Cos(image1.kaf) + Math.Cos(image1.fiu) * Math.Sin(image1.omg) * Math.Sin(image1.kaf);
            c2 = -Math.Sin(image1.fiu) * Math.Sin(image1.kaf) + Math.Cos(image1.fiu) * Math.Sin(image1.omg) * Math.Cos(image1.kaf);
            c3 = Math.Cos(image1.fiu) * Math.Cos(image1.omg);

            xh = a1 * (cps.xt - image1.xs) + b1 * (cps.yt - image1.ys) + c1 * (cps.zt - image1.zs);
            yh = a2 * (cps.xt - image1.xs) + b2 * (cps.yt - image1.ys) + c2 * (cps.zt - image1.zs);
            zh = a3 * (cps.xt - image1.xs) + b3 * (cps.yt - image1.ys) + c3 * (cps.zt - image1.zs);

            xp0 = -image1.f * (xh / zh);
            yp0 = -image1.f * (yh / zh);
            
            l[0] = cps.x1 - image1.x0 - xp0;
            l[1] = cps.y1 - image1.y0 - yp0;

            b[0, 0] = -(a1 * image1.f + a3 * (cps.x1 - image1.x0)) / zh;
            b[0, 1] = -(b1 * image1.f + b3 * (cps.x1 - image1.x0)) / zh;
            b[0, 2] = -(c1 * image1.f + c3 * (cps.x1 - image1.x0)) / zh;

            b[1, 0] = -(a2 * image1.f + a3 * (cps.y1 - image1.y0)) / zh;
            b[1, 1] = -(b2 * image1.f + b3 * (cps.y1 - image1.y0)) / zh;
            b[1, 2] = -(c2 * image1.f + c3 * (cps.y1 - image1.y0)) / zh;


            //右像点计算

            d1 = Math.Cos(image2.fiu) * Math.Cos(image2.kaf) - Math.Sin(image2.fiu) * Math.Sin(image2.omg) * Math.Sin(image2.kaf);
            d2 = -Math.Cos(image2.fiu) * Math.Sin(image2.kaf) - Math.Sin(image2.fiu) * Math.Sin(image2.omg) * Math.Cos(image2.kaf);
            d3 = -Math.Sin(image2.fiu) * Math.Cos(image2.omg);
            e1 = Math.Cos(image2.omg) * Math.Sin(image2.kaf);
            e2 = Math.Cos(image2.omg) * Math.Cos(image2.kaf);
            e3 = -Math.Sin(image2.omg);
            f1 = Math.Sin(image2.fiu) * Math.Cos(image2.kaf) + Math.Cos(image2.fiu) * Math.Sin(image2.omg) * Math.Sin(image2.kaf);
            f2 = -Math.Sin(image2.fiu) * Math.Sin(image2.kaf) + Math.Cos(image2.fiu) * Math.Sin(image2.omg) * Math.Cos(image2.kaf);
            f3 = Math.Cos(image2.fiu) * Math.Cos(image2.omg);

            xh = d1 * (cps.xt - image2.xs) + e1 * (cps.yt - image2.ys) + f1 * (cps.zt - image2.zs);
            yh = d2 * (cps.xt - image2.xs) + e2 * (cps.yt - image2.ys) + f2 * (cps.zt - image2.zs);
            zh = d3 * (cps.xt - image2.xs) + e3 * (cps.yt - image2.ys) + f3 * (cps.zt - image2.zs);

            xp0 = -image2.f * (xh / zh);
            yp0 = -image2.f * (yh / zh);
            l[2] = cps.x2 - image2.x0 - xp0;
            l[3] = cps.y2 - image2.y0 - yp0;

            b[2, 0] = -(d1 * image2.f + d3 * (cps.x2 - image2.x0)) / zh;
            b[2, 1] = -(e1 * image2.f + e3 * (cps.x2 - image2.x0)) / zh;
            b[2, 2] = -(f1 * image2.f + f3 * (cps.x2 - image2.x0)) / zh;

            b[3, 0] = -(d2 * image2.f + d3 * (cps.y2 - image2.y0)) / zh;
            b[3, 1] = -(e2 * image2.f + e3 * (cps.y2 - image2.y0)) / zh;
            b[3, 2] = -(f2 * image2.f + f3 * (cps.y2 - image2.y0)) / zh;

            //建立法方程
            n = mat.MatMulti(mat.MatTrans(b), b);
            w = mat.MatMulti(mat.MatTrans(b), l);
            // //求逆
            q = mat.MatInver(n);

            //求未知数
            x = mat.MatMulti(q, w);
            cps.xt = cps.xt + x[0];
            cps.yt = cps.yt + x[1];
            cps.zt = cps.zt + x[2];

            //误差
            double[] v = new double[4];
            double vv, m0;
            for (i = 0; i <= 3; i++)
            {
                v[i] = -l[i];
            }
            vv = 0;
            double[] bx = mat.MatMulti(b, x);

            for (i = 0; i <= 3; i++)
            {
                for (j = 0; j <= 2; j++)
                {
                    v[i] = v[i] + bx[i];
                }
            }
            for (i = 0; i <= 3; i++)
            {
                vv = vv + v[i] * v[i];
            }
            //
            m0 = Math.Sqrt(vv);
            cps.mx = m0 * Math.Sqrt(q[0, 0]);
            cps.my = m0 * Math.Sqrt(q[1, 1]);
            cps.mz = m0 * Math.Sqrt(q[2, 2]);
        }

        //多点情况下单点精确计算
        public void cal1(CImage image1, CImage image2, CPoints[] cps)
        {
            int i, num;
            num = cps.GetLength(0);
            for (i = 0; i <= num - 1; i++)
            {
                cal1(image1, image2, cps[i]);
            }
        }

        //连续像对相对定向
        public void ConRelRor(CImage image1, CImage image2, CPoints[] cps)
        { }

        //独立像对相对定向
        public void IndRelRor(CImage image1, CImage image2, CPoints[] cps)
        { }

    }
}

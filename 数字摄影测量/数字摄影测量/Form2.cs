using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 数字摄影测量
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 解析法
        /// </summary>
        private ArrayList list = new ArrayList();
        double f, x0, y0, m;
        double xs1, ys1, zs1, fiu1, omg1, kaf1;
        double xs2, ys2, zs2, fiu2, omg2, kaf2;
        double u1, v1, w1, u2, v2, w2;
        double a1, a2, a3, b1, b2, b3, c1, c2, c3;
        double d1, d2, d3, e1, e2, e3, f1, f2, f3;
        double n1, n2;
        double bu, bv, bw, u, v;


        /// <summary>
        /// 交会法
        /// </summary>
        ArrayList list1 = new ArrayList();

        CPoint[] p_left = null;
        CImage image_left = new CImage();

        CPoint[] p_right = null;
        CImage image_right = new CImage();

        CPoints[] points = null;
        CImages images = new CImages();



        //打开左
        private void button1_Click(object sender, EventArgs e)
        {
            list1.Clear();

            string path = Application.StartupPath + "\\空间后方交会控制点文件lift.txt";
            StreamReader sr = new StreamReader(path);
            String line = null;
            do
            {
                line = sr.ReadLine();
                if (line == null)
                { break; }
                list1.Add(line);
            } while (line != null);
            sr.Close();

            p_left = new CPoint[list1.Count - 1];
            int i;
            line = (list1[0]).ToString();
            string[] splits = line.Split(',');
            image_left.f = Convert.ToDouble(splits[0]);
            image_left.x0 = Convert.ToDouble(splits[1]);
            image_left.y0 = Convert.ToDouble(splits[2]);
            image_left.m = Convert.ToDouble(splits[3]);
            for (i = 1; i < list1.Count; i++)
            {
                line = (list1[i]).ToString();
                splits = line.Split(',');
                p_left[i - 1] = new CPoint();
                p_left[i - 1].id = Convert.ToInt16(splits[0]);
                p_left[i - 1].xp = Convert.ToDouble(splits[1]);
                p_left[i - 1].yp = Convert.ToDouble(splits[2]);
                p_left[i - 1].xt = Convert.ToDouble(splits[3]);
                p_left[i - 1].yt = Convert.ToDouble(splits[4]);
                p_left[i - 1].zt = Convert.ToDouble(splits[5]);
            }
            MessageBox.Show("左像片控制点文件已经读入！", "数据读取进程提示", MessageBoxButtons.OK);
        }
        
        //计算左
        private void button_cal_left_Click(object sender, EventArgs e)
        {
            image_left.ImageCal6(0.000001, p_left);
        }

        //打开右
        private void button_open_right_Click(object sender, EventArgs e)
        {
            list1.Clear();

            string path = Application.StartupPath + "\\空间后方交会控制点文件right.txt";
            StreamReader sr = new StreamReader(path);
            String line = null;
            do
            {
                line = sr.ReadLine();
                if (line == null)
                { break; }
                list1.Add(line);
            } while (line != null);
            sr.Close();

            
            p_right = new CPoint[list1.Count - 1];
            int i;
            line = (list1[0]).ToString();
            string[] splits = line.Split(',');
            image_right.f = Convert.ToDouble(splits[0]);
            image_right.x0 = Convert.ToDouble(splits[1]);
            image_right.y0 = Convert.ToDouble(splits[2]);
            image_right.m = Convert.ToDouble(splits[3]);
            for (i = 1; i < list1.Count; i++)
            {
                line = (list1[i]).ToString();
                splits = line.Split(',');
                p_right[i - 1] = new CPoint();
                p_right[i - 1].id = Convert.ToInt16(splits[0]);
                p_right[i - 1].xp = Convert.ToDouble(splits[1]);
                p_right[i - 1].yp = Convert.ToDouble(splits[2]);
                p_right[i - 1].xt = Convert.ToDouble(splits[3]);
                p_right[i - 1].yt = Convert.ToDouble(splits[4]);
                p_right[i - 1].zt = Convert.ToDouble(splits[5]);
            }

            DialogResult dialogResult = MessageBox.Show("右像片控制点文件已经读入！", "数据读取进程提示", MessageBoxButtons.OK);
        }

        //计算右
        private void button1_Click_1(object sender, EventArgs e)
        {
            image_right.ImageCal6(0.000001, p_right);
        }

        //打开同名像点
        private void button_open_Click(object sender, EventArgs e)
        {
            list1.Clear();

            string path = Application.StartupPath + "\\同名像点坐标.txt";
            StreamReader sr = new StreamReader(path);
            String line = null;
            do
            {
                line = sr.ReadLine();
                if (line == null)
                { break; }
                list1.Add(line);
            } while (line != null);
            sr.Close();

            points = new CPoints[list1.Count - 1];
            int i;
            string[] splits;

            for (i = 1; i < list1.Count; i++)
            {
                line = (list1[i]).ToString();
                splits = line.Split(',');
                points[i - 1] = new CPoints
                {
                    id = Convert.ToInt16(splits[0]),

                    x1 = Convert.ToDouble(splits[1]),
                    y1 = Convert.ToDouble(splits[2]),

                    x2 = Convert.ToDouble(splits[3]),
                    y2 = Convert.ToDouble(splits[4])
                };
            }
        }

        private void button_cal1_Click(object sender, EventArgs e)
        {
            images.cal0(image_left, image_right, points);
        }

        private void button_cal2_Click(object sender, EventArgs e)
        {
            images.cal1(image_left, image_right, points);
        }

        //连续像对法
        private void button_cal3_Click(object sender, EventArgs e)
        {
            //

            int num = list.Count;
            CMat mat = new CMat();

            points = new CPoints[num];
            string line;
            string[] splits;
            int[] id = new int[num];
            double[] xp1 = new double[num];
            double[] yp1 = new double[num];
            double[] xp2 = new double[num];
            double[] yp2 = new double[num];
            double[] xm = new double[num];
            double[] ym = new double[num];
            double[] zm = new double[num];
            int i, j, k;
            for (i = 0; i <= num - 1; i++)
            {
                line = Convert.ToString(list[i]);
                splits = line.Split(',');
                id[i] = Convert.ToInt16(splits[0]);
                xp1[i] = Convert.ToDouble(splits[1]);
                yp1[i] = Convert.ToDouble(splits[2]);
                xp2[i] = Convert.ToDouble(splits[3]);
                yp2[i] = Convert.ToDouble(splits[4]);
            }

            xs1 = ys1 = zs1 = fiu1 = omg1 = kaf1 = 0;
            a1 = Math.Cos(fiu1) * Math.Cos(kaf1) - Math.Sin(fiu1) * Math.Sin(omg1) * Math.Sin(kaf1);
            a2 = -Math.Cos(fiu1) * Math.Sin(kaf1) - Math.Sin(fiu1) * Math.Sin(omg1) * Math.Cos(kaf1);
            a3 = -Math.Sin(fiu1) * Math.Cos(omg1);
            b1 = Math.Cos(omg1) * Math.Sin(kaf1);
            b2 = Math.Cos(omg1) * Math.Cos(kaf1);
            b3 = -Math.Sin(omg1);
            c1 = Math.Sin(fiu1) * Math.Cos(kaf1) + Math.Cos(fiu1) * Math.Sin(omg1) * Math.Sin(kaf1);
            c2 = -Math.Sin(fiu1) * Math.Sin(kaf1) + Math.Cos(fiu1) * Math.Sin(omg1) * Math.Cos(kaf1);
            c3 = Math.Cos(fiu1) * Math.Cos(omg1);
            xs2 = bu;

            ys2 = zs2 = fiu2 = omg2 = kaf2 = 0;
            u = v = 0;
            double[] b = new double[5];
            double l;
            double[,] n = new double[5, 5];
            double[] w = new double[5];
            double[,] q = new double[5, 5];
            double[] x = new double[5];
            double x1, y1, x2, y2;
        loop1:

            for (i = 0; i <= 4; i++) //法方程式系数和常数项置零
            {
                for (j = 0; j <= 4; j++)
                {
                    n[i, j] = 0;
                }
                w[i] = 0;
                x[i] = 0;
            }

            d1 = Math.Cos(fiu2) * Math.Cos(kaf2) - Math.Sin(fiu2) * Math.Sin(omg2) * Math.Sin(kaf2);
            d2 = -Math.Cos(fiu2) * Math.Sin(kaf2) - Math.Sin(fiu2) * Math.Sin(omg2) * Math.Cos(kaf2);
            d3 = -Math.Sin(fiu2) * Math.Cos(omg2);
            e1 = Math.Cos(omg2) * Math.Sin(kaf2);
            e2 = Math.Cos(omg2) * Math.Cos(kaf2);
            e3 = -Math.Sin(omg2);
            f1 = Math.Sin(fiu2) * Math.Cos(kaf2) + Math.Cos(fiu2) * Math.Sin(omg2) * Math.Sin(kaf2);
            f2 = -Math.Sin(fiu2) * Math.Sin(kaf2) + Math.Cos(fiu2) * Math.Sin(omg2) * Math.Cos(kaf2);
            f3 = Math.Cos(fiu2) * Math.Cos(omg2);
            bv = bu * u;
            bw = bu * v;

            // 逐点建立误差法方程式			
            for (k = 0; k <= 5; k++)
            {
                for (i = 0; i <= 4; i++)  //各点的误差方程式系数和常数项置零
                {
                    b[i] = 0;
                }
                l = 0;
                x1 = xp1[k];
                y1 = yp1[k];
                x2 = xp2[k];
                y2 = yp2[k];

                u1 = a1 * (x1 - x0) + a2 * (y1 - y0) - a3 * f;
                v1 = b1 * (x1 - x0) + b2 * (y1 - y0) - b3 * f;
                w1 = c1 * (x1 - x0) + c2 * (y1 - y0) - c3 * f;

                u2 = d1 * (x2 - x0) + d2 * (y2 - y0) - d3 * f;
                v2 = e1 * (x2 - x0) + e2 * (y2 - y0) - e3 * f;
                w2 = f1 * (x2 - x0) + f2 * (y2 - y0) - f3 * f;

                n1 = (bu * w2 - bw * u2) / (u1 * w2 - u2 * w1);
                n2 = (bu * w1 - bw * u1) / (u1 * w2 - u2 * w1);

                b[0] = bu;
                b[1] = -v2 / w2 * bu;
                b[2] = -u2 * v2 / w2 * n2;
                b[3] = -(w2 + v2 * v2 / w2) * n2;
                b[4] = u2 * n2;
                l = n1 * v1 - n2 * v2 - bv;

                //逐点建立法方程式
                for (i = 0; i <= 4; i++)
                {
                    for (j = 0; j <= 4; j++)
                    {
                        n[i, j] = n[i, j] + b[i] * b[j];
                    }
                }
                for (i = 0; i <= 4; i++)
                {
                    w[i] = w[i] + b[i] * l;
                }
            }

            // //求逆
            q = inv(5, n);
            //求未知数
            for (i = 0; i <= 4; i++)
            {
                for (j = 0; j <= 4; j++)
                {
                    x[i] = x[i] + q[i, j] * w[j];
                }
            }

            u = u + x[0];
            v = v + x[1];
            fiu2 = fiu2 + x[2];
            omg2 = omg2 + x[3];
            kaf2 = kaf2 + x[4];


            double max = Math.Abs(x[0]);
            for (i = 1; i <= 4; i++)
            {
                if (Math.Abs(x[i]) >= max)
                {
                    max = Math.Abs(x[i]);
                }
            }

            if (max >= Convert.ToDouble(0.000001))
            {
                goto loop1;
            }

            //模型点坐标计算
            d1 = Math.Cos(fiu2) * Math.Cos(kaf2) - Math.Sin(fiu2) * Math.Sin(omg2) * Math.Sin(kaf2);
            d2 = -Math.Cos(fiu2) * Math.Sin(kaf2) - Math.Sin(fiu2) * Math.Sin(omg2) * Math.Cos(kaf2);
            d3 = -Math.Sin(fiu2) * Math.Cos(omg2);
            e1 = Math.Cos(omg2) * Math.Sin(kaf2);
            e2 = Math.Cos(omg2) * Math.Cos(kaf2);
            e3 = -Math.Sin(omg2);
            f1 = Math.Sin(fiu2) * Math.Cos(kaf2) + Math.Cos(fiu2) * Math.Sin(omg2) * Math.Sin(kaf2);
            f2 = -Math.Sin(fiu2) * Math.Sin(kaf2) + Math.Cos(fiu2) * Math.Sin(omg2) * Math.Cos(kaf2);
            f3 = Math.Cos(fiu2) * Math.Cos(omg2);
            bv = bu * u;
            bw = bu * v;
            xs2 = xs1 + bu;
            ys2 = ys1 + bv;
            zs2 = zs1 + bw;

            for (k = 0; k <= num - 1; k++)
            {
                x1 = xp1[k];
                y1 = yp1[k];
                x2 = xp2[k];
                y2 = yp2[k];

                u1 = a1 * (x1 - x0) + a2 * (y1 - y0) - a3 * f;
                v1 = b1 * (x1 - x0) + b2 * (y1 - y0) - b3 * f;
                w1 = c1 * (x1 - x0) + c2 * (y1 - y0) - c3 * f;

                u2 = d1 * (x2 - x0) + d2 * (y2 - y0) - d3 * f;
                v2 = e1 * (x2 - x0) + e2 * (y2 - y0) - e3 * f;
                w2 = f1 * (x2 - x0) + f2 * (y2 - y0) - f3 * f;

                n1 = (bu * w2 - bw * u2) / (u1 * w2 - u2 * w1);
                n2 = (bu * w1 - bw * u1) / (u1 * w2 - u2 * w1);

                xm[k] = xs1 + n1 * u1;
                ym[k] = ((ys1 + n1 * v1) + (ys2 + n2 * v2)) / 2;
                zm[k] = zs1 + n1 * w1;

                xm[k] = xm[k] * m / 1000;
                ym[k] = ym[k] * m / 1000;
                zm[k] = zm[k] * m / 1000;

            }
            bu = bu * m / 1000;
            bv = bv * m / 1000;
            bw = bw * m / 1000;
            xs2 = xs2 * m / 1000;
            ys2 = ys2 * m / 1000;
            zs2 = zs2 * m / 1000;


            string path = Application.StartupPath + "\\连续像对法相对定向模型点坐标文件.txt";
            StreamWriter sw = File.CreateText(path);
            sw.WriteLine(xs1.ToString() + "," + ys1.ToString() + "," + zs1.ToString() + "," + fiu1.ToString() + "," + omg1.ToString() + "," + kaf1.ToString());
            sw.WriteLine(xs2.ToString() + "," + ys2.ToString() + "," + zs2.ToString() + "," + fiu2.ToString() + "," + omg2.ToString() + "," + kaf2.ToString());
            for (i = 0; i <= num - 1; i++)
            {
                sw.WriteLine(id[i] + "," + xm[i].ToString() + "," + ym[i].ToString() + "," + zm[i].ToString());

            }
            sw.Close();
            MessageBox.Show("连续像对法相对定向计算结束，数据已保存！", "数据保存进程提示", MessageBoxButtons.OK);
        }

        //读取相对定向坐标点文件
        private void button_open_2_Click(object sender, EventArgs e)
        {

        }

        //独立相对法
        private void button_cal4_Click(object sender, EventArgs e)
        {


            //
            int num = list.Count;
            string line;
            string[] splits = null;
            int[] id = new int[num];
            double[] xp1 = new double[num];
            double[] yp1 = new double[num];
            double[] xp2 = new double[num];
            double[] yp2 = new double[num];
            double[] xm = new double[num];
            double[] ym = new double[num];
            double[] zm = new double[num];
            int i, j, k;
            for (i = 0; i <= num - 1; i++)
            {
                line = Convert.ToString(list[i]);
                splits = line.Split(',');
                id[i] = Convert.ToInt16(splits[0]);
                xp1[i] = Convert.ToDouble(splits[1]);
                yp1[i] = Convert.ToDouble(splits[2]);
                xp2[i] = Convert.ToDouble(splits[3]);
                yp2[i] = Convert.ToDouble(splits[4]);
            }

            xs1 = ys1 = zs1 = fiu1 = omg1 = kaf1 = 0;
            xs2 = bu;
            ys2 = zs2 = fiu2 = omg2 = kaf2 = 0;
            u = v = 0;
            bv = bu * u;
            bw = bu * v;


            double[] b = new double[5];
            double l;
            double[,] n = new double[5, 5];
            double[] w = new double[5];
            double[,] q = new double[5, 5];
            double[] x = new double[5];
            double x1, y1, x2, y2;
        loop1:

            for (i = 0; i <= 4; i++) //法方程式系数和常数项置零
            {
                for (j = 0; j <= 4; j++)
                {
                    n[i, j] = 0;
                }
                w[i] = 0;
                x[i] = 0;
            }

            a1 = Math.Cos(fiu1) * Math.Cos(kaf1) - Math.Sin(fiu1) * Math.Sin(omg1) * Math.Sin(kaf1);
            a2 = -Math.Cos(fiu1) * Math.Sin(kaf1) - Math.Sin(fiu1) * Math.Sin(omg1) * Math.Cos(kaf1);
            a3 = -Math.Sin(fiu1) * Math.Cos(omg1);
            b1 = Math.Cos(omg1) * Math.Sin(kaf1);
            b2 = Math.Cos(omg1) * Math.Cos(kaf1);
            b3 = -Math.Sin(omg1);
            c1 = Math.Sin(fiu1) * Math.Cos(kaf1) + Math.Cos(fiu1) * Math.Sin(omg1) * Math.Sin(kaf1);
            c2 = -Math.Sin(fiu1) * Math.Sin(kaf1) + Math.Cos(fiu1) * Math.Sin(omg1) * Math.Cos(kaf1);
            c3 = Math.Cos(fiu1) * Math.Cos(omg1);

            d1 = Math.Cos(fiu2) * Math.Cos(kaf2) - Math.Sin(fiu2) * Math.Sin(omg2) * Math.Sin(kaf2);
            d2 = -Math.Cos(fiu2) * Math.Sin(kaf2) - Math.Sin(fiu2) * Math.Sin(omg2) * Math.Cos(kaf2);
            d3 = -Math.Sin(fiu2) * Math.Cos(omg2);
            e1 = Math.Cos(omg2) * Math.Sin(kaf2);
            e2 = Math.Cos(omg2) * Math.Cos(kaf2);
            e3 = -Math.Sin(omg2);
            f1 = Math.Sin(fiu2) * Math.Cos(kaf2) + Math.Cos(fiu2) * Math.Sin(omg2) * Math.Sin(kaf2);
            f2 = -Math.Sin(fiu2) * Math.Sin(kaf2) + Math.Cos(fiu2) * Math.Sin(omg2) * Math.Cos(kaf2);
            f3 = Math.Cos(fiu2) * Math.Cos(omg2);

            // 逐点建立误差法方程式			
            for (k = 0; k <= 5; k++)
            {
                for (i = 0; i <= 4; i++)  //各点的误差方程式系数和常数项置零
                {
                    b[i] = 0;
                }
                l = 0;
                x1 = xp1[k];
                y1 = yp1[k];
                x2 = xp2[k];
                y2 = yp2[k];

                u1 = a1 * (x1 - x0) + a2 * (y1 - y0) - a3 * f;
                v1 = b1 * (x1 - x0) + b2 * (y1 - y0) - b3 * f;
                w1 = c1 * (x1 - x0) + c2 * (y1 - y0) - c3 * f;

                u2 = d1 * (x2 - x0) + d2 * (y2 - y0) - d3 * f;
                v2 = e1 * (x2 - x0) + e2 * (y2 - y0) - e3 * f;
                w2 = f1 * (x2 - x0) + f2 * (y2 - y0) - f3 * f;

                //n1 = (bu * w2 - bw * u2) / (u1 * w2 - u2 * w1);
                //n2 = (bu * w1 - bw * u1) / (u1 * w2 - u2 * w1);

                b[0] = u1 * v2 / w2;
                b[1] = -u2 * v1 / w1;
                b[2] = f * (1 + v1 * v2 / w1 / w2);
                //b[3] = u1 / w1;
                //b[4] = -u2 / w2;
                b[3] = f * u1 / w1;
                b[4] = -f * u2 / w2;
                l = -f * v1 / w1 + f * v2 / w2;

                //逐点建立法方程式
                for (i = 0; i <= 4; i++)
                {
                    for (j = 0; j <= 4; j++)
                    {
                        n[i, j] = n[i, j] + b[i] * b[j];
                    }
                }
                for (i = 0; i <= 4; i++)
                {
                    w[i] = w[i] + b[i] * l;
                }
            }

            // //求逆
            q = inv(5, n);

            //求未知数
            for (i = 0; i <= 4; i++)
            {
                for (j = 0; j <= 4; j++)
                {
                    x[i] = x[i] + q[i, j] * w[j];
                }
            }

            fiu1 = fiu1 + x[0];
            fiu2 = fiu2 + x[1];
            omg2 = omg2 + x[2];
            kaf1 = kaf1 + x[3];
            kaf2 = kaf2 + x[4];

            double max = Math.Abs(x[0]);
            for (i = 1; i <= 4; i++)
            {
                if (Math.Abs(x[i]) >= max)
                {
                    max = Math.Abs(x[i]);
                }
            }

            if (max >= Convert.ToDouble(0.000001))
            {
                goto loop1;
            }

            a1 = Math.Cos(fiu1) * Math.Cos(kaf1) - Math.Sin(fiu1) * Math.Sin(omg1) * Math.Sin(kaf1);
            a2 = -Math.Cos(fiu1) * Math.Sin(kaf1) - Math.Sin(fiu1) * Math.Sin(omg1) * Math.Cos(kaf1);
            a3 = -Math.Sin(fiu1) * Math.Cos(omg1);
            b1 = Math.Cos(omg1) * Math.Sin(kaf1);
            b2 = Math.Cos(omg1) * Math.Cos(kaf1);
            b3 = -Math.Sin(omg1);
            c1 = Math.Sin(fiu1) * Math.Cos(kaf1) + Math.Cos(fiu1) * Math.Sin(omg1) * Math.Sin(kaf1);
            c2 = -Math.Sin(fiu1) * Math.Sin(kaf1) + Math.Cos(fiu1) * Math.Sin(omg1) * Math.Cos(kaf1);
            c3 = Math.Cos(fiu1) * Math.Cos(omg1);

            d1 = Math.Cos(fiu2) * Math.Cos(kaf2) - Math.Sin(fiu2) * Math.Sin(omg2) * Math.Sin(kaf2);
            d2 = -Math.Cos(fiu2) * Math.Sin(kaf2) - Math.Sin(fiu2) * Math.Sin(omg2) * Math.Cos(kaf2);
            d3 = -Math.Sin(fiu2) * Math.Cos(omg2);
            e1 = Math.Cos(omg2) * Math.Sin(kaf2);
            e2 = Math.Cos(omg2) * Math.Cos(kaf2);
            e3 = -Math.Sin(omg2);
            f1 = Math.Sin(fiu2) * Math.Cos(kaf2) + Math.Cos(fiu2) * Math.Sin(omg2) * Math.Sin(kaf2);
            f2 = -Math.Sin(fiu2) * Math.Sin(kaf2) + Math.Cos(fiu2) * Math.Sin(omg2) * Math.Cos(kaf2);
            f3 = Math.Cos(fiu2) * Math.Cos(omg2);

            xs2 = xs1 + bu;
            ys2 = ys1 + bv;
            zs2 = zs1 + bw;

            for (k = 0; k <= num - 1; k++)
            {
                x1 = xp1[k];
                y1 = yp1[k];
                x2 = xp2[k];
                y2 = yp2[k];

                u1 = a1 * (x1 - x0) + a2 * (y1 - y0) - a3 * f;
                v1 = b1 * (x1 - x0) + b2 * (y1 - y0) - b3 * f;
                w1 = c1 * (x1 - x0) + c2 * (y1 - y0) - c3 * f;

                u2 = d1 * (x2 - x0) + d2 * (y2 - y0) - d3 * f;
                v2 = e1 * (x2 - x0) + e2 * (y2 - y0) - e3 * f;
                w2 = f1 * (x2 - x0) + f2 * (y2 - y0) - f3 * f;

                n1 = (bu * w2 - bw * u2) / (u1 * w2 - u2 * w1);
                n2 = (bu * w1 - bw * u1) / (u1 * w2 - u2 * w1);

                xm[k] = xs1 + n1 * u1;
                ym[k] = ((ys1 + n1 * v1) + (ys2 + n2 * v2)) / 2;
                zm[k] = zs1 + n1 * w1;

                xm[k] = xm[k] * m / 1000;
                ym[k] = ym[k] * m / 1000;
                zm[k] = zm[k] * m / 1000;

            }
            bu = bu * m / 1000;
            bv = bv * m / 1000;
            bw = bw * m / 1000;
            xs2 = xs2 * m / 1000;
            ys2 = ys2 * m / 1000;
            zs2 = zs2 * m / 1000;

            string path = Application.StartupPath + "\\独立像对法相对定向模型点坐标文件.txt";
            StreamWriter sw = File.CreateText(path);
            sw.WriteLine(xs1.ToString() + "," + ys1.ToString() + "," + zs1.ToString() + "," + fiu1.ToString() + "," + omg1.ToString() + "," + kaf1.ToString());
            sw.WriteLine(xs2.ToString() + "," + ys2.ToString() + "," + zs2.ToString() + "," + fiu2.ToString() + "," + omg2.ToString() + "," + kaf2.ToString());
            for (i = 0; i <= num - 1; i++)
            {
                sw.WriteLine(id[i] + "," + xm[i].ToString() + "," + ym[i].ToString() + "," + zm[i].ToString());
            }
            sw.Close();
            MessageBox.Show("独立像对法相对定向计算结束，数据已保存！", "数据保存进程提示", MessageBoxButtons.OK);
        }

    }
}

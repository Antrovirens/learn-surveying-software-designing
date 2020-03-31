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

namespace 期末考试
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //变量
        Form2 SubForm;
        Form3 TextFrom;
        ArrayList list = new ArrayList();  //
        public ArrayList Resultlist = new ArrayList();  //

        public double a, b, r, a0, b0, r0;  //平差值和近似值
        public double da, db, dr;  //dx

        double tx0, ty0, tx1, ty1;
        double PlotScale = 1.0;//比例尺

        double[,] MatB;
        double[,] Matl;
        double[,] MatQxx = new double[3, 3];  //Qxx协因数阵
        double[,] MatDxx = new double[3, 3];//未知数方差阵
        double[,] Matx = new double[3, 1];  // x改正数
        double[,] MatV;  //平差值
        double D0; //单位权中误差
        public bool Fitted = false;

        struct Triangle //三角形结构体
        {
            public int n1, n2, n3;  //三个顶点的序号
            public double Area;     //三角形面积
        };

        Triangle[] triangles;  //三角形数组
        Point[] points = new Point[3];  //保存最大三角形的值

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            GC.Collect();
            SubForm = new Form2
            {
                TopLevel = false,
                Dock = DockStyle.None
            };

            this.panel.Controls.Add(SubForm);
            SubForm.Show();

            ReadFile();
            double[] m = new double[list.Count];

            if (list.Count == 0)
                return;

            string line;
            string[] splits;
            int n = list.Count;
            for (int i = 0; i < n; i++)
            {
                line = System.Convert.ToString(list[i]);
                splits = line.Split(',');

                int index = SubForm.dataGridView1.Rows.Add();
                SubForm.dataGridView1.Rows[index].Cells[0].Value = splits[0];
                SubForm.dataGridView1.Rows[index].Cells[1].Value = splits[1];
                SubForm.dataGridView1.Rows[index].Cells[2].Value = splits[2];
            }

            DotsPaint();
        }

        private void 拟合ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextFrom = new Form3
            {
                TopLevel = false,
                Dock = DockStyle.None,
            };
            //do
            //{
            //    FitCircle();
            //    a0 = a;
            //    b0 = b;
            //    r0 = r;
            //} while (D0 > 1);
            FitCircle();

            PaintCircle();

            ExecResult();

            this.panel.Controls.Add(TextFrom);//展示结果
            int n = Resultlist.Count;
            int i = 0;
            while (i < n)
                TextFrom.textBox1.AppendText(Resultlist[i++] + Environment.NewLine);
            SubForm.TopMost = false;
            TextFrom.TopMost = true;
            TextFrom.Show();
        }

        private void 导出DXFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.Filter = "DXF文档|*.DXF";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                String path = ofd.FileName;
                using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
                {
                    sw.WriteLine("0");  // 开始组码
                    sw.WriteLine("SECTION");  // 与后面的ENDSEC对应
                    sw.WriteLine("2");
                    sw.WriteLine("HEADER");
                    sw.WriteLine("0");
                    sw.WriteLine("ENDSEC");
                    for (int i = 0; i < SubForm.dataGridView1.Rows.Count - 1; i++)
                    {
                        sw.WriteLine("0");
                        sw.WriteLine("SECTION");
                        sw.WriteLine("2");
                        sw.WriteLine("ENTITIES");
                        sw.WriteLine("0");
                        sw.WriteLine("POINT");
                        sw.WriteLine("100");
                        sw.WriteLine("AcDbEntity");
                        sw.WriteLine("8");
                        sw.WriteLine("0");
                        sw.WriteLine("100");
                        sw.WriteLine("AcDbPoint");
                        sw.WriteLine("10");  // 起点X坐标
                        sw.WriteLine(System.Convert.ToDouble(SubForm.dataGridView1.Rows[i].Cells[1].Value));
                        sw.WriteLine("20");  // 起点Y坐标
                        sw.WriteLine(System.Convert.ToDouble(SubForm.dataGridView1.Rows[i].Cells[2].Value));
                        sw.WriteLine("0");
                        sw.WriteLine("ENDSEC");  // 对应SECTION
                    }
                    //圆心
                    sw.WriteLine("0");
                    sw.WriteLine("SECTION");
                    sw.WriteLine("2");
                    sw.WriteLine("ENTITIES");
                    sw.WriteLine("0");
                    sw.WriteLine("POINT");
                    sw.WriteLine("100");
                    sw.WriteLine("AcDbEntity");
                    sw.WriteLine("8");
                    sw.WriteLine("0");
                    sw.WriteLine("100");
                    sw.WriteLine("AcDbPoint");
                    sw.WriteLine("10");  // 起点X坐标
                    sw.WriteLine(a);
                    sw.WriteLine("20");  // 起点Y坐标
                    sw.WriteLine(b);
                    sw.WriteLine("0");
                    sw.WriteLine("ENDSEC");  // 对应SECTION
                    //circle
                    sw.WriteLine("0");
                    sw.WriteLine("SECTION");
                    sw.WriteLine("2"); //名称
                    sw.WriteLine("ENTITIES"); 
                    sw.WriteLine("0");
                    sw.WriteLine("CIRCLE");
                    sw.WriteLine("100");
                    sw.WriteLine("AcDbEntity");
                    sw.WriteLine("8"); //图层名
                    sw.WriteLine("0");
                    sw.WriteLine("6"); //线形
                    sw.WriteLine("Continuous");
                    sw.WriteLine("100");
                    sw.WriteLine("AcDbCircle");
                    sw.WriteLine("10");  //圆心X坐标
                    sw.WriteLine(a);
                    sw.WriteLine("20");  //圆心Y坐标
                    sw.WriteLine(b);
                    sw.WriteLine("30");  //圆心X坐标
                    sw.WriteLine(0.0);
                    sw.WriteLine("40");  //圆心Y坐标
                    sw.WriteLine(r);
                    sw.WriteLine("0");
                    sw.WriteLine("ENDSEC");  // 对应SECTION
                    //画圆结束
                    sw.WriteLine("0");
                    sw.WriteLine("EOF");  // 文件结束
                    sw.Close();  // 关闭文件流
                }
            }
            MessageBox.Show("保存成功", "进程提示");
        }

        private void 刷新图形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Point[] group1 = new Point[200];
            //int n = SubForm.dataGridView1.Rows.Count - 1;
            //Graphics g = CreateGraphics();

            //double x0 = Convert.ToDouble(SubForm.dataGridView1.Rows[0].Cells[1].Value);  // x min
            //double y0 = Convert.ToDouble(SubForm.dataGridView1.Rows[0].Cells[2].Value);  // y min
            //double x1 = x0;  // x max
            //double y1 = y0;  // y max

            //for (int i = 0; i < n; i++)
            //{
            //    if (x1 < Convert.ToDouble(SubForm.dataGridView1.Rows[i].Cells[1].Value))
            //        x1 = Convert.ToDouble(SubForm.dataGridView1.Rows[i].Cells[1].Value);
            //    if (y1 < Convert.ToDouble(SubForm.dataGridView1.Rows[i].Cells[2].Value))
            //        y1 = Convert.ToDouble(SubForm.dataGridView1.Rows[i].Cells[2].Value);
            //    if (x0 > Convert.ToDouble(SubForm.dataGridView1.Rows[i].Cells[1].Value))
            //        x0 = Convert.ToDouble(SubForm.dataGridView1.Rows[i].Cells[1].Value);
            //    if (y0 > Convert.ToDouble(SubForm.dataGridView1.Rows[i].Cells[2].Value))
            //        y0 = Convert.ToDouble(SubForm.dataGridView1.Rows[i].Cells[2].Value);
            //}
            //tx0 = x0;
            //ty0 = y0;
            //tx1 = x1;
            //ty1 = y1;

            //a0 = (x0 + x1) / 2;
            //b0 = (y0 + y1) / 2;
            //r0 = (x1 - x0 + y1 - y0) / 4;  //计算近似值

            //if (((SubForm.pictureBox1.Size.Width - 100) / (y1 - y0)) < ((SubForm.pictureBox1.Size.Width - 100) / (x1 - x0)))
            //    PlotScale = (SubForm.pictureBox1.Size.Width - 100) / (y1 - y0);
            //else
            //    PlotScale = (SubForm.pictureBox1.Size.Width - 100) / (x1 - x0);

            //for (int i = 0; i < n; i++)
            //{
            //    group1[i].X = Convert.ToInt16(50 + (Convert.ToDouble(SubForm.dataGridView1.Rows[i].Cells[1].Value) - x0) * PlotScale);
            //    group1[i].Y = Convert.ToInt16(-50 - (Convert.ToDouble(SubForm.dataGridView1.Rows[i].Cells[2].Value) - y0) * PlotScale + SubForm.pictureBox1.Height);
            //}


            //Bitmap B = new Bitmap(SubForm.pictureBox1.Width, SubForm.pictureBox1.Height);
            //using (Graphics G = Graphics.FromImage(B))
            //{
            //    for (int i = 0; i < n; i++)
            //    {
            //        string str = "" + SubForm.dataGridView1.Rows[i].Cells[0].Value.ToString() + "";
            //        G.FillEllipse(Brushes.Blue, group1[i].X, group1[i].Y, 5, 5);
            //        G.DrawString(str, new Font("黑体", 10), new SolidBrush(Color.Blue), group1[i].X, group1[i].Y + 10);
            //    }
            //    G.Dispose();
            //}

            //SubForm.pictureBox1.Image = B;

            DotsPaint();
            if (Fitted)
                PaintCircle();

        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            GC.Collect();
            list.Clear();
            Resultlist.Clear();
        }

        private void 导出TXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Fitted)
                return;
            SaveFileDialog saeDlg = new SaveFileDialog
            {
                Filter = "文本文件（*.txt)|*.txt",
                Title = "保存数据",
                ShowHelp = true
            };
            if (saeDlg.ShowDialog() == DialogResult.OK)
            {
                String path = saeDlg.FileName;
                StreamWriter sw = new StreamWriter(path);
                if (Resultlist.Count < 1)
                    MessageBox.Show("没有数据！导出失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    for (int i = 0; i < Resultlist.Count; i++)
                    {
                        sw.WriteLine(Resultlist[i].ToString());
                    }
                    //清空缓冲区
                    sw.Flush();
                    //关闭流
                    sw.Close();
                    MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            GC.Collect();
            SubForm = new Form2
            {
                TopLevel = false,
                Dock = DockStyle.None
            };

            this.panel.Controls.Add(SubForm);
            SubForm.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saeDlg = new SaveFileDialog
            {
                Filter = "文本文件（*.txt)|*.txt",
                Title = "保存数据",
                ShowHelp = true
            };
            if (saeDlg.ShowDialog() == DialogResult.OK)
            {
                String path = saeDlg.FileName;
                StreamWriter sw = new StreamWriter(path);
                int n = SubForm.dataGridView1.Rows.Count - 1;

                for (int i = 0; i < n; i++)
                {
                    sw.WriteLine(SubForm.dataGridView1.Rows[i].Cells[0].Value.ToString() + "," + SubForm.dataGridView1.Rows[i].Cells[1].Value.ToString() + "," + SubForm.dataGridView1.Rows[i].Cells[2].Value.ToString());
                }
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void 求最大三角形ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = SubForm.dataGridView1.Rows.Count - 1;
            //三角形总个数为一组合数  根据排列组合公式  C（n,3)
            int numbers = n * (n - 1) * (n - 2) / 6;
            triangles = new Triangle[numbers]; //初始化三角形数组  

            //遍历三角形
            int m = 0;
            for (int i = 0; i < n - 2; i++)
            {
                for (int j = i + 1; j < n - 1; j++)
                {
                    for (int k = j + 1; k < n && m < numbers; k++)
                    {
                        triangles[m].n1 = i;
                        triangles[m].n2 = j;
                        triangles[m].n3 = k;
                        triangles[m].Area = CalArea(i, j, k);
                        m++;
                    }
                }
            }

            if (m == numbers)
            {
                MessageBox.Show("三角形构建成功！", "Successful！", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("三角形构建失败", "ERROR", MessageBoxButtons.OK);
            }

            Triangle TheOne = triangles[0]; //面积最大的三角形

            //排序得到最大三角形
            for (int i = 0; i < numbers; i++)
            {
                if (TheOne.Area < triangles[i].Area)
                    TheOne = triangles[i];
            }


            ;//绘制该三角形
            PaintTriangle(TheOne.n1, TheOne.n2, TheOne.n3);

        }

        //平差
        private void FitCircle()
        {
            //计算近似值

            int n = SubForm.dataGridView1.Rows.Count - 1;
            //初始化矩阵
            MatB = new double[n, 3];
            Matl = new double[n, 1];
            //矩阵赋值
            for (int i = 0; i < n; i++)
            {
                double xi = System.Convert.ToDouble(SubForm.dataGridView1.Rows[i].Cells[1].Value); //获取值
                double yi = System.Convert.ToDouble(SubForm.dataGridView1.Rows[i].Cells[2].Value);
                double si0 = Math.Sqrt((xi - a0) * (xi - a0) + (yi - b0) * (yi - b0));
                MatB[i, 0] = -(xi - a0) / si0;
                MatB[i, 1] = -(yi - b0) / si0;
                MatB[i, 2] = -1;
                Matl[i, 0] = si0 - r0;
            }
            // x=(BTPB).I*(BTPl)  P为单位阵
            Matx = MatMulti(MatInver(MatMulti(MatTrans(MatB), MatB)), MatMulti(MatTrans(MatB), Matl));  //BTPB逆 BTPL
            MatQxx = MatInver(MatMulti(MatTrans(MatB), MatB));////BTPB逆
            da = -Matx[0, 0];  //近似值
            db = -Matx[1, 0];
            dr = -Matx[2, 0];
            a = da + a0;  //平差值
            b = db + b0;
            r = dr + r0;
            Fitted = true;
            //D0 = sqrt(vtpv/(n-t))
            MatV = MatAdd(MatMulti(MatB, Matx), Matl);  //  V=Bx+l
            double[,] t0 = MatMulti(MatTrans(MatV), MatV);  //VTPV
            D0 = Math.Sqrt(t0[0,0] / (n - 3));
            MatDxx = MatMulti2(MatQxx, D0 * D0);


        }

        //绘画出拟合后的圆形
        private void PaintCircle()
        {
            DotsPaint();
            //坐标转换
            int x = Convert.ToInt16(50 + (a - tx0) * PlotScale);
            int y = Convert.ToInt16(-50 - (b - ty0) * PlotScale + SubForm.pictureBox1.Height);
            int c = Convert.ToInt16(r * PlotScale);

            //取出图形
            Bitmap B = new Bitmap(SubForm.pictureBox1.Image);

            using (Graphics G = Graphics.FromImage(B))
            {
                string str = "（" + String.Format("{0:N2}", a) + "，" + String.Format("{0:N2}", b) + "）" + " r=" + String.Format("{0:N2}", r);
                //绘制圆心
                G.FillEllipse(Brushes.Red, x, y, 5, 5);
                G.DrawString(str, new Font("黑体", 10), new SolidBrush(Color.Red), x - 100, y + 10);
                //绘制圆形
                Pen pen = new Pen(Color.Red);//画笔颜色    
                G.DrawEllipse(pen, x - c, y - c, 2 * c, 2 * c);//画椭圆的方法，x坐标、y坐标、宽、高，如果是100，则半径为50

                G.Flush();  //执行
                G.Dispose();  // 清除内存
            }

            SubForm.pictureBox1.Image = B;
        }

        //绘制三角形
        private void PaintTriangle(int n1, int n2, int n3)
        {
            double[] x = new double[3];
            double[] y = new double[3];

            //给坐标赋值
            x[0] = System.Convert.ToDouble(SubForm.dataGridView1.Rows[n1].Cells[1].Value);
            y[0] = System.Convert.ToDouble(SubForm.dataGridView1.Rows[n1].Cells[2].Value);

            x[1] = System.Convert.ToDouble(SubForm.dataGridView1.Rows[n2].Cells[1].Value);
            y[1] = System.Convert.ToDouble(SubForm.dataGridView1.Rows[n2].Cells[2].Value);

            x[2] = System.Convert.ToDouble(SubForm.dataGridView1.Rows[n3].Cells[1].Value);
            y[2] = System.Convert.ToDouble(SubForm.dataGridView1.Rows[n3].Cells[2].Value);


            //坐标转换
            
            for (int i = 0; i < 3; i++)
            {
                points[i].X = Convert.ToInt32(50 + (x[i] - tx0) * PlotScale);
                points[i].Y = Convert.ToInt32(-50 - (y[i] - ty0) * PlotScale + SubForm.pictureBox1.Height);
            }

            //取出图形
            Bitmap B = new Bitmap(SubForm.pictureBox1.Image);

            using (Graphics G = Graphics.FromImage(B))
            {
                //绘制圆形
                Pen pen = new Pen(Color.Green);//画笔颜色    
                G.DrawLine(pen, points[1], points[2]);
                G.DrawLine(pen, points[2], points[0]);
                G.DrawLine(pen, points[1], points[0]);
                G.Flush();  //执行
                G.Dispose();  // 清除内存
            }
            SubForm.pictureBox1.Image = B;
        }

        //写入resultlist
        private void ExecResult()
        {
            Resultlist.Clear();

            int n = SubForm.dataGridView1.Rows.Count - 1;
            
            Resultlist.Add("======================圆形拟合======================");
            Resultlist.Add("                  测绘实用软件设计                  ");
            Resultlist.Add("");
            Resultlist.Add("=====================已知点坐标=====================");
            Resultlist.Add("点号            X坐标            Y坐标");
            for (int i = 0; i < n; i++)
            {
                Resultlist.Add(SubForm.dataGridView1.Rows[i].Cells[0].Value.ToString() + "           " + SubForm.dataGridView1.Rows[i].Cells[1].Value.ToString() + "           " + SubForm.dataGridView1.Rows[i].Cells[2].Value.ToString());
            }
            Resultlist.Add("====================================================");
            Resultlist.Add("=====================拟合计算=======================");
            Resultlist.Add("");
            Resultlist.Add("近似值估算：");
            Resultlist.Add("圆心横坐标近似值  a0 = " + a0);
            Resultlist.Add("圆心纵坐标近似值  b0 = " + b0);
            Resultlist.Add("圆形半径近似值  r0 = " + r0);
            Resultlist.Add("");
            Resultlist.Add("间接平差矩阵：");
            Resultlist.Add("");
            Resultlist.Add("B矩阵                                                      l矩阵 ");
            for (int i = 0; i < n; i++)
            {
                double a1, a2, a3, b1;
                a1 = MatB[i, 0];a2 = MatB[i, 1]; a3 = MatB[i, 2];b1 = Matl[i, 0];
                Resultlist.Add(a1 + "   " + a2 + "    " + a3 + "               " + b1);
            }
            Resultlist.Add("");
            Resultlist.Add("X坐标改正数 da               Y坐标改正数 db                半径改正数 dr");
            Resultlist.Add(da + "        " + db + "          " + dr);
            Resultlist.Add("");
            Resultlist.Add("X坐标 a                    Y坐标 b                     半径 r");
            Resultlist.Add(a + "        " + b + "          " + r);
            Resultlist.Add("");
            Resultlist.Add("=====================精度评定=======================");
            Resultlist.Add("平差值协方差矩阵Qxx (依次是a b r)");
            Resultlist.Add("");
            for (int i = 0; i < 3; i++)
            {
                double a1, a2, a3;
                a1 = MatQxx[i, 0]; a2 = MatQxx[i, 1]; a3 = MatQxx[i, 2];
                Resultlist.Add(a1 + "    " + a2 + "     " + a3);
            }
            Resultlist.Add("");
            Resultlist.Add("平差结果精度Qxixi：");
            Resultlist.Add("X坐标                    Y坐标                     半径");
            Resultlist.Add(MatQxx[0,0] + "        " + MatQxx[1,1] + "          " + MatQxx[2,2]);
            Resultlist.Add("");
            Resultlist.Add("单位权中误差m0");
            Resultlist.Add(D0);
            Resultlist.Add("");
            Resultlist.Add("未知数方差阵Dxx");
            Resultlist.Add("");
            for (int i = 0; i < 3; i++)
            {
                double a1, a2, a3;
                a1 = MatDxx[i, 0]; a2 = MatDxx[i, 1]; a3 = MatDxx[i, 2];
                Resultlist.Add(a1 + "    " + a2 + "     " + a3);
            }
            Resultlist.Add("");
            Resultlist.Add("拟合结果中误差 Dxixi：");
            Resultlist.Add("X坐标                    Y坐标                     半径");
            Resultlist.Add(MatDxx[0, 0] + "        " + MatDxx[1, 1] + "          " + MatDxx[2, 2]);

        }

        //从datagridview绘点
        private void DotsPaint()
        {
            int n = SubForm.dataGridView1.Rows.Count - 1;
            Point[] group = new Point[n];
            Point[] group1 = new Point[n];
            string[] m = new string[n];

            for (int i = 0; i < n; i++)
            {
                m[i] = SubForm.dataGridView1.Rows[i].Cells[0].Value.ToString();
                group[i].X = Convert.ToInt16(Convert.ToDouble(SubForm.dataGridView1.Rows[i].Cells[1].Value));
                group[i].Y = Convert.ToInt16(Convert.ToDouble(SubForm.dataGridView1.Rows[i].Cells[2].Value));
            }

            double x0 = Convert.ToDouble(group[0].X);  // x min
            double y0 = Convert.ToDouble(group[0].Y);  // y min
            double x1 = Convert.ToDouble(group[0].X);  // x max
            double y1 = Convert.ToDouble(group[0].Y);  // y max

            for (int i = 0; i < n; i++)
            {
                if (x1 < Convert.ToDouble(group[i].X))
                    x1 = Convert.ToDouble(group[i].X);
                if (y1 < Convert.ToDouble(group[i].Y))
                    y1 = Convert.ToDouble(group[i].Y);
                if (x0 > Convert.ToDouble(group[i].X))
                    x0 = Convert.ToDouble(group[i].X);
                if (y0 > Convert.ToDouble(group[i].Y))
                    y0 = Convert.ToDouble(group[i].Y);
            }
            tx0 = x0;
            ty0 = y0;
            tx1 = x1;
            ty1 = y1;
            a0 = (x0 + x1) / 2;
            b0 = (y0 + y1) / 2;
            r0 = (x1 - x0 + y1 - y0) / 4;  //计算近似值

            if (x0 == x1 && y0 == y1)
                return;

            if ( ((SubForm.pictureBox1.Size.Height -100 ) / (y1 - y0)) < ((SubForm.pictureBox1.Size.Width - 100) / (x1 - x0)) )
                PlotScale = (SubForm.pictureBox1.Size.Height - 100) / (y1 - y0);
            else
                PlotScale = (SubForm.pictureBox1.Size.Width - 100) / (x1 - x0);
            
            //图上坐标
            for (int i = 0; i < n; i++)
            {
                group1[i].X = Convert.ToInt16(50 + (group[i].X - x0) * PlotScale);
                group1[i].Y = Convert.ToInt16(- 50 - (group[i].Y - y0) *  PlotScale + SubForm.pictureBox1.Height);
            }

            Bitmap B = new Bitmap(SubForm.pictureBox1.Width, SubForm.pictureBox1.Height);
            using (Graphics G = Graphics.FromImage(B))
            {
                for (int i = 0; i < n; i++)
                {
                    string str = "" + m[i] + "";
                    G.FillEllipse(Brushes.Blue, group1[i].X, group1[i].Y, 5, 5);
                    G.DrawString(str, new Font("黑体", 10), new SolidBrush(Color.Blue), group1[i].X, group1[i].Y + 10);
                }
                G.Dispose();
            }
            SubForm.pictureBox1.Image = B;
        }

        //读取txt文件
        private void ReadFile()
        {
            Fitted = false;
            list.Clear();
            OpenFileDialog opnDlg = new OpenFileDialog(); // 对话框读取
            opnDlg.Filter = "文本文件(*.txt)|*.txt";
            opnDlg.Title = "打开数据文件";
            opnDlg.ShowHelp = true;
            if (opnDlg.ShowDialog() == DialogResult.OK)
            {
                String path = opnDlg.FileName;
                StreamReader sr = new StreamReader(path);

                string line;
                do
                {
                    line = sr.ReadLine();
                    if (line == null)
                    { break; }
                    list.Add(line);
                } while (line != null);
                sr.Close(); //读取结束
            }
        }

        //求矩阵转置
        public double[,] MatTrans(double[,] a)
        {
            int m = a.GetLength(0);
            int n = a.GetLength(1);
            double[,] b = new double[n, m];
            int i, j;
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    b[j, i] = a[i, j];
                }
            }
            double[,] result = b;
            return result;
        }

        //求矩阵相乘
        public double[,] MatMulti(double[,] a, double[,] b)
        {
            int m1 = a.GetLength(0); //r
            int n1 = a.GetLength(1); //c
            int m2 = b.GetLength(0);
            int n2 = b.GetLength(1);
            if (n1 != m2) return null;
            double[,] c = new double[m1, n2];
            int i, j, k;
            for (i = 0; i < m1; i++)
            {
                for (j = 0; j < n2; j++)
                {
                    c[i, j] = 0;
                    for (k = 0; k < n1; k++)
                    {
                        c[i, j] = c[i, j] + a[i, k] * b[k, j];
                    }
                }
            }
            double[,] result = c;
            return result;
        }

        //矩阵相加
        public double[,] MatAdd(double[,] a, double[,] b)
        {
            int m1 = a.GetLength(0);
            int n1 = a.GetLength(1);
            int m2 = b.GetLength(0);
            int n2 = b.GetLength(1);
            if (n1 != n2 || m1 != m2) return null;
            double[,] c = new double[m1, n1];
            int i, j;
            for (i = 0; i < m1; i++)
            {
                for (j = 0; j < n1; j++)
                {
                    c[i, j] = a[i, j] + b[i, j];
                }
            }
            double[,] result = c;
            return result;
        }

        //矩阵数乘
        public double[,] MatMulti2(double[,] a, double b)
        {
            int m = a.GetLength(0);
            int n = a.GetLength(1);
            double[,] c = new double[m, n];
            int i, j;
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    c[i, j] = a[i, j] * b;
                }
            }
            double[,] result = c;
            return result;
        }

        //求逆函数
        public double[,] MatInver(double[,] n) //矩阵求逆函数  组员法改进  
        {
            //前提判断： 是否为方形矩阵  是否满足可逆条件
            int m = n.GetLength(0);
            double[,] q = new double[m, m]; //法方程系数逆矩阵;
            double u, temp;  //临时变量
            int i, j, k;

            //初始单位阵
            for (i = 0; i < m; i++)
                for (j = 0; j <= m - 1; j++)
                    q[i, j] = (i == j) ? 1 : 0;

            // 求左下
            for (i = 0; i <= m - 2; i++)
            {

                //提取该行的主对角线元素
                u = n[i, i];   //可能为0

                if (u == 0)
                {
                    for (i = 0; i < m; i++)
                    {
                        k = i;
                        for (j = i + 1; j < m; j++)
                        {
                            if (n[j, i] != 0)
                            {
                                k = j;
                                break;
                            }
                        }

                        if (k != i)
                        {
                            for (j = 0; j < m; j++)
                            {
                                temp = n[i, j];
                                n[i, j] = n[k, j];
                                n[k, j] = temp;
                                //伴随交换
                                temp = q[i, j];
                                q[i, j] = q[k, j];
                                q[k, j] = temp;
                            }
                        }
                        else
                            MessageBox.Show("不可逆矩阵", "ERROR", MessageBoxButtons.OK);

                    }
                }

                for (j = 0; j < m; j++)//该行除以主对角线元素的值 使主对角线元素为1  
                {
                    n[i, j] = n[i, j] / u;   //分母不为0
                    q[i, j] = q[i, j] / u;  //伴随矩阵
                }

                for (k = i + 1; k < m; k++)  //下方的每一行减去  该行的倍数
                {
                    u = n[k, i];   //下方的某一行的主对角线元素
                    for (j = 0; j < m; j++)
                    {
                        n[k, j] = n[k, j] - u * n[i, j];  //下方的每一行减去该行的倍数  使左下角矩阵化为0
                        q[k, j] = q[k, j] - u * q[i, j];  //左下伴随矩阵
                    }
                }
            }


            u = n[m - 1, m - 1];  //最后一行最后一个元素

            if (u == 0)
                MessageBox.Show("不可逆矩阵", "ERROR", MessageBoxButtons.OK);
            n[m - 1, m - 1] = 1;
            for (j = 0; j < m; j++)
            {
                q[m - 1, j] = q[m - 1, j] / u;
            }

            // 求右上
            for (i = m - 1; i >= 0; i--)
            {
                for (k = i - 1; k >= 0; k--)
                {
                    u = n[k, i];
                    for (j = 0; j < m; j++)
                    {
                        n[k, j] = n[k, j] - u * n[i, j];
                        q[k, j] = q[k, j] - u * q[i, j];
                    }
                }
            }
            return q;
        }

        //计算三角形面积
        private double CalArea(int n1, int  n2 ,int n3)
        {
            double[] x = new double[3];
            double[] y = new double[3];

            //给坐标赋值
            x[0] = System.Convert.ToDouble(SubForm.dataGridView1.Rows[n1].Cells[1].Value);
            y[0] = System.Convert.ToDouble(SubForm.dataGridView1.Rows[n1].Cells[2].Value);

            x[1] = System.Convert.ToDouble(SubForm.dataGridView1.Rows[n2].Cells[1].Value);
            y[1] = System.Convert.ToDouble(SubForm.dataGridView1.Rows[n2].Cells[2].Value);

            x[2] = System.Convert.ToDouble(SubForm.dataGridView1.Rows[n3].Cells[1].Value);
            y[2] = System.Convert.ToDouble(SubForm.dataGridView1.Rows[n3].Cells[2].Value);

            double area = Math.Abs(x[0] * y[1] + y[0] * x[2] + x[1] * y[2] - y[1] * x[2] - y[2] * x[0] - y[0] * x[1]) / 2;
            return area;

        }
    }

}

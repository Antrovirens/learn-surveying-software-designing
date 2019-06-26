using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 期中考试
{
    public partial class Form_main : Form
    {
        public Form_main()
        {
            InitializeComponent();
        }

        private ArrayList list = new ArrayList();
        private ArrayList Resultlist = new ArrayList();
        private ArrayList text = new ArrayList();
        CPolygon polygon = new CPolygon();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 400;
            this.Height = 500;
            button_read.Enabled = true;
            button_cal.Enabled = false;
            button_save.Enabled = false;
        }

        private void Read(ArrayList listin)
        {
            polygon.X = new double[listin.Count];
            polygon.Y = new double[listin.Count];
            string line;
            string[] splits = null;
            double[] X0 = new double[listin.Count];
            double[] Y0 = new double[listin.Count];

            int m = listin.Count;
            int t = 0;
            for (int i = 0; i < m; i++)
            {
                line = System.Convert.ToString(listin[i]);
                splits = line.Split(',');
                polygon.X[i] = System.Convert.ToDouble(splits[0]);
                polygon.Y[i] = System.Convert.ToDouble(splits[1]);
                //if (i > 1)
                //    if (X[i] < X[i - 1])
                //        t = i;
            }
            //X[0] = X0[t];Y[0] = Y0[t];//从最左侧为起点排序
            ////重新排序
            //for (int i = 0; i < listin.Count; i++)
            //{

            //}

        }

        private void button_read_Click(object sender, EventArgs e)
        {
            button_cal.Enabled = true;
            button_save.Enabled = true;
            button_read.Text = "重新读取";
            list.Clear();
            textBox_status.Text = "正在打开：";
            OpenFileDialog opnDlg = new OpenFileDialog(); // 对话框读取
            opnDlg.Filter = "文本文件(*.txt)|*.txt";
            opnDlg.Title = "打开数据文件";
            opnDlg.ShowHelp = true;
            if (opnDlg.ShowDialog() == DialogResult.OK)
            {
                String path = opnDlg.FileName;
                textBox_status.AppendText(path + Environment.NewLine);
                StreamReader sr = new StreamReader(path);

                string line;
                do
                {
                    line = sr.ReadLine();
                    if (line == null)
                    { break; }
                    list.Add(line);
                    textBox_status.AppendText(line + Environment.NewLine);
                } while (line != null);
                sr.Close();                      //读取结束
            }
            textBox_status.AppendText("读取结束！" + Environment.NewLine);   //Environment.NewLine多环境支持  （windows：/r/n   linux：/n）

            textBox_status.AppendText(Environment.NewLine);

            Resultlist.Add(textBox_status.ToString());
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\计算结果.txt";
            textBox_status.AppendText("正在保存：" + path );
            StreamWriter sw = new StreamWriter(path);

            int i;
            for (i = 0; i < Resultlist.Count; i++)
            {
                sw.WriteLine(Resultlist[i].ToString());
            }
            sw.Close();
            textBox_status.AppendText("保存成功！" + Environment.NewLine);

            textBox_status.AppendText(Environment.NewLine);
        }

        private void button_cal_Click(object sender, EventArgs e)
        {
            int n = list.Count;
            
            Read(list);

            textBox_status.AppendText("录入多边形顶点坐标如下：" + Environment.NewLine);
            Resultlist.Add("录入多边形顶点坐标如下：");

            for (int i = 0; i < n; i ++)
            {
                textBox_status.AppendText("x" + i.ToString() + "=" + polygon.X[i].ToString());
                textBox_status.AppendText("; y" + i.ToString() + "=" + polygon.Y[i].ToString() + Environment.NewLine);
                Resultlist.Add(polygon.X[i].ToString() + ";" + polygon.Y[i].ToString());
            }
            textBox_status.AppendText("正在计算......");
            double[] length = new double[polygon.X.Length];
            double[] azimuth = new double[polygon.X.Length];

            length = polygon.PolygonLength();
            azimuth = polygon.Azimuth();

            double area, c;
            c = polygon.PolygonPerimeter(length);
            area = polygon.PolygonArea();
            textBox_status.AppendText(Environment.NewLine + "计算成功！" + Environment.NewLine);

            textBox_status.AppendText("多边形各边边长如下：");
            Resultlist.Add("多边形各边边长以及其方位角为如下：");
            for (int i = 0; i < n; i++)
            {
                textBox_status.AppendText("第" + i.ToString() + "条边的长度为: " + length[i].ToString());
                textBox_status.AppendText("; 其方位角为: " + azimuth[i].ToString() + Environment.NewLine);
                Resultlist.Add(length[i].ToString()+";"+ azimuth[i].ToString());
            }

            textBox_status.AppendText("多边形总边长为：" + c.ToString()+ "; 多边形总面积为："+ area.ToString() + Environment.NewLine);
            Resultlist.Add("多边形总边长为：" + c.ToString() + "; 多边形总面积为：" + area.ToString() + Environment.NewLine);
            textBox_status.AppendText(Environment.NewLine);

        }
    }
}

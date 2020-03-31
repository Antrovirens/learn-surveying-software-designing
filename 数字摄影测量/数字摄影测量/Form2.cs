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

        ArrayList list1 = new ArrayList();

        CPoint[] p_left = null;
        CImage image_left = new CImage();

        CPoint[] p_right = null;
        CImage image_right = new CImage();


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

        private void button_cal_left_Click(object sender, EventArgs e)
        {
            image_left.ImageCal6(0.000001, p_left);
        }

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

        private void button1_Click_1(object sender, EventArgs e)
        {
            image_right.ImageCal6(0.000001, p_right);
        }
    }
}

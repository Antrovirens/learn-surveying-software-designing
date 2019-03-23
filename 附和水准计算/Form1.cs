using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;  //输入输出
using System.Collections;  //数组

namespace 附和水准路线
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ArrayList list = new ArrayList();  //
        private ArrayList Resultlist = new ArrayList();
        private ArrayList text = new ArrayList();

        private void Read_Click(object sender, EventArgs e)
        {
            list.Clear();
            Status.Text= "正在打开：";
            OpenFileDialog opnDlg = new OpenFileDialog(); // 对话框读取
            opnDlg.Filter = "文本文件(*.txt)|*.txt";
            opnDlg.Title = "打开数据文件";
            opnDlg.ShowHelp = true;
            if (opnDlg.ShowDialog() == DialogResult.OK)
            {
                String path = opnDlg.FileName;
                Status.AppendText(path + Environment.NewLine);
                StreamReader sr = new StreamReader(path);

                string line;
                do
                {
                    line = sr.ReadLine();
                    if (line == null)
                    { break; }
                    list.Add(line);
                    Status.AppendText(line + Environment.NewLine);
                } while (line != null);
                sr.Close();                      //读取结束
            }
            Status.AppendText( "读取结束！" + Environment.NewLine);   //Environment.NewLine多环境支持  （windows：/r/n   linux：/n）

            Status.AppendText(Environment.NewLine);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\附合水准计算结果.txt";
            Status.AppendText("正在保存：" + path + Environment.NewLine);
            StreamWriter sw = new StreamWriter(path);

            int i;
            for (i = 0; i < Resultlist.Count; i++)
            {
                sw.WriteLine(Resultlist[i].ToString());
                Status.AppendText(Resultlist[i].ToString() + Environment.NewLine);
            }
            sw.Close();
            Status.AppendText("保存成功！"+ Environment.NewLine);

            Status.AppendText(Environment.NewLine);
        }

        private void Cal_Click(object sender, EventArgs e)
        {
            Leveline leveline = new Leveline();
            Resultlist = leveline.LevelCal(list);

            Status.AppendText("计算成功！" + Environment.NewLine);
            Status.AppendText("路线长度d=" + leveline.D.ToString() + "km" + Environment.NewLine);
            Status.AppendText("闭合差fh="+leveline.FH.ToString() + "mm" + Environment.NewLine);
            Status.AppendText("四等水准容许误差fh0=" + leveline.FH0.ToString() + "mm" + Environment.NewLine);
            Status.AppendText(Environment.NewLine);
        }

        private void Status_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

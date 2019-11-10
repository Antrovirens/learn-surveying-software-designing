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

namespace 计算加常数乘常数
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public ArrayList list = new ArrayList();  //读取文件
        public ArrayList Resultlist = new ArrayList();  //输出文件
        private double[,] values = new double[6, 6]; //六段观测值
        private double[] data = new double[6]; //长度平差值
        private double C;
        private double D;

        //构建零矩阵
        private double[,] MatZero(int m, int n)
        {
            double[,] result = new double[m, n];
            int i, j;
            for (i = 0; i <= m - 1; i++)
            {
                for (j = 0; j <= n - 1; j++)
                {
                    result[i, j] = 0.0;
                }
            }
            return result;
        }

        //读取txt文件
        private void ReadFile()
        {
            list.Clear();
            int i = 0, j = 0, k = 0;
            OpenFileDialog opnDlg = new OpenFileDialog(); // 对话框读取
            opnDlg.Filter = "文本文件(*.txt)|*.txt";
            opnDlg.Title = "打开数据文件";
            opnDlg.ShowHelp = true;
            if (opnDlg.ShowDialog() == DialogResult.OK)
            {
                String path = opnDlg.FileName;
                StreamReader sr = new StreamReader(path);
                
                string line,word;
                string[] splits;
                do
                {
                    line = sr.ReadLine();
                    if (line == null)
                    { break; }
                    list.Add(line);
                    word = Convert.ToString(list[i]);
                    splits = word.Split(',');
                    while (k < splits.Length)
                        values[i, j++] = Convert.ToDouble(splits[k++].ToString());

                    i++;
                    j = i;
                    k = 0;
                } while (line != null);
                sr.Close(); //读取结束
            }
            
        }

        private void ShowFromValues()
        {
            
            //显示数据
            textBox2.Text = values[0, 0].ToString();
            textBox3.Text = values[0, 1].ToString();
            textBox4.Text = values[0, 2].ToString();
            textBox5.Text = values[0, 3].ToString();
            textBox6.Text = values[0, 4].ToString();
            textBox7.Text = values[0, 5].ToString();
            textBox8.Text = values[1, 1].ToString();
            textBox9.Text = values[1, 2].ToString();
            textBox10.Text = values[1, 3].ToString();
            textBox11.Text = values[1, 4].ToString();
            textBox12.Text = values[1, 5].ToString();
            textBox13.Text = values[2, 2].ToString();
            textBox14.Text = values[2, 3].ToString();
            textBox15.Text = values[2, 4].ToString();
            textBox16.Text = values[2, 5].ToString();
            textBox17.Text = values[3, 3].ToString();
            textBox18.Text = values[3, 4].ToString();
            textBox19.Text = values[3, 5].ToString();
            textBox20.Text = values[4, 4].ToString();
            textBox21.Text = values[4, 5].ToString();
            textBox22.Text = values[5, 5].ToString();
        }

        private void SaveToValues()
        {
            values = MatZero(6, 6);
            values[0, 0] = Convert.ToDouble(textBox2.Text);
            values[0, 1] = Convert.ToDouble(textBox3.Text);
            values[0, 2] = Convert.ToDouble(textBox4.Text);
            values[0, 3] = Convert.ToDouble(textBox5.Text);
            values[0, 4] = Convert.ToDouble(textBox6.Text);
            values[0, 5] = Convert.ToDouble(textBox7.Text);
            values[1, 1] = Convert.ToDouble(textBox8.Text);
            values[1, 2] = Convert.ToDouble(textBox9.Text);
            values[1, 3] = Convert.ToDouble(textBox10.Text);
            values[1, 4] = Convert.ToDouble(textBox11.Text);
            values[1, 5] = Convert.ToDouble(textBox12.Text);
            values[2, 2] = Convert.ToDouble(textBox13.Text);
            values[2, 3] = Convert.ToDouble(textBox14.Text);
            values[2, 4] = Convert.ToDouble(textBox15.Text);
            values[2, 5] = Convert.ToDouble(textBox16.Text);
            values[3, 3] = Convert.ToDouble(textBox17.Text);
            values[3, 4] = Convert.ToDouble(textBox18.Text);
            values[3, 5] = Convert.ToDouble(textBox19.Text);
            values[4, 4] = Convert.ToDouble(textBox20.Text);
            values[4, 5] = Convert.ToDouble(textBox21.Text);
            values[5, 5] = Convert.ToDouble(textBox22.Text);

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
            {
                MessageBox.Show("D未知");
            }
            values = MatZero(6, 6);
            ReadFile();
            ShowFromValues();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void 开始计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToValues();
            D = Convert.ToDouble(textBox1.Text);
            int i = 0;
            data[i] = (values[0, i] + values[1, i] + values[2, i] + values[3, i] + values[4, i] + values[5, i]) / i;

            C = (D - (data[0] + data[1] + data[2] + data[3] + data[4] + data[5])) / 5;

            Resault_textBox.Text = "计算结果：" ;
            Resault_textBox.AppendText("D1 = " + data[0].ToString() + Environment.NewLine);
            Resault_textBox.AppendText("D2 = " + data[1].ToString() + Environment.NewLine);
            Resault_textBox.AppendText("D3 = " + data[2].ToString() + Environment.NewLine);
            Resault_textBox.AppendText("D4 = " + data[3].ToString() + Environment.NewLine);
            Resault_textBox.AppendText("D5 = " + data[4].ToString() + Environment.NewLine);
            Resault_textBox.AppendText("D6 = " + data[5].ToString() + Environment.NewLine);
            Resault_textBox.AppendText("D = " + D.ToString() + Environment.NewLine);
            Resault_textBox.AppendText(Environment.NewLine);
            Resault_textBox.AppendText("C = " + C.ToString() + Environment.NewLine);

        }
    }
}

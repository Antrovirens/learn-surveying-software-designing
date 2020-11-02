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


namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ArrayList list = new ArrayList();
        private CSatellite sat = null;
        private CSatellites sats = new CSatellites();
        private double RINEX_VERSION;


        //测试用
        private void init_test()
        {
            sat = new CSatellite
            {
                Name = "G01",
                X = 0,
                Y = 0,
                Z = 0
            };
            sats = new CSatellites();
            sats.EpochSats.Add(sat);
        }

        //初始化  读取参数
        private void init_sats()
        {
            foreach (CSatellite EpochSat in sats.EpochSats)
                EpochSat.InitParas(RINEX_VERSION);
        }



        // 计算每一年的天数
        private int ydcount(int year)
        {
            int count = 0;
            if (year == 1980) count = 360;   // 若是 1980 年的话，按照算法 360 天
            else if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0)) count = 366;// 若是闰年，则 1 年有 366 天
            else count = 365;   // 若平闰年，则 1 年有 365 天
            return count;
        }  

        private int ydcount(int year, int month)
        {
            int count = 0;  // 存储每个月的天数
            if (year == 1980 && month == 1) count = 25;     // 根据算法，1980 年 1 月算作 25 天
            else if (month == 4 || month == 6 || month == 9 || month == 11) count = 30;     // 四六九冬 30 整
            else if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) count = 31;
            else
            {
                if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0)) count = 29;   // 若是闰年，则 2 月有 29 天
                else count = 28;
            }
            return count;
        }

        // c = 'w' 则返回 gps 周， c = 's' 则返回 gps 周内秒，默认返回周内秒
        private long get_gpstime(CSatellite satellite, char c = 's' )
        {
            if (c != 'w' && c != 's') 
                return -1;    // 若传递的参数不正确，则返回-1
            int days = satellite.Day;
            for (int i = 1980; i < satellite.Year; i++) 
                days += ydcount(i);     // 计算年天数
            for (int i = 1; i < satellite.Month; i++) 
                days += ydcount(satellite.Year, i);      // 计算月天数
            return c == 'w' ? days / 7 : (days % 7) * 86400 + (satellite.Hour * 3600) + (satellite.Min * 60) + satellite.Sec;
        }

        //读取renix文件
        private void ReadFile()
        {
            list.Clear();

            OpenFileDialog opnDlg = new OpenFileDialog();
            opnDlg.Title = "打开RENIX3文件";
            opnDlg.FileName = "";
            opnDlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//为了获取特定的系统文件夹，可以使用System.Environment类的静态方法GetFolderPath()。该方法接受一个Environment.SpecialFolder枚举，其中可以定义要返回路径的哪个系统目录
            opnDlg.Filter = "RENIX3文件(*.*)|*.*";
            opnDlg.ValidateNames = true;     //文件名有效性验证
            opnDlg.CheckFileExists = true;  //验证路径有效性
            opnDlg.CheckPathExists = true; //验证文件有效性
            opnDlg.ShowHelp = true;
            try
            {
                if (opnDlg.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(opnDlg.FileName);
                    String line;
                    do
                    {
                        line = sr.ReadLine();
                        if (line == null)
                            break;
                        list.Add(line);
                        this.textBox_read.AppendText(line + System.Environment.NewLine);
                    } while (line != null);
                    sr.Close(); //读取结束
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //读取目标卫星信息，并保存到类中的list0中
        private void ReadList()
        {
            if (list.Count  == 0)
            {
                MessageBox.Show("读取内容为空");
                return;
            }
            RINEX_VERSION = System.Convert.ToDouble( list[0].ToString().Substring(5, 4));
            int i = -1;
            sat = new CSatellite();
            foreach (string line in list)
            {
                
                if (line[1] != ' ' && ( line[2] == ' ' || line[3] == ' '))
                {
                    i += 1;
                    sat = new CSatellite();
                    sats.EpochSats.Add(sat);
                }
                if (i >= 0)
                    sat.List0.Add(line);
            }
            MessageBox.Show("读取成功");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            list.Clear();
            this.textBox_result.Clear();
            this.textBox_read.Clear();
            sats.EpochSats.Clear();

            ReadFile();
            //init_test();
            ReadList();
            init_sats();
        }

        private void 计算卫星坐标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //卫星读取为空
            if(sats.EpochSats.Count == 0)
            {
                MessageBox.Show("读取内容为空");
                return;
            }
            this.textBox_result.AppendText("RENIX VERSION" + ',' + RINEX_VERSION.ToString() + System.Environment.NewLine);
            this.textBox_result.AppendText( "Name" + ',' + "GPS WEEK" + ',' + "GPS TIME IN WEEK /s" + ',' + "Xk/m" + ',' + "Yk/m" + ',' + "Zk/m" + System.Environment.NewLine);

            double miu = 3986005e8; //GM
            double omigae = 729211515e-5;

            //挨个计算
            foreach (CSatellite EpochSat in sats.EpochSats)
            {
                //平均角速度n
                double n0 = Math.Sqrt(miu) / Math.Pow(EpochSat.Paras[7], 3);
                double n = n0 + EpochSat.Paras[2];
                //归化观测时间tk

                long t = get_gpstime(EpochSat, 's');
                long tk = t - long.Parse(EpochSat.Paras[8].ToString());

                ////////////////////

                //计算观测时刻的卫星平近点角Mk
                double Mk = EpochSat.Paras[3] + n * tk;
                //观测时刻的偏近点角Ek
                double e1 = EpochSat.Paras[5]; //偏心率命名为e1
                double Ek = Mk;
                double t1 = 0.0;
                while ((Ek - t) > 0.00000001)
                {
                    t1 = Ek;
                    Ek += e1 * Math.Sin(Ek);
                }
                //计算真近点角Vk

                double Vk = 2 * Math.Atan(Math.Sqrt((1 + e1) / (1 - e1)) * Math.Tan(Ek / 2));
                //计算升交距Faik
                double Faik = Vk + EpochSat.Paras[14];
                //计算摄动改正项
                double du, dr, di;
                double Cuc = EpochSat.Paras[4];
                double Cus = EpochSat.Paras[6];
                double Crc = EpochSat.Paras[13];
                double Crs = EpochSat.Paras[1];
                double Cic = EpochSat.Paras[9];
                double Cis = EpochSat.Paras[11];
                du = Cuc * Math.Cos(2 * Faik) + Cus * Math.Sin(2 * Faik);
                dr = Crc * Math.Cos(2 * Faik) + Crs * Math.Sin(2 * Faik);
                di = Cic * Math.Cos(2 * Faik) + Cis * Math.Sin(2 * Faik);
                //计算经摄动改正的升交距角uk卫星矢径rk轨道倾角ik
                double uk = Faik + du;
                double rk = Math.Pow(EpochSat.Paras[7], 2) * (1 - e1 * Math.Cos(Ek)) + dr;
                double ik = EpochSat.Paras[12] + di + EpochSat.Paras[16] * tk;
                //计算卫星在轨道坐标系的坐标
                double xk = rk * Math.Cos(uk);
                double yk = rk * Math.Sin(uk);
                double zk = 0;
                //计算观测时刻t的升交点经度Lk
                
                double Lk = EpochSat.Paras[10] + (EpochSat.Paras[15] - omigae) * tk - omigae * EpochSat.Paras[8];
                //计算卫星在WGS84下的坐标
                double Xk = xk * Math.Cos(Lk) - yk * Math.Cos(ik) * Math.Sin(Lk);
                double Yk = xk * Math.Sin(Lk) + yk * Math.Cos(ik) * Math.Cos(Lk);
                double Zk = yk * Math.Sin(ik);

                EpochSat.X = Xk;
                EpochSat.Y = Yk;
                EpochSat.Z = Zk;


                this.textBox_result.AppendText(EpochSat.Name + ',' + get_gpstime(EpochSat, 'w').ToString() + ',' + get_gpstime(EpochSat, 's').ToString() + ',' + EpochSat.X.ToString() + ',' + EpochSat.Y.ToString() + ',' + EpochSat.X.ToString() + System.Environment.NewLine);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 保存结果为csvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sats.EpochSats.Count == 0 || sats.EpochSats[0].X == -1)
            {
                MessageBox.Show("未计算!");
                return;
            }

            string FilePath;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "请选择保存文件路径";
            saveFile.Filter = "数据计算结果(*.csv)|*.csv";
            saveFile.OverwritePrompt = true;  //是否覆盖当前文件
            saveFile.RestoreDirectory = true;  //还原目录

            try
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    FilePath = saveFile.FileName;
                    try
                    {
                        System.IO.StreamWriter stream = new System.IO.StreamWriter(FilePath, false, Encoding.UTF8);
                        string str = this.textBox_result.Text;
                        stream.WriteLine(str);
                        stream.Flush();
                        stream.Close();
                        stream.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}

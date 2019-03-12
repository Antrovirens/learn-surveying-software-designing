 private void button1_Click(object sender, EventArgs e)
        {
            list.Clear();//防止重复读取
            //读取文件
            //string path = "C:\Folder doc\seu课程\测绘软件设计\附和导线数据.txt";
            string path = Application.StartupPath + "\\附合导线数据.txt";
            StreamReader sr = new StreamReader(path);  //system.io

            string line;
            do {
                line = sr.ReadLine();
                if (line == null)
                { break; }
                list.Add(line);
            }while (line != null);
             sr.Close();
            MessageBox.Show("数据已经读入~","读取进程提示",MessageBoxButtons.OK);   // 信息框  标题头  按钮
        }

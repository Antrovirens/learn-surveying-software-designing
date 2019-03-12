private void button3_Click(object sender, EventArgs e)   //botton对话框读取
        {
            list.Clear();    // 防止重复读取
            OpenFileDialog opnDlg = new OpenFileDialog();   //创建对话框
            opnDlg.Filter = "文本文件(*.txt)|*.txt";  //指定文件类型
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
                sr.Close();                      //读取结束
            }

        }

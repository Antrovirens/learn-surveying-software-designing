using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 数字摄影测量
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 数字摄影测量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            //
            form.TopLevel = false;
            panel1.Controls.Add(form);
           
            form.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }
    }
}

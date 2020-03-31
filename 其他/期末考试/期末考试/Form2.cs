using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期末考试
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.pictureBox1.Paint += new PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseWheel += new MouseEventHandler(this.pictureBox1_MouseWheel);
            this.pictureBox1.MouseLeave += new EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseEnter += new EventHandler(this.pictureBox1_MouseEnter);
        }

        public double tx0, ty0, tx1, ty1;
        public double PlotScale ;//比例尺

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
        }

    }
}

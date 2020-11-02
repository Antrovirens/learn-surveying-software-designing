namespace WindowsFormsApp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算卫星坐标ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存结果为csvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.textBox_read = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.CalToolStripMenuItem,
            this.保存ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(654, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.QuitToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.OpenToolStripMenuItem.Text = "打开RENIX3文件";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // QuitToolStripMenuItem
            // 
            this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
            this.QuitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.QuitToolStripMenuItem.Text = "退出";
            this.QuitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // CalToolStripMenuItem
            // 
            this.CalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.计算卫星坐标ToolStripMenuItem});
            this.CalToolStripMenuItem.Name = "CalToolStripMenuItem";
            this.CalToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.CalToolStripMenuItem.Text = "计算";
            // 
            // 计算卫星坐标ToolStripMenuItem
            // 
            this.计算卫星坐标ToolStripMenuItem.Name = "计算卫星坐标ToolStripMenuItem";
            this.计算卫星坐标ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.计算卫星坐标ToolStripMenuItem.Text = "计算卫星坐标";
            this.计算卫星坐标ToolStripMenuItem.Click += new System.EventHandler(this.计算卫星坐标ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存结果为csvToolStripMenuItem});
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.保存ToolStripMenuItem.Text = "保存";
            // 
            // 保存结果为csvToolStripMenuItem
            // 
            this.保存结果为csvToolStripMenuItem.Name = "保存结果为csvToolStripMenuItem";
            this.保存结果为csvToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.保存结果为csvToolStripMenuItem.Text = "保存结果为csv";
            this.保存结果为csvToolStripMenuItem.Click += new System.EventHandler(this.保存结果为csvToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "星历文件";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "计算结果";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox_result
            // 
            this.textBox_result.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_result.Location = new System.Drawing.Point(31, 341);
            this.textBox_result.Multiline = true;
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.ReadOnly = true;
            this.textBox_result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_result.Size = new System.Drawing.Size(573, 198);
            this.textBox_result.TabIndex = 10;
            // 
            // textBox_read
            // 
            this.textBox_read.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_read.Location = new System.Drawing.Point(31, 100);
            this.textBox_read.Multiline = true;
            this.textBox_read.Name = "textBox_read";
            this.textBox_read.ReadOnly = true;
            this.textBox_read.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_read.Size = new System.Drawing.Size(573, 192);
            this.textBox_read.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 601);
            this.Controls.Add(this.textBox_read);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "计算卫星位置";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算卫星坐标ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.TextBox textBox_read;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存结果为csvToolStripMenuItem;
    }
}


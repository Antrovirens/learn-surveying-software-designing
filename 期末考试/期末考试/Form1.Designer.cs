namespace 期末考试
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
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.处理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.拟合ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.输出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出DXFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出TXTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新图形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel = new System.Windows.Forms.Panel();
            this.求最大三角形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.处理ToolStripMenuItem,
            this.输出ToolStripMenuItem,
            this.刷新图形ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1140, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.关闭ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.新建ToolStripMenuItem.Text = "新建";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.新建ToolStripMenuItem_Click);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.关闭ToolStripMenuItem.Text = "关闭";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.关闭ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 处理ToolStripMenuItem
            // 
            this.处理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.拟合ToolStripMenuItem,
            this.求最大三角形ToolStripMenuItem});
            this.处理ToolStripMenuItem.Name = "处理ToolStripMenuItem";
            this.处理ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.处理ToolStripMenuItem.Text = "处理";
            // 
            // 拟合ToolStripMenuItem
            // 
            this.拟合ToolStripMenuItem.Name = "拟合ToolStripMenuItem";
            this.拟合ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.拟合ToolStripMenuItem.Text = "拟合";
            this.拟合ToolStripMenuItem.Click += new System.EventHandler(this.拟合ToolStripMenuItem_Click);
            // 
            // 输出ToolStripMenuItem
            // 
            this.输出ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出DXFToolStripMenuItem,
            this.导出TXTToolStripMenuItem});
            this.输出ToolStripMenuItem.Name = "输出ToolStripMenuItem";
            this.输出ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.输出ToolStripMenuItem.Text = "输出";
            // 
            // 导出DXFToolStripMenuItem
            // 
            this.导出DXFToolStripMenuItem.Name = "导出DXFToolStripMenuItem";
            this.导出DXFToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.导出DXFToolStripMenuItem.Text = "导出DXF";
            this.导出DXFToolStripMenuItem.Click += new System.EventHandler(this.导出DXFToolStripMenuItem_Click);
            // 
            // 导出TXTToolStripMenuItem
            // 
            this.导出TXTToolStripMenuItem.Name = "导出TXTToolStripMenuItem";
            this.导出TXTToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.导出TXTToolStripMenuItem.Text = "导出TXT";
            this.导出TXTToolStripMenuItem.Click += new System.EventHandler(this.导出TXTToolStripMenuItem_Click);
            // 
            // 刷新图形ToolStripMenuItem
            // 
            this.刷新图形ToolStripMenuItem.Name = "刷新图形ToolStripMenuItem";
            this.刷新图形ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.刷新图形ToolStripMenuItem.Text = "刷新图形";
            this.刷新图形ToolStripMenuItem.Click += new System.EventHandler(this.刷新图形ToolStripMenuItem_Click);
            // 
            // panel
            // 
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 28);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1140, 625);
            this.panel.TabIndex = 3;
            // 
            // 求最大三角形ToolStripMenuItem
            // 
            this.求最大三角形ToolStripMenuItem.Name = "求最大三角形ToolStripMenuItem";
            this.求最大三角形ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.求最大三角形ToolStripMenuItem.Text = "求最大三角形";
            this.求最大三角形ToolStripMenuItem.Click += new System.EventHandler(this.求最大三角形ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 653);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "期末考试";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 处理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 输出ToolStripMenuItem;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拟合ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出DXFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新图形ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出TXTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 求最大三角形ToolStripMenuItem;
    }
}


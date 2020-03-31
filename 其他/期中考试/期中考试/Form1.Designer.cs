namespace 期中考试
{
    partial class Form_main
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
            this.button_read = new System.Windows.Forms.Button();
            this.button_cal = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.textBox_status = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_read
            // 
            this.button_read.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_read.Location = new System.Drawing.Point(12, 12);
            this.button_read.Name = "button_read";
            this.button_read.Size = new System.Drawing.Size(141, 62);
            this.button_read.TabIndex = 0;
            this.button_read.Text = "读取";
            this.button_read.UseVisualStyleBackColor = true;
            this.button_read.Click += new System.EventHandler(this.button_read_Click);
            // 
            // button_cal
            // 
            this.button_cal.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_cal.Location = new System.Drawing.Point(172, 12);
            this.button_cal.Name = "button_cal";
            this.button_cal.Size = new System.Drawing.Size(141, 62);
            this.button_cal.TabIndex = 1;
            this.button_cal.Text = "计算";
            this.button_cal.UseVisualStyleBackColor = true;
            this.button_cal.Click += new System.EventHandler(this.button_cal_Click);
            // 
            // button_save
            // 
            this.button_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_save.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_save.Location = new System.Drawing.Point(332, 12);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(141, 62);
            this.button_save.TabIndex = 2;
            this.button_save.Text = "保存";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // textBox_status
            // 
            this.textBox_status.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_status.Location = new System.Drawing.Point(12, 80);
            this.textBox_status.Multiline = true;
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.ReadOnly = true;
            this.textBox_status.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_status.Size = new System.Drawing.Size(461, 473);
            this.textBox_status.TabIndex = 3;
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 561);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_cal);
            this.Controls.Add(this.button_read);
            this.Controls.Add(this.textBox_status);
            this.Name = "Form_main";
            this.ShowIcon = false;
            this.Text = "多边形面积计算";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_read;
        private System.Windows.Forms.Button button_cal;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TextBox textBox_status;
    }
}


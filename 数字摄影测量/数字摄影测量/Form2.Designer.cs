namespace 数字摄影测量
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_cal_right = new System.Windows.Forms.Button();
            this.button_cal_left = new System.Windows.Forms.Button();
            this.button_open_right = new System.Windows.Forms.Button();
            this.button_open_left = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_cal_right);
            this.groupBox1.Controls.Add(this.button_cal_left);
            this.groupBox1.Controls.Add(this.button_open_right);
            this.groupBox1.Controls.Add(this.button_open_left);
            this.groupBox1.Location = new System.Drawing.Point(41, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 313);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "后方交会-前方交会解法";
            // 
            // button_cal_right
            // 
            this.button_cal_right.Location = new System.Drawing.Point(20, 148);
            this.button_cal_right.Name = "button_cal_right";
            this.button_cal_right.Size = new System.Drawing.Size(152, 23);
            this.button_cal_right.TabIndex = 2;
            this.button_cal_right.Text = "计算右像片外方位元素";
            this.button_cal_right.UseVisualStyleBackColor = true;
            this.button_cal_right.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button_cal_left
            // 
            this.button_cal_left.Location = new System.Drawing.Point(20, 70);
            this.button_cal_left.Name = "button_cal_left";
            this.button_cal_left.Size = new System.Drawing.Size(152, 23);
            this.button_cal_left.TabIndex = 1;
            this.button_cal_left.Text = "计算左像片外方位元素";
            this.button_cal_left.UseVisualStyleBackColor = true;
            this.button_cal_left.Click += new System.EventHandler(this.button_cal_left_Click);
            // 
            // button_open_right
            // 
            this.button_open_right.Location = new System.Drawing.Point(20, 109);
            this.button_open_right.Name = "button_open_right";
            this.button_open_right.Size = new System.Drawing.Size(152, 23);
            this.button_open_right.TabIndex = 0;
            this.button_open_right.Text = "读取右像片控制点文件";
            this.button_open_right.UseVisualStyleBackColor = true;
            this.button_open_right.Click += new System.EventHandler(this.button_open_right_Click);
            // 
            // button_open_left
            // 
            this.button_open_left.Location = new System.Drawing.Point(20, 31);
            this.button_open_left.Name = "button_open_left";
            this.button_open_left.Size = new System.Drawing.Size(152, 23);
            this.button_open_left.TabIndex = 0;
            this.button_open_left.Text = "读取左相片控制点文件";
            this.button_open_left.UseVisualStyleBackColor = true;
            this.button_open_left.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(253, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 313);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "相对定向-绝对定向解法";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(465, 38);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(188, 313);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "光束法解法";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 477);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2";
            this.Text = "数字摄影测量";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_open_right;
        private System.Windows.Forms.Button button_open_left;
        private System.Windows.Forms.Button button_cal_left;
        private System.Windows.Forms.Button button_cal_right;
    }
}
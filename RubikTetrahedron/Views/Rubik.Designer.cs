namespace RubikTetrahedron
{
    partial class Rubik
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.yTranslatePositiveBtn = new System.Windows.Forms.Button();
            this.xTranslatePositiveBtn = new System.Windows.Forms.Button();
            this.yTranslateNegitiveBtn = new System.Windows.Forms.Button();
            this.xTranslateNegitiveBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.zRotatePositiveBtn = new System.Windows.Forms.Button();
            this.xRotatePositiveBtn = new System.Windows.Forms.Button();
            this.zRotateNegitiveBtn = new System.Windows.Forms.Button();
            this.yRotatePositiveBtn = new System.Windows.Forms.Button();
            this.xRotateNegitiveBtn = new System.Windows.Forms.Button();
            this.yRotateNegitiveBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.top_left = new System.Windows.Forms.Button();
            this.top_right = new System.Windows.Forms.Button();
            this.middle_right = new System.Windows.Forms.Button();
            this.middle_left = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.bottom_right = new System.Windows.Forms.Button();
            this.bottom_left = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.direction1 = new System.Windows.Forms.RadioButton();
            this.direction2 = new System.Windows.Forms.RadioButton();
            this.direction4 = new System.Windows.Forms.RadioButton();
            this.direction3 = new System.Windows.Forms.RadioButton();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.hScrollBar3 = new System.Windows.Forms.HScrollBar();
            this.label10 = new System.Windows.Forms.Label();
            this.zTranslateNegitiveBtn = new System.Windows.Forms.Button();
            this.zTranslatePositiveBtn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Location = new System.Drawing.Point(16, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 656);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.yTranslatePositiveBtn);
            this.groupBox1.Controls.Add(this.xTranslatePositiveBtn);
            this.groupBox1.Controls.Add(this.yTranslateNegitiveBtn);
            this.groupBox1.Controls.Add(this.xTranslateNegitiveBtn);
            this.groupBox1.Location = new System.Drawing.Point(903, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(157, 116);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Move";
            // 
            // yTranslatePositiveBtn
            // 
            this.yTranslatePositiveBtn.Location = new System.Drawing.Point(60, 25);
            this.yTranslatePositiveBtn.Name = "yTranslatePositiveBtn";
            this.yTranslatePositiveBtn.Size = new System.Drawing.Size(44, 25);
            this.yTranslatePositiveBtn.TabIndex = 51;
            this.yTranslatePositiveBtn.TabStop = false;
            this.yTranslatePositiveBtn.Text = "▲";
            this.yTranslatePositiveBtn.UseVisualStyleBackColor = true;
            // 
            // xTranslatePositiveBtn
            // 
            this.xTranslatePositiveBtn.Location = new System.Drawing.Point(103, 49);
            this.xTranslatePositiveBtn.Name = "xTranslatePositiveBtn";
            this.xTranslatePositiveBtn.Size = new System.Drawing.Size(25, 30);
            this.xTranslatePositiveBtn.TabIndex = 49;
            this.xTranslatePositiveBtn.TabStop = false;
            this.xTranslatePositiveBtn.Text = "▶";
            this.xTranslatePositiveBtn.UseVisualStyleBackColor = true;
            // 
            // yTranslateNegitiveBtn
            // 
            this.yTranslateNegitiveBtn.Location = new System.Drawing.Point(61, 76);
            this.yTranslateNegitiveBtn.Name = "yTranslateNegitiveBtn";
            this.yTranslateNegitiveBtn.Size = new System.Drawing.Size(42, 23);
            this.yTranslateNegitiveBtn.TabIndex = 52;
            this.yTranslateNegitiveBtn.TabStop = false;
            this.yTranslateNegitiveBtn.Text = "▼";
            this.yTranslateNegitiveBtn.UseVisualStyleBackColor = true;
            // 
            // xTranslateNegitiveBtn
            // 
            this.xTranslateNegitiveBtn.Location = new System.Drawing.Point(36, 49);
            this.xTranslateNegitiveBtn.Name = "xTranslateNegitiveBtn";
            this.xTranslateNegitiveBtn.Size = new System.Drawing.Size(25, 30);
            this.xTranslateNegitiveBtn.TabIndex = 50;
            this.xTranslateNegitiveBtn.TabStop = false;
            this.xTranslateNegitiveBtn.Text = "◀";
            this.xTranslateNegitiveBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.zRotatePositiveBtn);
            this.groupBox2.Controls.Add(this.xRotatePositiveBtn);
            this.groupBox2.Controls.Add(this.zRotateNegitiveBtn);
            this.groupBox2.Controls.Add(this.yRotatePositiveBtn);
            this.groupBox2.Controls.Add(this.xRotateNegitiveBtn);
            this.groupBox2.Controls.Add(this.yRotateNegitiveBtn);
            this.groupBox2.Location = new System.Drawing.Point(903, 144);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(157, 106);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rotate";
            // 
            // zRotatePositiveBtn
            // 
            this.zRotatePositiveBtn.Location = new System.Drawing.Point(103, 22);
            this.zRotatePositiveBtn.Name = "zRotatePositiveBtn";
            this.zRotatePositiveBtn.Size = new System.Drawing.Size(25, 25);
            this.zRotatePositiveBtn.TabIndex = 48;
            this.zRotatePositiveBtn.TabStop = false;
            this.zRotatePositiveBtn.Text = "◥";
            this.zRotatePositiveBtn.UseVisualStyleBackColor = true;
            // 
            // xRotatePositiveBtn
            // 
            this.xRotatePositiveBtn.Location = new System.Drawing.Point(60, 21);
            this.xRotatePositiveBtn.Name = "xRotatePositiveBtn";
            this.xRotatePositiveBtn.Size = new System.Drawing.Size(44, 25);
            this.xRotatePositiveBtn.TabIndex = 45;
            this.xRotatePositiveBtn.TabStop = false;
            this.xRotatePositiveBtn.Text = "▲";
            this.xRotatePositiveBtn.UseVisualStyleBackColor = true;
            // 
            // zRotateNegitiveBtn
            // 
            this.zRotateNegitiveBtn.Location = new System.Drawing.Point(36, 22);
            this.zRotateNegitiveBtn.Name = "zRotateNegitiveBtn";
            this.zRotateNegitiveBtn.Size = new System.Drawing.Size(25, 25);
            this.zRotateNegitiveBtn.TabIndex = 47;
            this.zRotateNegitiveBtn.TabStop = false;
            this.zRotateNegitiveBtn.Text = "◤";
            this.zRotateNegitiveBtn.UseVisualStyleBackColor = true;
            // 
            // yRotatePositiveBtn
            // 
            this.yRotatePositiveBtn.Location = new System.Drawing.Point(103, 45);
            this.yRotatePositiveBtn.Name = "yRotatePositiveBtn";
            this.yRotatePositiveBtn.Size = new System.Drawing.Size(25, 30);
            this.yRotatePositiveBtn.TabIndex = 43;
            this.yRotatePositiveBtn.TabStop = false;
            this.yRotatePositiveBtn.Text = "▶";
            this.yRotatePositiveBtn.UseVisualStyleBackColor = true;
            // 
            // xRotateNegitiveBtn
            // 
            this.xRotateNegitiveBtn.Location = new System.Drawing.Point(61, 72);
            this.xRotateNegitiveBtn.Name = "xRotateNegitiveBtn";
            this.xRotateNegitiveBtn.Size = new System.Drawing.Size(42, 23);
            this.xRotateNegitiveBtn.TabIndex = 46;
            this.xRotateNegitiveBtn.TabStop = false;
            this.xRotateNegitiveBtn.Text = "▼";
            this.xRotateNegitiveBtn.UseVisualStyleBackColor = true;
            // 
            // yRotateNegitiveBtn
            // 
            this.yRotateNegitiveBtn.Location = new System.Drawing.Point(36, 45);
            this.yRotateNegitiveBtn.Name = "yRotateNegitiveBtn";
            this.yRotateNegitiveBtn.Size = new System.Drawing.Size(25, 30);
            this.yRotateNegitiveBtn.TabIndex = 44;
            this.yRotateNegitiveBtn.TabStop = false;
            this.yRotateNegitiveBtn.Text = "◀";
            this.yRotateNegitiveBtn.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1030, 483);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "rotate top";
            // 
            // top_left
            // 
            this.top_left.Location = new System.Drawing.Point(1009, 503);
            this.top_left.Name = "top_left";
            this.top_left.Size = new System.Drawing.Size(54, 28);
            this.top_left.TabIndex = 25;
            this.top_left.TabStop = false;
            this.top_left.Text = "◀";
            this.top_left.UseVisualStyleBackColor = true;
            this.top_left.Click += new System.EventHandler(this.rotate_top);
            // 
            // top_right
            // 
            this.top_right.Location = new System.Drawing.Point(1069, 503);
            this.top_right.Name = "top_right";
            this.top_right.Size = new System.Drawing.Size(54, 28);
            this.top_right.TabIndex = 26;
            this.top_right.TabStop = false;
            this.top_right.Text = "▶";
            this.top_right.UseVisualStyleBackColor = true;
            this.top_right.Click += new System.EventHandler(this.rotate_top);
            // 
            // middle_right
            // 
            this.middle_right.Location = new System.Drawing.Point(1068, 553);
            this.middle_right.Name = "middle_right";
            this.middle_right.Size = new System.Drawing.Size(54, 28);
            this.middle_right.TabIndex = 29;
            this.middle_right.TabStop = false;
            this.middle_right.Text = "▶";
            this.middle_right.UseVisualStyleBackColor = true;
            this.middle_right.Click += new System.EventHandler(this.rotate_middle);
            // 
            // middle_left
            // 
            this.middle_left.Location = new System.Drawing.Point(1008, 553);
            this.middle_left.Name = "middle_left";
            this.middle_left.Size = new System.Drawing.Size(54, 28);
            this.middle_left.TabIndex = 28;
            this.middle_left.TabStop = false;
            this.middle_left.Text = "◀";
            this.middle_left.UseVisualStyleBackColor = true;
            this.middle_left.Click += new System.EventHandler(this.rotate_middle);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1020, 533);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 17);
            this.label7.TabIndex = 27;
            this.label7.Text = "rotate middle";
            // 
            // bottom_right
            // 
            this.bottom_right.Location = new System.Drawing.Point(1068, 601);
            this.bottom_right.Name = "bottom_right";
            this.bottom_right.Size = new System.Drawing.Size(54, 28);
            this.bottom_right.TabIndex = 32;
            this.bottom_right.TabStop = false;
            this.bottom_right.Text = "▶";
            this.bottom_right.UseVisualStyleBackColor = true;
            this.bottom_right.Click += new System.EventHandler(this.rotate_bottom);
            // 
            // bottom_left
            // 
            this.bottom_left.Location = new System.Drawing.Point(1008, 601);
            this.bottom_left.Name = "bottom_left";
            this.bottom_left.Size = new System.Drawing.Size(54, 28);
            this.bottom_left.TabIndex = 31;
            this.bottom_left.TabStop = false;
            this.bottom_left.Text = "◀";
            this.bottom_left.UseVisualStyleBackColor = true;
            this.bottom_left.Click += new System.EventHandler(this.rotate_bottom);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1018, 582);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 17);
            this.label9.TabIndex = 30;
            this.label9.Text = "rotate bottom";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.direction1);
            this.groupBox3.Controls.Add(this.direction2);
            this.groupBox3.Controls.Add(this.direction4);
            this.groupBox3.Controls.Add(this.direction3);
            this.groupBox3.Location = new System.Drawing.Point(854, 483);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(140, 155);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rubik\'s direction:";
            // 
            // direction1
            // 
            this.direction1.AutoSize = true;
            this.direction1.Location = new System.Drawing.Point(59, 31);
            this.direction1.Name = "direction1";
            this.direction1.Size = new System.Drawing.Size(37, 21);
            this.direction1.TabIndex = 37;
            this.direction1.Text = "1";
            this.direction1.UseVisualStyleBackColor = true;
            this.direction1.Click += new System.EventHandler(this.direction_radioButton);
            // 
            // direction2
            // 
            this.direction2.AutoSize = true;
            this.direction2.Checked = true;
            this.direction2.Location = new System.Drawing.Point(59, 58);
            this.direction2.Name = "direction2";
            this.direction2.Size = new System.Drawing.Size(37, 21);
            this.direction2.TabIndex = 38;
            this.direction2.TabStop = true;
            this.direction2.Text = "2";
            this.direction2.UseVisualStyleBackColor = true;
            this.direction2.Click += new System.EventHandler(this.direction_radioButton);
            // 
            // direction4
            // 
            this.direction4.AutoSize = true;
            this.direction4.Location = new System.Drawing.Point(59, 112);
            this.direction4.Name = "direction4";
            this.direction4.Size = new System.Drawing.Size(37, 21);
            this.direction4.TabIndex = 40;
            this.direction4.Text = "4";
            this.direction4.UseVisualStyleBackColor = true;
            this.direction4.Click += new System.EventHandler(this.direction_radioButton);
            // 
            // direction3
            // 
            this.direction3.AutoSize = true;
            this.direction3.Location = new System.Drawing.Point(59, 85);
            this.direction3.Name = "direction3";
            this.direction3.Size = new System.Drawing.Size(37, 21);
            this.direction3.TabIndex = 39;
            this.direction3.Text = "3";
            this.direction3.UseVisualStyleBackColor = true;
            this.direction3.Click += new System.EventHandler(this.direction_radioButton);
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.Location = new System.Drawing.Point(903, 417);
            this.hScrollBar2.Maximum = 200;
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(157, 16);
            this.hScrollBar2.TabIndex = 41;
            this.hScrollBar2.Value = 123;
            this.hScrollBar2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarScroll);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(903, 385);
            this.hScrollBar1.Maximum = 200;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(157, 16);
            this.hScrollBar1.TabIndex = 40;
            this.hScrollBar1.Value = 82;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarScroll);
            // 
            // hScrollBar3
            // 
            this.hScrollBar3.Location = new System.Drawing.Point(903, 446);
            this.hScrollBar3.Maximum = 200;
            this.hScrollBar3.Minimum = 85;
            this.hScrollBar3.Name = "hScrollBar3";
            this.hScrollBar3.Size = new System.Drawing.Size(157, 16);
            this.hScrollBar3.TabIndex = 39;
            this.hScrollBar3.Value = 119;
            this.hScrollBar3.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarScroll);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(947, 354);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 17);
            this.label10.TabIndex = 42;
            this.label10.Text = "light control";
            // 
            // zTranslateNegitiveBtn
            // 
            this.zTranslateNegitiveBtn.Location = new System.Drawing.Point(57, 33);
            this.zTranslateNegitiveBtn.Name = "zTranslateNegitiveBtn";
            this.zTranslateNegitiveBtn.Size = new System.Drawing.Size(25, 25);
            this.zTranslateNegitiveBtn.TabIndex = 53;
            this.zTranslateNegitiveBtn.TabStop = false;
            this.zTranslateNegitiveBtn.Text = "-";
            this.zTranslateNegitiveBtn.UseVisualStyleBackColor = true;
            // 
            // zTranslatePositiveBtn
            // 
            this.zTranslatePositiveBtn.Location = new System.Drawing.Point(82, 33);
            this.zTranslatePositiveBtn.Name = "zTranslatePositiveBtn";
            this.zTranslatePositiveBtn.Size = new System.Drawing.Size(25, 25);
            this.zTranslatePositiveBtn.TabIndex = 54;
            this.zTranslatePositiveBtn.TabStop = false;
            this.zTranslatePositiveBtn.Text = "+";
            this.zTranslatePositiveBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.zTranslatePositiveBtn);
            this.groupBox4.Controls.Add(this.zTranslateNegitiveBtn);
            this.groupBox4.Location = new System.Drawing.Point(903, 269);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(156, 76);
            this.groupBox4.TabIndex = 55;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Zoom";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1066, 385);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 17);
            this.label1.TabIndex = 56;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1066, 417);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 57;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1066, 446);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 58;
            this.label3.Text = "Z";
            // 
            // Rubik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 689);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.hScrollBar2);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.hScrollBar3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.bottom_right);
            this.Controls.Add(this.bottom_left);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.middle_right);
            this.Controls.Add(this.middle_left);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.top_right);
            this.Controls.Add(this.top_left);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Rubik";
            this.Text = "Rubik";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button top_left;
        private System.Windows.Forms.Button top_right;
        private System.Windows.Forms.Button middle_right;
        private System.Windows.Forms.Button middle_left;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bottom_right;
        private System.Windows.Forms.Button bottom_left;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton direction1;
        private System.Windows.Forms.RadioButton direction2;
        private System.Windows.Forms.RadioButton direction4;
        private System.Windows.Forms.RadioButton direction3;
        private System.Windows.Forms.HScrollBar hScrollBar2;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button yRotatePositiveBtn;
        private System.Windows.Forms.Button yRotateNegitiveBtn;
        private System.Windows.Forms.Button xRotatePositiveBtn;
        private System.Windows.Forms.Button xRotateNegitiveBtn;
        private System.Windows.Forms.Button zRotateNegitiveBtn;
        private System.Windows.Forms.Button zRotatePositiveBtn;
        private System.Windows.Forms.Button yTranslatePositiveBtn;
        private System.Windows.Forms.Button xTranslatePositiveBtn;
        private System.Windows.Forms.Button yTranslateNegitiveBtn;
        private System.Windows.Forms.Button xTranslateNegitiveBtn;
        private System.Windows.Forms.Button zTranslateNegitiveBtn;
        private System.Windows.Forms.Button zTranslatePositiveBtn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}


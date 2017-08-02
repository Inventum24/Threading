namespace Threadings.ProgramowanieCS5.Chapter6
{
    partial class Form1
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
            this.button_6_1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_6_2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_6_3 = new System.Windows.Forms.Button();
            this.button_6_4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_6_1);
            this.groupBox1.Location = new System.Drawing.Point(52, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Równległe wykonywanie dużej ilość zadań";
            // 
            // button_6_1
            // 
            this.button_6_1.Location = new System.Drawing.Point(42, 52);
            this.button_6_1.Name = "button_6_1";
            this.button_6_1.Size = new System.Drawing.Size(123, 23);
            this.button_6_1.TabIndex = 0;
            this.button_6_1.Text = "6.1";
            this.button_6_1.UseVisualStyleBackColor = true;
            this.button_6_1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_6_2);
            this.groupBox2.Location = new System.Drawing.Point(52, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Task zwaracający wartość";
            // 
            // button_6_2
            // 
            this.button_6_2.Location = new System.Drawing.Point(42, 52);
            this.button_6_2.Name = "button_6_2";
            this.button_6_2.Size = new System.Drawing.Size(123, 23);
            this.button_6_2.TabIndex = 0;
            this.button_6_2.Text = "6.2";
            this.button_6_2.UseVisualStyleBackColor = true;
            this.button_6_2.Click += new System.EventHandler(this.button_6_2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_6_3);
            this.groupBox3.Location = new System.Drawing.Point(52, 286);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Przekazanie wartości do Taska";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_6_4);
            this.groupBox4.Location = new System.Drawing.Point(52, 408);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 100);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Synchronizacja zadań";
            // 
            // button_6_3
            // 
            this.button_6_3.Location = new System.Drawing.Point(42, 43);
            this.button_6_3.Name = "button_6_3";
            this.button_6_3.Size = new System.Drawing.Size(123, 23);
            this.button_6_3.TabIndex = 0;
            this.button_6_3.Text = "6.3";
            this.button_6_3.UseVisualStyleBackColor = true;
            this.button_6_3.Click += new System.EventHandler(this.button_6_3_Click);
            // 
            // button_6_4
            // 
            this.button_6_4.Location = new System.Drawing.Point(42, 45);
            this.button_6_4.Name = "button_6_4";
            this.button_6_4.Size = new System.Drawing.Size(123, 23);
            this.button_6_4.TabIndex = 0;
            this.button_6_4.Text = "6.4";
            this.button_6_4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 566);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_6_1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_6_2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_6_3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_6_4;
    }
}


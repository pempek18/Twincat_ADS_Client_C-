
namespace Beckhoff_VS_Visualisation
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.eventView1 = new System.Windows.Forms.ListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.statisticViewier5 = new Beckhoff_VS_Visualisation.StatisticViewier();
            this.statisticViewier4 = new Beckhoff_VS_Visualisation.StatisticViewier();
            this.statisticViewier3 = new Beckhoff_VS_Visualisation.StatisticViewier();
            this.statisticViewier2 = new Beckhoff_VS_Visualisation.StatisticViewier();
            this.statisticViewier1 = new Beckhoff_VS_Visualisation.StatisticViewier();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button4.Location = new System.Drawing.Point(1162, 616);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(161, 213);
            this.button4.TabIndex = 58;
            this.button4.Text = "Confirmation \r\nAlarms";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(105, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 26);
            this.label5.TabIndex = 59;
            this.label5.Text = "Recipe Name";
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.Location = new System.Drawing.Point(1027, 44);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(296, 120);
            this.button3.TabIndex = 51;
            this.button3.Text = "Reset";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(103, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 39);
            this.label4.TabIndex = 6;
            this.label4.Text = "Actual BPM";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Highlight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(103, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 39);
            this.label3.TabIndex = 5;
            this.label3.Text = "Actual BPM";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(103, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(134, 747);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Test OFF";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(134, 695);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Test ON";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(333, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // eventView1
            // 
            this.eventView1.HideSelection = false;
            listViewItem4.Tag = "Activation TIme";
            this.eventView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4});
            this.eventView1.Location = new System.Drawing.Point(306, 616);
            this.eventView1.Margin = new System.Windows.Forms.Padding(2);
            this.eventView1.Name = "eventView1";
            this.eventView1.Size = new System.Drawing.Size(852, 213);
            this.eventView1.TabIndex = 52;
            this.eventView1.UseCompatibleStateImageBehavior = false;
            this.eventView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(134, 832);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // statisticViewier5
            // 
            this.statisticViewier5.BZBackColor = System.Drawing.Color.RoyalBlue;
            this.statisticViewier5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statisticViewier5.Label_1 = "Test:";
            this.statisticViewier5.Label_2 = "NG:";
            this.statisticViewier5.Label_3 = "Reject rate:";
            this.statisticViewier5.Label_4 = "Test:";
            this.statisticViewier5.Label_5 = "NG:";
            this.statisticViewier5.Label_6 = "Reject rate:";
            this.statisticViewier5.Location = new System.Drawing.Point(799, 422);
            this.statisticViewier5.Margin = new System.Windows.Forms.Padding(2);
            this.statisticViewier5.Name = "statisticViewier5";
            this.statisticViewier5.Size = new System.Drawing.Size(274, 171);
            this.statisticViewier5.TabIndex = 57;
            this.statisticViewier5.Text = "Body Camera 4";
            // 
            // statisticViewier4
            // 
            this.statisticViewier4.BZBackColor = System.Drawing.Color.RoyalBlue;
            this.statisticViewier4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statisticViewier4.Label_1 = "Test:";
            this.statisticViewier4.Label_2 = "NG:";
            this.statisticViewier4.Label_3 = "Reject rate:";
            this.statisticViewier4.Label_4 = "Test:";
            this.statisticViewier4.Label_5 = "NG:";
            this.statisticViewier4.Label_6 = "Reject rate:";
            this.statisticViewier4.Location = new System.Drawing.Point(487, 422);
            this.statisticViewier4.Margin = new System.Windows.Forms.Padding(2);
            this.statisticViewier4.Name = "statisticViewier4";
            this.statisticViewier4.Size = new System.Drawing.Size(274, 171);
            this.statisticViewier4.TabIndex = 56;
            this.statisticViewier4.Text = "Body Camera 3";
            // 
            // statisticViewier3
            // 
            this.statisticViewier3.BZBackColor = System.Drawing.Color.RoyalBlue;
            this.statisticViewier3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statisticViewier3.Label_1 = "Test:";
            this.statisticViewier3.Label_2 = "NG:";
            this.statisticViewier3.Label_3 = "Reject rate:";
            this.statisticViewier3.Label_4 = "Test:";
            this.statisticViewier3.Label_5 = "NG:";
            this.statisticViewier3.Label_6 = "Reject rate:";
            this.statisticViewier3.Location = new System.Drawing.Point(799, 235);
            this.statisticViewier3.Margin = new System.Windows.Forms.Padding(2);
            this.statisticViewier3.Name = "statisticViewier3";
            this.statisticViewier3.Size = new System.Drawing.Size(274, 171);
            this.statisticViewier3.TabIndex = 55;
            this.statisticViewier3.Text = "Body Camera 2";
            // 
            // statisticViewier2
            // 
            this.statisticViewier2.BZBackColor = System.Drawing.Color.RoyalBlue;
            this.statisticViewier2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statisticViewier2.Label_1 = "Test:";
            this.statisticViewier2.Label_2 = "NG:";
            this.statisticViewier2.Label_3 = "Reject rate:";
            this.statisticViewier2.Label_4 = "Test:";
            this.statisticViewier2.Label_5 = "NG:";
            this.statisticViewier2.Label_6 = "Reject rate:";
            this.statisticViewier2.Location = new System.Drawing.Point(487, 235);
            this.statisticViewier2.Margin = new System.Windows.Forms.Padding(2);
            this.statisticViewier2.Name = "statisticViewier2";
            this.statisticViewier2.Size = new System.Drawing.Size(274, 171);
            this.statisticViewier2.TabIndex = 54;
            this.statisticViewier2.Text = "Body Camera 1";
            // 
            // statisticViewier1
            // 
            this.statisticViewier1.BZBackColor = System.Drawing.Color.RoyalBlue;
            this.statisticViewier1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statisticViewier1.Label_1 = "Test:";
            this.statisticViewier1.Label_2 = "NG:";
            this.statisticViewier1.Label_3 = "Reject rate:";
            this.statisticViewier1.Label_4 = "Test:";
            this.statisticViewier1.Label_5 = "NG:";
            this.statisticViewier1.Label_6 = "Reject rate:";
            this.statisticViewier1.Location = new System.Drawing.Point(107, 235);
            this.statisticViewier1.Margin = new System.Windows.Forms.Padding(2);
            this.statisticViewier1.Name = "statisticViewier1";
            this.statisticViewier1.Size = new System.Drawing.Size(274, 171);
            this.statisticViewier1.TabIndex = 53;
            this.statisticViewier1.Text = "Global";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1392, 828);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.statisticViewier5);
            this.Controls.Add(this.statisticViewier4);
            this.Controls.Add(this.statisticViewier3);
            this.Controls.Add(this.statisticViewier2);
            this.Controls.Add(this.statisticViewier1);
            this.Controls.Add(this.eventView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Vision System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatisticViewier statisticViewier1;
        private StatisticViewier statisticViewier2;
        private StatisticViewier statisticViewier3;
        private StatisticViewier statisticViewier4;
        private StatisticViewier statisticViewier5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.ListView eventView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
    }
}


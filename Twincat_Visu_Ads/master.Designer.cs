
namespace Beckhoff_VS_Visualisation
{
    partial class master
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rejectsTriggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blowersSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conveyorSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pLCCONNECTIONSTATUSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorsCounterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.rejectsTriggerToolStripMenuItem,
            this.blowersSetupToolStripMenuItem,
            this.conveyorSetupToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.pLCCONNECTIONSTATUSToolStripMenuItem,
            this.errorsCounterToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1856, 45);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(91, 41);
            this.mainToolStripMenuItem.Text = "Main";
            this.mainToolStripMenuItem.Click += new System.EventHandler(this.mainToolStripMenuItem_Click);
            // 
            // rejectsTriggerToolStripMenuItem
            // 
            this.rejectsTriggerToolStripMenuItem.Name = "rejectsTriggerToolStripMenuItem";
            this.rejectsTriggerToolStripMenuItem.Size = new System.Drawing.Size(203, 41);
            this.rejectsTriggerToolStripMenuItem.Text = "Rejects Trigger";
            this.rejectsTriggerToolStripMenuItem.Click += new System.EventHandler(this.rejectsTriggerToolStripMenuItem_Click);
            // 
            // blowersSetupToolStripMenuItem
            // 
            this.blowersSetupToolStripMenuItem.Name = "blowersSetupToolStripMenuItem";
            this.blowersSetupToolStripMenuItem.Size = new System.Drawing.Size(198, 41);
            this.blowersSetupToolStripMenuItem.Text = "Blowers Setup";
            // 
            // conveyorSetupToolStripMenuItem
            // 
            this.conveyorSetupToolStripMenuItem.Name = "conveyorSetupToolStripMenuItem";
            this.conveyorSetupToolStripMenuItem.Size = new System.Drawing.Size(219, 41);
            this.conveyorSetupToolStripMenuItem.Text = "Conveyor Setup";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.Enabled = false;
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(87, 41);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // pLCCONNECTIONSTATUSToolStripMenuItem
            // 
            this.pLCCONNECTIONSTATUSToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pLCCONNECTIONSTATUSToolStripMenuItem.Name = "pLCCONNECTIONSTATUSToolStripMenuItem";
            this.pLCCONNECTIONSTATUSToolStripMenuItem.Size = new System.Drawing.Size(345, 41);
            this.pLCCONNECTIONSTATUSToolStripMenuItem.Text = "PLC CONNECTION STATUS";
            this.pLCCONNECTIONSTATUSToolStripMenuItem.Click += new System.EventHandler(this.pLCCONNECTIONSTATUSToolStripMenuItem_Click);
            // 
            // errorsCounterToolStripMenuItem
            // 
            this.errorsCounterToolStripMenuItem.Enabled = false;
            this.errorsCounterToolStripMenuItem.Name = "errorsCounterToolStripMenuItem";
            this.errorsCounterToolStripMenuItem.Size = new System.Drawing.Size(196, 41);
            this.errorsCounterToolStripMenuItem.Text = "errors counter";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1856, 971);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "master";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "master";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rejectsTriggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blowersSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conveyorSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pLCCONNECTIONSTATUSToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem errorsCounterToolStripMenuItem;
    }
}




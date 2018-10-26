namespace Relax
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.okBtn = new System.Windows.Forms.Button();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayCntxMnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.takeABreakNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.breakPrdLbl = new System.Windows.Forms.Label();
            this.breakPrdTxt = new System.Windows.Forms.TextBox();
            this.restLbl = new System.Windows.Forms.Label();
            this.restTxt = new System.Windows.Forms.TextBox();
            this.globalTimer = new System.Windows.Forms.Timer(this.components);
            this.trayCntxMnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(73, 95);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.OK_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipTitle = "Relax";
            this.trayIcon.ContextMenuStrip = this.trayCntxMnu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // trayCntxMnu
            // 
            this.trayCntxMnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.takeABreakNowToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.trayCntxMnu.Name = "trayCntxMnu";
            this.trayCntxMnu.Size = new System.Drawing.Size(171, 76);
            // 
            // takeABreakNowToolStripMenuItem
            // 
            this.takeABreakNowToolStripMenuItem.Name = "takeABreakNowToolStripMenuItem";
            this.takeABreakNowToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.takeABreakNowToolStripMenuItem.Text = "Take a break now";
            this.takeABreakNowToolStripMenuItem.Click += new System.EventHandler(this.takeABreakNowToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // breakPrdLbl
            // 
            this.breakPrdLbl.AutoSize = true;
            this.breakPrdLbl.Location = new System.Drawing.Point(13, 13);
            this.breakPrdLbl.Name = "breakPrdLbl";
            this.breakPrdLbl.Size = new System.Drawing.Size(92, 13);
            this.breakPrdLbl.TabIndex = 1;
            this.breakPrdLbl.Text = "Break period(min):";
            // 
            // breakPrdTxt
            // 
            this.breakPrdTxt.Location = new System.Drawing.Point(116, 10);
            this.breakPrdTxt.Name = "breakPrdTxt";
            this.breakPrdTxt.Size = new System.Drawing.Size(100, 20);
            this.breakPrdTxt.TabIndex = 2;
            // 
            // restLbl
            // 
            this.restLbl.AutoSize = true;
            this.restLbl.Location = new System.Drawing.Point(13, 48);
            this.restLbl.Name = "restLbl";
            this.restLbl.Size = new System.Drawing.Size(76, 13);
            this.restLbl.TabIndex = 3;
            this.restLbl.Text = "Rest time(min):";
            // 
            // restTxt
            // 
            this.restTxt.Location = new System.Drawing.Point(116, 45);
            this.restTxt.Name = "restTxt";
            this.restTxt.Size = new System.Drawing.Size(100, 20);
            this.restTxt.TabIndex = 4;
            // 
            // globalTimer
            // 
            this.globalTimer.Interval = 1000;
            this.globalTimer.Tick += new System.EventHandler(this.globalTimer_Tick);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 127);
            this.Controls.Add(this.restTxt);
            this.Controls.Add(this.restLbl);
            this.Controls.Add(this.breakPrdTxt);
            this.Controls.Add(this.breakPrdLbl);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.trayCntxMnu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayCntxMnu;
        private System.Windows.Forms.ToolStripMenuItem takeABreakNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label breakPrdLbl;
        private System.Windows.Forms.TextBox breakPrdTxt;
        private System.Windows.Forms.Label restLbl;
        private System.Windows.Forms.TextBox restTxt;
        private System.Windows.Forms.Timer globalTimer;

    }
}
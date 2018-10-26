namespace Relax
{
    partial class BlockForm
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
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.backGround = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.backGround)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTimer
            // 
            this.mainTimer.Interval = 1000;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // backGround
            // 
            this.backGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backGround.ImageLocation = "Resources\\bg.jpg";
            this.backGround.Location = new System.Drawing.Point(0, 0);
            this.backGround.Name = "backGround";
            this.backGround.Size = new System.Drawing.Size(445, 349);
            this.backGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.backGround.TabIndex = 2;
            this.backGround.TabStop = false;
            this.backGround.WaitOnLoad = true;
            // 
            // BlockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 349);
            this.ControlBox = false;
            this.Controls.Add(this.backGround);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BlockForm";
            this.Text = "BlockForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BlockForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BlockForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.backGround)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox backGround;
        private System.Windows.Forms.Timer mainTimer;

    }
}


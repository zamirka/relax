using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Relax
{
    public partial class SettingsForm : Form
    {
        private Boolean isShown;
        private Boolean settingsSucceeded;
        private Int32 periodTime;
        private Int32 restTime;
        private Int32 passedTime;

        private String PeriodTime
        {
            get
            {
                return periodTime.ToString();
            }
            set
            {
                Int32 temp;
                settingsSucceeded = false;
                if (Int32.TryParse(value, out temp))
                {
                    if (temp > 90 || temp < 1)
                    {
                        MessageBox.Show("Period must be positive integer less than 90 min","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        periodTime = 90;
                    }
                    else
                    {
                        periodTime = temp;
                        settingsSucceeded = true;
                    }
                    breakPrdTxt.Text = periodTime.ToString();
                }
                else
                {
                    MessageBox.Show("Period must be positive integer less than 90 min", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    periodTime = 90;
                    breakPrdTxt.Text = periodTime.ToString();
                }
            }
        }
        private String RestTime
        {
            get
            {
                return restTime.ToString();
            }
            set
            {
                Int32 temp;
                settingsSucceeded = false;
                if (Int32.TryParse(value, out temp))
                {
                    if (temp > periodTime || temp < 1)
                    {
                        MessageBox.Show("Rest time must be positive integer less than period", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        restTime = periodTime / 4 + 1;
                    }
                    else
                    {
                        restTime = temp;
                        settingsSucceeded = true;
                    }
                    restTxt.Text = restTime.ToString();
                }
                else
                {
                    MessageBox.Show("Rest time must be positive integer less than period", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    restTime = periodTime / 4 + 1;
                    restTxt.Text = restTime.ToString();
                }
            }
        }

        public SettingsForm()
        {
            InitializeComponent();
            isShown = true;
            PeriodTime = "50";
            RestTime = "10";
            passedTime = 0;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            RestTime = restTxt.Text;
            PeriodTime = breakPrdTxt.Text;
            if (settingsSucceeded)
            {
                Hide();
                isShown = false;
            }
            globalTimer.Start();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall || e.CloseReason == CloseReason.WindowsShutDown)
            {
                base.Close();
            }
            else
            {
                Hide();
                isShown = false;
                e.Cancel = true;
            }
        }
        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            if (isShown)
            {
                Hide();
                isShown = false;
            }
            else
            {
                Show();
                isShown = true;
            }
        }
        private void takeABreak()
        {
            globalTimer.Stop();
            passedTime = 0;
            BlockForm bf = new BlockForm();
            bf.startGlobalTimer += globalTimer.Start;
            bf.Block(restTime * 60);
        }
        private void globalTimer_Tick(object sender, EventArgs e)
        {
            if (passedTime >= periodTime*60)
            {
                takeABreak();
            }
            else
            {
                passedTime++;
                Int32 timeLeft = (periodTime*60 - passedTime)/60+1;
                if (timeLeft > 1)
                {
                    trayIcon.Text = String.Format("{0} minute(s) left to {1} minute(s) break", timeLeft, RestTime);
                }
                else
                {
                    trayIcon.Text = String.Format("Less than 1 minute left to {0} minute break", RestTime);
                }
                if (periodTime * 60 - passedTime == 60)
                {
                    trayIcon.BalloonTipText = trayIcon.Text = String.Format("1 minute left to {0} minute(s) break", RestTime);
                    trayIcon.ShowBalloonTip(500);
                }
            }
        }


        private void takeABreakNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            takeABreak();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            isShown = true;
        }
    }
}

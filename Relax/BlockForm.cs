using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Security.Principal;
using System.Diagnostics;
using System.Collections;

namespace Relax
{
    public partial class BlockForm : Form
    {
        private Int32 secondsPassed;
        private Int32 seconds;
        public ParentTimerStarter startGlobalTimer;

        public BlockForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            this.TopMost = true;
        }
        #region WinApi imported functions
        
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr SetWindowsHookExA(Int32 idHook, LowLevelKeyboardProcDelegate lpfn, IntPtr hMod, Int32 dwThreadId);
        
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean UnhookWindowsHookEx(IntPtr hHook);
        
        [DllImport("user32", EntryPoint = "CallNextHookEx", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hHook, Int32 nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam);
        
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(String lpModuleName);
        
        [DllImport("user32.dll")]
        private static extern Int32 FindWindow(String className, String windowText);
        
        [DllImport("user32.dll")]
        private static extern Int32 ShowWindow(Int32 hwnd, Int32 command);
        #endregion

        #region Helper constants, statics and structures
        private const Int32 SW_HIDE = 0;
        private const Int32 SW_SHOW = 1;
        public struct KBDLLHOOKSTRUCT
        {
            public Int32 vkCode;
            public Int32 scanCode;
            public Int32 flags;
            /*
             Bits Description 
             * 0 Specifies whether the key is an extended key, such as a function key or a key on the numeric keypad. 
             *      The value is 1 if the key is an extended key; otherwise, it is 0. 
             * 1-3 Reserved. 
             * 4 Specifies whether the event was injected. The value is 1 if the event was injected; otherwise, it is 0. 
             * 5 The context code. The value is 1 if the ALT key is pressed; otherwise, it is 0. 
             * 6 Reserved. 
             * 7 The transition state. The value is 0 if the key is pressed and 1 if it is being released. 
             * */

            public Int32 time;
            public Int32 dwExtraInfo;
        }
        public static IntPtr _hookId = IntPtr.Zero;
        public const Int32 WH_KEYBOARD_LL = 13;
        public const Int32 WM_KEYDOWN = 0x0100;
        public const Int32 WM_SYSKEYDOWN = 0x0104;
        #endregion

        #region Worker Methods
        public delegate IntPtr LowLevelKeyboardProcDelegate(Int32 nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam);
        public delegate void ParentTimerStarter();
        public IntPtr LowLevelKeyboardProc(Int32 nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam)
        {
            if (lParam.vkCode > 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
            {
                Boolean blnEat = false;
                blnEat = (((Keys)lParam.vkCode == Keys.Tab) && (Control.ModifierKeys == Keys.Alt)) |
                         (((Keys)lParam.vkCode == Keys.Escape) && (Control.ModifierKeys == Keys.Alt)) |
                         (((Keys)lParam.vkCode == Keys.F4) && (Control.ModifierKeys == Keys.Alt)) |
                         (((Keys)lParam.vkCode == Keys.Escape) && (Control.ModifierKeys == Keys.Control)) |
                         (((Keys)lParam.vkCode == Keys.LWin) || ((Keys)lParam.vkCode == Keys.RWin) || ((Keys)lParam.vkCode == Keys.Apps)) |
                         (((Keys)lParam.vkCode == Keys.Escape) && (Control.ModifierKeys == Keys.Control));
                if (blnEat == true)
                {
                    return (IntPtr)1;
                }
            }
            return (IntPtr)0;//CallNextHookEx(_hookId, nCode, wParam, ref lParam);
        }
        public void Block(Int32 seconds)
        {
            Opacity = 1;
            KillCtrlAltDelete();
            KillStartMenuAndCursor();
            KillHotKeys();
            secondsPassed = 0;
            this.seconds = seconds;
            mainTimer.Start();
            Show();
        }
        public void Unblock()
        {
            RestoreCtrlAltDelete();
            RestoreStartMenuAndCursor();
            RestoreHotKeys();
            mainTimer.Stop();
            Close();
        }
        private void mainTimer_Tick(object sender, EventArgs e)
        {
            if (secondsPassed >= seconds)
            {
                Unblock();
                Close();
            }
            secondsPassed++;
            Opacity = 1 - (Single)secondsPassed / seconds;
        }
        private void BlockForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (startGlobalTimer != null)
            {
                startGlobalTimer();
            }
        }
        #endregion
        
        #region Kill Methods
        public void KillStartMenuAndCursor()
        {
            Int32 hwnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow(hwnd, SW_HIDE);
            Cursor.Hide();
        }
        private static void KillCtrlAltDelete()
        {

            RegistryKey regkey;
            String keyValueInt32 = "1";
            String subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
            try
            {
                regkey = Registry.CurrentUser.CreateSubKey(subKey);
                regkey.SetValue("DisableTaskMgr", keyValueInt32);
                regkey.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void BlockForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
            //base.OnClosing(e);
        }
        private void KillHotKeys()
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                _hookId = SetWindowsHookExA(WH_KEYBOARD_LL, LowLevelKeyboardProc, GetModuleHandle(curModule.ModuleName), 0);
            }
            
        }
        #endregion
        
        #region Restore Methods
        private static void RestoreCtrlAltDelete()
        {
            try
            {
                String subKey = @"Software\Microsoft\Windows\CurrentVersion\Policies\System";
                RegistryKey rk = Registry.CurrentUser;
                RegistryKey sk1 = rk.OpenSubKey(subKey);
                if (sk1 != null)
                {
                    rk.DeleteSubKeyTree(subKey);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private static void RestoreStartMenuAndCursor()
        {
            Int32 hwnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow(hwnd, SW_SHOW);
            Cursor.Show();
        }
        private void RestoreHotKeys()
        {
            UnhookWindowsHookEx(_hookId);
        }
        #endregion
    }
}

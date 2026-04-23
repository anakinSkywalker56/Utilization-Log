using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace C7
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            EnsureStartup();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        private static void EnsureStartup()
        {
            string appName = "C7";
            string exePath = Application.ExecutablePath;

            RegistryKey key = Registry.CurrentUser.OpenSubKey(
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            object currentValue = key.GetValue(appName);

            if (currentValue == null || currentValue.ToString() != exePath)
            {
                key.SetValue(appName, exePath);
            }
        }
    }
}

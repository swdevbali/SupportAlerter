﻿using OpenPop.Pop3;
using SupportAlerter.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using SupportAlerterLibrary;

namespace SupportAlerter
{
    public class Program : Form
    {
        public const string EventLogName = "SMS Alert from eMail";
        [STAThread]
        static void Main()
        {
            RegistrySettings.getInstance(); //prepare registry
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new MainForm();
            Application.Run(new Program());
        }

        public static MainForm mainForm;
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;

        public Program()
        {
            // Create a simple tray menu with only one item.
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("&Settings", OnSettings);
            trayMenu.MenuItems[0].DefaultItem = true;
            trayMenu.MenuItems.Add("&View inbox", OnViewInbox);
            trayMenu.MenuItems.Add("&Show log", OnShowLog);
            trayMenu.MenuItems.Add("&About", OnAbout);
            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add("E&xit", OnExit);
            

            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            trayIcon = new NotifyIcon();
            trayIcon.Text = "SMS Alert from eMail";
            trayIcon.Icon = new Icon("icon/sms-32.ico");
            trayIcon.DoubleClick += new EventHandler(OnSettings); 
            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnSettings(object sender, EventArgs e)
        {
            Settings frmSettings = new Settings();
            frmSettings.ShowDialog();
            frmSettings.Dispose();
        }

        private void OnViewInbox(object sender, EventArgs e)
        {
            ViewInbox viewInbox = new ViewInbox();
            viewInbox.ShowDialog();
            viewInbox.Dispose();
        }

        private void OnShowLog(object sender, EventArgs e)
        {
            ShowLog showLog = new ShowLog();
            showLog.ShowDialog();
            showLog.Dispose();
        }

        private void OnAbout(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
            about.Dispose();
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                // Release the icon resource.
                trayIcon.Dispose();
            }

            base.Dispose(isDisposing);
        }
    }
}

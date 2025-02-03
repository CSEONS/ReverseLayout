using System;
using System.Windows.Forms;

namespace ReverseLayout
{
    public class TrayManager : IDisposable
    {
        private readonly NotifyIcon _trayIcon;
        private readonly MainForm _mainForm;

        public TrayManager(MainForm form)
        {
            _mainForm = form;

            _trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application, // Замените на свою иконку
                Text = "Reverse Layout",
                Visible = true
            };

            _trayIcon.DoubleClick += (s, e) => ShowSettings();

            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Настройки", null, (s, e) => ShowSettings());
            contextMenu.Items.Add("Выход", null, (s, e) => Application.Exit());
            _trayIcon.ContextMenuStrip = contextMenu;
        }

        private void ShowSettings()
        {
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        public void Dispose()
        {
            _trayIcon.Dispose();
        }
    }
}
using System;
using System.Threading;
using System.Windows.Forms;

namespace ReverseLayout
{
    public partial class MainForm : Form
    {
        private const int HOTKEY_ID = 1;
        private HotkeyManager _hotkeyManager;
        private TrayManager _trayManager;

        public MainForm()
        {
            InitializeComponent(); // Добавлен вызов инициализации компонентов
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            // Инициализация после компонентов формы
            _hotkeyManager = new HotkeyManager(Handle, HOTKEY_ID);
            _trayManager = new TrayManager(this);

            // Явно скрываем форму
            this.Visible = false;
            this.ShowIcon = false;
        }


        protected override void WndProc(ref Message m)
        {
            // Проверяем, инициализирован ли _hotkeyManager
            if (_hotkeyManager != null && _hotkeyManager.IsHotkeyMessage(ref m))
            {
                ConvertSelectedText();
            }
            base.WndProc(ref m);
        }

        private void ConvertSelectedText()
        {
            IDataObject? originalClipboard = Clipboard.GetDataObject();
            try
            {
                Clipboard.Clear();
                SendCtrlC();
                Thread.Sleep(100); // Даем время для копирования

                if (Clipboard.ContainsText())
                {
                    string text = Clipboard.GetText();
                    string converted = LayoutConverter.Convert(text);
                    Clipboard.SetText(converted);
                    SendCtrlV();
                }
            }
            finally
            {
                if (originalClipboard is not null)
                {
                    Clipboard.SetDataObject(originalClipboard);
                }
            }
        }

        private void SendCtrlC()
        {
            SendKeys.SendWait("^(c)");
        }

        private void SendCtrlV()
        {
            SendKeys.SendWait("^(v)");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _hotkeyManager?.Dispose(); // Проверка на null перед вызовом Dispose
            _trayManager?.Dispose();   // Проверка на null перед вызовом Dispose
            base.OnFormClosing(e);
        }
    }
}
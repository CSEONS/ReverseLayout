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
            InitializeComponent(); // �������� ����� ������������� �����������
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            // ������������� ����� ����������� �����
            _hotkeyManager = new HotkeyManager(Handle, HOTKEY_ID);
            _trayManager = new TrayManager(this);

            // ���� �������� �����
            this.Visible = false;
            this.ShowIcon = false;
        }


        protected override void WndProc(ref Message m)
        {
            // ���������, ��������������� �� _hotkeyManager
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
                Thread.Sleep(100); // ���� ����� ��� �����������

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
            _hotkeyManager?.Dispose(); // �������� �� null ����� ������� Dispose
            _trayManager?.Dispose();   // �������� �� null ����� ������� Dispose
            base.OnFormClosing(e);
        }
    }
}
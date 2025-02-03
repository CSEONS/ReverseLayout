using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ReverseLayout
{
    public class HotkeyManager : IDisposable
    {
        private const int MOD_CONTROL = 0x0002;
        private const int MOD_SHIFT = 0x0004;
        private const int WM_HOTKEY = 0x0312;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private readonly IntPtr _handle;
        private readonly int _hotkeyId;

        public HotkeyManager(IntPtr handle, int hotkeyId)
        {
            _handle = handle;
            _hotkeyId = hotkeyId;
            RegisterHotKey(_handle, _hotkeyId, MOD_CONTROL | MOD_SHIFT, (int)Keys.L);
        }

        public void Dispose()
        {
            UnregisterHotKey(_handle, _hotkeyId);
        }

        public bool IsHotkeyMessage(ref Message m)
        {
            return m.Msg == WM_HOTKEY;
        }
    }
}
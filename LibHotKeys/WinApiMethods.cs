using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibHotKeys
{
    public static class WinApiMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, uint vk);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    }
    [Flags]
    public enum KeyModifiers : uint
    {
        Alt= 0x0001,
        CONTROL=0x0002,
        NOREPEAT=0x4000,
       SHIFT=0x0004,
        WIN=0x0008
    }


    







}

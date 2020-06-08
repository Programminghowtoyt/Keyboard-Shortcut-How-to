using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibHotKeys
{
    public class HotKeyController
    {
        private static HotKeyController instance = null;

        int id = 1;

        public static HotKeyController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HotKeyController();

                }
                return instance;
            }
        }


        public List<HotKey> RegisteredHotKeys { get; set; } = new List<HotKey>();
        MessageListenerWindow window;
        IntPtr windowHandle = IntPtr.Zero;
        private HotKeyController()
        {
            window = new MessageListenerWindow(this);
            windowHandle = window.Handle;
        }

        public void RegisterHotKey(string Purpose, KeyModifiers modifiers, Keys vk, Action<HotKey> OnPressed)
        {
            HotKey key = RegisteredHotKeys.SingleOrDefault(o => o.Purpose == Purpose);

            if (key == null)
            {
                key = new HotKey() { Purpose = Purpose, id = id, fsModifiers = modifiers, vk = vk, OnPressed = OnPressed };
                bool issuccess = WinApiMethods.RegisterHotKey(windowHandle, key.id, key.fsModifiers, (uint)key.vk);
                if (!issuccess)
                {
                    key = null;
                    Win32Exception ex = new Win32Exception(Marshal.GetLastWin32Error());
                    if (ex.Message == "Hot key is already registered")
                    {
                        throw ex;
                    }
                }
                else
                {
                    RegisteredHotKeys.Add(key);
                    id++;
                }
            }
            else
            {
                throw new AlreadyMappedException(key);
            }
        }

        public void ReplaceHotKey(string Purpose, KeyModifiers modifiers,Keys vk, Action<HotKey> OnPressed)
        {
            HotKey key = RegisteredHotKeys.SingleOrDefault(o => o.Purpose == Purpose);
            if (key != null)
            {
                key.fsModifiers = modifiers;
                key.vk = vk;
                bool issuccess = WinApiMethods.RegisterHotKey(windowHandle, key.id, key.fsModifiers, (uint)key.vk);
                if (!issuccess)
                {
                    key = null;
                    Win32Exception ex = new Win32Exception(Marshal.GetLastWin32Error());
                    if (ex.Message == "Hot key is already registered")
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                throw new KeyNotFoundException(Purpose);
            }
            
        }

        public void UnRegisterHotKey(string Purpose)
        {
            HotKey key = RegisteredHotKeys.SingleOrDefault(o => o.Purpose == Purpose);
            if (key != null)
            {
                bool issuccess = WinApiMethods.UnregisterHotKey(this.windowHandle, key.id);
                if (!issuccess)
                {
                    Win32Exception ex = new Win32Exception(Marshal.GetLastWin32Error());

                    throw ex;

                }
                else
                {
                    RegisteredHotKeys.Remove(key);
                }
            }
            else
            {
               throw new KeyNotFoundException(Purpose);
            }
        }
        internal HotKey GetHotKeyById(int id)
        {
            return RegisteredHotKeys.SingleOrDefault(o => o.id == id);
        }
    }

    public class MessageListenerWindow : Form
    {
        const int hotkeyCapture = 0x0312;
        HotKeyController hotKeyController;
        public MessageListenerWindow(HotKeyController controller)
        {
            hotKeyController = controller;
        }
        protected override void WndProc(ref Message m)
        {
            if(m.Msg==hotkeyCapture)
            {
                int id = m.WParam.ToInt32();
                HotKey hotkey = hotKeyController.GetHotKeyById(id);
                hotkey.OnPressed(hotkey);
            }

            base.WndProc(ref m);
        }
    }
}

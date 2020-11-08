using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Npgg.VirtualInput
{

    public enum KeyboardAction : uint
    {
        KeyDown = 0x00,
        KeyUp = 0x02,
    }

    public class VirtualKeyboard
    {

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        public async Task KeyPress(VirtualKeys key, ushort waitTerm)
        {
            await Keydown(key, waitTerm);
            KeyUp(key);
        }

        public async Task Keydown(VirtualKeys key, ushort waitTerm = 0)
        {
            keybd_event((byte)key, 0, (uint)KeyboardAction.KeyDown, 1);
            await Task.Delay(waitTerm);
        }

        public void KeyUp(VirtualKeys key)
        {

        }

    }
}

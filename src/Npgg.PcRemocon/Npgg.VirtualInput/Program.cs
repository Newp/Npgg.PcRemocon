using System;
using System.Threading.Tasks;

namespace Npgg.VirtualInput
{
    class Program
    {
        static async Task Main(string[] args)
        {
            VirtualKeyboard keyboard = new VirtualKeyboard();

            await Task.Delay(1000);
            await keyboard.KeyPress(VirtualKeys.A, 100);
            await keyboard.KeyPress(VirtualKeys.B, 100);
            await keyboard.KeyPress(VirtualKeys.C, 100);
        }
    }
}

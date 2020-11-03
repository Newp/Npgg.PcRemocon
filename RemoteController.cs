using Npgg.ApiRouter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace WebApplication1
{
    [Controller("api/[controller]")]
    public class RemoteController
    {

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        [HttpGet]
        public object Get()
        {
            return new
            {
                msg = "hi"
            };
        }
    }
}

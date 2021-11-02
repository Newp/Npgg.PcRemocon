using Microsoft.AspNetCore.Components;
using Npgg.KeyboardMouseInvoker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Npgg.PcRemoconServer
{
    public class MouseComponent : ComponentBase
    {


        public async Task LeftClick()
        {
            Mouse.LeftDown();
            await Task.Delay(20);
            Mouse.LeftUp();
        }

        public async Task RightClick()
        {
            Mouse.RightDown();
            await Task.Delay(20);
            Mouse.RightUp();
        }



        protected int distance = 3;
       

    }
}

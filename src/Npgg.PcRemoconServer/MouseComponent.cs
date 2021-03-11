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
            ClearMove();
            Mouse.LeftDown();
            await Task.Delay(20);
            Mouse.LeftUp();
        }

        public async Task RightClick()
        {
            ClearMove();
            Mouse.RightDown();
            await Task.Delay(20);
            Mouse.RightUp();
        }



        protected int distance = 3;
       


        [Inject]
        private MouseService mouseService { get; set; }

        protected void SetMove(int x, int y) => mouseService.SetMove(x, y);
        protected void ClearMove() => mouseService.ClearMove();
    }
}

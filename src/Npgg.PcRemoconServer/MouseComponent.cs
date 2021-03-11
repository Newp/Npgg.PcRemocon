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
        int x;
        int y;

        Task run = null;
        protected void SetMove(int x, int y)
        {
            if (this.x == x && this.y == y)
            {
                ClearMove();
                return;
            }

            this.x = x;
            this.y = y;

            if (run == null)
            {
                run = Task.Run(Update);
            }
        }

        protected void ClearMove()
        {
            this.x = 0;
            this.y = 0;

        }

        async Task Update()
        {
            while (true)
            {
                if (x == 0 && y == 0)
                {
                    await Task.Delay(100);
                    continue;
                }

                Mouse.MovePosition(x, y);
                await Task.Delay(3);
            }
        }


        void OnMouseOver()
        {

        }
    }
}

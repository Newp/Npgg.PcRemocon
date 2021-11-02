using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgg.KeyboardMouseInvoker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Npgg.PcRemoconServer
{
    public class MouseComponent : ComponentBase
    {

        protected string text = "";
        DateTime click;
        bool isTouchDown = false;
        bool moved = false;
        protected void Mouse_Down(TouchEventArgs e)
        {
            text = "touch down";
            click = DateTime.Now;
            isTouchDown = true;
            moved = false;
            lastTouch = e;
        }

        TouchEventArgs lastTouch;
        protected async Task Mouse_Up(TouchEventArgs e)
        {
            isTouchDown = false;
            var diff = DateTime.Now - click;

            if (moved)
                return;

            if (diff.Milliseconds < 200)
            {
                await this.LeftClick();
                text = "click";
            }
            else
            {
                text = "drag?";
            }

        }

        protected void Mouse_Move(TouchEventArgs e)
        {
            if (isTouchDown == false)
                return;

            moved = true;

            text = "moving..";


            var source = lastTouch.TargetTouches.First();
            var dest = e.TargetTouches.First();

            var factor = 1.8;
            var moveX = (dest.ClientX - source.ClientX) * factor;
            var moveY = (dest.ClientY - source.ClientY) * factor;

            Mouse.MovePosition((int)moveX, (int)moveY);

            lastTouch = e;
        }

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

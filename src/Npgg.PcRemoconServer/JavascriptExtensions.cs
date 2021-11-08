using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Npgg.PcRemoconServer;

public static class JavascriptExtensions
{
    public static async Task ScrollTo(this IJSRuntime js, int y)
    {
        int x = 0;
        try
        {
            var option = new
            {
                top = y,
                left = x,
                behavior = "smooth"
            };

            var json = JsonConvert.SerializeObject(option);
            await js.InvokeVoidAsync($"window.scrollTo", option);
        }
        catch (System.Exception ex)
        {
            throw;
        }
    }


    public static ValueTask<bool> Confirm(this IJSRuntime jsRuntime, string message)
        => jsRuntime.InvokeAsync<bool>("confirm", message);
    public static ValueTask Alert(this IJSRuntime jsRuntime, string message)
        => jsRuntime.InvokeVoidAsync("alert", message);
}

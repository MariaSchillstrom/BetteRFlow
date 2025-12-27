using Microsoft.JSInterop;
using System.Text.Json;

namespace BetteRFlowWebApp.Components.Pages.BrfPages
{
    public partial class Brf
    {
        private string userName = "";

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                try
                {
                    var userJson = await JS.InvokeAsync<string>("localStorage.getItem", "user");
                    if (!string.IsNullOrEmpty(userJson))
                    {
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        var user = JsonSerializer.Deserialize<Dictionary<string, string>>(userJson, options);
                        if (user != null)
                        {
                            userName = user.ContainsKey("name") ? user["name"] : "";
                            await InvokeAsync(StateHasChanged);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fel: {ex.Message}");
                }
            }
        }
    }
}
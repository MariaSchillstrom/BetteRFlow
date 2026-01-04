using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BetteRFlowWebApp.Components.Pages.Admin
{
    public partial class BrfCreate
    {
        [SupplyParameterFromForm(FormName = "BrfCreateForm")]
        private BrfDto brfDto { get; set; } = new BrfDto();

        private bool isSubmitting = false;
        private bool success = false;
        private string errorMessage = "";

        private async Task HandleSubmit()
        {
            await JS.InvokeVoidAsync("console.log", "=== HandleSubmit STARTAR ===");

            isSubmitting = true;
            errorMessage = "";

            try
            {
                await JS.InvokeVoidAsync("console.log", "Skapar POST till API...");

                var http = ClientFactory.CreateClient("ApiClient");

                var response = await http.PostAsJsonAsync(
                    "api/Brf", brfDto);

                await JS.InvokeVoidAsync("console.log", "Response:", response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    success = true;
                    await Task.Delay(1500);
                    Navigation.NavigateTo("/admin/brf");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    errorMessage = $"Kunde inte skapa BRF: {error}";
                }
            }
            catch (Exception ex)
            {
                await JS.InvokeVoidAsync("console.log", "EXCEPTION:", ex.Message);
                errorMessage = $"Ett fel uppstod: {ex.Message}";
            }
            finally
            {
                isSubmitting = false;
            }
        }


        private void Cancel()
        {
            Navigation.NavigateTo("/admin");
        }
    }
}
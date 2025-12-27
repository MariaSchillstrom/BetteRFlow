using BetteRFlow.Shared.DTOs;

namespace BetteRFlowWebApp.Components.Pages.Admin
{
    public partial class RegisterAdmin
    {
        private RegisterDto registerModel { get; set; } = new()
        {
            Role = "Admin",
        };

        private string errorMessage = "";
        private bool success = false;
        private bool isSubmitting = false;

        private async Task HandleSubmit()
        {
            isSubmitting = true;
            errorMessage = "";
            bool shouldNavigate = false;

            try
            {
                var response = await Http.PostAsJsonAsync("api/auth/register", registerModel);

                if (response.IsSuccessStatusCode)
                {
                    success = true;
                    shouldNavigate = true;
                    await Task.Delay(1500);
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    errorMessage = $"Kunde inte skapa konto: {error}";
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"Ett fel uppstod: {ex.Message}";
            }
            finally
            {
                isSubmitting = false;
            }

            if (shouldNavigate)
            {
                Navigation.NavigateTo("/login");
            }
        }
    }
}
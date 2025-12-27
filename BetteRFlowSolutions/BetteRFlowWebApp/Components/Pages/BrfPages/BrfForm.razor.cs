using BetteRFlow.Shared.DTOs;
using Microsoft.JSInterop;
using System.Text.Json;

namespace BetteRFlowWebApp.Components.Pages.BrfPages
{
    public partial class BrfForm
    {
        private FormDto formModel { get; set; } = new();
        private string errorMessage = "";
        private bool success = false;
        private bool isSubmitting = false;

        private string userName = "";
        private string userEmail = "";
        private string UserRole = "";

        // NYA VARIABLER
        private bool showForm = false;
        private bool isEditMode = false;

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
                            userEmail = user.ContainsKey("email") ? user["email"] : "";
                            UserRole = user.ContainsKey("role") ? user["role"] : "";
                        }
                    }
                    await InvokeAsync(StateHasChanged);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fel: {ex.Message}");
                }
            }
        }

        private async Task HandleSubmit()
        {
            await JS.InvokeVoidAsync("console.log", "=== HandleSubmit START ===");
            isSubmitting = true;
            errorMessage = "";
            bool shouldNavigate = false;

            try
            {
                await JS.InvokeVoidAsync("console.log", "Försöker POST till api/formsubmission");
                var response = await Http.PostAsJsonAsync("api/formsubmission", formModel);
                await JS.InvokeVoidAsync("console.log", "POST klar, status:", response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    success = true;
                    shouldNavigate = true;
                    await Task.Delay(1500);
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    await JS.InvokeVoidAsync("console.log", "Error response:", error);
                    errorMessage = $"Kunde inte spara formulär: {error}";
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

            if (shouldNavigate)
            {
                Navigation.NavigateTo("/");
            }
        }

        // NYA METODER
        private void CreateNewForm()
        {
            formModel = new FormDto();
            isEditMode = false;
            showForm = true;
        }

        private async Task LoadExistingForm()
        {
            isEditMode = true;
            showForm = true;

            try
            {
                var response = await Http.GetAsync("api/formsubmission/search");
                if (response.IsSuccessStatusCode)
                {
                    var forms = await response.Content.ReadFromJsonAsync<List<FormDto>>();
                    if (forms != null && forms.Any())
                    {
                        formModel = forms.First();
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
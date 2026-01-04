using BetteRFlow.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using System.Text.Json;

namespace BetteRFlowWebApp.Components.Pages.BrfPages
{
    public partial class BrfForm    {
        

        private FormDto formModel = new();
        private string errorMessage = "";
        private bool success = false;
        private bool isSubmitting = false;

        private string userName = "";
        private string userEmail = "";
        private string userRole = "";

        private bool showForm = false;
        private bool isEditMode = false;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender) return;

            try
            {
                var userJson = await JS.InvokeAsync<string>("localStorage.getItem", "user");
                if (!string.IsNullOrWhiteSpace(userJson))
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var user = JsonSerializer.Deserialize<Dictionary<string, string>>(userJson, options);

                    if (user != null)
                    {
                        userName = user.GetValueOrDefault("name", "");
                        userEmail = user.GetValueOrDefault("email", "");
                        userRole = user.GetValueOrDefault("role", "");
                    }
                }

                await InvokeAsync(StateHasChanged);
            }
            catch
            {
                // ignore
            }
        }

        private async Task HandleSubmit()
        {
            isSubmitting = true;
            errorMessage = "";
            bool shouldNavigate = false;

            try
            {
                var http = ClientFactory.CreateClient("ApiClient");
                var response = await http.PostAsJsonAsync("api/formsubmission", formModel);

                if (response.IsSuccessStatusCode)
                {
                    success = true;
                    shouldNavigate = true;
                    await Task.Delay(1500);
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    errorMessage = $"Kunde inte spara formulär: {error}";
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
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
                var http = ClientFactory.CreateClient("ApiClient");
                var forms = await http.GetFromJsonAsync<List<FormDto>>("api/formsubmission/search");

                if (forms != null && forms.Any())
                {
                    formModel = forms.First();
                }
            }
            catch
            {
                // ignore
            }
        }
    }
}

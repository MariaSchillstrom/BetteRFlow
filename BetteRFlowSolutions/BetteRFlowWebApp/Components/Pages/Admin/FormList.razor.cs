using BetteRFlow.Shared.Models;

namespace BetteRFlowWebApp.Components.Pages.Admin
{
    public partial class FormList
    {
        private List<Form>? forms;
        private bool isLoading = true;
        private string errorMessage = "";

        protected override async Task OnInitializedAsync()
        {
            await LoadForms();
        }

        private async Task LoadForms()
        {
            isLoading = true;
            errorMessage = "";

            try
            {
                var response = await Http.GetAsync("api/formsubmission");

                if (response.IsSuccessStatusCode)
                {
                    forms = await response.Content.ReadFromJsonAsync<List<Form>>();
                }
                else
                {
                    errorMessage = $"Kunde inte hämta formulär. Status: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"Ett fel uppstod: {ex.Message}";
            }
            finally
            {
                isLoading = false;
            }
        }

        private void ViewDetails(int formId)
        {
            Navigation.NavigateTo($"/forms/{formId}");
        }
    }
}
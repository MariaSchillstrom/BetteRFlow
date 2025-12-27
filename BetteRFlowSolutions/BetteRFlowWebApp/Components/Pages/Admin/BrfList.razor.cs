using BetteRFlow.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;


namespace BetteRFlowWebApp.Components.Pages.Admin
{
    public partial class BrfList
    {
        private List<Brf>? brfList;
        private bool isLoading = true;
        private string errorMessage = "";

        protected override async Task OnInitializedAsync()
        {
            await LoadBrfs();
        }

        private async Task LoadBrfs()
        {
            isLoading = true;
            errorMessage = "";

            try
            {
                brfList = await Http.GetFromJsonAsync<List<Brf>>("https://localhost:7007/api/Brf");
            }
            catch (Exception ex)
            {
                errorMessage = $"Kunde inte ladda BRF:er: {ex.Message}";
            }
            finally
            {
                isLoading = false;
            }
        }

        private void CreateNew()
        {
            Navigation.NavigateTo("/admin/brf/create");
        }
    }
}
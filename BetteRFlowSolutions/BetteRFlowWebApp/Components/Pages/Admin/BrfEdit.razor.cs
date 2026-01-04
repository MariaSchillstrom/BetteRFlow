using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using BetteRFlow.Shared.DTOs;
using BetteRFlow.Shared.Models;

namespace BetteRFlowWebApp.Components.Pages.Admin
{
    public partial class BrfEdit
    {
        [Parameter]
        public int Id { get; set; }

        [Inject] public IHttpClientFactory ClientFactory { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; } = default!;

        private BrfDto brfDto = new();
        private bool isLoading = true;
        private bool isSubmitting = false;
        private bool success = false;
        private string errorMessage = "";

        protected override async Task OnInitializedAsync()
        {
            await LoadBrf();
        }

        private async Task LoadBrf()
        {
            isLoading = true;
            errorMessage = "";

            try
            {
                var http = ClientFactory.CreateClient("ApiClient");
                var brf = await http.GetFromJsonAsync<Brf>($"api/Brf/{Id}");

                if (brf != null)
                {
                    brfDto = new BrfDto
                    {
                        ForeningensNamn = brf.ForeningensNamn,
                        OrganisationsNummer = brf.OrganisationsNummer,
                        Gatuadress = brf.Gatuadress,
                        Postnummer = brf.Postnummer,
                        Ort = brf.Ort,
                        KontaktEmail = brf.KontaktEmail,
                        KontaktTelefon = brf.KontaktTelefon,
                        Hemsida = brf.Hemsida
                    };
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            finally
            {
                isLoading = false;
            }
        }

        private async Task HandleSubmit()
        {
            isSubmitting = true;
            errorMessage = "";

            try
            {
                var http = ClientFactory.CreateClient("ApiClient");
                var response = await http.PutAsJsonAsync($"api/Brf/{Id}", brfDto);

                if (response.IsSuccessStatusCode)
                {
                    success = true;
                    await Task.Delay(1000);
                    Navigation.NavigateTo("/admin/brf");
                }
                else
                {
                    errorMessage = await response.Content.ReadAsStringAsync();
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
        }

        private void Cancel()
        {
            Navigation.NavigateTo("/admin/brf");
        }
    }
}

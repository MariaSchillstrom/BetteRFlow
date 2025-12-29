using Microsoft.AspNetCore.Components;

namespace BetteRFlowWebApp.Components.Pages.Admin
{
    public partial class BrfEdit
    {
        [Parameter]
        public int Id { get; set; }

        private BrfDto brfDto = new BrfDto();
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
                var brf = await Http.GetFromJsonAsync<Brf>($"https://localhost:7007/api/Brf/{Id}");

                if (brf != null)
                {
                    brfDto = new BrfDto
                    {
                        BrfNamn = brf.BrfNamn,
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
                errorMessage = $"Kunde inte ladda BRF: {ex.Message}";
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
                var response = await Http.PutAsJsonAsync($"https://localhost:7007/api/Brf/{Id}", brfDto);

                if (response.IsSuccessStatusCode)
                {
                    success = true;
                    await Task.Delay(1500);
                    Navigation.NavigateTo("/admin/brf");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    errorMessage = $"Kunde inte uppdatera BRF: {error}";
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
        }

        private void Cancel()
        {
            Navigation.NavigateTo("/admin/brf");
        }
    }
}
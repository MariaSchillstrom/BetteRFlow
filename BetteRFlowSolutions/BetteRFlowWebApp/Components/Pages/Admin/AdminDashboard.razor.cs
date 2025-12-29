using Microsoft.AspNetCore.Components;


namespace BetteRFlowWebApp.Components.Pages.Admin
{
    public partial class AdminDashboard
    {
        private void GoToCreateBrf()
        {
            Navigation.NavigateTo("/admin/brf/create");
        }

        private void GoToBrfList()
        {
            Navigation.NavigateTo("/admin/brf");
        }

        private void GoToFormList()
        {
            Navigation.NavigateTo("/formList");
        }

        private void GoToImport()
        {
            Navigation.NavigateTo("/admin/brf/import");

        }
        private void GoToAvvikelser() => Navigation.NavigateTo("/admin/avvikelser");
    }
}

    

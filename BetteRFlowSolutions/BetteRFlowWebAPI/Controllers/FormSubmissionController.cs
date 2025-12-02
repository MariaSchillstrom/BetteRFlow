using Microsoft.AspNetCore.Mvc;
using BetteRFlow.Shared.Models;

namespace BetteRFlowWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormSubmissionController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<FormSubmission> GetAllFormSubmissions()
        {
            // TODO: Implementera senare
            return new List<FormSubmission>();
        }
    }
}
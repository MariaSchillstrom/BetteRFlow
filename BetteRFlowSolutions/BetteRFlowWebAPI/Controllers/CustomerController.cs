using Microsoft.AspNetCore.Mvc;
using BetteRFlow.Shared.Models;

namespace BetteRFlowWebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    [HttpPut("{id}")]
public async Task<ActionResult<Customer>> UpdateCustomer(int id, [FromBody] Customer updatedCustomer)
{
    // Skriv denna rad (metoden finns inte - blir röd!)
    if (!IsValidCustomer(updatedCustomer))
    {
        return BadRequest("Ogiltig customer-data");
    }

        if (id != updatedCustomer.ID)
        {
            return BadRequest("ID matchar inte");
        }

        updatedCustomer.CreatedAt = DateTime.UtcNow;

        return Ok(updatedCustomer);


    } 

    private bool IsValidCustomer(Customer updatedCustomer)
    {
        if (updatedCustomer == null) return false;
        if (string.IsNullOrEmpty(updatedCustomer.BusinessName)) return false;
        if (string.IsNullOrEmpty(updatedCustomer.CustomerNumber)) return false;
        return true;
    }
}

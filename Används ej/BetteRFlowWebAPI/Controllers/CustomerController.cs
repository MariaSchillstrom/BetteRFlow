using Microsoft.AspNetCore.Mvc;
using BetteRFlow.Shared.Models;

namespace BetteRFlowWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        // ============================================
        // UpdateCustomer - Uppdatera customer
        // ============================================

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(int id, [FromBody] Customer updatedCustomer)
        {
            // STEG 1: Validera input
            if (!IsValidCustomer(updatedCustomer))
            {
                return BadRequest("Ogiltig customer-data");
            }

            // STEG 2: Kolla att id matchar
            if (id != updatedCustomer.Id)
            {
                return BadRequest("ID matchar inte");
            }

            // STEG 3: Uppdatera i databas (hårdkoda för nu)
            updatedCustomer.CreatedAt = DateTime.UtcNow;

            // STEG 4: Returnera Customer (ingen DTO)
            return Ok(updatedCustomer);
        }

        // ============================================
        // GetCustomerById - Hämta en customer
        // ============================================

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            // STEG 1: Validera id
            if (id <= 0)
            {
                return BadRequest("Ogiltigt ID");
            }

            // STEG 2: Hämta från databas (hårdkoda för nu)
            var customer = new Customer
            {
                Id = id,
                BusinessName = "Mäklarhuset Test",
                CustomerNumber = "M001",
                CreatedAt = DateTime.UtcNow
            };

            // STEG 3: Kolla att customer finns
            if (customer == null)
            {
                return NotFound($"Customer med ID {id} hittades inte");
            }

            return Ok(customer);
        }

        // ============================================
        // GetAllCustomers - Hämta alla customers
        // ============================================

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            // STEG 1: Hämta från databas (hårdkoda för nu)
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    BusinessName = "Mäklarhuset",
                    CustomerNumber = "M001",
                    CreatedAt = DateTime.UtcNow
                },
                new Customer
                {
                    Id = 2,
                    BusinessName = "Fastighetsbyrån",
                    CustomerNumber = "M002",
                    CreatedAt = DateTime.UtcNow
                }
            };

            // STEG 2: Kolla att det finns customers
            if (customers == null || !customers.Any())
            {
                return Ok(new List<Customer>());
            }

            return Ok(customers);
        }

        // ============================================
        // DeleteCustomerById - Ta bort en customer
        // ============================================

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomerById(int id)
        {
            // STEG 1: Validera id
            if (id <= 0)
            {
                return BadRequest("Ogiltigt ID");
            }

            // STEG 2: Kolla att customer finns (hårdkoda för nu)
            // TODO: Senare via repository/DbContext
            var customerExists = true; // Simulerar att customer finns

            if (!customerExists)
            {
                return NotFound($"Customer med ID {id} hittades inte");
            }

            // STEG 3: Returnera 204 No Content (standard för lyckad DELETE)
            return NoContent();
        }

        // ============================================
        // PRIVATE HELPER-METODER
        // ============================================

        private bool IsValidCustomer(Customer updatedCustomer)
        {
            if (updatedCustomer == null) return false;
            if (string.IsNullOrEmpty(updatedCustomer.BusinessName)) return false;
            if (string.IsNullOrEmpty(updatedCustomer.CustomerNumber)) return false;
            return true;
        }
    }
}
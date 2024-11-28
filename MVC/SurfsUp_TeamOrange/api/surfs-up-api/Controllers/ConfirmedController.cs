using Microsoft.AspNetCore.Mvc;
using surfs_up_api.Models;

namespace surfs_up_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfirmedController : ControllerBase
    {
        private readonly ShoppingCart _shoppingCart = new ShoppingCart();

        // POST: api/confirmed
        [HttpPost("confirm")]
        public IActionResult ConfirmOrder([FromBody] CustomerVM customerData)
        {
            if (customerData == null)
            {
                return BadRequest(new { message = "Invalid customer data" });
            }

            // Opretter en Customer-objekt med de data, der er modtaget
            var customer = new Customer
            {
                FirstName = customerData.FirstName,
                LastName = customerData.LastName,
                Email = customerData.Email,
                PhoneNumber = customerData.PhoneNumber,
                Address = customerData.Address,
                ZipCode = customerData.ZipCode,
                City = customerData.City
            };

            // Henter varerne fra indkøbskurven
            List<ShoppingCartItem> items = _shoppingCart.GetItems();

            // Opretter en ConfirmedViewModel-objekt med customer og items
            var model = new OrderConfirmedVM
            {
                Customer = customer,
                Items = items
            };

            // Returnerer modellen som JSON-respons
            return Ok(model);
        }

        // GET: api/confirmed/order-confirmed
        [HttpGet("order-confirmed")]
        public IActionResult OrderConfirmed()
        {
            return Ok(new { message = "Order has been confirmed" });
        }
    }

    // ViewModel til at modtage kundedata
    public class CustomerVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
    }
}

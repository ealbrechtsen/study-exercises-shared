using Microsoft.AspNetCore.Mvc;
using surfs_up_api.Models;
using System;
using System.Collections.Generic;

namespace surfs_up_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShippingController : ControllerBase
    {
        private readonly ShoppingCart _shoppingCart;

        // Brug dependency injection til at få fat i shoppingkurven
        public ShippingController(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart ?? new ShoppingCart(); // Sørg for at _shoppingCart er initialiseret
        }

        // GET: api/shipping
        [HttpGet]
        public IActionResult GetItems()
        {
            // Hent varer fra indkøbskurven
            var items = _shoppingCart.GetItems();
            if (items == null || items.Count == 0)
            {
                return NotFound(new { message = "Shopping cart is empty" });
            }

            // Returner indholdet af indkøbskurven som JSON
            return Ok(items);
        }

        // POST: api/shipping
        [HttpPost]
        public IActionResult UpdateShippingDates([FromBody] ShippingDateVM shippingDates)
        {
            // Tjek om modellen er gyldig
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Opdater afhentnings- og afleveringsdato i indkøbskurven
            _shoppingCart.PickUpDate = shippingDates.PickUpDate;
            _shoppingCart.ReturnDate = shippingDates.ReturnDate;

            // Hent opdaterede varer fra indkøbskurven
            var updatedItems = _shoppingCart.GetItems();

            // Returner opdaterede varer som JSON
            return Ok(new { items = updatedItems, pickUpDate = _shoppingCart.PickUpDate, returnDate = _shoppingCart.ReturnDate });
        }
    }

    // ViewModel til at modtage afhentnings- og afleveringsdatoer
    public class ShippingDateVM
    {
        public DateTime PickUpDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}

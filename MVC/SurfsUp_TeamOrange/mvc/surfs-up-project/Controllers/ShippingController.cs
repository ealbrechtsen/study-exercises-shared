using Microsoft.AspNetCore.Mvc;
using surfs_up_project.Models;
using System;

namespace surfs_up_project.Controllers
{
    public class ShippingController : Controller
    {
        private readonly ShoppingCart _shoppingCart;

        // Brug dependency injection til at få fat i shoppingkurven
        public ShippingController(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart ?? new ShoppingCart(); // Sørg for at _shoppingCart er initialiseret
        }

        // GET: Shipping/Index
        public IActionResult Index()
        {
            // Hent varer fra indkøbskurven
            var items = _shoppingCart.GetItems();
            return View(items); // Returner til visning
        }

        // POST: Shipping/Index
        [HttpPost]
        public IActionResult Index(DateTime pickUpDateTime, DateTime returnDateTime)
        {
            // Tjek om modelstate er gyldig
            if (!ModelState.IsValid)
            {
                // Hvis ikke gyldig, vis den samme visning med fejlmeddelelser
                var items = _shoppingCart.GetItems();
                return View(items); // Returner indholdet af indkøbskurven og vis eventuelle fejl
            }

            // Opdater afhentnings- og afleveringsdato i indkøbskurven
            _shoppingCart.PickUpDate = pickUpDateTime;
            _shoppingCart.ReturnDate = returnDateTime;

            // Hent opdaterede varer fra indkøbskurven
            var updatedItems = _shoppingCart.GetItems();
            return View(updatedItems); // Returner til visning med opdaterede data
        }
    }
}

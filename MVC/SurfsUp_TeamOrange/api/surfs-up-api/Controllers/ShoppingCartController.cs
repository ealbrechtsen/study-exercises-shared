using Microsoft.AspNetCore.Mvc;
using surfs_up_api.Models;
using System.Collections.Generic;

namespace surfs_up_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private static ShoppingCart _shoppingCart = new ShoppingCart();

        // GET: api/shoppingcart
        [HttpGet]
        public IActionResult GetCartItems()
        {
            // Hent varer fra indkøbskurven
            List<ShoppingCartItem> items = _shoppingCart.GetItems();
            if (items == null || items.Count == 0)
            {
                return NotFound(new { message = "Shopping cart is empty" });
            }

            // Returner indholdet af indkøbskurven som JSON
            return Ok(items);
        }

        // POST: api/shoppingcart/add
        [HttpPost("add")]
        public IActionResult AddToCart(int productId)
        {
            var product = ProductRepository.GetProductById(productId);
            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            // Tilføj produktet til indkøbskurven
            _shoppingCart.AddItem(product);

            // Returner opdateret liste over varer
            List<ShoppingCartItem> items = _shoppingCart.GetItems();
            return Ok(items);
        }

        // POST: api/shoppingcart/remove
        [HttpPost("remove")]
        public IActionResult RemoveFromCart(int id)
        {
            // Fjern vare fra indkøbskurven
            _shoppingCart.DeleteItem(id);

            // Returner opdateret liste over varer
            List<ShoppingCartItem> items = _shoppingCart.GetItems();
            if (items == null || items.Count == 0)
            {
                return NotFound(new { message = "No items in the cart" });
            }

            return Ok(items);
        }
    }
}

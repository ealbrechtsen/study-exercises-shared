using Microsoft.AspNetCore.Mvc;
using surfs_up_project.Models;
using System.Collections.Generic;

namespace surfs_up_project.Controllers
{
    public class ShoppingCartController : Controller
    {
        private static ShoppingCart _shoppingCart = new ShoppingCart();

        public IActionResult Index()
        {
            List<ShoppingCartItem> items = _shoppingCart.GetItems();
            return View(items); // Sørg for, at din view også bruger List<ShoppingCartItem>
        }

        [HttpPost]
        public ActionResult AddToCart(int productId)
        {
            var product = ProductRepository.GetById(productId);
            if (product != null)
            {
                _shoppingCart.AddItem(product); // Tilføj produktet uden mængde
            }

            List<ShoppingCartItem> items = _shoppingCart.GetItems();
            return View("Index", items);
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            _shoppingCart.DeleteItem(id);
            List<ShoppingCartItem> items = _shoppingCart.GetItems();
            return View("Index", items);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using surfs_up_project.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace surfs_up_project.Controllers
{
    public class ConfirmedController : Controller
    {
        private ShoppingCart _shoppingCart = new ShoppingCart();

        public IActionResult Index(string firstName, string lastName, string email, string phoneNumber, string address, int zipCode, string city)
        {
            // Opretter en Customer-objekt med de data, der er sendt til metoden
            var customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address,
                ZipCode = zipCode,
                City = city
            };

            // Opretter en Product-objekt med eksempeldata (du skal tilpasse dette efter dine behov)
            List<ShoppingCartItem> items = _shoppingCart.GetItems();

            // Opretter en ConfirmedViewModel-objekt og tildeler customer og product
            var model = new OrderConfirmedVM
            {
                Customer = customer,
                Items = items
            };

            // Sender modellen til viewet
            return View(model);
        }
        
        public IActionResult OrderConfirmed () 
        {
            return View();
        }
    }
}

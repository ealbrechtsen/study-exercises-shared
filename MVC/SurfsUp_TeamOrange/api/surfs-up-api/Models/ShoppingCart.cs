using System.Collections.Generic;
using System.Linq;

namespace surfs_up_api.Models
{
    public class ShoppingCart
    {
        private List<ShoppingCartItem> _items;

        public ShoppingCart()
        {
            _items = new List<ShoppingCartItem>();
        }

        // Egenskaber til at gemme afhentnings- og afleveringsdatoer
        public DateTime PickUpDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public void AddItem(Product product)
        {
            // Tjekker om produktet allerede er i indkøbskurven
            var existingItem = _items.FirstOrDefault(x => x.Product.ProductId == product.ProductId);
            if (existingItem == null)
            {
                // Hvis produktet ikke findes, tilføj det som et nyt item
                var maxId = _items.Any() ? _items.Max(x => x.Id) : 0; // Tjekker om listen har elementer
                var item = new ShoppingCartItem(maxId + 1, product); // Tilføj med en mængde på 1
                _items.Add(item);
            }
            // Hvis produktet allerede findes, gør ingenting (eller håndter det på en anden måde, hvis nødvendigt)
        }

        public List<ShoppingCartItem> GetItems()
        {
            return _items; // Returnerer listen over indkøbsvare
        }

        public void DeleteItem(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _items.Remove(item); // Fjerner varen fra listen
            }
        }
    }
}

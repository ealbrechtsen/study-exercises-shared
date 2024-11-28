namespace surfs_up_api.Models
{    
    public static class ProductRepository //CRUD 
    {

        /*
         * 
         *              LAV NY CRUD, LAV EN CRONTROLLER ISTEDET 
         * 
        */
        private static List<Product> _products = new List<Product>() {
            new Product(1, "The Minilog", "/images/the_minilog.webp", 6, 21, 2.75, 38.8, "Shortboard", 565),
            new Product(2, "The Wide Glider", "/images/the_wide_glider.webp", 7.1, 21.75, 2.75, 44.16, "Funboard", 685),
            new Product(3, "The Golden Ratio", "/images/the_golden_ratio.webp", 6.3, 21.85, 2.9, 43.22, "Funboard", 695),
            new Product(4, "Mahi Mahi", "/images/mahi_mahi.webp", 5.4, 20.75, 2.3, 29.39, "Fish", 645)
        };

        public static void AddProduct(Product product) //CREATE 
        {
            var maxId = _products.Max(x => x.ProductId);
            product.ProductId = maxId + 1;//SER IGENNEM LISTEN OG FINDER MAX OG
                                          //TILFØJER MED 1 NÅR EN NY CATEGORY SKAL TILFØJES 
            _products.Add(product);//NY cATEGORY BLIVER TILFØJET 
        }

        public static List<Product> GetProducts() => _products;//READ

        public static Product? GetProductById(int? productId)//READ BY ID 
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)//KONTROLLER OM CATEGORY BLEV FUNDET 
            {
                return product; // Her blev der slettet så der ikke længere bliver oprettet en kopi. (ret tilbage hvis det giver fejl)
            }
            return null;//HVIS INGEN CATEGORY BLEV FUNDET RETURNERES NULL
        }

        public static void UpdateProduct(int productId, Product product)//UDPATE 
        {
            if (productId != product.ProductId) return; //Sikre sig at id´et er det rigtige 

            var productToUpdate = GetProductById(productId);//Henter den Category der skal opdateres 
            if (productToUpdate != null)//kontroller om den category der skal opdateres findes 
            {
                //Hvis den blev fundet opdateres disse parametre 
                productToUpdate.Name = product.Name;
                productToUpdate.Length = product.Length;
                productToUpdate.Width = product.Width;
                productToUpdate.Thickness = product.Thickness;
                productToUpdate.Volume = product.Volume;
                productToUpdate.Type = product.Type;
                productToUpdate.Price = product.Price;
            }
        }

        public static void DeleteProduct(int productId) // Metode til at slette en kategori baseret på dens ID
        {
            // Finder den første kategori i listen _categories, hvor CategoryId matcher det angivne categoryId.
            // Hvis der ikke findes en kategori, vil 'category' blive sat til null.
            var product = _products.FirstOrDefault(x => x.ProductId == productId);

            // Tjekker om kategorien blev fundet.
            if (product != null)
            {
                // Hvis kategorien blev fundet, fjernes den fra _categories-listen.
                _products.Remove(product); // Fjerner kategorien fra listen
            }
            // Hvis kategorien ikke findes, sker der ingenting.
        }

    }   
}

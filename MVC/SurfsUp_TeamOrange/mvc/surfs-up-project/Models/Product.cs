namespace surfs_up_project.Models
{
    public abstract class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public double Price { get; set; }

        public Product(string name, string imagePath, double price)
        {
            Name = name;
            ImagePath = imagePath;
            Price = price;
        }
    }
}

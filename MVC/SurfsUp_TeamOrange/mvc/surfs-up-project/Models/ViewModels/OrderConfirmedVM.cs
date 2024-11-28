namespace surfs_up_project.Models

{
    public class OrderConfirmedVM
    {
        public Customer Customer { get; set; }
        public List<ShoppingCartItem> Items { get; set;}
    }
}


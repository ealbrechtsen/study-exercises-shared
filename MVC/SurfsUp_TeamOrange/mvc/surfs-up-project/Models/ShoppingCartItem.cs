using surfs_up_project.Models;

public class ShoppingCartItem
{
    public int Id { get; private set; }
    public Board Product { get; private set; }


    // Ingen Quantity-felt, da vi kun tillader én af hver slags
    public ShoppingCartItem(int id, Board product)
    {
        Id = id;
        Product = product;
    }
}

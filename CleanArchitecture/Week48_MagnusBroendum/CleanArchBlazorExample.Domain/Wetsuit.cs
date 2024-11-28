using System.ComponentModel.DataAnnotations;

namespace CleanArchBlazorExample.Domain
{
    public class Wetsuit : Product
    {
        [Required]
        public Gender Gender { get; set; }

        [Required]
        public int Size { get; set; }

        public Wetsuit(string name, string imagePath, double price, Gender gender, int size) : base(name, imagePath, price)
        {
            
            Gender = gender;
            Size = size;
        }
    }
}

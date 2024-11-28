using System.ComponentModel.DataAnnotations;

namespace surfs_up_project.Models
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

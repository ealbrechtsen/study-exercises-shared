using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace surfs_up_api.Models
{
    public class AppUser:IdentityUser
    {
        [StringLength(100)]
        [MaxLength(100)]
        [Required]
        public string? FirstName { get; set; }
       [StringLength(100)]
        [MaxLength(100)]
        [Required]
        public string? LastName { get; set; }
        
        public string? Address { get; set; }
        [Required]
        public string? ZipCode { get; set; }
        [StringLength(100)]
        [MaxLength(100)]
        [Required]
        public string? City { get; set; }


    }
}

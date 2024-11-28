using System.ComponentModel.DataAnnotations;

namespace surfs_up_project.Models.ViewModels
{
    public class RegisterVM
    {
        public int customerId { get; set; }
        [Required(ErrorMessage = "Indtast Navn")]
        [Display(Name = "Navn")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Indtast Efternavn")]
        [Display(Name = "Efternavn")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Indtast Brugernavn")]
        [Display(Name = "Brugernavn")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Indtast E-mail")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Indtast Adgangskode")]
        [DataType(DataType.Password)]
        [Display(Name = "Adgangskode")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage ="Adgangskode skal være ens")]
        [DataType(DataType.Password)]
        [Display(Name = "Bekræft adgangskode")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Indtast Adresse")]
        [Display(Name = "Adresse")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Indtast Postnummer")]
        [Display(Name = "Postnummer")]
        [MaxLength(4)]
        public string? ZipCode { get; set; }
        [Required(ErrorMessage = "Indtast By")]
        [Display(Name = "By")]
        public string? City { get; set; }



    }
}

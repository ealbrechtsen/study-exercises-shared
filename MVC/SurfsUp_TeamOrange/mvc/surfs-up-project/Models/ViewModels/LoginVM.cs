using System.ComponentModel.DataAnnotations;

namespace surfs_up_project.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Indtast et gyldig brugernavn")]
        [Display(Name ="Brugernavn")]
        public string? UserName { get; set; }

        [Required(ErrorMessage ="Indtast en gyldig adgangskode")]
        [DataType(DataType.Password)]
        [Display(Name = "Adgangskode")]
        public string? Password { get; set; }

        [Display(Name ="Husk mig")]
        public bool RememberMe { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TBWeb.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña actual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva contraseña")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar la nueva contraseña")]
        [Compare("NewPassword", ErrorMessage = "La nueva contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "¿Recordar cuenta?")]
        public bool RememberMe { get; set; }
    }


    public class RegisterAgencyViewModel
    {
        [Required]
        [Display(Name = "Agency name")]
        public string AgencyName { get; set; }

        [Required]
        [Display(Name = "Registry number")]
        public int RegistryNumber { get; set; }

        [Required]
        [Display(Name = "Adress")]
        public string Adress { get; set; }

        [Required]
        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Agency Phone")]
        public int AgencyPhone { get; set; }

        [Required]
        [Display(Name = "Agency Phone 2")]
        public int AgencyPhone2 { get; set; }

        [Required]
        [Display(Name = "Extension")]
        public int Extension { get; set; }

        [Required]
        [Display(Name = "Extension 2")]
        public int Extension2 { get; set; }

        [Required]
        [Display(Name = "Web Page")]
        public string WebPage { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Email (User)")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Invalido")]
        public string UserEMail { get; set; }

        [Required]
        [Display(Name = "ConfirmEmail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Invalido")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Caribe / Playa / Verano")]
        public bool DestinoCaribe { get; set; }

        [Display(Name = "Ski / Invierno")]
        public bool SkiInvierno { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        [Display(Name = "Adress")]
        public string Adress { get; set; }

        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }

        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [Display(Name = "Estado")]
        public string State { get; set; }

        [Display(Name = "Pais")]
        public string Country { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Celular")]
        public string CelPhone { get; set; }


        [Required]
        [Display(Name = "Email (User)")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Invalido")]
        public string UserEMail { get; set; }

        [Required]
        [Display(Name = "ConfirmEmail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Invalido")]
        public string ConfirmEmail { get; set; }
    }




}

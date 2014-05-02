using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TBWeb.Models
{
    public class Agency
    {
        [Key]
        public int AgencyId { get; set; }

        [Required]
        [Display(Name = "Razon Social")]
        public string Name { get; set; }
 
        public int Ranking { get; set; }

            [Required]
        [Display(Name = "Numero de Registro")]
        public int RegistryNumber { get; set; }

            [Required]
            [Display(Name = "Numero de CUIT")]
            public string CUIT { get; set; }

        [Required]
        [Display(Name = "Direccion")]
        public string Adress { get; set; }

        [Required]
        [Display(Name = "Codigo Postal")]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Ciudad")]
        public virtual City City { get; set; }
        public virtual int CityId { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public virtual State State { get; set; }
        public virtual int StateId { get; set; }

        [Required]
        [Display(Name = "Pais")]
        public virtual Country Country { get; set; }
        public virtual int CountryId { get; set; }

        [Required]
        [Display(Name = "Celular")]
        public int AgencyPhone { get; set; }

        [Display(Name = "Telefono")]
        public int AgencyPhone2 { get; set; }

        //[Display(Name = "Ext")]
        //public int Extension { get; set; }

        //[Display(Name = "Ext")]
        //public int Extension2 { get; set; }

        [Display(Name = "Web Page")]
        public string WebPage { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Clave")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar clave")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Invalido")]
        public string EMail { get; set; }

        [Required]
        [Display(Name = "Confirmar Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Invalido")]
        public string ConfirmEmail { get; set; }



    public Agency()
    {
        Products = new List<Product>();
        Destinations = new List<Destination>();
        CustomerProfiles = new List<CustomerProfile>();
        PaymentMethods = new List<PaymentMethod>();
    }
        public  List<Product> Products { get; set; }
        public  List<Destination> Destinations { get; set; }
        //public  List<City> SalesZones { get; set; }
        public  List<CustomerProfile> CustomerProfiles { get; set; }
        public int PriceRangeFrom { get; set; }
        public int PriceRangeTo { get; set; }
        public  List<PaymentMethod> PaymentMethods { get; set; }

        public virtual int MemberCategoryId { get; set; }
        public virtual MemberCategory MemberCategory { get; set; }
    }

    public class Destination
    {
        [Key]
        public int DestinationId { get; set; }
        public string Name { get; set; }

    }


    public class Continent
    {
        [Key]
        public int ContinentId { get; set; }
        public string Name { get; set; }
        public Boolean IsDefault { get; set; }
    
    }
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }

        public int ContinentId { get; set; }
        public virtual Continent Continent { get; set; }

        public List<State> States { get; set; }

        public Boolean IsDefault { get; set; }

    }

    public class Region {
        [Key]
        public int RegionId { get; set; }
        public string Name { get; set; }
        public int LanguageId { get; set; }

        public Boolean IsDefault { get; set; }

    }
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string Name { get; set; }

        public  int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int LanguageId { get; set; }

        public  List<City> Cities { get; set; }

        public Boolean IsDefault { get; set; }
    }

    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }

        public  int StateId { get; set; }
        public virtual State State { get; set; }


      public string TimeZone { get; set; }
        public int Region { get; set; }
        public int Population { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string StateCountry { get; set; }

        public Boolean IsDefault { get; set; }
    }

    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }

        public List<Agency> Agencies { get; set; }

    }
    
    public class CustomerProfile
    {
        [Key]
        public int CustomerProfileId { get; set; }
        public string Name { get; set; }

        public List<Agency> Agencies { get; set; }
    }
    public class PaymentMethod
	{
        [Key]
        public int PaymentMethodId { get; set; }
        public string Name { get; set; }

        public List<Agency> Agencies { get; set; }
		
	}
    public class MemberCategory 
    {
        [Key]
        public int MemeberCategoryId { get; set; }
        public string Name { get; set; }


    }
}





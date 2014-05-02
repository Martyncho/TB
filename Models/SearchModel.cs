using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TBWeb.Models
{

    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        
        public string Mail { get; set; }


        [Required]
        public string PostalCode { get; set; }

        [Display(Name = "Ciudad")]
        public virtual City City { get; set; }
        public virtual int CityId { get; set; }

        [Display(Name = "Estado")]
        public virtual State State { get; set; }
        public virtual int StateId { get; set; }

        [Display(Name = "Pais")]
        public virtual Country Country { get; set; }
        public virtual int CountryId { get; set; }

        [Required]
        public string CelPhone { get; set; }

        public string Adress { get; set; }

    }


    public class Trip
    {
        // Primary key, and one-to-many relation with Customer
        [Key]
        public int TripId { get; set; }
        
        public virtual int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        // Properties for this Trip
        public string Category { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public bool IsFinished { get; set; } 
        public DateTime PostDate { get; set; }
        public int DurationDays { get; set; }
    }


    public class AgencyUser
    {
        [Key]
        public int AgencyUserId { get; set; }
        public virtual Agency Agency { get; set; }
        public virtual int AgencyId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string City { get; set; }
        public int Ranking { get; set; }
    }

    public class Bid
    {
        // Primary key, and one-to-many relation with Customer
        [Key]
        public int BidId { get; set; }
        public virtual int TripId { get; set; }
        public virtual Trip Trip { get; set; }

        // Properties for this Trip
        public int BidTripNumber { get; set; }
        public DateTime PostDate { get; set; }
        public int DurationDays { get; set; }
        
        public int AgencyId { get; set; }
        public decimal Price { get; set; }
        public string Destino { get; set; }
        public string Description { get; set; }
      
        public bool Viewed { get; set; } // <-- This is what we're mainly interested in
        public bool SaveForLater { get; set; } // <-- This is what we're mainly interested in
        public bool Selected { get; set; } // <-- This is what we're mainly interested in
        public byte[] File { get; set; }
    

    }

    public class Message {
        [Key]
        public int QuestionId { get; set; }
        public int QuestionParentId { get; set; }

        public virtual int BidId { get; set; }
        public virtual Bid Bid { get; set; }

        public string QuestionText { get; set; }
        
        public int UserId { get; set; }
       
       
        public DateTime PostDate { get; set; }
    }

    public class News
    {
        [Key]
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsBody { get; set; }
        public string NewsURL { get; set; }
        public byte[] NewsImage { get; set; }
        public DateTime NewsPostDate { get; set; }
    }

}
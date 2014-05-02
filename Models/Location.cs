using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TBWeb.Models
{
    public class Location
    {


            public int ContinentId { get; set; }

        public int CountryId { get; set; }
        
        public int RegionId { get; set; }
        
        public int StateId { get; set; }

        public int CityId { get; set; }

    }

}
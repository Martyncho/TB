using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using TBWeb.Models;

namespace TBWeb.Controllers
{
    public class LocationsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/Locations
        public IQueryable<City> GetCities(int StateId)
        {

            var cities =  db.Cities.Where(x => x.StateId == StateId).OrderBy(c => c.Name).AsQueryable();
//            City defaultcity = cities.Where(x => x.CityId == 14391).First<City>();
  //          defaultcity.isDefault = true;
            return cities;
        }

        // GET api/Locations
        public IQueryable<Country> GetCountries()
        {
            return db.Countries.OrderBy(c => c.Name).AsQueryable();
        }

        // GET api/Locations
        public IQueryable<State> GetStates(int CountryId)
        {
            return db.States.Where(x => x.CountryId == CountryId).OrderBy(c => c.Name).AsQueryable();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
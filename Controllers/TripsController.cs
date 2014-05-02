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
    public class TripsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/Trips
        public IQueryable<Trip> GetTrips()
        {
            return db.Trips.OrderBy(m => m.TripId);
        }


        // GET api/CustomerBids/query

        public IQueryable<Trip> GetTrips(String query)
        {
            IQueryable<Trip> trips = null;
            if (query != null && query != "")
                trips = db.Trips.Where(x => x.Destination.Contains(query)).OrderBy(m => m.TripId);
            else
                trips = db.Trips.OrderBy(m => m.TripId);
            return trips;
        }



        // GET api/Trips/5
        [ResponseType(typeof(Trip))]
        public async Task<IHttpActionResult> GetTrip(int id)
        {
            Trip trip = await db.Trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }

            return Ok(trip);
        }

        // PUT api/Trips/5
        public async Task<IHttpActionResult> PutTrip(int id, Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trip.TripId)
            {
                return BadRequest();
            }

            db.Entry(trip).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Trips
        [ResponseType(typeof(Trip))]
        public async Task<IHttpActionResult> PostTrip(Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trips.Add(trip);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = trip.TripId }, trip);
        }

        // DELETE api/Trips/5
        [ResponseType(typeof(Trip))]
        public async Task<IHttpActionResult> DeleteTrip(int id)
        {
            Trip trip = await db.Trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }

            db.Trips.Remove(trip);
            await db.SaveChangesAsync();

            return Ok(trip);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TripExists(int id)
        {
            return db.Trips.Count(e => e.TripId == id) > 0;
        }

      
    }
}
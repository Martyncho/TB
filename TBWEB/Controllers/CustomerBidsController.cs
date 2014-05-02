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
using TBWeb.Models;
using Microsoft.AspNet.Identity.EntityFramework;
namespace TBWeb.Controllers
{
    public class CustomerBidsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/CustomerBids
        public IQueryable<Bid> GetBids()
        {
//            return db.Bids.Include("Trip").GroupBy(x => x.Trip.TripId);
                      return db.Bids.Include("Trip").OrderBy(m => m.TripId).ThenBy(m => m.BidTripNumber);
        }

        // GET api/CustomerBids/query
     
        public IQueryable<Bid> GetBids(String query)
        {
              IQueryable<Bid> bids = null;
            if (query != null && query != "")
                bids = db.Bids.Where(x => x.Destino.Contains(query)).Include("Trip").OrderBy(m => m.TripId).ThenBy(m => m.BidTripNumber);
            else
                bids = db.Bids.Include("Trip").OrderBy(m => m.TripId).ThenBy(m => m.BidTripNumber);
            return bids;
        }


        public IQueryable<Bid> GetBids(int TripId)
        {
            IQueryable<Bid> bids = null;
            if (TripId != 0)
                bids = db.Bids.Where(x => x.TripId == TripId).OrderBy(m => m.TripId);
            else
                bids = db.Bids.OrderBy(m => m.TripId);
            return bids;
        }

        // GET api/CustomerBids/5
        [ResponseType(typeof(Bid))]
        public async Task<IHttpActionResult> GetBid(int id)
        {
            Bid bid = await db.Bids.FindAsync(id);
            if (bid == null)
            {
                return NotFound();
            }

            return Ok(bid);
        }

        // PUT api/CustomerBids/5
        public async Task<IHttpActionResult> PutBid(int id, Bid bid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bid.BidId)
            {
                return BadRequest();
            }

            db.Entry(bid).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BidExists(id))
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

        // POST api/CustomerBids
        [ResponseType(typeof(Bid))]
        public async Task<IHttpActionResult> PostBid(Bid bid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bids.Add(bid);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bid.BidId }, bid);
        }

        // DELETE api/CustomerBids/5
        [ResponseType(typeof(Bid))]
        public async Task<IHttpActionResult> DeleteBid(int id)
        {
            Bid bid = await db.Bids.FindAsync(id);
            if (bid == null)
            {
                return NotFound();
            }

            db.Bids.Remove(bid);
            await db.SaveChangesAsync();

            return Ok(bid);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BidExists(int id)
        {
            return db.Bids.Count(e => e.BidId == id) > 0;
        }
    }
}
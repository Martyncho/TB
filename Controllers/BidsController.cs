using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TBWeb.Models;

namespace TBWeb.Controllers
{
    public class BidsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Bids/
        public async Task<ActionResult> Index()
        {
            var bids = db.Bids.Include(b => b.Trip);
            return View(await bids.ToListAsync());
        }



        // GET: /Bids/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = await db.Bids.FindAsync(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            return View(bid);
        }

        // GET: /Bids/Create
        public ActionResult Create()
        {
            ViewBag.TripId = new SelectList(db.Trips, "TripId", "Category");
            return View();
        }

        // POST: /Bids/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="BidId,TripId,ProviderId,Price,Destino,Description,Viewed,File")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                db.Bids.Add(bid);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TripId = new SelectList(db.Trips, "TripId", "Category", bid.TripId);
            return View(bid);
        }

        // GET: /Bids/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = await db.Bids.FindAsync(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            ViewBag.TripId = new SelectList(db.Trips, "TripId", "Category", bid.TripId);
            return View(bid);
        }

        // POST: /Bids/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="BidId,TripId,ProviderId,Price,Destino,Description,Viewed,File")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bid).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TripId = new SelectList(db.Trips, "TripId", "Category", bid.TripId);
            return View(bid);
        }

        // GET: /Bids/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid bid = await db.Bids.FindAsync(id);
            if (bid == null)
            {
                return HttpNotFound();
            }
            return View(bid);
        }

        // POST: /Bids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Bid bid = await db.Bids.FindAsync(id);
            db.Bids.Remove(bid);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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

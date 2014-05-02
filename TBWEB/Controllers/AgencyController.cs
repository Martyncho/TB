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
    public class AgencyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Agency/
        public async Task<ActionResult> Index()
        {
            var agencies = db.Agencies.Include(a => a.City).Include(a => a.Country).Include(a => a.State);
            return View(await agencies.ToListAsync());
        }

        // GET: /Agency/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agency agency = await db.Agencies.FindAsync(id);
            if (agency == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = agency.CityId;
            ViewBag.CountryId = agency.CountryId;
            ViewBag.StateId = agency.StateId;

            ViewBag.CustomerProfiles = db.CustomerProfiles;
            ViewBag.Destinations = db.Destinations;
            ViewBag.PaymentMethods = db.PaymentMethods;
            ViewBag.Products = db.Products;

            return View(agency);
        }

        // GET: /Agency/Create
        public ActionResult Create()
        {

            ViewBag.CustomerProfiles = db.CustomerProfiles;
            ViewBag.Destinations = db.Destinations;
            ViewBag.PaymentMethods = db.PaymentMethods;
            ViewBag.Products = db.Products;
            return View();
        }

        // POST: /Agency/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AgencyId,Name,RegistryNumber,CUIT,Adress,PostalCode,CityId,StateId,CountryId,AgencyPhone,AgencyPhone2,Extension,Extension2,WebPage,Password,ConfirmPassword,EMail,ConfirmEmail,PriceRangeFrom,PriceRangeTo")] Agency agency, string[] CustomerProfiles, string[] Destinations, string[] PaymentMethods, string[] Products)
        {
            agency.Country = db.Countries.Find(agency.CountryId);
            agency.State = db.States.Find(agency.StateId);
            agency.City = db.Cities.Find(agency.CityId );


            if (CustomerProfiles != null)
            {
             foreach (string c in CustomerProfiles)
            {
                agency.CustomerProfiles.Add(db.CustomerProfiles.Find(int.Parse(c)));
            }
           }
            if (Destinations != null)
            {
             foreach (string c in Destinations)
            {
                agency.Destinations.Add(db.Destinations.Find(int.Parse(c)));
            }
            }
            if (PaymentMethods != null)
            {
            foreach (string c in PaymentMethods)
            {
                agency.PaymentMethods.Add(db.PaymentMethods.Find(int.Parse(c)));
            }
            }
            if (Products != null)
            {
                foreach (string c in Products)
                {
                    agency.Products.Add(db.Products.Find(int.Parse(c)));
                }
            }

                db.Agencies.Add(agency);
                await db.SaveChangesAsync();

            ViewBag.CityId = agency.CityId;
            ViewBag.CountryId = agency.CountryId;
            ViewBag.StateId = agency.StateId;

            ViewBag.CustomerProfiles = db.CustomerProfiles;
            ViewBag.Destinations = db.Destinations;
            ViewBag.PaymentMethods = db.PaymentMethods;
            ViewBag.Products = db.Products;

//            return RedirectToAction("Index");

            return View(agency);
        }

        // GET: /Agency/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agency agency = await db.Agencies.FindAsync(id);
            if (agency == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.CityId = agency.CityId;
            ViewBag.CountryId = agency.CountryId;
            ViewBag.StateId = agency.StateId;

            ViewBag.CustomerProfiles = db.CustomerProfiles;
            ViewBag.Destinations = db.Destinations;
            ViewBag.PaymentMethods = db.PaymentMethods;
            ViewBag.Products = db.Products;

            return View(agency);
        }

        // POST: /Agency/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AgencyId,Name,Ranking,RegistryNumber,CUIT,Adress,PostalCode,CityId,StateId,CountryId,AgencyPhone,AgencyPhone2,Extension,Extension2,WebPage,Password,ConfirmPassword,EMail,ConfirmEmail,PriceRangeFrom,PriceRangeTo,MemberCategoryId")] Agency agency, string[] CustomerProfiles, string[] Destinations, string[] PaymentMethods, string[] Products)
        {
            agency.Country = db.Countries.Find(agency.CountryId);
            agency.State = db.States.Find(agency.StateId);
            agency.City = db.Cities.Find(agency.CityId);

            if (CustomerProfiles != null)
            {
                foreach (string c in CustomerProfiles)
                {
                    agency.CustomerProfiles.Add(db.CustomerProfiles.Find(int.Parse(c)));
                }
            }
            if (Destinations != null)
            {
            foreach (string c in Destinations)
            {
                agency.Destinations.Add(db.Destinations.Find(int.Parse(c)));
            }
            }
            if (PaymentMethods != null)
            {
            foreach (string c in PaymentMethods)
            {
                agency.PaymentMethods.Add(db.PaymentMethods.Find(int.Parse(c)));
            }
            }
            if (Products != null)
            {
                foreach (string c in Products)
                {
                    agency.Products.Add(db.Products.Find(int.Parse(c)));
                }
            }
            if (ModelState.IsValid)
            {
                db.Entry(agency).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = agency.CityId;
            ViewBag.CountryId = agency.CountryId;
            ViewBag.StateId = agency.StateId;

            ViewBag.CustomerProfiles = db.CustomerProfiles;
            ViewBag.Destinations = db.Destinations;
            ViewBag.PaymentMethods = db.PaymentMethods;
            ViewBag.Products = db.Products;
            return View(agency);
        }

        // GET: /Agency/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agency agency = await db.Agencies.FindAsync(id);
            if (agency == null)
            {
                return HttpNotFound();
            }
            return View(agency);
        }

        // POST: /Agency/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Agency agency = await db.Agencies.FindAsync(id);
            db.Agencies.Remove(agency);
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

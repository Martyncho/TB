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
    public class CustomerProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /CustomerProfiles/
        public async Task<ActionResult> Index()
        {
            return View(await db.CustomerProfiles.ToListAsync());
        }

        // GET: /CustomerProfiles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerProfile customerprofile = await db.CustomerProfiles.FindAsync(id);
            if (customerprofile == null)
            {
                return HttpNotFound();
            }
            return View(customerprofile);
        }

        // GET: /CustomerProfiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CustomerProfiles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="CustomerProfileId,Name")] CustomerProfile customerprofile)
        {
            if (ModelState.IsValid)
            {
                db.CustomerProfiles.Add(customerprofile);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(customerprofile);
        }

        // GET: /CustomerProfiles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerProfile customerprofile = await db.CustomerProfiles.FindAsync(id);
            if (customerprofile == null)
            {
                return HttpNotFound();
            }
            return View(customerprofile);
        }

        // POST: /CustomerProfiles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="CustomerProfileId,Name")] CustomerProfile customerprofile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerprofile).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customerprofile);
        }

        // GET: /CustomerProfiles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerProfile customerprofile = await db.CustomerProfiles.FindAsync(id);
            if (customerprofile == null)
            {
                return HttpNotFound();
            }
            return View(customerprofile);
        }

        // POST: /CustomerProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CustomerProfile customerprofile = await db.CustomerProfiles.FindAsync(id);
            db.CustomerProfiles.Remove(customerprofile);
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

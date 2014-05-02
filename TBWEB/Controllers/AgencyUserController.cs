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
    public class AgencyUserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /AgencyUser/
        public async Task<ActionResult> Index()
        {
            var agenciesusers = db.AgenciesUsers.Include(a => a.Agency);
            return View(await agenciesusers.ToListAsync());
        }

        // GET: /AgencyUser/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgencyUser agencyuser = await db.AgenciesUsers.FindAsync(id);
            if (agencyuser == null)
            {
                return HttpNotFound();
            }
            return View(agencyuser);
        }

        // GET: /AgencyUser/Create
        public ActionResult Create()
        {
            ViewBag.AgencyId = new SelectList(db.Agencies, "AgencyId", "Name");
            return View();
        }

        // POST: /AgencyUser/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="AgencyUserId,AgencyId,Name,Mail,City,Ranking")] AgencyUser agencyuser)
        {
            if (ModelState.IsValid)
            {
                db.AgenciesUsers.Add(agencyuser);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AgencyId = new SelectList(db.Agencies, "AgencyId", "Name", agencyuser.AgencyId);
            return View(agencyuser);
        }

        // GET: /AgencyUser/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgencyUser agencyuser = await db.AgenciesUsers.FindAsync(id);
            if (agencyuser == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgencyId = new SelectList(db.Agencies, "AgencyId", "Name", agencyuser.AgencyId);
            return View(agencyuser);
        }

        // POST: /AgencyUser/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="AgencyUserId,AgencyId,Name,Mail,City,Ranking")] AgencyUser agencyuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agencyuser).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AgencyId = new SelectList(db.Agencies, "AgencyId", "Name", agencyuser.AgencyId);
            return View(agencyuser);
        }

        // GET: /AgencyUser/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgencyUser agencyuser = await db.AgenciesUsers.FindAsync(id);
            if (agencyuser == null)
            {
                return HttpNotFound();
            }
            return View(agencyuser);
        }

        // POST: /AgencyUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AgencyUser agencyuser = await db.AgenciesUsers.FindAsync(id);
            db.AgenciesUsers.Remove(agencyuser);
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

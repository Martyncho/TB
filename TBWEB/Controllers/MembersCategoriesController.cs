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
    public class MembersCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /MembersCategories/
        public async Task<ActionResult> Index()
        {
            return View(await db.MemberCategories.ToListAsync());
        }

        // GET: /MembersCategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberCategory membercategory = await db.MemberCategories.FindAsync(id);
            if (membercategory == null)
            {
                return HttpNotFound();
            }
            return View(membercategory);
        }

        // GET: /MembersCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /MembersCategories/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="MemeberCategoryId,Name")] MemberCategory membercategory)
        {
            if (ModelState.IsValid)
            {
                db.MemberCategories.Add(membercategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(membercategory);
        }

        // GET: /MembersCategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberCategory membercategory = await db.MemberCategories.FindAsync(id);
            if (membercategory == null)
            {
                return HttpNotFound();
            }
            return View(membercategory);
        }

        // POST: /MembersCategories/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="MemeberCategoryId,Name")] MemberCategory membercategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membercategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(membercategory);
        }

        // GET: /MembersCategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemberCategory membercategory = await db.MemberCategories.FindAsync(id);
            if (membercategory == null)
            {
                return HttpNotFound();
            }
            return View(membercategory);
        }

        // POST: /MembersCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MemberCategory membercategory = await db.MemberCategories.FindAsync(id);
            db.MemberCategories.Remove(membercategory);
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

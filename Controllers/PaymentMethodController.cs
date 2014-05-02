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
    public class PaymentMethodController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /PaymentMethod/
        public async Task<ActionResult> Index()
        {
            return View(await db.PaymentMethods.ToListAsync());
        }

        // GET: /PaymentMethod/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMethod paymentmethod = await db.PaymentMethods.FindAsync(id);
            if (paymentmethod == null)
            {
                return HttpNotFound();
            }
            return View(paymentmethod);
        }

        // GET: /PaymentMethod/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PaymentMethod/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="PaymentMethodId,Name")] PaymentMethod paymentmethod)
        {
            if (ModelState.IsValid)
            {
                db.PaymentMethods.Add(paymentmethod);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(paymentmethod);
        }

        // GET: /PaymentMethod/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMethod paymentmethod = await db.PaymentMethods.FindAsync(id);
            if (paymentmethod == null)
            {
                return HttpNotFound();
            }
            return View(paymentmethod);
        }

        // POST: /PaymentMethod/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="PaymentMethodId,Name")] PaymentMethod paymentmethod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentmethod).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(paymentmethod);
        }

        // GET: /PaymentMethod/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMethod paymentmethod = await db.PaymentMethods.FindAsync(id);
            if (paymentmethod == null)
            {
                return HttpNotFound();
            }
            return View(paymentmethod);
        }

        // POST: /PaymentMethod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PaymentMethod paymentmethod = await db.PaymentMethods.FindAsync(id);
            db.PaymentMethods.Remove(paymentmethod);
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

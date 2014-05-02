using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using TBWeb.Models;
using MvcPaging;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Net;

namespace TBWeb.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            ViewBag.Message = "Home";

            if (db.News != null)
            {
                var news = db.News.ToList();
                if (news != null)
                {
                    return View(news);
                }
                else
                {
                    return View();
                }
            }
            else 
            {
                return View();
            }
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        public async Task<ActionResult> News()
        {
            return View(await db.News.ToListAsync());
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        //public ActionResult Index(string Customer_name, int? page)
        //{
        //    ViewData["Customer_name"] = Customer_name;
        
        //    int currentPageIndex = page.HasValue ? page.Value : 1;
        //    IList<Customer> Customers = this.allCustomer;

        //    if (string.IsNullOrWhiteSpace(Customer_name))
        //    {
        //        Customers = Customers.ToPagedList(currentPageIndex, defaultPageSize);
        //    }
        //    else
        //    {
        //        Customers = Customers.Where(p => p.Name.ToLower() == Customer_name.ToLower()).ToPagedList(currentPageIndex, defaultPageSize);
        //    }



        //    //var list = 
        //    if (Request.IsAjaxRequest())
        //        return PartialView("_AjaxCustomerList", Customers);
        //    else
        //        return View(Customers);
        //}

        //public ActionResult Paging(string Customer_name, int? page)
        //{
        //    ViewData["Customer_name"] = Customer_name;
        //    int currentPageIndex = page.HasValue ? page.Value : 1;
        //    IList<Customer> Customers = this.allCustomer;

        //    if (string.IsNullOrWhiteSpace(Customer_name))
        //    {
        //        Customers = Customers.ToPagedList(currentPageIndex, defaultPageSize);
        //    }
        //    else
        //    {
        //        Customers = Customers.Where(p => p.Name.ToLower() == Customer_name.ToLower()).ToPagedList(currentPageIndex, defaultPageSize);
        //    }

        //    return View(Customers);
        //}

        public ActionResult Theme()
        {
            return View();
        }

        
        public ActionResult Admin()
        {
            return View();
        
        }
    }
}
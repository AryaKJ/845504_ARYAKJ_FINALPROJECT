using AUCTIONonlineWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AUCTIONonlineWeb.Controllers
{
    public class SaleController : Controller
    {
        [HttpGet]
        public ActionResult Sale()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sale([ Bind(Exclude = "FinalAmount")] Sale sell)
        {
            bool Status = false;
            string message = "";

            if (ModelState.IsValid)
            {
                string filename = Path.GetFileNameWithoutExtension(sell.ImageFile.FileName);
                string extension = Path.GetExtension(sell.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                sell.Image = "~/DatabaseImage/" + filename;
                filename = Path.Combine(Server.MapPath("~/DatabaseImage/"), filename);
                sell.ImageFile.SaveAs(filename);
                sell.UserId = GetId(this.User.Identity.Name);

                using (BidAndSellEntities db = new BidAndSellEntities())
                {
                    db.Sales.Add(sell);
                    db.SaveChanges();
                    message = "Your Product Has been Added";
                    Status = true;
                    //return RedirectToAction("ShowProduct", "Sale");
                }
            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(sell);
        }

        [NonAction]
        public int GetId(string email)
        {
            using(BidAndSellEntities db = new BidAndSellEntities())
            {
                var s = db.Users.Where(a => a.Email == email).Select(a => a.UserId).FirstOrDefault();
                return s;
            }
            
        }

        [HttpGet]
        public ActionResult ShowProduct(int Saleid)
        {
            
            //int id = GetId(this.User.Identity.Name);
            using (BidAndSellEntities db = new BidAndSellEntities())
            {
                return View(db.Sales.Find(Saleid));

            }
            
        }

        [HttpGet]
        public ActionResult YourProducts()
        {
            
            int id = GetId(this.User.Identity.Name);
            ViewBag.id = id;
            using (BidAndSellEntities db = new BidAndSellEntities())
            {
                //var items = db.Sales.Where(a => a.UserId == id).FirstOrDefault();
                return View(db.Sales.ToList());
            }

                     
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            using(BidAndSellEntities db = new BidAndSellEntities())
            {
                return View(db.Sales.Where(a => a.SaleId== id).FirstOrDefault());
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RFahWebsite.Data.DAL;

namespace RFahWebsite.Controllers
{
    public class HomeController : Controller
    {
        RFahDBEntities1 DbObject = null;
        public HomeController()
        {
            DbObject = new RFahDBEntities1();
        }

        public ActionResult Index()
        {
            //var tt= DbObject.TblBrands.Where(m => m.Isactive == true && m.Img != "").ToList();
            return View(DbObject.TblBrands.Where(m => m.Isactive == true && m.Img != "").ToList());
        }
        public PartialViewResult SubBanner()
        {
            return PartialView();
        }
        public PartialViewResult NewArrival()
        {
            return PartialView(DbObject.TblProducts.Where(m => m.IsActive == true && m.Status == "inv" && m.Img != "").Take(1).ToList());
        }
        public PartialViewResult RandomProduct()
        {
            return PartialView(DbObject.TblProducts.Where(m => m.IsActive == true && m.Status=="inv" && m.Img != "").Take(3).ToList());
        }
        public PartialViewResult TopCategory()
        {
            return PartialView(DbObject.TblCategories.Where(m => m.Isactive == true && m.Image!="").Take(4).ToList());
        }
        public PartialViewResult PopularBrand()
        {
            return PartialView(DbObject.TblBrands.Where(m => m.Isactive == true && m.Img != "").ToList());
        }
        public ActionResult contact()
        {
            return View();
        }
        public ActionResult CheckOut()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult Detail()        {
            return View();
        }
        public ActionResult WishList()
        {
            return View();
        }

        public ActionResult Grid()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }


    }
}
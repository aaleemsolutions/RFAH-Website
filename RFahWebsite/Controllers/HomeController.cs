using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using RFahWebsite.Data.DAL;
using RFahWebsite.Models;

namespace RFahWebsite.Controllers
{
    public class HomeController : Controller
    {
        RFahDBEntities1 DbObject = null;
        private MasterModel model = null;
        public HomeController()
        {
            model = new MasterModel();
            DbObject = new RFahDBEntities1();
            
        }
        
        public ActionResult Index()
        {
            //var tt= DbObject.TblBrands.Where(m => m.Isactive == true && m.Img != "").ToList();
            model.BrandList = DbObject.TblBrands.Where(m => m.Isactive == true && m.Img != "").Take(6).ToList();

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(string message="Hello")
        {
            //var tt= DbObject.TblBrands.Where(m => m.Isactive == true && m.Img != "").ToList();
            model.BrandList = DbObject.TblBrands.Where(m => m.Isactive == true && m.Img != "").ToList();

            return View(model);
        }
        [HttpGet]
        public ActionResult Brandproduct(int Brandid)
        {
            model.ProductList = DbObject.TblProducts.Where(i => i.IsActive== true && i.BrdId == Brandid).ToList();

            if (model!=null && model.ProductList.Count()!=0)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
        [HttpGet]
        public ActionResult Productdetail(int id)
        {
            model.Product = DbObject.TblProducts.Where(i => i.IsActive == true && i.ID == id).SingleOrDefault();
            model.Brand = DbObject.TblBrands.Where(i => i.Isactive== true && i.Id == id).SingleOrDefault();
            model.RelatedImages = DbObject.TblProRelImgs.Where(i=>i.PrdID == id).ToList();
            model.RelatedProduct = DbObject.TblRelProducts.Where(m => m.PrdId == id).ToList();
            model.RelatedProductsDetail = DbObject.TblProducts.Where(m => m.IsActive == true).ToList();
            if (model.RelatedProduct==null)
            {

            }
            return View(model);
        }
        public PartialViewResult SubBanner()
        {
            return PartialView();
        }
        public ActionResult NewArrival()
        {
           //Thread.Sleep(3000);
            model.ProductList = DbObject.TblProducts.Where(m => m.IsActive == true && m.Status == "inv" && m.Img != "" && m.Created.Month==DateTime.Now.Month || m.Created.Month==DateTime.Now.Month-1).OrderByDescending(m=>m.Created.Month).ToList();
            
            
            return PartialView(model);
        }
        public JsonResult JsonQuick(int QuickId)
        {
            model.Product = DbObject.TblProducts.Where(m => m.IsActive && m.ID == QuickId).SingleOrDefault();
            model.RelatedImages = DbObject.TblProRelImgs.Where(i => i.PrdID == QuickId).ToList();
            ViewBag.Name = model.Product.Name;
            var product = new { Name = model.Product.Name, Image = model.Product.Img, RelatedImages = model.RelatedImages };
            return Json(product, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult RandomProduct()
        {
         
            /*var demo = from a in DbObject.TblBrands.ToList()
                       join  b in DbObject.TblSales.ToList() on a.Id equals b.BrndId

                        select new { a = model.BrandList,b = model.SalList};*/
            //.GroupBy(m => m.PrdId).Where(x => x.Count() > 1);

            model.SalList = DbObject.TblSales.Where(u => u.isactive == true).OrderByDescending(m=>m.Sold).ToList();
            
            //model.BrandList = DbObject.TblBrands.Where(u => u.Isactive == true).OrderByDescending(m=>m.TblSales).ToList();
            model.ProductList = DbObject.TblProducts.Where(m => m.IsActive == true && m.Status == "inv" && m.Img != "").Take(3).ToList();



            return PartialView(model);
        }
        public PartialViewResult TopCategory()
        {
            
            var query = from a in DbObject.TblCategories
                        join b in DbObject.TblProducts on a.Id equals b.CatId
                        join c in DbObject.TblSales on b.ID equals c.PrdId
                        orderby c.Sale descending
                        select new MasterModel
                        {
                         Category = a,
                         Product = b,
                         Sales = c,
                         CategoryList = DbObject.TblCategories.Where(m => m.Isactive == true && m.ParentId != null && m.ParentId==a.Id)
        };
            var result = query.ToList();

           //model.CategoryList =  DbObject.TblCategories.Where(m => m.Isactive == true && m.ParentId!=null);
            //DbObject.TblCategories.Where(m => m.Isactive == true && m.Image != "").Take(4).ToList();
            //model.CategoryList = DbObject.TblCategories.Where(m => m.Isactive == true && m.Image != "").Take(4).ToList(); ;

            
            return PartialView(result);
        }
        public PartialViewResult PopularBrand()
        {
            var query =
               from a in DbObject.TblBrands
               join b in DbObject.TblSales on a.Id equals b.BrndId
               orderby b.Sale
               select new { a = model.BrandList1,b = model.SalList};

            model.BrandList = DbObject.TblBrands.Where(m => m.Isactive == true && m.Img != "").ToList();
            //ViewBag.hotsalecheck = model.ProductList.Take(3).ToList();

            return PartialView(model);
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
        [HttpPost]
        public ActionResult AddtoCart(int CartId)
        {
            return View();
        }
        
        [HttpGet]
        public PartialViewResult QuickView(int QuickId)
        {
            model.Product = DbObject.TblProducts.Where(m => m.IsActive && m.ID == QuickId).SingleOrDefault();
            model.RelatedImages = DbObject.TblProRelImgs.Where(i => i.PrdID == QuickId).ToList();
            ViewBag.Name = model.Product.Name;

            return PartialView(model);
        }

        public PartialViewResult SpecialOffer()
        {

            return PartialView();
        }

    }
}
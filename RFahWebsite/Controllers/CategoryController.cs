using RFahWebsite.Data.DAL;
using RFahWebsite.Logics;
using RFahWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RFahWebsite.Controllers
{
    public class CategoryController : Controller
    {
        RFahDBEntities1 DbObject = null;
        private MasterModel model = null;
        MyLogicsController logics = null;
        public CategoryController()
        {
            model = new MasterModel();
            DbObject = new RFahDBEntities1();
            logics = new MyLogicsController();
            ViewBag.SearchCategory = logics.Category();
        }
        // GET: Category
        public ActionResult CategoryDropDown()
        {
           model.CategoryList =  DbObject.TblCategories.Where(m => m.Isactive == true).ToList();
            model.BrandList = DbObject.TblBrands.Where(m => m.Isactive == true).ToList();

            //var check = from a in DbObject.TblCategories
            //            join b in DbObject.TblBrands on a.Id equals b.CatId
            //            select new MasterModel {
            //                Category=a,
            //                Brand=b,
            //                CategoryList = DbObject.TblCategories.Where(m=>m.Isactive==true && m.ParentId==b.Id)
            //            };

            

            return PartialView(model);
        }

        public ActionResult CategoryDetails(int CatId)
        {
            model.ProductList = DbObject.TblProducts.Where(m => m.IsActive == true && m.CatId == CatId).ToList();
            return View(model);
        }
    }
}
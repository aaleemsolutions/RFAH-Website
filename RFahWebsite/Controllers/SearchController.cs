using RFahWebsite.Data.DAL;
using RFahWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RFahWebsite.Logics;
using System.Threading;

namespace RFahWebsite.Controllers
{
    public class SearchController : Controller
    {
        RFahDBEntities1 DbObject = null;
        private MasterModel model = null;
        MyLogicsController logics = null;
        public SearchController(){
            model = new MasterModel();
            DbObject = new RFahDBEntities1();
            logics = new MyLogicsController();
            ViewBag.SearchCategory = logics.Category();
        }
        // GET: Search
        public ActionResult SearchPartial()
        {
            
            return PartialView();
        }
        [HttpPost]
        public ActionResult SearchPartial(string TxtSearchQuery,string SearchCategory)
        {
            Thread.Sleep(3000);
            int CatId = 0;
            CatId = Convert.ToInt32(SearchCategory);
            ViewBag.SearchCategory = logics.Category();
            if (CatId == 0)
            {
                model.ProductList = DbObject.TblProducts.Where(s => s.Name.StartsWith(TxtSearchQuery)).ToList();
            }
            else
            {
                model.ProductList = DbObject.TblProducts.Where(s => s.Name.StartsWith(TxtSearchQuery) && s.TblCategory.Id == CatId).ToList();
            }
            
            return PartialView("SearchResult", model);
        }

        [HttpGet]
        public JsonResult SearchQuery(string term)
       {
            List<string> Product = DbObject.TblProducts.Where(s => s.Name.StartsWith(term) || s.Name.Contains(term))
            .Select(x =>x.Name).ToList();

            

            return Json(Product, JsonRequestBehavior.AllowGet);

        }

        
    }
}

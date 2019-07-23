
using RFahWebsite.Data.DAL;
using RFahWebsite.Logics;
using RFahWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace RFahWebsite.Controllers
{
    public class NavigationController : Controller
    {
        RFahDBEntities1 DbObject = null;
        private MasterModel model = null;
        MyLogicsController logics = null;
        public NavigationController()
        {
            model = new MasterModel();
            DbObject = new RFahDBEntities1();
            logics = new MyLogicsController();
            ViewBag.SearchCategory = logics.Category();
        }
        // GET: Navigatiomn
        public ActionResult MainNavigation()
        {
            
            model.CategoryList = DbObject.TblCategories.Where(m => m.Isactive == true && m.ParentId == null).ToList().Take(6);
            return PartialView(model);
        }
        
        public ActionResult NavigationResult(int id)
        {
            return PartialView();
        }
    }
}
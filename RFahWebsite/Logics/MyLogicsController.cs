using RFahWebsite.Data.DAL;
using RFahWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RFahWebsite.Logics
{
    public class MyLogicsController : Controller
    {
        RFahDBEntities1 DbObject = null;
        private MasterModel model = null;
        public MyLogicsController(){
            DbObject = new RFahDBEntities1();
            model = new MasterModel();
            }

        // GET: MyLogics
        //Code
        internal List<SelectListItem> Category()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            SelectListItem selectListItem = new SelectListItem();

            selectListItems.Add(new SelectListItem()
            {
                Text = "--All Category--",
                Value = 0.ToString(),
                Disabled = false,
                Selected = true
            });
            foreach (var category in DbObject.TblCategories.Where(i => i.ParentId == null))
            {
                selectListItem = new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.Id.ToString(),
                };
                selectListItems.Add(selectListItem);
            }
            return selectListItems;
        }

    }
}
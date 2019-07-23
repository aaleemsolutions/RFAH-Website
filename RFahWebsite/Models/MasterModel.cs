using RFahWebsite.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RFahWebsite.Models
{
    public class MasterModel
    {
        public MasterModel()
        {
        //    Category = null;
        //    Brand = null;
        //    BrandList = null;
        //    BrandList1 = null;
        //    SalList = null;
        //    Product = null;
        //    ProductList = null;
        }   
        

        public TblBrand Brand{ get; set; }
        public IEnumerable<TblBrand> BrandList { get; set; }
        public IEnumerable<TblBrand> BrandList1 { get; set; }
        public TblSale Sales { get; set; }
        public IEnumerable<TblSale> SalList { get; set; }
        public TblCategory Category { get; set; }
        public IEnumerable<TblCategory> CategoryList { get; set; }
        
        public TblProduct  Product{ get; set; }

        public IEnumerable<TblProRelImg> RelatedImages{ get; set; }

        public IEnumerable<TblProduct> ProductList { get; set; }

        public IEnumerable<TblRelProduct> RelatedProduct { get; set; }
        public IEnumerable<TblProduct> RelatedProductsDetail{ get; set; }


        //Top CategoryName
        public string name { get; set; }


    }
}
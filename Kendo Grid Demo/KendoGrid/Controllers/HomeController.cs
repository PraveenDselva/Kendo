using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KendoGrid.Models;

namespace KendoGrid.Controllers
{
    public class HomeController : Controller
    {
       public ActionResult Index()
        {
            return View();
        }

       [HttpPost]
       public ActionResult Read()
       {
           var products = new ProductModelRepository().Products;
           return Json(products);
       }

       [HttpPost]
       public ActionResult ReadCategories()
       {
           var products = new ProductModelRepository().ProductCategories;
           return Json(products);
       }

        [HttpPost]
        public ActionResult Update(ProductModel products)
        {
            var prod = new ProductModelRepository().Products.ToList().Find(x => x.ProductId.Equals(products.ProductId));
            if (prod != null)
            {
                prod.ProductName = products.ProductName;
                prod.UnitPrice = products.UnitPrice;
                prod.UnitsInStock = products.UnitsInStock;
                prod.Discontinued = products.Discontinued;
                if (products.ProductCategory != null)
                    prod.ProductCategory =
                        new ProductModelRepository().ProductCategories.ToList()
                            .Find(x => x.ProductCategoryId.Equals(products.ProductCategory.ProductCategoryId));
            }

            return Json(null);
        }
    }
}
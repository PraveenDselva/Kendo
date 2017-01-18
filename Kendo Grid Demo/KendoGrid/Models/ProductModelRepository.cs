﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoGrid.Models
{
    public class ProductModelRepository
    {
        public IEnumerable<ProductModel> Products
        {
            get
            {
                IEnumerable<ProductModel> result = (IEnumerable<ProductModel>)HttpContext.Current.Session["Products"];

                if (result == null)
                {
                    HttpContext.Current.Session["Products"] = result = GenerateProducts();
                }

                return result;
            }
        }

        public IEnumerable<ProductCategoryModel> ProductCategories
        {
            get
            {
                IEnumerable<ProductCategoryModel> result = (IEnumerable<ProductCategoryModel>)HttpContext.Current.Session["ProductCategories"];

                if (result == null)
                {
                    HttpContext.Current.Session["ProductCategories"] = result = GenerateProductCategories();
                }

                return result;
            }
        }

        private IEnumerable<ProductModel> GenerateProducts()
        {
            var list = new List<ProductModel>();
            var categories = ProductCategories.ToArray();
            var idx = 1;
            Random random = new Random();
            for (var i = 1; i <= 50; i++)
            {
                int randomCategorySelection=random.Next(0, ProductCategories.Count());
                list.Add(new ProductModel
                {
                    ProductId = idx++,
                    ProductName = "Product" + idx,
                    UnitPrice = i,
                    UnitsInStock = (short?) (i + 10),
                    Discontinued = false,
                    ProductCategory = categories[randomCategorySelection]
                });
            }

            return list;
        }

        private IEnumerable<ProductCategoryModel> GenerateProductCategories()
        {
            var list = new List<ProductCategoryModel>();
            var idx = 1;

            for (var i = 1; i <= 5; i++)
            {
                list.Add(new ProductCategoryModel
                {
                    ProductCategoryId = idx++,
                    ProductCategoryName = "Product Category " + idx,
                });
            }

            return list;
        }

    }
}
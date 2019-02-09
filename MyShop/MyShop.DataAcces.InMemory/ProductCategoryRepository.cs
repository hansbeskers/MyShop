using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAcces.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = cache["productsCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["productsCategories"] = productCategories;
        }

        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);
        }

        public void Update(ProductCategory ProductCategory)
        {
            ProductCategory productCategoryToUpdate = productCategories.Find(p => p.Id == ProductCategory.Id);
            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = ProductCategory;
            }
            else
            {
                throw new Exception("ProductCategory not found");
            }
        }

        public ProductCategory Find(String Id)
        {
            ProductCategory ProductCategory = productCategories.Find(p => p.Id == Id);
            if (ProductCategory != null)
            {
                return ProductCategory;
            }
            else
            {
                throw new Exception("ProductCategory not found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory productCategoryToDelete = productCategories.Find(p => p.Id == Id);
            if (productCategoryToDelete != null)
            {
                productCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("productCategoryToDelete not found");
            }
        }
    }
}

using API.Interfaces;
using Data_Layer.Data_Context;
using Data_Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly ECommerceContext db;

        public ProductRepo(ECommerceContext db)
        {
            this.db = db;
        }

        #region AddProduct
        public void AddProduct(Products product)
        {
           db.products.Add(product);
        }
        #endregion

        #region DeleteProduct
        public void DeleteProduct(int id)
        {
            var product = db.products.Find(id);

            if(product != null)
            {
                db.products.Remove(product);
            }
        }
        #endregion

        #region GetProductById
        public async Task<Products> GetProductById(int id)
        {
            var product = await db.products.FindAsync(id);
            return product;
        }
        #endregion

        #region GetProductsAsync
        public async Task<IEnumerable<Products>> GetProductsAsync()
        {
            return await db.products.ToListAsync();
        }
        #endregion

        public int GetCategoryId(string name)
        {
            return db.categories.FirstOrDefault(c => c.Title == name).CategoryID;
        }

        public int GetBrandId(string name)
        {
            return db.brands.FirstOrDefault(c => c.Title == name).BrandID;
        }

        public string GetCategoryName(int id)
        {
            return db.categories.FirstOrDefault(a => a.CategoryID == id).Title;
        }

        public string GetBrandName(int id)
        {
            return db.brands.FirstOrDefault(a => a.BrandID == id).Title;
        }
    }
}

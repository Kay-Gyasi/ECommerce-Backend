using API.Interfaces;
using Data_Layer.Data_Context;
using Data_Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repository
{
    public class BrandRepo : IBrandRepo
    {
        private readonly ECommerceContext db;

        public BrandRepo(ECommerceContext db)
        {
            this.db = db;
        }

        #region AddBrand
        public void AddBrand(Brands brand)
        {
            db.brands.Add(brand);
        }
        #endregion

        #region DeleteBrand
        public void DeleteBrand(int id)
        {
            var brand = db.brands.Find(id);

            if(brand != null)
            {
                db.brands.Remove(brand);
            }   
        }
        #endregion

        #region GetBrandById
        public async Task<Brands> GetBrandById(int id)
        {
            return await db.brands.FindAsync(id);
        }
        #endregion

        #region GetBrandsAsync
        public async Task<IEnumerable<Brands>> GetBrandsAsync()
        {
            return await db.brands.ToListAsync();
        }
        #endregion
    }
}

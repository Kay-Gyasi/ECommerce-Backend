using API.Data.Repository;
using API.Interfaces;
using Data_Layer.Data_Context;

namespace API.Data.Unit_Of_Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceContext db;

        public UnitOfWork(ECommerceContext db)
        {
            this.db = db;
        }

        public IBrandRepo BrandRepo => new BrandRepo(db);

        public ICategoryRepo CategoryRepo => new CategoryRepo(db);

        public IProductRepo ProductRepo => new ProductRepo(db);

        public IUserRepo UserRepo => new UserRepo(db);

        #region SaveAsync
        public async Task<bool> SaveAsync()
        {
            return await db.SaveChangesAsync() > 0;
        }
        #endregion
    }
}

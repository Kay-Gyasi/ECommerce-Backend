namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        IBrandRepo BrandRepo { get; }

        ICategoryRepo CategoryRepo { get; }

        IProductRepo ProductRepo { get; }

        IUserRepo UserRepo { get; } 

        Task<bool> SaveAsync();
    }
}

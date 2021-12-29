using Data_Layer.Models;

namespace API.Interfaces
{
    public interface IBrandRepo
    {
        Task<IEnumerable<Brands>> GetBrandsAsync();

        void AddBrand(Brands brand);

        void DeleteBrand(int id);

        Task<Brands> GetBrandById(int id);
    }
}

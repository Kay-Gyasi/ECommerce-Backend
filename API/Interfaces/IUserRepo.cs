using Data_Layer.Models;

namespace API.Interfaces
{
    public interface IUserRepo
    {
        Task<IEnumerable<Users>> GetUsersAsync();

        void AddUser(Users users);

        void DeleteUser(int id);

        Task<Users> GetUsersById(int id);
    }
}

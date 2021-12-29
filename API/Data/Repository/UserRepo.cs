using API.Interfaces;
using Data_Layer.Data_Context;
using Data_Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly ECommerceContext db;

        public UserRepo(ECommerceContext db)
        {
            this.db = db;
        }

        #region AddUser
        public void AddUser(Users users)
        {
            db.users.Add(users);
        }
        #endregion

        #region DeleteUser
        public void DeleteUser(int id)
        {
            var user = db.users.Find(id);

            if(user != null)
            {
                db.users.Remove(user);
            }
        }
        #endregion

        #region GetUsersAsync
        public async Task<IEnumerable<Users>> GetUsersAsync()
        {
            return await db.users.ToListAsync();
        }
        #endregion

        #region GetUsersById
        public async Task<Users> GetUsersById(int id)
        {
            return await db.users.FindAsync(id);
        }
        #endregion
    }
}

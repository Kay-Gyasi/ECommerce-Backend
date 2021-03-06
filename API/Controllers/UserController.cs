using API.DTOs;
using API.Interfaces;
using Data_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
   
    public class UserController : BaseController
    {
        private readonly IUnitOfWork uow;

        public UserController(IUnitOfWork uow)
        {
            this.uow = uow;
        }


        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await uow.UserRepo.GetUsersAsync();

            var usersDto = from c in users
                           select new UsersDto()
                           {
                               CustomerID = c.CustomerID,
                               FirstName = c.FirstName,
                               LastName = c.LastName,
                               Email = c.Email,
                               Password = c.Password,
                               Address = c.Address,
                               Phone = c.Phone
                           };

            return Ok(usersDto);
        }

        
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            uow.UserRepo.DeleteUser(id);

            await uow.SaveAsync();

            return Ok(id);
        }


        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(AccountsDto user)
        {
            var name = user.FirstName + ' ' + user.LastName;

            if (await uow.UserRepo.UserAlreadyExists(name))
            {
                return BadRequest("User already registered");
            }

            uow.UserRepo.Register(user);

            await uow.SaveAsync();

            return Ok("User added successfully");
        }


        // [HttpPut("")]
    }
}

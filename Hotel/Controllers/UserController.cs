using Hotel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly HotelDbContext userDbContext;

        public UserController(HotelDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        [HttpGet]
        [Route("GetUsers")]

        public List<User> GetUsers()
        {
            return userDbContext.User.ToList();
        }


        [HttpPost]
        [Route("AddUser")]

        public string AddUser(User user) 
        {
            string response = string.Empty;
            userDbContext.User.Add(user);
            userDbContext.SaveChanges();
            return "User Added";
        }

        [HttpPut]
        [Route("UpdateUser")]

        public string UpdateUser(User user) 
        {
            userDbContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            userDbContext.SaveChanges();
            return "User Updated";
        }


        [HttpDelete]
        [Route("DeleteUser")]

        public string DeleteUser(int id) 
        {
            User user = userDbContext.User.Where(x => x.User_Id == id).FirstOrDefault();
            if (user != null) 
            {
                userDbContext.User.Remove(user);
                userDbContext.SaveChanges();
                return "User Deleted";
            }
            else
            {
                return "No User found";
            }
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagementApi.Data;

namespace UserManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext context;

        public UserController(DataContext dataContext)
        {
            this.context=dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {

            return Ok(await context.Users.ToListAsync());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<User>>> Get(int id)
        {
            var user = await context.Users.FindAsync(id);
            {
                if (user == null)
                    return BadRequest("User not found.");
                return Ok(user);
            }
        }


        // Search using FirstName

        //[HttpGet("{FirstName}")]

        //public async Task<ActionResult<List<User>>> Get(string FirstName)
        //{
        //    var user = await context.Users.FindAsync();
        //    {
        //        if (user == null)
        //            return BadRequest("User not found.");
        //        return Ok(user);
        //    }
        //}


        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return Ok(await context.Users.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(User request)
        {

            var dbUser = await context.Users.FindAsync(request.Id);
            {
                if (dbUser == null)
                    return BadRequest("User not found.");

                dbUser.Title = request.Title;
                dbUser.FirstName = request.FirstName;
                dbUser.LastName = request.LastName;
                dbUser.DateOfBirth = request.DateOfBirth;
                dbUser.Gender = request.Gender;
                dbUser.Password = request.Password;
                dbUser.Remark = request.Remark;
            }

            await context.SaveChangesAsync();
            return Ok(await context.Users.ToListAsync());
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<User>>> Delete(int id)
        {
            var dbUser = await context.Users.FindAsync(id);
            {
                if (dbUser == null)
                    return BadRequest("User not found.");
                context.Users.Remove(dbUser);
                await context.SaveChangesAsync();
                return Ok(await context.Users.ToListAsync());
            }
        }

    }
}

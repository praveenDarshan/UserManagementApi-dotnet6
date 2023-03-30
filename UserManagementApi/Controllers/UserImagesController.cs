using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagementApi.Data;

namespace UserManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserImagesController : ControllerBase
    {
        private readonly DataContext context;
        public UserImagesController(DataContext dataContext)
        {
            this.context = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserImages>>> Get()
        {

            return Ok(await context.UserImages.ToListAsync());
        }

        [HttpGet("{Imageid}")]

        public async Task<ActionResult<List<UserImages>>> Get(int Imageid)
        {
            var user = await context.UserImages.FindAsync(Imageid);
            {
                if (user == null)
                    return BadRequest("User Images not found.");
                return Ok(user);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<UserImages>>> AddUserImage(UserImages Image)
        {
            await context.UserImages.AddAsync(Image);
            await context.SaveChangesAsync();

            return Ok(await context.UserImages.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<UserImages>>> UpdateUser(UserImages request)
        {

            var dbUser = await context.UserImages.FindAsync(request.Id);
            {
                if (dbUser == null)
                    return BadRequest("User Image not found.");

                dbUser.ImagesPath = request.ImagesPath;
            }

            await context.SaveChangesAsync();
            return Ok(await context.UserImages.ToListAsync());
        }

        [HttpDelete("{Imageid}")]

        public async Task<ActionResult<List<UserImages>>> Delete(int Imageid)
        {
            var dbUser = await context.UserImages.FindAsync(Imageid);
            {
                if (dbUser == null)
                    return BadRequest("User Image not found.");
                context.UserImages.Remove(dbUser);
                await context.SaveChangesAsync();
                return Ok(await context.UserImages.ToListAsync());
            }
        }
    }
}

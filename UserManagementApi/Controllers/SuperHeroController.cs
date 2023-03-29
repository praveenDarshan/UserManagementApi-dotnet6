using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagementApi.Data;

namespace UserManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
        {


                new SuperHero
                {
                    Id = 1,
                    Name = "Spider Man",
                    FirstName = "Peter",
                    LastName =  "Parker",
                    Place = "NYC"
                },
                new SuperHero
                {
                    Id = 2,
                    Name = "Bat Man",
                    FirstName = "Bruz",
                    LastName =  "Wayne",
                    Place = "NYC"
                }

        };
        private readonly DataContext context;

        public SuperHeroController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {

            return Ok(await context.SuperHeroes.ToListAsync());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<SuperHero>>> Get(int id)
        {
             var hero =  await context.SuperHeroes.FindAsync(id);// heroes.Find(h => h.Id == id);
            {
                if (hero == null)
                    return BadRequest("Hero not found.");
                return Ok(hero);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            await context.SuperHeroes.AddAsync(hero);
            await context.SaveChangesAsync();
            
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {

            var dbhero = await context.SuperHeroes.FindAsync(request.Id);
            {
                if (dbhero == null)
                    return BadRequest("Hero not found.");

                dbhero.Name = request.Name;
                dbhero.FirstName = request.FirstName;
                dbhero.LastName = request.LastName;
                dbhero.Place = request.Place;

            }

            await context.SaveChangesAsync();
            return Ok(await context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var dbhero = await context.SuperHeroes.FindAsync(id);
            {
                if (dbhero == null)
                    return BadRequest("Hero not found.");
                 context.SuperHeroes.Remove(dbhero);
                await context.SaveChangesAsync();
                return Ok(await context.SuperHeroes.ToListAsync());
            }
        }

    }
}

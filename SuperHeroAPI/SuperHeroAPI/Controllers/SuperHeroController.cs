using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            return new List<SuperHero>() 
            { 
                new SuperHero 
                { 
                    Name = "Batman",
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    Place = "Gotham City",
                } 
            };
        }
    }
}

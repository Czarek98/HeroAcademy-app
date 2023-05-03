using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;

namespace SuperHeroAPI.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class SuperHeroController : ControllerBase
  {
    private readonly DataContext _dbContext;

    public SuperHeroController(DataContext dbContext)
    {
      _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
    {
      return Ok(await _dbContext.SuperHeroes.ToListAsync());
    }
  }
}

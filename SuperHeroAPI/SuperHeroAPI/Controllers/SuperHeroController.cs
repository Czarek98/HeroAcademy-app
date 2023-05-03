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

    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> AddSuperHero(SuperHero superHero)
    {
      _dbContext.SuperHeroes.Add(superHero);
      await _dbContext.SaveChangesAsync();
      return Ok(await _dbContext.SuperHeroes.ToListAsync());
    }

    [HttpPut]
    public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero superHero)
    {
      var dbHero = await _dbContext.SuperHeroes.FindAsync(superHero.Id);
      if (dbHero == null)
      {
        return BadRequest("Hero not found!");
      }

      dbHero.Name = superHero.Name;
      dbHero.FirstName = superHero.FirstName;
      dbHero.LastName = superHero.LastName;
      dbHero.Place = superHero.Place;
      await _dbContext.SaveChangesAsync();
      return Ok(await _dbContext.SuperHeroes.ToListAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
    {
      var dbHero = await _dbContext.SuperHeroes.FindAsync(id);
      if (dbHero == null)
      {
        return BadRequest("Hero not found!");
      }

      _dbContext.SuperHeroes.Remove(dbHero);
      await _dbContext.SaveChangesAsync();
      return Ok(await _dbContext.SuperHeroes.ToListAsync());
    }
    /*
    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> AddSuperHeroes(List<SuperHero> superHeroesList)
    {
      await _dbContext.SuperHeroes.AddRangeAsync(superHeroesList);
      await _dbContext.SaveChangesAsync();
      return 

    }
    */
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SafariApi.Models;

namespace SafariApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SeenAnimalsController : ControllerBase
  {
    [HttpGet]
    //https://localhost:5001/api/SeenAnimals 
    //In order by times seen
    public IEnumerable<SeenAnimals> Get()
    {
      var db = new SeenAnimalsContext();
      return db.SeenAnimals.OrderBy(o => o.CountOfTimesSeen);
    }
    [HttpGet("{location}")]
    public IEnumerable<SeenAnimals> GetByLocation(string location)
    {
      var db = new SeenAnimalsContext();
      return db.SeenAnimals.Where(w => w.LocationOfLastSeen.ToLower() == location.ToLower());
    }
    [HttpPost]
    public ActionResult<SeenAnimals> Post([FromBody] SeenAnimals seenAnimals)
    {
      var db = new SeenAnimalsContext();
      db.SeenAnimals.Add(seenAnimals);
      db.SaveChanges();
      return seenAnimals;
    }


    [HttpDelete("{id}")]
    //https://localhost:5001/api/SeenAnimals/1 
    public ActionResult Delete(int id)
    {
      var db = new SeenAnimalsContext();
      var animal = db.SeenAnimals.FirstOrDefault(a => a.Id == id);
      if (animal == null)
      {
        return NotFound();
      }
      db.SeenAnimals.Remove(animal);
      //save changed
      db.SaveChanges();
      //return 200
      return Ok();
    }

    [HttpPut("{id}")]
    //https://localhost:5001/api/SeenAnimals/3 
    public ActionResult<SeenAnimals> Put([FromRoute] int id, [FromBody] SeenAnimals updatedData)
    {
      //The actual update
      var db = new SeenAnimalsContext();
      var seenAnimals = db.SeenAnimals.FirstOrDefault(animal => animal.Id == id);

      seenAnimals.Species = updatedData.Species;
      seenAnimals.CountOfTimesSeen = updatedData.CountOfTimesSeen;
      seenAnimals.LocationOfLastSeen = updatedData.LocationOfLastSeen;

      db.SaveChanges();

      return updatedData;
    }

  }
}
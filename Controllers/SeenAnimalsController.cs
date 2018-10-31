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
    public IEnumerable<SeenAnimals> Get()
    {
      var db = new SeenAnimalsContext();
      return db.SeenAnimals.OrderBy(o => o.CountOfTimesSeen);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

  }
}
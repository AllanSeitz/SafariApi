using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SafariApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SeenAnimalsController : ControllerBase
  {
    [HttpGet]
    public IEnumerable<Models.SeenAnimals> Get()
    {
      var db = new SeenAnimalsContext();
      return db.SeenAnimals.OrderBy(o => o.CountOfTimesSeen);
    }

  }
}
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
  public class SearchController : ControllerBase
  {
    [HttpGet]
    public IQueryable<SeenAnimals> Search(string searchTerm)
    {
      var db = new SeenAnimalsContext();

      var results = db.SeenAnimals.Where(w => w.Species.ToLower().Contains(searchTerm.ToLower()));

      return results;
      //https://localhost:5001/api/search?searchTerm=Li
    }
  }
}
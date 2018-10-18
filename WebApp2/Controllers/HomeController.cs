using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebApp2.Models;

namespace WebApp2.Controllers
{
    [Route("api/home")]
    public class HomeController : Controller
    {
        ApplicationContext db;
        IHostingEnvironment env;
        public HomeController(ApplicationContext _db, IHostingEnvironment _env)
        {
            db = _db;
            env = _env;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovie()
        {
            var movies = db.Movies.ToList();
            return movies;
        }


        [Authorize]
        [HttpPost]
        public ActionResult Add([FromBody]Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Movies.Add(movie);
            db.SaveChanges();
            return Ok();
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [Authorize]
        [Route("{id}")]
        public ActionResult Delete(Guid id)
        {
            Movie movie = db.Movies.Find(id);
            if(movie == null)
            {
                return NotFound();
            }
            
            db.Movies.Remove(movie);
            db.SaveChanges();

            return Ok();
        }

        [Authorize]
        [HttpPut]
        public ActionResult PutMovie([FromBody]Movie movie)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Movies.Update(movie);
            try
            {
                db.SaveChanges();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!MovieExists(movie.Id))
                {
                    return NotFound();
                }else
                {
                    throw;
                }
            }
            return Ok();
        }

        private bool MovieExists(Guid id)
        {
            return db.Movies.Count(e => e.Id == id) > 0;
        }
    }
}
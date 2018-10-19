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
        UnitOfWork db;
        IHostingEnvironment env;
        public HomeController(IHostingEnvironment _env)
        {
            db = new UnitOfWork();
            env = _env;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovie()
       {
            var movies = db.Movies.GetAll().ToList();
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
            db.Movies.Create(movie);
            db.Save();
            return Ok();
        }

        [Authorize]
        [Route("{id}")]
        public ActionResult Delete(Guid id)
        {
            db.Movies.Delete(id);
            db.Save();

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
                db.Save();
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
            return db.Movies.Count(id) > 0;
        }
    }
}
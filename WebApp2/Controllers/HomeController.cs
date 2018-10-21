using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp2.Models;
using WebApp2.Models.Abstract;

namespace WebApp2.Controllers
{
    [Route("api/home")]
    public class HomeController : Controller
    {
        private IMovieRepository db;
        IHostingEnvironment env;
        public HomeController(IMovieRepository _repository, IHostingEnvironment _env)
        {
            db = _repository;
            env = _env;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovie()
        {
            var movies = db.GetAll().ToList();
            return movies;
        }

        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            var movie = db.Get(id);
            if (movie != null)
            {
                return Ok(movie);
            }
            else
            {
                return NotFound();
            }

        }



        [Authorize]
        [HttpPost]
        public ActionResult Add([FromBody]Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Create(movie);
            return Ok();
        }

        [Authorize]
        [Route("{id}")]
        public ActionResult Delete(Guid id)
        {
            Movie movie = db.Get(id);
            if (movie == null)
            {
                return NotFound();
            }

            db.Delete(id);
            return Ok();
        }

        [Authorize]
        [HttpPut]
        public ActionResult PutMovie([FromBody]Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = db.Get(movie.Id);
            if (item != null)
            {
                db.Update(movie);
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

    }
}
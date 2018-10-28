using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApp2.Models.Abstract;

namespace WebApp2.Controllers
{
    [Route("api/genres")]
    public class GenreController : Controller
    {
        private IGenreRepository repository;
        public GenreController(IGenreRepository repos)
        {
            this.repository = repos;
        }


        [HttpGet]
        public IActionResult GetGenres()
        {
            return Ok(repository.GetAll().ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieByGenry(Guid id)
        {
            return Ok(repository.GetById(id));
        }
    }
}
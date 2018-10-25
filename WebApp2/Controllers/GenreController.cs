using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    }
}
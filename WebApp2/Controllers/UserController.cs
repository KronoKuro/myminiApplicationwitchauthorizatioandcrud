using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebApp2.Models.Abstract;

namespace WebApp2.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private IUserRepository db;
        IHostingEnvironment env;

        public UserController(IUserRepository repository, IHostingEnvironment host)
        {
            db = repository;
            env = host;
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            return Ok(db.Get(id));
        }
    }
}
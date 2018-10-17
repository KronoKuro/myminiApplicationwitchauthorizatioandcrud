using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Security.Claims;
using System.Linq;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

   
    [Route("api/news")]
    public class NewsController : Controller
    {
        ApplicationContext db;
        IHostingEnvironment env;

        public NewsController(ApplicationContext _db, IHostingEnvironment _env) {
            db = _db;
            env = _env;
        }

        // GET: api/News
        [HttpGet]
        public IActionResult GetNews()
        {
            return Ok(db.News);
        }

        // GET: api/News/5
        [Authorize]
        public IActionResult GetNews(int id)
        {
            New news = db.News.Find(id);
            if (news == null)
            {
                return NotFound();
            }

            return Ok(news);
        }

        // PUT: api/News/5
        [Authorize]
        [HttpPut]
        public IActionResult PutNews([FromBody] New news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            db.News.Update(news);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsExists(news.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        return Ok();

        }

        public void Options() { }

        // POST: api/News
        [Authorize]
        [HttpPost]
        public IActionResult PostNews([FromBody] New news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.News.Add(news);
            db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = news.Id }, news);
            return Ok();
        }

        // DELETE: api/News/5
        [Authorize]
        [Route("{id}")]
        public IActionResult DeleteNews(int id)
        {
            New news = db.News.Find(id);
            if (news == null)
            {
                return NotFound();
            }

            db.News.Remove(news);
            db.SaveChanges();

            return Ok(news);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NewsExists(int id)
        {
            return db.News.Count(e => e.Id == id) > 0;
        }
    }
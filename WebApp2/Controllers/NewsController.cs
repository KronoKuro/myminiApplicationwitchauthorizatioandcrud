using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApp2.Models.Abstract;


[Route("api/news")]
public class NewsController : Controller
{
    private INewsRepository db;
    IHostingEnvironment env;

    public NewsController(INewsRepository repository, IHostingEnvironment _env)
    {
        db = repository;
        env = _env;
    }

    // GET: api/News
    [HttpGet]
    public IActionResult GetNews()
    {


        var model = db.GetAll().ToList();
        return Ok(model);
    }

    // GET: api/News/5
    [Authorize]
    public IActionResult GetNews(int id)
    {
        New news = db.Get(id);
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

        var item = db.Get(news.Id);
        if (item != null)
        {
            db.Update(news);
        }
        else
        {
            return NotFound();
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

        db.Create(news);
        //return CreatedAtRoute("DefaultApi", new { id = news.Id }, news);
        return Ok();
    }

    // DELETE: api/News/5
    [Authorize]
    [Route("{id}")]
    public IActionResult DeleteNews(int id)
    {
        New news = db.Get(id);
        if (news == null)
        {
            return NotFound();
        }

        db.Delete(id);

        return Ok(news);
    }

}
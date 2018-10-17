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

public class AuthController : Controller {
    ApplicationContext _db;
    IHostingEnvironment _env;

    public AuthController(ApplicationContext db, IHostingEnvironment env) {
        _db = db;
        _env = env;
    }

    [HttpPost("api/token")]
    public IActionResult Token([FromBody] User model) {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var identity = GetIdentity(model.Login, model.Password);
        if(identity == null) 
            return BadRequest("Invalid login or password");

        var now = DateTime.UtcNow;
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            notBefore: now,
            claims: identity.Claims,
            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
        );
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        var response = new {
            access_token = encodedJwt,
            user_name = identity.Name,
        };

        return Ok(response);
    }
    
    public ClaimsIdentity GetIdentity(string login, string password) {
        User user = _db.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
        if(user != null) {
            var claims = new List<Claim> {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, null);
            return claimsIdentity;
        } else {
            return null;
        }
    }

    [Authorize]
    [HttpGet("api/checktoken")]
    public IActionResult GetAccess() {
        return Ok(true);
    }

     [HttpPost("api/register")]
    public IActionResult Register([FromBody] User model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        _db.Users.Add(model);
        _db.SaveChanges();
        return Ok(model);
        
        ViewBag.Message = "Такой пользователь уже есть";
        return BadRequest(model);
    }
}
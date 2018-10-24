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
using WebApp2.Models.Infrastructure;
using WebApp2.Models;

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
            admin = identity.IsAdmin(),
        };

        return Ok(response);
    }
    
    public ClaimsIdentity GetIdentity(string login, string password) {
        password = Crypt.Encript(password, login.ToLower());
        User user = _db.Users.Include(x => x.Role).FirstOrDefault(u => u.Login == login && u.Password == password);
        List<Role> roles = _db.Roles.ToList();
        //Role role = _db.Roles.First(r => r.Id == user.RoleId);
        if(user != null) {
            var claims = new List<Claim> {
                new Claim("name", user.Login),
                new Claim("id", user.Id.ToString(), ClaimValueTypes.String),
                new Claim("role", user.Role.Name),
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token");
            //claimsIdentity.AddClaim(user.Role.Name);
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
        model.Password = Crypt.Encript(model.Password, model.Login.ToLower());
        var role = _db.Roles.First(u => u.Name == "User");
        model.RoleId = role.Id;
        _db.Users.Add(model);
        _db.SaveChanges();
        return Ok(model);
        
        ViewBag.Message = "Такой пользователь уже есть";
        return BadRequest(model);
    }
}
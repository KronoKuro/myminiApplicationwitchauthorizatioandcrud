using Microsoft.AspNetCore.Identity;
using System;
using WebApp2.Models;

public class User : IdentityUser {
    public string Login { get; set; }
    public string Password {get;set;}
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public string RoleId { get; set; }
    public virtual Role Role { get; set; }
}
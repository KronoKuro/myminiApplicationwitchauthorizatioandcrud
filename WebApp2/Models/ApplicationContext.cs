using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp2.Models;

public class ApplicationContext : IdentityDbContext 
{
    public DbSet<New> News { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Movie> Movies { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) 
        :base(options)
    {}
}
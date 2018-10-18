using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using WebApp2.Models;

public class ApplicationContext : IdentityDbContext 
{
    public DbSet<New> News { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Movie> Movies { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) 
        :base(options)
    {
        //Database.EnsureCreated();
    }

    /* protected override void OnModelCreating(ModelBuilder builder)
    {

        //base.OnModelCreating(builder);
       builder.Entity<User>().HasData(new User {Id = Guid.NewGuid().ToString(), Login = "User", Password = "123" });
        builder.Entity<User>().HasData(new User { Id = Guid.NewGuid().ToString(), Login = "Admin", Password = "123" });
        builder.Entity<Movie>().HasData(new Movie
        { Id = Guid.NewGuid(),
            Name = "Test Movie",
            Description = "not yet",
            ReleaseDate = "12.12.12"
        });
        builder.Entity<Movie>().HasData(new Movie
        {
            Id = Guid.NewGuid(),
            Name = "Test Movie2",
            Description = "not yet",
            ReleaseDate = "12.12.12"
        });
        builder.Entity<New>().HasData(new New
        {
            Id = 1,
            Title = "News1",
            Text = "Description to news 1 ",
            DatePost = DateTime.Now,
        });
    }*/
}
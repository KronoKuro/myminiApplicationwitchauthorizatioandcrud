using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp2.Map;
using WebApp2.Models;

public class ApplicationContext : IdentityDbContext
{
    public DbSet<New> News { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Movie> Movies { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Genre> Genres { get; set; }


    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new MovieConfiguration());
        builder.ApplyConfiguration(new NewsConfiguration());
        builder.Entity<GenreMovie>()
            .HasKey(gm => new { gm.GenreId, gm.MovieId });
        builder.Entity<GenreMovie>()
            .HasOne(gm => gm.Movie)
            .WithMany(g => g.GenreMovie)
            .HasForeignKey(gm => gm.MovieId);
        builder.Entity<GenreMovie>()
            .HasOne(gm => gm.Genre)
            .WithMany(g => g.GenreMovie)
            .HasForeignKey(gm => gm.GenreId);
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
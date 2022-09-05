using FilmReviewApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmActorApp.Database
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options){}
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmActor> FilmActors { get; set;}
        public DbSet<FilmCategory> FilmCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<FilmCategory>()
                .HasKey(fc => new { fc.FilmId, fc.CategoryId });
            modelBuilder.Entity<FilmCategory>()
                .HasOne(f => f.Film)
                .WithMany(fc => fc.FilmCategories)
                .HasForeignKey(f => f.FilmId);
            modelBuilder.Entity<FilmCategory>()
                .HasOne(c => c.Category)
                .WithMany(fc => fc.FilmCategories)
                .HasForeignKey(c => c.CategoryId);



            modelBuilder.Entity<FilmActor>()
                .HasKey(fc => new { fc.FilmId, fc.ActorId });
            modelBuilder.Entity<FilmActor>()
                .HasOne(f => f.Film)
                .WithMany(fc => fc.FilmActors)
                .HasForeignKey(f => f.FilmId);
            modelBuilder.Entity<FilmActor>()
                .HasOne(c => c.Actor)
                .WithMany(fc => fc.FilmActors)
                .HasForeignKey(c => c.ActorId);
            
        }

    }
}

using boxify.Data.ModelsDb;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace boxify.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category { Id = "1", Name = "Electronics", Description = "All kinds of electronics - phones, laptops, PCs, TVs ..." });
            modelBuilder.Entity<Category>().HasData(new Category { Id = "2", Name = "Cars", Description = "All types of cars" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = "3", Name = "Animals", Description = "Аll kinds and breeds of animals" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = "4", Name = "Fashions", Description = "Clothes, shoes, accessories..." });
            modelBuilder.Entity<Category>().HasData(new Category { Id = "5", Name = "Services", Description = "Cleaning, catering, beautician..." });


            modelBuilder.Entity<Coment>()
                .HasOne(a => a.Ad)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Coment>()
                .HasOne(u => u.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserFavorite>()
                .HasKey(uf => new { uf.UserId, uf.FavoriteId });

            modelBuilder.Entity<UserFavorite>()
                 .HasOne(f => f.Favourite)
                .WithMany(uf => uf.UserFavorites)
                .HasForeignKey(f => f.FavoriteId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AdTag>()
                .HasKey(at => new { at.AdId, at.TagId });

            

        }


        public DbSet<Ad> Ads { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Coment> Coments { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<UserFavorite> UserFavorite { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<AdTag> AdTags { get; set; }

    }
}
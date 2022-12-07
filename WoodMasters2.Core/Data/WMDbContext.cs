using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WoodMasters2.Core.Data.Configurations;
using WoodMasters2.Core.Data.Entities;

namespace WoodMasters2.Core.Data
{
    public class WMDbContext : IdentityDbContext<Master>
    {
        public WMDbContext(DbContextOptions<WMDbContext> options)
            : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<MasterPiece> MasterPieces { get; set; } = null!;       
        public DbSet<Wood> Woods { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<StarRating> Ratings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString)
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<MasterAddress>()
                .HasKey(x => new { x.MasterId, x.AddressId });

            
            


            builder.Entity<Master>()
                .Property(m => m.UserName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Entity<Master>()
                .Property(m => m.Email)
                .HasMaxLength(60)
                .IsRequired();

            builder.Entity<MasterPiece>()
                .Property(mp => mp.Price)
                .HasColumnType("decimal")
                .HasPrecision(7, 2);

            

            
            //Seeding Masters, Categories, Woods, Rating, Countries, MasterPieces and Addresses example
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new WoodConfiguration());           
            builder.ApplyConfiguration(new CountryConfiguration());           
            builder.ApplyConfiguration(new MasterPieceConfiguration());
            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new MasterAddressConfiguration());        
            builder.ApplyConfiguration(new RatingConfiguration());        

            base.OnModelCreating(builder);
        }
    }
}
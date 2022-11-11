using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
        public DbSet<Stain> Stains { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<Wood> Woods { get; set; } = null!;

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
            
            builder.Entity<MasterPieceWood>()
                .HasKey(x => new { x.MasterPieceId, x.WoodId });

            



            builder.Entity<Master>()
                .Property(m => m.UserName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Entity<Master>()
                .Property(m => m.Email)
                .HasMaxLength(60)
                .IsRequired();

            builder.Entity<MasterPiece>()
                .Property(mp=>mp.Price)
                .HasColumnType("decimal")
                .HasPrecision(7,2);

            builder.Entity<MasterPiece>()
               .Property(mp => mp.Rating)
               .HasColumnType("decimal")
               .HasPrecision(4,2);

            //Seeding Categories, Woods, Suppliers and a MasterPiece example
            builder
           .Entity<Category>()
           .HasData(new Category()
           {
               Id = 1,
               Name = "Woodcarving"
           },
           new Category()
           {
               Id = 2,
               Name = "Woodturning"
           },
           new Category()
           {
               Id = 3,
               Name = "Pyrography"
           },
           new Category()
           {
               Id = 4,
               Name = "Intarsia"
           },
           new Category()
           {
               Id = 5,
               Name = "Scrow Sawing"
           },
           new Category()
           {
               Id = 6,
               Name = "Cabinetry and Furniture"
           },
           new Category()
           {
               Id = 7,
               Name = "Carpentry and Joinery"
           },
           new Category()
           {
               Id = 8,
               Name = "Construction"
           },
           new Category()
           {
               Id = 9,
               Name = "Miscelaneous"
           });

            builder
          .Entity<Wood>()
          .HasData(new Wood()
          {
              Id = 1,
              Type = "Oak"
          },
          new Wood()
          {
              Id = 2,
              Type = "Walnut"
          },
          new Wood()
          {
              Id = 3,
              Type = "Pine"
          },
          new Wood()
          {
              Id = 4,
              Type = "Beech"
          },
          new Wood()
          {
              Id = 5,
              Type = "Linden"
          },
          new Wood()
          {
              Id = 6,
              Type = "Poplar"
          },
          new Wood()
          {
              Id = 7,
              Type = "Birch"
          },
          new Wood()
          {
              Id = 8,
              Type = "Cedar"
          },
          new Wood()
          {
              Id = 9,
              Type = "Ash"
          },
          new Wood()
          {
              Id = 10,
              Type = "Acer"
          });

            builder
         .Entity<Supplier>()
         .HasData(new Supplier()
         {
             Id = 1,
             Name = "Bari Trans LTD"
         },
         new Supplier()
         {
             Id = 2,
             Name = "Ilza LTD"
         },
         new Supplier()
         {
             Id = 3,
             Name = "KoronaIm LTD"
         },
         new Supplier()
         {
             Id = 4,
             Name = "Hardi LTD"
         },
         new Supplier()
         {
             Id = 5,
             Name = "JAF Bulgaria"
         },
         new Supplier()
         {
             Id = 6,
             Name = "Centaur LTD"
         },
         new Supplier()
         {
             Id = 7,
             Name = "Birch"
         },
         new Supplier()
         {
             Id = 8,
             Name = "Cedar"
         },
         new Supplier()
         {
             Id = 9,
             Name = "Ash"
         },
         new Supplier()
         {
             Id = 10,
             Name = "Acer"
         });

            builder
         .Entity<Country>()
         .HasData(new Country()
         {
             Id = 1,
             Name = "Bulgaria"
         },
         new Country()
         {
             Id = 2,
             Name = "Romania"
         },
         new Country()
         {
             Id = 3,
             Name = "Greece"
         },
         new Country()
         {
             Id = 4,
             Name = "Serbia"
         },
         new Country()
         {
             Id = 5,
             Name = "Turkey"
         },
         new Country()
         {
             Id = 6,
             Name = "Brazil"
         },
         new Country()
         {
             Id = 7,
             Name = "Russia"
         },
         new Country()
         {
             Id = 8,
             Name = "Ukraine"
         },
         new Country()
         {
             Id = 9,
             Name = "USA"
         },
         new Country()
         {
             Id = 10,
             Name = "Canada"
         });

            builder
          .Entity<Stain>()
          .HasData(new Stain()
          {
              Id = 1,
              Name = "Clear Coat"
          },
          new Stain()
          {
              Id = 2,
              Name = "Exotic Redwood"
          },
          new Stain()
          {
              Id = 3,
              Name = "Vintage Modern"
          },
          new Stain()
          {
              Id = 4,
              Name = "Golden Sunset"
          },
          new Stain()
          {
              Id = 5,
              Name = "Mocha"
          },
          new Stain()
          {
              Id = 6,
              Name = "Maroccan Red"
          },
          new Stain()
          {
              Id = 7,
              Name = "Silk Grey"
          },
          new Stain()
          {
              Id = 8,
              Name = "Whitish"
          });

            

            //builder
            //   .Entity<MasterPiece>()
            //   .HasData(new MasterPiece()
            //   {
            //       Id = 1,
            //       Name = "Lorem Ipsum",
            //       MasterId = 
            //       Width = 23.5,
            //       Length = 43.5,
            //       Depth = 13.5,
            //       ImageURL = "https://www.harvardmagazine.com/sites/default/files/styles/4x3_main/public/img/article/0613/ja13_page_31_02.jpg",
            //       Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
            //       MasterPiecesCategories = new List<MasterPieceCategory>()
            //       {
            //           new MasterPieceCategory()
            //           {
            //           MasterPieceId = 1,
            //           CategoryId = 1
            //           }
            //       },
            //       MasterPiecesWoods = new List<MasterPieceWood>()
            //       {
            //           new MasterPieceWood()
            //           {
            //           MasterPieceId = 1,
            //           WoodId = 1
            //           }
            //       },

            //       Price = 1543.34m,
            //       Quantity = 1,
            //       Rating = 9.9m
            //   });



            base.OnModelCreating(builder);
        }
    }
}
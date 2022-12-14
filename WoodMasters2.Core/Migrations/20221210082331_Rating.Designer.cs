// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WoodMasters2.Core.Data;

#nullable disable

namespace WoodMasters2.Core.Migrations
{
    [DbContext(typeof(WMDbContext))]
    [Migration("20221210082331_Rating")]
    partial class Rating
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("PlaceName")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            PlaceName = "Varna, 37 Evlogi Georgiev str."
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            PlaceName = "Sofia, 3 Musala str."
                        });
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Woodcarving"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Woodturning"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pyrography"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Intarsia"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Scrow Sawing"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Cabinetry and Furniture"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Carpentry and Joinery"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Construction"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Miscelaneous"
                        });
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MasterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MasterPieceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostingTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MasterId");

                    b.HasIndex("MasterPieceId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bulgaria"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Romania"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Greece"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Serbia"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Turkey"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Brazil"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Russia"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Ukraine"
                        },
                        new
                        {
                            Id = 9,
                            Name = "USA"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Canada"
                        });
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MasterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MasterId");

                    b.ToTable("Favorite");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Master", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dea12856-c198-4129-b3f3-b893d8395082",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7a777aae-0d31-48cf-9612-095e419c8769",
                            CreatedOn = new DateTime(2022, 12, 10, 10, 23, 31, 47, DateTimeKind.Local).AddTicks(615),
                            Email = "m_eftimov@yahoo.com",
                            EmailConfirmed = false,
                            Experience = 0,
                            FirstName = "Momchil",
                            LastName = "Eftimov",
                            LockoutEnabled = false,
                            NormalizedEmail = "M_EFTIMOV@YAHOO.COM",
                            NormalizedUserName = "MOMO12",
                            PasswordHash = "AQAAAAEAACcQAAAAEM9kiqBSkfdixbKFcy0OMDvURLmoDtRjKFwFPJjZHcNmpahDaDes8mnxPVIxM6/ZAQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "92bb6fe5-837a-4d8e-a8a7-8caae7469042",
                            TwoFactorEnabled = false,
                            UserName = "Momo12"
                        },
                        new
                        {
                            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b7bfbc72-fac8-4a94-a713-d3a9148f8f1d",
                            CreatedOn = new DateTime(2022, 12, 10, 10, 23, 31, 54, DateTimeKind.Local).AddTicks(6609),
                            Email = "b_eftimov@yahoo.com",
                            EmailConfirmed = false,
                            Experience = 0,
                            FirstName = "Boris",
                            LastName = "Eftimov",
                            LockoutEnabled = false,
                            NormalizedEmail = "B_EFTIMOV@YAHOO.COM",
                            NormalizedUserName = "CAPTAIN76",
                            PasswordHash = "AQAAAAEAACcQAAAAEC9WVmO2uw84Wnmn6j2qz2pzTEdetLY9GtTimU/uie0H90C7M9eEZ+pBN4dro6yV3w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fce8aed7-5018-47e7-9abb-7a8e2577dd64",
                            TwoFactorEnabled = false,
                            UserName = "captain76"
                        });
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.MasterAddress", b =>
                {
                    b.Property<string>("MasterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.HasKey("MasterId", "AddressId");

                    b.HasIndex("AddressId");

                    b.ToTable("MasterAddress");

                    b.HasData(
                        new
                        {
                            MasterId = "dea12856-c198-4129-b3f3-b893d8395082",
                            AddressId = 1
                        },
                        new
                        {
                            MasterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            AddressId = 2
                        });
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.MasterPiece", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<double>("Depth")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<string>("MasterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasPrecision(7, 2)
                        .HasColumnType("decimal(7,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.Property<int>("WoodId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MasterId");

                    b.HasIndex("WoodId");

                    b.ToTable("MasterPieces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Depth = 10.0,
                            Description = "Flowers and leaves carved as a 3D model",
                            ImageURL = "https://www.harvardmagazine.com/sites/default/files/styles/4x3_main/public/img/article/0613/ja13_page_31_02.jpg",
                            IsDeleted = false,
                            Length = 40.0,
                            MasterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            Name = "Flowers",
                            Price = 2000m,
                            Quantity = 1,
                            Width = 60.0,
                            WoodId = 5
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 4,
                            Depth = 5.0,
                            Description = "A beautiful tribal mosaics build from stained woods",
                            ImageURL = "https://i0.wp.com/100things2do.ca/wp-content/uploads/2021/06/scrapwood-snowflake-12.jpg",
                            IsDeleted = false,
                            Length = 50.0,
                            MasterId = "dea12856-c198-4129-b3f3-b893d8395082",
                            Name = "Tribal Mosaic",
                            Price = 50m,
                            Quantity = 2,
                            Width = 50.0,
                            WoodId = 3
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Depth = 12.0,
                            Description = "A wooden bowl from cedar tree",
                            ImageURL = "https://www.dougsturnings.com/wp-content/uploads/2020/04/Doug-Heck-Maryland-Woodturner-8636-1024x682-1.jpg",
                            IsDeleted = false,
                            Length = 20.0,
                            MasterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            Name = "Wooden Bowl",
                            Price = 100m,
                            Quantity = 4,
                            Width = 20.0,
                            WoodId = 8
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 7,
                            Depth = 40.0,
                            Description = "A wooden crate to store your staff all around!!!",
                            ImageURL = "https://www.ana-white.com/sites/default/files/wood-crate-how-to-build-1.jpg",
                            IsDeleted = false,
                            Length = 60.0,
                            MasterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                            Name = "Crate",
                            Price = 20m,
                            Quantity = 100,
                            Width = 40.0,
                            WoodId = 3
                        });
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.StarRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MasterPieceId")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MasterPieceId");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MasterPieceId = 1,
                            Rate = 3
                        },
                        new
                        {
                            Id = 2,
                            MasterPieceId = 2,
                            Rate = 4
                        },
                        new
                        {
                            Id = 3,
                            MasterPieceId = 3,
                            Rate = 5
                        },
                        new
                        {
                            Id = 4,
                            MasterPieceId = 4,
                            Rate = 3
                        },
                        new
                        {
                            Id = 5,
                            MasterPieceId = 1,
                            Rate = 5
                        },
                        new
                        {
                            Id = 6,
                            MasterPieceId = 3,
                            Rate = 2
                        });
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Wood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Woods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Oak"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Walnut"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Pine"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Beech"
                        },
                        new
                        {
                            Id = 5,
                            Type = "Linden"
                        },
                        new
                        {
                            Id = 6,
                            Type = "Poplar"
                        },
                        new
                        {
                            Id = 7,
                            Type = "Birch"
                        },
                        new
                        {
                            Id = 8,
                            Type = "Cedar"
                        },
                        new
                        {
                            Id = 9,
                            Type = "Ash"
                        },
                        new
                        {
                            Id = 10,
                            Type = "Acer"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WoodMasters2.Core.Data.Entities.Master", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WoodMasters2.Core.Data.Entities.Master", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WoodMasters2.Core.Data.Entities.Master", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WoodMasters2.Core.Data.Entities.Master", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Address", b =>
                {
                    b.HasOne("WoodMasters2.Core.Data.Entities.Country", "Country")
                        .WithMany("Addresses")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Comment", b =>
                {
                    b.HasOne("WoodMasters2.Core.Data.Entities.Master", "Master")
                        .WithMany("Comments")
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WoodMasters2.Core.Data.Entities.MasterPiece", "MasterPiece")
                        .WithMany()
                        .HasForeignKey("MasterPieceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Master");

                    b.Navigation("MasterPiece");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Favorite", b =>
                {
                    b.HasOne("WoodMasters2.Core.Data.Entities.Master", null)
                        .WithMany("Favorites")
                        .HasForeignKey("MasterId");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.MasterAddress", b =>
                {
                    b.HasOne("WoodMasters2.Core.Data.Entities.Address", "Address")
                        .WithMany("MastersAddresses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WoodMasters2.Core.Data.Entities.Master", "Master")
                        .WithMany("MastersAddresses")
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Master");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.MasterPiece", b =>
                {
                    b.HasOne("WoodMasters2.Core.Data.Entities.Category", "Category")
                        .WithMany("MasterPieces")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WoodMasters2.Core.Data.Entities.Master", "Master")
                        .WithMany("MasterPieces")
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WoodMasters2.Core.Data.Entities.Wood", "Wood")
                        .WithMany("MasterPieces")
                        .HasForeignKey("WoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Master");

                    b.Navigation("Wood");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.StarRating", b =>
                {
                    b.HasOne("WoodMasters2.Core.Data.Entities.MasterPiece", "MasterPiece")
                        .WithMany("Rating")
                        .HasForeignKey("MasterPieceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MasterPiece");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Address", b =>
                {
                    b.Navigation("MastersAddresses");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Category", b =>
                {
                    b.Navigation("MasterPieces");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Country", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Master", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Favorites");

                    b.Navigation("MasterPieces");

                    b.Navigation("MastersAddresses");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.MasterPiece", b =>
                {
                    b.Navigation("Rating");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Wood", b =>
                {
                    b.Navigation("MasterPieces");
                });
#pragma warning restore 612, 618
        }
    }
}

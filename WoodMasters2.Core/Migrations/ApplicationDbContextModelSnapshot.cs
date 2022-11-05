﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WoodMasters2.Core.Data;

#nullable disable

namespace WoodMasters2.Core.Migrations
{
    [DbContext(typeof(WMDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Country", b =>
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

                    b.Property<decimal>("Rating")
                        .HasPrecision(4, 2)
                        .HasColumnType("decimal(4,2)");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MasterId");

                    b.ToTable("MasterPieces");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.MasterPieceWood", b =>
                {
                    b.Property<int>("MasterPieceId")
                        .HasColumnType("int");

                    b.Property<int>("WoodId")
                        .HasColumnType("int");

                    b.HasKey("MasterPieceId", "WoodId");

                    b.HasIndex("WoodId");

                    b.ToTable("MasterPieceWood");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Stain", b =>
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

                    b.ToTable("Stains");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Clear Coat"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Exotic Redwood"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Vintage Modern"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Golden Sunset"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Mocha"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Maroccan Red"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Silk Grey"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Whitish"
                        });
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Supplier", b =>
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

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bari Trans LTD"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ilza LTD"
                        },
                        new
                        {
                            Id = 3,
                            Name = "KoronaIm LTD"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Hardi LTD"
                        },
                        new
                        {
                            Id = 5,
                            Name = "JAF Bulgaria"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Centaur LTD"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Birch"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Cedar"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Ash"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Acer"
                        });
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Wood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("StainId")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("StainId");

                    b.HasIndex("SupplierId");

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
                        .WithMany()
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Master");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.MasterPieceWood", b =>
                {
                    b.HasOne("WoodMasters2.Core.Data.Entities.MasterPiece", "MasterPiece")
                        .WithMany("MasterPiecesWoods")
                        .HasForeignKey("MasterPieceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WoodMasters2.Core.Data.Entities.Wood", "Wood")
                        .WithMany("MasterPiecesWoods")
                        .HasForeignKey("WoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MasterPiece");

                    b.Navigation("Wood");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Wood", b =>
                {
                    b.HasOne("WoodMasters2.Core.Data.Entities.Stain", null)
                        .WithMany("Woods")
                        .HasForeignKey("StainId");

                    b.HasOne("WoodMasters2.Core.Data.Entities.Supplier", null)
                        .WithMany("Woods")
                        .HasForeignKey("SupplierId");
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
                    b.Navigation("MastersAddresses");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.MasterPiece", b =>
                {
                    b.Navigation("MasterPiecesWoods");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Stain", b =>
                {
                    b.Navigation("Woods");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Supplier", b =>
                {
                    b.Navigation("Woods");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Wood", b =>
                {
                    b.Navigation("MasterPiecesWoods");
                });
#pragma warning restore 612, 618
        }
    }
}

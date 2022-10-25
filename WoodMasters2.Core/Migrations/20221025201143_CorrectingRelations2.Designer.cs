﻿// <auto-generated />
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
    [Migration("20221025201143_CorrectingRelations2")]
    partial class CorrectingRelations2
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

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.MasterMasterPiece", b =>
                {
                    b.Property<string>("MasterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MasterPieceId")
                        .HasColumnType("int");

                    b.HasKey("MasterId", "MasterPieceId");

                    b.HasIndex("MasterPieceId");

                    b.ToTable("MasterMasterPiece");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.MasterPiece", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Depth")
                        .HasColumnType("float");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasPrecision(2)
                        .HasColumnType("decimal(2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Rating")
                        .HasPrecision(2)
                        .HasColumnType("decimal(2)");

                    b.Property<double>("Width")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("MasterPieces");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.MasterPieceCategory", b =>
                {
                    b.Property<int>("MasterPieceId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("MasterPieceId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("MasterPieceCategory");
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
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.WoodStain", b =>
                {
                    b.Property<int>("WoodId")
                        .HasColumnType("int");

                    b.Property<int>("StainId")
                        .HasColumnType("int");

                    b.HasKey("WoodId", "StainId");

                    b.HasIndex("StainId");

                    b.ToTable("WoodStain");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.WoodSupplier", b =>
                {
                    b.Property<int>("WoodId")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("WoodId", "SupplierId");

                    b.HasIndex("SupplierId");

                    b.ToTable("WoodSupplier");
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

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.MasterMasterPiece", b =>
                {
                    b.HasOne("WoodMasters2.Core.Data.Entities.Master", "Master")
                        .WithMany("MastersMasterPieces")
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WoodMasters2.Core.Data.Entities.MasterPiece", "MasterPiece")
                        .WithMany("MastersMasterPieces")
                        .HasForeignKey("MasterPieceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Master");

                    b.Navigation("MasterPiece");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.MasterPieceCategory", b =>
                {
                    b.HasOne("WoodMasters2.Core.Data.Entities.Category", "Category")
                        .WithMany("MasterPiecesCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WoodMasters2.Core.Data.Entities.MasterPiece", "MasterPiece")
                        .WithMany("MasterPiecesCategories")
                        .HasForeignKey("MasterPieceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("MasterPiece");
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

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.WoodStain", b =>
                {
                    b.HasOne("WoodMasters2.Core.Data.Entities.Stain", "Stain")
                        .WithMany("WoodsStains")
                        .HasForeignKey("StainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WoodMasters2.Core.Data.Entities.Wood", "Wood")
                        .WithMany("WoodsStains")
                        .HasForeignKey("WoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stain");

                    b.Navigation("Wood");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.WoodSupplier", b =>
                {
                    b.HasOne("WoodMasters2.Core.Data.Entities.Supplier", "Supplier")
                        .WithMany("WoodsSuppliers")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WoodMasters2.Core.Data.Entities.Wood", "Wood")
                        .WithMany("WoodsSuppliers")
                        .HasForeignKey("WoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");

                    b.Navigation("Wood");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Address", b =>
                {
                    b.Navigation("MastersAddresses");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Category", b =>
                {
                    b.Navigation("MasterPiecesCategories");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Country", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Master", b =>
                {
                    b.Navigation("MastersAddresses");

                    b.Navigation("MastersMasterPieces");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.MasterPiece", b =>
                {
                    b.Navigation("MasterPiecesCategories");

                    b.Navigation("MasterPiecesWoods");

                    b.Navigation("MastersMasterPieces");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Stain", b =>
                {
                    b.Navigation("WoodsStains");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Supplier", b =>
                {
                    b.Navigation("WoodsSuppliers");
                });

            modelBuilder.Entity("WoodMasters2.Core.Data.Entities.Wood", b =>
                {
                    b.Navigation("MasterPiecesWoods");

                    b.Navigation("WoodsStains");

                    b.Navigation("WoodsSuppliers");
                });
#pragma warning restore 612, 618
        }
    }
}

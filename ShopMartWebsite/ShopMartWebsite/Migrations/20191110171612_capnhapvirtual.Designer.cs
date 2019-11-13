﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ShopMartWebsite.Data;
using ShopMartWebsite.Entities;
using System;

namespace ShopMartWebsite.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    [Migration("20191110171612_capnhapvirtual")]
    partial class capnhapvirtual
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ShopMartWebsite.Entities.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<bool>("status");

                    b.HasKey("id");

                    b.ToTable("category");
                });

            modelBuilder.Entity("ShopMartWebsite.Entities.Comment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("content");

                    b.Property<DateTime>("createDate");

                    b.Property<int>("productId");

                    b.Property<int>("userId");

                    b.Property<string>("userId1");

                    b.HasKey("id");

                    b.HasIndex("productId");

                    b.HasIndex("userId1");

                    b.ToTable("comment");
                });

            modelBuilder.Entity("ShopMartWebsite.Entities.ImageProduct", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("alt");

                    b.Property<int>("productId");

                    b.Property<string>("url");

                    b.HasKey("id");

                    b.HasIndex("productId");

                    b.ToTable("images");
                });

            modelBuilder.Entity("ShopMartWebsite.Entities.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("createDate");

                    b.Property<bool>("status");

                    b.Property<decimal>("total");

                    b.Property<int>("userId");

                    b.Property<string>("userId1");

                    b.HasKey("id");

                    b.HasIndex("userId1");

                    b.ToTable("order");
                });

            modelBuilder.Entity("ShopMartWebsite.Entities.OrderDetail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("orderId");

                    b.Property<int>("productId");

                    b.Property<int>("quantity");

                    b.Property<decimal>("unitPrice");

                    b.HasKey("id");

                    b.HasIndex("orderId");

                    b.HasIndex("productId");

                    b.ToTable("orderdetail");
                });

            modelBuilder.Entity("ShopMartWebsite.Entities.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("categoryId");

                    b.Property<int?>("color");

                    b.Property<string>("description");

                    b.Property<string>("name");

                    b.Property<decimal>("price");

                    b.Property<int?>("size");

                    b.Property<bool>("status");

                    b.HasKey("id");

                    b.HasIndex("categoryId");

                    b.ToTable("product");
                });

            modelBuilder.Entity("ShopMartWebsite.Entities.Reply", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("commentId");

                    b.Property<string>("content");

                    b.Property<DateTime>("createDate");

                    b.Property<int>("userId");

                    b.Property<string>("userId1");

                    b.HasKey("id");

                    b.HasIndex("commentId");

                    b.HasIndex("userId1");

                    b.ToTable("reply");
                });

            modelBuilder.Entity("ShopMartWebsite.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("ShopMartWebsite.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("address");

                    b.Property<DateTime>("birthDay");

                    b.Property<string>("displayname");

                    b.Property<bool>("gender");

                    b.Property<string>("password");

                    b.Property<string>("phone");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("ShopMartWebsite.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ShopMartWebsite.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ShopMartWebsite.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("ShopMartWebsite.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopMartWebsite.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ShopMartWebsite.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopMartWebsite.Entities.Comment", b =>
                {
                    b.HasOne("ShopMartWebsite.Entities.Product", "product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopMartWebsite.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("userId1");
                });

            modelBuilder.Entity("ShopMartWebsite.Entities.ImageProduct", b =>
                {
                    b.HasOne("ShopMartWebsite.Entities.Product", "product")
                        .WithMany("Images")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopMartWebsite.Entities.Order", b =>
                {
                    b.HasOne("ShopMartWebsite.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("userId1");
                });

            modelBuilder.Entity("ShopMartWebsite.Entities.OrderDetail", b =>
                {
                    b.HasOne("ShopMartWebsite.Entities.Order", "order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("orderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopMartWebsite.Entities.Product", "product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopMartWebsite.Entities.Product", b =>
                {
                    b.HasOne("ShopMartWebsite.Entities.Category", "category")
                        .WithMany("Products")
                        .HasForeignKey("categoryId");
                });

            modelBuilder.Entity("ShopMartWebsite.Entities.Reply", b =>
                {
                    b.HasOne("ShopMartWebsite.Entities.Comment", "comment")
                        .WithMany("Replies")
                        .HasForeignKey("commentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopMartWebsite.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("userId1");
                });
#pragma warning restore 612, 618
        }
    }
}

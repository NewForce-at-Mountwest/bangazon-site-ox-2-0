using System;
using System.Collections.Generic;
using System.Text;
using BangazonSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BangazonSite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Setting up Delete functions for use in Controllers
            modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderProducts)
            .WithOne(l => l.Order)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Product>()
                .HasMany(o => o.OrderProducts)
                .WithOne(l => l.Product)
                .OnDelete(DeleteBehavior.Restrict);

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Cake",
                LastName = "Johnson",
                StreetAddress = "666 St.Lucifer Way",
                UserName = "Daddy",
                NormalizedUserName = "DADDY",
                Email = "admin@admin",
                NormalizedEmail = "ADMIN@ADMIN",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<PaymentType>().HasData(
                new PaymentType()
                {
                    PaymentTypeId = 1,
                    UserId = user.Id,
                    Name = "American Express",
                    acctNumber = "123456789",
                    isActive = true
                },
                new PaymentType()
                {
                    PaymentTypeId = 2,
                    UserId = user.Id,
                    Name = "Visa",
                    acctNumber = "0987654321",
                    isActive = false
                },

                new PaymentType()
                {
                    PaymentTypeId = 3,
                    UserId = user.Id,
                    Name = "MasterCard",
                    acctNumber = "6942069",
                    isActive = true
                }
                );
            modelBuilder.Entity<ProductType>().HasData(
                new ProductType()
                {
                ProductTypeId= 1,
                Name="Electronics"
            },
                     new ProductType()
                     {
                         ProductTypeId = 2,
                         Name = "Apparel"
                     },

                          new ProductType()
                          {
                              ProductTypeId = 3,
                              Name = "Sporting Goods"
                          },
                               new ProductType()
                               {
                                   ProductTypeId = 4,
                                   Name = "Games"
                               },

                                    new ProductType()
                                    {
                                        ProductTypeId = 5,
                                        Name = "Entertainment"
                                    },
                                         new ProductType()
                                         {
                                             ProductTypeId = 6,
                                             Name = "Books"
                                         }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    ProductTypeId = 1,
                    UserId = user.Id,
                    Description = "Plays Music and E-Books",
                    Title = "Pocket Media Player",
                    Quantity = 25,
                    Price = 299.99,
                    isArchived = true

                },
                 new Product()
                 {
                     Id = 2,
                     ProductTypeId = 1,
                     UserId = user.Id,
                     Description = "Laptop",
                     Title = "TopLap CPU",
                     Quantity = 7,
                     Price = 899.99,
                     isArchived = true

                 },
                  new Product()
                  {
                      Id = 3,
                      ProductTypeId = 2,
                      UserId = user.Id,
                      Description = "Helps you not be naked",
                      Title = "Shirt",
                      Quantity = 25,
                      Price = 4.99,
                      isArchived = true

                  },

                   new Product()
                   {
                       Id = 4,
                       ProductTypeId = 1,
                       UserId = user.Id,
                       Description = "Also helps you not be naked ",
                       Title = "Jeans",
                       Quantity = 25,
                       Price = 49.99,
                       isArchived = true

                   },

                    new Product()
                    {
                        Id = 5,
                        ProductTypeId = 3,
                        UserId = user.Id,
                        Description = "Kick it if you want",
                        Title = "Soccer Ball",
                        Quantity = 12,
                        Price = 25.99,
                        isArchived = false

                    },
                     new Product()
                     {
                         Id = 6,
                         ProductTypeId = 3,
                         UserId = user.Id,
                         Description = "Hit it with a bat",
                         Title = "Base-Ball",
                         Quantity = 25,
                         Price = 10.99,
                         isArchived = true

                     },
                      new Product()
                      {
                          Id = 7,
                          ProductTypeId = 4,
                          UserId = user.Id,
                          Description = "Play it, could be fun",
                          Title = "Not Doom, But close",
                          Quantity = 25,
                          Price = 60.00,
                          isArchived = true

                      },
                       new Product()
                       {
                           Id = 8,
                           ProductTypeId = 4,
                           UserId = user.Id,
                           Description = "Shoot People(Bad people)",
                           Title = "Duty That Calls",
                           Quantity = 25,
                           Price = 60.00,
                           isArchived = true

                       },
                        new Product()
                        {
                            Id = 9,
                            ProductTypeId = 5,
                            UserId = user.Id,
                            Description = "Watch it, it is a movie",
                            Title = "Indianapolis James",
                            Quantity = 6,
                            Price = 20.99,
                            isArchived = true

                        },
                         new Product()
                         {
                             Id = 10,
                             ProductTypeId = 5,
                             UserId = user.Id,
                             Description = "Listen it is music",
                             Title = "Skittles LP",
                             Quantity = 25,
                             Price = 12.99,
                             isArchived = true

                         },
                          new Product()
                          {
                              Id = 11,
                              ProductTypeId = 6,
                              UserId = user.Id,
                              Description = "Book read me, or forget about me and leave me on a shelf",
                              Title = "Carry Lotter, and the Rock of Magic",
                              Quantity = 19,
                              Price = 29.99,
                              isArchived = true


                          },
                           new Product()
                           {
                               Id = 12,
                               ProductTypeId = 6,
                               UserId = user.Id,
                               Description = "Book read me, or forget about me and leave me on a shelf",
                               Title = "Quit Kidding Yourself, You're Not Going to Read This",
                               Quantity = 25,
                               Price = 9.99,
                               isArchived = true

                           }




            );
            modelBuilder.Entity<Order>().HasData(
                new Order()
                {
                    OrderId = 1,
                    UserId = user.Id,
                    PaymentTypeId = null
                }
                );
            modelBuilder.Entity<OrderProduct>().HasData(
                new OrderProduct()
                {
                    OrderProductId = 1,
                    OrderId = 1,
                    ProductId = 1
                }
                );






        }
    }
}

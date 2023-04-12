﻿using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Models
{
    public class PizzaContext : DbContext
    {
        public const string ConnectionString = "Data Source=localhost;Initial Catalog=PizzaDati;Integrated Security=True;TrustServerCertificate=True";
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options) { }
        public PizzaContext() {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<Pizza> Pizze { get; set; }

        public void Seed()
        {
            if (!Pizze.Any())
            {
                var seed = new Pizza[]
                {
                new Pizza
                    {
                        Name = "Pizza Diavola",
                        Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit.",
                        Image = "https://picsum.photos/id/237/200/300",
                        Price = 4.50,
                    },
                new Pizza
                    {
                        Name = "Pizza Capricciosa",
                        Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit.",
                        Image = "https://picsum.photos/id/237/200/300",
                        Price = 6.80,
                    },
                new Pizza
                    {
                        Name = "Pizza Marinara",
                        Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit.",
                        Image = "https://picsum.photos/id/237/200/300",
                        Price = 5,
                    },
                new Pizza
                    {
                        Name = "Pizza Fumè",
                        Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit.",
                        Image = "https://picsum.photos/id/237/200/300",
                        Price = 5.50,
                    },
                };
                    Pizze.AddRange(seed);

                    SaveChanges();
            }
        }
    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFF_Api_App.Models;
using Microsoft.EntityFrameworkCore;

namespace SFF_Api_App.DB
{
    public class SFF_DbContext :DbContext

    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Trivias> Trivias { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SFF_Databas.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().Property(r => r.Grade).IsRequired();
            modelBuilder.Entity<Movie>().Property(r => r.Title).IsRequired();
            modelBuilder.Entity<Studio>().Property(r => r.Name).IsRequired();
            modelBuilder.Entity<Trivias>().Property(r => r.Title).IsRequired();
        }
        public DbSet<SFF_Api_App.Models.Rented> Rented { get; set; }

    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence
{
    public class GoliathDbContext : DbContext
    {
        public GoliathDbContext(DbContextOptions<GoliathDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


        public DbSet<Rates> Rates { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
    }
}

using MathOperation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MathOperation.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Operation> Operations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=mathoperations.db");
        }
    }
}

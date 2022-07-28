using Microsoft.EntityFrameworkCore;
using MM.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MM.Repository
{
    public class MMDbContext : DbContext
    {
        public MMDbContext(DbContextOptions<MMDbContext> options) : base(options)
        { }
        public DbSet<Customer> Customers  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(CommonSettings.config["MMDBContext"]);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

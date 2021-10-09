using Microsoft.EntityFrameworkCore;
using MilestoneExam.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilestoneExam.Common.Exceptions;
using System.Reflection;

namespace MilestoneExam.Data
{
    public class MainDataContext : DbContext, IMainDataContext
    {
        public MainDataContext(string connectionString) : base(GetOptions(connectionString)) { }

        public MainDataContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            int output;

            try
            {
                output = await base.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null)
                    throw new ValidationException($"Could not save changes due to a SQL error - {ex.InnerException.Message}");

                throw new ValidationException("Could not save changes as there was an error in the database - see InnerException for more details");
            }

            return output;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>().HasKey(c => new { c.CustomerId, c.ProductId });

            base.OnModelCreating(modelBuilder);
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
    }
}

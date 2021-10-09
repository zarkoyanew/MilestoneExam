using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MilestoneExam.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilestoneExam.Data
{
    public interface IMainDataContext : IDisposable 
    {
        DbSet<Product> Products { get; set; }

        DbSet<Customer> Customers { get; set; }

        DbSet<Purchase> Purchases { get; set; }


        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}

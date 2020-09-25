using Domain.Entities;
using Domain.Interfaces;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Context : DbContext, IContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           // builder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }

        public async Task<int> SaveChangesAsync()
        {
            return this.SaveChanges();
        }
    }
}
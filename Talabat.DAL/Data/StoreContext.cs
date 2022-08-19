using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Entities;

namespace Talabat.DAL.Data
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext>options):base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Product> products { get; set; }

        public DbSet<ProductType> types { get; set; }    


        public DbSet<ProductBrand> brands { get; set; }     

    }
}

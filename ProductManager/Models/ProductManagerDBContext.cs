using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProductManager.Models
{
    public class ProductManagerDBContext : DbContext
    {
        public virtual DbSet<Product> Products {get;set;}
        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=product.db");
        }
    }
}

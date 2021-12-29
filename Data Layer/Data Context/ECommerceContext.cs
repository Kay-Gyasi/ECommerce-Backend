using Data_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Data_Context
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(){}

        public ECommerceContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Brands> brands { get; set; }

        public DbSet<Categories> categories { get; set; }

        public DbSet<Products> products { get; set; }

        public DbSet<Users> users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=YOGA-X1;Database=ECommerceDb;Trusted_Connection=True;");
            }
        }
    }
}

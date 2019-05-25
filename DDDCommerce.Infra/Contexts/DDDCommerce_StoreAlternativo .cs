using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDCommerce.Domain.Store.Entities;
using DDDCommerce.Infra.Mappings;

namespace DDDCommerce.Infra.Contexts
{
    public class DDDCommerce_StoreDataContext : DbContext
    {

        public DDDCommerce_StoreDataContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BancoDDDTeste1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
            //Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new OrderItemMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ProductMap());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDCommerce.Domain.Store.Entities;

namespace DDDCommerce.Infra.Mappings
{
    public class ProductMap: EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");
            HasKey(x => x.Id);
            Property(x => x.Description).IsRequired().HasMaxLength(180);
            Property(x => x.Image);
            Property(x => x.Price).HasColumnType("money");
            Property(x => x.QuantityOnHand);
            Property(x => x.Title).IsRequired().HasMaxLength(80);
            
        }
    }
}

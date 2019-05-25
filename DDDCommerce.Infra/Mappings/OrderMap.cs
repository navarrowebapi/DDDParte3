using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDCommerce.Domain.Store.Entities;

namespace DDDCommerce.Infra.Mappings
{
    public class OrderMap: EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable("Order");
            HasKey(x => x.Id);
            Property(x => x.CreateDate);
            Property(x => x.Number).IsRequired().HasMaxLength(8).IsFixedLength();
            Property(x => x.Status);//vai virar um inteiro no banco

            HasRequired(x => x.Customer);//Relacionamento com Customer

            HasMany(x => x.Items);
            //Vai dar pau, pois Items é READONLYCOLLECTION e o EF não mapeia esse tipo.
            //Solução (preço a pagar) voltar Items como uma Collection normal.
        }
    }
}

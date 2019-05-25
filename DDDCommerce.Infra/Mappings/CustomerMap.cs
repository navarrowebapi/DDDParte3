using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDCommerce.Domain.Store.Entities;

namespace DDDCommerce.Infra.Mappings
{
    public class CustomerMap: EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable("Customer");
            HasKey(x => x.Id);//mesmo que não informamos a chave, por padrão o EF seta o Id como chave.
            Property(x => x.Document).IsRequired().HasMaxLength(11).IsFixedLength(); //CPF(11) e CHAR em vez de VARCHAR, performance.
            Property(x => x.Phone).HasMaxLength(14);
            Property(x => x.Email.MailAddress).HasMaxLength(60); //Mapeamento de VO
            Property(x => x.Name.FirstName).HasMaxLength(50); //Mapeamento de VO
            Property(x => x.Name.LastName).HasMaxLength(50); //Mapeamento de VO

            //Aqui não temos um relacionamento (JOIN) direto com outra Entidade, caso tivessemos usaríamos:
            ////HasRequired(x => x.ENTIDADE);

            //* Poderíamos ter feito um relacionamento como se Email fosse uma Entidade e então seria necessário 
            //um JOIN, no entanto, tratamos Property(x => x.Email.MailAddress), desta forma, é criado dentro
            //da Tabela de Customer o campo "MailAddress", evitando-se assim JOINs desnecessários.


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDCommerce.Domain.Store.Repositories;
using DDDCommerce.Infra.Contexts;
using DDDCommerce.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DDDComm.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //AddScoped funciona como um Singleton, ou seja, uma única instância desta classe 
            services.AddScoped<DDDCommerce_StoreAlternativo, DDDCommerce_StoreAlternativo>();

            //AddTransient fornece instâncias de cada Interface quando forem necessitadas
            //Ex.: No Customercontroller temos ICustomerRepository, esta interface quando requisitada
            //será "abastecida" com uma implementação de "CustomerRepositoryPersistence2" por exemplo.
            //Ou por qualquer outra implementação do repositório que for necessário.
            services.AddTransient<ICustomerRepository, CustomerRepositoryPersistence2>();

            //Serviço básico para MVC.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

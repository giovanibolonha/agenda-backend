using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Application.Mappers;
using Agenda.Data;
using Agenda.Repository.Mappers;
using Agenda.Web.Api.Configurations;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Agenda.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AgendaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);
            containerBuilder.RegisterModule<WebModule>();
            var container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                    .CreateScope())
            {
                serviceScope.ServiceProvider.GetService<AgendaContext>().Database.Migrate();
            }

            Mapper.Initialize(map =>
            {
                map.AddCollectionMappers();

                AutoMapperAgendaAppService.RegisterMapping(map);
                AutoMapperAgendaRepository.RegisterMapping(map);
            });
        }
    }
}

using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SysVentas.Domain.Contracts;
using SysVentas.Domain.Services;
using SysVentas.Infrastructure.Data;
using SysVentas.Infrastructure.Data.Base;
using SysVentas.Infrastructure.Data.initialize;
using SysVentas.WebApi.Infrastructure;
namespace SysVentas.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["ConnectionString"];
            services.AddDbContext<ProductDataContext>
                (opt => opt.UseSqlServer(connectionString));

            services.AddTransient<ICancelInvoiceMasterService, CancelInvoiceMasterService>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorPipelineBehavior<,>));
            InyeccionFluentValidations(services);
            services.AddScoped<IDbContext, ProductDataContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddMediatR(Assembly.Load("SysVentas.Application"));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SysVentas.WebApi", Version = "v1" });
            });


        }

        private void InyeccionFluentValidations(IServiceCollection services)
        {
            AssemblyScanner.FindValidatorsInAssembly(Assembly.Load("SysVentas.Application")).ForEach(pair =>
            {
                // RegisterValidatorsFromAssemblyContaing does this:
                services.Add(ServiceDescriptor.Scoped(pair.InterfaceType, pair.ValidatorType));
                // Also register it as its concrete type as well as the interface type
                services.Add(ServiceDescriptor.Scoped(pair.ValidatorType, pair.ValidatorType));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SysVentas.WebApi v1"));
            }
            app.UseCors(x => x
                  .AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            InicializarDatabase(app, env);
        }

        private static void InicializarDatabase(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();

            scope.ServiceProvider.GetRequiredService<ProductDataContext>().Database.Migrate();
            var context = scope.ServiceProvider.GetRequiredService<ProductDataContext>();
            if (env.IsDevelopment())
            {
                var initializeDevelopment = new InitializeDevelopmentSales(context);
                initializeDevelopment.Initialize();
            }
        }
    }
}

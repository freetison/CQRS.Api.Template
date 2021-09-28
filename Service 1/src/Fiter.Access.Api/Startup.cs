using System;
using Api.DependencyInjection;
using Api.Filters;
using Application.DependencyInjection;
using Application.Models.OrderStatusFactory;
using Domain.Common;
using Domain.Enumeration;
using Domain.Interfaces;
using FluentValidation.AspNetCore;
using Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
{
  public class Startup
    {
        public IConfiguration Configuration { get; }
        private IWebHostEnvironment _env { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
          _env = env;
          Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
                {
                    options.SuppressAsyncSuffixInActionNames = false;
                    options.RespectBrowserAcceptHeader = true;
                    options.Filters.Add(new ValidateModelStateAttribute());
                    options.Filters.Add<ApiExceptionFilter>();
                })
                .AddFluentValidation(fv => fv.DisableDataAnnotationsValidation = true)
                .AddNewtonsoftJson();

            if (!_env.IsDevelopment()) { services.AddHSTS(443, TimeSpan.FromHours(4)); }

            services.AddHttpContextAccessor();
            services.AddAppSettings(Configuration);
            services.AddVersioningApi();
            services.AddAutoMapperProfiles();
            services.AddMediatRHub();

            services.AddInfrastructureServices(Configuration);

            services.AddSwagger(Configuration);

            if (_env.IsDevelopment()) { services.AddAllowAllCors(); }
            services.AddCorsForLocalhost(4200);
            services.AddCordForAzure();

            // Register GenericEnumFactory
            services.AddScoped(sp =>
            {
                var factory = new GenericFactory<int, IOrderStatus>();
                factory.Register(OrderStatus.InProgress, () => ActivatorUtilities.CreateInstance<InProgress>(sp));
                factory.Register(OrderStatus.Completed, () => ActivatorUtilities.CreateInstance<Completed>(sp));
                factory.Register(OrderStatus.Rejected, () => ActivatorUtilities.CreateInstance<Rejected>(sp));
                return factory;
            });

        }

        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseCors("AllowLocalhost");
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SignalR.Server v1"));
            }
            else
            {
              app.UseExceptionHandler("/Error");
              app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("AllowAzure");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
    }


  }
}

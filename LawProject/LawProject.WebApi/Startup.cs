using LawProject.Application;
using LawProject.Application.Interfaces;
using LawProject.Infrastructure.Identity;
using LawProject.Infrastructure.Persistence;
using LawProject.Infrastructure.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LawProject.WebApi.Extensions;
using LawProject.WebApi.Services;
using Serilog;
using Serilog.Events;
using LawProject.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using LawProject.Infrastructure.Identity.Contexts;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace LawProject.WebApi
{
    public class Startup
    {
        public IConfiguration _config { get; }
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationLayer(_config);
            services.AddIdentityInfrastructure(_config);
            services.AddPersistenceInfrastructure(_config);
            services.AddSharedInfrastructure(_config);
            services.AddSwaggerExtension();
            services.AddControllers();
            services.AddApiVersioningExtension();
            services.AddHealthChecks();
            services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // migrate database changes on startup (includes initial db creation)
                //InitializeDatabase(app);
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwaggerExtension();

            // global cors policy
            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseErrorHandlingMiddleware();
            //app.UseRequestCultureMiddleware();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"Hello{CultureInfo.CurrentCulture.DisplayName}");
            //});

            app.UseHealthChecks("/health");

            app.UseEndpoints(endpoints =>
             {
                 endpoints.MapControllers();
             });
        }

        /// <summary>
        /// Make DB update to latest migration
        /// </summary>
        /// <param name="app"></param>
        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
                scope.ServiceProvider.GetRequiredService<IdentityContext>().Database.Migrate();
            }
        }
    }
}

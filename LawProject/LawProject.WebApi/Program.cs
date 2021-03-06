using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Extensions;
using Serilog;
using LawProject.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using LawProject.Infrastructure.Identity.Models;
using Microsoft.Extensions.DependencyInjection;
using LawProject.Infrastructure.Persistence.Seeds;
using LawProject.Application.Interfaces.Repositories;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace LawProject.WebApi
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            //Read Configuration from appSettings
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //Initialize Logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                //.WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Starting up");

            var host = CreateHostBuilder(args).Build();

            #region Init default value
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    try
                    {
                        await Infrastructure.Identity.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
                        await Infrastructure.Identity.Seeds.DefaultSuperAdmin.SeedAsync(userManager, roleManager);
                        await Infrastructure.Identity.Seeds.DefaultBasicUser.SeedAsync(userManager, roleManager);


                        var legalGroup = services.GetRequiredService<ILegalGroupRepositoryAsync>();
                        var seedLegalGroup = new DefaultLegalDocumentGroup();
                        await seedLegalGroup.CreateLegalGroup(legalGroup);

                        var legalType = services.GetRequiredService<ILegalTypeRepositoryAsync>();
                        var seedLegalType = new DefaultLegalDocumentType();
                        await seedLegalType.CreateLegalType(legalType);
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex.Message);
                    }

                    Log.Information("Finished Seeding Default Data");
                    Log.Information("Application Starting");
                }
                catch (Exception ex)
                {
                    Log.Warning(ex, "An error occurred seeding the DB");
                }
                finally
                {
                    Log.CloseAndFlush();
                }
            }
            #endregion

            host.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            //.UseSerilog() //Uses Serilog instead of default .NET Logger
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

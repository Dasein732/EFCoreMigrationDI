using Dasein.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MigrationDI;
using Project;
using System.Reflection;

internal class Program
{
    public static async Task Main(string[] args)
    {
        await Host.CreateDefaultBuilder(args)
          .UseContentRoot(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
          .ConfigureServices(AddMigratorServices)
          .RunConsoleAsync();
    }

    public static void AddMigratorServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddHostedService<MigrationService>();

        services.AddScoped<IColumnNameProvider, ColumnNameProvider>();

        var builder = new DbContextOptionsBuilder();
        builder.UseDependencyInjectionInMigrations(services.BuildServiceProvider());

        services.AddDbContext<ExampleContext>(opt =>
        {
            opt.UseDependencyInjectionInMigrations();
        });
    }
}
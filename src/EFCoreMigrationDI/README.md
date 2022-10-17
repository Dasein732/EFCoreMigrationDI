# EFCoreMigrationDI

Set of extension methods providing DI support to SQL Server migrations for EF Core

## Usage

    services.AddDbContext<DbContext>(opt =>
    {
        opt.UseDependencyInjectionInMigrations();
    });

or

    var builder = new DbContextOptionsBuilder();
    builder.UseDependencyInjectionInMigrations(services.BuildServiceProvider());
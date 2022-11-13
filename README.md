# EFCoreMigrationDI

Set of extension methods providing DI support to relational provider migrations for EF Core. 
Tested on SQL Server and SQLite.

## Purpose

The library is intended to smooth out bumpy interactions between multiple contexts in code first environment
that can't be handled other than having multiple sets of migration files and preventing those issues from surfacing into runtime code.
For e.g. doing a complex update or delete operation during the migration, such as joining 2 tables 
in different databases where the table or database names may vary between the deployments.

## Usage
    using Dasein.EntityFrameworkCore.Migrations;
    
    services.AddDbContext<DbContext>(opt =>
    {
        opt.UseDependencyInjectionInMigrations();
    });

or

    var builder = new DbContextOptionsBuilder();
    builder.UseDependencyInjectionInMigrations(services.BuildServiceProvider());

then

    public partial class ExampleMigration : Migration
    {
        private readonly IConfiguration config;

        public ExampleMigration(IConfiguration config)
        {
            this.config = config;
        }

        //protected override void Up(MigrationBuilder migrationBuilder)

        //protected override void Down(MigrationBuilder migrationBuilder)
    }

I'll be using EF's current version as a version prefix.
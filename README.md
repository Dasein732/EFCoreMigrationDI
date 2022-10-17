# EFCoreMigrationDI

Set of extension methods providing DI support to SQL Server migrations for EF Core. 
This will most likely work for other providers but I haven't got around to testing it yet.

## Usage

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
        public IConfiguration Config { get; }

        public InitialCreate(IConfiguration config)
        {
            Config = config;
        }

        //protected override void Up(MigrationBuilder migrationBuilder)

        //protected override void Down(MigrationBuilder migrationBuilder)
    }
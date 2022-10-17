using Microsoft.Extensions.Hosting;

namespace MigrationDI
{
    internal class MigrationService : IHostedService
    {

        public MigrationService(TestContext ctx)
        {
            Ctx = ctx;
        }

        public TestContext Ctx { get; }

        public async Task StartAsync(CancellationToken cancellationToken)
        {

            //if(Ctx.Database.GetPendingMigrations().Any())
            //{
            //    Ctx.Database.Migrate();
            //}

            var zz = Ctx.Model
                .GetEntityTypes()
                .Where(x => x.Name == "MigrationDI.TestTable")
                .First();

            var z = zz.GetAnnotations();

            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}

using Microsoft.EntityFrameworkCore;
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

            if(Ctx.Database.GetPendingMigrations().Any())
            {
                Ctx.Database.Migrate();
            }

            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}

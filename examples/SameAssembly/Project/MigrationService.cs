using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MigrationDI;

namespace Project
{
    internal class MigrationService : IHostedService
    {

        public MigrationService(ExampleContext ctx)
        {
            Ctx = ctx;
        }

        public ExampleContext Ctx { get; }

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

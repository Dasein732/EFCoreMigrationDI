using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

#pragma warning disable EF1001 // Internal EF Core API usage.
namespace Dasein.EntityFrameworkCore.Migrations
{
    internal class DIMigrationsAssembly : MigrationsAssembly
    {

        public DIMigrationsAssembly(ICurrentDbContext currentContext, IDbContextOptions options, IMigrationsIdGenerator idGenerator, IDiagnosticsLogger<DbLoggerCategory.Migrations> logger) : base(currentContext, options, idGenerator, logger)
        {
            Options = options;
        }

        private IDbContextOptions Options { get; }

        public override Migration CreateMigration(TypeInfo migrationClass, string activeProvider)
        {

            var nonDefaultCtors = migrationClass
                .GetConstructors()
                .Where(x => x.GetParameters().Length > 0)
                .ToList();

            if(nonDefaultCtors.Count > 1)
            {
                throw new InvalidOperationException($"Multiple constructors have been found in type '{migrationClass.FullName}'. There should only be one applicable constructor.");
            }
            else if(nonDefaultCtors.Count == 1)
            {
                var ext = Options.Extensions.OfType<CoreOptionsExtension>().FirstOrDefault();

                if(ext is null)
                {
                    throw new InvalidOperationException($"{Options.GetType().FullName} is missing {nameof(CoreOptionsExtension)}.");
                }

                using var scope = ext.ApplicationServiceProvider!.CreateScope();
                var ctor = nonDefaultCtors.First();
                var ctorParamTypes = ctor.GetParameters();
                var ctorParams = ctorParamTypes
                    .Select(x => scope.ServiceProvider.GetRequiredService(x.ParameterType))
                    .ToArray();

                var migration = (Migration)ctor.Invoke(ctorParams);
                migration.ActiveProvider = activeProvider;

                return migration;
            }

            return base.CreateMigration(migrationClass, activeProvider);
        }
    }
}
#pragma warning restore EF1001 // Internal EF Core API usage.
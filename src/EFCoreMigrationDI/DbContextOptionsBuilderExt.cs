using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dasein.EntityFrameworkCore.Migrations
{
    public static class DbContextOptionsBuilderExt
    {

        /// <summary>
        ///     <para>
        ///         Adds support for dependency injection to the migration builder.
        ///     </para>
        /// </summary>
        /// <returns>The same builder instance so that multiple calls can be chained.</returns>
        public static DbContextOptionsBuilder UseDependencyInjectionInMigrations(this DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ReplaceService<IMigrationsAssembly, DIMigrationsAssembly>();

            return optionsBuilder;
        }

        /// <summary>
        ///     <para>
        ///         Adds support for dependency injection to the migration builder with specific <see cref="IServiceProvider" />.
        ///         Redundant when the <see cref="DbContext" /> was added with the 'AddDbContext' or 'AddDbContextPool' extensions.
        ///     </para>
        /// </summary>
        /// <param name="serviceProvider">The service provider to be used.</param>
        /// <returns>The same builder instance so that multiple calls can be chained.</returns>
        public static DbContextOptionsBuilder UseDependencyInjectionInMigrations(this DbContextOptionsBuilder optionsBuilder, IServiceProvider serviceProvider)
        {
            optionsBuilder.ReplaceService<IMigrationsAssembly, DIMigrationsAssembly>();
            optionsBuilder.UseApplicationServiceProvider(serviceProvider);

            return optionsBuilder;
        }
    }
}

namespace Coterie.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using System.Linq;

    public class CoterieContextFactory : IDesignTimeDbContextFactory<CoterieContext>
    {
        public CoterieContext CreateDbContext(string[] args)
        {
            var databasePath = args.Any() ? args.FirstOrDefault() : "DataSource=DatabaseMigrations\\coterie.db";
            var optionsBuilder = new DbContextOptionsBuilder<CoterieContext>();
            optionsBuilder.UseSqlite(databasePath);

            return new CoterieContext(optionsBuilder.Options);
        }
    }
}
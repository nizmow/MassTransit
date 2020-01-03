namespace MassTransit.EntityFrameworkCoreIntegration.Tests.DeadlockSaga.DataAccess
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Shared;


    public class DeadlockSagaContextFactory : IDesignTimeDbContextFactory<DeadlockSagaDbContext>
    {
        public DeadlockSagaDbContext CreateDbContext(string[] args)
        {
            // used only for database update and migrations. Since IDesignTimeDbContextFactory is icky,
            // we only support command line tools for SQL Server, so use SQL Server if you need to do
            // migrations.

            var optionsBuilder = new SqlServerTestDbParameters().GetDbContextOptions(typeof(DeadlockSagaDbContext));

            return new DeadlockSagaDbContext(optionsBuilder.Options);
        }

        public DeadlockSagaDbContext CreateDbContext(DbContextOptionsBuilder optionsBuilder)
        {
            return new DeadlockSagaDbContext(optionsBuilder.Options);
        }
    }
}

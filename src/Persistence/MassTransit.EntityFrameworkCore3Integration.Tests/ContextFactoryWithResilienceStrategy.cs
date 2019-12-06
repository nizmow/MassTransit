namespace MassTransit.EntityFrameworkCore3Integration.Tests
{
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;


    public class ContextFactoryWithResilienceStrategy : IDesignTimeDbContextFactory<SimpleSagaDbContextWithResilienceStrategy>
    {
        public SimpleSagaDbContextWithResilienceStrategy CreateDbContext(string[] args)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<SimpleSagaDbContextWithResilienceStrategy>();

            SqlServerDbContextOptionsExtensions.UseSqlServer((DbContextOptionsBuilder)dbContextOptionsBuilder, LocalDbConnectionStringProvider.GetLocalDbConnectionString(),
                m =>
                    {
                        var executingAssembly = typeof(ContextFactory).GetTypeInfo().Assembly;
                        m.MigrationsAssembly(executingAssembly.GetName().Name);
                        m.EnableRetryOnFailure();
                    });

            return new SimpleSagaDbContextWithResilienceStrategy(dbContextOptionsBuilder.Options);
        }
    }
}

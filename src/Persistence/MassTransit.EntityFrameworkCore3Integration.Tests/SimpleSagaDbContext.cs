namespace MassTransit.EntityFrameworkCore3Integration.Tests
{
    using System.Collections.Generic;
    using Mappings;
    using Microsoft.EntityFrameworkCore;


    public class SimpleSagaDbContext : SagaDbContext
    {
        public SimpleSagaDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override IEnumerable<ISagaClassMap> Configurations
        {
            get { yield return new SimpleSagaMap(); }
        }
    }
}

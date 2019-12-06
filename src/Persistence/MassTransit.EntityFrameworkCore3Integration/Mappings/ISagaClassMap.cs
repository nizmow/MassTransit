namespace MassTransit.EntityFrameworkCore3Integration.Mappings
{
    using System;
    using Microsoft.EntityFrameworkCore;


    public interface ISagaClassMap
    {
        Type SagaType { get; }
        void Configure(ModelBuilder modelBuilder);
    }
}

﻿namespace MassTransit.EntityFrameworkCore3Integration.Tests
{
    using System;
    using System.Threading.Tasks;
    using MassTransit.Saga;
    using MassTransit.Tests.Saga.Messages;


    public class SagaWithDependency :
        InitiatedBy<InitiateSimpleSaga>,
        Orchestrates<UpdateSagaDependency>,
        ISaga
    {
        public bool Completed { get; private set; }
        public bool Initiated { get; private set; }
        public string Name { get; private set; }

        public SagaDependency Dependency { get; set; }

        public Task Consume(ConsumeContext<InitiateSimpleSaga> context)
        {
            this.CorrelationId = context.Message.CorrelationId;
            this.Initiated = true;
            this.Name = context.Message.Name;
            this.Dependency = new SagaDependency
            {
                SagaInnerDependency = new SagaInnerDependency()
            };

            return Task.CompletedTask;
        }

        public Guid CorrelationId { get; set; }

        public Task Consume(ConsumeContext<UpdateSagaDependency> context)
        {
            this.Dependency.SagaInnerDependency.Name = context.Message.Name;
            this.Completed = true;
            return Task.CompletedTask;
        }
    }
}

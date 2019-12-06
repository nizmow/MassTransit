namespace MassTransit.EntityFrameworkCore3Integration.Tests
{
    using System;
    using MassTransit.Tests.Saga.Messages;


    [Serializable]
    public class UpdateSagaDependency :
        SimpleSagaMessageBase
    {
        public UpdateSagaDependency()
        {
        }

        public UpdateSagaDependency(Guid correlationId, string propertyValue)
            : base(correlationId)
        {
            this.Name = propertyValue;
        }

        public string Name { get; set; }
    }
}

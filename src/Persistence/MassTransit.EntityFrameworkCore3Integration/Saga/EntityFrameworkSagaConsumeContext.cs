namespace MassTransit.EntityFrameworkCore3Integration.Saga
{
    using System;
    using System.Threading.Tasks;
    using Context;
    using MassTransit.Saga;
    using Microsoft.EntityFrameworkCore;


    public class EntityFrameworkSagaConsumeContext<TSaga, TMessage> :
        ConsumeContextScope<TMessage>,
        SagaConsumeContext<TSaga, TMessage>
        where TMessage : class
        where TSaga : class, ISaga
    {
        readonly DbContext _dbContext;
        readonly bool _existing;

        public EntityFrameworkSagaConsumeContext(DbContext dbContext, ConsumeContext<TMessage> context, TSaga instance, bool existing = true)
            : base(context)
        {
            this.Saga = instance;
            this._dbContext = dbContext;
            this._existing = existing;
        }

        Guid? MessageContext.CorrelationId => this.Saga.CorrelationId;

        public async Task SetCompleted()
        {
            this.IsCompleted = true;
            if (this._existing)
            {
                this._dbContext.Set<TSaga>().Remove(this.Saga);

                this.LogRemoved();

                await this._dbContext.SaveChangesAsync(this.CancellationToken).ConfigureAwait(false);
            }
        }

        public bool IsCompleted { get; private set; }
        public TSaga Saga { get; }
    }
}

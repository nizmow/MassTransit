namespace MassTransit.EntityFrameworkCore3Integration
{
    using MassTransit.Saga;
    using Microsoft.EntityFrameworkCore;


    public interface IRawSqlLockStatements
    {
        string GetRowLockStatement<TSaga>(DbContext context)
            where TSaga : class, ISaga;
    }
}

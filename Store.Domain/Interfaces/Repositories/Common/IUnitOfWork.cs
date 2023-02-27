using System;

namespace Store.Domain.Interfaces.Repositories.Common
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}

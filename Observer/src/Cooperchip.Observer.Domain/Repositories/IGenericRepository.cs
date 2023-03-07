using Cooperchip.Observer.Domain.Repositories.UoW;
using System;

namespace Cooperchip.Observer.Domain.Repositories
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        IUnitOfWork UnitOfWork { get; }
    }
}

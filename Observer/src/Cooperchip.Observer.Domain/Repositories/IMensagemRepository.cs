using Cooperchip.Observer.Domain.Entities;
using Cooperchip.Observer.Domain.Repositories.UoW;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Domain.Repositories
{
    public interface IMensagemRepository : IUnitOfWork, IDisposable
    {
        Task Add(Mensagens model);
        Task<IEnumerable<Mensagens>> GetAllMensagens();
    }
}

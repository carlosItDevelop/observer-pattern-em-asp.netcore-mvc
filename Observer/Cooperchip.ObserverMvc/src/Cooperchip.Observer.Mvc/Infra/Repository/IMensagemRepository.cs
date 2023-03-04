using Cooperchip.Observer.Mvc.Infra.UoW;
using Cooperchip.Observer.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Infra.Repository
{
    public interface IMensagemRepository : IUnitOfWork, IDisposable
    {
        Task Add(Mensagens model);
        Task<IEnumerable<Mensagens>> GetAllMensagens();
    }
}

using Cooperchip.Observer.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Infra.Repository
{
    public interface IMensagemRepository : IDisposable
    {
        Task Add(Mensagens model);
        Task Commit();

        Task<IEnumerable<Mensagens>> GetAllMensagens();
    }
}

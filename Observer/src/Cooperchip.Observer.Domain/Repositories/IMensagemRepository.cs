using Cooperchip.Observer.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Domain.Repositories
{
    public interface IMensagemRepository : IGenericRepository<Mensagens>
    {
        Task Add(Mensagens model);
        Task AddNotas();
        Task<IEnumerable<Mensagens>> GetAllMensagens();
    }
}

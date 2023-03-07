using Cooperchip.Observer.Domain.Repositories.UoW;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Domain.Services
{
    public class TransactionHandler : ITransactiondHandler
    {
        public async Task<bool> PersistirDados(IUnitOfWork uow)
        {
            if (!await uow.Commit()) return false;

            return true;
        }
    }

}

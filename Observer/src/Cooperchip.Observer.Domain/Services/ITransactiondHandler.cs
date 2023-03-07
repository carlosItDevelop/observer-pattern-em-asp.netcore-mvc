using Cooperchip.Observer.Domain.Repositories.UoW;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Domain.Services
{
    public interface ITransactiondHandler
    {
        Task<bool> PersistirDados(IUnitOfWork uow);
    }
}
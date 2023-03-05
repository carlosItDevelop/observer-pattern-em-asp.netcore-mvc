using System.Threading.Tasks;

namespace Cooperchip.Observer.Domain.Repositories.UoW
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}

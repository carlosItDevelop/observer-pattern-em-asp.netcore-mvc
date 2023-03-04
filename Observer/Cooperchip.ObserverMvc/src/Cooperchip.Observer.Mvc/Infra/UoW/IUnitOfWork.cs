using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Infra.UoW
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}

using Cooperchip.Observer.Domain.Entities;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Configurations.Observer.Interfaces
{
    public interface IPedidoObserver
    {
        Task Update(Pedido pedido);
    }
}

using Cooperchip.Observer.Domain.Entities;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Configurations.Observer.Interfaces
{
    public interface IPedidoNotificador
    {
        Task Attach(IPedidoObserver observer);
        Task Detach(IPedidoObserver observer);
        Task Notificar(Pedido pedido);
    }
}

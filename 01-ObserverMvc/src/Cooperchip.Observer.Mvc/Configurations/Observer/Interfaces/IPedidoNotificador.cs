using Cooperchip.Observer.Mvc.Models;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Configurations.Observer.Interfaces
{
    public interface IPedidoNotificador
    {
        Task Attach(IPedidoObserver observer);
        Task Dettach(IPedidoObserver observer);
        Task Notificar(PedidoViewModel pedido);
    }
}

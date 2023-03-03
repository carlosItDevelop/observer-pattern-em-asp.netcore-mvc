using Cooperchip.Observer.Mvc.Models;

namespace Cooperchip.Observer.Mvc.Services.Abstractions
{
    public interface IPedidoNotificacao
    {
        void Attach(IPedidoObserver observer);
        void Detach(IPedidoObserver observer);
        void Notify(Pedido pedido);
    }
}

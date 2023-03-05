using Cooperchip.Observer.Domain.Entities;

namespace Cooperchip.Observer.Domain.Services.Abstractions
{
    public interface IPedidoNotificacao
    {
        void Attach(IPedidoObserver observer);
        void Detach(IPedidoObserver observer);
        void Notify(Pedido pedido);
    }
}

using Cooperchip.Observer.Domain.Entities;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Domain.Services.Abstractions
{
    public interface IPedidoService : IPedidoNotificacao
    {
        void AtualizaPedido(Pedido pedido);
    }
}

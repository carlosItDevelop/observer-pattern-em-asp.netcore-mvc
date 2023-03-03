using Cooperchip.Observer.Mvc.Models;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Services.Abstractions
{
    public interface IPedidoService : IPedidoNotificacao
    {
        void AtualizaPedido(Pedido pedido);
        Task<Pedido> GetPedido();
    }
}

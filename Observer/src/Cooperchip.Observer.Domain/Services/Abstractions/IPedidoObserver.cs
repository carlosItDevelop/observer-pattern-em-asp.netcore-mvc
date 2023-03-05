using Cooperchip.Observer.Domain.Entities;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Domain.Services.Abstractions
{
    public interface IPedidoObserver
    {
        Task Update(Pedido pedido);
    }
}

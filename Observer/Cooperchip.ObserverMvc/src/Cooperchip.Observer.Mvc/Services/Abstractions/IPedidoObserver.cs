using Cooperchip.Observer.Mvc.Models;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Services.Abstractions
{
    public interface IPedidoObserver
    {
        Task Update(Pedido pedido);
    }
}

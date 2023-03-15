using Cooperchip.Observer.Mvc.Models;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Configurations.Observer.Interfaces
{
    public interface IPedidoObserver
    {
        Task Update(PedidoViewModel pedido);
    }
}

using Cooperchip.Observer.Domain.Entities;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Domain.Repositories
{
    public interface IPedidoRepository : IGenericRepository<Pedido>
    {
        Task<Pedido> GetPedido();
    }
}

using System.Threading.Tasks;
using System;
using Cooperchip.Observer.Domain.Enums;
using Cooperchip.Observer.Domain.Entities;
using Cooperchip.Observer.Domain.Repositories;
using Cooperchip.Observer.Domain.Repositories.UoW;
using Cooperchip.Observer.Infra.Data;

namespace Cooperchip.Observer.Infra.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _context;

        public PedidoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Pedido> GetPedido()
        {
            Pedido pedido = new()
            {
                Id = Guid.NewGuid(),
                NumeroDoPedido = "JAN/2023-003769-ref45",
                DataDoPedido = DateTime.UtcNow,
                Total = 2702.90M,
                StatusDoPedido = StatusDoPedido.Pendente
            };
            return await Task.FromResult(pedido);
        }

        public IUnitOfWork UnitOfWork => (IUnitOfWork)_context;

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}

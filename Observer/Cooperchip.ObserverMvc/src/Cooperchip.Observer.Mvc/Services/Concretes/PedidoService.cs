using Cooperchip.Observer.Mvc.Models;
using Cooperchip.Observer.Mvc.Models.Enums;
using Cooperchip.Observer.Mvc.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Services.Concretes
{
    public class PedidoService : IPedidoService
    {
        public List<IPedidoObserver> Observadores = new List<IPedidoObserver>();

        public void AtualizaPedido(Pedido pedido) => Notify(pedido);
        public void Attach(IPedidoObserver observer) => Observadores.Add(observer);
        public void Detach(IPedidoObserver observer) => Observadores.Remove(observer);

        public void Notify(Pedido pedido)
        {
            foreach (var observador in Observadores)
            {
                observador.Update(pedido);
            }
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
    }
}

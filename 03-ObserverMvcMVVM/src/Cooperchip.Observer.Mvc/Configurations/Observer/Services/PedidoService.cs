using Cooperchip.Observer.Domain.Entities;
using Cooperchip.Observer.Mvc.Configurations.Observer.Interfaces;
using Cooperchip.Observer.Mvc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Configurations.Observer.Services
{
    public class PedidoService : IPedidoService
    {
        public List<IPedidoObserver> Observadores = new();

        public async Task Attach(IPedidoObserver observer)
        {
            Observadores.Add(observer);
            await Task.CompletedTask;
        }
        public async Task Detach(IPedidoObserver observer) 
        { 
            Observadores.Remove(observer); 
            await Task.CompletedTask;
        }

        public async Task AtualizaPedido(Pedido pedido)
        {
            await Notificar(pedido);
        }

        public async Task Notificar(Pedido pedido)
        {
            foreach (var observador in Observadores)
            {
                await observador.Update(pedido);
            }
        }

    }
}

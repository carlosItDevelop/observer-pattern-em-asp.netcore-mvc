using Cooperchip.Observer.Domain.Entities;
using Cooperchip.Observer.Domain.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Domain.Services.Concretes
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

    }
}

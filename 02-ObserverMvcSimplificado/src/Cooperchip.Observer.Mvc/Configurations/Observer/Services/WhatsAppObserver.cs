using Cooperchip.Observer.Mvc.Configurations.Observer.Interfaces;
using Cooperchip.Observer.Mvc.Models;
using System;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Configurations.Observer.Services
{
    public class WhatsAppObserver : IPedidoObserver
    {
        public async Task Update(PedidoViewModel pedido)
        {
            Console.WriteLine("\tPedido: [ {0} ] status: [ {1} ]. WhatsApp enviada.",
            pedido.Numero, pedido.Status.ToString());
            await Task.CompletedTask;
        }
    }
}

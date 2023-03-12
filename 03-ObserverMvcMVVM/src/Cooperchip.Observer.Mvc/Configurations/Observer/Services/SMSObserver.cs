using Cooperchip.Observer.Domain.Entities;
using Cooperchip.Observer.Mvc.Configurations.Observer.Interfaces;
using System;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Configurations.Observer.Services
{
    public class SMSObserver : IPedidoObserver
    {
        public async Task Update(Pedido pedido)
        {
            Console.WriteLine("\tPedido: [ {0} ] status: [ {1} ]. SMS enviado.",
            pedido.Numero, pedido.Status.ToString());
            await Task.CompletedTask;
        }
    }
}

using Cooperchip.Observer.Mvc.Configurations.Observer.Interfaces;
using Cooperchip.Observer.Mvc.Models;
using System;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Configurations.Observer.Services
{
    public class EmailObserver : IPedidoObserver
    {
        public async Task Update(PedidoViewModel pedido)
        {
            Console.WriteLine("\tPedido: [ {0} ] Status: [ {1} ]. Email Enviado!",
                pedido.Numero, pedido.Status.ToString());

            await Task.CompletedTask;
        }
    }
}

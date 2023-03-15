﻿using Cooperchip.Observer.Mvc.Configurations.Observer.Interfaces;
using Cooperchip.Observer.Mvc.Models;
using System.Threading.Tasks;
using System;

namespace Cooperchip.Observer.Mvc.Configurations.Observer.Services
{
    public class WhatsAppObserver : IPedidoObserver
    {
        public async Task Update(PedidoViewModel pedido)
        {
            Console.WriteLine("\tPedido: [ {0} ] Status: [ {1} ]. WhatsApp Enviado!",
                pedido.Numero, pedido.Status.ToString());

            await Task.CompletedTask;
        }
    }
}

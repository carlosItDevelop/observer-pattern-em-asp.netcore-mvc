﻿using Cooperchip.Observer.Domain.Entities;
using Cooperchip.Observer.Mvc.Models;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Configurations.Observer.Interfaces
{
    public interface IPedidoService : IPedidoNotificador
    {
        Task AtualizaPedido(Pedido pedido);
    }
}

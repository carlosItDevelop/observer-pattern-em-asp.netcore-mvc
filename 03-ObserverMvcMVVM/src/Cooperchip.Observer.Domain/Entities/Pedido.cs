using Cooperchip.Observer.Domain.Enums;
using System;

namespace Cooperchip.Observer.Domain.Entities
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public StatusDoPedido Status { get; set; }
    }
}

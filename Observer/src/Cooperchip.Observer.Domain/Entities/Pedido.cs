using Cooperchip.Observer.Domain.Enums;
using System;

namespace Cooperchip.Observer.Domain.Entities
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public string NumeroDoPedido { get; set; }
        public DateTime DataDoPedido { get; set; }
        public decimal Total { get; set; }
        public StatusDoPedido StatusDoPedido { get; set; }
    }
}

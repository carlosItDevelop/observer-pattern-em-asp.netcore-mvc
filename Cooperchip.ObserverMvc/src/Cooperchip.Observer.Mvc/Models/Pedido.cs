using Cooperchip.Observer.Mvc.Models.Enums;
using System;

namespace Cooperchip.Observer.Mvc.Models
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public string NumeroDoPedido { get; set; }
        public DateTime DataDoPedido { get; set; }
        public Decimal Total { get; set; }
        public StatusDoPedido StatusDoPedido { get; set; }
    }
}

using System;

namespace Cooperchip.Observer.Mvc.Models
{
    public class PedidoViewModel
    {
        public Guid Id { get; set; }
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public StatusDoPedido Status { get; set; }
    }

    public enum StatusDoPedido
    {
        PedidoPendente = 1,
        AguardandoProcessamento,
        Processando,
        Enviado,
        Entregue,
        Cancelado,
        Recusado,
        Falha,
        Completo
    }

}

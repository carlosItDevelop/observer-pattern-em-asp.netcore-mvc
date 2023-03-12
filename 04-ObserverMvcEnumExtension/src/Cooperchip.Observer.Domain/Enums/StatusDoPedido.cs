using System.ComponentModel;

namespace Cooperchip.Observer.Domain.Enums;

public enum StatusDoPedido
{
    PedidoPendente = 1,
    [Description("Em Processamento")] AguardandoProcessamento,
    [Description("Falha Imprevista")] Falha,
    [Description("Pedido Processado")] Processado,
    Enviado,
    Entregue,
    Cancelado,
    Recusado,
    Completo
}


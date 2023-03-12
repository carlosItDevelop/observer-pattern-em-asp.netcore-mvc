namespace Cooperchip.Observer.Domain.Enums;

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


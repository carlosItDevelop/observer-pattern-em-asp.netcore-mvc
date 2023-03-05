using System.ComponentModel;

namespace Cooperchip.Observer.Domain.Enums
{
    public enum StatusDoPedido
    {
        [Description("Pedido Pendente")] Pendente = 1,
        [Description("Aguardando Processamento")] AguardandoProcessamento = 2,
        [Description("Pedido Processando")] Processando = 3,
        [Description("Pedido Enviado")] Enviado = 4,
        [Description("Pedido Cancelado")] Cancelado = 5,
        [Description("Pedido Devolvido")] Devolvido = 6,
        [Description("Falha no Pedido")] Falha = 7,
        [Description("Pedido Completo")] Completo = 8
    }
}

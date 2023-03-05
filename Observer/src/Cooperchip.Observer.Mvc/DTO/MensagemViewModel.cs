using Cooperchip.Observer.Domain.Entities;
using System.Collections.Generic;

namespace Cooperchip.Observer.Mvc.DTO
{
    public class MensagemViewModel
    {
        public MensagemViewModel()
        {
            ListMensagens = new List<Mensagens>();
        }

        public Pedido Pedido { get; set; }
        public IEnumerable<Mensagens> ListMensagens { get; set; }

        public void AddPedido(Pedido pedido) => Pedido = pedido;
    }
}
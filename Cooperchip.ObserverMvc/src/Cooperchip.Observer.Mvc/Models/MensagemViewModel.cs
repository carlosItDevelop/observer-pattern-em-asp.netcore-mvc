using System.Collections.Generic;

namespace Cooperchip.Observer.Mvc.Models
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

using Cooperchip.Observer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
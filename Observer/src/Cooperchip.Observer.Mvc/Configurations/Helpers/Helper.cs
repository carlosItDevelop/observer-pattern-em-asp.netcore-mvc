using Cooperchip.Observer.Domain.Entities;
using Cooperchip.Observer.Infra.Data;
using Cooperchip.Observer.Mvc.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Cooperchip.Observer.Mvc.Configurations.Helpers
{
    public static class Helper
    {
        public static int TotalNotify(ApplicationDbContext ctx) => (from total in ctx.Mensagens.AsNoTracking().Select(x => x.Mensagem) select total).Count();


        public static MensagemViewModel FactoryMessageViewModel(Pedido pedido, IEnumerable<Mensagens> listMensagens)
        {
            MensagemViewModel _mensagens = new();
            _mensagens.AddPedido(pedido);
            _mensagens.ListMensagens = listMensagens;

            return _mensagens;
        }

    }
   

}

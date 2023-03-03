using Cooperchip.Observer.Mvc.Infra.Repository;
using Cooperchip.Observer.Mvc.Models;
using Cooperchip.Observer.Mvc.Services.Abstractions;
using System;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Services.Concretes
{
    public class SmsObserver : IPedidoObserver
    {
        private readonly IMensagemRepository _repository;

        public SmsObserver(IMensagemRepository repository)
        {
            _repository = repository;
        }

        public async Task Update(Pedido pedido)
        {
            Mensagens msg = new()
            {
                Id = Guid.NewGuid(),
                Data = DateTime.Now,
                Mensagem = $"Pedido: '{pedido.NumeroDoPedido}' Status: '{pedido.StatusDoPedido.ToString()}'. SMS enviado.",
            };
            await _repository.Add(msg);
        }
    }
}

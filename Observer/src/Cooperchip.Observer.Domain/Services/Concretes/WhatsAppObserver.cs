using Cooperchip.Observer.Domain.Entities;
using Cooperchip.Observer.Domain.Repositories;
using Cooperchip.Observer.Domain.Services.Abstractions;
using System;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Domain.Services.Concretes
{
    public class WhatsAppObserver : IPedidoObserver
    {
        private readonly IMensagemRepository _repository;

        public WhatsAppObserver(IMensagemRepository repository)
        {
            _repository = repository;
        }

        public async Task Update(Pedido pedido)
        {
            Mensagens msg = new()
            {
                Id = Guid.NewGuid(),
                Data = DateTime.Now,
                Mensagem = $"Pedido: '{pedido.NumeroDoPedido}' Status: '{pedido.StatusDoPedido.ToString()}'. WhatsApp enviado.",
            };
            await _repository.Add(msg);
        }
    }
}

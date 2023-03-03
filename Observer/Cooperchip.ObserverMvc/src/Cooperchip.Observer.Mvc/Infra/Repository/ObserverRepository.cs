using Cooperchip.Observer.Mvc.Services.Abstractions;
using Cooperchip.Observer.Mvc.Services.Concretes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Infra.Repository
{
    public class ObserverRepository : IObserverRepository
    {
        private readonly IPedidoService _pedidoService;
        public ObserverRepository(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }
        public async Task ObserverHandre([FromServices] IMensagemRepository _repository)
        {
            Console.WriteLine("Attaching Observadores...");

            _pedidoService.Attach(new SmsObserver(_repository));
            _pedidoService.Attach(new EmailObserver(_repository));
            _pedidoService.Attach(new WhatsAppObserver(_repository));

            //Console.WriteLine("Dettaching Observevador SMS...");
            //_pedidoService.Detach(new SmsObserver(_repository));
            Console.WriteLine("Atualizando Status do Pedido..");

            await Task.CompletedTask;
        }
    }
}
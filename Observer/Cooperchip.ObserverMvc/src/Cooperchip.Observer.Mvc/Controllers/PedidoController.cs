using Cooperchip.Observer.Mvc.Infra.Repository;
using Cooperchip.Observer.Mvc.Models;
using Cooperchip.Observer.Mvc.Models.Enums;
using Cooperchip.Observer.Mvc.Services.Abstractions;
using Cooperchip.Observer.Mvc.Services.Concretes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IPedidoService _pedidoService;
        private readonly IMensagemRepository _repository;
        private readonly IObserverRepository _observerRepository;

        public PedidoController(ILogger<HomeController> logger,
                                IPedidoService pedidoService,
                                IMensagemRepository repository,
                                IObserverRepository observerRepository)
        {
            _logger = logger;
            _pedidoService = pedidoService;
            _repository = repository;
            _observerRepository = observerRepository;
        }

        public async Task<IActionResult> Index()
        {
            var pedido = await _pedidoService.GetPedido();
            var msgs = await _repository.GetAllMensagens();

            MensagemViewModel msgModel = new();
            msgModel.AddPedido(pedido);
            msgModel.ListMensagens = msgs;

            return View(msgModel);
        }

        [HttpPost]
        public async Task<IActionResult> PostPedido(MensagemViewModel model) 
        {
            var msgs = await _repository.GetAllMensagens();
            model.ListMensagens = msgs;

            await _observerRepository.ObserverHandre(_repository);          

            _pedidoService.AtualizaPedido(model.Pedido);
            await _repository.Commit();

            return RedirectToAction(nameof(Index), model);

        }


    }
}
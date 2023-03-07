using AutoMapper;
using Cooperchip.Observer.Domain.Repositories;
using Cooperchip.Observer.Domain.Services;
using Cooperchip.Observer.Domain.Services.Abstractions;
using Cooperchip.Observer.Mvc.Configurations.Helpers;
using Cooperchip.Observer.Mvc.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IPedidoService _pedidoService;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMensagemRepository _mensagensRepository;
        private readonly IObserverRepository _observerRepository;
        private readonly ITransactiondHandler _transaction;

        public PedidoController(ILogger<HomeController> logger, IPedidoService pedidoService, IMensagemRepository repository,
                                IObserverRepository observerRepository, IPedidoRepository pedidoRepository, ITransactiondHandler transaction)
        {
            _logger = logger;
            _pedidoService = pedidoService;
            _mensagensRepository = repository;
            _observerRepository = observerRepository;
            _pedidoRepository = pedidoRepository;
            _transaction = transaction;
        }

        public async Task<IActionResult> Index()
        {
            var pedido = await _pedidoRepository.GetPedido();
            var msgs = await _mensagensRepository.GetAllMensagens();
            var msgViewModel = Helper.FactoryMessageViewModel(pedido, msgs);
            return View(msgViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> PostPedido(MensagemViewModel model) 
        {
            var msgs = await _mensagensRepository.GetAllMensagens();
            model.ListMensagens = msgs;

            await _observerRepository.ObserverHandre(_mensagensRepository);          

            _pedidoService.AtualizaPedido(model.Pedido);

            await _mensagensRepository.AddNotas();
            if(!await _transaction.PersistirDados(_mensagensRepository.UnitOfWork))
            {
                TempData["Erro"] = "Erro ao persistir dados!";
                return View(nameof(PostPedido), model);
            }
            TempData["Sucesso"] = "Dados persistidos com sucesso!";
            return RedirectToAction(nameof(Index));

        }


    }
}
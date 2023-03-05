using Cooperchip.Observer.Domain.Repositories;
using Cooperchip.Observer.Domain.Services.Abstractions;
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
        private readonly IMensagemRepository _repository;
        private readonly IObserverRepository _observerRepository;

        public PedidoController(ILogger<HomeController> logger,
                                IPedidoService pedidoService,
                                IMensagemRepository repository,
                                IObserverRepository observerRepository,
                                IPedidoRepository pedidoRepository)
        {
            _logger = logger;
            _pedidoService = pedidoService;
            _repository = repository;
            _observerRepository = observerRepository;
            _pedidoRepository = pedidoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var pedido = await _pedidoRepository.GetPedido();
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
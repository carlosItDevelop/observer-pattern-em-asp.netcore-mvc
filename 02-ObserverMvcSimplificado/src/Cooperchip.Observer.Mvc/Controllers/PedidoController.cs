﻿using Cooperchip.Observer.Mvc.Configurations.Observer.Interfaces;
using Cooperchip.Observer.Mvc.Configurations.Observer.Services;
using Cooperchip.Observer.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Cooperchip.Observer.Mvc.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoService _pedidoService;
        private readonly ILogger _logger;

        public PedidoController(IPedidoService pedidoService, ILogger<PedidoController> logger)
        {
            _pedidoService = pedidoService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            PedidoViewModel viewModel = new()
            {
                Id = Guid.NewGuid(),
                Numero = "P-2023/764",
                Data = DateTime.Now,
                Valor = 213.90M,
                Status = StatusDoPedido.PedidoPendente
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(PedidoViewModel model) {
            if (!ModelState.IsValid) return View(model);

            Console.WriteLine("");
            //Console.WriteLine("\tADICIONANDO OBSERVADORES:");
            _logger.LogInformation("\tADICIONANDO OBSERVADORES:");
            Console.WriteLine("");

            await _pedidoService.Attach(new EmailObserver());
            await _pedidoService.Attach(new SMSObserver());
            await _pedidoService.Attach(new WhatsAppObserver());

            Console.WriteLine("\tATUALIZANDO STATUS DO PEDIDO:");
            Console.WriteLine("");

            await _pedidoService.AtualizaPedido(model);

            return View(model);
        }
    }
}

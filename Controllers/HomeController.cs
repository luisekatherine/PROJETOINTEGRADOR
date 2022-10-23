using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PROJETOINTEGRADOR.Models;

namespace PROJETOINTEGRADOR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult PaginaInicial()
        {
            return View();
        }
        public IActionResult Index()
        {
            PreAgendamentoRepository teste = new PreAgendamentoRepository();
            teste.TestarConexao();
            return View();
        }

        

        public IActionResult Duvidas()
        {
            return View();
        }
        public IActionResult Agendamento()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Agendamento(PreAgendamento agenda)
        {
            PreAgendamentoRepository pr = new PreAgendamentoRepository();
            pr.Inserir(agenda);
            return View("AgendadoComSucesso");
        }
        
        public IActionResult ListaAgendamento()
        {
            List<PreAgendamento> agendamentos = Dados.AgendaAtual.Listar();
            return View(agendamentos);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

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
    public class PreAgendamentoController : Controller
    {
        
        public IActionResult ListaAgendamento()
        {
            List<PreAgendamento> agendamentos = Dados.AgendaAtual.Listar();
            return View(agendamentos);
        }
    }
}

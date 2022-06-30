using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_FourTask___Avaliação_Final.Models;
using Projeto_FourTask___Avaliação_Final.Repositorio.Interfaces;

namespace Projeto_FourTask___Avaliação_Final.Controllers
{
    public class TarefasController : Controller
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IEquipeRepositorio _equipeRepositorio;

        public TarefasController(ITarefaRepository tarefaRepository,
                                 IEquipeRepositorio equipeRepositorio)
        {
            _tarefaRepository = tarefaRepository;
            _equipeRepositorio = equipeRepositorio;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Editar(int id)
        {
            Tarefa tarefa = _tarefaRepository.ObterTarefa(id);
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Salvar(Tarefa tarefa)
        {
            _tarefaRepository.Salvar(tarefa);
            return RedirectToAction("Index", "Equipe");
        }

        [HttpGet, Authorize]
        public IActionResult Cadastrar()
        {
            CadastrarTarefaViewModel viewModel = new CadastrarTarefaViewModel();

            viewModel.Equipes = _equipeRepositorio.ListarEquipes();

            return View(viewModel);
        }

        [HttpPost, Authorize]
        public IActionResult CriarTarefa(CadastrarTarefaViewModel viewModel)
        {
            Tarefa tarefa = viewModel.MapearTarefa();

            Equipe equipe = _equipeRepositorio.ObterEquipe(Convert.ToInt32(viewModel.EquipeId));
            equipe.AdicionarTarefa(tarefa);

            _equipeRepositorio.Salvar(equipe);

            return RedirectToAction("Index", "Equipe");
        }

        [HttpGet, Authorize]
        public IActionResult Remover(int id)
        {
            Tarefa tarefa = _tarefaRepository.ObterTarefa(id);
            _tarefaRepository.Remover(tarefa);

            return RedirectToAction("Index", "Equipe");
        }
    }
}

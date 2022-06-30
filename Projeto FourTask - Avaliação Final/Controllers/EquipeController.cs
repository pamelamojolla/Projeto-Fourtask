using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_FourTask___Avaliação_Final.Models;
using Projeto_FourTask___Avaliação_Final.Repositorio.Interfaces;
using System.Security.Claims;

namespace Projeto_FourTask___Avaliação_Final.Controllers
{
    public class EquipeController : Controller
    {
        private readonly IEquipeRepositorio _equipeRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ITarefaRepository _tarefaRepository;


        //injeção de independencia
        public EquipeController(IEquipeRepositorio equipeRepositorio,
                                IUsuarioRepositorio usuarioRepositorio,
                                ITarefaRepository tarefaRepository)
        {
            _equipeRepositorio = equipeRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _tarefaRepository = tarefaRepository;
        }

        [Authorize] //autorização para acessar as paginas com login
        public IActionResult Index()
        {
            EquipeIndexViewModel equipeIndexViewModel = new EquipeIndexViewModel();

            string id = ObterUsuarioIdentityId();

            Usuario usuario = _usuarioRepositorio.ObterUsuario(id);

            equipeIndexViewModel.Equipe = usuario.Equipe;

            return View(equipeIndexViewModel);
        }

        [HttpGet, Authorize]
        public IActionResult Cadastrar()
        {
            return View(new Equipe());
        }

        [HttpPost]
        [Authorize]
        public IActionResult Cadastrar(Equipe equipe)
        {
            equipe.DataCriacao = DateTime.Now;

            _equipeRepositorio.Adicionar(equipe);

            TempData["msg"] = "Equipe Cadastrada com Sucesso!";
            return RedirectToAction("Listagem");
        }

        [Authorize]
        public IActionResult Listagem()
        {
            List<Equipe> equipes = _equipeRepositorio.ListarEquipes();

            ListagemViewModel viewModel = new ListagemViewModel();
            viewModel.Equipes = equipes;

            return View(viewModel);
        }

        [Authorize]
        public IActionResult Entrar(int EquipeSelecionada, string Senha)
        {
            List<Equipe> equipes = _equipeRepositorio.ListarEquipes();

            Equipe equipe = equipes.Find(e => e.EquipeId == EquipeSelecionada) ?? new Equipe();

            if (equipe.Senha == Senha)
            {
                string id = ObterUsuarioIdentityId();

                _usuarioRepositorio.DefinirEquipeUsuario(id, equipe.EquipeId);

                return RedirectToAction("Index");
            }

            ListagemViewModel viewModel = new ListagemViewModel()
            {
                Equipes = equipes
            };

            viewModel.MensagemDeErro = $"A senha está incorreta.";
            return View("Listagem", viewModel);
        }

        private string ObterUsuarioIdentityId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
        }

        [HttpGet, Authorize]
        public IActionResult AceitarTarefa(int id)
        {
            Tarefa tarefa = _tarefaRepository.ObterTarefa(id);
            Usuario usuario = _usuarioRepositorio.ObterUsuario(ObterUsuarioIdentityId());

            tarefa.DefinirUsuario(usuario);
            _tarefaRepository.Salvar(tarefa);

            return RedirectToAction("Index");
        }
    }
}

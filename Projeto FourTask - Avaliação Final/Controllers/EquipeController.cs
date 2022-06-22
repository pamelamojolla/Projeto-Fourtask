using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_FourTask___Avaliação_Final.Models;

namespace Projeto_FourTask___Avaliação_Final.Controllers
{
    public class EquipeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Cadastrar()
        {
            return View();

        }

        [HttpPost]
        [Authorize]
        public IActionResult Cadastrar(Equipe equipe)
        {
            TempData["msg"] = "Equipe Cadastrada com Sucesso!";
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Listagem()
        {
            return View();
        }


    }
}

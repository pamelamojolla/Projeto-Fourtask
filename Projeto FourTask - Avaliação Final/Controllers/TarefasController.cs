using Microsoft.AspNetCore.Mvc;

namespace Projeto_FourTask___Avaliação_Final.Controllers
{
    public class TarefasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Editar()
        {
            return View();
        }
    }
}

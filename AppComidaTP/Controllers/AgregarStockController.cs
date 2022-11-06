using AppComidaTP.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppComidaTP.Controllers
{
    public class AgregarStockController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ReponerPrincipal()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ReponerPrincipal(Comida comida)
        {
            using (PedidosContext context = new())
            {
                context.Comida.Add(comida);
                context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ReponerBebida()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ReponerBebida(Bebida bebida)
        {
            using (PedidosContext context = new())
            {
                context.Bebida.Add(bebida);
                context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ReponerPostre()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ReponerPostre(Postre postre)
        {
            using (PedidosContext context = new())
            {
                context.Postre.Add(postre);
                context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

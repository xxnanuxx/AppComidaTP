using Microsoft.AspNetCore.Mvc;

namespace AppComidaTP.Controllers
{
    public class AgregarPedidoController : Controller
    {
        public IActionResult AgregarPrincipal()
        {
            return View();
        }

        public IActionResult AgregarBebida()
        {
            return View();
        }

        public IActionResult AgregarPostre()
        {
            return View();
        }
        
    }
}

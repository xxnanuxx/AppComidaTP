using AppComidaTP.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppComidaTP.Controllers
{
    public class AgregarPedidoController : Controller
    {
        public static Pedido prePedido = new();

        [HttpGet]
        public IActionResult AgregarPrincipal()
        {
            List<Comida>? listaComida;

            using (PedidosContext context = new())
            {
                listaComida = context.Comida.ToList();

            }

            return View(listaComida);
        }

        [HttpGet]
        public IActionResult AgregarBebida(int Codigo)
        {
            List<Bebida>? listaBebida;

            using (PedidosContext context = new())
            {
                Comida? comida = context.Comida.Find(Codigo);
                if (comida != null)
                {
                    prePedido.Comida = comida.Nombre;
                    prePedido.Total += comida.Precio;
                }

                listaBebida = context.Bebida.ToList();

            }
            return View(listaBebida);
        }

        [HttpGet]
        public IActionResult AgregarPostre(int Codigo)
        {

            List<Postre>? listaPostre;

            using (PedidosContext context = new())
            {
                Bebida? bebida = context.Bebida.Find(Codigo);
                if (bebida != null)
                {
                    prePedido.Bebida = bebida.Nombre;
                    prePedido.Total += bebida.Precio;
                }
                listaPostre = context.Postre.ToList();

            }
            return View(listaPostre);
        }

        public IActionResult AgregarCliente(int Codigo)
        {

            using (PedidosContext context = new())
            {
                Postre? postre = context.Postre.Find(Codigo);
                if (postre != null)
                {
                    prePedido.Bebida = postre.Nombre;
                    prePedido.Total += postre.Precio;
                }
            }
            return View();
        }

    }
}

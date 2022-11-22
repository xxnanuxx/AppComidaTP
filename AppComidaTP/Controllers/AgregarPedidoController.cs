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
                if (prePedido.Comida == null)
                {
                    Comida? comida = context.Comida.Find(Codigo);
                    if (comida != null)
                    {
                        prePedido.Comida = comida.Nombre;
                        prePedido.Total += comida.Precio;
                    }
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
                if (prePedido.Bebida == null)
                {
                    Bebida? bebida = context.Bebida.Find(Codigo);
                    if (bebida != null)
                    {
                        prePedido.Bebida = bebida.Nombre;
                        prePedido.Total += bebida.Precio;
                    }
                    
                }

                listaPostre = context.Postre.ToList();

            }
            return View(listaPostre);
        }
        [HttpGet]
        public IActionResult AgregarCliente(int Codigo)
        {

            using (PedidosContext context = new())
            {   
                if (prePedido.Postre == null)
                {
                    Postre? postre = context.Postre.Find(Codigo);
                    if (postre != null)
                    {
                        prePedido.Postre = postre.Nombre;
                        prePedido.Total += postre.Precio;
                    }
                }
            }
            return View(prePedido);
        }

        [HttpPost]
        public IActionResult AgregarCliente(Pedido pedido)
        {

            using (PedidosContext context = new())
            {
                if (pedido.Comida == null && pedido.Bebida == null && pedido.Postre == null)
                {
                    return RedirectToAction(nameof(FalloDePedido));
                } else
                {
                    if (pedido.Comida == null)
                        pedido.Comida = "";

                    if (pedido.Bebida == null)
                        pedido.Bebida = "";

                    if (pedido.Postre == null)
                        pedido.Postre = "";

                    context.Pedidos.Add(pedido);
                    context.SaveChanges();
                    prePedido = new Pedido();
                }
                
            }
            return RedirectToAction(nameof(PedidoExitoso));
        }

        public IActionResult FalloDePedido()
        {
            return View();
        }
        public IActionResult PedidoExitoso()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListarPedidos()
        {
            List<Pedido>? listaPedidos = null;
           
            using (PedidosContext context = new())
            {
                listaPedidos = context.Pedidos.ToList();
            }

            return View(listaPedidos);
        }

        [HttpGet]
        public IActionResult DeletePedido(int id)
        {
            using (PedidosContext context = new())
            {
                if (id != 0)
                {
                    Pedido? pedido = context.Pedidos.Find(id);
                    if (pedido != null)
                    {
                        context.Pedidos.Remove(pedido);
                        context.SaveChanges();
                    }
                }
            }

            return RedirectToAction(nameof(ListarPedidos));
        }


    }
}

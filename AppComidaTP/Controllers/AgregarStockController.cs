using AppComidaTP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public IActionResult ListarStock()
        {
            List<Comida>? listaComida = null;
            List<Bebida>? listaBebida = null;
            List<Postre>? listaPostre = null;

            using (PedidosContext context = new())
            {
                listaComida = context.Comida.ToList();
                listaBebida = context.Bebida.ToList();
                listaPostre = context.Postre.ToList();
            }

            ViewModel alimentos = new ViewModel(listaComida, listaBebida, listaPostre);

            return View(alimentos);
        }

        [HttpGet]
        public IActionResult EditComida(int codigo)
        {
            using (PedidosContext context = new())
            {
                
                Comida? comida = context.Comida.Find(codigo);
                comida.Codigo = codigo;
                if (comida != null)
                {
                    return View(comida);
                }
                else
                {
                    return RedirectToAction(nameof(ListarStock));
                }
            }
        }

        [HttpPost]
        public IActionResult UpdateComida(int Codigo, Comida comida)
        {
            using (PedidosContext context = new())
            {
                bool? sePudo = null;

                if (Codigo != comida.Codigo)
                {
                    sePudo = false;
                }
                context.Entry(comida).State = EntityState.Modified;

                try
                {
                    context.SaveChanges();
                    sePudo = true;
                }
                catch
                {
                    sePudo = false;
                }

                if (sePudo != false)
                {
                    return RedirectToAction(nameof(ListarStock));
                }
                else
                {
                    return RedirectToAction(nameof(EditComida));
                }
            }
        }

        [HttpGet]
        public IActionResult EditBebida(int Codigo)
        {
            using (PedidosContext context = new())
            {

                Bebida? dato = context.Bebida.Find(Codigo);
                if (dato != null)
                {
                    return View(dato);
                }
                else
                {
                    return RedirectToAction(nameof(ListarStock));
                }
            }
        }
        [HttpPost]
        public IActionResult UpdateBebida(int Codigo, Bebida bebida)
        {

            using (PedidosContext context = new())
            {

                Comida? dato = context.Comida.Find(Codigo);
                if (Codigo != bebida.Codigo)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    context.Bebida.Update(bebida);
                    context.SaveChanges();
                }
                return RedirectToAction(nameof(ListarStock));
            }
        }

        [HttpGet]
        public IActionResult EditPostre(int Codigo)
        {
            using (PedidosContext context = new())
            {

                Postre? dato = context.Postre.Find(Codigo);
                if (dato != null)
                {
                    return View(dato);
                }
                else
                {
                    return RedirectToAction(nameof(ListarStock));
                }
            }
        }
        [HttpPost]
        public IActionResult UpdatePostre(int Codigo, Postre postre)
        {

            using (PedidosContext context = new())
            {
                if (Codigo != postre.Codigo)
                {
                    return NotFound();
                }
                
                if (ModelState.IsValid)
                {
                    context.Postre.Update(postre);
                    context.SaveChanges();
                }
                return RedirectToAction(nameof(ListarStock));
            }
        }


        [HttpGet]
        public IActionResult DeleteComida(int Codigo)
        {
            using (PedidosContext context = new())
            {
                if (Codigo != 0)
                {
                    Comida? comida = context.Comida.Find(Codigo);
                    if (comida != null)
                    {
                        context.Comida.Remove(comida);
                        context.SaveChanges();
                    }
                }
            }

            return RedirectToAction(nameof(ListarStock));
        }

        [HttpGet]
        public IActionResult DeleteBebida(int Codigo)
        {
            using (PedidosContext context = new())
            {
                if (Codigo != 0)
                {
                    Bebida? bebida = context.Bebida.Find(Codigo);
                    if (bebida != null)
                    {
                        context.Bebida.Remove(bebida);
                        context.SaveChanges();
                    }
                }
            }

            return RedirectToAction(nameof(ListarStock));
        }

        [HttpGet]
        public IActionResult DeletePostre(int Codigo)
        {
            using (PedidosContext context = new())
            {
                if (Codigo != 0)
                {
                    Postre? postre = context.Postre.Find(Codigo);
                    if (postre != null)
                    {
                        context.Postre.Remove(postre);
                        context.SaveChanges();
                    }
                }
            }

            return RedirectToAction(nameof(ListarStock));
        }
    }
}

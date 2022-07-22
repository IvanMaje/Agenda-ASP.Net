using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Controllers
{
    public class HomeController : Controller {

        private IListasAlmacen ListasAlmacen;
        public HomeController(IListasAlmacen ListasAlmacen)
        {
            this.ListasAlmacen = ListasAlmacen;
        }

        [Route("")]

        public ViewResult Index()
        {
            List<ListaAmigos> listas = ListasAlmacen.ObtenerListasDeAmigos();
            return View(listas);
        }


        [Route("Home/Amigos_Listado/{listaAmigosId?}")]
        public ViewResult Amigos_Listado(int listaAmigosId)
        {
            ListaAmigos listaAmigos = ListasAlmacen.ObtenerListaConAmigos(listaAmigosId);
            return View(listaAmigos);
        }

        [Route("Home/Crear_Listado")]
        [HttpGet]
        public ViewResult Crear_Lista()
        {
            return View();
        }

        [Route("Home/Crear_Listado")]
        [HttpPost]
        public IActionResult Crear_Lista(ListaAmigos nuevaLista)
        {
            ListasAlmacen.ListaNueva(nuevaLista);
            return RedirectToAction("Index");
        }

        [Route("Home/Crear_Amigo/{listaAmigosId?}")]
        [HttpGet]
        public ViewResult Crear_Amigo(int listaAmigosId)
        {
            Amigo amigo = new Amigo();
            amigo.ListaAmigosId = listaAmigosId;
            return View(amigo);
        }

        [Route("Home/Crear_Amigo/{listaAmigosId?}")]
        [HttpPost]
        public IActionResult Crear_Amigo(Amigo amigo)
        {
            ListasAlmacen.AmigoNuevo(amigo);
            return RedirectToAction("Amigos_Listado", new { listaId = amigo.ListaAmigosId });
        }

        [Route("Home/Editar_Lista/{Id?}")]
        [HttpGet]
        public ViewResult Editar_Lista(int id)
        {
            ListaAmigos lista = ListasAlmacen.ObtenerLista(id);
            return View(lista);
        }

        [Route("Home/Editar_Lista/{Id?}")]
        [HttpPost]
        public IActionResult Editar_Lista(ListaAmigos lista)
        {
            ListasAlmacen.ModificarLista(lista);
            return RedirectToAction("Index");
        }

        [Route("Home/Borrar_Lista/{Id?}")]
        [HttpPost]
        public IActionResult Borrar_Lista(int id)
        {
            ListaAmigos lista = ListasAlmacen.ObtenerLista(id);
            ListasAlmacen.EliminarLista(lista);
            return RedirectToAction("Index");
        }
    }

}

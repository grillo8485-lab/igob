using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;

namespace IGOB.Controllers
{
    public class CartasController : ValidaSession
    {
        private brCartas ObrCartas = new brCartas();
        private brTiposCartas ObrTiposCartas = new brTiposCartas();

        // GET: Cartas
        public ActionResult Index()
        {
            List<beTiposCartas> TCList = ObrTiposCartas.listarTodos_TiposCartas().ToList();
            ViewBag.TCList = new SelectList(TCList,"IdTipoCarta", "TipoCarta");

            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ViewBag.gob = b.id5;

            List<beCartas> cartasList = ObrCartas.listarTodos_Cartas_GetAll().Where(x=>x.IdGobierno == b.id5).ToList();
            return View(cartasList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beCartas cartas) {
            var b = (ClsGenerica) System.Web.HttpContext.Current.Session["ClsGenerico"];
            cartas.IdGobierno = b.id5;
            if (ModelState.IsValid)
            {
                ObrCartas.guardarCartas(cartas);
                ViewBag.Result = "Agregado correctamente ";
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                ViewBag.Result = "No se ha podido agregar";
            }

            return Json(ViewBag.Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            beCartas cartas = ObrCartas.traerCartas_x_IdCarta(id);

            if (cartas != null)
            {
                ObrCartas.eliminarCartas(id);
                ViewBag.Result = "Eliminado correctamente";
            }
            else
            {
                ViewBag.Result = "No se ha podido eliminar";
            }
            return Json(ViewBag.Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beCartas cartas)
        {
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            cartas.IdGobierno = b.id5;
            beCartas carta = ObrCartas.traerCartas_x_IdCarta(cartas.IdCarta);
            if (carta != null)
            {
                ObrCartas.actualizarCartas(cartas);
                ViewBag.Result = "Editado correctamente";
            }
            else
            {
                ViewBag.Result = "No se ha podido editar";
            }

            return Json(ViewBag.Result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Autorizar(int id)
        {
            beCartas cartas = ObrCartas.traerCartas_x_IdCarta(id);

            if (cartas != null)
            {
                cartas.IdEstatus = 1;
                ObrCartas.actualizarCartas(cartas);
                ViewBag.Result = "Autorizado correctamente";
            }
            else
            {
                ViewBag.Result = "No se ha podido Autorizadar";
            }
            return Json(ViewBag.Result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Rechazar(int id)
        {
            beCartas cartas = ObrCartas.traerCartas_x_IdCarta(id);

            if (cartas != null)
            {
                cartas.IdEstatus = 2;
                ObrCartas.actualizarCartas(cartas);
                ViewBag.Result = "Rechazado correctamente";
            }
            else
            {
                ViewBag.Result = "No se ha podido Rechazar";
            }
            return Json(ViewBag.Result, JsonRequestBehavior.AllowGet);
        }
    }
}
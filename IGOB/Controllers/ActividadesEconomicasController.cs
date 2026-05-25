using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Models;

namespace IGOB.Controllers
{
    public class ActividadesEconomicasController : ValidaSession
    {
        private brActividadesEconomicas obrActividadEconomica = new brActividadesEconomicas();

        // GET: ActividadesEconomicas
        public ActionResult Index()
        {
            ViewBag.Partidas = new SelectList(getPartidas(),"IdPartida","Partida");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beActividadesEconomicas actividadesEconomicas)
        {
            try
            {
                actividadesEconomicas.Activo = true;
                return Json(new { success = true, mensaje = obrActividadEconomica.guardarActividadesEconomicas(actividadesEconomicas) }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beActividadesEconomicas actividadesEconomicas)
        {

            beActividadesEconomicas actividadEconomica = obrActividadEconomica.traerActividadesEconomicas_x_IdActividadEconomica(actividadesEconomicas.IdActividadEconomica);

            if (actividadesEconomicas != null)
            {
                var r = obrActividadEconomica.actualizarActividadesEconomicas(actividadesEconomicas);
                return Json(new { success = true, m = "Editado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false, m = "No se ha podido editar" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            if (obrActividadEconomica.traerActividadesEconomicas_x_IdActividadEconomica(id) != null)
            {
                obrActividadEconomica.eliminarActividadesEconomicas(id);
                return Json(new { success = true, m = "Eliminado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false, m = "No se ha podido eliminar" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddPartida_x_IdActividadEconomica(bePartidasActividadesEconomicas actividadesEconomicas)
        {
            try
            {
                brPartidasActividadesEconomicas p = new brPartidasActividadesEconomicas();

                 var isExists = p.listarTodos_PartidasActividadesEconomicas().Where(x => x.IdPartida == actividadesEconomicas.IdPartida && x.IdActividadEconomica == actividadesEconomicas.IdActividadEconomica).FirstOrDefault();

                if (isExists != null)              
                    return Json(new { success = false, mensaje = "La partida se ha agregado anteriormente" }, JsonRequestBehavior.AllowGet);
                
                return Json(new { success = true, mensaje = p.guardarPartidasActividadesEconomicas(actividadesEconomicas) }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public List< bePartidas > getPartidas()
        {
            var c = new brPartidas().listarTodos_Partidas();

            foreach (var item in c)
            {
                item.Partida = item.ClavePartida + " " + item.Partida;
            }

            return c;
        }

        public JsonResult GetPartidasActividadesEconomicas_x_IdActividadEconomica(int IdActividadEconomica)
        {
            try
            {
                return Json(new { success = true, mensaje = new brPartidasActividadesEconomicas().listarTodos_PartidasActividadesEconomicas_GetAll().Where(x => x.IdActividadEconomica == IdActividadEconomica).ToList() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult EliminarPartidaActEconomica(int IdPartidaActEconomica)
        {
            try
            {
                brPartidasActividadesEconomicas p = new brPartidasActividadesEconomicas();
                var r = p.eliminarPartidasActividadesEconomicas(IdPartidaActEconomica);

                return Json(new { success = true, mensaje = r }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetActividadesEconomicas()
        {
            try
            {
                return Json(new { success = true, mensaje = obrActividadEconomica.listarTodos_ActividadesEconomicas() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
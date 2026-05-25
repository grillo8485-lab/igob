using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;
using IGOB.Models;

namespace IGOB.Controllers
{
    public class PresupuestosPartidasController : ValidaSession
    {
        private brPresupuestosPartidas p = new brPresupuestosPartidas();
        private brClavesPresupuestalesDetalles cd = new brClavesPresupuestalesDetalles();

        ClsClavesPresupuestales c = new ClsClavesPresupuestales();
        // GET: Presupuestos
        public ActionResult Index()
        {
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            
            ViewBag.PresupuestoList = new SelectList(c.GetPresupuestosPartidas_x_IdDependencia(b.id4), "IdPresupuesto", "MontoSaldo");
            ViewBag.CapList = new SelectList(c.GetCapitulos(), "IdCapitulo", "Capitulo");
            ViewBag.ejercicioActual = c.getEjercicioFiscal();
            ViewBag.ORList = new SelectList(c.GetOrigenRecurso(), "IdOrigenRecurso", "OrigenRecurso");
            ViewBag.Dependencias = new SelectList(c.GetDependencias(), "IdDependencia", "Dependencia");

            var todos = p.listarTodos_PresupuestosPartidas_GetAll();
            return View(todos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GetClavesPresupuestalesDetalles_x_IdPresupuestoPartida(int IdPresupuestoPartida)
        {
            var Details = c.GetClavesPresupuestalesDetalles_x_IdPresupuestoPartida(IdPresupuestoPartida);
            return Json(new { success = true, r = Details }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getMontoSaldo(int IdPresupuestoPartida)
        {
            var r = c.getMontoSaldo(IdPresupuestoPartida);

            return Json(new { success = true, m = r}, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getAllPartidas_x_IdCapitulo(int pIdCapitulo)
        {
            try
            {                
                var b = c.getAllPartidas_x_IdCapitulo(pIdCapitulo);
                return Json(new { success = true, objeto = b }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult getPartida_x_IdPartida(int IdPartida)
        {
            try
            {
                var b = c.getPartida_x_IdPartida(IdPartida);
                return Json(new { success = true, objeto = b }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetCapitulo_x_IdPartida(int IdPartida)
        {
            try
            {
                var b = c.GetCapitulo_x_IdPartida(IdPartida);
                return Json(new { success = true, objeto = b }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(bePresupuestosPartidas presupuestosPartidas)
        {
            try
            {

                var presupuestoPartidaDependencia = c.GetPresupuestosPartidas_x_IdDependencia(presupuestosPartidas.IdDependencia).Where(x => x.IdPartida == presupuestosPartidas.IdPartida).FirstOrDefault();
                var r = "El registro para la partida ya ha sido creado con anterioridad";

                if (presupuestoPartidaDependencia == null)
                {
                    var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                    presupuestosPartidas.FechaRegistro = DateTime.Now;
                    presupuestosPartidas.IdUsuarioRegistro = (int)b.id2;
                    presupuestosPartidas.IdPresupuestoPartida = 0;

                    var response = p.guardarPresupuestosPartidas(presupuestosPartidas);

                    r = "El presupuesto para la partida ha sido creado con exito";

                    return Json(new { success = true, m = r ,id = response }, JsonRequestBehavior.AllowGet);

                }
                return Json( new { success = false, m = r},JsonRequestBehavior.AllowGet );
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveDetails(beClavesPresupuestalesDetalles clavesPresupuestalesDetalles)
        {
            try
            {
                var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

                clavesPresupuestalesDetalles.FechaRegistro = DateTime.Now;
                clavesPresupuestalesDetalles.IdUsuarioRegistro = (int)b.id2;
                clavesPresupuestalesDetalles.IdClavePresupuestalDetalle = 0;

                var r = cd.guardarClavesPresupuestalesDetalles(clavesPresupuestalesDetalles);

                return Json(new { success = true, m = "Añadido Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int IdPresupuestoPartida)
        {
            try
            {
                var r = c.DeletePresupuestosPartidas_w_ClavesPresupuestalesDetalles(IdPresupuestoPartida);

                return Json(new { success = true, m = r },JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = true, m = ex.Message }, JsonRequestBehavior.AllowGet);

                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(bePresupuestosPartidas presupuestos)
        {

            bePresupuestosPartidas presupuesto = p.traerPresupuestosPartidas_x_IdPresupuestoPartida(presupuestos.IdPresupuestoPartida);
            if (presupuesto != null)
            {
                presupuesto.NumeroMinistracion = presupuestos.NumeroMinistracion;
                p.actualizarPresupuestosPartidas(presupuesto);
                return Json(new { success = true, m = "Editado correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success= false, m =  "No se ha podido editar"}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EliminarClavePresupuestalDetalles(int IdClavePresupuestalDetalle)
        {
            try
            {
                var r = cd.eliminarClavesPresupuestalesDetalles(IdClavePresupuestalDetalle);

                return Json(new { success = true, m = r }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, m = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
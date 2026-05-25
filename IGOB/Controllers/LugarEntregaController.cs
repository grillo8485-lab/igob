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
    public class LugarEntregaController : ValidaSession
    {
        private brLugaresEntregaFirma ObrLugarEntregaFirma = new brLugaresEntregaFirma();
        private brDependencias ObrDependencias = new brDependencias();
        private brEF_EntidadesFederativas ObrEF_EntidadesFederativas = new brEF_EntidadesFederativas();
        // GET: Catalogos/LugarEntrega
        public ActionResult Index()
        {
            ViewBag.ListDep = new SelectList(ObrDependencias.listarTodos_Dependencias(), "IdDependencia", "Dependencia");
            ViewBag.ListEnt = new SelectList(ObrEF_EntidadesFederativas.listarTodos_EF_EntidadesFederativas(), "ClaveEstado", "Estado");

            return View(ObrLugarEntregaFirma.Listar_LugaresEntregaFirma_Traer_Entrega());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beLugaresEntregaFirma lef)
        {
            var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            lef.IdUsuarioRegistro = (int)c.id2;
            lef.FechaRegistro = DateTime.Now;
            if (ModelState.IsValid)
            {

                ObrLugarEntregaFirma.guardarLugaresEntregaFirma(lef);
                return Json(new { success = true, m = "Lugar de entrega: <strong>" + lef.Lugar + "</strong> agregado correctamente." }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false, m = ModelState.Values.SelectMany(v => v.Errors) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int Id)
        {
            if (ObrLugarEntregaFirma.traerLugaresEntregaFirma_x_IdLugarEntregaFirma(Id) != null)
            {
                ObrLugarEntregaFirma.eliminarLugaresEntregaFirma(Id);
                return Json(new { success = true, m = "Eliminado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false, m = "No se ha podido eliminar" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beLugaresEntregaFirma lef)
        {
            if (ObrLugarEntregaFirma.traerLugaresEntregaFirma_x_IdLugarEntregaFirma(lef.IdLugarEntregaFirma) != null)
            {
                lef.FechaRegistro = ObrLugarEntregaFirma.traerLugaresEntregaFirma_x_IdLugarEntregaFirma(lef.IdLugarEntregaFirma).FechaRegistro;
                ObrLugarEntregaFirma.actualizarLugaresEntregaFirma(lef);
                return Json(new { success = true, m = "Editado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false, m = "No se ha podido editar" }, JsonRequestBehavior.AllowGet);
        }
    }
}
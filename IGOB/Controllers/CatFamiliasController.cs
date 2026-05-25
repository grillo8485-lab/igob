using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;

namespace IGOB.Areas.Catalogos
{
    public class CatFamiliasController : ValidaSession
    {
        private brFamilias ObrFamlias = new brFamilias();

        // GET: Catalogos/CatFamilias
        public ActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public JsonResult Getfamilias()
        {
            try
            {
                var jsonResult = Json(new { sucess = true, mensaje = ObrFamlias.listarTodos_Familias() }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
           


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beFamilias familias)
        {
            if (ModelState.IsValid)
            {
                ObrFamlias.guardarFamilias(familias);
                return Json(new { success = true, m = "Familia <strong>" + familias.Familia + "</strong> agregada correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = true, m = ModelState.Values.SelectMany(v => v.Errors) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            if (ObrFamlias.traerFamilias_x_IdFamilia(id) != null)
            {
                ObrFamlias.eliminarFamilias(id);
                return Json(new { success = true, m = "Familia eliminada correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = true, m = "No se ha podido eliminar" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beFamilias familias)
        {
            if ( ObrFamlias.traerFamilias_x_IdFamilia(familias.IdFamilia) != null)
            {
                ObrFamlias.actualizarFamilias(familias);
                return Json(new { success = true, m = "Familia editada correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = true, m = "No se ha podido editar" }, JsonRequestBehavior.AllowGet);
        }
    }
}
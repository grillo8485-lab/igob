using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.ReglasNegocios;
using iGob.Entidades;

namespace PruebaiGob.Controllers
{
    public class CapitulosController : ValidaSession
    {
        private brCapitulos obrCapitulos = new brCapitulos();

        // GET: ActividadesEconomicas
        public ActionResult index()
        {
            return View(obrCapitulos.listarTodos_Capitulos());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beCapitulos capitulos)
        {
            if (ModelState.IsValid)
            {
                capitulos.Activo = true;
                obrCapitulos.guardarCapitulos(capitulos);
                var resp = "Capítulo: <strong>" + capitulos.Capitulo + "</strong> agregado correctamente.";
                return Json(new { success = true, m = resp }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json( new { success = false, m = ModelState.Values.SelectMany(v => v.Errors) }, JsonRequestBehavior.AllowGet);           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            if (obrCapitulos.traerCapitulos_x_IdCapitulo(id) != null)
            {
                obrCapitulos.eliminarCapitulos(id);
                return Json(new { success = true, m = "Eliminado Correctamente"}, JsonRequestBehavior.AllowGet);
            }
            else          
                return Json( new { success= false, m = "No se ha podido eliminar" }, JsonRequestBehavior.AllowGet);            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beCapitulos capitulos)
        {
            if (obrCapitulos.traerCapitulos_x_IdCapitulo(capitulos.IdCapitulo) != null)
            {
                obrCapitulos.actualizarCapitulos(capitulos);
                return Json(new { success = true, m = "Editado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else         
                return Json(new { success = false, m = "No se ha podido editar" }, JsonRequestBehavior.AllowGet);
        }
    }
}
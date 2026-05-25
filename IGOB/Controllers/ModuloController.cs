using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class ModuloController : ValidaSession
    {
        // GET: Modulo
        public ActionResult Index()
        {
            ClsModulo modulo = new ClsModulo();
            List<ClsGenerica> clase = modulo.getModulos().OrderBy(s=> s.id2).ToList();
            return View(clase);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult createModulo(beSysModulos pSysModulo)
        {

            try
            {
                ClsModulo a = new ClsModulo();
                a.saveModulo(pSysModulo);
                return Json(new { success = true, mensaje = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getModulo(int pIdModulo)
        {

            ClsModulo modulo = new ClsModulo();
            beSysModulos a = modulo.getModulo(pIdModulo);

            return Json(new { success = true, objeto = a }, JsonRequestBehavior.AllowGet); ;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult actualizarModulo(beSysModulos pSysModulo)
        {
            try
            {
                ClsModulo modulo = new ClsModulo();
                modulo.saveEditModulo(pSysModulo);

                return Json(new { success = true, mensaje = ""}, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception ex)
            {
                return Json(new { success = true, mensaje =  ex.Message }, JsonRequestBehavior.AllowGet); ;
            }
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult deleteModulo(int pIdModulo)
        {
            try
            {
                ClsModulo modulo = new ClsModulo();
                var a = modulo.getModulo(pIdModulo);
                a.Activo = false;
                modulo.saveEditModulo(a);

                return Json(new { success = true, mensaje = "" }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception ex)
            {
                return Json(new { success = true, mensaje = ex.Message }, JsonRequestBehavior.AllowGet); ;
            }

        }
    }
}
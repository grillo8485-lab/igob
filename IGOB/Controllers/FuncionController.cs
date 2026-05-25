using iGob.Entidades;
using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class FuncionController : ValidaSession
    {
        // GET: Funcion
        public ActionResult Index()
        {
            ClsFuncion funcion = new ClsFuncion();
            ClsModulo a = new ClsModulo();
            List<ClsGenerica> clase = funcion.getFunciones().OrderBy(s => s.id3).ToList();
            ViewBag.ListFunciones = new SelectList(a.getAllModulo(), "IdModulo", "Descripcion");
            return View(clase);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult createFuncion(beSysFunciones pSysFuncion)
        {

            try
            {
                ClsFuncion a = new ClsFuncion();
                a.saveFuncion(pSysFuncion);
                return Json(new { success = true, mensaje = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getFuncion(int pIdFuncion)
        {

            ClsFuncion funcion = new ClsFuncion();
            beSysFunciones a = funcion.getFuncion(pIdFuncion);

            return Json(new { success = true, objeto = a }, JsonRequestBehavior.AllowGet); ;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult actualizarFuncion(beSysFunciones pSysFuncion)
        {
            try
            {
                ClsFuncion funcion = new ClsFuncion();
                funcion.saveEditFuncion(pSysFuncion);

                return Json(new { success = true, mensaje = "" }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception ex)
            {
                return Json(new { success = true, mensaje = ex.Message }, JsonRequestBehavior.AllowGet); ;
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult deleteFuncion(int pIdFuncion)
        {
            try
            {
                ClsFuncion funcion = new ClsFuncion();
                var a = funcion.getFuncion(pIdFuncion);
                a.Activo = false;
                funcion.saveEditFuncion(a);

                return Json(new { success = true, mensaje = "" }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception ex)
            {
                return Json(new { success = true, mensaje = ex.Message }, JsonRequestBehavior.AllowGet); ;
            }

        }
    }
}
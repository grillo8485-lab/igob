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
    public class PerfilController : ValidaSession
    {
        // GET: Perfil
        public ActionResult Index()
        {
            ClsPerfil Perfil = new ClsPerfil();
            List<ClsGenerica> clase = Perfil.getPerfiles();
            return View(clase);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult createPerfil(beSysPerfiles pSysPerfil)
        {

            try
            {
                ClsPerfil Perfil = new ClsPerfil();
                Perfil.savePerfil(pSysPerfil);
                return Json(new { success = true, mensaje = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getPerfil(int pIdPerfil)
        {

            ClsPerfil Perfil = new ClsPerfil();
            beSysPerfiles a = Perfil.getPerfil(pIdPerfil);

            return Json(new { success = true, objeto = a }, JsonRequestBehavior.AllowGet); ;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult actualizarPerfil(beSysPerfiles pSysPerfil)
        {
            try
            {
                ClsPerfil Perfil = new ClsPerfil();
                Perfil.saveEditPerfil(pSysPerfil);

                return Json(new { success = true, mensaje = "" }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception ex)
            {
                return Json(new { success = true, mensaje = ex.Message }, JsonRequestBehavior.AllowGet); ;
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult deletePerfil(int pIdPerfil)
        {
            try
            {
                ClsPerfil Perfil = new ClsPerfil();
                var a = Perfil.getPerfil(pIdPerfil);
                a.Activo = false;
                Perfil.saveEditPerfil(a);

                return Json(new { success = true, mensaje = "" }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception ex)
            {
                return Json(new { success = true, mensaje = ex.Message }, JsonRequestBehavior.AllowGet); ;
            }

        }
    }
}
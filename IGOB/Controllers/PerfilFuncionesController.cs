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
    public class PerfilFuncionesController : ValidaSession
    {
        // GET: PerfilFunciones
        public ActionResult Index()
        {
            ClsUsuario a = new ClsUsuario();
            ViewBag.TPListPerfiles = new SelectList(a.getPerfiles(), "IdPerfil", "Descripcion");
            
            return View();
        }

        [HttpPost]
        public JsonResult getMenu_x_IdPerfil(int pIdPerfil)
        {

            try
            {
                ClsPerfilFuncion perfilFunciones = new ClsPerfilFuncion();
                var listMenu = perfilFunciones.getAllMenu();
                var perfilesFunciones = perfilFunciones.getAllPerfilFunciones_x_IdPerfil(pIdPerfil);
                listMenu = perfilFunciones.procesarMenuPerfilFunciones(listMenu, perfilesFunciones);
                ClsPerfil Perfil = new ClsPerfil();
                return Json(new { success = true, lista = listMenu }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }


        }
        [HttpPost]
        public JsonResult createPerfilFunciones(List<beSysPerfilesFunciones> pLstPerfilFunciones)
        {

            try
            {
                
                ClsPerfilFuncion perfilFunciones = new ClsPerfilFuncion();
                var lstPerfilFuncionesBase = perfilFunciones.getAllPerfilFunciones_x_IdPerfil(pLstPerfilFunciones[0].IdPerfil);
                var lstEliminar = perfilFunciones.getPerfilFuncionesEliminar(lstPerfilFuncionesBase, pLstPerfilFunciones);
                var lstAgregar = perfilFunciones.getPerfilFuncionesAgregar(lstPerfilFuncionesBase, pLstPerfilFunciones);
                var lstActualizar = perfilFunciones.getPerfilFuncionesActualizar(lstPerfilFuncionesBase, pLstPerfilFunciones);

                foreach(var item in lstEliminar)
                {
                    perfilFunciones.eliminarPerfilFuciones(item.IdPerfilFuncion);
                }
                foreach (var item in lstAgregar)
                {
                    perfilFunciones.savePerfilFuciones(item);
                }
                foreach (var item in lstActualizar)
                {
                    perfilFunciones.saveEditPerfilFUnciones(item);
                }

                return Json(new { success = true, lista = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }


        }


    }
}
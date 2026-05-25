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
    public class LicitacionesListadoInvitacionesController : ValidaSession
    {
        // GET: LicitacionesListadoInvitaciones
        public ActionResult Index()
        {
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            List<beListadoLicitacionesInvitacionProveedores> listadoInvitacionesProv = new brListadoLicitacionesInvitacionProveedores().ListadoLicitacionesInvitacionProveedores(b.id6).ToList();
            return View(listadoInvitacionesProv);
        }

        public JsonResult envioPrueba(int IdLicitacion)
        {
            return Json(IdLicitacion, JsonRequestBehavior.AllowGet);
        }
    }
}
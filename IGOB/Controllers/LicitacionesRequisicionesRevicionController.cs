using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class LicitacionesRequisicionesRevicionController : ValidaSession
    {
        ClsListadoLicitacionesInvitacionAceptadasProveedor aceptadasProveedor = new ClsListadoLicitacionesInvitacionAceptadasProveedor();
        ListadoLicitacionesInvitacionAceptadasProveedor model = new ListadoLicitacionesInvitacionAceptadasProveedor();
        // GET: LicitacionesRequisicionesRevicion
        public ActionResult Index(int pIdLicitacion)
        {
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            model.Titulo = aceptadasProveedor.getAllRevisarPagosProveedor((int)b.id2).Where(s=> s.IdLicitacion == pIdLicitacion).First().Licitacion;
            model.lstInvitacionesAcptadasProveedor = aceptadasProveedor.Licitacion_Requisiciones_Revisor(pIdLicitacion);
            return View(model);
        }
    }
}
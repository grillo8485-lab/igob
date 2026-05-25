using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class AdjudicacionConsultaController : ValidaSession
    {
        // GET: AdjudicacionConsulta
        public ActionResult Index(int id)
        {
            var TipoUsuario = TempData.ContainsKey("TipoPropuesta") ? int.Parse(TempData["TipoPropuesta"].ToString()) : 0;

            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ClsAdquisicion adquisicion = new ClsAdquisicion();

            var a = b.id == 8 ? adquisicion.consultaAdjudicacionProveedor((int)b.id6, id) : adquisicion.consultaAdjudicacion(id, (int)b.id, b.id4);//pIdLista,pIdPerfil,pIdDependencia

            ViewBag.tipoAdjudicacion = id;
            ViewBag.IdPerfil = b.id;

            return View(a);
        }
    }
}
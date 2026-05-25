using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class RequisicionesComprasMenoresConsultaController : ValidaSession
    {
        // GET: RequisicionesComprasMenoresConsulta
        public ActionResult Index()
        {
            
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ClsRequisicionesComprasMenores requisicionescm = new ClsRequisicionesComprasMenores();
            var a = requisicionescm.consultaRequisicionCM(1, (int)b.id, b.id4);//pIdLista,pIdPerfil,pIdDependencia
            return View(a);
        }
    }
}
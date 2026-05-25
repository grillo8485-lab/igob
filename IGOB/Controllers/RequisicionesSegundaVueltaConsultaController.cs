using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class RequisicionesSegundaVueltaConsultaController : Controller
    {
        // GET: RequisicionesSegundaVueltaConsulta
        public ActionResult Index()
        {
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ClsRequisiciones requisiciones = new ClsRequisiciones();
            var a = requisiciones.consultaRequisicionSegundaVuelta( b.id4);//pIdDependencia
            a = a.Where(s => s.IdEstatusRequisicion == 5 || s.IdEstatusRequisicion == 150).ToList();
            ViewBag.OSession = b;
            return View(a);
        }
    }
}
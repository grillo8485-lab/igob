using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class RequisicionHistorialController : Controller
    {
        // GET: RequisicionHistorial
        public ActionResult Index()
        {
            ViewBag.tipoRequisicion = 1;
            var idFuncion = (int)Session["IdFuncion"];
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ClsRequisiciones requisiciones = new ClsRequisiciones();
            var a = requisiciones.requisicionHistorial(b.id4, (int)b.id);//pIdDependencia,pIdPerfil
            
            return View(a);
        }
        [HttpGet]
        public ActionResult editRequisicion(int idRequisicion )
        {
            TempData["Historial"] = true;
            
            return RedirectToAction("Index", "Requisiciones", new { id = 1, IdRequisicion = idRequisicion });
        }
    }
}
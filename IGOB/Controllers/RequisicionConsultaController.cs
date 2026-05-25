using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class RequisicionConsultaController : ValidaSession
    {
        // GET: RequisicionConsulta
        public ActionResult Index(int id)
        {
            ViewBag.tipoRequisicion = id;
            var idFuncion = (int)Session["IdFuncion"];
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ClsRequisiciones requisiciones = new ClsRequisiciones();
            var a = requisiciones.consultaRequisicion(id,(int)b.id,b.id4);//pIdLista,pIdPerfil,pIdDependencia

            switch ((int)b.id)
            {
                case 7:
                     a = a.Where(s=> s.IdUsuarioRevisor == (int)b.id2).ToList();
                    break;
                case 5:
                    if(idFuncion==30 || idFuncion==1045)// para asignar requisicion a revisor
                        a = a.Where(s => s.IdEstatusRequisicion == 70 ).ToList();
                    else// para ver las requisiciones autorizadas por revisor
                        a = a.Where(s => s.IdEstatusRequisicion == 90 || s.IdEstatusRequisicion== 85).ToList();
                    break;
            }
           
            ViewBag.OSession = b;
            return View(a);
        }

        public ActionResult editRequisicion(int id_,int idRequisicion=0)
        {
            TempData["Historial"] = false;
            return RedirectToAction("Index","Requisiciones", new { id = id_, IdRequisicion= idRequisicion });
        }
    }
}
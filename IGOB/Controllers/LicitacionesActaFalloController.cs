using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class LicitacionesActaFalloController : ValidaSession
    {
        // GET: LicitacionesActaFallo
        public ActionResult Index(int pIdLic = 0)
        {
            ClsLicitacionesCambios ReqSol = new ClsLicitacionesCambios();
            ViewBag.Licitacion = ReqSol.getLicitacion(pIdLic);
            //obtenemos los datos necesarios
            brLicitacionesActaFallo Lic = new brLicitacionesActaFallo();

            //obtenemos los datos de licitacion
            beLicitacionesActaFallo obeLic = Lic.traerActaFallo_Licitaciones_x_IdLicitacion(pIdLic);

            //obtenemos los datos de las requisiciones en la licitacion
            List<beLicitacionesActaFallo> ListaReq = Lic.traerActaFallo_PropuestasTecnicaEconomica_x_IdLicitacion(pIdLic);
                        
            ViewBag.ListaReq = ListaReq;

            ViewBag.pIdLic = pIdLic;
            ViewBag.FolioLicitacion = obeLic.Titulo;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ImprimirSolicitud(int pIdLic)
        {
            try
            {
                ClsLicitacionesImprimirActaFallo ReqSol = new ClsLicitacionesImprimirActaFallo(Server.MapPath("~/Files/Reportes/"), Server.MapPath("~/Files/Plantillas/"));

                //obtenemos el gobierno
                var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                int IdGobierno = usuario.id5;

                string Archivo = ReqSol.ImprimeArchivo(pIdLic, IdGobierno);

                return Json(new { success = true, Descarga = Archivo }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveGenerarPublicarReferenciaActaFallo(int pIdLic)
        {
            try
            {
                ClsLicitacionesCambios ReqSol = new ClsLicitacionesCambios();

                //Proc_GenerarRequisionesSegundaLicitacion_x_IdLicitacion
               
                var result = ReqSol.GenerarRequisionesSegundaLicitacion_x_IdLicitacion(pIdLic);
                if (result.obeLicitaciones)
                {
                    var licitacion = ReqSol.getLicitacion(pIdLic);
                    licitacion.IdEstatusLicitacion = 70;
                    ReqSol.editLicitacion(licitacion);
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, mensaje = result.errMessage }, JsonRequestBehavior.AllowGet);
                }

                
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }

}
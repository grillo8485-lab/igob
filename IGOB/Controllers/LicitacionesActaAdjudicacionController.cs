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
    public class LicitacionesActaAdjudicacionController : ValidaSession
    {
        // GET: LicitacionesActaAdjudicacion
        public ActionResult Index(int pIdLic = 0)
        {
            ClsLicitacionesCambios ReqSol = new ClsLicitacionesCambios();
            ViewBag.Licitacion = ReqSol.getLicitacion(pIdLic);
            //obtenemos los datos necesarios
            brLicitacionesActaAdjudicacion Lic = new brLicitacionesActaAdjudicacion();

            //obtenemos los datos de licitacion
            beLicitacionesActaAdjudicacion obeLic = Lic.traerActaAdjudicacion_Licitaciones_x_IdLicitacion(pIdLic);
            
            //obtenemos los datos de las requisiciones en la licitacion
            List<beLicitacionesActaAdjudicacion> ListaReq = Lic.traerActaAdjudicacion_Requisiciones_x_IdLicitacion(pIdLic);

            //obtenemos los datos de lotes ofertados
            List<beLicitacionesActaAdjudicacion> ListaLotes = Lic.traerActaAdjudicacion_Lotes_x_IdLicitacion(pIdLic);

            ViewBag.ListaReq = ListaReq;
            ViewBag.ListaLotes = ListaLotes;
            
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
                ClsLicitacionesImprimirActaAdjudicacion ReqSol = new ClsLicitacionesImprimirActaAdjudicacion(Server.MapPath("~/Files/Reportes/"), Server.MapPath("~/Files/Plantillas/"));

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
        public JsonResult saveGenerarActaAdjudicacionProveedores(int pIdLic)
        {
            try
            {
                ClsLicitacionesCambios ReqSol = new ClsLicitacionesCambios();
                var result = ReqSol.GenerarActaAdjudicacionProveedores(pIdLic);
                if (result.obeLicitaciones)
                {
                    var licitacion = ReqSol.getLicitacion(pIdLic);
                    licitacion.IdEstatusLicitacion = 60;
                    ReqSol.editLicitacion(licitacion);
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, mensaje= result.errMessage }, JsonRequestBehavior.AllowGet);
                }
                
                
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }

}
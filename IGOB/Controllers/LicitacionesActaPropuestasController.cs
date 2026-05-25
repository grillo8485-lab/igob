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
    public class LicitacionesActaPropuestasController : ValidaSession
    {
        // GET: LicitacionesActaPropuestas
        public ActionResult Index(int pIdLic=0)
        {
            ClsLicitacionesCambios ReqSol = new ClsLicitacionesCambios();
            ViewBag.Licitacion = ReqSol.getLicitacion(pIdLic);

            //obtenemos los datos nesarios
            brLicitacionesActaPropuesta Lic = new brLicitacionesActaPropuesta();

            //obtenemos los datos de licitacion
            beLicitacionesActaPropuesta obeLic = Lic.traerLicitaciones_x_IdLicitacion_ActaApertura(pIdLic);

            //obtenemos los datos de propuestas
            List<beLicitacionesActaPropuesta> ListaPropuestas = Lic.traerPropuestasTecnicaEconomica_x_IdLicitacion_ActaApertura(pIdLic);


            ViewBag.pIdLic = pIdLic;

            ViewBag.FolioLicitacion = obeLic.Titulo;

            return View(ListaPropuestas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ImprimirSolicitud(int pIdLic)
        {
            try
            {
                ClsLicitacionesImprimirActaPropuestas ReqSol = new ClsLicitacionesImprimirActaPropuestas(Server.MapPath("~/Files/Reportes/"), Server.MapPath("~/Files/Plantillas/"));

                //obtenemos el gobierno
                var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                int IdGobierno = usuario.id5;

                string Archivo = ReqSol.ImprimeArchivo(pIdLic, IdGobierno);

                return Json(new { success = true, Descarga = Archivo }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveGenerarPublicarPropuestaTecnicaEconomica(int pIdLic)
        {
            try
            {
                ClsLicitacionesCambios ReqSol = new ClsLicitacionesCambios();
                var licitacion = ReqSol.getLicitacion(pIdLic);
                licitacion.IdEstatusLicitacion = 40;
                ReqSol.editLicitacion(licitacion);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
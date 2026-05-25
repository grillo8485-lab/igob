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
    public class LicitacionesAclaracionDudasController : ValidaSession
    {
        // GET: LicitacionesAclaracionDudas
        public ActionResult Index(int pIdLic = 0)
        {
            ClsLicitacionesCambios ReqSol = new ClsLicitacionesCambios();
            ViewBag.Licitacion = ReqSol.getLicitacion(pIdLic);
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ViewBag.IdPerfil = b.id;
            //obtenemos los datos nesarios
            brLicitacionesAclaracionDudas Lic = new brLicitacionesAclaracionDudas();

            //obtenemos los datos de licitacion
            beLicitacionesAclaracionDudas obeLic = Lic.traerLicitaciones_x_IdLicitacion_AclaracionDudas(pIdLic);

            //obtenemos los datos de preguntas
            List<beLicitacionesAclaracionDudas> ListaPreguntas = Lic.traerProveedoresPreguntas_x_IdLicitacion_AclaracionDudas(pIdLic);
                        
            // = ListaPreguntas.GroupBy(u => u.IdProveedorRqInvitacion).Select(grp => grp.ToList()).ToList().FirstOrDefault();

            

            List<beLicitacionesAclaracionDudas> ListaInvitacion = new List<beLicitacionesAclaracionDudas>();

            //iniciamos el diferenciador
            int Invitacion = 0;
            foreach (beLicitacionesAclaracionDudas Pre in ListaPreguntas)
            {
                if (Pre.IdProveedorRqInvitacion != Invitacion)
                {
                    ListaInvitacion.Add(new beLicitacionesAclaracionDudas() { RazonSocial = Pre.RazonSocial, RequisicionFolio = Pre.RequisicionFolio, Partida = Pre.Partida, Dependencia = Pre.Dependencia, IdProveedorRqInvitacion = Pre.IdProveedorRqInvitacion });
                    Invitacion = Pre.IdProveedorRqInvitacion;
                }                
            }

            ViewBag.ListaInvitacion = ListaInvitacion;

            ViewBag.ListaPreguntas = ListaPreguntas;

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
                ClsLicitacionesImprimirAclaracionDudas ReqSol = new ClsLicitacionesImprimirAclaracionDudas(Server.MapPath("~/Files/Reportes/"), Server.MapPath("~/Files/Plantillas/"));

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
        public JsonResult saveGenerarPublicarActaAclaraciónDudas(int pIdLic)
        {
            try
            {
                ClsLicitacionesCambios ReqSol = new ClsLicitacionesCambios();
                var licitacion = ReqSol.getLicitacion(pIdLic);
                licitacion.IdEstatusLicitacion = 30;
                ReqSol.editLicitacion(licitacion);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
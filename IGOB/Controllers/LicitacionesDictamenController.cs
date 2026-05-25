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
    public class LicitacionesDictamenController : ValidaSession
    {
        // GET: LicitacionesDictamen
        public ActionResult Index(int pIdLic = 0)
        {
            ClsLicitacionesCambios ReqSol = new ClsLicitacionesCambios();
            ViewBag.Licitacion = ReqSol.getLicitacion(pIdLic);

            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ViewBag.IdPerfil = (int)b.id;
            //obtenemos los datos nesarios
            brLicitacionesDictamen Lic = new brLicitacionesDictamen();
            
            //obtenemos los datos de licitacion
            beLicitacionesDictamen obeLic = Lic.traerDictamen_Licitaciones_x_IdLicitacion(pIdLic);

            //obtenemos los datos de propuestas
            List<beLicitacionesDictamen> ListaReq = Lic.traerDictamen_PropuestasTecnicaEconomica_x_IdLicitacion(pIdLic);

            //declaramos las listas que vamos a utilizar por invitación
        
            //Generamos la lista de lotes
            List<beLicitacionesDictamen> ListaLotes = Lic.traerDictamen_PropuestasTecnicaEconomicaLotes_x_IdLicitacion(pIdLic);

            //Generamos la lista de cartas
            List<beLicitacionesDictamen> ListaCartas = Lic.traerDictamen_Cartas_x_IdLicitacion(pIdLic);

            //Generamos la lista de condiciones de entrega
            List<beLicitacionesDictamen> ListaCondicionesEntrega = Lic.traerDictamen_RequisicionesCondicionesEntregasDetalles_x_IdLicitacion(pIdLic);

            //Generamos la lista de clientes
            List<beLicitacionesDictamen> ListaClientes = Lic.traerDictamen_ManifiestoProveedoresClientes_x_IdLicitacion(pIdLic);

            //Generamos la lista de manifiestos
            List<beLicitacionesDictamen> ListaManifiestos = Lic.traerDictamen_ManifiestoProveedoresDeclaratorias_x_IdLicitacion(pIdLic);

            //enviamos las listas

            ViewBag.ListaLotes = ListaLotes;
            ViewBag.ListaCartas = ListaCartas;
            ViewBag.ListaCondicionesEntrega = ListaCondicionesEntrega;
            ViewBag.ListaClientes = ListaClientes;
            ViewBag.ListaManifiestos = ListaManifiestos;

            ViewBag.pIdLic = pIdLic;

            ViewBag.FolioLicitacion = obeLic.Titulo;

            return View(ListaReq);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ImprimirSolicitud(int pIdLic)
        {
            try
            {
                ClsLicitacionesImprimirDictamen ReqSol = new ClsLicitacionesImprimirDictamen(Server.MapPath("~/Files/Reportes/"), Server.MapPath("~/Files/Plantillas/"));

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
        public JsonResult saveGenerarPublicarPropuestaTecnicaEconomica(int pIdLic)
        {
            try
            {
                ClsLicitacionesCambios ReqSol = new ClsLicitacionesCambios();
                beErrorProceso result = ReqSol.GenerarActaDictamen_Publicar_x_IdLicitacion(pIdLic,50);
                if(result.obeLicitaciones)
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet); ;
                }
                else
                {
                    return Json(new { success = false, mensaje = "<div class='alert alert-danger' role='alert' style='margin-bottom: .2rem !important;'><span class='fa fa-exclamation-triangle fa-1x'></span> "+ result.errMessage + " </div>" }, JsonRequestBehavior.AllowGet); ;
                }
                //var licitacion = ReqSol.getLicitacion(pIdLic);
                //licitacion.IdEstatusLicitacion = 50;
                //ReqSol.editLicitacion(licitacion);

                //return Json(new { success = true }, JsonRequestBehavior.AllowGet); ;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
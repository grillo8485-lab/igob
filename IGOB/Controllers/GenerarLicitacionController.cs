using iGob.Entidades;
using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class GenerarLicitacionController : ValidaSession
    {
        // GET: GenerarLiquidacion
        public ActionResult Index()
        {
            ParametrosGenerarLicitacion oParametro = new ParametrosGenerarLicitacion();
            oParametro = (ParametrosGenerarLicitacion)TempData["oParametrosLicitacion"];
            var x = string.Join(",", oParametro.id);
            var f = (ClsGenerica)Session["ClsGenerico"];
            GenerarLicitacion modelLicitacion = new GenerarLicitacion();
            ClsGenerarLicitacion clsLicitacion = new ClsGenerarLicitacion();

            modelLicitacion.IdRequisisicones = x;
            var configuracion = clsLicitacion.set_Get_TempLicitacionRequisiciones(oParametro.id);

            if(configuracion.IdConfiguracionModalidad>0)
            {
                oParametro.IdTiempo = configuracion.IdTiempo;
                oParametro.IdModalidadLicitacion = configuracion.IdConfiguracionModalidad;
                modelLicitacion.oLicitacion = clsLicitacion.getLicitacion(oParametro.IdLicitacion, f, oParametro.IdEjercicioFiscal, oParametro.IdTipoLicitacion, oParametro.IdTiempo, oParametro.IdModalidadLicitacion);
                modelLicitacion.lstLicitacionRequisiciciones = clsLicitacion.getLicitacionRequisiciones(modelLicitacion.oLicitacion.IdLicitacion, oParametro.id, (int)f.id2);
                modelLicitacion.oLicitacion = clsLicitacion.getLicitacion(modelLicitacion.oLicitacion.IdLicitacion, f, oParametro.IdEjercicioFiscal, oParametro.IdTipoLicitacion, oParametro.IdTiempo, oParametro.IdModalidadLicitacion);
                modelLicitacion.lstEjerccioFiscal = new SelectList(clsLicitacion.getAllEjercicioFiscal(), "IdEjercicioFiscal", "Ejercicio", oParametro.IdEjercicioFiscal);
                modelLicitacion.lstNumeroUnidadLicitatotia = new SelectList(clsLicitacion.getAllUnidadesLicitadoras(f.id4), "IdUnidadLicitadora", "UnidadLicitadora", modelLicitacion.oLicitacion.IdUnidadLicitadora);
                modelLicitacion.lstTiempos = new SelectList(clsLicitacion.getAllTiempos(), "IdTiempo", "Tiempo", modelLicitacion.oLicitacion.IdTiempo);

                if (oParametro.IdLicitacion == 0)
                {
                    //IdEjercicioFiscal = 1 & IdLicitacion = 0 & id = 1142
                    oParametro.IdLicitacion = modelLicitacion.oLicitacion.IdLicitacion;
                    TempData["oParametrosLicitacion"] = oParametro;
                    return Redirect("/GenerarLicitacion/Index");// + list + "&IdLicitacion=" + modelLicitacion.oLicitacion.IdLicitacion.ToString()+ "&IdEjercicioFiscal" + IdEjercicioFiscal.ToString());
                                                                                                                                                                     //return RedirectToAction("Index", "GenerarLiquidacion", new { @id = list, @IdLicitacion = modelLicitacion.oLicitacion.IdLicitacion, @IdEjercicioFiscal = IdEjercicioFiscal });
                }
                TempData["oParametrosLicitacion"] = oParametro;
                TempData["ErrorConfiguracionLicitacion"] = "";
                return View(modelLicitacion);
            }
            else
            {
                TempData["oParametrosLicitacion"] = oParametro;
                TempData["ErrorConfiguracionLicitacion"] = "Las requisiciones seleccionadas, no arrojaron ninguna configuración, favor de verificar los montos";
                return RedirectToAction("index", "ListadoLicitaciones");
            }
            
        }
        List<T> CreateList<T>(params T[] values)
        {
            return new List<T>(values);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult updateDates(beLicitaciones data)
        {
            ParametrosGenerarLicitacion oParametro = new ParametrosGenerarLicitacion();
            oParametro = (ParametrosGenerarLicitacion)TempData["oParametrosLicitacion"];
            try
            {
                
                var f = (ClsGenerica)Session["ClsGenerico"];
                GenerarLicitacion modelLicitacion = new GenerarLicitacion();
                ClsGenerarLicitacion clsLicitacion = new ClsGenerarLicitacion();
                modelLicitacion.oLicitacion = clsLicitacion.updateLicitacion(data, f.id5, oParametro.IdTipoLicitacion, oParametro.IdTiempo, oParametro.IdModalidadLicitacion);
                TempData["oParametrosLicitacion"] = oParametro;
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                TempData["oParametrosLicitacion"] = oParametro;
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult publicar(beLicitaciones data)
        {
            try
            {

                var f = (ClsGenerica)Session["ClsGenerico"];
                

                if (TempData["keyAcceso"] == null)
                {
                    TempData.Remove("keyAcceso");
                    return Json("<span class='fa fa-exclamation-triangle fa-1x'></span><strong>Debe intorducir token antes de poder guardar.</strong>", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (TempData["keyAcceso"].ToString().Trim() != f.string6.Trim())
                    {
                        TempData.Remove("keyAcceso");
                        return Json("<span class='fa fa-exclamation-triangle fa-1x'></span><strong>Debe intorducir token antes de poder guardar.</strong>", JsonRequestBehavior.AllowGet);
                    }
                }
                GenerarLicitacion modelLicitacion = new GenerarLicitacion();
                ClsGenerarLicitacion clsLicitacion = new ClsGenerarLicitacion();
                clsLicitacion.publicar(data);
                var a=clsLicitacion.getLicitacion_x_IdLicitacion(data.IdLicitacion);
                return Json(new { success = true, objeto=a }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ImprimirBases(int pIdLic)
        {
            try
            {
                ClsLicitacionesImprimirBases ReqSol = new ClsLicitacionesImprimirBases(Server.MapPath("~/Files/Reportes/"), Server.MapPath("~/Files/Plantillas/"));

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
        public JsonResult ImprimirConvocatoria(int pIdLic)
        {
            try
            {
                ClsLicitacionesImprimirConvocatoria ReqSol = new ClsLicitacionesImprimirConvocatoria(Server.MapPath("~/Files/Reportes/"), Server.MapPath("~/Files/Plantillas/"));

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

        public ActionResult CedulaProgramacion(int pIdLic)
        {
            ClsImprimirCedulaProgramacion Print = new ClsImprimirCedulaProgramacion();
            byte[] abytes = Print.PrepararReporte(pIdLic);
            return File(abytes, "application/pdf");
        }
    }
}
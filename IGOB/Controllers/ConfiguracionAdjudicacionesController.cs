using System;
using System.Linq;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;

namespace IGOB.Controllers
{
    public class ConfiguracionAdjudicacionesController : ValidaSession
    {

        brConfiguracionModalidadTipoProceso modalidad = new brConfiguracionModalidadTipoProceso();
        // GET: ConfiguracionAdjudicaciones
        public ActionResult Index()
        {
            var adj= modalidad.listarTodos_ConfiguracionModalidadTipoProceso().Where(x => x.IdTipoProceso == 2);
            ViewBag.MontoMinimo = adj.Where(x=>x.IdModalidadLicitacion==5).Select( x => x.MontoMinimo).FirstOrDefault();
            ViewBag.MontoMinimo2 = adj.Where(x => x.IdModalidadLicitacion == 6).Select(x => x.MontoMinimo).FirstOrDefault();
            ViewBag.MontoMaximo = adj.Where(x => x.IdModalidadLicitacion == 5).Select(x => x.MontoMaximo).FirstOrDefault();
            ViewBag.MontoMaximo2 = adj.Where(x => x.IdModalidadLicitacion == 6).Select(x => x.MontoMaximo).FirstOrDefault();
            ViewBag.IdConfiguracionModalidadTipoProceso = adj.Select(x => x.IdConfiguracionModalidadTipoProceso).FirstOrDefault();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ConfigurarDirecta(beConfiguracionModalidadTipoProceso configuracionModalidadTipoProceso){
            try
            {
                var getTipoAdjudicacion = modalidad.traerConfiguracionModalidadTipoProceso_x_IdConfiguracionModalidadTipoProceso(configuracionModalidadTipoProceso.IdConfiguracionModalidadTipoProceso);

                if (configuracionModalidadTipoProceso.IdModalidadLicitacion == 5)
                {
                    if (configuracionModalidadTipoProceso.MontoMinimo >= configuracionModalidadTipoProceso.MontoMaximo)
                    {
                        return Json(new { success = false, m = "Verifique las cantidades asignadas" }, JsonRequestBehavior.AllowGet);
                    }
                    getTipoAdjudicacion.MontoMinimo = configuracionModalidadTipoProceso.MontoMinimo;
                    getTipoAdjudicacion.MontoMaximo = configuracionModalidadTipoProceso.MontoMaximo;

                    modalidad.actualizarConfiguracionModalidadTipoProceso(getTipoAdjudicacion);

                    return Json(new { success = true, m = "Se modificó la configuración correctamente" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { success = false, m = "No se pudo completar la acción" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, m = "No se pudo completar la acción", e = ex.Message}, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ConfigurarMayor(beConfiguracionModalidadTipoProceso configuracionModalidadTipoProceso)
        {
            try
            {
                var getTipoAdjudicacion = modalidad.traerConfiguracionModalidadTipoProceso_x_IdConfiguracionModalidadTipoProceso(configuracionModalidadTipoProceso.IdConfiguracionModalidadTipoProceso);

                if (configuracionModalidadTipoProceso.IdModalidadLicitacion == 6)
                {
                    if (configuracionModalidadTipoProceso.MontoMinimo >= configuracionModalidadTipoProceso.MontoMaximo)
                    {
                        return Json(new { success = false, m = "Verifique las cantidades asignadas" }, JsonRequestBehavior.AllowGet);
                    }
                    getTipoAdjudicacion.MontoMinimo = configuracionModalidadTipoProceso.MontoMinimo;
                    getTipoAdjudicacion.MontoMaximo = configuracionModalidadTipoProceso.MontoMaximo;

                    modalidad.actualizarConfiguracionModalidadTipoProceso(getTipoAdjudicacion);

                    return Json(new { success = true, m = "Se modificó la configuración correctamente" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { success = false, m = "No se pudo completar la acción" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, m = "No se pudo completar la acción", e = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
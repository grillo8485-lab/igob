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
    public class ConfiguracionFirmantesModalidadesController : Controller
    {
        // GET: ConfiguracionFirmantesModalidades
        public ActionResult Index(int IdModalidadLicitacion=0)
        {
            ClsConfiguracionFirmantesModalidades configuracion = new ClsConfiguracionFirmantesModalidades();
            ConfiguracionFirmantesModalidades conf = new ConfiguracionFirmantesModalidades();
            if(IdModalidadLicitacion!=0)
            conf.lst= configuracion.getConfiguracionFirmantesModalidades(IdModalidadLicitacion);
            //conf.lstModalidades = configuracion.getAllModalidadesLicitaciones();
            conf.lstModalidades = new SelectList(configuracion.getAllModalidadesLicitaciones(), "IdModalidadLicitacion", "ModalidadLicitacion ", IdModalidadLicitacion);
            return View(conf);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveConfiguracionFirmante(beConfiguracionFirmatesPedidos objeto)
        {
            try
            {
                ClsConfiguracionFirmantesModalidades configuracion = new ClsConfiguracionFirmantesModalidades();
                var f = (ClsGenerica)Session["ClsGenerico"];
                if (objeto.Activo)
                {
                    var lst = configuracion.getConfiguracionFirmantesModalidades(objeto.IdModalidadLicitacion);
                    var maximo = lst.Max(s => s.Ordenamiento);
                    objeto.Ordenamiento = maximo + 1;
                    objeto.IdGobierno = f.id5;
                    var a = configuracion.getConfiguracionModalidadTipoProceso_x_IdModalidadLicitacion(objeto.IdModalidadLicitacion);
                    objeto.IdTipoProceso = a.IdTipoProceso;
                    configuracion.saveConfiguracionModalidadFirmante(objeto);
                }
                else
                {
                    configuracion.deleteConfiguracionModalidadFirmante(objeto.IdConfigFirmantePedido);
                }

                configuracion.procesarOrdenamiento(objeto.IdModalidadLicitacion);

                return Json(new { success = true}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public JsonResult getModalidadLicitacion(int IdModalidadLicitacion)
        //{
        //    try
        //    {
        //        ClsConfiguracionFirmantesModalidades configuracion = new ClsConfiguracionFirmantesModalidades();
        //        ConfiguracionFirmantesModalidades conf = new ConfiguracionFirmantesModalidades();
        //        conf.lst= configuracion.getConfiguracionFirmantesModalidades(IdModalidadLicitacion);
        //        return Json(new { success = true, objeto = b }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
        //    }

        //}
    }
}
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
    public class ConfiguracionesModalidadesController : ValidaSession
    {
        // GET: ConfiguracionesModalidades
        public ActionResult Index()
        {
            var IdGobierno = (int)TempData["IdGobierno"];
            ClsConfiguracionesModalidades ConfiguracionesModalidades = new ClsConfiguracionesModalidades();
            ConfiguracionesModalidades model = new ConfiguracionesModalidades();
            model.lstConfiguracionesModalidades = ConfiguracionesModalidades.getAllConfiguracionesModalidade().Where(s=> s.IdGobierno == IdGobierno).ToList();
            ViewBag.lstTiposLicitaciones = new SelectList(ConfiguracionesModalidades.getAllTiposLicitaciones(), "IdTipoLicitacion", "TipoLicitacion");
            ViewBag.lstTiempos = new SelectList(ConfiguracionesModalidades.getAllTiempos(), "IdTiempo", "Tiempo");
            ViewBag.lstModalidadesLicitaciones = new SelectList(ConfiguracionesModalidades.getAllModalidadesLicitaciones(), "IdModalidadLicitacion", "ModalidadLicitacion");
            TempData["IdGobierno"] = IdGobierno;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveConfiguracionesModalidades(beConfiguracionesModalidades oConfiguracionesModalidades)
        {
            try
            {
                var IdGobierno = (int)TempData["IdGobierno"];
                ClsConfiguracionesModalidades ConfiguracionesModalidades = new ClsConfiguracionesModalidades();
                oConfiguracionesModalidades.IdGobierno = IdGobierno;
                oConfiguracionesModalidades.NomenclaturaProveedores = "";
                oConfiguracionesModalidades.NomenclaturaPreguntas = "";
                ConfiguracionesModalidades.saveConfiguracionesModalidades(oConfiguracionesModalidades);
                var lst_ = ConfiguracionesModalidades.getAllConfiguracionesModalidade();
                TempData["IdGobierno"] = IdGobierno;
                return Json(new { success = true, lst= lst_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveEditConfiguracionesModalidades(beConfiguracionesModalidades oConfiguracionesModalidades)
        {
            try
            {
                var IdGobierno = (int)TempData["IdGobierno"];
                ClsConfiguracionesModalidades ConfiguracionesModalidades = new ClsConfiguracionesModalidades();
                oConfiguracionesModalidades.IdGobierno = IdGobierno;
                oConfiguracionesModalidades.NomenclaturaProveedores = "";
                oConfiguracionesModalidades.NomenclaturaPreguntas = "";
                ConfiguracionesModalidades.saveEditConfiguracionesModalidades(oConfiguracionesModalidades);
                var lst_ = ConfiguracionesModalidades.getAllConfiguracionesModalidade().Where(s => s.IdGobierno == IdGobierno).ToList();
                
                TempData["IdGobierno"] = IdGobierno;
                return Json(new { success = true, lst = lst_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult deleteConfiguracionesModalidades(int IdConfiguracionModalidad)
        {
            try
            {
                var IdGobierno = (int)TempData["IdGobierno"];
                ClsConfiguracionesModalidades ConfiguracionesModalidades = new ClsConfiguracionesModalidades();
                ConfiguracionesModalidades.deleteConfiguracionesModalidades(IdConfiguracionModalidad);
                var lst_ = ConfiguracionesModalidades.getAllConfiguracionesModalidade().Where(s => s.IdGobierno == IdGobierno).ToList();
                TempData["IdGobierno"] = IdGobierno;
                return Json(new { success = true, lst = lst_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult getAllModelo(int IdConfiguracionModalidad)
        {
            try
            {
                ClsConfiguracionesModalidades ConfiguracionesModalidades = new ClsConfiguracionesModalidades();

                ConfiguracionesModalidades model = new ConfiguracionesModalidades();
                model.lstConfiguracionesModalidades = ConfiguracionesModalidades.getAllConfiguracionesModalidade();
                if (IdConfiguracionModalidad != 0)
                {
                    model.oConfiguracionesModalidades = ConfiguracionesModalidades.getConfiguracionesModalidades(IdConfiguracionModalidad);
                }
                ViewBag.lstTiposLicitaciones = new SelectList(ConfiguracionesModalidades.getAllTiposLicitaciones(), "IdTipoLicitacion", "TipoLicitacion", (IdConfiguracionModalidad == 0 ? "" : model.oConfiguracionesModalidades.IdTipoLicitacion.ToString()));
                ViewBag.lstTiempos = new SelectList(ConfiguracionesModalidades.getAllTiempos(), "IdTiempo", "Tiempo", (IdConfiguracionModalidad == 0 ? "" : model.oConfiguracionesModalidades.IdTiempo.ToString()));
                ViewBag.lstModalidadesLicitaciones = new SelectList(ConfiguracionesModalidades.getAllModalidadesLicitaciones(), "IdModalidadLicitacion", "ModalidadLicitacion", (IdConfiguracionModalidad == 0 ? "" : model.oConfiguracionesModalidades.IdModalidadLicitacion.ToString()));

                return PartialView("ConfiguracionesModalidades", model);
            }
            catch (Exception ex)
            {
                return PartialView();
            }

        }
       
    }
}
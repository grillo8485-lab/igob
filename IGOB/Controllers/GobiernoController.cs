using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;

namespace IGOB.Controllers
{
    public class GobiernoController : ValidaSession
    {
        private brGobiernoLogoBanner ObrGobiernoLogoBanner = new brGobiernoLogoBanner();
        private brGobierno ObrGobierno = new brGobierno();
        private beGobiernoLogoBanner logobanner = new beGobiernoLogoBanner();
        // GET: Gobierno

        public ActionResult Index()
        {
            var f = (ClsGenerica)Session["ClsGenerico"];

            brGobiernoLogoBanner ObrGobiernoLogoBanner = new brGobiernoLogoBanner();
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            List<beGobierno> listGob = ObrGobierno.listarTodos_Gobierno().Where(s => s.IdGobierno == f.id5).ToList();//.Where(x=>x.IdGobierno==b.id5).ToList();
            foreach(var item in listGob)
            {
                var idgoblogobanner =  ObrGobiernoLogoBanner.listarTodos_GobiernoLogoBanner().Where(x => x.IdGobierno == item.IdGobierno).FirstOrDefault();
                if (idgoblogobanner != null)
                {
                    item.Banner = idgoblogobanner.Banner;
                    item.Logo = idgoblogobanner.Logo;
                }
            }
            return View(listGob);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beGobierno gob)
        {
            var Result = "";
            var suc = false;
            try
            { 
                var result = ObrGobierno.guardarGobierno(gob);
                logobanner.IdGobierno = result;
                logobanner.IdLogoBanner = 0;
                logobanner.Logo = gob.Logo;
                logobanner.Banner = gob.Banner;
                var save = ObrGobiernoLogoBanner.guardarGobiernoLogoBanner(logobanner);
                Result = (result>0 && save>0) ? "Se Agrego Correctamente" : "No se Pudo Agregar";
                suc = (result>0 && save>0) ? true : false;
            }catch(Exception e)
            {
                Result = gob.Gobierno + " No se Pudo Agregar " + e.Message;
            }
            return Json(new { success = suc, message = Result }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beGobierno gob)
        {
            var Result = "";
            var suc = false;
            try
            {
                var exist = ObrGobiernoLogoBanner.listarTodos_GobiernoLogoBanner().Where(x => x.IdGobierno == gob.IdGobierno).FirstOrDefault();
                if (exist != null)
                {
                    logobanner.IdGobierno = gob.IdGobierno;
                    logobanner.IdLogoBanner = exist.IdLogoBanner;
                    logobanner.Logo = gob.Logo;
                    logobanner.Banner = gob.Banner;
                }
                else
                {
                    logobanner.IdGobierno = gob.IdGobierno;
                    logobanner.IdLogoBanner = 0;
                    logobanner.Logo = gob.Logo;
                    logobanner.Banner = gob.Banner;
                }
                var save = ObrGobiernoLogoBanner.actualizarGobiernoLogoBanner(logobanner);
                
                var result = ObrGobierno.actualizarGobierno(gob);
                if (result == 0)
                {
                    Result = ((result == 0 && save > 0)|| (result == 0 && save == 0)) ? "Se Agrego Correctamente" : "No se Pudo Agregar";
                    suc = ((result == 0 && save > 0) || (result == 0 && save == 0)) ? true : false;
                }
                else
                {
                    Result = gob.Gobierno + " No se Pudo Agregar";
                }
            }catch(Exception e)
            {
                Result = gob.Gobierno + " No se Pudo Agregar "+e.Message;
            }
            return Json(new { success = suc, message = Result }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            var Result = "";
            var result = ObrGobierno.eliminarGobierno(id);
            Result = "Se elimino correctamente";
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult configuracionModalidadesGobierno(int IdGobierno)//IdGobierno
        {
            TempData["IdGobierno"] = IdGobierno;

            return RedirectToAction("Index", "ConfiguracionesModalidades");
        }
    }
}
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
    public class DependenciasController : ValidaSession
    {
        private brDependencias ObrDependencias = new brDependencias();
        private brEF_Municipios ObrMunicipios = new brEF_Municipios();
        private brGobierno ObrGobierno = new brGobierno();
        private brEF_EntidadesFederativas ObrEF_EntidadesFederativas = new brEF_EntidadesFederativas();
        // GET: Catalogos/Dependencias
        public ActionResult Index()
        {
            ViewBag.ListGob = new SelectList(ObrGobierno.listarTodos_Gobierno(), "IdGobierno", "Gobierno");
            ViewBag.ListEntidadesFederativas = new SelectList(ObrEF_EntidadesFederativas.listarTodos_EF_EntidadesFederativas(), "ClaveEstado", "Estado");

            return View(ObrDependencias.Listar_Dependencias_GetAll());
        }

        public JsonResult MunicipioById(string id)
        {
            return Json(ObrMunicipios.listarTodos_EF_Municipios().Where(x => x.ClaveEstado == id).ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beDependencias dep)
        {

            if (ModelState.IsValid)
            {
                var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                dep.FechaRegistro = DateTime.Now;
                dep.IdGobierno = (int)c.id5;
                dep.IdUsuarioRegistro = (int)c.id2;
                ObrDependencias.guardarDependencias(dep);
                return Json(new { success = true, m = "Dependencia <strong>" + dep.Dependencia + "</strong> agregada correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = true, m = ModelState.Values.SelectMany(v => v.Errors) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            if (ObrDependencias.traerDependencias_x_IdDependencia(id) != null)
            {
                ObrDependencias.eliminarDependencias(id);
                return Json(new { success = true, m = "Dependencia eliminada correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = true, m = "No se ha podido eliminar" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beDependencias dep)
        {

            if (ObrDependencias.traerDependencias_x_IdDependencia(dep.IdDependencia) != null)
            {
                var c = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                dep.FechaRegistro = DateTime.Now;
                dep.IdGobierno = (int)c.id5;

                ObrDependencias.actualizarDependencias(dep);
                return Json(new { success = true, m = "Dependencia editada correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = true, m = "No se ha podido editar" }, JsonRequestBehavior.AllowGet);

        }
    }
}
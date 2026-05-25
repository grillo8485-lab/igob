using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Models;
using IGOB.Areas.Catalogos.Models;

namespace IGOB.Controllers
{
    public class ProveedoresMenoresController : ValidaSession
    {
        private ClsProvedoresMenores OClsProvMen = new ClsProvedoresMenores();
        private brProveedores ObrProveedores = new brProveedores();

        // GET: ProveedoresMenores
        public ActionResult Index(int id = 0)
        {

            ViewBag.EFList = new SelectList(OClsProvMen.ListEF(), "ClaveEstado", "Estado");
            ViewBag.ActvList = new SelectList(OClsProvMen.ListActE(), "IdActividadEconomica", "Descripcion");
            ViewBag.TRList = new SelectList(OClsProvMen.ListTipRep(), "IdTipoRepresentacion", "TipoRepresentacion");
            ViewBag.ProAcList = new SelectList(OClsProvMen.ListProvAc(), "IdProveedorAccionista", "Nombre");
            //ViewBag.GobList = new SelectList(OClsProvMen.ListGob(), "IdGobierno", "Gobierno");
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ViewBag.gob = b.id5;
            ViewBag.Perfil = (b.id == 3 ? "d-none" : b.id == 2 ? "d-none": "");

            var prov = (b.id == 3 ? 1 : b.id == 2 ? 0 : b.id == 1 ? id : 3 );

            ViewBag.BancList = new SelectList(OClsProvMen.ListBanc(), "IdBanco", "NombreCorto");
            ViewBag.Tipo = ((prov == 1) ? 1 : 0);
            TempData["tipoProv"] = id;
            return View(prov == 1 ? OClsProvMen.ListProvMen(b.id5) : OClsProvMen.ListProvGen(b.id5));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beProveedores prov)
        {
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            prov.IdGobierno = b.id5;
            prov.Sitiooficial = (prov.Sitiooficial == null || prov.Sitiooficial == "") ? "Sitio No disponoble" : prov.Sitiooficial;
            var result = "";
            if (ModelState.IsValid)
            {
                var create = ObrProveedores.guardarProveedores(prov);
                result = "Se agrego correctamente";
            }
            else
            {
                result = "No se pudo agregar";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getProvedores(int id)
        {
            var provemen = ObrProveedores.traerProveedores_x_IdProveedor(id);
            return Json(provemen, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beProveedores prov)
        {
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            prov.IdGobierno = b.id5;
            prov.Sitiooficial = (prov.Sitiooficial == null || prov.Sitiooficial == "") ? "Sitio No disponoble" : prov.Sitiooficial;
            var result = "";
            if (ModelState.IsValid)
            {
                if (ObrProveedores.actualizarProveedores(prov) == 0)
                {
                    result = "Se edito correctamente";
                }
                else
                {
                    result = "No se pudo editar";
                }
            }
            else
            {
                result = "No se pudo editar";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            var result = "";
            var delete = ObrProveedores.eliminarProveedores(id);
            if (delete == 0)
            {
                result = "Se elimino correctamente";
            }
            else
            {
                result = "No se pudo eliminar";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MunicipioById(string id)
        {
            return Json(OClsProvMen.ListMunxId(id), JsonRequestBehavior.AllowGet);
        }

    }
}
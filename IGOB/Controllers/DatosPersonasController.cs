using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.ReglasNegocios;
using iGob.Entidades;
using IGOB.Models;
using IGOB.Areas.Catalogos.Models;

namespace IGOB.Controllers
{
    public class DatosPersonasController : ValidaSession
    {
        private brDatosPersonas ObrDatosPersonas = new brDatosPersonas();
        private ClsDatosPersonas clsDatPer = new ClsDatosPersonas();
        // GET: DatosPersonas
        public ActionResult Index()
        {
            brGobiernoLogoBanner ObrGobiernoLogoBanner = new brGobiernoLogoBanner();
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ViewBag.IdUsuarioRegistro = b.id2;
            ViewBag.EntFedNacimiento = new SelectList(clsDatPer.ListEntFed(), "ClaveEstado", "Estado");
            ViewBag.Dependencia = new SelectList(clsDatPer.ListDependencias(), "IdDependencia", "Dependencia");
            ViewBag.Proveedor = new SelectList(clsDatPer.ListProv(), "IdProveedor", "RazonSocial");
            ViewBag.Estatus = new SelectList(clsDatPer.ListEstatus(), "IdEstatusPersona", "Estatus");
            ViewBag.TipoPersona = new SelectList(clsDatPer.ListTipoPersonas(), "IdTipoPersona", "TipoPersona");
            List<beDatosPersonas> listaPersonas = ObrDatosPersonas.listarTodos_DatosPersonas().ToList();
            return View(listaPersonas);
        }
        [HttpGet]
        public JsonResult GetMunicipios(string claveestado)
        {
            try
            {
                return Json(clsDatPer.ListMunxClaveEst(claveestado), JsonRequestBehavior.AllowGet);
            }catch(Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetColonias(string IdMunicipio)
        {
            try
            {
                return Json(clsDatPer.ListColonias(IdMunicipio), JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetMunicipio_idColonia(string idColonia)
        {
            try
            {
                return Json(((clsDatPer.GetMunicipio_idColonia(idColonia) != null) ? clsDatPer.GetMunicipio_idColonia(idColonia) : "0"), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message,JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beDatosPersonas DatosPersonas)
        {
            try
            {
                var Result = "";
                var suc = false;
                DatosPersonas.FechaRegistro = DateTime.Now;
                DatosPersonas.NoInterior = (DatosPersonas.NoInterior == null || DatosPersonas.NoInterior == "") ? "sin número" : DatosPersonas.NoInterior;
                DatosPersonas.NoExterior = (DatosPersonas.NoExterior == null || DatosPersonas.NoExterior == "") ? "sin número" : DatosPersonas.NoExterior;
                DatosPersonas.EstadoCivil = (DatosPersonas.EstadoCivil == null || DatosPersonas.EstadoCivil == "") ? "N" : DatosPersonas.EstadoCivil;
                DatosPersonas.Sexo = (DatosPersonas.Sexo == null || DatosPersonas.Sexo == "") ? "N" : DatosPersonas.Sexo;
                var datop = ObrDatosPersonas.guardarDatosPersonas(DatosPersonas);
                Result = (datop != 0) ? "Se agrego correctamente la persona" : "No se pudo agregar";
                suc = (datop != 0) ? true : false;
                return Json(new { success = suc, message = Result }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beDatosPersonas DatosPersonas)
        {
            try
            {
                var Result = "";
                var suc = false;
                DatosPersonas.NoInterior = (DatosPersonas.NoInterior == null || DatosPersonas.NoInterior == "") ? "sin número" : DatosPersonas.NoInterior;
                DatosPersonas.NoExterior = (DatosPersonas.NoExterior == null || DatosPersonas.NoExterior == "") ? "sin número" : DatosPersonas.NoExterior;
                DatosPersonas.EstadoCivil = (DatosPersonas.EstadoCivil == null || DatosPersonas.EstadoCivil == "") ? "N" : DatosPersonas.EstadoCivil;
                DatosPersonas.Sexo = (DatosPersonas.Sexo == null || DatosPersonas.Sexo == "") ? "N" : DatosPersonas.Sexo;
                var datop = ObrDatosPersonas.actualizarDatosPersonas(DatosPersonas);
                Result = (datop == 0) ? "Se edito correctamente" : "No se pudo editar";
                suc = (datop == 0) ? true : false;
                return Json(new { success = suc, message = Result }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            try
            {
                var datop = ObrDatosPersonas.eliminarDatosPersonas(id);
                var Result = (datop == 0) ? "Se elimino correctamente" : "No se pudo eliminar";
                var suc = (datop == 0) ? true : false;
                return Json(new { success = suc, message = Result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
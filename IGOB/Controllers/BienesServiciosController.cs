using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;
using IGOB.Models;

namespace IGOB.Controllers
{
    public class BienesServiciosController : ValidaSession
    {
        private brBienesServicios ObrBienesServicios = new brBienesServicios();
        private brTiposProductos ObrTiposProductos = new brTiposProductos();
        private brFamilias ObrFamilias =new brFamilias();
        private brUnidadesMedidas ObrUnidadesMedidas = new brUnidadesMedidas();
        private brCertificaciones ObrCertificaciones = new brCertificaciones();
        private brImpuestos ObrImpuestos = new brImpuestos();
        private brMarcas ObrMarcas = new brMarcas();
        private brTiposMonedas ObrTiposMonedas = new brTiposMonedas();
        private brPartidas ObrPartidas = new brPartidas();
        private brCapitulos ObrCapitulos = new brCapitulos();
        private brModificadorProducto ObrModificadorProducto = new brModificadorProducto();

        // GET: Catalogos/BienesServicios
        public ActionResult Index()
        {
            ClsAdquisicion a = new ClsAdquisicion();

            ViewBag.TPList = new SelectList(ObrTiposProductos.listarTodos_TiposProductos(), "IdTipoProducto", "TipoProducto");
            ViewBag.FamiliasList = new SelectList(ObrFamilias.listarTodos_Familias(), "IdFamilia", "Familia");
            ViewBag.CertList = new SelectList(ObrCertificaciones.listarTodos_Certificaciones(), "IdCertificacion", "Certificacion");
            ViewBag.MarcaList = new SelectList(ObrMarcas.listarTodos_Marcas(), "IdMarca", "Marca");
            ViewBag.TMList = new SelectList(ObrTiposMonedas.listarTodos_TiposMonedas(), "IdTipoMoneda", "Moneda");
            ViewBag.ImpList = new SelectList(ObrImpuestos.listarTodos_Impuestos(), "IdImpuesto", "Descripcion");
            ViewBag.UMList = new SelectList(ObrUnidadesMedidas.listarTodos_UnidadesMedidas(), "IdUnidadMedida", "UnidadMedida");
            ViewBag.capitulosList = new SelectList(a.getAllCapitulos(), "IdCapitulo", "Capitulo");
            ViewBag.capitulosListBuscar = new SelectList(a.getAllCapitulos(), "IdCapitulo", "Capitulo");
            ViewBag.ModificadorList = new SelectList(ObrModificadorProducto.listarTodos_ModificadorProducto(), "IdModificador", "Modificador");

            return View();
        }

        [HttpPost]
        public JsonResult GetAll(int id)
        {
            try
            {
                var jsonResult = Json(new { });
                if (id != 0)
                    jsonResult = Json(new { sucess = true, mensaje = ObrBienesServicios.listarTodos_GetAllBienesServicios_x_IdCapitulo(id) }, JsonRequestBehavior.AllowGet);
                else
                    jsonResult = Json(new { sucess = true, mensaje = ObrBienesServicios.listarTodos_GetAllBienesServicios() }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult getAllPartidas_x_IdCapitulo(int pIdCapitulo)
        {
            try
            {
                ClsAdquisicion adquisicion = new ClsAdquisicion();
                var b = adquisicion.getAllPartidas_x_IdCapitulo(pIdCapitulo);
                return Json(new { success = true, objeto = b }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beBienesServicios bienesServicios)
        {
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

            bienesServicios.Codigo = bienesServicios.Codigo == null ? "0" : bienesServicios.Codigo;
            bienesServicios.ClaveCubs = bienesServicios.ClaveCubs == null ? "0" : bienesServicios.ClaveCubs;
            bienesServicios.IdCertificacion = bienesServicios.IdCertificacion == 0 ? 1 : bienesServicios.IdCertificacion;
            bienesServicios.IdUsuarioRegistro = (int)b.id2;
            //bienesServicios.FechaRegistro = DateTime.Now;
            bienesServicios.FechaActualizacionPrecio = DateTime.Now;
            try
            {
                bienesServicios.FechaRegistro = DateTime.Now;
                var resp = ObrBienesServicios.guardarBienesServicios(bienesServicios);
                ViewBag.Result = bienesServicios.BienServicio + " Agregado correctamente ";
            }
            catch(Exception ex)
            {
                var errors = ex.Message;
                ViewBag.Result = bienesServicios.BienServicio + " No se ha podido agregar";
            }

            return Json(ViewBag.Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            if (ObrBienesServicios.traerBienesServicios_x_IdBienServicio(id) != null)
            {
                ObrBienesServicios.eliminarBienesServicios(id);
                return Json(new { success = true, m = "Eliminado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false, m = "No se ha podido eliminar" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beBienesServicios bienesServicios)
        {
            try
            {
                beBienesServicios bienServicio = ObrBienesServicios.traerBienesServicios_x_IdBienServicio(bienesServicios.IdBienServicio);
                if (bienServicio != null)
                {
                    bienesServicios.FechaActualizacionPrecio = DateTime.Now;
                    ObrBienesServicios.actualizarBienesServicios(bienesServicios);
                    ViewBag.Result = "Editado correctamente";
                }
                else
                {
                    ViewBag.Result = "No se ha podido editar";
                }

                return Json(new { success = false, mensaje = ViewBag.Result }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult getBienServicio(int pIdBienServicio)
        {
            try
            {
                beBienesServicios oBienServicio = new beBienesServicios();
                oBienServicio = ObrBienesServicios.traerBienesServicios_x_IdBienServicio(pIdBienServicio);
                
                ClsAdquisicion a = new ClsAdquisicion();

                ViewBag.TPList = new SelectList(ObrTiposProductos.listarTodos_TiposProductos(), "IdTipoProducto", "TipoProducto", oBienServicio.IdTipoProducto);
                ViewBag.FamiliasList = new SelectList(ObrFamilias.listarTodos_Familias(), "IdFamilia", "Familia", oBienServicio.IdFamilia);
                ViewBag.CertList = new SelectList(ObrCertificaciones.listarTodos_Certificaciones(), "IdCertificacion", "Certificacion", oBienServicio.IdCertificacion);
                ViewBag.MarcaList = new SelectList(ObrMarcas.listarTodos_Marcas(), "IdMarca", "Marca", oBienServicio.IdMarca);
                ViewBag.TMList = new SelectList(ObrTiposMonedas.listarTodos_TiposMonedas(), "IdTipoMoneda", "Moneda", oBienServicio.IdTipoMoneda);
                ViewBag.ImpList = new SelectList(ObrImpuestos.listarTodos_Impuestos(), "IdImpuesto", "Descripcion", oBienServicio.IdImpuesto);
                ViewBag.UMList = new SelectList(ObrUnidadesMedidas.listarTodos_UnidadesMedidas(), "IdUnidadMedida", "UnidadMedida", oBienServicio.IdUnidadMedida);

                var partida = (new brPartidas()).traerPartidas_x_IdPartida(oBienServicio.IdPartida);
                
                ViewBag.partidaLst = new SelectList(a.getAllPartidas_x_IdCapitulo(partida.IdCapitulo), "IdPartida", "Partida", oBienServicio.IdPartida);
                ViewBag.ModificadorList = new SelectList(ObrModificadorProducto.listarTodos_ModificadorProducto(), "IdModificador", "Modificador", oBienServicio.IdModificador);
                ViewBag.capitulosList = new SelectList(a.getAllCapitulos(), "IdCapitulo", "Capitulo", partida.IdCapitulo);

                return PartialView("BienServicio", oBienServicio);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult getAllCodigoScian(string term)
        {
            try
            {
                brCategoriasScian scian = new brCategoriasScian();
                var lst_ = scian.listarTodos_CategoriasScian_x_Descripcion(term);
                return Json(new { success = true, data = lst_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getCodigoScian(int pCodigoScian)
        {
            try
            {
                brCategoriasScian scian = new brCategoriasScian();
                var lst_ = scian.traerCategoriasScian_x_CodigoScian(pCodigoScian);
                return Json(new { success = true, data = lst_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}
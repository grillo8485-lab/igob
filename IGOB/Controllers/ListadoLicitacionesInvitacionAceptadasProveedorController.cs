using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class ListadoLicitacionesInvitacionAceptadasProveedorController : ValidaSession
    {
        ClsListadoLicitacionesInvitacionAceptadasProveedor aceptadasProveedor = new ClsListadoLicitacionesInvitacionAceptadasProveedor();
        ListadoLicitacionesInvitacionAceptadasProveedor model = new ListadoLicitacionesInvitacionAceptadasProveedor();
        // GET: ListadoLicitacionesInvitacionAceptadasProveedor
        public ActionResult Index()
        {
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            model.IdPerfil = (int)b.id;
            switch (model.IdPerfil)
            {
                case 8:
                    model.lstInvitacionesAcptadasProveedor = aceptadasProveedor.getAllInvitacionesAceptadasProveedor(b.id6);
                    break;
                case 7:
                    model.lstInvitacionesAcptadasProveedor = aceptadasProveedor.getAllRevisarPagosProveedor((int)b.id2);
                    break;
                case 3:
                case 4:
                    model.lstInvitacionesAcptadasProveedor = aceptadasProveedor.getAllRevisarRespuestaSolictanteDependencia(b.id4);
                    break;
                case 5:
                    model.lstInvitacionesAcptadasProveedor = aceptadasProveedor.getAllDirectorAdquisiciones();
                    break;
            }
           
            return View(model);
        }
        [HttpGet]
        public ActionResult licitacionRequisionTecnica(int Id)//IdLicitacion
        {
            TempData["TituloPorProceso"] = "";
            TempData["IdLicitacion"] = 0;
            TempData["IdInvitacion"] = Id;
            TempData["IdTipoProceso"] = 1;
            return RedirectToAction("Index", "ListadoRequisicionLicitacion");
        }
        [HttpGet]
        public ActionResult licitacionRequisionEconomica(int Id)//IdLicitacion
        {
            TempData["TituloPorProceso"] = "";
            TempData["IdLicitacion"] = 0;
            TempData["IdInvitacion"] = Id;
            TempData["IdTipoProceso"] = 2;
            return RedirectToAction("Index", "ListadoRequisicionLicitacion");
        }
        [HttpGet]
        public ActionResult preguntas(int Id)//IdLicitacion
        {
            TempData["TituloPorProceso"] = "";
            TempData["IdLicitacion"] = 0;
            TempData["IdInvitacion"] = Id;
            TempData["IdTipoProceso"] = 0;
            return RedirectToAction("Index", "ListadoRequisicionLicitacion");
        }
        [HttpGet]
        public ActionResult setRepuestas(int Id)//IdLicitacion
        {
            TempData["TituloPorProceso"] = "";
            TempData["IdLicitacion"] = Id;
            TempData["IdInvitacion"] = 0;
            TempData["IdTipoProceso"] = 1;
            return RedirectToAction("Index", "ListadoRequisicionLicitacion", new { id = Id });
        }
        //revisor
        [HttpGet]
        public ActionResult licitacionRequisionTecnicaRevisor(int Id)//IdLicitacion
        {
            TempData["TituloPorProceso"] = "";
            TempData["IdInvitacion"] = 0;
            TempData["IdLicitacion"] = Id;
            TempData["IdTipoProceso"] = 3;
            return RedirectToAction("Index", "ListadoRequisicionLicitacion");
        }
        [HttpGet]
        public ActionResult licitacionRequisionEconomicaRevisor(int Id)//IdLicitacion
        {
            TempData["TituloPorProceso"] = "";
            TempData["IdInvitacion"] = 0;
            TempData["IdLicitacion"] = Id;
            TempData["IdTipoProceso"] = 4;
            return RedirectToAction("Index", "ListadoRequisicionLicitacion");
        }
        [HttpGet]
        public ActionResult licitacionRequisionDictamenPropuestaTecnica(int Id)//IdLicitacion
        {
            TempData["TituloPorProceso"] = "";
            TempData["IdLicitacion"] = Id;
            TempData["IdInvitacion"] = 0;
            TempData["IdTipoProceso"] = 5;
            return RedirectToAction("Index", "ListadoRequisicionLicitacion");
        }
        [HttpGet]
        public ActionResult licitacionRequisionRespuestas(int IdLicitacion, int IdProceso)//IdLicitacion
        {
            TempData["TituloPorProceso"] = "";
            TempData["IdLicitacion"] = IdLicitacion;
            TempData["IdInvitacion"] = 0;
            TempData["IdTipoProceso"] = IdProceso;
            return RedirectToAction("Index", "ListadoRequisicionLicitacion");
        }
        [HttpGet]
        public ActionResult licitacionRequisionDictamenPropuestaTecnicaRevisor(int Id)//IdLicitacion
        {
            TempData["TituloPorProceso"] = "";
            TempData["IdLicitacion"] = Id;
            TempData["IdInvitacion"] = 0;
            TempData["IdTipoProceso"] = 6;
            return RedirectToAction("Index", "ListadoRequisicionLicitacion");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult saveGenerarPedido(int pIdLicitacion)//IdLicitacion
        {
            try
            {
                ClsLicitacionesCambios ReqSol = new ClsLicitacionesCambios();
                var result = ReqSol.GenerarPedido_x_IdLicitacion(pIdLicitacion);
                if (result.obeLicitaciones)
                {
                    var licitacion = ReqSol.getLicitacion(pIdLicitacion);
                    licitacion.IdEstatusLicitacion = 100;
                    ReqSol.editLicitacion(licitacion);
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, mensaje = result.errMessage }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult liberarPedidoRequisicion(int IdLicitacion)//IdLicitacion
        {
            TempData["TituloPorProceso"] = "";
            TempData["IdLicitacion"] = IdLicitacion;
            TempData["IdInvitacion"] = 0;
            TempData["IdTipoProceso"] = 100;
            return RedirectToAction("Index", "ListadoRequisicionLicitacion");
        }
        [HttpGet]
        
        public ActionResult ImprimirBases(int pIdLic)
        {
            try
            {
                ClsLicitacionesImprimirBases ReqSol = new ClsLicitacionesImprimirBases(Server.MapPath("~/Files/Reportes/"), Server.MapPath("~/Files/Plantillas/"));

                //obtenemos el gobierno
                var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                int IdGobierno = usuario.id5;

                string Archivo = ReqSol.ImprimeArchivo(pIdLic, IdGobierno);

                
                string filename = Server.MapPath("~/Files/Reportes/" + Archivo);
                byte[] filedata = System.IO.File.ReadAllBytes(filename);
                string contentType = MimeMapping.GetMimeMapping(filename);

                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = filename,
                    Inline = true,
                };

                Response.AppendHeader("Content-Disposition", cd.ToString());

                return File(filedata, contentType);
            }
            catch (Exception ex)
            {
                //return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult ImprimirConvocatoria(int pIdLic)
        {
            try
            {
                ClsLicitacionesImprimirConvocatoria ReqSol = new ClsLicitacionesImprimirConvocatoria(Server.MapPath("~/Files/Reportes/"), Server.MapPath("~/Files/Plantillas/"));

                //obtenemos el gobierno
                var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                int IdGobierno = usuario.id5;

                string Archivo = ReqSol.ImprimeArchivo(pIdLic, IdGobierno);
                string filename = Server.MapPath("~/Files/Reportes/"+ Archivo);
                byte[] filedata = System.IO.File.ReadAllBytes(filename);
                string contentType = MimeMapping.GetMimeMapping(filename);

                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = filename,
                    Inline = true,
                };

                Response.AppendHeader("Content-Disposition", cd.ToString());

                return File(filedata, contentType);
            }
            catch (Exception ex)
            {
                //return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult DescargarActaPropuestaTecnicaEconomica(int pIdLic)
        {
            try
            {
                ClsLicitacionesImprimirActaPropuestas ReqSol = new ClsLicitacionesImprimirActaPropuestas(Server.MapPath("~/Files/Reportes/"), Server.MapPath("~/Files/Plantillas/"));

                //obtenemos el gobierno
                var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                int IdGobierno = usuario.id5;

                string Archivo = ReqSol.ImprimeArchivo(pIdLic, IdGobierno);
                string filename = Server.MapPath("~/Files/Reportes/" + Archivo);
                byte[] filedata = System.IO.File.ReadAllBytes(filename);
                string contentType = MimeMapping.GetMimeMapping(filename);

                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = filename,
                    Inline = true,
                };

                Response.AppendHeader("Content-Disposition", cd.ToString());

                return File(filedata, contentType);
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult ActaFallo(int pIdLic)
        {
            try
            {
                ClsLicitacionesImprimirActaFallo ReqSol = new ClsLicitacionesImprimirActaFallo(Server.MapPath("~/Files/Reportes/"), Server.MapPath("~/Files/Plantillas/"));

                //obtenemos el gobierno
                var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                int IdGobierno = usuario.id5;

                string Archivo = ReqSol.ImprimeArchivo(pIdLic, IdGobierno);
                string filename = Server.MapPath("~/Files/Reportes/" + Archivo);
                byte[] filedata = System.IO.File.ReadAllBytes(filename);
                string contentType = MimeMapping.GetMimeMapping(filename);

                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = filename,
                    Inline = true,
                };

                Response.AppendHeader("Content-Disposition", cd.ToString());

                return File(filedata, contentType);
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        [HttpGet]

        public ActionResult ImprimirDictamen(int pIdLic)
        {
            try
            {
                ClsLicitacionesImprimirDictamen ReqSol = new ClsLicitacionesImprimirDictamen(Server.MapPath("~/Files/Reportes/"), Server.MapPath("~/Files/Plantillas/"));

                //obtenemos el gobierno
                var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
                int IdGobierno = usuario.id5;

                string Archivo = ReqSol.ImprimeArchivo(pIdLic, IdGobierno);


                string filename = Server.MapPath("~/Files/Reportes/" + Archivo);
                byte[] filedata = System.IO.File.ReadAllBytes(filename);
                string contentType = MimeMapping.GetMimeMapping(filename);

                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = filename,
                    Inline = true,
                };

                Response.AppendHeader("Content-Disposition", cd.ToString());

                return File(filedata, contentType);
            }
            catch (Exception ex)
            {
                //return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
                return View(model);
            }
        }
    }
}
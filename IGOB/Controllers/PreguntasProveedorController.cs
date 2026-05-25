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
    public class PreguntasProveedorController : ValidaSession
    {
        private brProveedoresPreguntas ObrProveedoresPreguntas = new brProveedoresPreguntas();
        // GET: PreguntasProveedor
        public ActionResult Index(int id = 0,int IdInvitacion=0)//id=IdProveedorRqInvitacion
        {
            beProveedoresRequisicionesInvitacion ProReqIn = new brProveedoresRequisicionesInvitacion().traerProveedoresRequisicionesInvitacion_x_IdProveedorRqInvitacion(id);
            beRequisiciones Req = new brRequisiciones().traerRequisiciones_x_IdRequisicion(ProReqIn.IdRequisicion);
            beDependencias dep = new brDependencias().traerDependencias_x_IdDependencia(Req.IdDependencia);
            ViewBag.Titulo = "Solicitud: " + Req.RequisicionFolio + " - " + dep.Dependencia;
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ViewBag.IdProveedorRqInvitacion = id;
            ViewBag.IdUsuarioRegistra = b.id2;
            ViewBag.IdInvitacion = IdInvitacion;
            List<beProveedoresPreguntas> listadoPreguntasPorProveedor = new brProveedoresPreguntas().listarTodos_ProveedoresPreguntas().Where(x=>x.IdProveedorRqInvitacion==id).ToList();
            if (listadoPreguntasPorProveedor.Count() > 0)
            {
                ViewBag.disabled = (listadoPreguntasPorProveedor[0].IdEstatusPregunta == 2) ? "disabledClick" : "";
            }
            else
            {
                ViewBag.disabled = "";
            }
            
            return View(listadoPreguntasPorProveedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beProveedoresPreguntas provPreg)
        {
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            provPreg.IdUsuarioRegistro = (int)b.id2;
            provPreg.FechaRegistro = DateTime.Now;
            var Result = "";
            if (ModelState.IsValid)
            {
                var dato = ObrProveedoresPreguntas.guardarProveedoresPreguntas(provPreg);
                Result = (dato != 0) ? "Se agregó correctamente" : "No se pudo agregar";
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                Result = errors + "No se pudo agregar";
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beProveedoresPreguntas provPreg)
        {
            var Result = "";
            if (ModelState.IsValid)
            {
                var dato = ObrProveedoresPreguntas.actualizarProveedoresPreguntas(provPreg);
                Result = (dato == 0) ? "Se edito correctamente" : "No se pudo editar";
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                Result = errors + "No se pudo editar";
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            var Result = "";
            try
            {
                var dato = ObrProveedoresPreguntas.eliminarProveedoresPreguntas(id);
                Result = (dato == 0) ? "Se elimino correctamente" : "No se pudo eliminar";
            }
            catch(Exception e)
            {
                Result = "Error: " + e.Message;
            }
            
            
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EditListaPregunta(int id, List<int> IdPregunta)//id=IdProveedorRqInvitacion
        {
            try
            {
                var retorno = "";
                var Result = 0;
                foreach (var item in IdPregunta)
                {
                    beProveedoresPreguntas pregunta = ObrProveedoresPreguntas.traerProveedoresPreguntas_x_IdPregunta(item);
                    pregunta.IdEstatusPregunta = 2;
                    pregunta.FechaRegistro = DateTime.Now;
                    ObrProveedoresPreguntas.actualizarProveedoresPreguntas(pregunta);
                    Result++;
                }
                retorno = (Result == IdPregunta.Count) ? "Se enviaron correctamente las preguntas" : "no se pudieron enviar las preguntas";
                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
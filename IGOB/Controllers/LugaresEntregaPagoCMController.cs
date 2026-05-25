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
    public class LugaresEntregaPagoCMController : ValidaSession
    {
        private brLugaresEntregasPagosCM obrLugaresEntregasPagosCM = new brLugaresEntregasPagosCM();

        // GET: Departamentos
        public ActionResult Index()
        {
            //obtenemos la dependencia
            var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            int IdDependencia = usuario.id4;

            List<beLugaresEntregasPagosCM> ListaLugares = obrLugaresEntregasPagosCM.traerLugaresEntregasPagosCM_x_IdDependencia(IdDependencia);

            //obtenemos los estados
            brEF_EntidadesFederativas obrEF_EntidadesFederativas = new brEF_EntidadesFederativas();
            ViewBag.EFList = new SelectList(obrEF_EntidadesFederativas.listarTodos_EF_EntidadesFederativas(), "ClaveEstado", "Estado");

            //obtenemos los tipos de lugares
            brTiposLugarCM obrTiposLugarCM = new brTiposLugarCM();
            ViewBag.ListaTiposLugar = new SelectList(obrTiposLugarCM.listarTodos_TiposLugarCM(), "IdTipoLugarCM", "TipoLugar");
            

            return View(ListaLugares);
        }

        public JsonResult TraerLugaresEntregaPago(int pIdLugarEntregaPago)
        {

            var lugarCM = obrLugaresEntregasPagosCM.traerLugaresEntregasPagosCM_x_IdLugarEntregaPago(pIdLugarEntregaPago);

            //obtenemos la clave de estado
            brEF_Municipios obrmun = new brEF_Municipios();
            var municipio = obrmun.traerEF_Municipios_x_IdMunicipio(lugarCM.IdMunicipio);

            lugarCM.ClaveEstado = municipio.ClaveEstado;

            return Json(lugarCM, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MunicipioByClaveEstado(string pClaveEstado)
        {
            brEF_Municipios obrEF_Municipios = new brEF_Municipios();
            List<beEF_Municipios> municipios = obrEF_Municipios.traerEF_Municipios_x_ClaveEstado(pClaveEstado);
            return Json(municipios, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beLugaresEntregasPagosCM obeLugar)
        {
            
            var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            //obtenemos la dependencia
            obeLugar.IdDependencia = usuario.id4;
            //obtenemos la id de usuario
            obeLugar.IdUsuarioRegistro = (int)usuario.id2;
            obeLugar.LocalizacionGoogle = " ";

            obeLugar.FechaRegistro = DateTime.Now;
            
            var result = "";
            if (ModelState.IsValid)
            {
                var create = obrLugaresEntregasPagosCM.guardarLugaresEntregasPagosCM(obeLugar);
                result = "Se Agrego Correctamente";
            }
            else
            {
                result = "No se Pudo Agregar";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beLugaresEntregasPagosCM obeLugar)
        {
            //datos anteriores que no se cambiarán al editar
            var LugarCM = obrLugaresEntregasPagosCM.traerLugaresEntregasPagosCM_x_IdLugarEntregaPago(obeLugar.IdLugarEntregaPago);

            obeLugar.FechaRegistro = LugarCM.FechaRegistro;
            obeLugar.IdUsuarioRegistro = LugarCM.IdUsuarioRegistro;
            obeLugar.IdDependencia = LugarCM.IdDependencia;
            obeLugar.LocalizacionGoogle = LugarCM.LocalizacionGoogle;

            var result = "";
            if (ModelState.IsValid)
            {
                var edit = obrLugaresEntregasPagosCM.actualizarLugaresEntregasPagosCM(obeLugar);
                if (edit == 0)
                {
                    result = "Se Edito Correctamente";
                }
                else
                {
                    result = "No se Pudo Editar";
                }
            }
            else
            {
                result = "No se Pudo Editar";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int pIdLugarEntregaPago)
        {
            var result = "";
            var delete = obrLugaresEntregasPagosCM.eliminarLugaresEntregasPagosCM(pIdLugarEntregaPago);
            if (delete == 0)
            {
                result = "Se Elimino Correctamente";
            }
            else
            {
                result = "No se Pudo Eliminar";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
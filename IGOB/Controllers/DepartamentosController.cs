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
    public class DepartamentosController : ValidaSession
    {
        private brDepartamentos obrDepartamentos = new brDepartamentos();

        // GET: Departamentos
        public ActionResult Index()
        {
            //obtenemos la dependencia
            var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            int IdDependencia = usuario.id4;

            List<beDepartamentos> ListaDepartamentos = obrDepartamentos.traerDepartamentos_x_IdDependencia(IdDependencia);

            return View(ListaDepartamentos);
        }

        public JsonResult TraerDepartamento(int pIdDepartamento)
        {
            var departamento = obrDepartamentos.traerDepartamentos_x_IdDepartamento(pIdDepartamento);
            return Json(departamento, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beDepartamentos depto)
        {
            //obtenemos la dependencia
            var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            
            depto.IdDependencia= usuario.id4;
            depto.Activo = true;

            var result = "";
            if (ModelState.IsValid)
            {
                var create = obrDepartamentos.guardarDepartamentos(depto);
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
        public JsonResult Edit(beDepartamentos depto)
        {
            //obtenemos la dependencia
            var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            depto.IdDependencia = usuario.id4;
            depto.Activo = true;

            var result = "";
            if (ModelState.IsValid)
            {
                var edit = obrDepartamentos.actualizarDepartamentos(depto);
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
        public JsonResult Delete(int pIdDepartamento)
        {
            var departamento = obrDepartamentos.traerDepartamentos_x_IdDepartamento(pIdDepartamento);

            departamento.Activo = false;

            var result = "";
            var delete = obrDepartamentos.actualizarDepartamentos(departamento);
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
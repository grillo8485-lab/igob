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
    public class CuentasBancariasController : ValidaSession
    {
        private brCuentasBancariasDependencias ObrCuentasBancarias = new brCuentasBancariasDependencias();
        private brDependencias ObrDependencias = new brDependencias();
        private brOrigenRecurso ObrOrigenRecurso = new brOrigenRecurso();
        private brBancos ObrBancos = new brBancos();
        private brEjerciciosFiscales ObrEjerciciosFiscales = new brEjerciciosFiscales();

        // GET: Catalogos/CuentasBancariasDependencias
        public ActionResult Index(int id = 0)
        {
            List<beDependencias> DependenciasList = ObrDependencias.listarTodos_Dependencias().ToList();
            ViewBag.DependenciasList = new SelectList(DependenciasList, "IdDependencia", "Dependencia");

            List<beOrigenRecurso> OrigenRecursoList = ObrOrigenRecurso.listarTodos_OrigenRecurso().ToList();
            ViewBag.OrigenRecursoList = new SelectList(OrigenRecursoList, "IdOrigenRecurso", "OrigenRecurso");

            List<beBancos> BancosList = ObrBancos.listarTodos_Bancos().ToList();
            ViewBag.BancosList = new SelectList(BancosList, "IdBanco", "NombreCorto");

            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ViewBag.idUsuarioRegistra = b.id2;

            ViewBag.Fechas = DateTime.Now;
            ViewBag.disabled = "";

            var todos = ObrCuentasBancarias.listarTodosCuentasBancariasPorDependencias();
            return View(todos);
        }
        public ActionResult CuentasPorDependencias(int id = 0)
        {
            List<beDependencias> DependenciasList = ObrDependencias.listarTodos_Dependencias().ToList();
            ViewBag.DependenciasList = new SelectList(DependenciasList, "IdDependencia", "Dependencia");

            List<beOrigenRecurso> OrigenRecursoList = ObrOrigenRecurso.listarTodos_OrigenRecurso().ToList();
            ViewBag.OrigenRecursoList = new SelectList(OrigenRecursoList, "IdOrigenRecurso", "OrigenRecurso");

            List<beBancos> BancosList = ObrBancos.listarTodos_Bancos().ToList();
            ViewBag.BancosList = new SelectList(BancosList, "IdBanco", "NombreCorto");

            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ViewBag.idUsuarioRegistra = b.id2;

            ViewBag.disabled = "disabledClick";
            ViewBag.Fechas = DateTime.Now;

            var todos = ObrCuentasBancarias.ListadoCuentasBancariasFiltradasPorDependencias(id);
            return View(todos);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beCuentasBancariasDependencias cuentasbancarias)
        {
            var existe = ObrCuentasBancarias.listarTodos_CuentasBancariasDependencias().Where(x => x.NumeroCuenta.Trim() == cuentasbancarias.NumeroCuenta.Trim() && x.IdDependencia == cuentasbancarias.IdDependencia).FirstOrDefault();
            if (existe == null)
            {
                var Result = "";
                if (ModelState.IsValid)
                {
                    var resp = ObrCuentasBancarias.guardarCuentasBancariasDependencias(cuentasbancarias);
                    Result = "Se Agrego correctamente ";

                }
                else
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    Result = " No se ha podido Agregar ";
                }
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Cuenta Existente", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            beCuentasBancariasDependencias cuentasbancarias = ObrCuentasBancarias.traerCuentasBancariasDependencias_x_IdCuentaBancaria(id);

            if (cuentasbancarias != null)
            {
                ObrCuentasBancarias.eliminarCuentasBancariasDependencias(id);
                ViewBag.Result = "Eliminado correctamente";
            }
            else
            {
                ViewBag.Result = "No se ha podido eliminar";
            }
            return Json(ViewBag.Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beCuentasBancariasDependencias cuentasbancarias)
        {
            try
            {
                var Result = "";
                beCuentasBancariasDependencias cuentabancaria = ObrCuentasBancarias.traerCuentasBancariasDependencias_x_IdCuentaBancaria(cuentasbancarias.IdCuentaBancaria);
                if (cuentabancaria != null)
                {
                    cuentabancaria.FechaMovimiento = DateTime.Now;
                    cuentabancaria.NombreCuenta = cuentasbancarias.NombreCuenta;
                    cuentabancaria.MontoDisponible = cuentasbancarias.MontoDisponible;
                    ObrCuentasBancarias.actualizarCuentasBancariasDependencias(cuentabancaria);
                    Result = "Editado correctamente";
                }
                else
                {
                    Result = "No se ha podido editar";
                }
                return Json(Result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }

        }
    }
}
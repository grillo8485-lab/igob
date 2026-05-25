using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;

namespace IGOB.Controllers
{
    public class LugarFirmaController : ValidaSession
    {
        private brLugaresEntregaFirma ObrLugarEntregaFirma = new brLugaresEntregaFirma();
        private brDependencias ObrDependencias = new brDependencias();
        private brEF_EntidadesFederativas ObrEF_EntidadesFederativas = new brEF_EntidadesFederativas();
        // GET: Catalogos/LugarEntrega
        public ActionResult Index()
        {
            List<beDependencias> ListaDependencia = ObrDependencias.listarTodos_Dependencias().ToList();
            ViewBag.ListDep = new SelectList(ListaDependencia, "IdDependencia", "Dependencia");

            List<beEF_EntidadesFederativas> ListaEntidades = ObrEF_EntidadesFederativas.listarTodos_EF_EntidadesFederativas().ToList();
            ViewBag.ListEnt = new SelectList(ListaEntidades, "ClaveEstado", "Estado");

            List<beLugaresEntregaFirma> ListaLugaresEntrega = ObrLugarEntregaFirma.Listar_LugaresEntregaFirma_Traer_Firma().ToList();
            return View(ListaLugaresEntrega);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beLugaresEntregaFirma lef)
        {
            var createResult = "";
            var create = ObrLugarEntregaFirma.guardarLugaresEntregaFirma(lef);
            if (create > 0)
            {
                createResult = "Se Agrego Correctamente";
            }
            else
            {
                createResult = "No Se Agrego";

            }
            return Json(createResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var deleteResult = "";
            var delete = ObrLugarEntregaFirma.eliminarLugaresEntregaFirma(id);
            if (delete == 0)
            {
                deleteResult = "Se Elimino Correctamente";
            }
            else
            {
                deleteResult = "No Se Pudo Eliminar";
            }
            return Json(deleteResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beLugaresEntregaFirma lef)
        {
            var editResult = "";
            var edit = ObrLugarEntregaFirma.actualizarLugaresEntregaFirma(lef);
            if (edit == 0)
            {
                editResult = "Se Modifico Correctamente";
            }
            else
            {
                editResult = "No Se Pudo Modificar";
            }
            return Json(editResult, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;

namespace IGOB.Controllers
{
    public class UnidadesMedidaController : ValidaSession
    {
        private brUnidadesMedidas ObrUnidadesMedidas = new brUnidadesMedidas();
        public ActionResult Index()
        {
            return View(ObrUnidadesMedidas.listarTodos_UnidadesMedidas().ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beUnidadesMedidas um)
        {
            try
            {
                um.Activo = true;
                um.FechaVigenciaInicial = DateTime.Now.AddYears(1);
                ObrUnidadesMedidas.guardarUnidadesMedidas(um);
                var resp = "Unidad de medida: <strong>" + um.UnidadMedida + "</strong> agregada correctamente.";
                return Json(new { success = true, m = resp }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, m = ex.Message}, JsonRequestBehavior.AllowGet);

                throw;
            }

        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            if (ObrUnidadesMedidas.traerUnidadesMedidas_x_IdUnidadMedida(id) != null)
            {
                ObrUnidadesMedidas.eliminarUnidadesMedidas(id);
                return Json(new { success = true, m = "Eliminado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false, m = "No se ha podido eliminar" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beUnidadesMedidas um)
        {
            if (ObrUnidadesMedidas.traerUnidadesMedidas_x_IdUnidadMedida(um.IdUnidadMedida) != null)
            {
                ObrUnidadesMedidas.actualizarUnidadesMedidas(um);
                return Json(new { success = true, m = "Editado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false, m = "No se ha podido editar" }, JsonRequestBehavior.AllowGet);
        }
    }
}
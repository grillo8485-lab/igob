using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;

namespace Controllers
{
    public class MarcasController : ValidaSession
    {
        private brMarcas ObrMarcas = new brMarcas();

        // GET: Catalogos/Marcas
        public ActionResult Index()
        {
            return View(ObrMarcas.listarTodos_Marcas());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beMarcas marcas)
        {
            if (ModelState.IsValid)
            {
                marcas.Activo = true;
                ObrMarcas.guardarMarcas(marcas);
                return Json(new { success = true, m = "Marca: <strong>" + marcas.Marca + "</strong> agregada correctamente." }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false, m = ModelState.Values.SelectMany(v => v.Errors) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int Id)
        {
            if (ObrMarcas.traerMarcas_x_IdMarca(Id) != null)
            {
                ObrMarcas.eliminarMarcas(Id);
                return Json(new { success = true, m = "Eliminado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false, m = "No se ha podido eliminar" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beMarcas marcas)
        {
            beMarcas editMarca = ObrMarcas.traerMarcas_x_IdMarca(marcas.IdMarca);

            if (editMarca != null)
            {
                editMarca.Marca = marcas.Marca;
                editMarca.Abreviatura = marcas.Abreviatura;
                ObrMarcas.actualizarMarcas(editMarca);
                return Json(new { success = true, m = "Editado Correctamente" }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false, m = "No se ha podido editar" }, JsonRequestBehavior.AllowGet);
        }
    }
}
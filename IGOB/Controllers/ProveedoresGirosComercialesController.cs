using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;

namespace IGOB.Controllers
{
    public class ProveedoresGirosComercialesController : ValidaSession
    {
        private brProveedoresGirosComerciales ObrProveedoresGirosComerciales = new brProveedoresGirosComerciales();
        private brProveedores ObrProveedores = new brProveedores();
        private brActividadesEconomicas ObrActividadesEconomicas = new brActividadesEconomicas();
        // GET: ProveedoresGirosComerciales
        public ActionResult Index(int id)
        {
            List<beProveedoresGirosComerciales> listProveedoresGirosComerciales = ObrProveedoresGirosComerciales.listarTodos_ProveedoresGirosComerciales_GetAll().Where(x => x.IdProveedor == id).ToList();
            ViewBag.IdProveedor = id;
            TempData["tipoProv"] = ViewBag.Tipo = TempData["tipoProv"];
            return View(listProveedoresGirosComerciales);
        }

        public JsonResult ListActividadEconomica(string descripcion)
        {
            var resultado = ObrActividadesEconomicas.listarTodos_ActividadesEconomicas().Where(x => x.Descripcion.Contains(descripcion.ToUpper())).Select(x => new { x.IdActividadEconomica, x.Descripcion, x.Codigo }).Take(5).ToList();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListaProveedores(string descripcion)
        {
            var resultado = ObrProveedores.listarTodos_Proveedores().Where(x => x.NombreComercial.ToUpper().Contains(descripcion.ToUpper())).Select(x => new { x.IdProveedor, x.NombreComercial }).Take(5).ToList();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(beProveedoresGirosComerciales pgc)
        {
            var mes = "";
            var suc = false;
            try
            {
                var hasActividad = ObrProveedoresGirosComerciales.listarTodos_ProveedoresGirosComerciales().Where(x => x.IdProveedor == pgc.IdProveedor && x.IdActividadEconomica == pgc.IdActividadEconomica).FirstOrDefault();
                if (hasActividad == null)
                {
                    ObrProveedoresGirosComerciales.guardarProveedoresGirosComerciales(pgc);
                    mes = "Giro comercial añadido.";
                    suc = true;
                }
                else
                {
                    mes = "Giro comercial duplicado.";
                }
                return Json(new { success = suc, message = mes }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                mes = "Giro comercial no se pudo añadir. "+e.Message;
                return Json(new { success = suc, message = mes}, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(beProveedoresGirosComerciales pgc)
        {
            var mes = "";
            var suc = false;
            try
            {
                if (ObrProveedoresGirosComerciales.actualizarProveedoresGirosComerciales(pgc) == 0)
                {
                    mes = "se modifico correctamente";
                    suc = true;
                }
                else
                {
                    mes = "No se pudo modificar";
                }
                return Json(new { success = suc, message = mes }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                mes = "No se pudo modificar "+e.Message;
                return Json(new { success = suc, message = mes}, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            var mes = "";
            var suc = false;
            try
            {
                if (ObrProveedoresGirosComerciales.eliminarProveedoresGirosComerciales(id) == 0)
                {
                    mes = "Se elimino correctamente";
                    suc = true;
                }
                else
                {
                    mes = "No se pudo eliminar";
                }
                return Json(new { success = suc, message = mes }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                mes = "No se pudo eliminar "+e.Message;
                return Json(new { success = suc, message = mes}, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
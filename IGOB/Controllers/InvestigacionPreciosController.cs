using iGob.Entidades;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class InvestigacionPreciosController : ValidaSession
    {
        // GET: InvestigacionPrecios
        public ActionResult Index()
        {
            ClsInvesticacionPrecio investicacionPrecio = new ClsInvesticacionPrecio();
            var lst = investicacionPrecio.getAllDispercionMuestraPrecios();
            return View(lst);
        }
        [HttpPost]
        public JsonResult getProductos(string term)
        {
            try
            {
                beGenerica pGenerico = new beGenerica();
                pGenerico.string1 = term;
                ClsInvesticacionPrecio investicacionPrecio = new ClsInvesticacionPrecio();
                var lst_ = investicacionPrecio.getProductos(pGenerico);
                return Json(new { success = true, data = lst_ }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult getInvestigacionPrecio(int IdDeterminaPrecioBienServicio)
        {
            try
            {
                ClsInvesticacionPrecio investicacionPrecio = new ClsInvesticacionPrecio();
                
               var DeterminacionPrecio = new beDeterminacionPrecios();
                var IdNivelConfianza = 0;
                var lst = investicacionPrecio.getAllNivelesConfianza();
                if (IdDeterminaPrecioBienServicio != 0)
                {
                    DeterminacionPrecio = investicacionPrecio.getDeterminacionPrecio(IdDeterminaPrecioBienServicio);
                    var objeto = lst.Where(s => s.NivelConfianza == DeterminacionPrecio.NivelConfianza).FirstOrDefault();
                    IdNivelConfianza = objeto.IdNivelConfianza;
                }

                ViewBag.IdNivelConfianza = IdNivelConfianza;
                ViewBag.NivelConfianza = new SelectList(lst, "IdNivelConfianza", "NivelConfianza", IdNivelConfianza);
                return PartialView("Componente/EditInvestigacionPrecio", DeterminacionPrecio);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getProducto(int IdBienServicio)
        {
            try
            {
                ClsInvesticacionPrecio investicacionPrecio = new ClsInvesticacionPrecio();
                var objeto = investicacionPrecio.getBienesServicios(IdBienServicio);
                
                return Json(new { success = true, data = objeto }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult getCalcularVarianza(beDeterminacionPrecios determinacionPrecios)
        {
            try
            {
                ClsInvesticacionPrecio investicacionPrecio = new ClsInvesticacionPrecio();
                //determinacionPrecios
                var nivelConfianza = investicacionPrecio.getNivelesConfianza((int)determinacionPrecios.NivelConfianza);
                var confianzaVarianza = Math.Pow(Double.Parse(nivelConfianza.ValorConfianza.ToString()), 2)* Math.Pow(Double.Parse(determinacionPrecios.Varianza.ToString()), 2);
                var divisor = confianzaVarianza * determinacionPrecios.Poblacion;
                var dividendo = confianzaVarianza + (Math.Pow(Double.Parse(determinacionPrecios.MargenError.ToString()), 2) * (determinacionPrecios.Poblacion - 1));
                var resultado = divisor / dividendo;
                determinacionPrecios.Muestra = decimal.Parse(resultado.ToString());
                determinacionPrecios.MuestraRedondeada = (int)Math.Ceiling(resultado);
                return Json(new { success = true, data = determinacionPrecios }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult saveInvestigacionPrecio(beDeterminacionPrecios determinacionPrecios)
        {
            try
            {
                ClsInvesticacionPrecio investicacionPrecio = new ClsInvesticacionPrecio();
                var nivelConfianza = investicacionPrecio.getNivelesConfianza((int)determinacionPrecios.NivelConfianza);
                determinacionPrecios.NivelConfianza = nivelConfianza.NivelConfianza;
                determinacionPrecios.ConstanteNivelConfianza  = nivelConfianza.ValorConfianza;
                determinacionPrecios.FechaCalculoMuestra = DateTime.Now;
                determinacionPrecios.FechaCalculoPrecio = DateTime.Now;
                //determinacionPrecios
                if(determinacionPrecios.IdDeterminaPrecioBienServicio==0)
                investicacionPrecio.saveInvestigacionPrecio(determinacionPrecios);
                else
                    investicacionPrecio.updateInvestigacionPrecio(determinacionPrecios);
                
                return Json(new { success = true}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
    
}
using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class RepProveedoresController : ValidaSession
    {
        // GET: RepProveedores
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListaProveedores(string descripcion)
        {
            brRptAppEjecutivosLicitaciones obrRep = new brRptAppEjecutivosLicitaciones();
            List<beRptAppEjecutivosLicitaciones> resultado = obrRep.ListaProveedores(descripcion);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Detalles(int pIdProveedor)
        {
            //obtenemos los datos necesarios

            //obtenemos el gobierno
            var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

            int IdPerfil = usuario.id.GetValueOrDefault();

            brRptAppEjecutivosLicitaciones obrRep = new brRptAppEjecutivosLicitaciones();
            
            if (IdPerfil == 11)
            {
                //perfil gobernador
                //obtenemos los datos necesarios
                List<beRptAppEjecutivosLicitaciones> ListRep = obrRep.AdquisicionesProveedoresDependencias(pIdProveedor);
                ViewBag.ListRep = ListRep;

                brProveedores obrPro = new brProveedores();
                beProveedores obePro = obrPro.traerProveedores_x_IdProveedor(pIdProveedor);

                ViewBag.Proveedor = obePro.RazonSocial;
            }
            else if (IdPerfil == 4)
            {
                //perfil jefe de dependencia
                int pIdDependencia = usuario.id4;

                beRptAppEjecutivosLicitaciones obeRep = obrRep.AdquisicionesDependenciaProveedor(pIdDependencia, pIdProveedor);

                ViewBag.obeRep = obeRep;
            }

            ViewBag.IdPerfil = IdPerfil;

            return PartialView("~/Views/RepProveedores/Detalles.cshtml");
        }
    }
}
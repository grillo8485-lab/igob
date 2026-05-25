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
    public class RepAdquisicionesController : ValidaSession
    {
        // GET: RepAdquisiciones
        public ActionResult Index()
        {
            //obtenemos el gobierno
            var usuario = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            int IdPerfil = usuario.id.GetValueOrDefault();

            brRptAppEjecutivosLicitaciones obrRep = new brRptAppEjecutivosLicitaciones();
            beRptAppEjecutivosLicitaciones obeRep = new beRptAppEjecutivosLicitaciones();

            if (IdPerfil == 11)
            {
                //perfil gobernador
                int IdGobierno = usuario.id5;
                //obtenemos los datos necesarios
                obeRep = obrRep.RepAdquisiciones(IdGobierno);
            }
            else if (IdPerfil == 4)
            {
                //perfil jefe de dependencia
                int IdDependencia = usuario.id4;
                obeRep = obrRep.RepAdquisicionesDep(IdDependencia);
            }

            ViewBag.obeRep = obeRep;
            ViewBag.IdPerfil = IdPerfil;

            return View();
        }
    }
}
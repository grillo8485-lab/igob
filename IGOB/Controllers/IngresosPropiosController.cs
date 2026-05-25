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
    public class IngresosPropiosController : ValidaSession
    {
        private brCuentasBancariasDependencias ObrCuentasBancariasDependencias = new brCuentasBancariasDependencias();
        private brDependencias ObrDependencias = new brDependencias();
        private brOrigenRecurso ObrOrigenRecurso = new brOrigenRecurso();
        private brBancos ObrBancos = new brBancos();
        // GET: IngresosPropios
        public ActionResult Index()
        {
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ViewBag.IdDep = b.id4;

            List<beBancos> BancosList = ObrBancos.listarTodos_Bancos().ToList();
            ViewBag.BancosList = new SelectList(BancosList, "IdBanco", "NombreCorto");

            var todos = ObrCuentasBancariasDependencias.listar_CuentasBancariasDependenciasIngProp_TraerTodas(b.id4);
            return View(todos);
        }
    }
}
using iGob.Entidades;
using IGOB.Areas.Catalogos.Models;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IGOB.Controllers
{
    public class AdjudicacionesPedidosConsultaController : Controller
    {
        // GET: AdjudicacionesPedidosConsulta
        public ActionResult Index()
        {
            ClsAdquisicion adquisicion = new ClsAdquisicion();
            var a = new List<beAdjudicacionesPedidosConsulta>();
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];

            switch (b.id)
            {

                case 4: // Jefe Dependencia: IdDependencia, IdPerfil
                    a = adquisicion.consultaAdjudicacionesPedidos((int)b.id4, 0, (int)b.id);//IdDependencia,IdProveedor,IdPerfil
                    break;
                case 5: // Director de Adquisiciones: IdPerfil
                    a = adquisicion.consultaAdjudicacionesPedidos(0, 0, (int)b.id);
                    break;
                case 8: // Proveedor: IdProveedor,IdPerfil
                    a = adquisicion.consultaAdjudicacionesPedidos(0, (int)b.id6, (int)b.id);
                    break;

            }

            return View(a);
        }
    }
}
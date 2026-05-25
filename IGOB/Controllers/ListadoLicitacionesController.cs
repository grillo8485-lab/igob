using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Models;

namespace IGOB.Controllers
{
    public class ListadoLicitacionesController : ValidaSession
    {
        brEjerciciosFiscales ObrEjerciciosFiscales = new brEjerciciosFiscales();
        brTiposLicitaciones ObrTiposLicitaciones = new brTiposLicitaciones();
        brSysUsuarios ObrSysUsuarios = new brSysUsuarios();
        brListadoGenerarLicitacion ObrListadoGenerarLicitacion = new brListadoGenerarLicitacion();
        brLicitacionesRequisiciones ObrLicitacionesRequisiciones = new brLicitacionesRequisiciones();
        brLicitaciones ObrLicitaciones = new brLicitaciones();
        brConfiguracionesModalidades ObrConfiguracionesModalidades = new brConfiguracionesModalidades();
        brTiposRequisiciones TiposRequisiciones = new brTiposRequisiciones();
        // GET: ListadoLicitaciones
        public ActionResult Index(int Id=0, int Id2=0, int Id3=0, int Id4 = 0)//IdTipoLicitacion,IdEjercicioFiscal,IdUsuarioRevisor
        {
            ViewBag.Error = "";
            if (TempData["ErrorConfiguracionLicitacion"] != null)
            {
                ViewBag.Error = TempData["ErrorConfiguracionLicitacion"].ToString() == "" ? "" : TempData["ErrorConfiguracionLicitacion"];
            }
            ViewBag.licitaciones = new SelectList(ObrTiposLicitaciones.listarTodos_TiposLicitaciones().ToList(), "IdTipoLicitacion", "TipoLicitacion",Id);
            ViewBag.ejerciciofiscal = new SelectList(ObrEjerciciosFiscales.listarTodos_EjerciciosFiscales().ToList(), "IdEjercicioFiscal", "Ejercicio",Id2);
            ViewBag.empleadoRevisor = new SelectList(ObrSysUsuarios.Usuarios_Traer_IdPerfil(7).ToList(), "IdUsuario", "Nombres",Id3);
            ViewBag.TiposRequisiciones = new SelectList(TiposRequisiciones.listarTodos_TiposRequisiciones().Where(s=> s.IdTipoRequisicion!=3).ToList(), "IdTipoRequisicion", "TipoRequisicion", Id4);
            ViewBag.tipo = new SelectList(ObrConfiguracionesModalidades.ConfiguracionesModalidades_traer_TiposLicitacion(), "IdConfiguracionModalidad", "ModalidadesLicitaciones");
            beListadoGenerarLicitacion ListadoFiltrado = new beListadoGenerarLicitacion();
            if (Id!=0 && Id2!=0 && Id3 != 0 && Id4 != 0)
            {
                List<beListadoGenerarLicitacion> listadoLicitacionesGenerar = ObrListadoGenerarLicitacion.ListadoGenerarLicitacion(Id, Id2, Id3, Id4);
                ViewBag.table = listadoLicitacionesGenerar;
                ListadoFiltrado = listadoLicitacionesGenerar.FirstOrDefault(x => x.IdLicitacion != 0);
            }
            ViewBag.IdLicitacion = (ListadoFiltrado!=null) ? ListadoFiltrado.IdLicitacion : 0;
            if (TempData["ErrorConfiguracionLicitacion"] != null)
            {
                TempData["ErrorConfiguracionLicitacion"] ="";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Listadolicitaciones(List<int> id, int IdLicitacion, int IdEjercicioFiscal, int IdTipoLicitacion)//IdTipoLicitacion,IdEjercicioFiscal,IdUsuarioRevisor
        {
            ParametrosGenerarLicitacion op = new ParametrosGenerarLicitacion();
            op.id = id;
            op.IdLicitacion = IdLicitacion;
            op.IdEjercicioFiscal = IdEjercicioFiscal;
            op.IdTipoLicitacion = IdTipoLicitacion;
            TempData["oParametrosLicitacion"] = op;
            return Redirect("/GenerarLicitacion/Index");
        }
        public JsonResult GetTipoSol()
        {
            var listTipoSol = new brTiposSolicitud().listarTodos_TiposSolicitud();
            return Json(listTipoSol, JsonRequestBehavior.AllowGet);
        }
    }
}
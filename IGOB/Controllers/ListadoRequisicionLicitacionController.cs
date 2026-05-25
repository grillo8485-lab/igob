using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iGob.Entidades;
using iGob.ReglasNegocios;
using IGOB.Areas.Catalogos.Models;
using IGOB.Models;

namespace IGOB.Controllers
{
    public class ListadoRequisicionLicitacionController : ValidaSession
    {
        // GET: ListadoRequisicionLicitacion
        public ActionResult Index()
        {
            ViewBag.IdInvitacion = (int)TempData["IdInvitacion"];
            ViewBag.IdLicitacion = (int)TempData["IdLicitacion"];
            ViewBag.idTipoProveso = (int)TempData["IdTipoProceso"];
            var b = (ClsGenerica)System.Web.HttpContext.Current.Session["ClsGenerico"];
            ViewBag.IdPerfil = (int)b.id;
            ViewBag.Titulo = "";
            ViewBag.ListadoRequisicionLicitacion = new List<beListadoRequisicionLicitacion>();
            ViewBag.count = 0;
            switch ((int)b.id)
            {
                case 8:// seccionde IdInvitacion
                    var lst = new List<beListadoRequisicionLicitacion>();
                    lst = new brListadoLicitacionesInvitacionProveedores().ListadoRequisicionLicitacion(ViewBag.IdInvitacion);
                    switch ((int)ViewBag.idTipoProveso)
                    {
                        case 0:
                            //lst = lst.Where(s => s.IdEstatusEnvioPropuestaTecnica == 1 | s.IdEstatusEnvioPropuestaTecnica == 2).ToList();
                            ViewBag.ListadoRequisicionLicitacion = lst;
                            if (lst.Count > 0)
                                ViewBag.Titulo = (new brListadoLicitacionesInvitacionProveedores()).ListadoLicitacionesAceptadasProveedor(b.id6).Where(s => s.IdInvitacion == (int)ViewBag.IdInvitacion).ToList().First().Licitacion;
                            TempData["TituloPorProceso"] = ViewBag.Titulo;
                            break;
                        case 1:
                            lst = lst.Where(s => s.IdEstatusEnvioPropuestaTecnica == 1 | s.IdEstatusEnvioPropuestaTecnica == 2).ToList();
                            ViewBag.ListadoRequisicionLicitacion = lst;
                            if (lst.Count > 0)
                                ViewBag.Titulo = (new brListadoLicitacionesInvitacionProveedores()).ListadoLicitacionesAceptadasProveedor(b.id6).Where(s => s.IdInvitacion == (int)ViewBag.IdInvitacion).ToList().First().Licitacion;
                            TempData["TituloPorProceso"] = ViewBag.Titulo;
                            break;
                        case 2:
                            lst = lst.Where(s => s.IdEstatusEnvioPropuestaTecnica == 2).ToList();
                            ViewBag.ListadoRequisicionLicitacion = lst;
                            if (lst.Count > 0)
                                ViewBag.Titulo = (new brListadoLicitacionesInvitacionProveedores()).ListadoLicitacionesAceptadasProveedor(b.id6).Where(s => s.IdInvitacion == (int)ViewBag.IdInvitacion).ToList().First().Licitacion;

                            TempData["TituloPorProceso"] = ViewBag.Titulo;
                            break;
                        case 100:
                            ViewBag.ListadoRequisicionLicitacion = new brListadoLicitacionesInvitacionProveedores().LiberarPedido_Proveedor((int)ViewBag.IdLicitacion, (int)b.id6, (int)ViewBag.IdPerfil);//licitacion proveddor
                            ViewBag.Titulo = (new brListadoLicitacionesInvitacionProveedores()).ListadoLicitacionesAceptadasProveedor((int)b.id6).Where(s => s.IdLicitacion == (int)ViewBag.IdLicitacion).First().Licitacion;
                            ViewBag.count = (ViewBag.ListadoRequisicionLicitacion as List<bePedidosLicitaciones>).Count();
                            var listado = ViewBag.ListadoRequisicionLicitacion as List<bePedidosLicitaciones>;
                            if (listado.Where(s => s.IdEstatusPedido == 2).ToList().Count == listado.Count)
                            {
                                if (listado.Count > 0)
                                {
                                    ClsLiberarPedido pedido = new ClsLiberarPedido();
                                    var licitacion = pedido.getLicitacion(listado.First().IdLicitacion);
                                    licitacion.IdEstatusLicitacion = 110;
                                    pedido.saveLicitacion(licitacion);
                                }

                            }
                            TempData["TituloPorProceso"] = ViewBag.Titulo;
                            break;
                       
                    }
                    
                    break;
                case 3:// seccion de IdLicitacion - solicitante

                     
                    switch ((int)ViewBag.idTipoProveso)
                    {
                        case 1:
                            ViewBag.ListadoRequisicionLicitacion = new brListadoLicitacionesInvitacionProveedores().ListadoRequisicionLicitacionSolictanteDependencia((int)ViewBag.IdLicitacion, b.id4);//licitacion Solicitante 
                            if ((ViewBag.ListadoRequisicionLicitacion as List<beListadoRequisicionLicitacion>).Count > 0)
                            {
                                ViewBag.Titulo = (new brListadoLicitacionesInvitacionProveedores()).Licitaciones_x_SolictanteDependencia(b.id4).Where(s => s.IdLicitacion == (int)ViewBag.IdLicitacion).First().Licitacion;
                                TempData["TituloPorProceso"] = ViewBag.Titulo;
                            }
                            
                            break;
                        case 5:
                            ViewBag.ListadoRequisicionLicitacion = new brListadoLicitacionesInvitacionProveedores().ListadoRequisicionLicitacionSolictanteDependenciaDictamenTecnico((int)ViewBag.IdLicitacion, b.id4);//licitacion Solicitante IdLicitacion,IdDependencia
                            if ((ViewBag.ListadoRequisicionLicitacion as List<beListadoRequisicionLicitacion>).Count > 0)
                            {
                                ViewBag.Titulo = (new brListadoLicitacionesInvitacionProveedores()).Licitaciones_x_SolictanteDependencia(b.id4).Where(s => s.IdLicitacion == (int)ViewBag.IdLicitacion).First().Licitacion;
                                TempData["TituloPorProceso"] = ViewBag.Titulo;
                            }
                            break;
                        case 100:
                            ViewBag.ListadoRequisicionLicitacion = new brListadoLicitacionesInvitacionProveedores().LiberarPedido_IdLicitacion_IdDependencia((int)ViewBag.IdLicitacion,(int)b.id4, (int)ViewBag.IdPerfil);//licitacion Revisor
                            
                            ViewBag.Titulo = (new brListadoLicitacionesInvitacionProveedores()).Licitaciones_x_SolictanteDependencia((int)b.id4).Where(s => s.IdLicitacion == (int)ViewBag.IdLicitacion).First().Licitacion;
                            ViewBag.count = (ViewBag.ListadoRequisicionLicitacion as List<bePedidosLicitaciones>).Count();
                            var listado = ViewBag.ListadoRequisicionLicitacion as List<bePedidosLicitaciones>;
                            if (listado.Where(s => s.IdEstatusPedido == 2).ToList().Count == listado.Count)
                            {
                                if (listado.Count > 0)
                                {
                                    ClsLiberarPedido pedido = new ClsLiberarPedido();
                                    var licitacion = pedido.getLicitacion(listado.First().IdLicitacion);
                                    licitacion.IdEstatusLicitacion = 110;
                                    pedido.saveLicitacion(licitacion);
                                }

                            }
                            TempData["TituloPorProceso"] = ViewBag.Titulo;
                            break;
                    }
                    

                    break;
                case 7: // revisor
                    
                    switch ((int)ViewBag.idTipoProveso)
                    {
                        case 1:
                            ViewBag.ListadoRequisicionLicitacion = new brListadoLicitacionesInvitacionProveedores().ListadoRequisicionLicitacionRevisor_x_IdLicitacion((int)ViewBag.IdLicitacion);//licitacion Solicitante 
                            if ((ViewBag.ListadoRequisicionLicitacion as List<beListadoRequisicionLicitacion>).Count > 0)
                            {
                                ViewBag.Titulo = (new brListadoLicitacionesInvitacionProveedores()).Licitaciones_x_Revisor((int)b.id2).Where(s => s.IdLicitacion == (int)ViewBag.IdLicitacion).First().Licitacion;
                                TempData["TituloPorProceso"] = ViewBag.Titulo;
                            }
                            ViewBag.count = (ViewBag.ListadoRequisicionLicitacion as List<beListadoRequisicionLicitacion>).Count();
                            break;
                        case 3:
                        case 4:
                            ViewBag.ListadoRequisicionLicitacion = new brListadoLicitacionesInvitacionProveedores().PropuestasTecnicasRevisor_IdLicitacion((int)ViewBag.IdLicitacion);//licitacion Revisor
                            if ((ViewBag.ListadoRequisicionLicitacion as List<beListadoRequisicionLicitacion>).Count > 0)
                            {
                                ViewBag.Titulo = (new brListadoLicitacionesInvitacionProveedores()).Licitaciones_x_Revisor((int)b.id2).Where(s => s.IdLicitacion == (int)ViewBag.IdLicitacion).First().Licitacion;
                                TempData["TituloPorProceso"] = ViewBag.Titulo;
                            }
                            ViewBag.count = (ViewBag.ListadoRequisicionLicitacion as List<beListadoRequisicionLicitacion>).Count();
                            break;
                        case 6:
                            ViewBag.ListadoRequisicionLicitacion = new brListadoLicitacionesInvitacionProveedores().DictamenPropuestasTecnicasRevisor_IdLicitacion_IdEstatus((int)ViewBag.IdLicitacion,5);//licitacion Revisor
                            if ((ViewBag.ListadoRequisicionLicitacion as List<beListadoRequisicionLicitacion>).Count > 0)
                            {
                                ViewBag.Titulo = (new brListadoLicitacionesInvitacionProveedores()).Licitaciones_x_Revisor((int)b.id2).Where(s => s.IdLicitacion == (int)ViewBag.IdLicitacion).First().Licitacion;
                                TempData["TituloPorProceso"] = ViewBag.Titulo;
                            }
                            ViewBag.count = (ViewBag.ListadoRequisicionLicitacion as List<beListadoRequisicionLicitacion>).Count();
                            break;
                        case 100:
                            ViewBag.ListadoRequisicionLicitacion = new brListadoLicitacionesInvitacionProveedores().LiberarPedido_IdLicitacion((int)ViewBag.IdLicitacion, (int)ViewBag.IdPerfil);//licitacion Revisor
                            ViewBag.Titulo = (new brListadoLicitacionesInvitacionProveedores()).Licitaciones_x_Revisor((int)b.id2).Where(s => s.IdLicitacion == (int)ViewBag.IdLicitacion).First().Licitacion;
                            ViewBag.count = (ViewBag.ListadoRequisicionLicitacion as List<bePedidosLicitaciones>).Count();
                            var listado = ViewBag.ListadoRequisicionLicitacion as List<bePedidosLicitaciones>;
                            if (listado.Where(s => s.IdEstatusPedido == 2).ToList().Count == listado.Count)
                            {
                                if (listado.Count > 0)
                                {
                                    ClsLiberarPedido pedido = new ClsLiberarPedido();
                                    var licitacion = pedido.getLicitacion(listado.First().IdLicitacion);
                                    licitacion.IdEstatusLicitacion = 110;
                                    pedido.saveLicitacion(licitacion);
                                }

                            }
                            TempData["TituloPorProceso"] = ViewBag.Titulo;
                            break;
                    }
                    
                    break;
                case 4:// jefe dependencia


                    switch ((int)ViewBag.idTipoProveso)
                    {
                       
                        case 100:
                            ViewBag.ListadoRequisicionLicitacion = new brListadoLicitacionesInvitacionProveedores().LiberarPedido_IdLicitacion_IdDependencia((int)ViewBag.IdLicitacion, (int)b.id4, (int)ViewBag.IdPerfil);//licitacion Revisor
                            ViewBag.Titulo = (new brListadoLicitacionesInvitacionProveedores()).Licitaciones_x_SolictanteDependencia((int)b.id4).Where(s => s.IdLicitacion == (int)ViewBag.IdLicitacion).First().Licitacion;
                            ViewBag.count = (ViewBag.ListadoRequisicionLicitacion as List<bePedidosLicitaciones>).Count();
                            TempData["TituloPorProceso"] = ViewBag.Titulo;
                            break;
                    }


                    break;
                case 5:// 4.	Director adquisiciones


                    switch ((int)ViewBag.idTipoProveso)
                    {

                        case 100:
                            ViewBag.Titulo = TempData["TituloPorProceso"];

                            ViewBag.ListadoRequisicionLicitacion = new brListadoLicitacionesInvitacionProveedores().LiberarPedido_IdLicitacion((int)ViewBag.IdLicitacion, (int)ViewBag.IdPerfil);//licitacion Revisor
                            if (ViewBag.Titulo == "" || ViewBag.Titulo== null)
                            {
                                ViewBag.Titulo = (new brListadoLicitacionesInvitacionProveedores()).getAllDirectorAdquisiciones().Where(s => s.IdLicitacion == (int)ViewBag.IdLicitacion).First().Licitacion;
                            }
                            
                            ViewBag.count = (ViewBag.ListadoRequisicionLicitacion as List<bePedidosLicitaciones>).Count();
                            TempData["TituloPorProceso"] = ViewBag.Titulo;
                            break;
                    }


                    break;
            }
            
            TempData["IdInvitacion"] = (int)ViewBag.IdInvitacion;
            TempData["IdTipoProceso"] = (int)ViewBag.idTipoProveso;
            TempData["IdLicitacion"] = (int)ViewBag.IdLicitacion;
            return View();
        }
        [HttpGet]
        public ActionResult requisicionPropuestaTecnicaEconomica(int Id,int IdProveedorRqInvitacion,int IdTipoProceso)//IdLicitacion
        {
            TempData["IdRequisicion"] = Id;
            TempData["IdTipoProceso"] = IdTipoProceso;
            TempData["IdProveedorRqInvitacion"] = IdProveedorRqInvitacion;
            return RedirectToAction("Index", "PropuestaTecnicaEconomica");
        }

        [HttpGet]
        public ActionResult requisicionPropuestaTecnicaEconomicaRevisor(int Id, int IdProveedorRqInvitacion,int IdTIpoProceso)//IdLicitacion
        {
            TempData["IdRequisicion"] = Id;
            TempData["IdTipoProceso"] = IdTIpoProceso;
            TempData["IdProveedorRqInvitacion"] = IdProveedorRqInvitacion;
            return RedirectToAction("Index", "PropuestaTecnicaEconomica");
        }
        [HttpGet]
        public ActionResult liberarPedido(int IdPedido)//IdLicitacion
        {
            TempData["IdPedido"] = IdPedido;
            return RedirectToAction("Index", "LiberarPedidoLicitacionRequisicion");
        }
    }
}
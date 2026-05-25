using iGob.Entidades;
using iGob.ReglasNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class ClsListadoLicitacionesInvitacionAceptadasProveedor
    {
        public List<beListadoLicitacionesInvitacionProveedores> getAllInvitacionesAceptadasProveedor(int pIdProveedor)
        {
            return (new brListadoLicitacionesInvitacionProveedores()).ListadoLicitacionesAceptadasProveedor(pIdProveedor);
        }
        public List<beListadoLicitacionesInvitacionProveedores> getAllRevisarPagosProveedor(int pIdUsuario)
        {
            return (new brListadoLicitacionesInvitacionProveedores()).Licitaciones_x_Revisor(pIdUsuario);
        }
        public List<beListadoLicitacionesInvitacionProveedores> getAllRevisarRespuestaSolictanteDependencia(int pIdDependencia)
        {
            return (new brListadoLicitacionesInvitacionProveedores()).Licitaciones_x_SolictanteDependencia(pIdDependencia);
        }
        public beLicitacionesInvitacionProveedores getLicitacionInvitacionProveddor(int pIdInvitacion)
        {
            return (new brLicitacionesInvitacionProveedores()).traerLicitacionesInvitacionProveedores_x_IdInvitacion(pIdInvitacion);
        }
        public List<beEstatusPagos> getEstatusPagos()
        {
            return (new brEstatusPagos()).listarTodos_EstatusPagos();
        }
        public int saveEnvioPagoProveedores(beLicitacionesInvitacionProveedores a)
        {
            return (new brLicitacionesInvitacionProveedores()).actualizarLicitacionesInvitacionProveedores(a);
        }
        public beLicitacionesInvitacionProveedores getEnvioPagoProveedores(int pdInvtacion)
        {
            return (new brLicitacionesInvitacionProveedores()).traerLicitacionesInvitacionProveedores_x_IdInvitacion(pdInvtacion);
        }
        public string getTitulo(int pIdpRoveddor,int pIdInvitacion)
        {
            return (new brListadoLicitacionesInvitacionProveedores()).ListadoLicitacionesAceptadasProveedor(pIdpRoveddor).ToList().Where(s => s.IdInvitacion == pIdInvitacion).First().Licitacion;
        }
        public List<beListadoLicitacionesInvitacionProveedores> Licitacion_Requisiciones_Revisor(int pLicitacion)
        {
            return (new brListadoLicitacionesInvitacionProveedores()).Licitacion_Requisiciones_Revisor(pLicitacion);
        }
        public List<beListadoLicitacionesInvitacionProveedores> getAllDirectorAdquisiciones()
        {
            return (new brListadoLicitacionesInvitacionProveedores()).getAllDirectorAdquisiciones();
        }
    }
}
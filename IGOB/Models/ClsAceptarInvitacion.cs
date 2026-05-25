using iGob.Entidades;
using iGob.ReglasNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class ClsAceptarInvitacion
    {
        public beListadoLicitacionesInvitacionProveedores getAceptarInvitacion_x_IdLicitacion_IdProveedor(int IdLicitacion, int IdProveedor)
        {
            return (new brListadoLicitacionesInvitacionProveedores()).ListadoLicitacionesInvitacionProveedores(IdProveedor).Where(s => s.IdLicitacion == IdLicitacion).FirstOrDefault();
        }
        
        public List<beUnidadesLicitadoras> getAllUnidadesLicitadoras(int pIdDependencia)
        {
            return (new brUnidadesLicitadoras()).listarTodos_UnidadesLicitadoras().Where(s => s.Activo == true && s.IdDependencia == pIdDependencia).ToList();
        }
        public List<beTiempos> getAllTiempos()
        {
            return (new brTiempos()).listarTodos_Tiempos().Where(s => s.Activo == true).ToList();
        }
        public beLicitaciones getLicitacion(int pIdLicitacion)
        {
            return (new brLicitaciones()).traerLicitaciones_x_IdLicitacion(pIdLicitacion);
        }
        public beLicitacionesInvitacionProveedores getLicitacionesInvitacionProveedores(int pIdInvitacion)
        {
            return (new brLicitacionesInvitacionProveedores()).traerLicitacionesInvitacionProveedores_x_IdInvitacion(pIdInvitacion);
        }
        public int saveLicitacionesInvitacionProveedores(beLicitacionesInvitacionProveedores a)
        {
            return (new brLicitacionesInvitacionProveedores()).actualizarLicitacionesInvitacionProveedores(a);
        }
    }
}
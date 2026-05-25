using iGob.Entidades;
using iGob.ReglasNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class ClsConfiguracionesModalidades
    {

        public List<beTiposLicitaciones> getAllTiposLicitaciones()
        {
            return (new brTiposLicitaciones()).listarTodos_TiposLicitaciones();
        }
        public List<beModalidadesLicitaciones> getAllModalidadesLicitaciones()
        {
            return (new brModalidadesLicitaciones()).listarTodos_ModalidadesLicitaciones();
        }
        public List<beTiempos> getAllTiempos()
        {
            return (new brTiempos()).listarTodos_Tiempos();
        }
        public List<beConfiguracionesModalidades> getAllConfiguracionesModalidade()
        {
            var lst = (new brConfiguracionesModalidades()).listarTodos_ConfiguracionesModalidades();
            foreach(var item in lst)
            {
                item.Tiempo = (new brTiempos()).traerTiempos_x_IdTiempo(item.IdTiempo).Tiempo;
                item.TipoLicitacion = (new brTiposLicitaciones()).traerTiposLicitaciones_x_IdTipoLicitacion(item.IdTipoLicitacion).TipoLicitacion;
                item.ModalidadesLicitaciones = (new brModalidadesLicitaciones()).traerModalidadesLicitaciones_x_IdModalidadLicitacion(item.IdModalidadLicitacion).ModalidadLicitacion;
            }
            return lst;
        }
        public int saveConfiguracionesModalidades(beConfiguracionesModalidades obeConfiguracionesModalidades)
        {
            return (new brConfiguracionesModalidades()).guardarConfiguracionesModalidades(obeConfiguracionesModalidades);
        }
        public int saveEditConfiguracionesModalidades(beConfiguracionesModalidades obeConfiguracionesModalidades)
        {
            return (new brConfiguracionesModalidades()).actualizarConfiguracionesModalidades(obeConfiguracionesModalidades);
        }
        public beConfiguracionesModalidades getConfiguracionesModalidades(int IdConfiguracionModalidad)
        {
            return (new brConfiguracionesModalidades()).traerConfiguracionesModalidades_x_IdConfiguracionModalidad(IdConfiguracionModalidad);
        }
        public int deleteConfiguracionesModalidades(int IdConfiguracionModalidad)
        {
            return (new brConfiguracionesModalidades()).eliminarConfiguracionesModalidades(IdConfiguracionModalidad);
        }
    }
}
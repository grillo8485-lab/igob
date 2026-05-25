using iGob.Entidades;
using iGob.ReglasNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class ClsConfiguracionFirmantesModalidades
    {
        public List<beConfiguracionFirmatesPedidos> getConfiguracionFirmantesModalidades(int pIdModalidadLicitacion)
        {
            return (new brConfiguracionFirmatesPedidos()).listarConfiguracionFirmantesModalidades_x_IdModalidadLicitacion(pIdModalidadLicitacion);
        }
        public List<beModalidadesLicitaciones> getAllModalidadesLicitaciones()
        {
            return (new brModalidadesLicitaciones()).listarTodos_ModalidadesLicitaciones();
        }
        public int saveConfiguracionModalidadFirmante(beConfiguracionFirmatesPedidos objeto)
        {
            return (new brConfiguracionFirmatesPedidos()).guardarConfiguracionFirmatesPedidos(objeto);
        }
        public beModalidadesLicitaciones getModalidadesLicitaciones(int IdConfigFirmantePedido)
        {
            return (new brModalidadesLicitaciones()).traerModalidadesLicitaciones_x_IdModalidadLicitacion(IdConfigFirmantePedido);
        }
        public int deleteConfiguracionModalidadFirmante(int IdConfigFirmantePedido)
        {
            return (new brConfiguracionFirmatesPedidos()).eliminarConfiguracionFirmatesPedidos(IdConfigFirmantePedido);
        }
        public bool procesarOrdenamiento(int pIdModalidadLicitacion)
        {
            return (new brConfiguracionFirmatesPedidos()).procesarOrdenamiento(pIdModalidadLicitacion);
            
        }
        public beConfiguracionModalidadTipoProceso getConfiguracionModalidadTipoProceso_x_IdModalidadLicitacion(int pIdModalidadLicitacion)
        {

            return (new brConfiguracionModalidadTipoProceso()).getConfiguracionModalidadTipoProceso_x_IdModalidadLicitacion(pIdModalidadLicitacion);

        }
    }
}
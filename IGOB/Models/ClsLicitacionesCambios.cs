using iGob.Entidades;
using iGob.ReglasNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class ClsLicitacionesCambios
    {
        public beLicitaciones getLicitacion(int pIdLic)
        {
            return (new brLicitaciones()).traerLicitaciones_x_IdLicitacion(pIdLic);
        }

        public int editLicitacion(beLicitaciones oLicitaciones)
        {
            return (new brLicitaciones()).actualizarLicitaciones(oLicitaciones);
        }
        public beErrorProceso GenerarActaAdjudicacionProveedores(int pIdLicitacion)
        {
            return (new brLicitaciones()).GenerarActaAdjudicacionProveedores(pIdLicitacion);
        }
        public beErrorProceso GenerarPedidosLicitaciones_x_IdLicitacion(int pIdLicitacion)
        {
            return (new brLicitaciones()).GenerarPedidosLicitaciones_x_IdLicitacion(pIdLicitacion);
        }
        public beErrorProceso GenerarPedido_x_IdLicitacion(int pIdLicitacion)
        {
            return (new brLicitaciones()).GenerarPedido_x_IdLicitacion(pIdLicitacion);
        }
        public beErrorProceso GenerarActaDictamen_Publicar_x_IdLicitacion(int pIdLic, int pIdEstatusLicitacion)
        {
            return (new brLicitaciones()).GenerarActaDictamen_Publicar_x_IdLicitacion(pIdLic, pIdEstatusLicitacion);
        }
        public beErrorProceso GenerarRequisionesSegundaLicitacion_x_IdLicitacion(int pIdLicitacion)
        {
            return (new brLicitaciones()).GenerarRequisionesSegundaLicitacion_x_IdLicitacion(pIdLicitacion);
        }
    }
}
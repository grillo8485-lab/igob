using iGob.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class PedidoDetalleLotes
    {
        public bePedidoDetalleCabezera oCabezera = new bePedidoDetalleCabezera();
        public List<beListadoPedidosLicitaciones> Detalle = new List<beListadoPedidosLicitaciones>();
    }
}
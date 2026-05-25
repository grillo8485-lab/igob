using System;
using System.Data;

namespace iGob.Entidades
{
    public class beLicitacionesRecepcionPedido
    {
        //RecepcionPedido
        public string Dependencia { get; set; }
        public string Folio { get; set; }
        public string NombreEncargado { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public string FolioPedido { get; set; }
        public string TituloLicitacion { get; set; }
        public string Partida { get; set; }
        public string LugarEntrega { get; set; }
        public string RequisicionFolio { get; set; }


        //RecepcionesPedidosDetalles
        public string BienServicio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal CantidadRecibida { get; set; }

        public beLicitacionesRecepcionPedido()
        {

        }

    }
}

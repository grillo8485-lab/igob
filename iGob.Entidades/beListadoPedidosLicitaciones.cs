using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.Entidades
{
    public class beListadoPedidosLicitaciones
    {
        public int IdPedido { get; set; }
        public string Folio { get; set; }
        public int FolioNumero { get; set; }
        public int IdEstatusPedido { get; set; }
        public string EstatusPedido { get; set; }
        public int IdRequisicion { get; set; }
        public string RequisicionFolio { get; set; }
        public string Rfc { get; set; }
        public string RazonSocial { get; set; }
        public int IdLicitacion { get; set; }
        public int IdProveedor { get; set; }
        public string FolioOficial { get; set; }
        public string Partida { get; set; }
        public int IdCondicionEntregaDetalle { get; set; }
        public int IdPedidoDetalle { get; set; }
        public decimal Cantidad { get; set; }
        public decimal CantidadRecibida { get; set; }
        public decimal CantidadxRecibir { get; set; }
        public string BienServicio { get; set; }
        public int IdLugarEntrega { get; set; }
        public string Lugar { get; set; }
        public int NoLote { get; set; }
        public string Observaciones { get; set; }
        public string EncargadoRecepcion { get; set; }
        public string UnidadMedida { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}

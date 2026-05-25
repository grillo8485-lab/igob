using System;
using System.Data;

namespace iGob.Entidades
{
    public class beRepRecepcionPedidos
    {
        //Encabezado
        public int IdPedido { get; set; }
        public string Folio { get; set; }
        public int FolioNumero { get; set; }
        public int IdRequisicion { get; set; }
        public string RequisicionFolio { get; set; }
        public DateTime FechaPedido { get; set; }
        public string Dependencia { get; set; }
        public string Partida { get; set; }
        public string EstatusPedido { get; set; }
        public string RazonSocial { get; set; }
        public string ModalidadLicitacion { get; set; }

        //Detalles
        //public int IdPedido { get; set; }
        //public string Folio { get; set; }
        //public int FolioNumero { get; set; }
        public int IdEstatusPedido { get; set; }
        public int IdLote { get; set; }
        public int NoLote { get; set; }
        public decimal Cantidad { get; set; }
        public string BienServicio { get; set; }
        public string UnidadMedida { get; set; }
        public int IdRecepcionDetalle { get; set; }
        public decimal CantidadRecibida { get; set; }
        public string LugarEntrega { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string NombreResponsable { get; set; }
        public string Observaciones { get; set; }
        public decimal CantidadxRecibir { get; set; }
    }
}

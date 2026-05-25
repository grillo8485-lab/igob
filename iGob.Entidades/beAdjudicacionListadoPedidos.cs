using System;
using System.Data;

namespace iGob.Entidades
{
    public class beAdjudicacionListadoPedidos
    {
        public string AdjudicacionFolio { set; get; }
        public int IdAdjudicacion { set; get; }
        public string Folio { set; get; }
        public int FolioNumero { set; get; }
        public DateTime FechaPedido { set; get; }
        public int Ejercicio { set; get; }
        public DateTime FechaAutorizacion { set; get; }
        public string TipoAdjudicacion { set; get; }
        public string Estatus { set; get; }
        public int IdEstatusAdjudicacion { set; get; }
        public string RazonSocial { set; get; }
        public string Partida { set; get; }

        public beAdjudicacionListadoPedidos() { }
    }
}

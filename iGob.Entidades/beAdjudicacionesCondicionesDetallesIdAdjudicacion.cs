using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.Entidades
{
    public class beAdjudicacionesCondicionesDetallesIdAdjudicacion
    {
        public int IdAdjudicacion { get; set; }
        public int NoLote { get; set; }
        public decimal Cantidad { get; set; }
        public string BienServicio { get; set; }
        public int IdLote { get; set; }
        public string CantidadLotesxAsignar { get; set; }
        public decimal CantidadLoteAsignado { get; set; }
        public decimal CantidadxAsignar { get; set; }
        public beAdjudicacionesCondicionesDetallesIdAdjudicacion()
        {

        }

        public beAdjudicacionesCondicionesDetallesIdAdjudicacion(int pIdAdjudicacion, int pNoLote, decimal pCantidad, string pBienServicio, int pIdLote, string pCantidadLotesxAsignar, 
        decimal pCantidadLoteAsignado, decimal pCantidadxAsignar)
        {
            this.IdAdjudicacion = pIdAdjudicacion;
            this.NoLote = pNoLote;
            this.Cantidad = pCantidad;
            this.BienServicio = pBienServicio;
            this.IdLote = pIdLote;
            this.CantidadLotesxAsignar = pCantidadLotesxAsignar;
            this.CantidadLoteAsignado = pCantidadLoteAsignado;
            this.CantidadxAsignar = pCantidadxAsignar;
        }
    }
}

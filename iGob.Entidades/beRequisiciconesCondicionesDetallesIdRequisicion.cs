using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.Entidades
{
    public class beRequisiciconesCondicionesDetallesIdRequisicion
    {
        public int IdRequisicion { get; set; }
        public int NoLote { get; set; }
        public decimal Cantidad { get; set; }
        public string BienServicio { get; set; }
        public int IdLote { get; set; }
        public string CantidadLotesxAsignar { get; set; }
        public decimal CantidadLoteAsignado { get; set; }
        public decimal CantidadxAsignar { get; set; }
        public beRequisiciconesCondicionesDetallesIdRequisicion()
        {

        }
        public beRequisiciconesCondicionesDetallesIdRequisicion(
            int pIdRequisicion,
int pNoLote,
decimal pCantidad,
string pBienServicio,
int pIdLote,
string pCantidadLotesxAsignar,
decimal pCantidadLoteAsignado,
decimal pCantidadxAsignar)
        {
            this.IdRequisicion = pIdRequisicion;
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

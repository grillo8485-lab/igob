using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.Entidades
{
    public class bePedidoDetallesLotesEntregas
    {
        public string BienServicio { get; set; }
        public int NoLote { get; set; }
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
        public decimal ImporteIva { get; set; }
        public decimal Total { get; set; }
        public int Frecuencia { get; set; }
        public string Lugar { get; set; }
        public string HorarioEntrega { get; set; }
        public string DiasEntrega { get; set; }
    }
}

using System;
using System.Data;

namespace iGob.Entidades
{
    public class beLicitacionesPedido
    {
        //Pedido
        public string Folio { get; set; }
        public DateTime FechaPedido { get; set; }
        public string RequisicionFolio { get; set; }
        public string Partida { get; set; }
        public string RazonSocial { get; set; }
        public string Rfc { get; set; }
        public string Calle { get; set; }
        public string NoExterior { get; set; }
        public string NoInterior { get; set; }
        public string Colonia { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string CodigoPostal { get; set; }
        public string Email { get; set; }
        public string Dependencia { get; set; }
        public string TipoCondicionPago { get; set; }        
        public string PlazoEntrega { get; set; }
        public string TipoEntrega { get; set; }
        public string Titulo { get; set; }


        //Pedido Detalles
        public int NoLote { get; set; }
        public string BienServicio { get; set; }
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
        public decimal ImporteIva { get; set; }
        public string Lugar { get; set; }
        public string HorarioEntrega { get; set; }
        public string DiasEntrega { get; set; }


        //Manifiestos
        public string Manifiesto { get; set; }


        //Firmantes
        public string Cargo { get; set; }
        public string Nombre { get; set; }

        public beLicitacionesPedido()
        {

        }

    }
}

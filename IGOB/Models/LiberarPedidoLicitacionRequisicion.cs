using iGob.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class LiberarPedidoLicitacionRequisicion
    {
        public bePedidosLicitaciones Pedido = new bePedidosLicitaciones();
        public string Partida = string.Empty;
        public string Dependencia = string.Empty;
        public string PlazoEntrega = string.Empty;
        public string PlazosTiempos = string.Empty;
        public string TiposDias = string.Empty;
        public string Estado = string.Empty;
        public string Municipio = string.Empty;
        public string Pais = string.Empty;
        public string Titulo = string.Empty;
        public string CondicionesEntrega = string.Empty;
        public string CondicionesPago = string.Empty;
        public DateTime Fecha = DateTime.MinValue;
        public beProveedores Proveedor = new beProveedores();
        public List<beManifiestoProveedoresDeclaratorias> lstManifiesto = new List<beManifiestoProveedoresDeclaratorias>();
        public List<bePedidosFirmantesLiberar> lstPedidosFirmantes = new List<bePedidosFirmantesLiberar>();
        public List<bePedidoDetallesLotesEntregas> lstPedidoDetallesLotesEntregas = new List<bePedidoDetallesLotesEntregas>();
        public int IdPerfil = int.MinValue;
        public int UltimaFirma = int.MinValue;
        public int UltimaFirmaIdFirmante = int.MinValue;
        public Decimal SutTotal = decimal.MinValue;
        public Decimal Impuesto = decimal.MinValue;
        public Decimal Total = decimal.MinValue;
        public string TotalLetras = String.Empty;
    }
}
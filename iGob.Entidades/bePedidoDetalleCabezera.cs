using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.Entidades
{
    public class bePedidoDetalleCabezera
    {
        public int IdPedido { get; set; }
        public string Folio { get; set; }
        
        public int IdEstatusPedido { get; set; }
        public string EstatusPedido { get; set; }

        public int IdRequisicion { get; set; }
        public string RequisicionFolio { get; set; }

        public string Rfc { get; set; }
        public string RazonSocial { get; set; }

        
        public DateTime Fecha { get; set; }

        public int IdLicitacion { get; set; }
        public string Licitacion { get; set; }
        public string FolioLicitacion { get; set; }

        public int IdProveedor { get; set; }
        public string Partida { get; set; }

        public string Dependencia { get; set; }
    }
}

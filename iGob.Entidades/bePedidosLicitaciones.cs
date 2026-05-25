using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.Entidades
{
    public class bePedidosLicitaciones
    {
        public int IdPedido { get; set; }
        public string Folio { get; set; }
        public int FolioNumero { get; set; }
        public int IdEstatusPedido { get; set; }
        public int IdRequisicion { get; set; }
        public string RequisicionFolio { get; set; }
        public string Rfc { get; set; }
        public string RazonSocial { get; set; }
        public int IdLicitacion { get; set; }
        public string EstatusPedido { get; set; }
        public int IdProveedor { get; set; }
        public string EstatusFirmaPedido { get; set; }
    }
}

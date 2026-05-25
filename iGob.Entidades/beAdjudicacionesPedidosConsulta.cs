using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iGob.Entidades
{
    public class beAdjudicacionesPedidosConsulta
    {
        public int IdAdjudicacionPedido { get; set; }
        public string Folio { get; set; }
        public int FolioNumero { get; set; }
        public int IdEstatusPedido { get; set; }
        public int IdAdjudicacion { get; set; }
        public string AdjudicacionFolio { get; set; }
        public string Rfc { get; set; }
        public string RazonSocial { get; set; }
        public int IdAdjudicacionProveedor { get; set; }
        public string EstatusPedido { get; set; }
        public int IdProveedor { get; set; }
        public string EstatusFirmaPedido { get; set; }

        public beAdjudicacionesPedidosConsulta()
        {

        }

        public beAdjudicacionesPedidosConsulta(int pIdAdjudicacionPedido,string pFolio,int pFolioNumero,int pIdEstatusPedido,int pIdAdjudicacion,string pAdjudicacionFolio,string pRfc,string pRazonSocial,
                                               int pIdAdjudicacionProveedor,string pEstatusPedido,int pIdProveedor,string pEstatusFirmaPedido)
        {
            this.IdAdjudicacionPedido = pIdAdjudicacionPedido;
            this.Folio = pFolio;
            this.FolioNumero = pFolioNumero;
            this.IdEstatusPedido = pIdEstatusPedido;
            this.IdAdjudicacion = pIdAdjudicacion;
            this.AdjudicacionFolio = pAdjudicacionFolio;
            this.Rfc = pRfc;
            this.RazonSocial = pRazonSocial;
            this.IdAdjudicacionProveedor = pIdAdjudicacionProveedor;
            this.EstatusPedido = pEstatusPedido;
            this.IdProveedor = pIdProveedor;
            this.EstatusFirmaPedido = pEstatusFirmaPedido;

        }
    }
}

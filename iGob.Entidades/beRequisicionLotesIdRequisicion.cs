using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.Entidades
{
    public class beRequisicionLotesIdRequisicion
    {

        public int IdLote { get; set; }
        public int IdRequisicion { get; set; }
        public int NoLote { get; set; }
        public int IdBienServicio { get; set; }
        public string Pantone { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
        public decimal PorcentajeImpuesto { get; set; }
        public decimal ImporteCImpuesto { get; set; }
        public decimal ImporteMesnsualCImpuesto { get; set; }
        public int MesesServicio { get; set; }
        public decimal Total { get; set; }
        public int MesInicial { get; set; }
        public int MesFinal { get; set; }
        public int Frecuencia { get; set; }
        public int IdMuestra { get; set; }
        public string Codigo { get; set; }
        public string ClaveCubs { get; set; }
        public string BienServicio { get; set; }
        public string Descripcion { get; set; }
        public int IdTipoProducto { get; set; }
        public int IdMarca { get; set; }
        public int IdFamilia { get; set; }
        public int IdUnidadMedida { get; set; }
        public string UnidadMedida { get; set; }
        public int IdImpuesto { get; set; }
        public string Muestra { get; set; }
        public string DesCricionMesInicial { get; set; }
        public string DesCricionMesFinal { get; set; }
        public string Impuesto { get; set; }
        public string DescripcionFrecuencia { get; set; }

        //nueva seccion de lotes de propuesta tecnica
        public int IdProveedorRqInvitacion { get; set; }
        public int IdEstatusEnvioPropuestaTecnica { get;set;}
        public int IdUsuaroEnviaPropuestaTecnica { get; set; }
        public DateTime FechaEnvioPropuestaTecnica { get; set; }
        public int IdEstatusEnvioPropuestaEconomica { get; set; }
        public int IdUsuaroEnviaPropuestaEconomica { get; set; }
        public DateTime FechaEnvioPropuestaEconomica { get; set; }
        public int IdPropuestaTecnicaEconomica { get; set; }
        public bool LoteOfertado { get; set; }
        public string Mejora { get; set; }
        public int EstatusMejora { get; set; }
        public decimal PrecioUnitarioRefencia { get; set; }
        public decimal PrecioUnitarioOfertado { get; set; }
        public decimal ImporteOfertado { get; set; }
        public decimal ImpuestoPorcentaje { get; set; }
        public decimal ImpuestoImporte { get; set; }
        public decimal TotalOfertado { get; set; }
        public string URLFileMuestraCatalogo { get; set; }
        public string URLFileCertificacion { get; set; }
        public decimal ImportePeriodo { get; set; }
        public decimal ImpuestoPeriodo { get; set; }
        public decimal TotalPeriodo { get; set; }
        public int IdMesInicial { get; set; }
        public int IdMesFinal { get; set; }
        public int IdEstatusPropuesta { get; set; }

        public bool AdquisicionCumple { get; set; }
        public string AdquisicionObserva{ get; set; }
        public bool DependenciaCumple{ get; set; }
        public string FundamentoLegal{ get; set; }

    public beRequisicionLotesIdRequisicion()
        {

        }

        public beRequisicionLotesIdRequisicion(int pIdLote,
    int pIdRequisicion,
    int pNoLote,
    int pIdBienServicio,
    string pPantone,
    decimal pCantidad,
    decimal pPrecioUnitario,
    decimal pImporte,
    decimal pPorcentajeImpuesto,
    decimal pImporteCImpuesto,
    decimal pImporteMesnsualCImpuesto,
    int pMesesServicio,
    decimal pTotal,
    int pMesInicial,
    int pMesFinal,
    int pFrecuencia,
    int pIdMuestra,
        string pCodigo,

    string pClaveCubs,

    string pBienServicio,

    string pDescripcion,

    int pIdTipoProducto,

    int pIdMarca,

    int pIdFamilia,

    int pIdUnidadMedida,
    string pUnidadMedida,
    int pIdImpuesto,

    string pMuestra,

    string pDesCricionMesInicial,

    string pDesCricionMesFinal,

    string pImpuesto,
    string pDescripcionFrecuencia)
        {
            this.IdLote = pIdLote;
            this.IdRequisicion = pIdRequisicion;
            this.NoLote = pNoLote;
            this.IdBienServicio = pIdBienServicio;
            this.Pantone = pPantone;
            this.Cantidad = pCantidad;
            this.PrecioUnitario = pPrecioUnitario;
            this.Importe = pImporte;
            this.PorcentajeImpuesto = pPorcentajeImpuesto;
            this.ImporteCImpuesto = pImporteCImpuesto;
            this.ImporteMesnsualCImpuesto = pImporteMesnsualCImpuesto;
            this.MesesServicio = pMesesServicio;
            this.Total = pTotal;
            this.MesInicial = pMesInicial;
            this.MesFinal = pMesFinal;
            this.Frecuencia = pFrecuencia;
            this.IdMuestra = pIdMuestra;
            this.Codigo = pCodigo;
            this.ClaveCubs = pClaveCubs;
            this.BienServicio = pBienServicio;
            this.Descripcion = pDescripcion;
            this.IdTipoProducto = pIdTipoProducto;
            this.IdMarca = pIdMarca;
            this.IdFamilia = pIdFamilia;
            this.IdUnidadMedida = pIdUnidadMedida;
            this.UnidadMedida = pUnidadMedida;
            this.IdImpuesto = pIdImpuesto;
            this.Muestra = pMuestra;
            this.DesCricionMesInicial = pDesCricionMesInicial;
            this.DesCricionMesFinal = pDesCricionMesFinal;
            this.Impuesto = pImpuesto;
            this.DescripcionFrecuencia = pDescripcionFrecuencia;
        }
    }
}

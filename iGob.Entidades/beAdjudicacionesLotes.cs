using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class beAdjudicacionesLotes
    {

        public int IdLote { get; set; }
        public int IdAdjudicacion { get; set; }
        public int NoLote { get; set; }
        public int IdBienServicio { get; set; }
        public string Pantone { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
        public decimal PorcentajeImpuesto { get; set; }
        public decimal ImporteCImpuesto { get; set; }
        public decimal ImporteMensualCImpuesto { get; set; }
        public int MesesServicio { get; set; }
        public decimal Total { get; set; }
        public int IdMesInicial { get; set; }
        public string IdMesFinal { get; set; }
        public int IdFrecuencia { get; set; }
        public int IdMuestra { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioRegistro { get; set; }

        // Adicionales....
        public string Codigo { get; set; }
        public string ClaveCubs { get; set; }
        public string BienServicio { get; set; }
        public string Descripcion { get; set; }
        public int IdModificador { get; set; }
        public int IdTipoProducto { get; set; }
        public int IdMarca { get; set; }
        public int IdFamilia { get; set; }
        public int IdUnidadMedida { get; set; }
        public int IdImpuesto { get; set; }
        public decimal BsPrecioUnitario { get; set; }
        public int IdPartida { get; set; }
        public decimal PrecioUnitarioMejorLicitado { get; set; }
        public int IdCertificacion { get; set; }
        public int IdTipoMoneda { get; set; }
        public bool Activo { get; set; }
        public string TipoProducto { get; set; }
        public string Marca { get; set; }
        public string UnidadMedida { get; set; }
        public string Familia { get; set; }
        public string Impuesto { get; set; }
        public string Certificacion { get; set; }
        public string Partida { get; set; }

        public string Modificador { get; set; }
        public string Muestra { get; set; }
        public string DescripcionMesInicial { get; set; }
        public string DescripcionMesFinal { get; set; }
        public string DescripcionFrecuencia { get; set; }

        public bool ActivoLote { get; set; }
        public int IdAdjudicionPropuestaTecEco { get; set; }
        public int IdProveedor { get; set; }

        public beAdjudicacionesLotes()
        {

        }

        public beAdjudicacionesLotes(int pIdLote, int pIdAdjudicacion, int pNoLote, int pIdBienServicio, string pPantone, decimal pCantidad, decimal pPrecioUnitario, decimal pImporte, decimal pPorcentajeImpuesto, 
            decimal pImporteCImpuesto, decimal pImporteMensualCImpuesto, int pMesesServicio, decimal pTotal, int pIdMesInicial, string pIdMesFinal, int pIdFrecuencia, int pIdMuestra, DateTime pFechaRegistro, int pIdUsuarioRegistro,

            string pCodigo, string pClaveCubs, string pBienServicio, string pDescripcion, int pIdModificador, int pIdTipoProducto, int pIdMarca, int pIdFamilia, int pIdUnidadMedida, int pIdImpuesto, decimal pBsPrecioUnitario, int pIdPartida, decimal pPrecioUnitarioMejorLicitado, int pIdCertificacion, int pIdTipoMoneda, bool pActivo, string pTipoProducto, string pMarca, string pUnidadMedida, string pFamilia, string pImpuesto, string pCertificacion, string pPartida, string pModificador,
            string pMuestra, string pDescripcionMesInicial, string pDescripcionMesFinal, string pDescripcionFrecuencia
            )
        {
            this.IdLote = pIdLote;
            this.IdAdjudicacion = pIdAdjudicacion;
            this.NoLote = pNoLote;
            this.IdBienServicio = pIdBienServicio;
            this.Pantone = pPantone;
            this.Cantidad = pCantidad;
            this.PrecioUnitario = pPrecioUnitario;
            this.Importe = pImporte;
            this.PorcentajeImpuesto = pPorcentajeImpuesto;
            this.ImporteCImpuesto = pImporteCImpuesto;
            this.ImporteMensualCImpuesto = pImporteMensualCImpuesto;
            this.MesesServicio = pMesesServicio;
            this.Total = pTotal;
            this.IdMesInicial = pIdMesInicial;
            this.IdMesFinal = pIdMesFinal;
            this.IdFrecuencia = pIdFrecuencia;
            this.IdMuestra = pIdMuestra;
            this.FechaRegistro = pFechaRegistro;
            this.IdUsuarioRegistro = pIdUsuarioRegistro;

            this.Codigo = pCodigo;
            this.ClaveCubs = pClaveCubs;
            this.BienServicio = pBienServicio;
            this.Descripcion = pDescripcion;
            this.IdModificador = IdModificador ;
            this.IdTipoProducto = IdTipoProducto;
            this.IdMarca = pIdMarca;
            this.IdFamilia = pIdFamilia;
            this.IdUnidadMedida = pIdUnidadMedida;
            this.IdImpuesto = pIdImpuesto;
            this.BsPrecioUnitario = pBsPrecioUnitario;
            this.IdPartida = pIdPartida;
            this.PrecioUnitarioMejorLicitado = pPrecioUnitarioMejorLicitado;
            this.IdCertificacion = pIdCertificacion;
            this.IdTipoMoneda = pIdTipoMoneda;
            this.Activo = pActivo;
            this.TipoProducto = pTipoProducto;
            this.Marca = pMarca;
            this.UnidadMedida = pUnidadMedida;
            this.Familia = pFamilia;
            this.Impuesto = pImpuesto;
            this.Certificacion = pCertificacion;
            this.Partida = pPartida;
            this.Modificador = pModificador;
            this.Muestra = pModificador;
            this.DescripcionMesInicial = pDescripcionMesInicial;
            this.DescripcionMesFinal = pDescripcionMesFinal;
            this.DescripcionFrecuencia = pDescripcionFrecuencia;


        }


    }
}

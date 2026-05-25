using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beRequisicionesLotes {

	public int IdLote { get; set;}
	public int IdRequisicion { get; set;}
	public int NoLote { get; set;}
	public int IdBienServicio { get; set;}
	public string Pantone { get; set;}
	public decimal Cantidad { get; set;}
	public decimal PrecioUnitario { get; set;}
	public decimal Importe { get; set;}
	public decimal PorcentajeImpuesto { get; set;}
	public decimal ImporteCImpuesto { get; set;}
	public decimal ImporteMesnsualCImpuesto { get; set;}
	public int MesesServicio { get; set;}
	public decimal Total { get; set;}
	public int MesInicial { get; set;}
	public int MesFinal { get; set;}
	public int Frecuencia { get; set;}
        public int IdMuestra { get; set; }
        public DateTime FechaRegistro { get; set;}
	public int IdUsuarioRegistro { get; set;}

	public beRequisicionesLotes()
	{
		
	}

	public beRequisicionesLotes( int pIdLote, int pIdRequisicion, int pNoLote, int pIdBienServicio, string pPantone, decimal pCantidad, decimal pPrecioUnitario, decimal pImporte, decimal pPorcentajeImpuesto, decimal pImporteCImpuesto, decimal pImporteMesnsualCImpuesto, int pMesesServicio, decimal pTotal, int pMesInicial, int pMesFinal, int pFrecuencia,int pIdMuestra, DateTime pFechaRegistro, int pIdUsuarioRegistro)
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

        this.FechaRegistro = pFechaRegistro;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
	}


}
}

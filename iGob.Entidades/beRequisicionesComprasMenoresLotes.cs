using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beRequisicionesComprasMenoresLotes {

	public int IdLoteCompraMenor { get; set;}
	public int IdRequisicionCompraMenor { get; set;}
	public int NoLote { get; set;}
	public int IdBienServicio { get; set;}
	public string Concepto { get; set;}
	public int IdTipoBienServicio { get; set;}
	public decimal Cantidad { get; set;}
	public decimal PrecioUnitario { get; set;}
	public decimal Importe { get; set;}
	public decimal PorcentajeImpuesto { get; set;}
	public decimal ImporteImpuesto { get; set;}
	public decimal Total { get; set;}
	public DateTime FechaRegistro { get; set;}
	public int IdUsuarioRegistro { get; set;}

    /* Get All 28/08/2018 */
    public string RequisicionFolio { get; set;}
    public int IdEjercicioFiscal { get; set;}
    public string Ejercicio { get; set;}
    public int IdOrigenRecurso { get; set;}
    public string OrigenRecurso { get; set;}

    /* Get All All Req Compras Menores 29/08/2018 */

	public int IdDependencia { get; set;}
	public string Departamento { get; set;}
	public int IdEstatusRequisicion { get; set;}
	public int IdPartida { get; set;}
	public int IdClavePresupuestal { get; set;}
	public DateTime FechaRequisicion { get; set;}
	public int ConsecutivoRequisicion { get; set;}
	public decimal MontoAproximado { get; set;}
	public int CantidadLotes { get; set;}
	public decimal ImporteTotalLotes { get; set;}
	public string Observaciones { get; set;}
	public string Justificacion { get; set;}
	public DateTime FechaEntrega { get; set;}
	public string LugarEntrega { get; set;}
	public DateTime FechaPago { get; set;}
	public string LugarPago { get; set;}

    public string Dependencia { get; set;}
    public string Partida { get; set;}
    public string RazonSocial { get; set;}

    public decimal TotalFinal { get; set; }

	public beRequisicionesComprasMenoresLotes()
	{
		
	}

	public beRequisicionesComprasMenoresLotes( int pIdLoteCompraMenor, int pIdRequisicionCompraMenor, int pNoLote, int pIdBienServicio, string pConcepto, int pIdTipoBienServicio, decimal pCantidad, decimal pPrecioUnitario, decimal pImporte, decimal pPorcentajeImpuesto, decimal pImporteImpuesto, decimal pTotal, DateTime pFechaRegistro, int pIdUsuarioRegistro, decimal pTotalFinal)
	{
		this.IdLoteCompraMenor = pIdLoteCompraMenor;
		this.IdRequisicionCompraMenor = pIdRequisicionCompraMenor;
		this.NoLote = pNoLote;
		this.IdBienServicio = pIdBienServicio;
		this.Concepto = pConcepto;
		this.IdTipoBienServicio = pIdTipoBienServicio;
		this.Cantidad = pCantidad;
		this.PrecioUnitario = pPrecioUnitario;
		this.Importe = pImporte;
		this.PorcentajeImpuesto = pPorcentajeImpuesto;
		this.ImporteImpuesto = pImporteImpuesto;
		this.Total = pTotal;
		this.FechaRegistro = pFechaRegistro;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
        this.TotalFinal = pTotalFinal;
	}


}
}

using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beAdjudicacionesCondicionesEntregas {

	public int IdAdjudicacionCondicionEntrega { get; set;}
	public int IdAdjudicacion { get; set;}
	public int IdTipoDia { get; set;}
	public int IdPlazoEntegra { get; set;}
	public int IdPlazoTiempo { get; set;}
	public int PlazoEntregaCantidad { get; set;}
	public DateTime FechaLimite { get; set;}
	public int IdTipoEntrega { get; set;}
	public string Observaciones { get; set;}
	public string NotaEspecial { get; set;}
	public int IdEstatus { get; set;}
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}
    public bool IsNUll { get; set; }

        public beAdjudicacionesCondicionesEntregas()
	{
            this.IsNUll = true;
    }

        public beAdjudicacionesCondicionesEntregas( int pIdAdjudicacionCondicionEntrega, int pIdAdjudicacion, int pIdTipoDia, int pIdPlazoEntegra, int pIdPlazoTiempo, int pPlazoEntregaCantidad, DateTime pFechaLimite, int pIdTipoEntrega, string pObservaciones, string pNotaEspecial, int pIdEstatus, int pIdUsuarioRegistro, DateTime pFechaRegistro, bool pIsNull)
	{
		this.IdAdjudicacionCondicionEntrega = pIdAdjudicacionCondicionEntrega;
		this.IdAdjudicacion = pIdAdjudicacion;
		this.IdTipoDia = pIdTipoDia;
		this.IdPlazoEntegra = pIdPlazoEntegra;
		this.IdPlazoTiempo = pIdPlazoTiempo;
		this.PlazoEntregaCantidad = pPlazoEntregaCantidad;
		this.FechaLimite = pFechaLimite;
		this.IdTipoEntrega = pIdTipoEntrega;
		this.Observaciones = pObservaciones;
		this.NotaEspecial = pNotaEspecial;
		this.IdEstatus = pIdEstatus;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
            this.IsNUll = pIsNull;
	}


}
}

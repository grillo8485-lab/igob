using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beAdjudicacionesPedidosFirmantes {

	public int IdAdjudicacionPedidoFirmante { get; set;}
	public int IdAdjudicacionPedido { get; set;}
	public int IdPerfil { get; set;}
	public int Ordenamiento { get; set;}
	public string Cargo { get; set;}
	public int IdEstatusFirmaPedido { get; set;}
	public int IdUsuarioFirmante { get; set;}
	public DateTime FechaFirma { get; set;}

	public beAdjudicacionesPedidosFirmantes()
	{
		
	}

	public beAdjudicacionesPedidosFirmantes( int pIdAdjudicacionPedidoFirmante, int pIdAdjudicacionPedido, int pIdPerfil, int pOrdenamiento, string pCargo, int pIdEstatusFirmaPedido, int pIdUsuarioFirmante, DateTime pFechaFirma)
	{
		this.IdAdjudicacionPedidoFirmante = pIdAdjudicacionPedidoFirmante;
		this.IdAdjudicacionPedido = pIdAdjudicacionPedido;
		this.IdPerfil = pIdPerfil;
		this.Ordenamiento = pOrdenamiento;
		this.Cargo = pCargo;
		this.IdEstatusFirmaPedido = pIdEstatusFirmaPedido;
		this.IdUsuarioFirmante = pIdUsuarioFirmante;
		this.FechaFirma = pFechaFirma;
	}


}
}

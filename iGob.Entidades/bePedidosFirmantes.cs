using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class bePedidosFirmantes {

	public int IdPedidoFirmante { get; set;}
	public int IdPedido { get; set;}
	public int IdPerfil { get; set;}
	public int Ordenamiento { get; set;}
	public string Cargo { get; set;}
	public int IdEstatusFirmaPedido { get; set;}
	public int IdUsuarioFirmante { get; set;}
	public DateTime FechaFirma { get; set;}

	public bePedidosFirmantes()
	{
		
	}

	public bePedidosFirmantes( int pIdPedidoFirmante, int pIdPedido, int pIdPerfil, int pOrdenamiento, string pCargo, int pIdEstatusFirmaPedido, int pIdUsuarioFirmante, DateTime pFechaFirma)
	{
		this.IdPedidoFirmante = pIdPedidoFirmante;
		this.IdPedido = pIdPedido;
		this.IdPerfil = pIdPerfil;
		this.Ordenamiento = pOrdenamiento;
		this.Cargo = pCargo;
		this.IdEstatusFirmaPedido = pIdEstatusFirmaPedido;
		this.IdUsuarioFirmante = pIdUsuarioFirmante;
		this.FechaFirma = pFechaFirma;
	}


}
}

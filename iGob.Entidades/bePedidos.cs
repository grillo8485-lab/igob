using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class bePedidos {

	public int IdPedido { get; set;}
	public int IdProveedorRqInvitacion { get; set;}
	public int FolioNumero { get; set;}
	public string Folio { get; set;}
	public DateTime FechaPedido { get; set;}
	public int IdProveedor { get; set;}
	public int IdRequisicion { get; set;}
	public decimal Importe { get; set;}
	public decimal ImporteIva { get; set;}
	public decimal Total { get; set;}
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}
	public int IdEstatusPedido { get; set;}

	public bePedidos()
	{
		
	}

	public bePedidos( int pIdPedido, int pIdProveedorRqInvitacion, int pFolioNumero, string pFolio, DateTime pFechaPedido, int pIdProveedor, int pIdRequisicion, decimal pImporte, decimal pImporteIva, decimal pTotal, int pIdUsuarioRegistro, DateTime pFechaRegistro, int pIdEstatusPedido)
	{
		this.IdPedido = pIdPedido;
		this.IdProveedorRqInvitacion = pIdProveedorRqInvitacion;
		this.FolioNumero = pFolioNumero;
		this.Folio = pFolio;
		this.FechaPedido = pFechaPedido;
		this.IdProveedor = pIdProveedor;
		this.IdRequisicion = pIdRequisicion;
		this.Importe = pImporte;
		this.ImporteIva = pImporteIva;
		this.Total = pTotal;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
		this.IdEstatusPedido = pIdEstatusPedido;
	}


}
}

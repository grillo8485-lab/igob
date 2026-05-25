using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beLicitacionesInvitacionProveedores {

	public int IdInvitacion { get; set;}
	public int IdLicitacion { get; set;}
	public int IdProveedor { get; set;}
	public int IdProveedorGiroComercial { get; set;}
	public bool Aceptacion { get; set;}
	public DateTime FechaAceptacion { get; set;}
	public string FolioPago { get; set;}
	public DateTime FechaPago { get; set;}
	public string UrlRecibo { get; set;}
	public string Observaciones { get; set;}
	public int IdEstatusPago { get; set;}
	public DateTime FechaValidaPago { get; set;}
	public TimeSpan TiempoValidaPago { get; set;}
	public int IdTipoTiempoValidaPago { get; set;}
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}
	public int IdRazonRechazo { get; set;}
	public int Activo { get; set;}

	public beLicitacionesInvitacionProveedores()
	{
		
	}

	public beLicitacionesInvitacionProveedores( int pIdInvitacion, int pIdLicitacion, int pIdProveedor, int pIdProveedorGiroComercial, bool pAceptacion, DateTime pFechaAceptacion, string pFolioPago, DateTime pFechaPago, string pUrlRecibo, string pObservaciones, int pIdEstatusPago, DateTime pFechaValidaPago, TimeSpan pTiempoValidaPago, int pIdTipoTiempoValidaPago, int pIdUsuarioRegistro, DateTime pFechaRegistro, int pIdRazonRechazo, int pActivo)
	{
		this.IdInvitacion = pIdInvitacion;
		this.IdLicitacion = pIdLicitacion;
		this.IdProveedor = pIdProveedor;
		this.IdProveedorGiroComercial = pIdProveedorGiroComercial;
		this.Aceptacion = pAceptacion;
		this.FechaAceptacion = pFechaAceptacion;
		this.FolioPago = pFolioPago;
		this.FechaPago = pFechaPago;
		this.UrlRecibo = pUrlRecibo;
		this.Observaciones = pObservaciones;
		this.IdEstatusPago = pIdEstatusPago;
		this.FechaValidaPago = pFechaValidaPago;
		this.TiempoValidaPago = pTiempoValidaPago;
		this.IdTipoTiempoValidaPago = pIdTipoTiempoValidaPago;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
		this.IdRazonRechazo = pIdRazonRechazo;
		this.Activo = pActivo;
	}


}
}

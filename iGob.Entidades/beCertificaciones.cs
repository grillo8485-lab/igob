using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beCertificaciones {

	public int IdCertificacion { get; set;}
	public string Certificacion { get; set;}
	public string NoCertificacion { get; set;}
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}

	public beCertificaciones()
	{
		
	}

	public beCertificaciones( int pIdCertificacion, string pCertificacion, string pNoCertificacion, int pIdUsuarioRegistro, DateTime pFechaRegistro)
	{
		this.IdCertificacion = pIdCertificacion;
		this.Certificacion = pCertificacion;
		this.NoCertificacion = pNoCertificacion;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
	}


}
}

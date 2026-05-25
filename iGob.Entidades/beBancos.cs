using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beBancos {

	public int IdBanco { get; set;}
	public string Clave { get; set;}
	public string NombreCorto { get; set;}
	public string NombreRazonSocial { get; set;}
	public string RFC { get; set;}
	public string Estatus { get; set;}
	public bool Activo { get; set;}

	public beBancos()
	{
		
	}

	public beBancos( int pIdBanco, string pClave, string pNombreCorto, string pNombreRazonSocial, string pRFC, string pEstatus, bool pActivo)
	{
		this.IdBanco = pIdBanco;
		this.Clave = pClave;
		this.NombreCorto = pNombreCorto;
		this.NombreRazonSocial = pNombreRazonSocial;
		this.RFC = pRFC;
		this.Estatus = pEstatus;
		this.Activo = pActivo;
	}


}
}

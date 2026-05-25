using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beDependencias {

	public int IdDependencia { get; set;}
	public string Dependencia { get; set;}
	public string Abreviatura { get; set;}
	public string Sitiooficial { get; set;}
	public string Titular { get; set;}
	public string Rfc { get; set;}
	public string Calle { get; set;}
	public string NoExterior { get; set;}
	public string NoInterior { get; set;}
	public string IdMunicipio { get; set;}
	public string Colonia { get; set;}
	public string CodigoPostal { get; set;}
	public string Telefono { get; set;}
	public string Email { get; set;}
	public string Logo { get; set;}
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}
	public string Localidad { get; set;}
    public string Municipio { get; set; }
    public string ClaveEstado { get; set; }
    public string Estado { get; set; }
    public int IdGobierno { get; set; }

	public beDependencias()
	{
		
	}

	public beDependencias( int pIdDependencia, string pDependencia, string pAbreviatura, string pSitiooficial, string pTitular, string pRfc, string pCalle, string pNoExterior, string pNoInterior, string pIdMunicipio, string pColonia, string pCodigoPostal, string pTelefono, string pEmail, string pLogo, int pIdUsuarioRegistro, DateTime pFechaRegistro, string plocalidad, int pIdGobierno)
	{
		this.IdDependencia = pIdDependencia;
		this.Dependencia = pDependencia;
		this.Abreviatura = pAbreviatura;
		this.Sitiooficial = pSitiooficial;
		this.Titular = pTitular;
		this.Rfc = pRfc;
		this.Calle = pCalle;
		this.NoExterior = pNoExterior;
		this.NoInterior = pNoInterior;
		this.IdMunicipio = pIdMunicipio;
		this.Colonia = pColonia;
		this.CodigoPostal = pCodigoPostal;
		this.Telefono = pTelefono;
		this.Email = pEmail;
		this.Logo = pLogo;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
		this.Localidad = plocalidad;
        this.IdGobierno = pIdGobierno;
	}


}
}

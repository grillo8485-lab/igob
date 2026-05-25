using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beFormasPago {

	public int IdFormaPago { get; set;}
	public string Clave { get; set;}
	public string FormaPago { get; set;}
	public string Bancarizado { get; set;}
	public DateTime Fechainiciovigencia { get; set;}
	public string Version { get; set;}
	public bool Activo { get; set;}

	public beFormasPago()
	{
		
	}

	public beFormasPago( int pIdFormaPago, string pClave, string pFormaPago, string pBancarizado, DateTime pFechainiciovigencia, string pVersion, bool pActivo)
	{
		this.IdFormaPago = pIdFormaPago;
		this.Clave = pClave;
		this.FormaPago = pFormaPago;
		this.Bancarizado = pBancarizado;
		this.Fechainiciovigencia = pFechainiciovigencia;
		this.Version = pVersion;
		this.Activo = pActivo;
	}


}
}

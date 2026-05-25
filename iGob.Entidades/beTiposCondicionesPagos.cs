using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beTiposCondicionesPagos {

	public int IdTipoCondicionPago { get; set;}
	public string TipoCondicionPago { get; set;}

	public beTiposCondicionesPagos()
	{
		
	}

	public beTiposCondicionesPagos( int pIdTipoCondicionPago, string pTipoCondicionPago)
	{
		this.IdTipoCondicionPago = pIdTipoCondicionPago;
		this.TipoCondicionPago = pTipoCondicionPago;
	}


}
}

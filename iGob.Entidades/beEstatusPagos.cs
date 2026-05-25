using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beEstatusPagos {

	public int IdEstatusPago { get; set;}
	public string Estatus { get; set;}
	public bool Activo { get; set;}

	public beEstatusPagos()
	{
		
	}

	public beEstatusPagos( int pIdEstatusPago, string pEstatus, bool pActivo)
	{
		this.IdEstatusPago = pIdEstatusPago;
		this.Estatus = pEstatus;
		this.Activo = pActivo;
	}


}
}

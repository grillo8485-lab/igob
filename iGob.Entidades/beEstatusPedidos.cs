using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beEstatusPedidos {

	public int IdEstatusPedido { get; set;}
	public string Estatus { get; set;}
	public bool Activo { get; set;}

	public beEstatusPedidos()
	{
		
	}

	public beEstatusPedidos( int pIdEstatusPedido, string pEstatus, bool pActivo)
	{
		this.IdEstatusPedido = pIdEstatusPedido;
		this.Estatus = pEstatus;
		this.Activo = pActivo;
	}


}
}

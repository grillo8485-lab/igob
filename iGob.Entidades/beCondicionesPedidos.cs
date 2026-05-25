using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beCondicionesPedidos {

	public int IdCondicionPedido { get; set;}
	public int IdGobierno { get; set;}
	public int Consecutivo { get; set;}
	public string CondicionPedido { get; set;}
	public bool Activo { get; set;}
    
    /* Gobierno 24/08/2018 */
    public string Gobierno { get; set;}

	public beCondicionesPedidos()
	{
		
	}

	public beCondicionesPedidos( int pIdCondicionPedido, int pIdGobierno, int pConsecutivo, string pCondicionPedido, bool pActivo)
	{
		this.IdCondicionPedido = pIdCondicionPedido;
		this.IdGobierno = pIdGobierno;
		this.Consecutivo = pConsecutivo;
		this.CondicionPedido = pCondicionPedido;
		this.Activo = pActivo;
	}


}
}

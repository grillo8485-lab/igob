using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beCondicionesPagosEntrega {

	public int IdCondicion { get; set;}
	public string Condicion { get; set;}
	public int IdTipoCondicion { get; set;}
	public bool Activo { get; set;}

    /* TiposCondiciones 24/08/2018 */
    public string TipoCondicion { get; set;}
    /**/

	public beCondicionesPagosEntrega()
	{
		
	}

	public beCondicionesPagosEntrega( int pIdCondicion, string pCondicion, int pIdTipoCondicion, bool pActivo)
	{
		this.IdCondicion = pIdCondicion;
		this.Condicion = pCondicion;
		this.IdTipoCondicion = pIdTipoCondicion;
		this.Activo = pActivo;
	}


}
}

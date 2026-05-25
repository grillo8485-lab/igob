using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beManifiestos {

	public int IdManifiesto { get; set;}
	public int IdGobierno { get; set;}
	public string Manifiesto { get; set;}
	public bool Activo { get; set;}
    
    /* Gobierno 24/08/2018 */
    public string Gobierno { get; set;}
    /**/

	public beManifiestos()
	{
		
	}

	public beManifiestos( int pIdManifiesto, int pIdGobierno, string pManifiesto, bool pActivo)
	{
		this.IdManifiesto = pIdManifiesto;
		this.IdGobierno = pIdGobierno;
		this.Manifiesto = pManifiesto;
		this.Activo = pActivo;
	}


}
}

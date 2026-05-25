using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beCapitulos {

	public int IdCapitulo { get; set;}
	public int ClaveCapitulo { get; set;}
	public string Capitulo { get; set;}
	public bool Activo { get; set;}

	public beCapitulos()
	{
		
	}

	public beCapitulos( int pIdCapitulo, int pClaveCapitulo, string pCapitulo, bool pActivo)
	{
		this.IdCapitulo = pIdCapitulo;
		this.ClaveCapitulo = pClaveCapitulo;
		this.Capitulo = pCapitulo;
		this.Activo = pActivo;
	}


}
}

using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beReactivosConclusionEM {

	public int IdReactivoConclusionEM { get; set;}
	public string Reactivo { get; set;}
	public bool Activo { get; set;}

	public beReactivosConclusionEM()
	{
		
	}

	public beReactivosConclusionEM( int pIdReactivoConclusionEM, string pReactivo, bool pActivo)
	{
		this.IdReactivoConclusionEM = pIdReactivoConclusionEM;
		this.Reactivo = pReactivo;
		this.Activo = pActivo;
	}


}
}

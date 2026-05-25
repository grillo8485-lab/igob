using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beUnidadesLicitadoras {

	public int IdUnidadLicitadora { get; set;}
	public int IdDependencia { get; set;}
	public string UnidadLicitadora { get; set;}
	public bool Activo { get; set;}
    
    /* Dependencia 24/08/2018 */
    public string Dependencia { get; set;}

	public beUnidadesLicitadoras()
	{
		
	}

	public beUnidadesLicitadoras( int pIdUnidadLicitadora, int pIdDependencia, string pUnidadLicitadora, bool pActivo)
	{
		this.IdUnidadLicitadora = pIdUnidadLicitadora;
		this.IdDependencia = pIdDependencia;
		this.UnidadLicitadora = pUnidadLicitadora;
		this.Activo = pActivo;
	}


}
}

using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beModalidades {

	public int IdModalidad { get; set;}
	public string Modalidad { get; set;}
	public string Abreviatura { get; set;}
	public bool Activo { get; set;}

	public beModalidades()
	{
		
	}

	public beModalidades( int pIdModalidad, string pModalidad, string pAbreviatura, bool pActivo)
	{
		this.IdModalidad = pIdModalidad;
		this.Modalidad = pModalidad;
		this.Abreviatura = pAbreviatura;
		this.Activo = pActivo;
	}


}
}

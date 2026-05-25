using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beOrigenRecurso {

	public int IdOrigenRecurso { get; set;}
	public string OrigenRecurso { get; set;}
	public string Descripcion { get; set;}
	public bool Activo { get; set;}

	public beOrigenRecurso()
	{
		
	}

	public beOrigenRecurso( int pIdOrigenRecurso, string pOrigenRecurso, string pDescripcion, bool pActivo)
	{
		this.IdOrigenRecurso = pIdOrigenRecurso;
		this.OrigenRecurso = pOrigenRecurso;
		this.Descripcion = pDescripcion;
		this.Activo = pActivo;
	}


}
}

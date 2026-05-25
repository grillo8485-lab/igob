using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beModalidadesLicitaciones {

	public int IdModalidadLicitacion { get; set;}
	public string ModalidadLicitacion { get; set;}
	public string Abreviatura { get; set;}
	public bool Activo { get; set;}

	public beModalidadesLicitaciones()
	{
		
	}

	public beModalidadesLicitaciones( int pIdModalidadLicitacion, string pModalidadLicitacion, string pAbreviatura, bool pActivo)
	{
		this.IdModalidadLicitacion = pIdModalidadLicitacion;
		this.ModalidadLicitacion = pModalidadLicitacion;
		this.Abreviatura = pAbreviatura;
		this.Activo = pActivo;
	}


}
}

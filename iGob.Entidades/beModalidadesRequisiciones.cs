using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beModalidadesRequisiciones {

	public int IdModalidadRequisicion { get; set;}
	public string ModalidadRequisicion { get; set;}
	public string Abreviatura { get; set;}
	public bool Activo { get; set;}

	public beModalidadesRequisiciones()
	{
		
	}

	public beModalidadesRequisiciones( int pIdModalidadRequisicion, string pModalidadRequisicion, string pAbreviatura, bool pActivo)
	{
		this.IdModalidadRequisicion = pIdModalidadRequisicion;
		this.ModalidadRequisicion = pModalidadRequisicion;
		this.Abreviatura = pAbreviatura;
		this.Activo = pActivo;
	}


}
}

using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beFamilias {

	public int IdFamilia { get; set;}
	public string Familia { get; set;}
	public string Descripcion { get; set;}
	public bool Activo { get; set;}

	public beFamilias()
	{
		
	}

	public beFamilias( int pIdFamilia, string pFamilia, string pDescripcion, bool pActivo)
	{
		this.IdFamilia = pIdFamilia;
		this.Familia = pFamilia;
		this.Descripcion = pDescripcion;
		this.Activo = pActivo;
	}


}
}

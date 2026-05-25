using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beActividadesEconomicas {

	public int IdActividadEconomica { get; set;}
	public int Codigo { get; set;}
	public string Descripcion { get; set;}
	public bool Activo { get; set;}

	public beActividadesEconomicas()
	{
		
	}

	public beActividadesEconomicas( int pIdActividadEconomica, int pCodigo, string pDescripcion, bool pActivo)
	{
		this.IdActividadEconomica = pIdActividadEconomica;
		this.Codigo = pCodigo;
		this.Descripcion = pDescripcion;
		this.Activo = pActivo;
	}


}
}

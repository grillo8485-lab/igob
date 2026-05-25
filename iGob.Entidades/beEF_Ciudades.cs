using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace igob.Entidades
{
public class beEF_Ciudades {

	public string IdCiudad { get; set;}
	public string Ciudad { get; set;}

	public beEF_Ciudades()
	{
		
	}

	public beEF_Ciudades( string pIdCiudad, string pCiudad)
	{
		this.IdCiudad = pIdCiudad;
		this.Ciudad = pCiudad;
	}


}
}

using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beFormaAbastecimiento {

	public int IdFormaAbastecimiento { get; set;}
	public string FormaAbastecimiento { get; set;}
	public bool Activo { get; set;}

	public beFormaAbastecimiento()
	{
		
	}

	public beFormaAbastecimiento( int pIdFormaAbastecimiento, string pFormaAbastecimiento, bool pActivo)
	{
		this.IdFormaAbastecimiento = pIdFormaAbastecimiento;
		this.FormaAbastecimiento = pFormaAbastecimiento;
		this.Activo = pActivo;
	}


}
}

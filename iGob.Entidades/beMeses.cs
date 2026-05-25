using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beMeses {

	public int IdMes { get; set;}
	public string Mes { get; set;}

	public beMeses()
	{
		
	}

	public beMeses( int pIdMes, string pMes)
	{
		this.IdMes = pIdMes;
		this.Mes = pMes;
	}


}
}

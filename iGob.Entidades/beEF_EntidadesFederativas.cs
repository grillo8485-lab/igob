using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beEF_EntidadesFederativas {

	public string ClaveEstado { get; set;}
	public string Clave { get; set;}
	public string Estado { get; set;}
	public string AbreviacionEdo { get; set;}
	public int IdPais { get; set;}

        public int ClaveEstado2 { get; set; }

    public beEF_EntidadesFederativas()
	{
		
	}

	public beEF_EntidadesFederativas( string pClaveEstado, string pClave, string pEstado, string pAbreviacionEdo, int pIdPais)
	{
		this.ClaveEstado = pClaveEstado;
		this.Clave = pClave;
		this.Estado = pEstado;
		this.AbreviacionEdo = pAbreviacionEdo;
		this.IdPais = pIdPais;
	}


}
}

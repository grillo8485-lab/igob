using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beDepartamentos {

	public int IdDepartamento { get; set;}
	public string Departamento { get; set;}
	public int IdDependencia { get; set;}
	public string Responsable { get; set;}
	public bool Activo { get; set;}

	public beDepartamentos()
	{
		
	}

	public beDepartamentos( int pIdDepartamento, string pDepartamento, int pIdDependencia, string pResponsable, bool pActivo)
	{
		this.IdDepartamento = pIdDepartamento;
		this.Departamento = pDepartamento;
		this.IdDependencia = pIdDependencia;
		this.Responsable = pResponsable;
		this.Activo = pActivo;
	}


}
}

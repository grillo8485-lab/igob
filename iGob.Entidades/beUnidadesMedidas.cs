using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beUnidadesMedidas {

	public int IdUnidadMedida { get; set;}
	public string ClaveUnidadMedida { get; set;}
	public string UnidadMedida { get; set;}
	public string Descripcion { get; set;}
	public DateTime? FechaVigenciaInicial { get; set;}
	public string Simbolo { get; set;}
	public string Version { get; set;}
	public string Formato { get; set;}
	public bool Activo { get; set;}

	public beUnidadesMedidas()
	{
		
	}

	public beUnidadesMedidas( int pIdUnidadMedida, string pClaveUnidadMedida, string pUnidadMedida, string pDescripcion, DateTime pFechaVigenciaInicial, string pSimbolo, string pVersion, string pFormato, bool pActivo)
	{
		this.IdUnidadMedida = pIdUnidadMedida;
		this.ClaveUnidadMedida = pClaveUnidadMedida;
		this.UnidadMedida = pUnidadMedida;
		this.Descripcion = pDescripcion;
		this.FechaVigenciaInicial = pFechaVigenciaInicial;
		this.Simbolo = pSimbolo;
		this.Version = pVersion;
		this.Formato = pFormato;
		this.Activo = pActivo;
	}


}
}

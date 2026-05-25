using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beConclusionesEstudioMercado {

	public int IdConclusionEstudioMercado { get; set;}
	public int IdReactivoConclusionEM { get; set;}
	public int IdDatoEstudioMercado { get; set;}
	public bool Respuesta { get; set;}
	public string Reactivo { get; set; }

        public beConclusionesEstudioMercado()
	{
		
	}

	public beConclusionesEstudioMercado( int pIdConclusionEstudioMercado, int pIdReactivoConclusionEM, int pIdDatoEstudioMercado, bool pRespuesta)
	{
		this.IdConclusionEstudioMercado = pIdConclusionEstudioMercado;
		this.IdReactivoConclusionEM = pIdReactivoConclusionEM;
		this.IdDatoEstudioMercado = pIdDatoEstudioMercado;
		this.Respuesta = pRespuesta;
	}


}
}

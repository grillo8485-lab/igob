using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class bePartidas {

	public int IdPartida { get; set;}
	public int IdPartidaGenerica { get; set;}
	public int IdCapitulo { get; set;}
	public string ClavePartida { get; set;}
	public string Partida { get; set;}
	public string Descripcion { get; set;}
	public bool Activo { get; set;}

	public bePartidas()
	{
		
	}

	public bePartidas( int pIdPartida, int pIdPartidaGenerica, int pIdCapitulo, string pClavePartida, string pPartida, string pDescripcion, bool pActivo)
	{
		this.IdPartida = pIdPartida;
		this.IdPartidaGenerica = pIdPartidaGenerica;
		this.IdCapitulo = pIdCapitulo;
		this.ClavePartida = pClavePartida;
		this.Partida = pPartida;
		this.Descripcion = pDescripcion;
		this.Activo = pActivo;
	}


}
}

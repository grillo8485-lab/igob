using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class bePartidasActividadesEconomicas {

	public int IdPartidaActEconomica { get; set;}
	public int IdPartida { get; set;}
	public int IdActividadEconomica { get; set;}
	public bool Activo { get; set;}

    public string Partida { get; set; }
    public string Descripcion { get; set; }

        public bePartidasActividadesEconomicas()
	{
		
	}

	public bePartidasActividadesEconomicas( int pIdPartidaActEconomica, int pIdPartida, int pIdActividadEconomica, bool pActivo, string pPartida, string pDescripcion)
	{
		this.IdPartidaActEconomica = pIdPartidaActEconomica;
		this.IdPartida = pIdPartida;
		this.IdActividadEconomica = pIdActividadEconomica;
		this.Activo = pActivo;

        this.Partida = pPartida;
        this.Descripcion = pDescripcion;
	}


}
}

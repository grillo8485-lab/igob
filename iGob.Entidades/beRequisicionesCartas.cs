using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beRequisicionesCartas {

	public int IdProveedorRequisicionCarta { get; set;}
	public int IdCarta { get; set;}
	public int IdRequisicion { get; set;}
	public int Autorizada { get; set;}
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}

	public beRequisicionesCartas()
	{
		
	}

	public beRequisicionesCartas( int pIdProveedorRequisicionCarta, int pIdCarta, int pIdRequisicion, int pAutorizada, int pIdUsuarioRegistro, DateTime pFechaRegistro)
	{
		this.IdProveedorRequisicionCarta = pIdProveedorRequisicionCarta;
		this.IdCarta = pIdCarta;
		this.IdRequisicion = pIdRequisicion;
		this.Autorizada = pAutorizada;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
	}


}
}

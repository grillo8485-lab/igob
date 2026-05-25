using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beProveedoresRequisicionesCartas {

	public int IdProveedorCarta { get; set;}
	public int IdProveedorRqInvitacion { get; set;}
	public int IdCarta { get; set;}
	public bool AceptacionCarta { get; set;}
	public DateTime FechaAceptacion { get; set;}
	public int IdUsuarioRegistro { get; set;}
    public int IdRequisicion { get; set; }
        public beProveedoresRequisicionesCartas()
	{
		
	}

	public beProveedoresRequisicionesCartas( int pIdProveedorCarta, int pIdProveedorRqInvitacion, int pIdCarta, bool pAceptacionCarta, DateTime pFechaAceptacion, int pIdUsuarioRegistro)
	{
		this.IdProveedorCarta = pIdProveedorCarta;
		this.IdProveedorRqInvitacion = pIdProveedorRqInvitacion;
		this.IdCarta = pIdCarta;
		this.AceptacionCarta = pAceptacionCarta;
		this.FechaAceptacion = pFechaAceptacion;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
	}


}
}

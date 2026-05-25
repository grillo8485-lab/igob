using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beRequisicionesProveedoresInvitacionRestringida {

	public int IdRequisicionProveedorInvitacion { get; set;}
	public int IdRequisicion { get; set;}
	public int IdProveedor { get; set;}
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}

	public beRequisicionesProveedoresInvitacionRestringida()
	{
		
	}

	public beRequisicionesProveedoresInvitacionRestringida( int pIdRequisicionProveedorInvitacion, int pIdRequisicion, int pIdProveedor, int pIdUsuarioRegistro, DateTime pFechaRegistro)
	{
		this.IdRequisicionProveedorInvitacion = pIdRequisicionProveedorInvitacion;
		this.IdRequisicion = pIdRequisicion;
		this.IdProveedor = pIdProveedor;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
	}


}
}

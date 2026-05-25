using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beProveedoresAccionistas {

	public int IdProveedorAccionista { get; set;}
	public int IdPersona { get; set;}
	public int IdProveedor { get; set;}
	public int IdTipoRepresentacion { get; set;}

    /* Get All 28/08/2018 */
    public string Nombre { get; set;}
    public string RazonSocial { get; set;}
    public string TipoRepresentacion { get; set;}

	public beProveedoresAccionistas()
	{
		
	}

	public beProveedoresAccionistas( int pIdProveedorAccionista, int pIdPersona, int pIdProveedor, int pIdTipoRepresentacion)
	{
		this.IdProveedorAccionista = pIdProveedorAccionista;
		this.IdPersona = pIdPersona;
		this.IdProveedor = pIdProveedor;
		this.IdTipoRepresentacion = pIdTipoRepresentacion;
	}


}
}

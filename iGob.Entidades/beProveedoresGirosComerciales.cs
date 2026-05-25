using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beProveedoresGirosComerciales {

	public int IdProveedorGiroComercial { get; set;}
	public int IdProveedor { get; set;}
	public int IdActividadEconomica { get; set;}
    
    /* Get All 28/08/2018 */
    public string RazonSocial { get; set;}
    public string Descripcion { get; set;}

	public beProveedoresGirosComerciales()
	{
		
	}

	public beProveedoresGirosComerciales( int pIdProveedorGiroComercial, int pIdProveedor, int pIdActividadEconomica,string pRazonSocial, string pDescripcion)
	{
		this.IdProveedorGiroComercial = pIdProveedorGiroComercial;
		this.IdProveedor = pIdProveedor;
		this.IdActividadEconomica = pIdActividadEconomica;
        this.RazonSocial = pRazonSocial;
        this.Descripcion = pDescripcion;
	}


}
}

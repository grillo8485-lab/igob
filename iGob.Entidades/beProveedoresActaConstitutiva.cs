using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beProveedoresActaConstitutiva {

	public int IdActaConstitutiva { get; set;}
	public int IdProveedor { get; set;}
	public string NoEscritura { get; set;}
	public string NoNotaria { get; set;}
	public string Lugar { get; set;}
	public DateTime FechaEscritura { get; set;}
	public DateTime FechaRegistroPublico { get; set;}
	public string NoFolioRegistro { get; set;}
	public int Actualizacion { get; set;}
    
    /* Get All 28/08/2018 */
    public string RazonSocial { get; set;}

	public beProveedoresActaConstitutiva()
	{
		
	}

	public beProveedoresActaConstitutiva( int pIdActaConstitutiva, int pIdProveedor, string pNoEscritura, string pNoNotaria, string pLugar, DateTime pFechaEscritura, DateTime pFechaRegistroPublico, string pNoFolioRegistro, int pActualizacion)
	{
		this.IdActaConstitutiva = pIdActaConstitutiva;
		this.IdProveedor = pIdProveedor;
		this.NoEscritura = pNoEscritura;
		this.NoNotaria = pNoNotaria;
		this.Lugar = pLugar;
		this.FechaEscritura = pFechaEscritura;
		this.FechaRegistroPublico = pFechaRegistroPublico;
		this.NoFolioRegistro = pNoFolioRegistro;
		this.Actualizacion = pActualizacion;
	}


}
}

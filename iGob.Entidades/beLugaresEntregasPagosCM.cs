using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beLugaresEntregasPagosCM {

	public int IdLugarEntregaPago { get; set;}
	public int IdDependencia { get; set;}
	public string Lugar { get; set;}
	public string Direccion { get; set;}
	public string Colonia { get; set;}
	public string CodigoPostal { get; set;}
	public string IdMunicipio { get; set;}
	public string Telefono { get; set;}
	public string LocalizacionGoogle { get; set;}
	public int IdTipoLugarCM { get; set;}
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}

    //tablas externas Proc_LugaresPagosCM_Traer_IdDependencia

    public string Dependencia { get; set; }
    public string Municipio { get; set; }
    public string ClaveEstado { get; set; }
    public string Estado { get; set; }
    public string TipoLugar { get; set; }


    public beLugaresEntregasPagosCM()
	{
		
	}

	public beLugaresEntregasPagosCM( int pIdLugarEntregaPago, int pIdDependencia, string pLugar, string pDireccion, string pColonia, string pCodigoPostal, string pIdMunicipio, string pTelefono, string pLocalizacionGoogle, int pIdTipoLugarCM, int pIdUsuarioRegistro, DateTime pFechaRegistro)
	{
		this.IdLugarEntregaPago = pIdLugarEntregaPago;
		this.IdDependencia = pIdDependencia;
		this.Lugar = pLugar;
		this.Direccion = pDireccion;
		this.Colonia = pColonia;
		this.CodigoPostal = pCodigoPostal;
		this.IdMunicipio = pIdMunicipio;
		this.Telefono = pTelefono;
		this.LocalizacionGoogle = pLocalizacionGoogle;
		this.IdTipoLugarCM = pIdTipoLugarCM;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
	}


}
}

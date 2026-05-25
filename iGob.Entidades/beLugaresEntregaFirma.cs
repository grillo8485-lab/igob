using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class beLugaresEntregaFirma {

	    public int IdLugarEntregaFirma { get; set;}
	    public int IdDependencia { get; set;}
	    public string Lugar { get; set;}
	    public string Direccion { get; set;}
	    public string Colonia { get; set;}
	    public string CodigoPostal { get; set;}
	    public string IdMunicipio { get; set;}
	    public string Telefono { get; set;}
	    public string LocalizacionGoogle { get; set;}
	    public int IdTipoLugar { get; set;}
	    public int IdUsuarioRegistro { get; set;}
	    public DateTime FechaRegistro { get; set;}
        public string Dependencia { get; set; }
        public string Municipio { get; set; }
        public string ClaveEstado { get; set; }
        public string Estado { get; set; }
        public int IdCondicionEntregaDetalle { get; set; }
        public beLugaresEntregaFirma()
	    {
		
	    }

	    public beLugaresEntregaFirma( int pIdLugarEntregaFirma, int pIdDependencia, string pLugar, string pDireccion, string pColonia, string pCodigoPostal, string pIdMunicipio, string pTelefono, string pLocalizacionGoogle, int pIdTipoLugar, int pIdUsuarioRegistro, DateTime pFechaRegistro, string pDependencia,string pMunicipio,string pClaveEstado, string pEstado)
	    {
		    this.IdLugarEntregaFirma = pIdLugarEntregaFirma;
		    this.IdDependencia = pIdDependencia;
		    this.Lugar = pLugar;
		    this.Direccion = pDireccion;
		    this.Colonia = pColonia;
		    this.CodigoPostal = pCodigoPostal;
		    this.IdMunicipio = pIdMunicipio;
		    this.Telefono = pTelefono;
		    this.LocalizacionGoogle = pLocalizacionGoogle;
		    this.IdTipoLugar = pIdTipoLugar;
		    this.IdUsuarioRegistro = pIdUsuarioRegistro;
		    this.FechaRegistro = pFechaRegistro;
		    this.Dependencia = pDependencia;
		    this.Municipio = pMunicipio;
            this.ClaveEstado = pClaveEstado;
            this.Estado = pEstado;
        }
    }
}

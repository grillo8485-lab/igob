using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class beEF_Colonias {

	    public string IdColonia { get; set;}
	    public string Colonia { get; set;}
	    public string CodigoPostal { get; set;}
	    public string IdMunicipio { get; set;}
	    public string IdTipoAsenta { get; set;}
	    public string IdCiudad { get; set;}
        public int IdColonia2 { get; set; }
        public int IdMunicipio2 { get; set; }
        
        public beEF_Colonias(){}

	    public beEF_Colonias( string pIdColonia, string pColonia, string pCodigoPostal, string pIdMunicipio, string pIdTipoAsenta, string pIdCiudad)
	    {
		    this.IdColonia = pIdColonia;
		    this.Colonia = pColonia;
		    this.CodigoPostal = pCodigoPostal;
		    this.IdMunicipio = pIdMunicipio;
		    this.IdTipoAsenta = pIdTipoAsenta;
		    this.IdCiudad = pIdCiudad;
	    }
    }
}

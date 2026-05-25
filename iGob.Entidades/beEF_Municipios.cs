using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class beEF_Municipios {

	    public string IdMunicipio { get; set;}
	    public string Municipio { get; set;}
	    public string ClaveEstado { get; set;}
	    public int ClaveEstado2 { get; set; }
        public int IdMunicipio2 { get; set; }


        public beEF_Municipios(){}

	    public beEF_Municipios( string pIdMunicipio, string pMunicipio, string pClaveEstado)
	    {
		    this.IdMunicipio = pIdMunicipio;
		    this.Municipio = pMunicipio;
		    this.ClaveEstado = pClaveEstado;
	    }
    }
}

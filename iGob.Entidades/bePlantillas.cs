using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class bePlantillas
    {

	    public int IdPlantilla { get; set;}
	    public int IdGobierno { get; set;}
	    public int IdTipoUsoPlantilla { get; set;}
	    public string UrlPlantilla { get; set;}
	    public string NombreArchivo { get; set;}
	    public string Descripcion { get; set;}

        //datos externos
        public string TipoUso { get; set; }

	    public bePlantillas()
	    {
		
	    }

	    public bePlantillas( int pIdPlantilla, int pIdGobierno, int pIdTipoUsoPlantilla, string pUrlPlantilla, string pNombreArchivo, string pDescripcion)
	    {
		    this.IdPlantilla = pIdPlantilla;
		    this.IdGobierno = pIdGobierno;
		    this.IdTipoUsoPlantilla = pIdTipoUsoPlantilla;
		    this.UrlPlantilla = pUrlPlantilla;
		    this.NombreArchivo = pNombreArchivo;
		    this.Descripcion = pDescripcion;
	    }


    }
}

using iGob.Entidades;
using iGob.ReglasNegocios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class ClsLicitacionesImprimirConvocatoria
    {
        public string pathLocal = ""; //ruta en donde se guardarán los documento generado
        public string pathPlantillas = ""; //ruta en donde se guardarán los documento generado
        ClsWord clsdocfiles = new ClsWord();

        public ClsLicitacionesImprimirConvocatoria(string pathLocal_, string pathPlantillas_)
        {
            pathLocal = pathLocal_;
            pathPlantillas = pathPlantillas_;
        }


        public void RemplazaTextoDoc(int pIdLic)
        {
            //obtenemos los datos nesarios
            brLicitacionesConvocatoria Lic = new brLicitacionesConvocatoria();

            //obtenemos los datos de licitacion
            beLicitacionesConvocatoria obeLic = Lic.traerLicitaciones_x_IdLicitacion_Convocatoria(pIdLic);

            //obtenemos los datos de lotes
            List<beLicitacionesConvocatoria> ListaLotes = Lic.traerRequisicionesLotes_x_IdLicitacion_Convocatoria(pIdLic);



            //obtenemos la fecha de hoy
            //clsdocfiles.FindAndReplace("<FECHAELABORACION>", DateTime.Now.ToString("dd/MM/yyyy"));

            clsdocfiles.FindAndReplace("<TITULOCONVOCATORIA>", obeLic.Titulo);
            clsdocfiles.FindAndReplace("<PARTIDAS>", obeLic.Partidas);
            clsdocfiles.FindAndReplace("<COSTOSBASES>", obeLic.MontoBases.ToString("C"));
            clsdocfiles.FindAndReplace("<FECHAADQUIRIRBASES>", obeLic.FechaDisposicionBases);
            clsdocfiles.FindAndReplace("<FECHAHORAACLARACIONDUDAS>", obeLic.FechaHoraAclaracionDudas);
            clsdocfiles.FindAndReplace("<FECHAHORAENVIOPROPUESTATECNICA>", obeLic.FechaEnvioPropuestasTecEco);
            clsdocfiles.FindAndReplace("<FECHAHORAFALLO>", obeLic.FechaFallo.ToString()+" "+obeLic.HoraFallo.ToString());

            //inicializamos las variables de lotes
            int[] numlote = new int[3];
            string[] descripcionlote = new string[3];
            decimal[] cantidadlote = new decimal[3];
            string[] unidadmedidalote = new string[3];

            int contador = 0;
            foreach (beLicitacionesConvocatoria Lote in ListaLotes)
            {
                numlote[contador] = Lote.NoLote;
                descripcionlote[contador] = Lote.BienServicio;
                cantidadlote[contador] = Lote.Cantidad;
                unidadmedidalote[contador] = Lote.UnidadMedida;
                contador++;
            }
            

            clsdocfiles.FindAndReplace("<NUMEROLOTE1>", numlote[0]);
            clsdocfiles.FindAndReplace("<DESCRIPCIONLOTE1>", descripcionlote[0]);
            clsdocfiles.FindAndReplace("<CANTIDADLOTE1>", cantidadlote[0]);
            clsdocfiles.FindAndReplace("<UNIDADMEDIDALOTE1>", unidadmedidalote[0]);
            clsdocfiles.FindAndReplace("<NUMEROLOTE2>", numlote[1]);
            clsdocfiles.FindAndReplace("<DESCRIPCIONLOTE2>", descripcionlote[1]);
            clsdocfiles.FindAndReplace("<CANTIDADLOTE2>", cantidadlote[1]);
            clsdocfiles.FindAndReplace("<UNIDADMEDIDALOTE2>", unidadmedidalote[1]);
            clsdocfiles.FindAndReplace("<NUMEROLOTE3>", numlote[2]);
            clsdocfiles.FindAndReplace("<DESCRIPCIONLOTE3>", descripcionlote[2]);
            clsdocfiles.FindAndReplace("<CANTIDADLOTE3>", cantidadlote[2]);
            clsdocfiles.FindAndReplace("<UNIDADMEDIDALOTE3>", unidadmedidalote[2]);
            clsdocfiles.FindAndReplace("<FECHAPUBLICACION>", obeLic.FechaPublicacion);

        }

        public string ImprimeArchivo(int pIdLic, int IdGobierno)
        {
            //obtenemos los datos de guardado
            brPlantillas plantillas = new brPlantillas();
            bePlantillas obeplantillas = plantillas.traerPlantillas_x_IdTipoUsoPlantilla(2, IdGobierno);

            string pRutaArchivoOrigen = pathPlantillas + obeplantillas.UrlPlantilla;

            string pDocumento = obeplantillas.NombreArchivo + pIdLic.ToString();  //nombre del nuevo documento

            if (File.Exists(pathLocal + pDocumento + ".PDF"))
            {
                //ya existe, solo regresa el nombre
            }
            else
            {
                //no existe, genera el documento
                clsdocfiles.WordDocument(pRutaArchivoOrigen, pathLocal, pDocumento);
                RemplazaTextoDoc(pIdLic);
                clsdocfiles.SaveDocument();
                clsdocfiles.ExportDocument(pathLocal, pDocumento);
            }

            clsdocfiles.CloseDocument();


            string Archivo = pDocumento + ".PDF";
            return Archivo;
            //borramos el archivo word
            //ClsLibreriaArchivos.DeleteFile(Path.Combine(pathLocal + pDocumento + ".docx"));
        }
    }
}
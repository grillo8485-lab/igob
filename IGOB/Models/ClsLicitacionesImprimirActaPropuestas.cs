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
    public class ClsLicitacionesImprimirActaPropuestas
    {

        public string pathLocal = ""; //ruta en donde se guardarán los documento generado
        public string pathPlantillas = ""; //ruta en donde se guardarán los documento generado
        ClsWord clsdocfiles = new ClsWord();

        public ClsLicitacionesImprimirActaPropuestas(string pathLocal_, string pathPlantillas_)
        {
            pathLocal = pathLocal_;
            pathPlantillas = pathPlantillas_;
        }

        public void RemplazaTextoDoc(int pIdLic)
        {
            //obtenemos los datos nesarios
            brLicitacionesActaPropuesta Lic = new brLicitacionesActaPropuesta();

            //obtenemos los datos de licitacion
            beLicitacionesActaPropuesta obeLic = Lic.traerLicitaciones_x_IdLicitacion_ActaApertura(pIdLic);

            //obtenemos los datos de propuestas
            List<beLicitacionesActaPropuesta> ListaPropuestas = Lic.traerPropuestasTecnicaEconomica_x_IdLicitacion_ActaApertura(pIdLic);


            //obtenemos la fecha de hoy
            //clsdocfiles.FindAndReplace("<FECHAELABORACION>", DateTime.Now.ToString("dd/MM/yyyy"));

            clsdocfiles.FindAndReplace("<TITULO>", obeLic.Titulo);
            clsdocfiles.FindAndReplace("<PARTIDAS>", obeLic.Partidas);
            clsdocfiles.FindAndReplace("<DEPENDENCIAS>", obeLic.Dependencias);
            clsdocfiles.FindAndReplace("<NUMFOLIO>", obeLic.FolioRequisiciones);
            clsdocfiles.FindAndReplace("<HORAPROPUESTAS>", obeLic.HoraPropuestas);
            clsdocfiles.FindAndReplace("<FECHAPROPUESTAS>", obeLic.FechaPropuestas);
            clsdocfiles.FindAndReplace("<EMPRESASPROVEEDORAS>", obeLic.EmpresasProveedoras.Replace("\\n", "\n"));


            

            //creamos la cadena de la tabla de propuestas
            string cadenatabla = "";
            foreach (beLicitacionesActaPropuesta Pro in ListaPropuestas)
            {
                Enletras let = new Enletras();
                string cantidad =Pro.OfertaTotal.ToString("C1")+" ("+ let.enletras(Pro.OfertaTotal.ToString())+").";

                cadenatabla += "<table><tr><td>Requisición:<td>" + Pro.RequisicionFolio;
                cadenatabla += "<tr><td>Dependencia solicitante:<td>" + Pro.Dependencia;
                cadenatabla += "<tr><td>Proveedor:<td>" + Pro.RazonSocial;
                cadenatabla += "<tr><td>Oferta total<td>" + cantidad;
                cadenatabla += "<tr><td><center>Tipo de abastecimiento<td>" + Pro.FormaAbastecimiento;
                cadenatabla += "<tr><td><center>Número de lotes ofertados:<td>" + Pro.NumLotes+"/"+Pro.TotalLotes;
                cadenatabla += "<tr><td><center>Lotes ofertados:<td>" + Pro.LotesOfertados;

            }

            clsdocfiles.Creartabla("<TABLAPROPUESTAS>", cadenatabla);



            clsdocfiles.FindAndReplace("<FECHAPUBLICACION>", obeLic.FechaPublicacion);

        }

        public string ImprimeArchivo(int pIdLic, int IdGobierno)
        {
            //obtenemos los datos de guardado
            brPlantillas plantillas = new brPlantillas();
            bePlantillas obeplantillas = plantillas.traerPlantillas_x_IdTipoUsoPlantilla(4, IdGobierno);

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
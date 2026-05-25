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
    public class ClsLicitacionesImprimirAclaracionDudas
    {
        public string pathLocal = ""; //ruta en donde se guardarán los documento generado
        public string pathPlantillas = ""; //ruta en donde se guardarán los documento generado
        ClsWord clsdocfiles = new ClsWord();

        public ClsLicitacionesImprimirAclaracionDudas(string pathLocal_, string pathPlantillas_)
        {
            pathLocal = pathLocal_;
            pathPlantillas = pathPlantillas_;
        }


        public void RemplazaTextoDoc(int pIdLic)
        {
            //obtenemos los datos nesarios
            brLicitacionesAclaracionDudas Lic = new brLicitacionesAclaracionDudas();

            //obtenemos los datos de licitacion
            beLicitacionesAclaracionDudas obeLic = Lic.traerLicitaciones_x_IdLicitacion_AclaracionDudas(pIdLic);

            //obtenemos los datos de preguntas
            List<beLicitacionesAclaracionDudas> ListaPreguntas = Lic.traerProveedoresPreguntas_x_IdLicitacion_AclaracionDudas(pIdLic);


            //obtenemos la fecha de hoy
            //clsdocfiles.FindAndReplace("<FECHAELABORACION>", DateTime.Now.ToString("dd/MM/yyyy"));

            clsdocfiles.FindAndReplace("<TITULO>", obeLic.Titulo);
            clsdocfiles.FindAndReplace("<HORAJUNTA>", obeLic.HoraAclaracionDudas);
            clsdocfiles.FindAndReplace("<FECHAJUNTA>", obeLic.FechaAclaracionDudas);
            clsdocfiles.FindAndReplace("<PARTIDAS>", obeLic.Partidas);
            clsdocfiles.FindAndReplace("<DEPENDENCIAS>", obeLic.Dependencias);
            clsdocfiles.FindAndReplace("<NUMFOLIO>", obeLic.FolioRequisiciones);

            //creamos la cadena de la tabla de preguntas
            string cadenatabla = "<table><tr><td><center>LICITACIÓN: "+obeLic.FolioOficial;
            int ReqActual = 0;
            foreach (beLicitacionesAclaracionDudas Pre in ListaPreguntas)
            {
                if (ReqActual != Pre.IdProveedorRqInvitacion)
                {
                    //Es una nueva requisición en la lista, generamos su encabezado
                    cadenatabla += "<table><tr><td>Proveedor<td>" + Pre.RazonSocial;
                    cadenatabla += "<tr><td>Requisición<td>" + Pre.RequisicionFolio;
                    cadenatabla += "<tr><td>Partida<td>" + Pre.Partida;
                    cadenatabla += "<tr><td>Dependencia solicitante:<td>" + Pre.Dependencia;
                    cadenatabla += "<tr><td><center>Pregunta<td><center>Respuesta";

                    ReqActual = Pre.IdProveedorRqInvitacion;
                }

                cadenatabla += "<tr><td>"+Pre.Pregunta+"<td>" + Pre.Respuesta;
            }

            clsdocfiles.Creartabla("<TABLAPREGUNTAS>", cadenatabla);

            clsdocfiles.FindAndReplace("<FECHAPUBLICACION>", obeLic.FechaPublicacion);
            clsdocfiles.FindAndReplace("<EMPRESASPROVEEDORAS>", obeLic.EmpresasProveedoras.Replace("\\n", "\n"));

        }

        public string ImprimeArchivo(int pIdLic, int IdGobierno)
        {
            //obtenemos los datos de guardado
            brPlantillas plantillas = new brPlantillas();
            bePlantillas obeplantillas = plantillas.traerPlantillas_x_IdTipoUsoPlantilla(3, IdGobierno);

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
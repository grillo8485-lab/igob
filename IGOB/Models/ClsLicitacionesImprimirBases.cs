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
    public class ClsLicitacionesImprimirBases
    {
        public string pathLocal = ""; //ruta en donde se guardarán los documento generado
        public string pathPlantillas = ""; //ruta en donde se guardarán los documento generado
        ClsWord clsdocfiles = new ClsWord();

        public ClsLicitacionesImprimirBases(string pathLocal_, string pathPlantillas_)
        {
            pathLocal = pathLocal_;
            pathPlantillas = pathPlantillas_;
        }


        public void RemplazaTextoDoc(int pIdLic)
        {
            //obtenemos los datos nesarios
            brLicitacionesBases Lic = new brLicitacionesBases();

            //obtenemos los datos de licitacion
            beLicitacionesBases obeLic = Lic.traerLicitaciones_x_IdLicitacion_Bases(pIdLic);

            //detalles de condiciones de entrega
            List<beLicitacionesBases> ListaLicCED = Lic.traerRequisicionesCondicionesEntregasDetalles_x_IdLicitacion_Bases(pIdLic);

            //Cartas
            List<beLicitacionesBases> ListaCartas = Lic.traerRequisicionesCartas_x_IdLicitacion_Bases(pIdLic);


            //obtenemos la fecha de hoy
            //clsdocfiles.FindAndReplace("<FECHAELABORACION>", DateTime.Now.ToString("dd/MM/yyyy"));

            clsdocfiles.FindAndReplace("<TITULOBASES>", obeLic.Titulo);
            clsdocfiles.FindAndReplace("<FECHAAUTORIZADA>", obeLic.FechaAutorizacion);
            clsdocfiles.FindAndReplace("<DEPENDENCIAS>", obeLic.Dependencias);
            clsdocfiles.FindAndReplace("<PARTIDAS>", obeLic.Partidas);
            clsdocfiles.FindAndReplace("<DESCRIPCIONPARTIDAS>", obeLic.DescripcionPartidas);
            clsdocfiles.FindAndReplace("<CLAVEPARTIDAS>", obeLic.ClavePartidas);
            clsdocfiles.FindAndReplace("<FOLIOREQUISICION>", obeLic.FolioRequisiciones);


            //generamos la tabla de lugares de entrega
            string cadenatabla = "<table><tr><td><th><center>Lote<td><th><center>Cantidad a entregar<td><th><center>Lugar de entrega<td><th><center>Horarios<td><th><center>Días";
            foreach (beLicitacionesBases Carta in ListaLicCED)
            {
                cadenatabla += "<tr><td>" + Carta.NoLote + "<td>" + Carta.Cantidad + "<td>" + Carta.LugarEntrega + "<td>" + Carta.Horario + "<td>" + Carta.Dias;
            }
            clsdocfiles.Creartabla("<TABLALUGARENTREGA>", cadenatabla);

            clsdocfiles.FindAndReplace("<PLAZOSENTREGA>", obeLic.PlazosEntrega);
            clsdocfiles.FindAndReplace("<DEPENDENCIASABREVIATURAS>", obeLic.DependenciasAbreviaturas);
            clsdocfiles.FindAndReplace("<PLAZOSPAGO>", obeLic.PlazosPago);
            clsdocfiles.FindAndReplace("<DATOSFACTURACION>", obeLic.DatosFacturacion.Replace("\\n", "\n"));
            clsdocfiles.FindAndReplace("<LUGARFIRMAPEDIDO>", obeLic.LugarFirmaPedido);
            clsdocfiles.FindAndReplace("<FECHAHORAENVIOPREGUNTAS>", obeLic.FechaLimitePreguntas);
            clsdocfiles.FindAndReplace("<FECHAHORAJUNTAACLARACIONDUDAS>", obeLic.FechaHoraAclaracionDudas);
            clsdocfiles.FindAndReplace("<FECHAHORAENVIOPROPUESTATECNICA>", obeLic.FechaEnvioPropuestasTecEco);
            clsdocfiles.FindAndReplace("<FECHAHORAFALLO>", obeLic.FechaFallo.ToString() + ' ' + obeLic.HoraFallo.ToString());
            clsdocfiles.FindAndReplace("<MODALIDADTIEMPO>", obeLic.Tiempo);
            

            //generamos la cadena de cartas
            string cartas = "";
            foreach(beLicitacionesBases Carta in ListaCartas)
            {
                cartas +=Carta.Inciso + "\t" + Carta.RequisicionFolio + " " + Carta.Nombre + " " + Carta.Carta + "\n";
            }

            clsdocfiles.FindAndReplace("<CARTAS>", cartas);
            clsdocfiles.FindAndReplace("<DIASHABILES>", "");

        }

        public string ImprimeArchivo(int pIdLic, int IdGobierno)
        {
            //obtenemos los datos de guardado
            brPlantillas plantillas = new brPlantillas();
            bePlantillas obeplantillas = plantillas.traerPlantillas_x_IdTipoUsoPlantilla(1, IdGobierno);

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
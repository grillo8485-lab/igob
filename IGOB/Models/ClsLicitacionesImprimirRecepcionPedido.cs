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
    public class ClsLicitacionesImprimirRecepcionPedido
    {
        public string pathLocal = ""; //ruta en donde se guardarán los documento generado
        public string pathPlantillas = ""; //ruta en donde se guardarán los documento generado
        ClsWord clsdocfiles = new ClsWord();

        public ClsLicitacionesImprimirRecepcionPedido(string pathLocal_, string pathPlantillas_)
        {
            pathLocal = pathLocal_;
            pathPlantillas = pathPlantillas_;
        }


        public void RemplazaTextoDoc(int pIdRecepcion)
        {
            //obtenemos los datos necesarios
            brLicitacionesRecepcionPedido Lic = new brLicitacionesRecepcionPedido();

            //obtenemos los datos de recepcion
            beLicitacionesRecepcionPedido obeLic = Lic.traerRecepcionPedido_x_IdRecepcion(pIdRecepcion);

            //obtenemos los detalles de recepcion
            List<beLicitacionesRecepcionPedido> ListaLotes = Lic.traerRecepcionesPedidosDetalles_x_IdRecepcion(pIdRecepcion);


            //obtenemos la fecha de hoy
            //clsdocfiles.FindAndReplace("<FECHAELABORACION>", DateTime.Now.ToString("dd/MM/yyyy"));

            clsdocfiles.FindAndReplace("<DEPENDENCIA>", obeLic.Dependencia);
            clsdocfiles.FindAndReplace("<FOLIORECEPCION>", obeLic.Folio);
            clsdocfiles.FindAndReplace("<ENCARGADORECEPCION>", obeLic.NombreEncargado);
            clsdocfiles.FindAndReplace("<FECHAENTREGA>", obeLic.FechaRecepcion);
            clsdocfiles.FindAndReplace("<FOLIOPEDIDO>", obeLic.FolioPedido);
            clsdocfiles.FindAndReplace("<LICITACION>", obeLic.TituloLicitacion);
            clsdocfiles.FindAndReplace("<PARTIDA>", obeLic.Partida);
            clsdocfiles.FindAndReplace("<LUGARENTREGA>", obeLic.LugarEntrega);

            string cadenatabla = "<table><tr><td><center>Descripción<tr><td><center>Cantidad<tr><td><center>Cantidad recibida";
            foreach (beLicitacionesRecepcionPedido Lot in ListaLotes)
            {
                cadenatabla += "<tr><td>" + Lot.BienServicio + "<td>" + Lot.Cantidad + "<td>" + Lot.CantidadRecibida;
            }

            clsdocfiles.Creartabla("<TABLARECEPCION>", cadenatabla);

            clsdocfiles.FindAndReplace("<TITULO>", obeLic.TituloLicitacion + " - " + obeLic.RequisicionFolio);

        }

        public string ImprimeArchivo(int pIdRecepcion, int IdGobierno)
        {
            //obtenemos los datos de guardado
            brPlantillas plantillas = new brPlantillas();
            bePlantillas obeplantillas = plantillas.traerPlantillas_x_IdTipoUsoPlantilla(9, IdGobierno);

            string pRutaArchivoOrigen = pathPlantillas + obeplantillas.UrlPlantilla;

            string pDocumento = obeplantillas.NombreArchivo + pIdRecepcion.ToString();  //nombre del nuevo documento

            clsdocfiles.WordDocument(pRutaArchivoOrigen, pathLocal, pDocumento);

            RemplazaTextoDoc(pIdRecepcion);

            clsdocfiles.SaveDocument();

            clsdocfiles.ExportDocument(pathLocal, pDocumento);
            clsdocfiles.CloseDocument();
            string Archivo = pDocumento + ".PDF";
            return Archivo;
            //borramos el archivo word
            //ClsLibreriaArchivos.DeleteFile(Path.Combine(pathLocal + pDocumento + ".docx"));
        }
    }
}
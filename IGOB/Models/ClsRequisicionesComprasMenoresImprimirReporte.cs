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
    public class ClsRequisicionesComprasMenoresImprimirReporte
    {
        //public string pRutaArchivoOrigen = @"C:\inetpub\wwwroot\Rtforigen\PlantillaComprasMenoresCDMX.docx"; //ruta de archivos de origen y el nombre del archivo plantilla

        //public string pDocumento = "plantilla_copia";  //nombre del nuevo documento
        public string pathLocal = @"C:\inetpub\wwwroot\Rtflocal\"; //ruta en donde se guardarán los documento generado

        ClsWord clsdocfiles = new ClsWord();

        public void RemplazaTextoDoc(int pIdReqCM)
        {
            //obtenemos los datos de la requisición
            ClsRequisicionesComprasMenores ReqCM = new ClsRequisicionesComprasMenores();
            beRequisicionesComprasMenores obeReqCM = ReqCM.TraerRequisicionCM(pIdReqCM);

            //obtenemos los lotes
            List<beRequisicionesComprasMenoresLotes> ListaReqCMLotes = ReqCM.GetAllLotes_x_IdReqCM(pIdReqCM);

            clsdocfiles.FindAndReplace("<DEPENDENCIA>", obeReqCM.Dependencia);
            clsdocfiles.FindAndReplace("<PARTIDA>", obeReqCM.Partida);
            //clsdocfiles.FindAndReplace("<AREASOLICITANTE>", obeReqCM.Departamento);
            clsdocfiles.FindAndReplace("<NOLOTES>", obeReqCM.CantidadLotes);
            clsdocfiles.FindAndReplace("<NOFOLIOCOMPRA>", obeReqCM.RequisicionFolio);

            clsdocfiles.FindAndReplace("<SOLICITUD>", " ");
            clsdocfiles.FindAndReplace("<CAPITULO>", obeReqCM.Capitulo);
            clsdocfiles.FindAndReplace("<PARTIDA>", obeReqCM.Partida);
            clsdocfiles.FindAndReplace("<ORIGENRECURSO>", obeReqCM.OrigenRecurso);
            clsdocfiles.FindAndReplace("<IMPORTE>", " ");
            clsdocfiles.FindAndReplace("<EJERCICIO>", obeReqCM.Ejercicio);
            clsdocfiles.FindAndReplace("<PROVEEDOR>", obeReqCM.RazonSocial);
            clsdocfiles.FindAndReplace("<JUSTIFICACION>", obeReqCM.Justificacion);
            clsdocfiles.FindAndReplace("<OBSERVACIONES>", obeReqCM.Observaciones);

            //generamos la tabla a partir de la lista de lotes            
            
            string cadenatabla = "<table><tr><td><th><center><width=1.5>LOTE<td><th><center><width=2.5>CANTIDAD<td><th><center><width=3>UNIDAD<td><th><center>DESCRIPCIÓN DEL ARTÍCULO";
            foreach (beRequisicionesComprasMenoresLotes Lote in ListaReqCMLotes)
            {
                cadenatabla += "<tr><td>" + Lote.NoLote + "<td>" + Lote.Cantidad + "<td> <td>" + Lote.Concepto;
            }            
            cadenatabla += "</table>";
            clsdocfiles.Creartabla("<TABLALOTES>", cadenatabla);

            clsdocfiles.FindAndReplace("<IMPORTEIMPUESTO>",  obeReqCM.ImporteTotalLotes.ToString("C"));
            clsdocfiles.FindAndReplace("<FECHAENTREGA>", obeReqCM.FechaEntrega);
            //clsdocfiles.FindAndReplace("<LUGARENTREGA>", obeReqCM.LugarEntrega);
            clsdocfiles.FindAndReplace("<FECHAPAGO>", obeReqCM.FechaPago);
            //clsdocfiles.FindAndReplace("<LUGARPAGO>", obeReqCM.LugarPago);
            clsdocfiles.FindAndReplace("<NOMBREPROVEEDOR>", obeReqCM.RazonSocial);
            clsdocfiles.FindAndReplace("<DIRECCIONPROVEEDOR>", " ");
            clsdocfiles.FindAndReplace("<FECHAELABORACION>", obeReqCM.FechaRequisicion);

        }

        public void ImprimeArchivo(int pIdReqCM, int IdGobierno)
        {
            //obtenemos los datos de guardado
            //ClsPlantillas plantillas = new ClsPlantillas();
            brPlantillas plantillas = new brPlantillas();
            bePlantillas obeplantillas = plantillas.traerPlantillas_x_IdTipoUsoPlantilla(13, IdGobierno);

            string pRutaArchivoOrigen = obeplantillas.UrlPlantilla;

            string pDocumento = obeplantillas.NombreArchivo + pIdReqCM.ToString();  //nombre del nuevo documento

            clsdocfiles.WordDocument(pRutaArchivoOrigen, pathLocal, pDocumento);
            
            RemplazaTextoDoc(pIdReqCM);

            clsdocfiles.SaveDocument();

            clsdocfiles.ExportDocument(pathLocal, pDocumento);
            clsdocfiles.CloseDocument();
            Process.Start(Path.Combine(pathLocal + pDocumento + ".PDF"));
            //borramos el archivo word
            //ClsLibreriaArchivos.DeleteFile(Path.Combine(pathLocal + pDocumento + ".docx"));
        }
    }
}
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
    public class ClsLicitacionesImprimirActaFallo
    {
        public string pathLocal = ""; //ruta en donde se guardarán los documento generado
        public string pathPlantillas = ""; //ruta en donde se guardarán los documento generado
        ClsWord clsdocfiles = new ClsWord();

        public ClsLicitacionesImprimirActaFallo(string pathLocal_, string pathPlantillas_)
        {
            pathLocal = pathLocal_;
            pathPlantillas = pathPlantillas_;
        }


        public void RemplazaTextoDoc(int pIdLic)
        {
            //obtenemos los datos necesarios
            brLicitacionesActaFallo Lic = new brLicitacionesActaFallo();

            //obtenemos los datos de licitacion
            beLicitacionesActaFallo obeLic = Lic.traerRep_ActaFallo_Licitaciones_x_IdLicitacion(pIdLic);

            //obtenemos los datos de las requisiciones en la licitacion
            List<beLicitacionesActaFallo> ListaReq = Lic.traerRep_ActaFallo_PropuestasTecnicaEconomica_x_IdLicitacion(pIdLic);


            //obtenemos la fecha de hoy
            //clsdocfiles.FindAndReplace("<FECHAELABORACION>", DateTime.Now.ToString("dd/MM/yyyy"));

            clsdocfiles.FindAndReplace("<TITULO>", obeLic.Titulo);
            clsdocfiles.FindAndReplace("<PARTIDAS>", obeLic.Partidas);
            clsdocfiles.FindAndReplace("<DEPENDENCIAS>", obeLic.Dependencias);
            clsdocfiles.FindAndReplace("<NUMFOLIO>", obeLic.FolioRequisiciones);

            clsdocfiles.FindAndReplace("<JUSTIFICACIONACTA>", "");
            
            //generamos la cadena de la tabla
            string cadenatabla = "<table><tr><td><center>Asignación de lotes";

            foreach (beLicitacionesActaFallo Req in ListaReq)
            {
                //Añadimos los datos de cabecera por requisición
                Enletras let = new Enletras();

                string OfertaTotal = Req.OfertaTotal.ToString("C2") + " (" + let.enletras(Req.OfertaTotal.ToString()) + ").";
                string MontoAsignado = Req.MontoAsignado.ToString("C2") + " (" + let.enletras(Req.MontoAsignado.ToString()) + ").";

                cadenatabla += "<table><tr><td><width=5>Requisición:<td>" + Req.RequisicionFolio;
                cadenatabla += "<tr><td>Dependencia solicitante:<td>" + Req.Dependencia;
                cadenatabla += "<tr><td>Proveedor:<td>" + Req.RazonSocial;
                cadenatabla += "<tr><td>Oferta total:<td>" + OfertaTotal;
                cadenatabla += "<tr><td>Tipo de abastecimiento:<td>" + Req.FormaAbastecimiento;
                cadenatabla += "<tr><td>Lotes ofertados:<td>" + Req.LotesOfertados;
                cadenatabla += "<tr><td>Lotes asignados:<td>" + Req.LotesAsignados;
                cadenatabla += "<tr><td>Monto asignado C/IVA:<td>" + MontoAsignado;

                //revisamos el incumplimiento
                cadenatabla += "<table><tr><td><center>Incumplimiento";
                cadenatabla += "<table><tr><td><width=5>SECCIÓN<td>OBSERVACIONES Y FUNDAMENTACIÓN LEGAL";
                string CartasAdqObservacion = "Ninguno";
                string CondicionEntregaAdqObservacion = "Ninguno";
                string CondicionPagoAdqObservacion = "Ninguno";
                string ManifiestoAdqObservacion = "Ninguno";

                if (Req.CartaAdquisicionCumple == true)
                {
                    CartasAdqObservacion = Req.CartasAdqObservacion;
                }

                if (Req.CondicionEntregaAdquisicionCumple == true)
                {
                    CondicionEntregaAdqObservacion = Req.CondicionEntregaAdqObservacion;
                }
                if (Req.CondicionPagoAdquisicionCumple == true)
                {
                    CondicionPagoAdqObservacion = Req.CondicionPagoAdqObservacion;
                }
                if (Req.ManifiestoAdquisicionCumple == true)
                {
                    ManifiestoAdqObservacion = Req.ManifiestoAdqObservacion;
                }
                cadenatabla += "<tr><td>Cartas<td>" + CartasAdqObservacion;
                cadenatabla += "<tr><td>Condiciones de entrega<td>" + CondicionEntregaAdqObservacion;
                cadenatabla += "<tr><td>Condiciones de pago<td>" + CondicionPagoAdqObservacion;
                cadenatabla += "<tr><td>Manifiestos<td>" + ManifiestoAdqObservacion;

                cadenatabla += "<tr><td><center>-<td><center>-";
            }

            clsdocfiles.Creartabla("<TABLAREQUISICIONES>", cadenatabla);


            cadenatabla = "<table><tr><td><center>Lotes desiertos";
            cadenatabla += "<table><tr><td><center>Requisión<td><center>Lotes";
            cadenatabla += "<tr><td><center>-<td><center>-";

            clsdocfiles.Creartabla("<TABLALOTESDESIERTOS>", cadenatabla);


            clsdocfiles.FindAndReplace("<HORAFALLO>", obeLic.HoraFallo);
            clsdocfiles.FindAndReplace("<FECHAFALLO>", obeLic.FechaFallo);

        }

        public string ImprimeArchivo(int pIdLic, int IdGobierno)
        {
            //obtenemos los datos de guardado
            brPlantillas plantillas = new brPlantillas();
            bePlantillas obeplantillas = plantillas.traerPlantillas_x_IdTipoUsoPlantilla(7, IdGobierno);

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
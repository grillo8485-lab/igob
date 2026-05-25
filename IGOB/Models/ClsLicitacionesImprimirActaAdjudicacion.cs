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
    public class ClsLicitacionesImprimirActaAdjudicacion
    {
        public string pathLocal = ""; //ruta en donde se guardarán los documento generado
        public string pathPlantillas = ""; //ruta en donde se guardarán los documento generado
        ClsWord clsdocfiles = new ClsWord();

        public ClsLicitacionesImprimirActaAdjudicacion(string pathLocal_, string pathPlantillas_)
        {
            pathLocal = pathLocal_;
            pathPlantillas = pathPlantillas_;
        }


        public void RemplazaTextoDoc(int pIdLic)
        {
            //obtenemos los datos necesarios
            brLicitacionesActaAdjudicacion Lic = new brLicitacionesActaAdjudicacion();

            //obtenemos los datos de licitacion
            beLicitacionesActaAdjudicacion obeLic = Lic.traerRep_ActaAdjudicacion_Licitaciones_x_IdLicitacion(pIdLic);

            //obtenemos los datos de las requisiciones en la licitacion
            List<beLicitacionesActaAdjudicacion> ListaReq = Lic.traerRep_ActaAdjudicacion_Requisiciones_x_IdLicitacion(pIdLic);

            //obtenemos los datos de lotes ofertados
            List<beLicitacionesActaAdjudicacion> ListaLotes = Lic.traerRep_ActaAdjudicacion_Lotes_x_IdLicitacion(pIdLic);


            //obtenemos la fecha de hoy
            //clsdocfiles.FindAndReplace("<FECHAELABORACION>", DateTime.Now.ToString("dd/MM/yyyy"));

            clsdocfiles.FindAndReplace("<TITULOLICITACION>", obeLic.Titulo);
            clsdocfiles.FindAndReplace("<FECHALICITACION>", obeLic.FechaAutorizacion);


            //generamos la cadena de la tabla
            string cadenatabla = "";

            foreach (beLicitacionesActaAdjudicacion Req in ListaReq)
            {
                //Añadimos los datos de cabecera por requisición
                Enletras let = new Enletras();

                string MontoAutorizado = Req.MontoAproximadoAutorizado.ToString("C2") + " (" + let.enletras(Req.MontoAproximadoAutorizado.ToString()) + ").";
                string MontoEjercido = Req.MontoEjercido.ToString("C2") + " (" + let.enletras(Req.MontoEjercido.ToString()) + ").";
                string MontoAdjudicado = Req.MontoTotalAdjudicado.ToString("C2") + " (" + let.enletras(Req.MontoTotalAdjudicado.ToString()) + ").";

                decimal economias = Req.MontoTotalAdjudicado - Req.MontoEjercido;

                string MontoEconomias = economias.ToString("C2") + " (" + let.enletras(economias.ToString()) + ").";

                cadenatabla += "<table><tr><td><width=5>Requisición:<td>" + Req.RequisicionFolio;
                cadenatabla += "<tr><td>Dependencia solicitante:<td>" + Req.Dependencia;
                cadenatabla += "<tr><td>Tipo de abastecimiento:<td>" + Req.FormaAbastecimiento;
                cadenatabla += "<tr><td>Monto presupuestado autorizado:<td>" + MontoAutorizado;
                cadenatabla += "<tr><td>Monto total de lotes adjudicados:<td>" + MontoAdjudicado;
                cadenatabla += "<tr><td>Ejercido:<td>" + MontoEjercido;
                cadenatabla += "<tr><td>Economías:<td>" + MontoEconomias;

                decimal subtotal = 0;
                decimal totalimpuesto = 0;


                cadenatabla += "<table><tr><td><center><width=0.8>Lote<td><center>Productos y servicios<td><center>Cantidad";
                cadenatabla += "<td><center>Unidad<td><center>Precio Unitario<td><center>Periodos<td><center>IVA";
                cadenatabla += "<td><center>Subtotal<td><center>Impuesto Total<td><center>Importe Total<td><center>Proveedor Ganador";
                foreach (var Lote in ListaLotes.Where(x => x.IdRequisicion == Req.IdRequisicion))
                {
                    subtotal += Lote.ImportePeriodo;
                    totalimpuesto += Lote.ImpuestoPeriodo;

                    decimal TotalLote = Lote.ImpuestoPeriodo + Lote.ImportePeriodo;

                    cadenatabla += "<tr><td><center>" + Lote.NoLote;
                    cadenatabla += "<td>" + Lote.BienServicio;
                    cadenatabla += "<td><center>" + Lote.Cantidad;
                    cadenatabla += "<td>" + Lote.UnidadMedida;
                    cadenatabla += "<td><center>" + Lote.PrecioUnitarioOfertado.ToString("C2");
                    cadenatabla += "<td><center>" + Lote.MesesServicio;
                    cadenatabla += "<td><center>" + Lote.ImpuestoPorcentaje.ToString("P2");
                    cadenatabla += "<td><center>" + Lote.ImportePeriodo.ToString("C2");
                    cadenatabla += "<td><center>" + Lote.ImpuestoPeriodo.ToString("C2");
                    cadenatabla += "<td><center>" + TotalLote.ToString("C2");

                    cadenatabla += "<td>" + Lote.RazonSocial;
                }
                decimal total = subtotal + totalimpuesto;
                cadenatabla += "<tr><td><th><td><th><td><th><td><th><td><th><td><th><td>TOTAL<td><center>" + subtotal.ToString("C2") + "<td><center>" + totalimpuesto.ToString("C2") + "<td><center>" + total.ToString("C2") + "<td><th>";               
            }

            clsdocfiles.Creartabla("<TABLADETALLES>", cadenatabla);
        }

        public string ImprimeArchivo(int pIdLic, int IdGobierno)
        {
            //obtenemos los datos de guardado
            brPlantillas plantillas = new brPlantillas();
            bePlantillas obeplantillas = plantillas.traerPlantillas_x_IdTipoUsoPlantilla(6, IdGobierno);

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
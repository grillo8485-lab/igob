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
    public class ClsAdjudicacionesImprimirSolicitud
    {
        public string pathLocal = @"C:\Rtflocal\"; //ruta en donde se guardarán los documento generado

        ClsWord clsdocfiles = new ClsWord();


        public void RemplazaTextoDoc(int pIdAdj)
        {
            //obtenemos los datos de la adjudicacion
            //ClsAdjudicacionesSolicitud Adj = new ClsAdjudicacionesSolicitud();
            brAdjudicacionesSolicitud Adj = new brAdjudicacionesSolicitud();
            beAdjudicacionesSolicitud obeAdj = Adj.traerAdjudicaciones_x_IdAdjudicacion_Solicitud(pIdAdj);

            //obtenemos los datos de presupuesto
            List<beAdjudicacionesSolicitud> ListaPrep = Adj.traerPresupuestosPartidas_x_IdAdjudicacion_Solicitud(pIdAdj);

            //obtenemos los datos de lotes
            List<beAdjudicacionesSolicitud> ListaAdjLotes = Adj.traerAdjudicacionesLotes_x_IdAdjudicacion_Solicitud(pIdAdj);

            //datos de condiciones de entrega
            beAdjudicacionesSolicitud obeAdjCE = Adj.traerAdjudicacionesCondicionesEntregas_x_IdAdjudicacion(pIdAdj);

            //detalles de condiciones de entrega
            List<beAdjudicacionesSolicitud> ListaAdjCED = Adj.traerAdjudicacionesCondicionesEntregasDetalles_x_IdAdjudicacion_Solicitud(pIdAdj);

            //datos de condiciones de pago
            beAdjudicacionesSolicitud obeAdjCP = Adj.traerAdjudicacionesCondicionesPagos_x_IdAdjudicacion_Solicitud(pIdAdj);

            //detalles de condiciones de pago
            List<beAdjudicacionesSolicitud> ListaAdjCPD = Adj.traerAdjudicacionesCondicionesPagosDetalles_x_IdAdjudicacion_Solicitud(pIdAdj);

            //obtenemos los datos de cartas
            List<beAdjudicacionesSolicitud> ListaCartas = Adj.traerAdjudicacionesCartas_x_IdAdjudicacion_Solicitud(pIdAdj);


            //obtenemos la fecha de hoy
            clsdocfiles.FindAndReplace("<FECHAELABORACION>", DateTime.Now.ToString("dd/MM/yyyy"));

            clsdocfiles.FindAndReplace("<NOLOTES>", obeAdj.CantidadLotes);
            clsdocfiles.FindAndReplace("<NOOFICIOSOLICITUD>", obeAdj.NumeroOficioSolicitud);
            clsdocfiles.FindAndReplace("<ADJUDICACIONFOLIO>", obeAdj.AdjudicacionFolio);
            clsdocfiles.FindAndReplace("<SOLICITUD>", obeAdj.TipoSolicitud);
            clsdocfiles.FindAndReplace("<CAPITULO>", obeAdj.Capitulo);
            clsdocfiles.FindAndReplace("<PARTIDA>", obeAdj.Partida);
            clsdocfiles.FindAndReplace("<ORIGENRECURSO>", obeAdj.OrigenRecurso);
            clsdocfiles.FindAndReplace("<VALORAPROXIMADO>", obeAdj.MontoAproximado.ToString("C"));
            clsdocfiles.FindAndReplace("<NOOFICIOCERTIFICACION>", obeAdj.NumeroOficioCertificacion);
            clsdocfiles.FindAndReplace("<EJERCICIO>", obeAdj.Ejercicio);
            clsdocfiles.FindAndReplace("<OBSERVACIONESDEPENDENCIA>", obeAdj.Observaciones);

            clsdocfiles.FindAndReplace("<SALDOPARTIDA>", obeAdj.SaldoPartida.ToString("C"));
            clsdocfiles.FindAndReplace("<MONTOAUTORIZADO>", obeAdj.MontoAproximadoAutorizado.ToString("C"));
            clsdocfiles.FindAndReplace("<SALDOPRESUPUESTO>", (obeAdj.SaldoPartida - obeAdj.MontoAproximadoAutorizado).ToString("C"));

            //clsdocfiles.FindAndReplace("<LIQUIDEZ>", obeAdj.TotalLiquidez.ToString("C"));
            clsdocfiles.FindAndReplace("<OBSERVACIONESPRESUPUESTO>", " ");

            clsdocfiles.FindAndReplace("<DEPENDENCIA>", obeAdj.Dependencia);
            clsdocfiles.FindAndReplace("<RFC>", obeAdj.Rfc);
            clsdocfiles.FindAndReplace("<CALLE>", obeAdj.Calle);
            clsdocfiles.FindAndReplace("<NOEXTERIOR>", obeAdj.NoExterior);
            clsdocfiles.FindAndReplace("<NOINTERIOR>", obeAdj.NoInterior);
            clsdocfiles.FindAndReplace("<COLONIA>", obeAdj.Colonia);
            clsdocfiles.FindAndReplace("<PAIS>", obeAdj.Pais);
            clsdocfiles.FindAndReplace("<ESTADO>", obeAdj.Estado);
            clsdocfiles.FindAndReplace("<MUNICIPIO>", obeAdj.Municipio);
            clsdocfiles.FindAndReplace("<LOCALIDAD>", obeAdj.Localidad);
            clsdocfiles.FindAndReplace("<CODIGOPOSTAL>", obeAdj.CodigoPostal);
            clsdocfiles.FindAndReplace("<EMAIL>", obeAdj.Email);

            
            //generamos la tabla de presupuesto
            string cadenatabla = "<table><tr><td><th><center>Origen de recurso<td><th><center>Clave presupuestal<td><th><center>Número ministración<td><th><center>De<td><th><center>Al";
            foreach (beAdjudicacionesSolicitud Prep in ListaPrep)
            {
                //cadenatabla += "<tr><td>" + Prep.OrigenRecurso + "<td align=center>" + Prep.ClavePresupuestal + "<td>" + Prep.NumeroMinistracion + "<td>" + Prep.MesInicio + "<td>" + Prep.MesFin;
                cadenatabla += "<tr><td>" + Prep.OrigenRecurso + "<td><center>" + Prep.ClavePresupuestal + "<td align =center>" + Prep.NumeroMinistracion + "<td align =center>" + Prep.MesInicio + "<td align =center>" + Prep.MesFin;
            }
            clsdocfiles.Creartabla("<TABLAPRESUPUESTO>", cadenatabla);
            

            //generamos la tabla a partir de la lista de lotes
            cadenatabla = "<table><tr><td><th><center>Lote<td><th><center>Cantidad<td><th><center>Unidad<td><th><center>Descripción del artículo";
            foreach (beAdjudicacionesSolicitud Lote in ListaAdjLotes)
            {
                cadenatabla += "<tr><td>" + Lote.NoLote + "<td>" + Lote.Cantidad + "<td>" + Lote.UnidadMedida + "<td>" + Lote.Descripcion;
            }
            clsdocfiles.Creartabla("<TABLALOTES>", cadenatabla);

            clsdocfiles.FindAndReplace("<TIEMPOPLAZOENTREGA>", obeAdjCE.PlazoEntrega);
            clsdocfiles.FindAndReplace("<NOTAESPECIAL>", obeAdjCE.NotaEspecial);

            //generamos la tabla de detalles de condiciones de entrega
            cadenatabla = "<table><tr><td><th><center>Numero<td><th><center>Lote<td><th><center>Cantidad a entregar<td><th><center>Lugar de entrega";
            cadenatabla += "<td><th><center>Domicilio<td><th><center>Hora inicio<td><th><center>Hora fin";
            foreach (beAdjudicacionesSolicitud CED in ListaAdjCED)
            {
                cadenatabla += "<tr><td>" + CED.NumeroEntrega + "<td>" + CED.NoLote + "<td>" + CED.Cantidad + "<td>" + CED.Lugar;
                cadenatabla += "<td>" + CED.Direccion + "<td>" + CED.HorarioInicio + "<td>" + CED.HorarioFinal;
            }
            clsdocfiles.Creartabla("<TABLACONDICIONESENTREGA>", cadenatabla);

            clsdocfiles.FindAndReplace("<PLAZOPAGOCANTIDAD>", obeAdjCP.PlazoPagoCantidad);
            clsdocfiles.FindAndReplace("<PLAZOTIEMPOPAGO>", obeAdjCP.PlazozTiempo);
            clsdocfiles.FindAndReplace("<TIPODIAPAGO>", obeAdjCP.TipoDia);
            clsdocfiles.FindAndReplace("<CONDICIONPAGO>", obeAdjCP.TipoCondicionPago);
            string pagaanticipo = "NO";
            if (obeAdjCP.Anticipo == 1)
            {
                pagaanticipo = "SI";
            }
            clsdocfiles.FindAndReplace("<ANTICIPOIMPORTE>", obeAdjCP.ImporteAnticipo.ToString("C"));
            clsdocfiles.FindAndReplace("<TOTALPAGOS>", obeAdjCP.ImporteTotalPagos.ToString("C"));
            clsdocfiles.FindAndReplace("<IMPORTETOTAL>", (obeAdjCP.ImporteAnticipo + obeAdjCP.ImporteTotalPagos).ToString("C"));
            clsdocfiles.FindAndReplace("<PAGAANTICIPO>", pagaanticipo);
            clsdocfiles.FindAndReplace("<PORCENTAJEANTICIPO>", obeAdjCP.PorcentajeAnticipo);
            clsdocfiles.FindAndReplace("<NUMEROPAGOS>", obeAdjCP.NumeroPagos);
            clsdocfiles.FindAndReplace("<PERIODICIDADPAGOS>", obeAdjCP.Periodicidad);

            //generamos la tabla de detalles de condiciones de pago
            cadenatabla = "<table><tr><td><th><center>Pago<td><th><center>Monto<td><th><center>Porcentaje<td><th><center>Fecha de pago<td><th><center>Observación";
            foreach (beAdjudicacionesSolicitud CPD in ListaAdjCPD)
            {
                cadenatabla += "<tr><td>" + CPD.NumeroPago + "<td>" + CPD.ImportePago + "<td>" + CPD.PorcentajePago + "% " + "<td>" + CPD.FechaPago + "<td>";
            }
            clsdocfiles.Creartabla("<TABLACONDICIONESPAGO>", cadenatabla);

            //generamos la tabla de cartas
            cadenatabla = "<table><tr><td><th><center>Número<td><th><center>Nombre Carta<td><th><center>Descripción";
            foreach (beAdjudicacionesSolicitud Carta in ListaCartas)
            {
                cadenatabla += "<tr><td>" + Carta.Nombre + "<td>" + Carta.Numero + "<td>" + Carta.Carta;
            }
            clsdocfiles.Creartabla("<TABLACARTAS>", cadenatabla);

        }

        public void ImprimeArchivo(int IdAdj, int IdGobierno)
        {           
            //obtenemos los datos de guardado
            brPlantillas plantillas = new brPlantillas();
            bePlantillas obeplantillas = plantillas.traerPlantillas_x_IdTipoUsoPlantilla(14, IdGobierno);

            string pRutaArchivoOrigen = obeplantillas.UrlPlantilla;

            string pDocumento = obeplantillas.NombreArchivo + IdAdj.ToString();  //nombre del nuevo documento

            clsdocfiles.WordDocument(pRutaArchivoOrigen, pathLocal, pDocumento);

            RemplazaTextoDoc(IdAdj);

            clsdocfiles.SaveDocument();

            clsdocfiles.ExportDocument(pathLocal, pDocumento);
            clsdocfiles.CloseDocument();
            Process.Start(Path.Combine(pathLocal + pDocumento + ".PDF"));
            //borramos el archivo word
            //ClsLibreriaArchivos.DeleteFile(Path.Combine(pathLocal + pDocumento + ".docx"));
        }
    }
}
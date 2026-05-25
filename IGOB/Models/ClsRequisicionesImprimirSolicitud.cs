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
    public class ClsRequisicionesImprimirSolicitud
    {
        public string pathLocal = ""; //ruta en donde se guardarán los documento generado
        public string pathPlantillas = ""; //ruta en donde se guardarán los documento generado
        ClsWord clsdocfiles = new ClsWord();

        public ClsRequisicionesImprimirSolicitud(string pathLocal_, string pathPlantillas_)
        {
            pathLocal = pathLocal_;
            pathPlantillas = pathPlantillas_;
        }
               

        public void RemplazaTextoDoc(int pIdReq)
        {
            //obtenemos los datos de la requisición
            brRequisicionesSolicitud Req = new brRequisicionesSolicitud();
            //ClsRequisicionesLista Req = new ClsRequisicionesLista();
            beRequisicionesSolicitud obeReq = Req.traerRequisiciones_x_IdRequisicion_Solicitud(pIdReq);

            //obtenemos los datos de presupuesto
            List<beRequisicionesSolicitud> ListaPrep = Req.traerPresupuestosPartidas_x_IdRequisicion_Solicitud(pIdReq);

            //obtenemos los datos de liquidez
            List<beRequisicionesSolicitud> ListaReqLiq = Req.traerRequisicionesLiquidez_x_IdRequisicion_Solicitud(pIdReq);

            //obtenemos los datos de cartas
            List<beRequisicionesSolicitud> ListaCartas = Req.traerRequisicionesCartas_x_IdRequisicion_Solicitud(pIdReq);

            //obtenemos los datos de lotes
            List<beRequisicionesSolicitud> ListaReqLotes = Req.traerRequisicionesLotes_x_IdRequisicion_Solicitud(pIdReq);

            //datos de condiciones de entrega
            beRequisicionesSolicitud obeReqCE = Req.traerRequisicionesCondicionesEntregas_x_IdRequisicion_Solicitud(pIdReq);

            //detalles de condiciones de entrega
            List<beRequisicionesSolicitud> ListaReqCED = Req.traerRequisicionesCondicionesEntregasDetalles_x_IdRequisicion_Solicitud(pIdReq);

            //datos de condiciones de pago
            beRequisicionesSolicitud obeReqCP = Req.traerRequisicionesCondicionesPagos_x_IdRequisicion_Solicitud(pIdReq);

            //detalles de condiciones de pago
            List<beRequisicionesSolicitud> ListaReqCPD = Req.traerRequisicionesCondicionesPagosDetalles_x_IdRequisicion_Solicitud(pIdReq);

            //obtenemos la fecha de hoy
            clsdocfiles.FindAndReplace("<FECHAELABORACION>", obeReq.FechaRequisicion.ToString("dd/MM/yyyy"));

            clsdocfiles.FindAndReplace("<NOLOTES>", obeReq.CantidadLotes);
            clsdocfiles.FindAndReplace("<NOOFICIOSOLICITUD>", obeReq.NumeroOficioSolicitud);
            clsdocfiles.FindAndReplace("<REQUISICIONFOLIO>", obeReq.RequisicionFolio);
            clsdocfiles.FindAndReplace("<NOLICITACION>", obeReq.NumeroLicitacion);
            clsdocfiles.FindAndReplace("<SOLICITUD>", obeReq.TipoSolicitud);
            clsdocfiles.FindAndReplace("<ABASTECIMIENTO>", obeReq.FormaAbastecimiento);
            clsdocfiles.FindAndReplace("<CAPITULO>", obeReq.Capitulo);
            clsdocfiles.FindAndReplace("<PARTIDA>", obeReq.Partida);
            clsdocfiles.FindAndReplace("<ORIGENRECURSO>", obeReq.OrigenRecurso);
            clsdocfiles.FindAndReplace("<VALORAPROXIMADO>", obeReq.MontoAproximado.ToString("C2"));
            clsdocfiles.FindAndReplace("<NOOFICIOCERTIFICACION>", obeReq.NumeroOficioCertificacion);
            clsdocfiles.FindAndReplace("<TIEMPOS>", obeReq.Tiempo);
            clsdocfiles.FindAndReplace("<EJERCICIO>", obeReq.Ejercicio);
            clsdocfiles.FindAndReplace("<OBSERVACIONESDEPENDENCIA>", obeReq.Observaciones);

            clsdocfiles.FindAndReplace("<SALDOPARTIDA>", obeReq.SaldoPartida.ToString("C2"));
            clsdocfiles.FindAndReplace("<MONTOAUTORIZADO>", obeReq.MontoAproximadoAutorizado.ToString("C2"));
            clsdocfiles.FindAndReplace("<SALDOPRESUPUESTO>", (obeReq.SaldoPartida - obeReq.MontoAproximadoAutorizado).ToString("C2"));

            //generamos la tabla de presupuesto
            string cadenatabla = "<table><tr><td><th><center>Origen de recurso<td><th><center>Clave presupuestal<td><th><center>Número ministración<td><th><center>De<td><th><center>Al";
            foreach (beRequisicionesSolicitud Prep in ListaPrep)
            {
                //    cadenatabla += "<tr><td>" + Prep.OrigenRecurso + "<td>" + Prep.ClavePresupuestal + "<td>" + Prep.NumeroMinistracion + "<td>" + Prep.MesInicio + "<td>" + Prep.MesFin;
                //
                cadenatabla += "<tr><td>" + "         "+Prep.OrigenRecurso + "<td>" +"         "+ Prep.ClavePresupuestal + "<td>" +"          "+ Prep.NumeroMinistracion + "<td>" +"        "+ Prep.MesInicio + "<td>" + "        "+Prep.MesFin;


                //cadenatabla += "<tr><td>" + Prep.OrigenRecurso + "<td><center>" + Prep.ClavePresupuestal + "<td><center>" + Prep.NumeroMinistracion + "<td><center>" + Prep.MesInicio + "<td align=center>" + Prep.MesFin;

            }
            clsdocfiles.Creartabla("<TABLAPRESUPUESTO>", cadenatabla);

            //generamos la tabla de liquidez
            cadenatabla = "<table><tr><td><th><center>Origen de recurso<td><th><center>Cuenta<td><th><center>Nombre de la cuenta<td><th><center>Banco";
            cadenatabla += "<td><th><center>Número operación<td><th><center>Saldo <td><th><center>Saldo en cuenta<td><th><center>Monto comprometido<td><th><center>Fecha Autorizado";
            decimal sumaliquidez = 0;
            foreach (beRequisicionesSolicitud Liq in ListaReqLiq)
            {
                cadenatabla += "<tr><td>" +"    "+ Liq.OrigenRecurso + "<td>" +"    "+ Liq.NumeroCuenta + "<td>" + Liq.NombreCuenta + "<td>" + Liq.NombreCorto;
                cadenatabla += "<td>" + Liq.NumeroOperacion + "<td>" + "  "+Liq.SaldoIgob + "<td>" +"  "+ Liq.SaldoCuenta + "<td>" + Liq.MontoComprometido.ToString("C2") + "<td>" + Liq.FechaRegistro;
                sumaliquidez += Liq.MontoComprometido;
            }
            clsdocfiles.Creartabla("<TABLALIQUIDEZ>", cadenatabla);

            //clsdocfiles.FindAndReplace("<LIQUIDEZ>", obeReq.TotalLiquidez.ToString("C"));
            clsdocfiles.FindAndReplace("<LIQUIDEZ>", sumaliquidez.ToString("C2"));
            clsdocfiles.FindAndReplace("<OBSERVACIONESPRESUPUESTOLIQUIDEZ>", " ");

            clsdocfiles.FindAndReplace("<DEPENDENCIA>", obeReq.Dependencia);
            clsdocfiles.FindAndReplace("<RFC>", obeReq.Rfc);
            clsdocfiles.FindAndReplace("<CALLE>", obeReq.Calle);
            clsdocfiles.FindAndReplace("<NOEXTERIOR>", obeReq.NoExterior);
            clsdocfiles.FindAndReplace("<NOINTERIOR>", obeReq.NoInterior);
            clsdocfiles.FindAndReplace("<COLONIA>", obeReq.Colonia);
            clsdocfiles.FindAndReplace("<PAIS>", obeReq.Pais);
            clsdocfiles.FindAndReplace("<ESTADO>", obeReq.Estado);
            clsdocfiles.FindAndReplace("<MUNICIPIO>", obeReq.Municipio);
            clsdocfiles.FindAndReplace("<LOCALIDAD>", obeReq.Localidad);
            clsdocfiles.FindAndReplace("<CODIGOPOSTAL>", obeReq.CodigoPostal);
            clsdocfiles.FindAndReplace("<EMAIL>", obeReq.Email);
            

            

            //generamos la tabla de cartas
            cadenatabla = "<table><tr><td><th><center>Número<td><th><center>Nombre Carta<td><th><center>Descripción";
            foreach (beRequisicionesSolicitud Carta in ListaCartas)
            {
                cadenatabla += "<tr><td>" +"                     "+ Carta.Numero + "<td>" +"      "+ Carta.Nombre + "<td>" + Carta.Carta;
            }
            clsdocfiles.Creartabla("<TABLACARTAS>", cadenatabla);

            //generamos la tabla a partir de la lista de lotes
            cadenatabla = "<table><tr><td><th><center>Lote<td><th><center>Cantidad<td><th><center>Unidad<td><th><center>Descripción del artículo";
            foreach (beRequisicionesSolicitud Lote in ListaReqLotes)
            {    
                cadenatabla += "<tr><td>" +"               " +Lote.NoLote + "<td>" +"             "+ Lote.Cantidad + "<td>" +"            "+ Lote.UnidadMedida + "<td>" + Lote.Descripcion;
            }
            clsdocfiles.Creartabla("<TABLALOTES>", cadenatabla);

            clsdocfiles.FindAndReplace("<TIEMPOPLAZOENTREGA>", obeReqCE.PlazoEntrega);
            clsdocfiles.FindAndReplace("<NOTAESPECIAL>", obeReqCE.NotaEspecial);

            //generamos la tabla de detalles de condiciones de entrega
            cadenatabla = "<table><tr><td><th><center>Numero<td><th><center>Lote<td><th><center>Cantidad a entregar<td><th><center>Lugar de entrega";
            cadenatabla += "<td><th><center>Domicilio<td><th><center>Hora inicio<td><th><center>Hora fin";
            foreach (beRequisicionesSolicitud CED in ListaReqCED)
            {
                cadenatabla += "<tr><td>" + "        "+CED.NumeroEntrega + "<td>" +"        "+ CED.NoLote + "<td>" +"       "+ CED.Cantidad + "<td>" +"  "+ CED.Lugar;
                cadenatabla += "<td>" + CED.Direccion + "<td>" + "    "+ CED.HorarioInicio + "<td>" + "    "+ CED.HorarioFinal;
            }
            clsdocfiles.Creartabla("<TABLACONDICIONESENTREGA>", cadenatabla);

            //condiciones de pago

            clsdocfiles.FindAndReplace("<PLAZOPAGOCANTIDAD>", obeReqCP.PlazoPagoCantidad);
            clsdocfiles.FindAndReplace("<PLAZOTIEMPOPAGO>", obeReqCP.PlazozTiempo);
            clsdocfiles.FindAndReplace("<TIPODIAPAGO>", obeReqCP.TipoDia);
            clsdocfiles.FindAndReplace("<CONDICIONPAGO>", obeReqCP.TipoCondicionPago);
            string pagaanticipo = "NO";
            if (obeReqCP.Anticipo == true)
            {
                pagaanticipo = "SI";
            }
            clsdocfiles.FindAndReplace("<ANTICIPOIMPORTE>", obeReqCP.ImporteAnticipo.ToString("C2"));
            clsdocfiles.FindAndReplace("<TOTALPAGOS>", obeReqCP.ImporteTotalPagos.ToString("C2"));
            clsdocfiles.FindAndReplace("<IMPORTETOTAL>", (obeReqCP.ImporteAnticipo+ obeReqCP.ImporteTotalPagos).ToString("C2"));
            clsdocfiles.FindAndReplace("<PAGAANTICIPO>", pagaanticipo);
            clsdocfiles.FindAndReplace("<PORCENTAJEANTICIPO>", obeReqCP.PorcentajeAnticipo.ToString("P2") );
            clsdocfiles.FindAndReplace("<NUMEROPAGOS>", obeReqCP.NumeroPagos);
            clsdocfiles.FindAndReplace("<PERIODICIDADPAGOS>", obeReqCP.Periodicidad);

            //generamos la tabla de detalles de condiciones de pago
            cadenatabla = "<table><tr><td><th><center>Pago<td><th><center>Monto<td><th><center>Porcentaje<td><th><center>Fecha de pago<td><th><center>Observación";
            decimal TotalPagos = 0;
            decimal TotalPorcentaje = 0;
            foreach (beRequisicionesSolicitud CPD in ListaReqCPD)
            {
                cadenatabla += "<tr><td>" +"            "+ CPD.NumeroPago + "<td>" +"       "+ CPD.ImportePago.ToString("C2")+ "<td>" +"           "+ CPD.PorcentajePago.ToString("#.##") + "% " + "<td>" + "      "+CPD.FechaPago.ToString("dd/MM/yyyy") + "<td>";
                TotalPagos += CPD.ImportePago;
                TotalPorcentaje += CPD.PorcentajePago;
            }
            //cadenatabla += "<tr><td><td>" + TotalPagos.ToString("C2") + "<td>" + TotalPorcentaje.ToString("#.##") + "% " + "<td><td>";
            clsdocfiles.Creartabla("<TABLACONDICIONESPAGO>", cadenatabla);
        }

        public string ImprimeArchivo(int pIdReq, int IdGobierno)
        {
            //obtenemos los datos de guardado
            brPlantillas plantillas = new brPlantillas();
            bePlantillas obeplantillas = plantillas.traerPlantillas_x_IdTipoUsoPlantilla(12, IdGobierno);

            string pRutaArchivoOrigen = pathPlantillas + obeplantillas.UrlPlantilla;

            string pDocumento = obeplantillas.NombreArchivo + pIdReq.ToString();  //nombre del nuevo documento

            if (File.Exists(pathLocal + pDocumento + ".PDF"))
            {
                //ya existe, solo regresa el nombre
            }
            else
            {
                //no existe, genera el documento
                clsdocfiles.WordDocument(pRutaArchivoOrigen, pathLocal, pDocumento);
                RemplazaTextoDoc(pIdReq);
                clsdocfiles.SaveDocument();
                clsdocfiles.ExportDocument(pathLocal, pDocumento);
            }

            clsdocfiles.CloseDocument();
            return pDocumento + ".PDF";

            //Process.Start(Path.Combine(pathLocal + pDocumento + ".PDF"));
            //borramos el archivo word
            //ClsLibreriaArchivos.DeleteFile(Path.Combine(pathLocal + pDocumento + ".docx"));
        }
    }
}
using iGob.Entidades;
using iGob.ReglasNegocios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace IGOB.Models
{
    public class ClsLicitacionesImprimirDictamen
    {
        public string pathLocal = ""; //ruta en donde se guardarán los documento generado
        public string pathPlantillas = ""; //ruta en donde se guardarán los documento generado
        ClsWord clsdocfiles = new ClsWord();

        public ClsLicitacionesImprimirDictamen(string pathLocal_,string pathPlantillas_)
        {
            pathLocal = pathLocal_;
            pathPlantillas = pathPlantillas_;
        }


        public void RemplazaTextoDoc(int pIdLic)
        {
            
            //obtenemos los datos necesarios
            brLicitacionesDictamen Lic = new brLicitacionesDictamen();

            //obtenemos los datos de licitacion
            beLicitacionesDictamen obeLic = Lic.traerRep_Dictamen_Licitaciones_x_IdLicitacion(pIdLic);

            //obtenemos los datos de las requisiciones en la licitacion
            List<beLicitacionesDictamen> ListaReq = Lic.traerRep_Dictamen_PropuestasTecnicaEconomica_x_IdLicitacion(pIdLic);

            //declaramos las listas que vamos a utilizar por invitación

            //Generamos la lista de lotes
            List<beLicitacionesDictamen> ListaLotes = Lic.traerRep_Dictamen_PropuestasTecnicaEconomicaLotes_x_IdLicitacion(pIdLic);

            //Generamos la lista de cartas
            List<beLicitacionesDictamen> ListaCartas = Lic.traerRep_Dictamen_Cartas_x_IdLicitacion(pIdLic);

            //Generamos la lista de condiciones de entrega
            List<beLicitacionesDictamen> ListaCondicionesEntrega = Lic.traerRep_Dictamen_RequisicionesCondicionesEntregasDetalles_x_IdLicitacion(pIdLic);

            //Generamos la lista de condiciones de pago
            List<beLicitacionesDictamen> ListaCondicionesPago = Lic.traerRep_Dictamen_RequisicionesCondicionesPagosDetalles_x_IdLicitacion(pIdLic);

            //Generamos la lista de clientes
            List<beLicitacionesDictamen> ListaClientes = Lic.traerRep_Dictamen_ManifiestoProveedoresClientes_x_IdLicitacion(pIdLic);

            //Generamos la lista de manifiestos
            List<beLicitacionesDictamen> ListaManifiestos = Lic.traerRep_Dictamen_ManifiestoProveedoresDeclaratorias_x_IdLicitacion(pIdLic);

            //obtenemos la fecha de hoy
            //clsdocfiles.FindAndReplace("<FECHAELABORACION>", DateTime.Now.ToString("dd/MM/yyyy"));

            clsdocfiles.FindAndReplace("<TITULO>", obeLic.Titulo);
            clsdocfiles.FindAndReplace("<FECHAAUTORIZACION>", obeLic.FechaAutorizacion);

            

            //generamos la cadena de la tabla
            string cadenatabla = "";

            foreach (beLicitacionesDictamen Pro in ListaReq)
            {
                //Añadimos los datos de cabecera por requisición
                Enletras let = new Enletras();            

                string cantidad =Pro.OfertaTotal.ToString("C2") + " (" + let.enletras(Pro.OfertaTotal.ToString()) + ").";

                cadenatabla += "<table><tr><td>Requisición:<td>" + Pro.RequisicionFolio;
                cadenatabla += "<tr><td>Dependencia solicitante:<td>" + Pro.Dependencia;
                cadenatabla += "<tr><td>Proveedor:<td>" + Pro.RazonSocial;
                cadenatabla += "<tr><td>Oferta total<td>" + cantidad;
                cadenatabla += "<tr><td><center>Tipo de abastecimiento<td>" + Pro.FormaAbastecimiento;

                //obtenemos los datos de la invitación actual

                //obtenemos los lotes
                

                cadenatabla += "<table><tr><td><center>LOTES";
                cadenatabla += "<table><tr><td><center>Cumple con lo ofertado";
                cadenatabla += "<td><center>Fundamento legal";
                cadenatabla += "<td><center>Lote ofertado";
                cadenatabla += "<td><center>Lote";
                cadenatabla += "<td><center>Productos y servicios";
                cadenatabla += "<td><center>Cantidad";
                cadenatabla += "<td><center>Unidad";
                cadenatabla += "<td><center>Clave pantone";
                foreach (beLicitacionesDictamen Lote in ListaLotes.Where(x => x.IdProveedorRqInvitacion == Pro.IdProveedorRqInvitacion))
                {
                    string LoteOfertado = "NO";
                    if (Lote.LoteOfertado == true) { LoteOfertado = "SI"; }
                    string AdquisicionCumple = "SI";
                    if (Lote.AdquisicionCumple == true) { AdquisicionCumple = "NO"; }
                    cadenatabla += "<tr><td><center>" + AdquisicionCumple + "<td>" + Lote.FundamentoLegal + "<td>" + LoteOfertado + "<td>" + Lote.NoLote;
                    cadenatabla += "<td>" + Lote.BienServicio + "<td>" + Lote.Cantidad + "<td>" + Lote.UnidadMedida + "<td>" + Lote.Pantone;
                }

                //obtenemos las cartas

                cadenatabla += "<table><tr><td><center>CARTAS";
                cadenatabla += "<table><tr><td><center>Inciso";
                cadenatabla += "<td><center>Nombre carta";
                cadenatabla += "<td><center>Carta";
                cadenatabla += "<td><center>Acepto";
                foreach (beLicitacionesDictamen Carta in ListaCartas.Where(x => x.IdProveedorRqInvitacion == Pro.IdProveedorRqInvitacion))
                {
                    string AceptacionCarta = "SI";
                    if (Carta.AceptacionCarta != true) { AceptacionCarta = "NO"; }
                    cadenatabla += "<tr><td><center>" + Carta.Inciso + "<td>" + Carta.Nombre + "<td>" + Carta.Carta + "<td><center>" + AceptacionCarta;
                }

                string CartaAdquisicionCumple = "NO";
                if (Pro.CartaAdquisicionCumple != true) { CartaAdquisicionCumple = "SI"; }
                cadenatabla += "<table><tr><td>Cumple con lo ofertado: " + CartaAdquisicionCumple;

                //obtenemos las condiciones de entrega
                cadenatabla += "<table><tr><td><center>CONDICIONES DE ENTREGA";
                cadenatabla += "<table><tr><td><center>Plazo de entrega<td><center>Cantidad<td><center>Unidad";
                cadenatabla += "<tr><td><center>" + Pro.PlazoEntrega + "<td><center>" + Pro.PlazoEntregaCantidad + "<td><center>" + Pro.PlazozTiempoEntrega;
                cadenatabla += "<tr><td><center>Tipo de día<td><center>Forma de entrega<td><center>Hasta";
                cadenatabla += "<tr><td><center>" + Pro.TipoDiaEntrega + "<td><center>" + Pro.TipoEntrega + "<td><center>" + Pro.FechaLimite;
                cadenatabla += "<table><tr><td>Nota especial<tr><td>" + Pro.NotaEspecial;
                                
                cadenatabla += "<table><tr><td><center>Lote<td><center>Cantidad a entregar<td><center>Lugar de entrega<td><center>Domicilio";
                
                foreach (beLicitacionesDictamen Cond in ListaCondicionesEntrega.Where(x => x.IdProveedorRqInvitacion == Pro.IdProveedorRqInvitacion))
                {
                    cadenatabla += "<tr><td><center>" + Cond.NoLote + "<td><center>" + Cond.Cantidad + "<td>" + Cond.Lugar + "<td>" + Cond.Direccion;
                }
                string CondicionEntregaAdquisicionCumple = "NO";
                if (Pro.CondicionEntregaAdquisicionCumple != true) { CondicionEntregaAdquisicionCumple = "SI"; }
                cadenatabla += "<table><tr><td>Cumple con lo ofertado: " + CondicionEntregaAdquisicionCumple;

                //obtenemos las condiciones de pago
                cadenatabla += "<table><tr><td><center>CONDICIONES DE PAGO";
                cadenatabla += "<table><tr><td><center>Cantidad<td><center>Unidad<td><center>Tipo de día";
                cadenatabla += "<tr><td><center>" + Pro.PlazoPagoCantidad + "<td><center>" + Pro.PlazosTiempoPago + "<td><center>" + Pro.TipoDiaPago;
                cadenatabla += "<tr><td><center>Condición de pago<td><center>Anticipo<td><center>Porcentaje anticipo";
                string anticipo = "NO";
                if (Pro.Anticipo == true)
                {
                    anticipo = "SI";
                }
                cadenatabla += "<tr><td><center>" + Pro.TipoCondicionPago + "<td><center>" + anticipo + "<td><center>" + Pro.PorcentajeAnticipo.ToString("P2");
                cadenatabla += "<tr><td><center>Número de pagos<td><center>Periodicidad<td><center>"; //+Anticipo
                cadenatabla += "<tr><td><center>" + Pro.NumeroPagos + "<td><center>" + Pro.Periodicidad + "<td><center>"; //+ Pro.ImporteAnticipo.ToString("C2")
                //cadenatabla += "<tr><td><center>Total de los pagos<td><center>Importe total<td><center>";
                //cadenatabla += "<tr><td><center>" + Pro.SumaTotalPagos.ToString("C2") + "<td><center>" + Pro.ImporteTotalPagos.ToString("C2") + "<td><center>";
                
                /*
                cadenatabla += "<table><tr><td><center>Pago<td><center>Monto<td><center>Porcentaje<td><center>Mes de pago<td><center>Observación";
                decimal totalpago = 0;
                decimal totalporcentaje = 0;

                foreach (beLicitacionesDictamen Cond in ListaCondicionesPago.Where(x => x.IdProveedorRqInvitacion == Pro.IdProveedorRqInvitacion))
                {
                    totalpago += Cond.ImportePago;
                    totalporcentaje += Cond.PorcentajePago;
                    cadenatabla += "<tr><td><center>" + Cond.NumeroPago + "<td><center>" + Cond.ImportePago.ToString("C2") + "<td><center>" + Cond.PorcentajePago.ToString("F") + "%<td><center>" + Cond.FechaPago.ToString("MMMM").ToUpper() + "<td>";
                }
                cadenatabla += "<tr><td><center>Total<td><center>" + totalpago.ToString("C2") + "<td><center>" + totalporcentaje.ToString("F") + "%<td><td>";

                */

                string CondicionPagoAdquisicionCumple = "NO";
                if (Pro.CondicionPagoAdquisicionCumple != true) { CondicionPagoAdquisicionCumple = "SI"; }
                cadenatabla += "<table><tr><td>Cumple con lo ofertado: " + CondicionPagoAdquisicionCumple;

                //obtenemos los requisitos adicionales
                cadenatabla += "<table><tr><td><center>REQUISITOS ADICIONALES";
                cadenatabla += "<table><tr><td><center>Descripción de infraestructura<td><center>Experiencia adquirida en el ramo<td><center>Número de empleados";
                cadenatabla += "<tr><td>" + Pro.Infraestructura + "<td>" + Pro.AnnioExperiencia + "<td><center>" + Pro.NumeroEmpleados;
                cadenatabla += "<tr><td><center>Domicilio para oir y recibir notificaciones<td><center>Capital contable<td>";
                cadenatabla += "<tr><td>" + Pro.Domicilio + "<td><center>" + Pro.CapitalContable.ToString("C2") + "<td>";

                //obtenemos los clientes
                
                cadenatabla += "<table><tr><td><center>Cliente<td><center>Dirección<td><center>Teléfono";
                
                foreach (beLicitacionesDictamen cte in ListaClientes.Where(x => x.IdProveedorRqInvitacion == Pro.IdProveedorRqInvitacion))
                {
                    cadenatabla += "<tr><td>" + cte.NombreCliente + "<td>" + cte.DirecionCliente + "<td>" + cte.TelefonoCliente;
                }

                //obtenemos los manifiestos
                
                cadenatabla += "<table><tr><td><center>Manifiesto<td><center>Acepto";
                
                foreach (beLicitacionesDictamen man in ListaManifiestos.Where(x => x.IdProveedorRqInvitacion == Pro.IdProveedorRqInvitacion))
                {
                    string Aceptacion = "NO";
                    if (man.Aceptacion == true) { Aceptacion = "SI"; }
                    cadenatabla += "<tr><td>" + man.Manifiesto + "<td><center>" + Aceptacion;
                }
                string ManifiestoAdquisicionCumple = "NO";
                if (Pro.ManifiestoAdquisicionCumple != true) { ManifiestoAdquisicionCumple = "SI"; }
                cadenatabla += "<table><tr><td>Cumple con lo ofertado: " + ManifiestoAdquisicionCumple;
            }
            
            clsdocfiles.Creartabla("<TABLADICTAMEN>", cadenatabla);
            
        }

        public string ImprimeArchivo(int pIdLic, int IdGobierno)
        {
            //obtenemos los datos de guardado
            brPlantillas plantillas = new brPlantillas();
            bePlantillas obeplantillas = plantillas.traerPlantillas_x_IdTipoUsoPlantilla(5, IdGobierno);

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
            //Process.Start(Path.Combine(pathLocal + pDocumento + ".PDF"));
            string Archivo = pDocumento + ".PDF";
            return Archivo;
            //borramos el archivo word
            //ClsLibreriaArchivos.DeleteFile(Path.Combine(pathLocal + pDocumento + ".docx"));
        }

        
    }
}
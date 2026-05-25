using iTextSharp.text;
using iTextSharp.text.pdf;
using IGOB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using iGob.ReglasNegocios;
using iGob.Entidades;
using System.Globalization;

namespace IGOB.Models
{
    public class ClsImprimirRepAdjudicacionPedido
    {
        public byte[] PrepararReporte(int IdAdjudicacionPedido)
        {
            //obtenemos los datos necesarios
            brRepAdjudicacionPedido obrRec = new brRepAdjudicacionPedido();

            //obtenemos los datos de licitacion
            beRepAdjudicacionPedido obeRec = obrRec.traerRep_AdjudicacionPedido_x_IdAdjudicacionPedido(IdAdjudicacionPedido);

            //obtenemos los datos de las requisiciones en la licitacion
            List<beRepAdjudicacionPedido> ListaRec = obrRec.traerRep_AdjudicacionPedidoDetalles_x_IdAdjudicacionPedido(IdAdjudicacionPedido);


            //declaramos variables
            Document _document;
            Font _fontStyle;

            PdfPTable _pdfTable = new PdfPTable(3);
            PdfPTable _pdfTable2 = new PdfPTable(11);

            PdfPCell _pdfPCell;
            MemoryStream _memoryStream = new MemoryStream();


            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

            _pdfTable2.WidthPercentage = 100;
            _pdfTable2.HorizontalAlignment = Element.ALIGN_LEFT;

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);

            PdfWriter.GetInstance(_document, _memoryStream);

            _document.Open();

            //tamaño de las celdas de las tablas declaradas
            _pdfTable.SetWidths(new float[] { 90f, 90f, 90f });
            _pdfTable2.SetWidths(new float[] { 10f, 40f, 20f, 20f, 30f, 20f, 30f, 20f, 20f, 30f, 30f });

            //encabezado
            _fontStyle = FontFactory.GetFont("Arial", 12f, 1);
            _pdfPCell = new PdfPCell(new Phrase("LIBERACIÓN DE PEDIDO: "+ obeRec.Folio + " ADJUDICACIÓN "+ obeRec.AdjudicacionFolio, _fontStyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase(obeRec.Dependencia, _fontStyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //salto de linea
            SaltoLinea();
            //cuerpo

            //encabezado tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Pedido", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Adjudicación", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.Colspan = 2;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //cuerpo tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 0);
            //llenado de datos
            _pdfPCell = new PdfPCell(new Phrase(obeRec.Folio, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeRec.AdjudicacionFolio, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.Colspan = 2;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //salto de linea
            SaltoLinea();
            
            //encabezado tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Partidas y conceptos", _fontStyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //cuerpo tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 0);
            //llenado de datos
            _pdfPCell = new PdfPCell(new Phrase(obeRec.Partida, _fontStyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //salto de linea
            SaltoLinea();


            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("DATOS GENERALES DEL PROVEEDOR", _fontStyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //salto de linea
            SaltoLinea();

            //encabezado tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Nombre denominación o razon social", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Clave de Registro Federal de Contribuyente (RFC)", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Calle", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //cuerpo tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 0);
            //llenado de datos
            _pdfPCell = new PdfPCell(new Phrase(obeRec.RazonSocial, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeRec.Rfc, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeRec.Calle, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //salto de linea
            SaltoLinea();


            //encabezado tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Número exterior", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Número interior", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Colonia", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //cuerpo tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 0);
            //llenado de datos
            _pdfPCell = new PdfPCell(new Phrase(obeRec.NoExterior, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeRec.NoInterior, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeRec.Colonia, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //salto de linea
            SaltoLinea();


            //encabezado tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("País", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Estado", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Municipio", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //cuerpo tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 0);
            //llenado de datos
            _pdfPCell = new PdfPCell(new Phrase(obeRec.Pais, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeRec.Estado, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeRec.Municipio, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //salto de linea
            SaltoLinea();

            //encabezado tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Localidad", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Código postal", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Correo electrónico", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //cuerpo tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 0);
            //llenado de datos
            _pdfPCell = new PdfPCell(new Phrase(obeRec.Colonia, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeRec.CodigoPostal, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeRec.Email, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //salto de linea
            SaltoLinea();
            SaltoLinea();

            //encabezado tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Fechas", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Dependencias o entidades", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Condiciones de entrega", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //cuerpo tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 0);
            //llenado de datos
            _pdfPCell = new PdfPCell(new Phrase(obeRec.FechaLimite.ToString("dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture), _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeRec.Dependencia, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeRec.TipoEntrega, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //salto de linea
            SaltoLinea();

            //encabezado tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Condiciones de pago", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Plazo de entrega", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPCell.Colspan = 2;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //cuerpo tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 0);
            //llenado de datos
            _pdfPCell = new PdfPCell(new Phrase(obeRec.PlazoPagoCantidad.ToString()+" "+obeRec.PlazozTiempoPago+" "+obeRec.TipoDiaPago+" "+obeRec.Condicion, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeRec.PlazoEntregaCantidad.ToString() + " " + obeRec.PlazozTiempoEntrega + " " + obeRec.TipoDiaEntrega + " " + obeRec.PlazoEntrega, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.Colspan = 2;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //salto de linea
            SaltoLinea();

            //tabla 2
            //encabezado
            _fontStyle = FontFactory.GetFont("Arial", 7f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Lote", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Bien o servicio", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Cantidad", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Unidad", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Lugar de entrega", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Horario", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Días de entrega", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Precio unitario", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Importe total", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Impuesto", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Total del periodo", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);
            _pdfTable2.CompleteRow();

            _fontStyle = FontFactory.GetFont("Arial", 7f, 0);
            //llenado de datos

            decimal subtotal = 0;
            decimal impuesto = 0;
            

            foreach (beRepAdjudicacionPedido Rec in ListaRec)
            {
                subtotal += Rec.ImporteOfertado;
                impuesto += Rec.ImpuestoImporte;

                _pdfPCell = new PdfPCell(new Phrase(Rec.NoLote.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Rec.BienServicio, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Rec.Cantidad.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Rec.UnidadMedida, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Rec.Lugar, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Rec.HorarioEntrega, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Rec.DiasEntrega, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Rec.PrecioUnitarioOfertado.ToString("C2"), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Rec.ImporteOfertado.ToString("C2"), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Rec.ImpuestoImporte.ToString("C2"), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Rec.TotalPeriodo.ToString("C2"), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);
                _pdfTable2.CompleteRow();
            }

            decimal total = subtotal+ impuesto;

            //subtotal
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.Colspan = 9;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Subtotal", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(subtotal.ToString("C2"), _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable2.AddCell(_pdfPCell);
            _pdfTable2.CompleteRow();

            //impuesto
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.Colspan = 9;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Impuesto", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(impuesto.ToString("C2"), _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable2.AddCell(_pdfPCell);
            _pdfTable2.CompleteRow();

            //total
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.Colspan = 9;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Total", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(total.ToString("C2"), _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable2.AddCell(_pdfPCell);
            _pdfTable2.CompleteRow();


            //_pdfTable.HeaderRows = 2;
            _document.Add(_pdfTable);
            _document.Add(_pdfTable2);
            _document.Close();
            return _memoryStream.ToArray();

            void SaltoLinea()
            {
                _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
                _pdfPCell.Colspan = 3;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPCell.Border = 0;
                _pdfPCell.ExtraParagraphSpace = 0;
                _pdfTable.AddCell(_pdfPCell);
                _pdfTable.CompleteRow();
            }
        }
    }
}
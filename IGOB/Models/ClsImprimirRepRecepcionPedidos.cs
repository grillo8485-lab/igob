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
    public class ClsImprimirRepRecepcionPedidos
    {
        public byte[] PrepararReporte(int IdPedido)
        {
            //obtenemos los datos necesarios
            brRepRecepcionPedidos obrRec = new brRepRecepcionPedidos();

            //obtenemos los datos de licitacion
            beRepRecepcionPedidos obeRec = obrRec.traerRep_RecepcionPedidos_x_IdPedido(IdPedido);

            //obtenemos los datos de las requisiciones en la licitacion
            List<beRepRecepcionPedidos> ListaRec = obrRec.traerRep_RecepcionPedidosDetalles_x_IdPedido(IdPedido);


            //declaramos variables
            Document _document;
            Font _fontStyle;

            PdfPTable _pdfTable = new PdfPTable(3);
            PdfPTable _pdfTable2 = new PdfPTable(10);

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
            _pdfTable2.SetWidths(new float[] { 10f, 40f, 30f, 20f, 20f, 20f, 30f, 30f, 30f, 40f });

            //encabezado
            _fontStyle = FontFactory.GetFont("Arial", 12f, 1);
            _pdfPCell = new PdfPCell(new Phrase("RECEPCIÓN DE PEDIDO", _fontStyle));
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
            _pdfPCell = new PdfPCell(new Phrase("Dependencia", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Estatus", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Fecha y hora", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //cuerpo tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 0);
            //llenado de datos
            _pdfPCell = new PdfPCell(new Phrase(obeRec.Dependencia, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeRec.EstatusPedido, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeRec.FechaPedido.ToString("dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture), _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //salto de linea
            SaltoLinea();

            //encabezado tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Folio del pedido", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Modalidad de licitación", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Partida", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
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

            _pdfPCell = new PdfPCell(new Phrase(obeRec.ModalidadLicitacion, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeRec.Partida, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //salto de linea
            SaltoLinea();

            //encabezado tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Requisición", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Proveedor", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.Border = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //cuerpo tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 0);
            //llenado de datos
            _pdfPCell = new PdfPCell(new Phrase(obeRec.RequisicionFolio, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeRec.RazonSocial, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.Border = 0;
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

            _pdfPCell = new PdfPCell(new Phrase("Descripción", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Unidad de medida", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Cantidad", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Cantidad recibida", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Cantidad pendiente por recibir", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Fecha recepción", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Lugar entrega", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Encargado recepción", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);
            
            _pdfPCell = new PdfPCell(new Phrase("Observación", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);
            _pdfTable2.CompleteRow();

            _fontStyle = FontFactory.GetFont("Arial", 7f, 0);
            //llenado de datos

            foreach (beRepRecepcionPedidos Rec in ListaRec)
            {
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

                _pdfPCell = new PdfPCell(new Phrase(Rec.UnidadMedida, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Rec.Cantidad.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Rec.CantidadRecibida.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Rec.CantidadxRecibir.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Rec.FechaRegistro.ToString("dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Rec.LugarEntrega, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Rec.NombreResponsable, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Rec.Observaciones, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);
                _pdfTable2.CompleteRow();
            }




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
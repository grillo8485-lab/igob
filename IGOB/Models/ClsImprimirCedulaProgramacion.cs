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
    public class ClsImprimirCedulaProgramacion
    {
        public byte[] PrepararReporte(int pIdLic)
        {
            //obtenemos los datos necesarios
            brRepCedulaProgramacion Lic = new brRepCedulaProgramacion();

            //obtenemos los datos de licitacion
            beRepCedulaProgramacion obeLic = Lic.traerRep_Cedula_Licitaciones_x_IdLicitacion(pIdLic);

            //obtenemos los datos de las requisiciones en la licitacion
            List<beRepCedulaProgramacion> ListaReq = Lic.traerRep_Cedula_Requisiciones_x_IdLicitacion(pIdLic);


            //declaramos variables
            Document _document;
            Font _fontStyle;

            PdfPTable _pdfTable = new PdfPTable(3);
            PdfPTable _pdfTable2 = new PdfPTable(4);

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
            _pdfTable2.SetWidths(new float[] { 90f, 80f, 50f, 50f });

            //encabezado
            _fontStyle = FontFactory.GetFont("Arial", 12f, 1);
            _pdfPCell = new PdfPCell(new Phrase(obeLic.Titulo, _fontStyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Arial", 12f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Cédula de programación", _fontStyle));
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
            _pdfPCell = new PdfPCell(new Phrase("Modalidad", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Número licitación por modalidad", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Ejercicio", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //cuerpo tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 0);
            //llenado de datos
            _pdfPCell = new PdfPCell(new Phrase(obeLic.Modalidad, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeLic.NumeroLicitacion, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeLic.Ejercicio.ToString(), _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //salto de linea
            SaltoLinea();

            //encabezado tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Tiempos", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Número oficial de licitación", _fontStyle));
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
            _pdfPCell = new PdfPCell(new Phrase(obeLic.Tiempo, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeLic.NumeroOficial, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.Border = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //salto de linea
            SaltoLinea();
            
            
            //encabezado tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Fecha de autorización d ela licitación", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Publicación de la convocatoria", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Límite de disposición de bases", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //cuerpo tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 0);
            //llenado de datos
            _pdfPCell = new PdfPCell(new Phrase(obeLic.FechaAutorizacion.ToString("dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture), _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeLic.FechaPublicacion.ToString("dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture), _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeLic.FechaDisposicionBases.ToString("dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture), _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //salto de linea
            SaltoLinea();


            //encabezado tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Límite de envío de preguntas de proveedores", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Límite de envío de respuestas de la dependencia o entidad", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Junta de aclaración de dudas", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //cuerpo tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 0);
            //llenado de datos
            _pdfPCell = new PdfPCell(new Phrase(obeLic.FechaLimitePreguntas.ToString("dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture), _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeLic.FechaLimiteRespuestas.ToString("dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture), _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeLic.FechaHoraAclaracionDudas.ToString("dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture), _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //salto de linea
            SaltoLinea();


            //encabezado tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Límite de envío de propuestas técnica y económica", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Entrega de dictamen", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Fallo", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //cuerpo tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 0);
            //llenado de datos
            _pdfPCell = new PdfPCell(new Phrase(obeLic.FechaEnvioPropuestasTecEco.ToString("dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture), _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeLic.FechaLimiteDictamen.ToString("dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture), _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(obeLic.FechaFallo.ToString("dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture), _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //salto de linea
            SaltoLinea();


            //encabezado tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Número de unidad licitadora", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.Border = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //cuerpo tabla
            _fontStyle = FontFactory.GetFont("Arial", 8f, 0);
            //llenado de datos
            _pdfPCell = new PdfPCell(new Phrase(obeLic.UnidadLicitadora, _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = 2;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.Border = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            //salto de linea
            SaltoLinea();


            //tabla 2
            //encabezado
            _fontStyle = FontFactory.GetFont("Arial", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Dependencia o entidad requirente", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Concepto", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Económico", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Recepción", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable2.AddCell(_pdfPCell);
            _pdfTable2.CompleteRow();

            _fontStyle = FontFactory.GetFont("Arial", 8f, 0);
            //llenado de datos

            foreach (beRepCedulaProgramacion Req in ListaReq)
            {
                _pdfPCell = new PdfPCell(new Phrase(Req.Dependencia, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Req.Partida, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Req.RequisicionFolio, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable2.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(Req.Recepcion.ToString(), _fontStyle));
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
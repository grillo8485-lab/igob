using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;

namespace IGOB.Models
{
    public class ClsWord
    {
        public Application wordApp = new Application();
        public Document aDoc;
        private object missing = Missing.Value;
        public object filename;

        public void WordDocument(string docPathOrigen, string pathLocal, string NombreDocumento)
        {
            try
            {
                ClsLibreriaArchivos.CreateEmptyDirectory(pathLocal);
                File.Copy(docPathOrigen, Path.Combine(pathLocal + NombreDocumento + ".docx"), true);
                filename = Path.Combine(pathLocal + NombreDocumento + ".docx");

                if (File.Exists((string)filename))
                {
                    object readOnly = false;
                    object isVisible = false;
                    wordApp.Visible = false;
                    aDoc = wordApp.Documents.Open(ref filename, ref missing,
                    ref readOnly, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref isVisible, ref missing, ref missing,
                    ref missing, ref missing);
                    aDoc.Activate();
                }
                else
                {
                    //MessageBox.Show("El archivo no existe.", "Sin archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                wordApp.Quit();
                //MessageBox.Show("Error durante el proceso. Descripcion: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }           
        }

        public void SaveDocument()
        {
            try
            {
                aDoc.Save();
            }
            catch (Exception ex)
            {
                wordApp.Quit();
                //MessageBox.Show("Error durante el proceso. Descripcion: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void ExportDocument(string pRutaLocal, string NombreDocumento)
        {
            try
            {
                aDoc.ExportAsFixedFormat(Path.Combine(pRutaLocal, NombreDocumento + ".pdf"),
                    WdExportFormat.wdExportFormatPDF,
                    OptimizeFor: WdExportOptimizeFor.wdExportOptimizeForOnScreen,
                    BitmapMissingFonts: true, DocStructureTags: false);
            }
            catch (Exception ex)
            {
                wordApp.Quit();
                //MessageBox.Show("Error durante el proceso. Descripcion: " + ex.Message, "Error Interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void CloseDocument()
        {
            object saveChanges = WdSaveOptions.wdSaveChanges;
            wordApp.Quit(ref saveChanges, ref missing, ref missing);

            //borramos el word
        }

        public void FindAndReplace(object findText, object replaceText)
        {
            this.FindAndReplace(wordApp, findText, replaceText);
        }

        /*
        public void FindAndReplace(Application wordApp, object findText, object replaceText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            wordApp.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
            ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms,
            ref forward, ref wrap, ref format, ref replaceText, ref replace,
            ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        }
        */
        
        public void FindAndReplace(Application wordApp, object findText, object replaceText)
        {
            Range wrdRng = aDoc.Content;

            Find find = wrdRng.Find;

            //creamos una cadena que reemplazará (para evitar conflictos si el objeto es nulo)
            string nuevotexto = "";
                        
            if (replaceText != null)
            {
                nuevotexto = replaceText.ToString();
            }

            
            //ponemos una restriccion de tamaño para encabezados y pie de pagina
            if (nuevotexto.Length < 250)
            {
                object replaceAll = WdReplace.wdReplaceAll;

                foreach (Section section in aDoc.Sections)
                {
                    //remplazamos header
                    Range headerRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Find.Text = findText.ToString();
                    headerRange.Find.Replacement.Text = nuevotexto;
                    headerRange.Find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);

                    //reemplazamos footer
                    Range footerRange = section.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    footerRange.Find.Text = findText.ToString();
                    footerRange.Find.Replacement.Text = nuevotexto;
                    footerRange.Find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                }
            }
            

            
            object token = findText; //texto a reemplazar

            

            bool result = find.Execute(ref token, true, true, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

            while (result)
            {
                //wrdRng ahora es el rango del texto buscado
                Range rangoContinua = wrdRng; //rango en el que se iniciará el siguiente elemento a crear

                rangoContinua.Text = nuevotexto;

                //reinicializamos wrdRng para buscar la siguiente palabra
                wrdRng = aDoc.Content;
                find = wrdRng.Find;

                result = find.Execute(ref token, true, true, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
            }
        }
        
        public void Creartabla(object findText, object replaceText)
        {
            this.Creartabla(wordApp, findText, replaceText);
        }

        //imprime tabla reemplazando texto
        public void Creartabla(Application wordApp, object findText, object replaceText)
        {
            Range wrdRng = aDoc.Content;  //declaramos el rango a utilizar 

            if (wrdRng.Find.Execute(findText)) //si encontró el texto a reemplazar hacemos el primer reemplazo
            {
                // separamos las tablas
                string CadenaTabla = replaceText.ToString();
                //removemos los delimitadores finales si es que se añadieron
                CadenaTabla = CadenaTabla.Replace("</table>", ""); //table se usará para hacer saltos de linea con parrafos
                CadenaTabla = CadenaTabla.Replace("</tr>", "");  //tr se usará para definir creación de Table
                CadenaTabla = CadenaTabla.Replace("</td>", "");  //td se usará para definir la impresión de cada celda de la tabla generada en la fila

                string[] Tablas = CadenaTabla.Split(new[] { "<table>" }, StringSplitOptions.None);

                int NoTablas = Tablas.Length;

                for (int t = 1; t < NoTablas; t++) //por cada tabla
                {
                    wrdRng = aDoc.Content;  //declaramos el rango a utilizar 

                    if (wrdRng.Find.Execute(findText))
                    {
                        //creamos el arreglo que contiene los anchos de columnas

                        float[] AnchosColumnas = new float[100];
                        bool AnchoDefinido = false;

                        //hacemos un split de todas las filas
                        string[] Filas = Tablas[t].Split(new[] { "<tr>" }, StringSplitOptions.None);
                        int NoFilas = Filas.Length;
                        int TRow = 1; //inicializamos las filas

                        int AnchoColumnas = 0; //para definir el número de columnas y evitar errores si se definen anchos

                        for (int r = 1; r < NoFilas; r++)
                        {

                            wrdRng = aDoc.Content;  //declaramos el rango a utilizar
                            if (wrdRng.Find.Execute(findText))
                            {
                                //definimos los elementos de la tabla (se hace una tabla por fila)
                                Table oTable; //tabla que utilizaremos
                                object posFinal; //objeto que servirá para marcar la posición final del elemento creado
                                Range rangoContinua = wrdRng; //rango en el que se iniciará el siguiente elemento a crear
                                object oRangoC; //objeto que indicará la posición donde se continuará (se usa en el caso de párrafos)
                                Paragraph oPara; //parrafo que servirá para separar las tablas 

                                //obtenemos el área de trabajo
                                float leftmargin = aDoc.PageSetup.LeftMargin;
                                float pagewidth = aDoc.PageSetup.PageWidth;
                                float righttmargin = aDoc.PageSetup.LeftMargin;
                                float workarea = pagewidth - (leftmargin + righttmargin);

                                //hacemos split de las columnas
                                string[] Columnas = Filas[r].Split(new[] { "<td>" }, StringSplitOptions.None);
                                int NoColumnas = Columnas.Length;
                                int TColumn = 1; //inicializamos las columnas


                                oTable = aDoc.Tables.Add(rangoContinua, 1, NoColumnas - 1, ref missing, ref missing); //elegimos una tabla de 1 filas y 1 columnas
                                oTable.Range.ParagraphFormat.SpaceAfter = 3;  //padding por celda
                                oTable.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle; //añade lineas internas en la tabla
                                oTable.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle; //añade el borde exterior
                                //oTable.Columns[1].Width = wordApp.CentimetersToPoints(3f); //convierte cm en pulgadas

                                //ciclo para imprimir contenido de celdas de esa fila
                                for (int c = 1; c < NoColumnas; c++)
                                {
                                    //revisamos si tiene una alineación
                                    if (Columnas[c].Contains("<center>"))
                                    {
                                        //quitamos la cadena
                                        Columnas[c] = Columnas[c].Replace("<center>", "");
                                        Columnas[c] = Columnas[c].Replace("</center>", "");

                                        //colocamos alineación centrada para esa celda
                                        oTable.Cell(TRow, TColumn).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                                    }
                                    if (Columnas[c].Contains("<left>"))
                                    {
                                        //quitamos la cadena
                                        Columnas[c] = Columnas[c].Replace("<left>", "");
                                        Columnas[c] = Columnas[c].Replace("</left>", "");

                                        //colocamos alineación centrada para esa celda
                                        oTable.Cell(TRow, TColumn).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                                    }
                                    if (Columnas[c].Contains("<right>"))
                                    {
                                        //quitamos la cadena
                                        Columnas[c] = Columnas[c].Replace("<right>", "");
                                        Columnas[c] = Columnas[c].Replace("</right>", "");

                                        //colocamos alineación centrada para esa celda
                                        oTable.Cell(TRow, TColumn).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                                    }
                                    if (Columnas[c].Contains("<th>"))
                                    {
                                        //quitamos la cadena
                                        Columnas[c] = Columnas[c].Replace("<th>", "");
                                        Columnas[c] = Columnas[c].Replace("</th>", "");

                                        //colocamos el sombreado griz
                                        oTable.Cell(TRow, TColumn).Range.Shading.BackgroundPatternColor = WdColor.wdColorGray125;
                                        //ponemos el texto en negritas
                                        oTable.Cell(TRow, TColumn).Range.Font.Bold = 1;
                                    }

                                    //si es la primer fila, revisamos si trae anchos

                                    if (TRow == 1)
                                    {
                                        //revisamos si tiene un ancho de celda
                                        if (Columnas[c].Contains("<width="))
                                        {
                                            string[] AnchoInicio = Columnas[c].Split(new[] { "<width=" }, StringSplitOptions.None);
                                            string[] AnchoFinal = AnchoInicio[1].Split(new[] { ">" }, StringSplitOptions.None);

                                            //quitamos el indicador de ancho de la cadena a insertar
                                            Columnas[c] = AnchoFinal[1];

                                            //guardamos el ancho en el arreglo
                                            AnchosColumnas[c] = float.Parse(AnchoFinal[0], CultureInfo.InvariantCulture.NumberFormat);

                                            //activamos el indicador de ancho definido
                                            AnchoDefinido = true;

                                            //indicamos el número de columnas con ancho definido
                                            AnchoColumnas = NoColumnas;
                                        }
                                        else
                                        {
                                            //no se definio ancho
                                        }
                                    }
                                    else
                                    {
                                        //verificamos si se definió ancho
                                        if (AnchoDefinido)
                                        {
                                            //verificamos si el número de columnas actual coincide con el definido
                                            if (AnchoColumnas != NoColumnas)
                                            {
                                                AnchoDefinido = false;
                                            }
                                        }
                                    }
                                                                        
                                    //imprimimos el contenido de la celda
                                    oTable.Cell(TRow, TColumn).Range.Text = Columnas[c];
                                    
                                    TColumn++;
                                }

                                //define la posición donde se continuará
                                posFinal = oTable.Range.End;
                                rangoContinua = aDoc.Range(ref posFinal, ref posFinal);

                                oRangoC = rangoContinua;
                                oPara = aDoc.Content.Paragraphs.Add(ref oRangoC);

                                //revisamos si es la ultima fila
                                if (TRow == NoFilas - 1)
                                {
                                    //insertamos parrafo para separar las tablas (esto reinicia las propiedades de la tabla)
                                    oPara.Range.InsertParagraphBefore();
                                    
                                    //si se definió ancho, se aplica
                                    if (AnchoDefinido)
                                    {
                                        float AnchoTabla = 0;
                                        float ColumnasSinAncho = 0;
                                        float espaciorestante = 0;
                                        float espaciocelda = 0;

                                        //verificamos cuantos anchos se definieron
                                        for (int c = 1; c < NoColumnas; c++)
                                        {
                                            if (AnchosColumnas[c] > 0)
                                            {
                                                //se definió el ancho
                                                AnchoTabla += wordApp.CentimetersToPoints(AnchosColumnas[c]);
                                            }
                                            else
                                            {
                                                //es una columna sin ancho asignado
                                                ColumnasSinAncho += 1;
                                            }
                                        }

                                        //si hay columnas sin ancho asignado, le asignamos el espacio restante de forma equitativa
                                        if (ColumnasSinAncho > 0)
                                        {
                                            espaciorestante = workarea - AnchoTabla;
                                            espaciocelda = espaciorestante / ColumnasSinAncho;
                                        }

                                        //rellenamos las columnas sin ancho definido con el espacio definido
                                        for (int c = 1; c < NoColumnas; c++)
                                        {
                                            if (AnchosColumnas[c] == 0)
                                            {
                                                AnchosColumnas[c] = wordApp.PointsToCentimeters(espaciocelda);
                                            }
                                        }

                                        //definimos los anchos de las columnas
                                        for (int c = 1; c < NoColumnas; c++)
                                        {                                            
                                            oTable.Columns[c].Width = wordApp.CentimetersToPoints(AnchosColumnas[c]); //convierte cm en pulgadas
                                        }
                                    }
                                }

                                if((t == NoTablas -1) && (r == NoFilas -1))
                                {
                                    //insertamos nada
                                    oPara.Range.Text = "";
                                }
                                else
                                {
                                    //insertamos la cadena para continuar la búsqueda
                                    oPara.Range.Text = findText.ToString();
                                }                                

                                TRow++;
                            }
                        }                       
                    } //fin de cada tabla
                }
            }
        }

    }
}
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
    public class ClsLicitacionesImprimirPedido
    {
        public string pathLocal = ""; //ruta en donde se guardarán los documento generado
        public string pathPlantillas = ""; //ruta en donde se guardarán los documento generado
        ClsWord clsdocfiles = new ClsWord();

        public ClsLicitacionesImprimirPedido(string pathLocal_, string pathPlantillas_)
        {
            pathLocal = pathLocal_;
            pathPlantillas = pathPlantillas_;
        }


        public void RemplazaTextoDoc(int pIdPedido)
        {
            //obtenemos los datos necesarios
            brLicitacionesPedido Lic = new brLicitacionesPedido();

            //obtenemos los datos de licitacion
            beLicitacionesPedido obeLic = Lic.traerPedido_x_IdPedido(pIdPedido);

            //obtenemos los lotes del pedido
            List<beLicitacionesPedido> ListaLotes = Lic.traerPedidoDetalles_x_IdPedido(pIdPedido);

            //obtenemos los manifiestos
            List<beLicitacionesPedido> ListaManifiestos = Lic.traerPedido_Manifiestos_x_IdPedido(pIdPedido);

            //obtenemos los firmantes
            List<beLicitacionesPedido> ListaFirmantes = Lic.traerPedido_Firmantes_x_IdPedido(pIdPedido);



            //obtenemos la fecha de hoy
            //clsdocfiles.FindAndReplace("<FECHAELABORACION>", DateTime.Now.ToString("dd/MM/yyyy"));

            clsdocfiles.FindAndReplace("<PEDIDO>", obeLic.Folio);
            clsdocfiles.FindAndReplace("<FOLIOREQUISICION>", obeLic.RequisicionFolio);
            clsdocfiles.FindAndReplace("<PARTIDACONCEPTO>", obeLic.Partida );
            clsdocfiles.FindAndReplace("<RAZONSOCIAL>", obeLic.RazonSocial);
            clsdocfiles.FindAndReplace("<RFC>", obeLic.Rfc);
            clsdocfiles.FindAndReplace("<CALLE>", obeLic.Calle);
            clsdocfiles.FindAndReplace("<NOEXTERIOR>", obeLic.NoExterior);
            clsdocfiles.FindAndReplace("<NOINTERIOR>", obeLic.NoInterior);
            clsdocfiles.FindAndReplace("<COLONIA>", obeLic.Colonia);
            clsdocfiles.FindAndReplace("<PAIS>", obeLic.Pais);
            clsdocfiles.FindAndReplace("<ESTADO>", obeLic.Estado);
            clsdocfiles.FindAndReplace("<MUNICIPIO>", obeLic.Municipio);
            clsdocfiles.FindAndReplace("<LOCALIDAD>", obeLic.Municipio);
            clsdocfiles.FindAndReplace("<CODIGOPOSTAL>", obeLic.CodigoPostal);
            clsdocfiles.FindAndReplace("<EMAIL>", obeLic.Email );
            clsdocfiles.FindAndReplace("<FECHA>", obeLic.FechaPedido);
            clsdocfiles.FindAndReplace("<DEPENDENCIA>", obeLic.Dependencia);

            //generamos la cadena de la tabla
            string cadenatabla = "<table><tr><td><center>Lote<td><center>Productos y servicios<td><center>Cantidad";
            cadenatabla += "<td><center>Unidad<tr><td><center>Precio unitario<td><center>Importe total";
            cadenatabla += "<td><center>Lugares de entrega<td><center>Horarios entrega<td><center>Días de entrega";
            decimal subtotal = 0;
            decimal impuesto = 0;
            decimal total = 0;

            foreach (beLicitacionesPedido Lote in ListaLotes)
            {
                subtotal += Lote.Importe;
                impuesto += Lote.ImporteIva;

                cadenatabla += "<tr><td><center>" + Lote.NoLote;
                cadenatabla += "<td><center>" + Lote.BienServicio;
                cadenatabla += "<td><center>" + Lote.Cantidad;
                cadenatabla += "<td><center>" + Lote.UnidadMedida;
                cadenatabla += "<td><center> $" + Lote.PrecioUnitario.ToString("C1");
                cadenatabla += "<td><center> $" + Lote.Importe.ToString("C1");
                cadenatabla += "<td><center>" + Lote.Lugar;
                cadenatabla += "<td><center>" + Lote.HorarioEntrega;
                cadenatabla += "<td><center>" + Lote.DiasEntrega;
            }

            total = subtotal + impuesto;
            cadenatabla += "<tr><td><td><td><td><td><center>SUBTOTAL:<td><center>" + subtotal.ToString("C1") + "<td><td><td>";
            cadenatabla += "<tr><td><td><td><td><td><center>IMPUESTOS:<td><center>" + impuesto.ToString("C1") + "<td><td><td>";
            cadenatabla += "<tr><td><td><td><td><td><center>TOTAL:<td><center>" + total.ToString("C1") + "<td><td><td>";

            clsdocfiles.Creartabla("<TABLADETALLES>", cadenatabla);
            
            clsdocfiles.FindAndReplace("<CONDICIONESPAGO>", obeLic.TipoCondicionPago);
            clsdocfiles.FindAndReplace("<PLAZOENTREGA>", obeLic.PlazoEntrega);
            clsdocfiles.FindAndReplace("<CONDICIONESENTREGA>", obeLic.TipoEntrega);

            //Añadimos los datos de cabecera por requisición
            Enletras let = new Enletras();

            string TotalLetra = "TOTAL CON LETRA: " +  let.enletras(total.ToString());
            
            clsdocfiles.FindAndReplace("<TOTALLETRA>", TotalLetra);

            cadenatabla = "<table>";
            int NoManifiesto = 1;
            foreach (beLicitacionesPedido Man in ListaManifiestos)
            {
                cadenatabla += "<tr><td><center>" + NoManifiesto.ToString()+ "<td>"+Man.Manifiesto;
            }

            clsdocfiles.Creartabla("<CONDICIONESCOMPRA>", cadenatabla);
            
           
            cadenatabla = "<table><tr><td><center>CARGO<td><center>NOMBRE";
            foreach (beLicitacionesPedido Pro in ListaFirmantes)
            {
                cadenatabla += "<tr><td>" + Pro.Cargo + "<td>" + Pro.Nombre;
            }

            clsdocfiles.Creartabla("<FIRMANTES>", cadenatabla);
            
            clsdocfiles.FindAndReplace("<TITULO>", obeLic.Titulo + " - " + obeLic.RequisicionFolio);
            
        }

        public string ImprimeArchivo(int pIdPedido, int IdGobierno)
        {
            //obtenemos los datos de guardado
            brPlantillas plantillas = new brPlantillas();
            bePlantillas obeplantillas = plantillas.traerPlantillas_x_IdTipoUsoPlantilla(8, IdGobierno);

            string pRutaArchivoOrigen = pathPlantillas + obeplantillas.UrlPlantilla;

            string pDocumento = obeplantillas.NombreArchivo + pIdPedido.ToString();  //nombre del nuevo documento
                       

            if (File.Exists(pathLocal + pDocumento + ".PDF"))
            {
                //ya existe, solo regresa el nombre
            }
            else
            {
                //no existe, genera el documento
                clsdocfiles.WordDocument(pRutaArchivoOrigen, pathLocal, pDocumento);
                RemplazaTextoDoc(pIdPedido);
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
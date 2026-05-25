using System;
using System.Data;

namespace iGob.Entidades
{
    public class beLicitacionesBases
    {
        //Licitaciones

        public int IdLicitacion { get; set; }
        //public int IdConfiguracionModalidad { get; set; }
        //public int IdModalidadLicitacion { get; set; }
        //public int IdEtapaLicitacion { get; set; }
        public string FolioOficial { get; set; }
        //public decimal MontoBases { get; set; }
        //public int NumeroLicitacion { get; set; }
        public DateTime FechaAutorizacion { get; set; }
        public TimeSpan HoraAutorizacion { get; set; }
        //public DateTime FechaPublicacion { get; set; }
        //public DateTime FechaDisposicionBases { get; set; }
        public DateTime FechaLimitePreguntas { get; set; }
        //public DateTime FechaLimiteRespuestas { get; set; }
        public DateTime FechaHoraAclaracionDudas { get; set; }
        public DateTime FechaEnvioPropuestasTecEco { get; set; }
        //public DateTime FechaLimiteDictamen { get; set; }
        public DateTime FechaFallo { get; set; }
        public TimeSpan HoraFallo { get; set; }
        //public int IdTipoLicitacion { get; set; }
        //public int IdTiempo { get; set; }
        //public int IdEjercicioFiscal { get; set; }
        //public int IdUnidadLicitadora { get; set; }
        //public int IdUsuarioRevisor { get; set; }
        //public int IdEstatusLicitacion { get; set; }
        //public int IdUsuarioRegistro { get; set; }
        //public DateTime FechaRegistro { get; set; }
        //public int TiempoPeriodoPujasHrs { get; set; }
        //public int TiempoAdicionalPujasMin { get; set; }
        //public int TiempoEtapaFinalMin { get; set; }
        //public bool AplicaNomenclaturaInvolucrados { get; set; }
        //public bool MostrarMontoPropuestaGanando { get; set; }
        //public bool MostrarLugarProveedor { get; set; }

        //tablas externas
        public string Tiempo { get; set; }
        public string Titulo { get; set; }
        public string Dependencias { get; set; }
        public string Partidas { get; set; }
        public string DescripcionPartidas { get; set; }
        public string ClavePartidas { get; set; }
        public string FolioRequisiciones { get; set; }
        public string PlazosEntrega { get; set; }
        public string PlazosPago { get; set; }
        public string DependenciasAbreviaturas { get; set; }
        public string DatosFacturacion { get; set; }
        public string LugarFirmaPedido { get; set; }
        public string Cartas { get; set; }


        //Lugares de entrega
        public int IdCondicionEntregaDetalle { get; set; }
        public decimal Cantidad { get; set; }
        public int NoLote { get; set; }
        public string Horario { get; set; }
        public string Dias { get; set; }
        public string LugarEntrega { get; set; }


        //Cartas
        public string RequisicionFolio { get; set; }
        public string Carta { get; set; }
        public string Nombre { get; set; }
        public int Numero { get; set; }
        public string Inciso { get; set; }


        public beLicitacionesBases()
        {

        }
    }
}

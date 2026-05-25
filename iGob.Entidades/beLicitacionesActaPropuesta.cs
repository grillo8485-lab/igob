using System;
using System.Data;

namespace iGob.Entidades
{
    public class beLicitacionesActaPropuesta
    {
        //Licitaciones
        public int IdLicitacion { get; set; }
        //public int IdConfiguracionModalidad { get; set; }
        //public int IdModalidadLicitacion { get; set; }
        //public int IdEtapaLicitacion { get; set; }
        public string FolioOficial { get; set; }
        //public decimal MontoBases { get; set; }
        //public int NumeroLicitacion { get; set; }
        //public DateTime FechaAutorizacion { get; set; }
        //public TimeSpan HoraAutorizacion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        //public DateTime FechaDisposicionBases { get; set; }
        //public DateTime FechaLimitePreguntas { get; set; }
        //public DateTime FechaLimiteRespuestas { get; set; }
        //public DateTime FechaHoraAclaracionDudas { get; set; }
        //public DateTime FechaEnvioPropuestasTecEco { get; set; }
        //public DateTime FechaLimiteDictamen { get; set; }
        //public DateTime FechaFallo { get; set; }
        //public TimeSpan HoraFallo { get; set; }
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
        public string FechaPropuestas { get; set; }
        public string HoraPropuestas { get; set; }
        public string Titulo { get; set; }
        public string Dependencias { get; set; }
        public string Partidas { get; set; }
        public string FolioRequisiciones { get; set; }
        public string EmpresasProveedoras { get; set; }


        //Preguntas
        public string RazonSocial { get; set; }
        public int IdRequisicion { get; set; }
        public string RequisicionFolio { get; set; }
        public int IdProveedorRqInvitacion { get; set; }
        public string Dependencia { get; set; }
        public string FormaAbastecimiento { get; set; }
        public decimal OfertaTotal { get; set; }
        public int NumLotes { get; set; }
        public string TotalLotes { get; set; }
        public string LotesOfertados { get; set; }


        public beLicitacionesActaPropuesta()
        {

        }
    }
}

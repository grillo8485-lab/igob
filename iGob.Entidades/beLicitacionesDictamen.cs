using System;
using System.Data;

namespace iGob.Entidades
{
    public class beLicitacionesDictamen
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
        public string Titulo { get; set; }


        //Cartas_x_IdLicitacion
        public int IdProveedorCarta { get; set; }
        public bool AceptacionCarta { get; set; }
        public string Inciso { get; set; }
        public string Nombre { get; set; }
        public string Carta { get; set; }


        //RequisicionesCondicionesEntregasDetalles_x_IdLicitacion
        public int IdCondicionEntregaDetalle { get; set; }
        public decimal Cantidad { get; set; }
        public string Lugar { get; set; }
        public string Direccion { get; set; }


        //PropuestasTecnicaEconomica_x_IdLicitacion
        public string RazonSocial { get; set; }
        public int IdRequisicion { get; set; }
        public string RequisicionFolio { get; set; }
        public int IdProveedorRqInvitacion { get; set; }

        public bool CartaAdquisicionCumple { get; set; }
        public bool CondicionEntregaAdquisicionCumple { get; set; }
        public bool CondicionPagoAdquisicionCumple { get; set; }
        public bool ManifiestoAdquisicionCumple { get; set; }

        public string CartaFundamento { get; set; }
        public string CondicionEntregaFundamento { get; set; }
        public string CondicionPagoFundamento { get; set; }
        public string ManifiestoFundamento { get; set; }


        public string Dependencia { get; set; }
        public string FormaAbastecimiento { get; set; }
        public decimal OfertaTotal { get; set; }

        public int IdRequisicionCondicionEntrega { get; set; }
        public int PlazoEntregaCantidad { get; set; }
        public DateTime FechaLimite { get; set; }
        public string TipoEntrega { get; set; }
        public string NotaEspecial { get; set; }
        public string PlazozTiempoEntrega { get; set; }
        public string TipoDiaEntrega { get; set; }
        public string PlazoEntrega { get; set; }

        public int IdRequisicionCondicionPago { get; set; }
        public int PlazoPagoCantidad { get; set; }
        public bool Anticipo { get; set; }
        public decimal PorcentajeAnticipo { get; set; }
        public int NumeroPagos { get; set; }
        public decimal ImporteAnticipo { get; set; }
        public decimal ImporteTotalPagos { get; set; }

        public string TipoCondicionPago { get; set; }
        public string Periodicidad { get; set; }
        public string PlazosTiempoPago { get; set; }
        public string TipoDiaPago { get; set; }
        public decimal SumaTotalPagos { get; set; }

        public string Infraestructura { get; set; }
        public int AnnioExperiencia { get; set; }
        public int NumeroEmpleados { get; set; }
        public string Domicilio { get; set; }
        public decimal CapitalContable { get; set; }


        //PropuestasTecnicaEconomicaLotes_x_IdLicitacion
        public int IdPropuestaTecnicaEconomica { get; set; }
        public bool LoteOfertado { get; set; }
        public bool AdquisicionCumple { get; set; }
        public string FundamentoLegal { get; set; }
        public decimal ImporteOfertado { get; set; }

        public int NoLote { get; set; }
        //public decimal Cantidad { get; set; }
        public string Pantone { get; set; }

        public string BienServicio { get; set; }
        public string UnidadMedida { get; set; }


        //RequisicionesCondicionesPagosDetalles
        public int IdRqCondicionPagoDetalle { get; set; }
        public int NumeroPago { get; set; }
        public decimal ImportePago { get; set; }
        public decimal PorcentajePago { get; set; }
        public DateTime FechaPago { get; set; }


        //ManifiestoProveedoresClientes
        public string NombreCliente { get; set; }
        public string DirecionCliente { get; set; }
        public string TelefonoCliente { get; set; }


        //ManifiestoProveedoresDeclaratorias
        public Boolean Aceptacion { get; set; }
        public string Manifiesto { get; set; }


        public beLicitacionesDictamen()
        {

        }
    }
}

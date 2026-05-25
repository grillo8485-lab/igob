using System;
using System.Data;

namespace iGob.Entidades
{
    public class beRequisicionesSolicitud
    {
        //Requisiciones
        public int IdRequisicion { get; set; }
        public int IdRequisicionOrigen { get; set; }
        public int IdDependencia { get; set; }
        public int IdTipoRequisicion { get; set; }
        public int IdTipoSolicitud { get; set; }
        public int IdOrigenRecurso { get; set; }
        public int IdOrigenRecursoAutorizado { get; set; }
        public int IdEstatus { get; set; }
        public int IdEstatusRequisicion { get; set; }
        public int NumeroLicitacion { get; set; }
        public int IdTiempo { get; set; }
        public int IdFormaAbastecimiento { get; set; }
        public int IdPartida { get; set; }
        public int IdEjercicioFiscal { get; set; }
        public int IdPresupuestoPartida { get; set; }
        public DateTime FechaRequisicion { get; set; }
        public string RequisicionFolio { get; set; }
        public int ConsecutivoRequisicion { get; set; }
        public string NumeroOficioSolicitud { get; set; }
        public string NumeroOficioCertificacion { get; set; }
        public decimal MontoAproximado { get; set; }
        public decimal MontoAproximadoAutorizado { get; set; }
        public int CantidadLotes { get; set; }
        public decimal ImporteTotalLotes { get; set; }
        public string Observaciones { get; set; }
        public string ObservacionesRechazo { get; set; }
        public TimeSpan TiempoRestante { get; set; }
        public string ColorTiempoRestante { get; set; }
        public decimal SaldoPartida { get; set; }
        public decimal MontoPresupuestado { get; set; }
        public decimal TotalLiquidez { get; set; }
        public int IdUsuarioAsignante { get; set; }
        public int Acepta2daLicitacion { get; set; }
        public int IdUsuarioRevisor { get; set; }
        public DateTime FechaAsignaRevisor { get; set; }
        public DateTime FechaAutorizacion { get; set; }
        public decimal Economia { get; set; }
        public decimal Ejercido { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }

        //2018-09-11 get all
        public string Dependencia { get; set; }
        public string Rfc { get; set; }
        public string Calle { get; set; }
        public string NoExterior { get; set; }
        public string NoInterior { get; set; }
        public string Colonia { get; set; }
        public string Localidad { get; set; }
        public string CodigoPostal { get; set; }
        public string Email { get; set; }
        public string IdMunicipio { get; set; }
        public string Municipio { get; set; }
        public string ClaveEstado { get; set; }
        public string Estado { get; set; }
        public int IdPais { get; set; }
        public string Pais { get; set; }
        public string TipoSolicitud { get; set; }
        public string OrigenRecurso { get; set; }
        public string Tiempo { get; set; }
        public string FormaAbastecimiento { get; set; }
        public string Partida { get; set; }
        public int IdCapitulo { get; set; }
        public string Capitulo { get; set; }
        public int Ejercicio { get; set; }


        //Requisiciones Liquidez

        public int IdRequisicionLiquidez { get; set; }
        //public int IdRequisicion { get; set; }
        //public int IdEstatus { get; set; }
        //public int IdOrigenRecurso { get; set; }
        public int IdCuentaBancaria { get; set; }
        public string NumeroOperacion { get; set; }
        public decimal SaldoCuenta { get; set; }
        public decimal SaldoIgob { get; set; }
        public decimal MontoComprometido { get; set; }
        public DateTime FechaDeposito { get; set; }
        //public int IdUsuarioRegistro { get; set; }
        //public DateTime FechaRegistro { get; set; }

        //datos de tablas externas
        public string NumeroCuenta { get; set; }
        public string NombreCuenta { get; set; }
        public decimal MontoDisponible { get; set; }
        //public string OrigenRecurso { get; set; }
        public int IdBanco { get; set; }
        public string NombreCorto { get; set; }


        //Requisiciones Lotes

        public int IdLote { get; set; }
        //public int IdRequisicion { get; set; }
        public int NoLote { get; set; }
        public int IdBienServicio { get; set; }
        public string Pantone { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
        public decimal PorcentajeImpuesto { get; set; }
        public decimal ImporteCImpuesto { get; set; }
        public decimal ImporteMesnsualCImpuesto { get; set; }
        public int MesesServicio { get; set; }
        public decimal Total { get; set; }
        public int MesInicial { get; set; }
        public int MesFinal { get; set; }
        public int Frecuencia { get; set; }
        public int IdMuestra { get; set; }
        //public DateTime FechaRegistro { get; set; }
        //public int IdUsuarioRegistro { get; set; }

        //Requisición Solicitud 2018-09-12
        public string Descripcion { get; set; }
        public int IdTipoProducto { get; set; }
        public string TipoProducto { get; set; }
        public int IdUnidadMedida { get; set; }
        public string UnidadMedida { get; set; }


        //Requisiciones Condiciones Entregas

        public int IdRequisicionCondicionEntrega { get; set; }
        //public int IdRequisicion { get; set; }
        public int IdTipoDia { get; set; }
        public int IdPlazoEntegra { get; set; }
        public int PlazoEntregaCantidad { get; set; }
        public DateTime FechaLimite { get; set; }
        public int IdTipoEntrega { get; set; }
        //public string Observaciones { get; set; }
        public string NotaEspecial { get; set; }
        //public int IdEstatus { get; set; }
        //public int IdUsuarioRegistro { get; set; }
        //public DateTime FechaRegistro { get; set; }
        public int IdPlazoTiempo { get; set; }

        //Proc_RequisicionesCondicionesEntregas_x_IdRequisicion_Solicitud 2018-09-12
        public string PlazoEntrega { get; set; }


        //RequisicionesCondicionesEntregaDetalles

        public int IdCondicionEntregaDetalle { get; set; }
        //public int IdRequisicionCondicionEntrega { get; set; }
        public int IdLugarEntrega { get; set; }
        public int NumeroEntrega { get; set; }
        public int IdRequisicionLote { get; set; }
        //public decimal Cantidad { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HorarioFinal { get; set; }
        public int Lunes { get; set; }
        public int Martes { get; set; }
        public int Miercoles { get; set; }
        public int Jueves { get; set; }
        public int Viernes { get; set; }
        public int Sabado { get; set; }
        public int Domingo { get; set; }

        //Requisiciones Solicitud 2018-09-12
        public string Lugar { get; set; }
        public string Direccion { get; set; }
        //public int NoLote { get; set; }


        //RequisicionesCondicionesPago

        public int IdRequisicionCondicionPago { get; set; }
        //public int IdRequisicion { get; set; }
        public bool Anticipo { get; set; }
        public decimal PorcentajeAnticipo { get; set; }
        public decimal ImporteAnticipo { get; set; }
        public int IdPeriodicidad { get; set; }
        public int NumeroPagos { get; set; }
        public decimal ImporteTotalPagos { get; set; }
        //public int IdEstatus { get; set; }
        //public string Observaciones { get; set; }
        //public int IdUsuarioRegistro { get; set; }
        //public DateTime FechaRegistro { get; set; }
        public int IdTipoCondicionPago { get; set; }
        //public int IdTipoDia { get; set; }
        //public int IdPlazoTiempo { get; set; }
        public int IdLugarFirma { get; set; }
        public int PlazoPagoCantidad { get; set; }

        //Solicitud 2018-09-12
        public string Periodicidad { get; set; }
        public string TipoCondicionPago { get; set; }
        public string TipoDia { get; set; }
        public string PlazozTiempo { get; set; }


        //RequisicionesCondicionesPagosDetalles
        public int IdRqCondicionPagoDetalle { get; set; }
        public int IdRequiscionCondicionPago { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal PorcentajePago { get; set; }
        public int NumeroPago { get; set; }
        public decimal ImportePago { get; set; }
        


        //PresupuestosPartidas

        //public int IdPresupuestoPartida { get; set; }
        //public int IdDependencia { get; set; }
        //public int IdEjercicioFiscal { get; set; }
        //public int IdPartida { get; set; }
        public decimal MontoPresupuesto { get; set; }
        //public decimal MontoComprometido { get; set; }
        public decimal MontoEjecutadoTotal { get; set; }
        public decimal MontoSaldo { get; set; }
        public decimal MontoEconomia { get; set; }
        public string NumeroMinistracion { get; set; }
        //public int IdUsuarioRegistro { get; set; }
        //public DateTime FechaRegistro { get; set; }

        //Requisiciones Solicitud 2018-09-12
        public int IdMesInicio { get; set; }
        public int IdMesFinal { get; set; }
        public string ClavePresupuestal { get; set; }
        //public int IdOrigenRecurso { get; set; }
        //public string OrigenRecurso { get; set; }
        public string MesInicio { get; set; }
        public string MesFin { get; set; }


        //Cartas
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Carta { get; set; }

        public beRequisicionesSolicitud()
        {

        }
    }
}

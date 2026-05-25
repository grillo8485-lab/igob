using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class beRequisicionesComprasMenores
    {

        public int IdRequisicionCompraMenor { get; set; }
        public int IdDependencia { get; set; }
        public int IdDepartamento { get; set; }
        public int IdOrigenRecurso { get; set; }
        public int IdEstatusCM { get; set; }
        public int IdPartida { get; set; }
        public int IdEjercicioFiscal { get; set; }
        public int IdTipoSolicitud { get; set; }
        public int IdPresupuesto { get; set; }
        public DateTime FechaRequisicion { get; set; }
        public string RequisicionFolio { get; set; }
        public int ConsecutivoRequisicion { get; set; }
        public decimal MontoAproximado { get; set; }
        public int CantidadLotes { get; set; }
        public decimal ImporteTotalLotes { get; set; }
        public string Observaciones { get; set; }
        public string Justificacion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int IdLugarEntrega { get; set; }
        public DateTime FechaPago { get; set; }
        public int IdLugarPago { get; set; }
        public decimal SaldoPartida { get; set; }
        public decimal MontoPresupuestado { get; set; }
        public int IdUsuarioAutoriza { get; set; }
        public int IdProveedor { get; set; }
        public decimal Economia { get; set; }
        public decimal Ejercido { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }

        /* Get All 31/08/2018 */
        public string Dependencia { get; set; }
        public string OrigenRecurso { get; set; }
        public string Partida { get; set; }
        public int IdCapitulo { get; set; }
        public string Capitulo { get; set; }
        public int Ejercicio { get; set; }
        public string RazonSocial { get; set; }
        public string Estatus { get; set; }

        public beRequisicionesComprasMenores()
        {

        }

        public beRequisicionesComprasMenores(int pIdRequisicionCompraMenor, int pIdDependencia, int pIdDepartamento, int pIdOrigenRecurso, int pIdEstatusCM, int pIdPartida, int pIdEjercicioFiscal, int pIdTipoSolicitud, int pIdPresupuesto, DateTime pFechaRequisicion, string pRequisicionFolio, int pConsecutivoRequisicion, decimal pMontoAproximado, int pCantidadLotes, decimal pImporteTotalLotes, string pObservaciones, string pJustificacion, DateTime pFechaEntrega, int pIdLugarEntrega, DateTime pFechaPago, int pIdLugarPago, decimal pSaldoPartida, decimal pMontoPresupuestado, int pIdUsuarioAutoriza, int pIdProveedor, decimal pEconomia, decimal pEjercido, int pIdUsuarioRegistro, DateTime pFechaRegistro)
        {
            this.IdRequisicionCompraMenor = pIdRequisicionCompraMenor;
            this.IdDependencia = pIdDependencia;
            this.IdDepartamento = pIdDepartamento;
            this.IdOrigenRecurso = pIdOrigenRecurso;
            this.IdEstatusCM = pIdEstatusCM;
            this.IdPartida = pIdPartida;
            this.IdEjercicioFiscal = pIdEjercicioFiscal;
            this.IdTipoSolicitud = pIdTipoSolicitud;
            this.IdPresupuesto = pIdPresupuesto;
            this.FechaRequisicion = pFechaRequisicion;
            this.RequisicionFolio = pRequisicionFolio;
            this.ConsecutivoRequisicion = pConsecutivoRequisicion;
            this.MontoAproximado = pMontoAproximado;
            this.CantidadLotes = pCantidadLotes;
            this.ImporteTotalLotes = pImporteTotalLotes;
            this.Observaciones = pObservaciones;
            this.Justificacion = pJustificacion;
            this.FechaEntrega = pFechaEntrega;
            this.IdLugarEntrega = pIdLugarEntrega;
            this.FechaPago = pFechaPago;
            this.IdLugarPago = pIdLugarPago;
            this.SaldoPartida = pSaldoPartida;
            this.MontoPresupuestado = pMontoPresupuestado;
            this.IdUsuarioAutoriza = pIdUsuarioAutoriza;
            this.IdProveedor = pIdProveedor;
            this.Economia = pEconomia;
            this.Ejercido = pEjercido;
            this.IdUsuarioRegistro = pIdUsuarioRegistro;
            this.FechaRegistro = pFechaRegistro;
        }


    }
}

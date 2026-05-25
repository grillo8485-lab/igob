using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class bePresupuestosPartidas {

	    public int IdPresupuestoPartida { get; set;}
	    public int IdPresupuesto { get; set;}
	    public int IdPartida { get; set;}
	    public decimal MontoPresupuesto { get; set;}
	    public decimal MontoComprometido { get; set;}
	    public decimal MontoEjecutadoTotal { get; set;}
	    public decimal MontoSaldo { get; set;}
	    public decimal MontoEconomia { get; set;}
	    public string NumeroMinistracion { get; set;}
	    public int IdUsuarioRegistro { get; set;}
	    public DateTime FechaRegistro { get; set;}
        public string Partida { get; set; }
    
        public int IdDependencia { get; set; }
        public int IdCapitulo { get; set; }
        public int IdEjercicioFiscal { get; set; }
        public decimal MontoPresupuestoTotal { get; set; }
        public decimal PreMontoComprometido { get; set; }
        public decimal PreMontoEjecutadoTotal { get; set; }
        public decimal PreMontoSaldo { get; set; }
        public decimal PreMontoEconomia { get; set; }
        public string Dependencia { get; set; }
        public string Capitulo { get; set; }
        public int Ejercicio { get; set; }

        public bePresupuestosPartidas()
	    {
		
	    }

	    public bePresupuestosPartidas( int pIdPresupuestoPartida, int pIdPresupuesto, int pIdPartida, decimal pMontoPresupuesto, decimal pMontoComprometido, decimal pMontoEjecutadoTotal, decimal pMontoSaldo, decimal pMontoEconomia, string pNumeroMinistracion, int pIdUsuarioRegistro, DateTime pFechaRegistro, string pPartida, int pIdDependencia, int pIdCapitulo, int pIdEjercicioFiscal, decimal pMontoPresupuestoTotal, decimal pPreMontoComprometido, decimal pPreMontoEjecutadoTotal, decimal pPreMontoSaldo, decimal pPreMontoEconomia, string pDependencia, string pCapitulo, int pEjercicio)
        {
		    this.IdPresupuestoPartida = pIdPresupuestoPartida;
		    this.IdPresupuesto = pIdPresupuesto;
		    this.IdPartida = pIdPartida;
		    this.MontoPresupuesto = pMontoPresupuesto;
		    this.MontoComprometido = pMontoComprometido;
		    this.MontoEjecutadoTotal = pMontoEjecutadoTotal;
		    this.MontoSaldo = pMontoSaldo;
		    this.MontoEconomia = pMontoEconomia;
		    this.NumeroMinistracion = pNumeroMinistracion;
		    this.IdUsuarioRegistro = pIdUsuarioRegistro;
		    this.FechaRegistro = pFechaRegistro;
            this.Partida = pPartida;

            this.IdDependencia = pIdDependencia;
            this.IdCapitulo = pIdCapitulo;
            this.IdEjercicioFiscal = pIdEjercicioFiscal;
            this.MontoPresupuestoTotal = pMontoPresupuestoTotal;
            this.PreMontoComprometido = pPreMontoComprometido;
            this.PreMontoEjecutadoTotal = pPreMontoEjecutadoTotal;
            this.PreMontoSaldo = pPreMontoSaldo;
            this.PreMontoEconomia = pPreMontoEconomia;
            this.Dependencia = pDependencia;
            this.Capitulo = pCapitulo;
            this.Ejercicio = pEjercicio;
        }


    }
}

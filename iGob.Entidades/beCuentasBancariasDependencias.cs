using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class beCuentasBancariasDependencias {

	    public int IdCuentaBancaria { get; set;}
	    public int IdDependencia { get; set;}
	    public int IdOrigenRecurso { get; set;}
	    public int IdBanco { get; set;}
	    public string NumeroCuenta { get; set;}
	    public string NombreCuenta { get; set;}
	    public decimal MontoDisponible { get; set;}
	    public decimal MontoDisponibleEntidad { get; set;}
	    public decimal AutorizadoIgob { get; set;}
	    public decimal MontoComprometido { get; set;}
	    public decimal MontoSaldoIgob { get; set;}
	    public decimal MontoEjecutado { get; set;}
	    public decimal MontoEconomia { get; set;}
	    public DateTime FechaMovimiento { get; set;}
	    public int IdUsuarioRegistro { get; set;}
	    public DateTime FechaRegistro { get; set;}

        /* Get All 29/08/2018 */
        public string Dependencia { get; set;}
        public string OrigenRecurso { get; set;}
        public string NombreCorto { get; set;}
        public int IdEjercicioFiscal { get; set; }
        public decimal TotalInicial { get; set; }


        public beCuentasBancariasDependencias()
	    {
		
	    }

	    public beCuentasBancariasDependencias( int pIdCuentaBancaria, int pIdDependencia, int pIdOrigenRecurso, int pIdBanco, string pNumeroCuenta, string pNombreCuenta, decimal pMontoDisponible, decimal pMontoDisponibleEntidad, decimal pAutorizadoIgob, decimal pMontoComprometido, decimal pMontoSaldoIgob, decimal pMontoEjecutado, decimal pMontoEconomia, DateTime pFechaMovimiento, int pIdUsuarioRegistro, DateTime pFechaRegistro, string pDependencia,string pOrigenRecurso,string pNombreCorto, int pIdEjercicioFiscal, decimal pTotalInicial)
	    {
		    this.IdCuentaBancaria = pIdCuentaBancaria;
		    this.IdDependencia = pIdDependencia;
		    this.IdOrigenRecurso = pIdOrigenRecurso;
		    this.IdBanco = pIdBanco;
		    this.NumeroCuenta = pNumeroCuenta;
		    this.NombreCuenta = pNombreCuenta;
		    this.MontoDisponible = pMontoDisponible;
		    this.MontoDisponibleEntidad = pMontoDisponibleEntidad;
		    this.AutorizadoIgob = pAutorizadoIgob;
		    this.MontoComprometido = pMontoComprometido;
		    this.MontoSaldoIgob = pMontoSaldoIgob;
		    this.MontoEjecutado = pMontoEjecutado;
		    this.MontoEconomia = pMontoEconomia;
		    this.FechaMovimiento = pFechaMovimiento;
		    this.IdUsuarioRegistro = pIdUsuarioRegistro;
		    this.FechaRegistro = pFechaRegistro;
            this.Dependencia = pDependencia;
            this.OrigenRecurso = pOrigenRecurso;
            this.NombreCorto = pNombreCorto;
            this.IdEjercicioFiscal = pIdEjercicioFiscal;
            this.TotalInicial = pTotalInicial;

        }


    }
}

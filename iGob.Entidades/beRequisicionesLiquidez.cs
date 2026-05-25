using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beRequisicionesLiquidez {

	public int IdRequisicionLiquidez { get; set;}
	public int IdRequisicion { get; set;}
	public int IdEstatus { get; set;}
	public int IdOrigenRecurso { get; set;}
	public int IdCuentaBancaria { get; set;}
	public string NumeroOperacion { get; set;}
	public decimal SaldoCuenta { get; set;}
	public decimal SaldoIgob { get; set;}
	public decimal MontoComprometido { get; set;}
	public DateTime FechaDeposito { get; set;}
	public int IdUsuarioRegistro { get; set;}
	public DateTime FechaRegistro { get; set;}
    public string NumeroCuenta { get; set; }
    public string NombreCuenta { get; set; }
    public decimal MontoDisponible { get; set; }
    public string OrigenRecurso { get; set; }
    public string NombreCorto { get; set; }

    public beRequisicionesLiquidez()
	{
		
	}

	public beRequisicionesLiquidez( int pIdRequisicionLiquidez, int pIdRequisicion, int pIdEstatus, int pIdOrigenRecurso, int pIdCuentaBancaria, string pNumeroOperacion, decimal pSaldoCuenta, decimal pSaldoIgob, decimal pMontoComprometido, DateTime pFechaDeposito, int pIdUsuarioRegistro, DateTime pFechaRegistro, string pNumeroCuenta, string pNombreCuenta, decimal pMontoDisponible, string pOrigenRecurso, string pNombreCorto)
	{
		this.IdRequisicionLiquidez = pIdRequisicionLiquidez;
		this.IdRequisicion = pIdRequisicion;
		this.IdEstatus = pIdEstatus;
		this.IdOrigenRecurso = pIdOrigenRecurso;
		this.IdCuentaBancaria = pIdCuentaBancaria;
		this.NumeroOperacion = pNumeroOperacion;
		this.SaldoCuenta = pSaldoCuenta;
		this.SaldoIgob = pSaldoIgob;
		this.MontoComprometido = pMontoComprometido;
		this.FechaDeposito = pFechaDeposito;
		this.IdUsuarioRegistro = pIdUsuarioRegistro;
		this.FechaRegistro = pFechaRegistro;
        this.NumeroCuenta = pNumeroCuenta;
        this.NombreCuenta = pNombreCuenta;
        this.MontoDisponible = pMontoDisponible;
        this.OrigenRecurso = pOrigenRecurso;
        this.NombreCorto = pNombreCorto;

    }


}
}

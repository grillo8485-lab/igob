using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beCondicionesEntregasDealles {

	public int IdCondicionEntregaDetalles { get; set;}
	public int IdRequisicionCondicionEntrega { get; set;}
	public int IdLugarEntregaFirma { get; set;}
	public int IdRequisicionLote { get; set;}
	public decimal CantidadEntregar { get; set;}
	public string HorarioInical { get; set;}
	public string HorarioFinal { get; set;}
	public int Lunes { get; set;}
	public int Martes { get; set;}
	public int Miercoles { get; set;}
	public int Jueves { get; set;}
	public int Viernes { get; set;}
	public int Sabado { get; set;}
	public int Domningo { get; set;}

	public beCondicionesEntregasDealles()
	{
		
	}

	public beCondicionesEntregasDealles( int pIdCondicionEntregaDetalles, int pIdRequisicionCondicionEntrega, int pIdLugarEntregaFirma, int pIdRequisicionLote, decimal pCantidadEntregar, string pHorarioInical, string pHorarioFinal, int pLunes, int pMartes, int pMiercoles, int pJueves, int pViernes, int pSabado, int pDomningo)
	{
		this.IdCondicionEntregaDetalles = pIdCondicionEntregaDetalles;
		this.IdRequisicionCondicionEntrega = pIdRequisicionCondicionEntrega;
		this.IdLugarEntregaFirma = pIdLugarEntregaFirma;
		this.IdRequisicionLote = pIdRequisicionLote;
		this.CantidadEntregar = pCantidadEntregar;
		this.HorarioInical = pHorarioInical;
		this.HorarioFinal = pHorarioFinal;
		this.Lunes = pLunes;
		this.Martes = pMartes;
		this.Miercoles = pMiercoles;
		this.Jueves = pJueves;
		this.Viernes = pViernes;
		this.Sabado = pSabado;
		this.Domningo = pDomningo;
	}


}
}

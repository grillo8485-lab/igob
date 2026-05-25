using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beRequisicionesCondicionesEntregasDetalles {

	public int IdCondicionEntregaDetalle { get; set;}
	public int IdRequisicionCondicionEntrega { get; set;}
	public int IdLugarEntrega { get; set;}
	public int NumeroEntrega { get; set;}
	public int IdRequisicionLote { get; set;}
	public decimal Cantidad { get; set;}
	public TimeSpan HorarioInicio { get; set;}
	public TimeSpan HorarioFinal { get; set;}
	public int Lunes { get; set;}
	public int Martes { get; set;}
	public int Miercoles { get; set;}
	public int Jueves { get; set;}
	public int Viernes { get; set;}
	public int Sabado { get; set;}
	public int Domingo { get; set;}
    

        public beRequisicionesCondicionesEntregasDetalles()
	{
		
	}

	public beRequisicionesCondicionesEntregasDetalles( int pIdCondicionEntregaDetalle, int pIdRequisicionCondicionEntrega, int pIdLugarEntrega, int pNumeroEntrega, int pIdRequisicionLote, decimal pCantidad, TimeSpan pHorarioInicio, TimeSpan pHorarioFinal, int pLunes, int pMartes, int pMiercoles, int pJueves, int pViernes, int pSabado, int pDomingo)
	{
		this.IdCondicionEntregaDetalle = pIdCondicionEntregaDetalle;
		this.IdRequisicionCondicionEntrega = pIdRequisicionCondicionEntrega;
		this.IdLugarEntrega = pIdLugarEntrega;
		this.NumeroEntrega = pNumeroEntrega;
		this.IdRequisicionLote = pIdRequisicionLote;
		this.Cantidad = pCantidad;
		this.HorarioInicio = pHorarioInicio;
		this.HorarioFinal = pHorarioFinal;
		this.Lunes = pLunes;
		this.Martes = pMartes;
		this.Miercoles = pMiercoles;
		this.Jueves = pJueves;
		this.Viernes = pViernes;
		this.Sabado = pSabado;
		this.Domingo = pDomingo;
	}


}
}

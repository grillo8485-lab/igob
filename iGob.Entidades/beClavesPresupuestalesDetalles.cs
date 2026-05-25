using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
public class beClavesPresupuestalesDetalles {

	public int IdClavePresupuestalDetalle { get; set;}
	public int IdPresupuestoPartida { get; set;}
	public int IdOrigenRecurso { get; set;}
	public int IdMesInicio { get; set;}
	public int IdMesFinal { get; set;}
	public string ClavePresupuestal { get; set;}
	public decimal MontoPresupuestado { get; set;}
	public decimal MontoComprometido { get; set;}
	public decimal MontoDisponible { get; set;}

    public int IdUsuarioRegistro { get; set; }
    public DateTime FechaRegistro { get; set; }

    public string OrigenRecurso { get; set; }
    public string MesInicial { get; set; }
    public string MesFinal { get; set; }

        public beClavesPresupuestalesDetalles()
	{
		
	}

	public beClavesPresupuestalesDetalles( int pIdClavePresupuestalDetalle, int pIdClavePresupuestal, int pIdOrigienRecurso, int pIdMesInicio, int pIdMesFinal, string pClavePresupuestal, decimal pMontoPresupuestado, decimal pMontoComprometido, decimal pMontoDisponible,
        int pIdUsuarioRegistro, DateTime pFechaRegistro, 
        string pOrigenRecurso, string pMesInicial, string pMesFinal)
	{
		this.IdClavePresupuestalDetalle = pIdClavePresupuestalDetalle;
		this.IdPresupuestoPartida = pIdClavePresupuestal;
		this.IdOrigenRecurso = pIdOrigienRecurso;
		this.IdMesInicio = pIdMesInicio;
		this.IdMesFinal = pIdMesFinal;
		this.ClavePresupuestal = pClavePresupuestal;
		this.MontoPresupuestado = pMontoPresupuestado;
		this.MontoComprometido = pMontoComprometido;
		this.MontoDisponible = pMontoDisponible;

        this.IdUsuarioRegistro = pIdUsuarioRegistro;
        this.FechaRegistro = pFechaRegistro;

        this.OrigenRecurso = pOrigenRecurso;
        this.MesInicial = pMesInicial;
        this.MesFinal = pMesFinal;



        }


}
}

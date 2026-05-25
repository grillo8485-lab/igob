using System;
using System.Data;

// debe cambiar los nombres de las clases a singular.
namespace iGob.Entidades
{
    public class beAdjudicacionesCondicionesEntregasDetalles {

	    public int IdAdCondicionEntregaDetalle { get; set;}
	    public int IdAdjudicacionCondicionEntrega { get; set;}
	    public int IdLugarEntrega { get; set;}
	    public int NumeroEntrega { get; set;}
	    public int IdAdjudicacionLote { get; set;}
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

        public int IdAdjudicacion { get; set; }
        public int IdTipoDia { get; set; }
        public int IdPlazoEntegra { get; set; }
        public int IdPlazoTiempo { get; set; }
        public int PlazoEntregaCantidad { get; set; }
        public DateTime FechaLimite { get; set; }
        public int IdTipoEntrega { get; set; }
        public string Observaciones { get; set; }
        public string NotaEspecial { get; set; }
        public int IdEstatus { get; set; }
        public int IdAdjucacionLote { get; set; }
        public int i { get; set; }

        public string Lugar { get; set; }
        public string Direccion { get; set; }
        public string Colonia { get; set; }
        public string CodigoPostal { get; set; }
        public string LocalizacionGoogle { get; set; }
        public string IdMunicipio { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public int NoLote { get; set; }

        public beAdjudicacionesCondicionesEntregasDetalles()
	    {
		
	    }

            public beAdjudicacionesCondicionesEntregasDetalles(int pIdAdCondicionEntregaDetalle, int pIdAdjudicacionCondicionEntrega, int pIdLugarEntrega, int pNumeroEntrega, int pIdAdjudicacionLote, decimal pCantidad, TimeSpan pHorarioInicio, TimeSpan pHorarioFinal, int pLunes, int pMartes, int pMiercoles, int pJueves, int pViernes, int pSabado, int pDomingo,
                int pIdAdjudicacion,
                int pIdTipoDia,
                int pIdPlazoEntegra,
                int pIdPlazoTiempo,
                int pPlazoEntregaCantidad,
                DateTime pFechaLimite,
                int pIdTipoEntrega,
                string pObservaciones,
                string pNotaEspecial,
                int pIdEstatus,
                int pIdAdjucacionLote,
                int pi
            )
	    {
		    this.IdAdCondicionEntregaDetalle = pIdAdCondicionEntregaDetalle;
		    this.IdAdjudicacionCondicionEntrega = pIdAdjudicacionCondicionEntrega;
		    this.IdLugarEntrega = pIdLugarEntrega;
		    this.NumeroEntrega = pNumeroEntrega;
		    this.IdAdjudicacionLote = pIdAdjudicacionLote;
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

                this.IdAdjudicacion = pIdAdjudicacion;
                this.IdTipoDia = pIdTipoDia;
                this.IdPlazoEntegra = pIdPlazoEntegra;
                this.IdPlazoTiempo = pIdPlazoTiempo;
                this.PlazoEntregaCantidad = pPlazoEntregaCantidad;
                this.FechaLimite = pFechaLimite;
                this.IdTipoEntrega = pIdTipoEntrega;
                this.Observaciones = pObservaciones;
                this.NotaEspecial = pNotaEspecial;
                this.IdEstatus = pIdEstatus;
                this.IdAdjucacionLote = pIdAdjucacionLote;
                this.i = pi;
            }
    }
}

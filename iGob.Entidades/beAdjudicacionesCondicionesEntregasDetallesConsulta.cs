using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.Entidades
{
    public class beAdjudicacionesCondicionesEntregasDetallesConsulta
    {
        public int IdAdjudicacionCondicionEntrega { get; set; }
        public int IdCondicionEntregaDetalle { get; set; }
        public int NumeroEntrega { get; set; }
        public int NoLote { get; set; }
        public decimal CantidadEntregaDetalle { get; set; }
        public string Lugar { get; set; }
        public string DomicilioEntrega { get; set; }
        public string LocalizacionGoogle { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HorarioFinal { get; set; }
        public int Lunes { get; set; }
        public int Martes { get; set; }
        public int Miercoles { get; set; }
        public int Jueves { get; set; }
        public int Viernes { get; set; }
        public int Sabado { get; set; }
        public int Domingo { get; set; }
        public int i { get; set; }

        public int IdAdjudicacion { get; set; }
        public int IdTipoDia { get; set; }
        public int IdPlazoEntegra {get; set;}
        public int IdPlazoTiempo {get; set;}
        public DateTime PlazoEntregaCantidad {get; set;}
        public DateTime FechaLimite {get; set;}
        public int IdTipoEntrega {get; set;}
        public string Observaciones {get; set;}
        public string NotaEspecial {get; set;}
        public int IdEstatus {get; set;}
        public int IdAdCondicionEntregaDetalle {get; set;}
        public int IdLugarEntrega {get; set;}
        public int IdAdjucacionLote {get; set;}
        public decimal Cantidad {get; set;}



        public beAdjudicacionesCondicionesEntregasDetallesConsulta()
        { }

        public beAdjudicacionesCondicionesEntregasDetallesConsulta(
            int pIdAdjudicacionCondicionEntrega, int pIdCondicionEntregaDetalle, int pNumeroEntrega, int pNoLote, decimal pCantidadEntregaDetalle, string pLugar, string pDomicilioEntrega, string pLocalizacionGoogle,
            TimeSpan pHorarioInicio, TimeSpan pHorarioFinal, int pLunes, int pMartes, int pMiercoles, int pJueves, int pViernes, int pSabado, int pDomingo,
            int pIdAdjudicacion,
            int pIdTipoDia,
            int pIdPlazoEntegra,
            int pIdPlazoTiempo,
            DateTime pPlazoEntregaCantidad,
            DateTime pFechaLimite,
            int pIdTipoEntrega,
            string pObservaciones,
            string pNotaEspecial,
            int pIdEstatus,
            int pIdAdCondicionEntregaDetalle,
            int pIdLugarEntrega,
            int pIdAdjucacionLote,
            decimal pCantidad
            )
        {
            this.IdAdjudicacionCondicionEntrega = pIdAdjudicacionCondicionEntrega;
            this.IdCondicionEntregaDetalle = pIdCondicionEntregaDetalle;
            this.NumeroEntrega = pNumeroEntrega;
            this.NoLote = pNoLote;
            this.CantidadEntregaDetalle = pCantidadEntregaDetalle;
            this.Lugar = pLugar;
            this.DomicilioEntrega = pDomicilioEntrega;
            this.LocalizacionGoogle = pLocalizacionGoogle;
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
            this.IdAdCondicionEntregaDetalle = pIdAdCondicionEntregaDetalle;
            this.IdLugarEntrega = pIdLugarEntrega;
            this.IdAdjucacionLote = pIdAdjucacionLote;
            this.Cantidad = pCantidad;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.Entidades
{
    public class beRequisicionCondicionesEntregaDetalleConsulta
    {
        public int IdRequisicionCondicionEntrega { get; set; }
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
        public bool Ofertado { get; set; }
        public beRequisicionCondicionesEntregaDetalleConsulta()
        {

        }

        public beRequisicionCondicionesEntregaDetalleConsulta(
            int pIdRequisicionCondicionEntrega,
            int pIdCondicionEntregaDetalle,
            int pNumeroEntrega,
int pNoLote,
decimal pCantidadEntregaDetalle,
string pLugar,
string pDomicilioEntrega,
string pLocalizacionGoogle,
TimeSpan pHorarioInicio,
TimeSpan pHorarioFinal,
int pLunes,
int pMartes,
int pMiercoles,
int pJueves,
int pViernes,
int pSabado,
int pDomingo
            )
        {
            this.IdRequisicionCondicionEntrega = pIdRequisicionCondicionEntrega;
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
        }
    }
}

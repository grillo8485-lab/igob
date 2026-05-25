using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.Entidades
{
    public class beListadoGenerarLicitacion
    {
        public int IdRequisicion { get; set; }
        public int IdRequisicionOrigen { get; set; }
        public int IdDependencia { get; set; }
        public int IdTipoRequisicion { get; set; }
        public int IdTipoSolicitud { get; set; }
        public int IdOrigenRecurso { get; set; }
        public int IdOrigenRecursoAutorizado { get; set; }
        public int IdEstatus { get; set; }
        public int IdPartida { get; set; }
        public int IdEjercicioFiscal { get; set; }
        public string RequisicionFolio { get; set; }
        public decimal MontoAproximado { get; set; }
        public decimal MontoAproximadoAutorizado { get; set; }
        public int IdUsuarioRevisor { get; set; }
        public string Dependencia { get; set; }
        public string ClavePartida { get; set; }
        public string Partida { get; set; }
        public string TipoSolicitud { get; set; }
        public int? Seleccionada { get; set; }
        public int IdLicitacion { get; set; }
        public string Licitacion { get; set; }
        public int NumeroLicitacion { get; set; }
        public beListadoGenerarLicitacion() { }
        
        public beListadoGenerarLicitacion(int pIdRequisicion, int pIdRequisicionOrigen, int pIdDependencia, int pIdTipoRequisicion, int pIdTipoSolicitud, int pIdOrigenRecurso, int pIdOrigenRecursoAutorizado,int pIdEstatus, int pIdPartida, int pIdEjercicioFiscal, string pRequisicionFolio, decimal pMontoAproximado, decimal pMontoAproximadoAutorizado, int pIdUsuarioRevisor,string pDependencia, string pClavePartida, string pPartida, string pTipoSolicitud, int? pSeleccionada, int pIdLicitacion)
        {
            this.IdRequisicion = pIdRequisicion;
            this.IdRequisicionOrigen = pIdRequisicionOrigen;
            this.IdDependencia = pIdDependencia;
            this.IdTipoRequisicion = IdTipoRequisicion;
            this.IdTipoSolicitud = pIdTipoSolicitud;
            this.IdOrigenRecurso = pIdOrigenRecurso;
            this.IdOrigenRecursoAutorizado = pIdOrigenRecursoAutorizado;
            this.IdEstatus = pIdEstatus;
            this.IdPartida = pIdPartida;
            this.IdEjercicioFiscal = pIdEjercicioFiscal;
            this.RequisicionFolio = pRequisicionFolio;
            this.MontoAproximado = pMontoAproximado;
            this.MontoAproximadoAutorizado = pMontoAproximadoAutorizado;
            this.IdUsuarioRevisor = pIdUsuarioRevisor;
            this.Dependencia = pDependencia;
            this.ClavePartida = pClavePartida;
            this.Partida = pPartida;
            this.TipoSolicitud = pTipoSolicitud;
            this.Seleccionada = pSeleccionada;
            this.IdLicitacion = pIdLicitacion;
        }

    }
}

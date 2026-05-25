using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.Entidades
{
    public class bePreguntaRespuestaSolicitanteDependencia
    {
        public int IdPregunta { get; set; }
        public int NoPregunta { get; set; }
        public string Pregunta { get; set; }
        public int IdEstatusPregunta { get; set; }
        public int IdProveedorRqInvitacion { get; set; }
        public int IdRequisicion { get; set; }
        public string EstatusPregunta { get; set; }
        public int IdRespuesta { get; set; }
        public string Respuesta { get; set; }
        public int IdEstatusRespuesta { get; set; }
        public string EstatusRespuesta { get; set; }
        public string Observaciones { get; set; }
        public int IdEstatusRespuestaGeneral { get; set; }

        public bePreguntaRespuestaSolicitanteDependencia()
        {

        }
    }
}

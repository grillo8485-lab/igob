using iGob.Entidades;
using iGob.ReglasNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class ClsRespuestaPreguntaSolicitante
    {
        public List<bePreguntaRespuestaSolicitanteDependencia> getAllPreguntaRespuesta_x_IdRequisicion(int pIdRequisicion)
        {
            return (new brPreguntaRespuestaSolicitanteDependencia()).listarTodos_PreguntaRespuesta_x_IdRequisicion(pIdRequisicion);
        }
        public beRespuestas getRespuesta(int pIdRespuesta)
        {
            return (new brRespuestas()).traerRespuestas_x_IdRespuesta(pIdRespuesta);
        }
        public int saveRespuesta(beRespuestas pRespuesta)
        {
            return (new brRespuestas()).actualizarRespuestas(pRespuesta);
        }
        public string getTitulo(int pIdlicitacion,int pIdDependencia,int pIdRequisicion,string licitacion)
        {
            //new brListadoLicitacionesInvitacionProveedores().PropuestasTecnicasRevisor_IdLicitacion((int)ViewBag.IdLicitacion)
            //var a = new brListadoLicitacionesInvitacionProveedores().PropuestasTecnicasRevisor_IdLicitacion(pIdlicitacion).First().RequisicionFolio;//licitacion Solicitante 
            //var a = new brListadoLicitacionesInvitacionProveedores().ListadoRequisicionLicitacionSolictanteDependencia(pIdlicitacion).Where(s=> s.IdRequisicion== pIdRequisicion).First().RequisicionFolio;//licitacion Solicitante IdLicitacion,IdDependencia
            //var f= (new brListadoLicitacionesInvitacionProveedores()).Licitaciones_x_SolictanteDependencia(pIdDependencia).Where(s => s.IdLicitacion == pIdlicitacion).First().Licitacion;
            return licitacion;// + " - " +a;
        }
        public int getEstatusRespuesta(int pIdRequisicion)
        {
            var a = (new brPreguntaRespuestaSolicitanteDependencia()).listarTodos_PreguntaRespuesta_x_IdRequisicion(pIdRequisicion).Where(s => s.IdEstatusRespuesta == 1 || s.IdEstatusRespuesta==3).ToList();
            if (a.Count() > 0)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        public int getEstatusRespuestaAutorizar(int pIdRequisicion)
        {
            var a = (new brPreguntaRespuestaSolicitanteDependencia()).listarTodos_PreguntaRespuesta_x_IdRequisicion(pIdRequisicion);

            if (a.Where(s => s.IdEstatusRespuestaGeneral == 2 || s.IdEstatusRespuestaGeneral == 1).ToList().Count() > 0)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
        public int saveRechazo(beRespuestasRechazadas pRespuestaRechazo)
        {
            return (new brRespuestasRechazadas()).guardarRespuestasRechazadas(pRespuestaRechazo);
        }
    }
}
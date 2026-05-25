using iGob.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGOB.Models
{
    public class RespuestaPreguntaSolicitante
    {
        public List<bePreguntaRespuestaSolicitanteDependencia> lstPreguntaRespuestaSolicitanteDependencia = new List<bePreguntaRespuestaSolicitanteDependencia>();
        public string Titulo = string.Empty;
        public int IdRequisicion = int.MinValue;
        public int IdEstatusRespues = int.MinValue;
        public int IdLicitacion = int.MinValue;
        public int IdTipoProveso = int.MinValue;
        public bePreguntaRespuestaSolicitanteDependencia obPreguntaRespuesta = new bePreguntaRespuestaSolicitanteDependencia();
    }
}
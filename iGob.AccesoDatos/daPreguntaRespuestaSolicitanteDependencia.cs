using iGob.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.AccesoDatos
{
    public class daPreguntaRespuestaSolicitanteDependencia
    {
        public List<bePreguntaRespuestaSolicitanteDependencia> listarTodos_PreguntaRespuesta_x_IdRequisicion(SqlConnection Conexion, int pIdRequisicion)
        {
            List<bePreguntaRespuestaSolicitanteDependencia> lbePreguntaRespuestaSolicitanteDependencia = new List<bePreguntaRespuestaSolicitanteDependencia>();
            string sp = "Proc_PreguntasRequisiciones_x_IdRequisicion";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = pIdRequisicion;

            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdPregunta = datard.GetOrdinal("IdPregunta");
                        int posNoPregunta = datard.GetOrdinal("NoPregunta");
                        int posPregunta = datard.GetOrdinal("Pregunta");
                        int posIdEstatusPregunta = datard.GetOrdinal("IdEstatusPregunta");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posEstatusPregunta = datard.GetOrdinal("EstatusPregunta");
                        int posIdRespuesta = datard.GetOrdinal("IdRespuesta");
                        int posRespuesta = datard.GetOrdinal("Respuesta");
                        int posIdEstatusRespuesta = datard.GetOrdinal("IdEstatusRespuesta");
                        int posEstatusRespuesta = datard.GetOrdinal("EstatusRespuesta");
                        int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posIdEstatusRespuestaGeneral = datard.GetOrdinal("IdEstatusRespuestaGeneral");

                        while (datard.Read())
                        {
                            bePreguntaRespuestaSolicitanteDependencia obePreguntaRespuestaSolicitanteDependencia = new bePreguntaRespuestaSolicitanteDependencia();
                            obePreguntaRespuestaSolicitanteDependencia.IdPregunta = datard.GetInt32(posIdPregunta);
                            obePreguntaRespuestaSolicitanteDependencia.NoPregunta = datard.GetInt32(posNoPregunta);
                            obePreguntaRespuestaSolicitanteDependencia.Pregunta = datard.GetString(posPregunta);
                            obePreguntaRespuestaSolicitanteDependencia.IdEstatusPregunta = datard.GetInt32(posIdEstatusPregunta);
                            obePreguntaRespuestaSolicitanteDependencia.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);
                            obePreguntaRespuestaSolicitanteDependencia.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obePreguntaRespuestaSolicitanteDependencia.EstatusPregunta = datard.GetString(posEstatusPregunta);
                            obePreguntaRespuestaSolicitanteDependencia.IdRespuesta = datard.GetInt32(posIdRespuesta);
                            obePreguntaRespuestaSolicitanteDependencia.Respuesta = datard.GetString(posRespuesta);
                            obePreguntaRespuestaSolicitanteDependencia.IdEstatusRespuesta = datard.GetInt32(posIdEstatusRespuesta);
                            obePreguntaRespuestaSolicitanteDependencia.EstatusRespuesta = datard.GetString(posEstatusRespuesta);
                            obePreguntaRespuestaSolicitanteDependencia.Observaciones = datard.GetString(posObservaciones);
                            obePreguntaRespuestaSolicitanteDependencia.IdEstatusRespuestaGeneral = datard.GetInt32(posIdEstatusRespuestaGeneral);
                            lbePreguntaRespuestaSolicitanteDependencia.Add(obePreguntaRespuestaSolicitanteDependencia);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbePreguntaRespuestaSolicitanteDependencia;
            }
        }
    }
}

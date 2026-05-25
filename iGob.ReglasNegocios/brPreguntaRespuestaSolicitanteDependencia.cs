using iGob.AccesoDatos;
using iGob.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGob.ReglasNegocios
{
    public class brPreguntaRespuestaSolicitanteDependencia : brConexion
    {
        public List<bePreguntaRespuestaSolicitanteDependencia> listarTodos_PreguntaRespuesta_x_IdRequisicion(int pIdRequisicion)
        {
            List<bePreguntaRespuestaSolicitanteDependencia> lbePreguntaRespuestaSolicitanteDependencia = new List<bePreguntaRespuestaSolicitanteDependencia>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPreguntaRespuestaSolicitanteDependencia odaConfiguracionesModalidades = new daPreguntaRespuestaSolicitanteDependencia();
                    lbePreguntaRespuestaSolicitanteDependencia = odaConfiguracionesModalidades.listarTodos_PreguntaRespuesta_x_IdRequisicion(con, pIdRequisicion);
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

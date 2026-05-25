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
    public class brListadoGenerarLicitacion : brConexion
    {
        public List<beListadoGenerarLicitacion> ListadoGenerarLicitacion(int IdTipoLicitacion, int IdEjercicioFiscal, int IdUsuarioRevisor, int IdTipoRequisicion)
        {
            List<beListadoGenerarLicitacion> listadoGenerarLicitacion = new List<beListadoGenerarLicitacion>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daListadoGenerarLicitacion a = new daListadoGenerarLicitacion();
                    listadoGenerarLicitacion = a.ListadoGenerarLicitacion(con, IdTipoLicitacion,IdEjercicioFiscal,IdUsuarioRevisor, IdTipoRequisicion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listadoGenerarLicitacion;
            }
        }
    }
}

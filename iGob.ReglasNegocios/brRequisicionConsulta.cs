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
    public class brRequisicionConsulta : brConexion
    {
        public List<beRequisicionConsulta> listarRequisicionConsulta(beGenerica oGenerico)
        {
            List<beRequisicionConsulta> listaRequisicionConsulta = new List<beRequisicionConsulta>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    
                    daRequisicionConsulta a = new daRequisicionConsulta();
                    listaRequisicionConsulta = a.listarRequisicionConsulta(con, oGenerico);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listaRequisicionConsulta;
            }
        }
        public List<beRequisicionConsulta> listarRequisicionSegundaVueltaConsulta(beGenerica oGenerico)
        {
            List<beRequisicionConsulta> listaRequisicionConsulta = new List<beRequisicionConsulta>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();

                    daRequisicionConsulta a = new daRequisicionConsulta();
                    listaRequisicionConsulta = a.listarRequisicionSegundaVueltaConsulta(con, oGenerico);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listaRequisicionConsulta;
            }
        }
        public List<beRequisicionConsulta> listarRequisicionHistorial(beGenerica oGenerico)
        {
            List<beRequisicionConsulta> listaRequisicionConsulta = new List<beRequisicionConsulta>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();

                    daRequisicionConsulta a = new daRequisicionConsulta();
                    listaRequisicionConsulta = a.listarRequisicionHistorial(con, oGenerico);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listaRequisicionConsulta;
            }
        }
    }
}

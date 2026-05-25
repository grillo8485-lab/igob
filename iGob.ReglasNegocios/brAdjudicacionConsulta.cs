using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iGob.Entidades;
using iGob.AccesoDatos;
using System.Data.SqlClient;

namespace iGob.ReglasNegocios
{
    public class brAdjudicacionConsulta : brConexion
    {
        public List<beAdjudicacionConsulta> listarAdjudicacionConsulta(beGenerica oGenerico)
        {
            List<beAdjudicacionConsulta> listaAdjudicacionConsulta = new List<beAdjudicacionConsulta>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();

                    daAdjudicacionConsulta a = new daAdjudicacionConsulta();
                    listaAdjudicacionConsulta = a.listarAdjudicacionConsulta(con, oGenerico);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listaAdjudicacionConsulta;
            }
        }

        public List<beAdjudicacionConsulta> listarAdjudicacionesConsultaProveedores(int IdProveedor, int IdTipoAdjudicacion)
        {
            List<beAdjudicacionConsulta> listaAdjudicacionConsultaProveedores = new List<beAdjudicacionConsulta>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();

                    daAdjudicacionConsulta a = new daAdjudicacionConsulta();
                    listaAdjudicacionConsultaProveedores = a.listarAdjudicacionConsultaProveedores(con, IdProveedor, IdTipoAdjudicacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listaAdjudicacionConsultaProveedores;
            }
        }

        public List<beAdjudicacionConsulta> ListarAdjudicacionPerfilAdjudicacionEstatusAutorizadas(int pIdLista, int pIdPerfil, int pIdDependencia)
        {
            List<beAdjudicacionConsulta> listaAdjudicacionConsulta = new List<beAdjudicacionConsulta>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();

                    daAdjudicacionConsulta a = new daAdjudicacionConsulta();
                    listaAdjudicacionConsulta = a.ListarAdjudicacionPerfilAdjudicacionEstatusAutorizadas(con, pIdLista,pIdPerfil,pIdDependencia);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listaAdjudicacionConsulta;
            }
        }
    }
}

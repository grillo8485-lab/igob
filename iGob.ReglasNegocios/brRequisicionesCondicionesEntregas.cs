using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brRequisicionesCondicionesEntregas : brConexion
    {
        public int guardarRequisicionesCondicionesEntregas(beRequisicionesCondicionesEntregas obeRequisicionesCondicionesEntregas)
        {
            int IdRequisicionCondicionEntrega;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesCondicionesEntregas odaRequisicionesCondicionesEntregas = new daRequisicionesCondicionesEntregas();
                    IdRequisicionCondicionEntrega = odaRequisicionesCondicionesEntregas.guardarRequisicionesCondicionesEntregas(con, obeRequisicionesCondicionesEntregas);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdRequisicionCondicionEntrega;
            }
        }

        public int actualizarRequisicionesCondicionesEntregas(beRequisicionesCondicionesEntregas obeRequisicionesCondicionesEntregas)
        {
            int IdRequisicionCondicionEntrega;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesCondicionesEntregas odaRequisicionesCondicionesEntregas = new daRequisicionesCondicionesEntregas();
                    IdRequisicionCondicionEntrega = odaRequisicionesCondicionesEntregas.actualizarRequisicionesCondicionesEntregas(con, obeRequisicionesCondicionesEntregas);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdRequisicionCondicionEntrega;
            }
        }

        public int eliminarRequisicionesCondicionesEntregas(int IdRequisicionCondicionEntrega)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesCondicionesEntregas odaRequisicionesCondicionesEntregas = new daRequisicionesCondicionesEntregas();
                    IdRequisicionCondicionEntrega = odaRequisicionesCondicionesEntregas.eliminarRequisicionesCondicionesEntregas(con, IdRequisicionCondicionEntrega);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdRequisicionCondicionEntrega;
            }
        }

        public beRequisicionesCondicionesEntregas traerRequisicionesCondicionesEntregas_x_IdRequisicionCondicionEntrega(int IdRequisicionCondicionEntrega)
        {
            beRequisicionesCondicionesEntregas obeRequisicionesCondicionesEntregas = new beRequisicionesCondicionesEntregas();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesCondicionesEntregas odaRequisicionesCondicionesEntregas = new daRequisicionesCondicionesEntregas();
                    obeRequisicionesCondicionesEntregas = odaRequisicionesCondicionesEntregas.traerRequisicionesCondicionesEntregas_x_IdRequisicionCondicionEntrega(con, IdRequisicionCondicionEntrega);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRequisicionesCondicionesEntregas;
            }
        }

        public List<beRequisicionesCondicionesEntregas> listarTodos_RequisicionesCondicionesEntregas()
        {
            List<beRequisicionesCondicionesEntregas> lbeRequisicionesCondicionesEntregas = new List<beRequisicionesCondicionesEntregas>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesCondicionesEntregas odaRequisicionesCondicionesEntregas = new daRequisicionesCondicionesEntregas();
                    lbeRequisicionesCondicionesEntregas = odaRequisicionesCondicionesEntregas.listarTodos_RequisicionesCondicionesEntregas(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesCondicionesEntregas;
            }
        }
        public List<beRequisicionesCondicionesEntregas> listarTodos_RequisicionesCondicionesEntregas_GetAll()
        {
            List<beRequisicionesCondicionesEntregas> lbeRequisicionesCondicionesEntregas = new List<beRequisicionesCondicionesEntregas>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesCondicionesEntregas odaRequisicionesCondicionesEntregas = new daRequisicionesCondicionesEntregas();
                    lbeRequisicionesCondicionesEntregas = odaRequisicionesCondicionesEntregas.listar_RequisicionesCondicionesEntregas_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesCondicionesEntregas;
            }
        }
        public beRequisicionesCondicionesEntregas traerRequisicionesCondicionesEntregas_x_IdRequisicion(int IdRequisicion)
        {
            beRequisicionesCondicionesEntregas obeRequisicionesCondicionesEntregas = new beRequisicionesCondicionesEntregas();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesCondicionesEntregas odaRequisicionesCondicionesEntregas = new daRequisicionesCondicionesEntregas();
                    obeRequisicionesCondicionesEntregas = odaRequisicionesCondicionesEntregas.traerRequisicionesCondicionesEntregas_x_IdRequisicion(con, IdRequisicion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRequisicionesCondicionesEntregas;
            }
        }
    }
}

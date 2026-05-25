using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brRequisicionesFirmantes : brConexion
    {
        public int guardarRequisicionesFirmantes(beRequisicionesFirmantes obeRequisicionesFirmantes)
        {
            int IdRqFirmante;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesFirmantes odaRequisicionesFirmantes = new daRequisicionesFirmantes();
                    IdRqFirmante = odaRequisicionesFirmantes.guardarRequisicionesFirmantes(con, obeRequisicionesFirmantes);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdRqFirmante;
            }
        }

        public int actualizarRequisicionesFirmantes(beRequisicionesFirmantes obeRequisicionesFirmantes)
        {
            int IdRqFirmante;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesFirmantes odaRequisicionesFirmantes = new daRequisicionesFirmantes();
                    IdRqFirmante = odaRequisicionesFirmantes.actualizarRequisicionesFirmantes(con, obeRequisicionesFirmantes);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdRqFirmante;
            }
        }

        public int eliminarRequisicionesFirmantes(int IdRqFirmante)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesFirmantes odaRequisicionesFirmantes = new daRequisicionesFirmantes();
                    IdRqFirmante = odaRequisicionesFirmantes.eliminarRequisicionesFirmantes(con, IdRqFirmante);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdRqFirmante;
            }
        }

        public beRequisicionesFirmantes traerRequisicionesFirmantes_x_IdRqFirmante(int IdRqFirmante)
        {
            beRequisicionesFirmantes obeRequisicionesFirmantes = new beRequisicionesFirmantes();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesFirmantes odaRequisicionesFirmantes = new daRequisicionesFirmantes();
                    obeRequisicionesFirmantes = odaRequisicionesFirmantes.traerRequisicionesFirmantes_x_IdRqFirmante(con, IdRqFirmante);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRequisicionesFirmantes;
            }
        }

        public List<beRequisicionesFirmantes> listarTodos_RequisicionesFirmantes()
        {
            List<beRequisicionesFirmantes> lbeRequisicionesFirmantes = new List<beRequisicionesFirmantes>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesFirmantes odaRequisicionesFirmantes = new daRequisicionesFirmantes();
                    lbeRequisicionesFirmantes = odaRequisicionesFirmantes.listarTodos_RequisicionesFirmantes(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesFirmantes;
            }
        }
        public List<beRequisicionesFirmantes> listarTodos_RequisicionesFirmantes_GetAll()
        {
            List<beRequisicionesFirmantes> lbeRequisicionesFirmantes = new List<beRequisicionesFirmantes>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesFirmantes odaRequisicionesFirmantes = new daRequisicionesFirmantes();
                    lbeRequisicionesFirmantes = odaRequisicionesFirmantes.listar_RequisicionesFirmantes_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRequisicionesFirmantes;
            }
        }

        public int actualizarRequisicionesFirmantes_Revisor(beRequisicionesFirmantes obeRequisicionesFirmantes)
        {
            int IdRqFirmante;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daRequisicionesFirmantes odaRequisicionesFirmantes = new daRequisicionesFirmantes();
                    IdRqFirmante = odaRequisicionesFirmantes.actualizarRequisicionesFirmantes_Revisor(con, obeRequisicionesFirmantes);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return IdRqFirmante;
            }
        }

    
    
    
    
    }
}

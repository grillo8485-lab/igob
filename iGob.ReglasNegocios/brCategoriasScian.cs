using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
{
    public class brCategoriasScian : brConexion
    {
        public int guardarCategoriasScian(beCategoriasScian obeCategoriasScian)
        {
            int CodigoScian;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCategoriasScian odaCategoriasScian = new daCategoriasScian();
                    CodigoScian = odaCategoriasScian.guardarCategoriasScian(con, obeCategoriasScian);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return CodigoScian;
            }
        }

        public int actualizarCategoriasScian(beCategoriasScian obeCategoriasScian)
        {
            int CodigoScian;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCategoriasScian odaCategoriasScian = new daCategoriasScian();
                    CodigoScian = odaCategoriasScian.actualizarCategoriasScian(con, obeCategoriasScian);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return CodigoScian;
            }
        }

        public int eliminarCategoriasScian(int CodigoScian)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCategoriasScian odaCategoriasScian = new daCategoriasScian();
                    CodigoScian = odaCategoriasScian.eliminarCategoriasScian(con, CodigoScian);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return CodigoScian;
            }
        }

        public beCategoriasScian traerCategoriasScian_x_CodigoScian(int CodigoScian)
        {
            beCategoriasScian obeCategoriasScian = new beCategoriasScian();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCategoriasScian odaCategoriasScian = new daCategoriasScian();
                    obeCategoriasScian = odaCategoriasScian.traerCategoriasScian_x_CodigoScian(con, CodigoScian);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeCategoriasScian;
            }
        }

        public List<beCategoriasScian> listarTodos_CategoriasScian()
        {
            List<beCategoriasScian> lbeCategoriasScian = new List<beCategoriasScian>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCategoriasScian odaCategoriasScian = new daCategoriasScian();
                    lbeCategoriasScian = odaCategoriasScian.listarTodos_CategoriasScian(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCategoriasScian;
            }
        }
        public List<beCategoriasScian> listarTodos_CategoriasScian_GetAll()
        {
            List<beCategoriasScian> lbeCategoriasScian = new List<beCategoriasScian>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCategoriasScian odaCategoriasScian = new daCategoriasScian();
                    lbeCategoriasScian = odaCategoriasScian.listar_CategoriasScian_GetAll(con);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCategoriasScian;
            }
        }
        public List<beCategoriasScian> listarTodos_CategoriasScian_x_Descripcion(string pDescripcion)
        {
            List<beCategoriasScian> lbeCategoriasScian = new List<beCategoriasScian>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daCategoriasScian odaCategoriasScian = new daCategoriasScian();
                    lbeCategoriasScian = odaCategoriasScian.listarTodos_CategoriasScian_x_Descripcion(con, pDescripcion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCategoriasScian;
            }
        }
    }
}

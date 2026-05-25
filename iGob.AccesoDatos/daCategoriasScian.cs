using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daCategoriasScian
    {
        public int guardarCategoriasScian(SqlConnection Conexion, beCategoriasScian obeCategoriasScian)
        {
            int Id = 0;
            string sp = "Proc_CategoriasScianInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodigoScian", SqlDbType.Int).Value = obeCategoriasScian.CodigoScian;
                    cmd.Parameters.Add("@Titulo", SqlDbType.NVarChar).Value = obeCategoriasScian.Titulo;
                    cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = obeCategoriasScian.Descripcion;
                    cmd.Parameters.Add("@Incluye", SqlDbType.NVarChar).Value = obeCategoriasScian.Incluye;
                    cmd.Parameters.Add("@Excluye", SqlDbType.NVarChar).Value = obeCategoriasScian.Excluye;

                    Id = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarCategoriasScian(SqlConnection Conexion, beCategoriasScian obeCategoriasScian)
        {
            string sp = "Proc_CategoriasScianActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodigoScian", SqlDbType.Int).Value = obeCategoriasScian.CodigoScian;
                    cmd.Parameters.Add("@Titulo", SqlDbType.NVarChar).Value = obeCategoriasScian.Titulo;
                    cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = obeCategoriasScian.Descripcion;
                    cmd.Parameters.Add("@Incluye", SqlDbType.NVarChar).Value = obeCategoriasScian.Incluye;
                    cmd.Parameters.Add("@Excluye", SqlDbType.NVarChar).Value = obeCategoriasScian.Excluye;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarCategoriasScian(SqlConnection Conexion, int pCodigoScian)
        {
            string sp = "Proc_CategoriasScianEliminar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodigoScian", SqlDbType.Int).Value = pCodigoScian;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
        public beCategoriasScian traerCategoriasScian_x_CodigoScian(SqlConnection Conexion, int CodigoScian)
        {
            string sp = "Proc_CategoriasScian_x_CodigoScian";
            beCategoriasScian obeCategoriasScian = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CodigoScian", SqlDbType.Int).Value = CodigoScian;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posCodigoScian = datard.GetOrdinal("CodigoScian");
                        int posTitulo = datard.GetOrdinal("Titulo");
                        int posDescripcion = datard.GetOrdinal("Descripcion");
                        int posIncluye = datard.GetOrdinal("Incluye");
                        int posExcluye = datard.GetOrdinal("Excluye");
                        obeCategoriasScian = new beCategoriasScian();
                        while (datard.Read())
                        {
                            obeCategoriasScian.CodigoScian = datard.GetInt32(posCodigoScian);
                            obeCategoriasScian.Titulo = datard.GetString(posTitulo);
                            obeCategoriasScian.Descripcion = datard.GetString(posDescripcion);
                            obeCategoriasScian.Incluye = datard.GetString(posIncluye);
                            obeCategoriasScian.Excluye = datard.GetString(posExcluye);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeCategoriasScian;
            }
        }
        public List<beCategoriasScian> listarTodos_CategoriasScian(SqlConnection Conexion)
        {
            string sp = "Proc_CategoriasScian_Traer_Todos";
            List<beCategoriasScian> lbeCategoriasScian = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posCodigoScian = datard.GetOrdinal("CodigoScian");
                        int posTitulo = datard.GetOrdinal("Titulo");
                        int posDescripcion = datard.GetOrdinal("Descripcion");
                        int posIncluye = datard.GetOrdinal("Incluye");
                        int posExcluye = datard.GetOrdinal("Excluye");
                        lbeCategoriasScian = new List<beCategoriasScian>();
                        beCategoriasScian obeCategoriasScian;
                        while (datard.Read())
                        {
                            obeCategoriasScian = new beCategoriasScian();
                            obeCategoriasScian.CodigoScian = datard.GetInt32(posCodigoScian);
                            obeCategoriasScian.Titulo = datard.GetString(posTitulo);
                            obeCategoriasScian.Descripcion = datard.GetString(posDescripcion);
                            obeCategoriasScian.Incluye = datard.GetString(posIncluye);
                            obeCategoriasScian.Excluye = datard.GetString(posExcluye);
                            lbeCategoriasScian.Add(obeCategoriasScian);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCategoriasScian;
            }
        }
        public List<beCategoriasScian> listar_CategoriasScian_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_CategoriasScian_TraerTodos_GetAll";
            List<beCategoriasScian> lbeCategoriasScian = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posCodigoScian = datard.GetOrdinal("CodigoScian");
                        int posTitulo = datard.GetOrdinal("Titulo");
                        int posDescripcion = datard.GetOrdinal("Descripcion");
                        int posIncluye = datard.GetOrdinal("Incluye");
                        int posExcluye = datard.GetOrdinal("Excluye");
                        lbeCategoriasScian = new List<beCategoriasScian>();
                        beCategoriasScian obeCategoriasScian;
                        while (datard.Read())
                        {
                            obeCategoriasScian = new beCategoriasScian();
                            obeCategoriasScian.CodigoScian = datard.GetInt32(posCodigoScian);
                            obeCategoriasScian.Titulo = datard.GetString(posTitulo);
                            obeCategoriasScian.Descripcion = datard.GetString(posDescripcion);
                            obeCategoriasScian.Incluye = datard.GetString(posIncluye);
                            obeCategoriasScian.Excluye = datard.GetString(posExcluye);
                            // debe agregar campos de la Vista
                            lbeCategoriasScian.Add(obeCategoriasScian);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeCategoriasScian;
            }
        }
        public List<beCategoriasScian> listarTodos_CategoriasScian_x_Descripcion(SqlConnection Conexion,string pDescripcion)
        {
            string sp = "Proc_CategoriasScian_X_Descripcion";
            List<beCategoriasScian> lbeCategoriasScian = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = pDescripcion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posCodigoScian = datard.GetOrdinal("CodigoScian");
                        int posTitulo = datard.GetOrdinal("Titulo");
                        int posDescripcion = datard.GetOrdinal("Descripcion");
                        int posIncluye = datard.GetOrdinal("Incluye");
                        int posExcluye = datard.GetOrdinal("Excluye");
                        lbeCategoriasScian = new List<beCategoriasScian>();
                        beCategoriasScian obeCategoriasScian;
                        while (datard.Read())
                        {
                            obeCategoriasScian = new beCategoriasScian();
                            obeCategoriasScian.CodigoScian = datard.GetInt32(posCodigoScian);
                            obeCategoriasScian.Titulo = datard.GetString(posTitulo);
                            obeCategoriasScian.Descripcion = datard.GetString(posDescripcion);
                            obeCategoriasScian.Incluye = datard.GetString(posIncluye);
                            obeCategoriasScian.Excluye = datard.GetString(posExcluye);
                            // debe agregar campos de la Vista
                            lbeCategoriasScian.Add(obeCategoriasScian);
                        }
                    }
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

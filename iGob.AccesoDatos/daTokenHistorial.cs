using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daTokenHistorial
    {
        public int guardarTokenHistorial(SqlConnection Conexion, beTokenHistorial obeTokenHistorial)
        {
            int Id = 0;
            string sp = "Proc_TokenHistorialInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdTokenHistorial", SqlDbType.Int).Value = obeTokenHistorial.IdTokenHistorial;
                    cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = obeTokenHistorial.IdUsuario;
                    cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = obeTokenHistorial.IdPerfil;
                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = obeTokenHistorial.Usuario;
                    cmd.Parameters.Add("@NoToken", SqlDbType.Char).Value = obeTokenHistorial.NoToken;
                    cmd.Parameters.Add("@llaveAcceso", SqlDbType.VarChar).Value = obeTokenHistorial.LlaveAcceso;
                    cmd.Parameters.Add("@Token", SqlDbType.VarChar).Value = obeTokenHistorial.Token;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeTokenHistorial.FechaRegistro;

                    Id = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarTokenHistorial(SqlConnection Conexion, beTokenHistorial obeTokenHistorial)
        {
            string sp = "Proc_TokenHistorialActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdTokenHistorial", SqlDbType.Int).Value = obeTokenHistorial.IdTokenHistorial;
                    cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = obeTokenHistorial.IdUsuario;
                    cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = obeTokenHistorial.IdPerfil;
                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = obeTokenHistorial.Usuario;
                    cmd.Parameters.Add("@NoToken", SqlDbType.Char).Value = obeTokenHistorial.NoToken;
                    cmd.Parameters.Add("@llaveAcceso", SqlDbType.VarChar).Value = obeTokenHistorial.LlaveAcceso;
                    cmd.Parameters.Add("@Token", SqlDbType.VarChar).Value = obeTokenHistorial.Token;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeTokenHistorial.FechaRegistro;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarTokenHistorial(SqlConnection Conexion, int pIdTokenHistorial)
        {
            string sp = "Proc_TokenHistorialEliminar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdTokenHistorial", SqlDbType.Int).Value = pIdTokenHistorial;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
        public beTokenHistorial traerTokenHistorial_x_IdTokenHistorial(SqlConnection Conexion, int IdTokenHistorial)
        {
            string sp = "Proc_TokenHistorial_x_IdTokenHistorial";
            beTokenHistorial obeTokenHistorial = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdTokenHistorial", SqlDbType.Int).Value = IdTokenHistorial;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdTokenHistorial = datard.GetOrdinal("IdTokenHistorial");
                        int posIdUsuario = datard.GetOrdinal("IdUsuario");
                        int posIdPerfil = datard.GetOrdinal("IdPerfil");
                        int posUsuario = datard.GetOrdinal("Usuario");
                        int posNoToken = datard.GetOrdinal("NoToken");
                        int posllaveAcceso = datard.GetOrdinal("llaveAcceso");
                        int posToken = datard.GetOrdinal("Token");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        obeTokenHistorial = new beTokenHistorial();
                        while (datard.Read())
                        {
                            obeTokenHistorial.IdTokenHistorial = datard.GetInt32(posIdTokenHistorial);
                            obeTokenHistorial.IdUsuario = datard.GetInt32(posIdUsuario);
                            obeTokenHistorial.IdPerfil = datard.GetInt32(posIdPerfil);
                            obeTokenHistorial.Usuario = datard.GetString(posUsuario);
                            obeTokenHistorial.NoToken = datard.GetString(posNoToken);
                            obeTokenHistorial.LlaveAcceso = datard.GetString(posllaveAcceso);
                            obeTokenHistorial.Token = datard.GetString(posToken);
                            obeTokenHistorial.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeTokenHistorial;
            }
        }
        public List<beTokenHistorial> listarTodos_TokenHistorial(SqlConnection Conexion)
        {
            string sp = "Proc_TokenHistorial_Traer_Todos";
            List<beTokenHistorial> lbeTokenHistorial = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdTokenHistorial = datard.GetOrdinal("IdTokenHistorial");
                        int posIdUsuario = datard.GetOrdinal("IdUsuario");
                        int posIdPerfil = datard.GetOrdinal("IdPerfil");
                        int posUsuario = datard.GetOrdinal("Usuario");
                        int posNoToken = datard.GetOrdinal("NoToken");
                        int posllaveAcceso = datard.GetOrdinal("llaveAcceso");
                        int posToken = datard.GetOrdinal("Token");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        lbeTokenHistorial = new List<beTokenHistorial>();
                        beTokenHistorial obeTokenHistorial;
                        while (datard.Read())
                        {
                            obeTokenHistorial = new beTokenHistorial();
                            obeTokenHistorial.IdTokenHistorial = datard.GetInt32(posIdTokenHistorial);
                            obeTokenHistorial.IdUsuario = datard.GetInt32(posIdUsuario);
                            obeTokenHistorial.IdPerfil = datard.GetInt32(posIdPerfil);
                            obeTokenHistorial.Usuario = datard.GetString(posUsuario);
                            obeTokenHistorial.NoToken = datard.GetString(posNoToken);
                            obeTokenHistorial.LlaveAcceso = datard.GetString(posllaveAcceso);
                            obeTokenHistorial.Token = datard.GetString(posToken);
                            obeTokenHistorial.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            lbeTokenHistorial.Add(obeTokenHistorial);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeTokenHistorial;
            }
        }
        public List<beTokenHistorial> listar_TokenHistorial_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_TokenHistorial_TraerTodos_GetAll";
            List<beTokenHistorial> lbeTokenHistorial = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdTokenHistorial = datard.GetOrdinal("IdTokenHistorial");
                        int posIdUsuario = datard.GetOrdinal("IdUsuario");
                        int posIdPerfil = datard.GetOrdinal("IdPerfil");
                        int posUsuario = datard.GetOrdinal("Usuario");
                        int posNoToken = datard.GetOrdinal("NoToken");
                        int posllaveAcceso = datard.GetOrdinal("llaveAcceso");
                        int posToken = datard.GetOrdinal("Token");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        lbeTokenHistorial = new List<beTokenHistorial>();
                        beTokenHistorial obeTokenHistorial;
                        while (datard.Read())
                        {
                            obeTokenHistorial = new beTokenHistorial();
                            obeTokenHistorial.IdTokenHistorial = datard.GetInt32(posIdTokenHistorial);
                            obeTokenHistorial.IdUsuario = datard.GetInt32(posIdUsuario);
                            obeTokenHistorial.IdPerfil = datard.GetInt32(posIdPerfil);
                            obeTokenHistorial.Usuario = datard.GetString(posUsuario);
                            obeTokenHistorial.NoToken = datard.GetString(posNoToken);
                            obeTokenHistorial.LlaveAcceso = datard.GetString(posllaveAcceso);
                            obeTokenHistorial.Token = datard.GetString(posToken);
                            obeTokenHistorial.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            // debe agregar campos de la Vista
                            lbeTokenHistorial.Add(obeTokenHistorial);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeTokenHistorial;
            }
        }

        public beTokenHistorial traerTokenHistorial_x_Token(SqlConnection Conexion, string pToken)
        {
            string sp = "Proc_TokenHistorial_x_Token";
            beTokenHistorial obeTokenHistorial = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Token", SqlDbType.NVarChar).Value = pToken;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdTokenHistorial = datard.GetOrdinal("IdTokenHistorial");
                        int posIdUsuario = datard.GetOrdinal("IdUsuario");
                        int posIdPerfil = datard.GetOrdinal("IdPerfil");
                        int posUsuario = datard.GetOrdinal("Usuario");
                        int posNoToken = datard.GetOrdinal("NoToken");
                        int posllaveAcceso = datard.GetOrdinal("llaveAcceso");
                        int posToken = datard.GetOrdinal("Token");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        obeTokenHistorial = new beTokenHistorial();
                        while (datard.Read())
                        {
                            obeTokenHistorial.IdTokenHistorial = datard.GetInt32(posIdTokenHistorial);
                            obeTokenHistorial.IdUsuario = datard.GetInt32(posIdUsuario);
                            obeTokenHistorial.IdPerfil = datard.GetInt32(posIdPerfil);
                            obeTokenHistorial.Usuario = datard.GetString(posUsuario);
                            obeTokenHistorial.NoToken = datard.GetString(posNoToken);
                            obeTokenHistorial.LlaveAcceso = datard.GetString(posllaveAcceso);
                            obeTokenHistorial.Token = datard.GetString(posToken);
                            obeTokenHistorial.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeTokenHistorial;
            }
        }
    }
}

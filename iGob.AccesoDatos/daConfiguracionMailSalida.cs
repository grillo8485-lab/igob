using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daConfiguracionMailSalida
    {
        public int guardarConfiguracionMailSalida(SqlConnection Conexion, beConfiguracionMailSalida obeConfiguracionMailSalida)
        {
            int Id = 0;
            string sp = "Proc_ConfiguracionMailSalidaInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdConfigMailSalida", SqlDbType.Int).Value = obeConfiguracionMailSalida.IdConfigMailSalida;
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = obeConfiguracionMailSalida.Nombre;
                    cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = obeConfiguracionMailSalida.Correo;
                    cmd.Parameters.Add("@Contrasena", SqlDbType.VarChar).Value = obeConfiguracionMailSalida.Contrasena;
                    cmd.Parameters.Add("@Smtp", SqlDbType.VarChar).Value = obeConfiguracionMailSalida.Smtp;
                    cmd.Parameters.Add("@Servidor", SqlDbType.NVarChar).Value = obeConfiguracionMailSalida.Servidor;
                    cmd.Parameters.Add("@Puerto", SqlDbType.Int).Value = obeConfiguracionMailSalida.Puerto;
                    cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeConfiguracionMailSalida.Activo;

                    Id = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarConfiguracionMailSalida(SqlConnection Conexion, beConfiguracionMailSalida obeConfiguracionMailSalida)
        {
            string sp = "Proc_ConfiguracionMailSalidaActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdConfigMailSalida", SqlDbType.Int).Value = obeConfiguracionMailSalida.IdConfigMailSalida;
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = obeConfiguracionMailSalida.Nombre;
                    cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = obeConfiguracionMailSalida.Correo;
                    cmd.Parameters.Add("@Contrasena", SqlDbType.VarChar).Value = obeConfiguracionMailSalida.Contrasena;
                    cmd.Parameters.Add("@Smtp", SqlDbType.VarChar).Value = obeConfiguracionMailSalida.Smtp;
                    cmd.Parameters.Add("@Servidor", SqlDbType.NVarChar).Value = obeConfiguracionMailSalida.Servidor;
                    cmd.Parameters.Add("@Puerto", SqlDbType.Int).Value = obeConfiguracionMailSalida.Puerto;
                    cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeConfiguracionMailSalida.Activo;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarConfiguracionMailSalida(SqlConnection Conexion, int pIdConfigMailSalida)
        {
            string sp = "Proc_ConfiguracionMailSalidaEliminar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdConfigMailSalida", SqlDbType.Int).Value = pIdConfigMailSalida;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
        public beConfiguracionMailSalida traerConfiguracionMailSalida_x_IdConfigMailSalida(SqlConnection Conexion, int IdConfigMailSalida)
        {
            string sp = "Proc_ConfiguracionMailSalida_x_IdConfigMailSalida";
            beConfiguracionMailSalida obeConfiguracionMailSalida = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdConfigMailSalida", SqlDbType.Int).Value = IdConfigMailSalida;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdConfigMailSalida = datard.GetOrdinal("IdConfigMailSalida");
                        int posNombre = datard.GetOrdinal("Nombre");
                        int posCorreo = datard.GetOrdinal("Correo");
                        int posContrasena = datard.GetOrdinal("Contrasena");
                        int posSmtp = datard.GetOrdinal("Smtp");
                        int posServidor = datard.GetOrdinal("Servidor");
                        int posPuerto = datard.GetOrdinal("Puerto");
                        int posActivo = datard.GetOrdinal("Activo");
                        obeConfiguracionMailSalida = new beConfiguracionMailSalida();
                        while (datard.Read())
                        {
                            obeConfiguracionMailSalida.IdConfigMailSalida = datard.GetInt32(posIdConfigMailSalida);
                            obeConfiguracionMailSalida.Nombre = datard.GetString(posNombre);
                            obeConfiguracionMailSalida.Correo = datard.GetString(posCorreo);
                            obeConfiguracionMailSalida.Contrasena = datard.GetString(posContrasena);
                            obeConfiguracionMailSalida.Smtp = datard.GetString(posSmtp);
                            obeConfiguracionMailSalida.Servidor = datard.GetString(posServidor);
                            obeConfiguracionMailSalida.Puerto = datard.GetInt32(posPuerto);
                            obeConfiguracionMailSalida.Activo = datard.GetBoolean(posActivo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeConfiguracionMailSalida;
            }
        }
        public List<beConfiguracionMailSalida> listarTodos_ConfiguracionMailSalida(SqlConnection Conexion)
        {
            string sp = "Proc_ConfiguracionMailSalida_Traer_Todos";
            List<beConfiguracionMailSalida> lbeConfiguracionMailSalida = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdConfigMailSalida = datard.GetOrdinal("IdConfigMailSalida");
                        int posNombre = datard.GetOrdinal("Nombre");
                        int posCorreo = datard.GetOrdinal("Correo");
                        int posContrasena = datard.GetOrdinal("Contrasena");
                        int posSmtp = datard.GetOrdinal("Smtp");
                        int posServidor = datard.GetOrdinal("Servidor");
                        int posPuerto = datard.GetOrdinal("Puerto");
                        int posActivo = datard.GetOrdinal("Activo");
                        lbeConfiguracionMailSalida = new List<beConfiguracionMailSalida>();
                        beConfiguracionMailSalida obeConfiguracionMailSalida;
                        while (datard.Read())
                        {
                            obeConfiguracionMailSalida = new beConfiguracionMailSalida();
                            obeConfiguracionMailSalida.IdConfigMailSalida = datard.GetInt32(posIdConfigMailSalida);
                            obeConfiguracionMailSalida.Nombre = datard.GetString(posNombre);
                            obeConfiguracionMailSalida.Correo = datard.GetString(posCorreo);
                            obeConfiguracionMailSalida.Contrasena = datard.GetString(posContrasena);
                            obeConfiguracionMailSalida.Smtp = datard.GetString(posSmtp);
                            obeConfiguracionMailSalida.Servidor = datard.GetString(posServidor);
                            obeConfiguracionMailSalida.Puerto = datard.GetInt32(posPuerto);
                            obeConfiguracionMailSalida.Activo = datard.GetBoolean(posActivo);
                            lbeConfiguracionMailSalida.Add(obeConfiguracionMailSalida);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeConfiguracionMailSalida;
            }
        }
        public List<beConfiguracionMailSalida> listar_ConfiguracionMailSalida_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_ConfiguracionMailSalida_TraerTodos_GetAll";
            List<beConfiguracionMailSalida> lbeConfiguracionMailSalida = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdConfigMailSalida = datard.GetOrdinal("IdConfigMailSalida");
                        int posNombre = datard.GetOrdinal("Nombre");
                        int posCorreo = datard.GetOrdinal("Correo");
                        int posContrasena = datard.GetOrdinal("Contrasena");
                        int posSmtp = datard.GetOrdinal("Smtp");
                        int posServidor = datard.GetOrdinal("Servidor");
                        int posPuerto = datard.GetOrdinal("Puerto");
                        int posActivo = datard.GetOrdinal("Activo");
                        lbeConfiguracionMailSalida = new List<beConfiguracionMailSalida>();
                        beConfiguracionMailSalida obeConfiguracionMailSalida;
                        while (datard.Read())
                        {
                            obeConfiguracionMailSalida = new beConfiguracionMailSalida();
                            obeConfiguracionMailSalida.IdConfigMailSalida = datard.GetInt32(posIdConfigMailSalida);
                            obeConfiguracionMailSalida.Nombre = datard.GetString(posNombre);
                            obeConfiguracionMailSalida.Correo = datard.GetString(posCorreo);
                            obeConfiguracionMailSalida.Contrasena = datard.GetString(posContrasena);
                            obeConfiguracionMailSalida.Smtp = datard.GetString(posSmtp);
                            obeConfiguracionMailSalida.Servidor = datard.GetString(posServidor);
                            obeConfiguracionMailSalida.Puerto = datard.GetInt32(posPuerto);
                            obeConfiguracionMailSalida.Activo = datard.GetBoolean(posActivo);
                            // debe agregar campos de la Vista
                            lbeConfiguracionMailSalida.Add(obeConfiguracionMailSalida);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeConfiguracionMailSalida;
            }
        }
    }
}

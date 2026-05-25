using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daAcceso
    {
        public int guardarAcceso(SqlConnection Conexion, beAcceso obeAcceso)
        {
            int Id = 0;
            string sp = "Proc_AccesoInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdAcceso", SqlDbType.Int).Value = obeAcceso.IdAcceso;
                    cmd.Parameters.Add("@FechaAcceso", SqlDbType.NVarChar).Value = obeAcceso.FechaAcceso;
                    cmd.Parameters.Add("@FechaAccesoTotal", SqlDbType.NVarChar).Value = obeAcceso.FechaAccesoTotal;
                    cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeAcceso.Activo;

                    Id = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarAcceso(SqlConnection Conexion, beAcceso obeAcceso)
        {
            string sp = "Proc_AccesoActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdAcceso", SqlDbType.Int).Value = obeAcceso.IdAcceso;
                    cmd.Parameters.Add("@FechaAcceso", SqlDbType.NVarChar).Value = obeAcceso.FechaAcceso;
                    cmd.Parameters.Add("@FechaAccesoTotal", SqlDbType.NVarChar).Value = obeAcceso.FechaAccesoTotal;
                    cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeAcceso.Activo;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarAcceso(SqlConnection Conexion, int pIdAcceso)
        {
            string sp = "Proc_AccesoEliminar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdAcceso", SqlDbType.Int).Value = pIdAcceso;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
        public beAcceso traerAcceso_x_IdAcceso(SqlConnection Conexion, int IdAcceso)
        {
            string sp = "Proc_Acceso_x_IdAcceso";
            beAcceso obeAcceso = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdAcceso", SqlDbType.Int).Value = IdAcceso;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdAcceso = datard.GetOrdinal("IdAcceso");
                        int posFechaAcceso = datard.GetOrdinal("FechaAcceso");
                        int posFechaAccesoTotal = datard.GetOrdinal("FechaAccesoTotal");
                        int posActivo = datard.GetOrdinal("Activo");
                        obeAcceso = new beAcceso();
                        while (datard.Read())
                        {
                            obeAcceso.IdAcceso = datard.GetInt32(posIdAcceso);
                            obeAcceso.FechaAcceso = datard.GetString(posFechaAcceso);
                            obeAcceso.FechaAccesoTotal = datard.GetString(posFechaAccesoTotal);
                            obeAcceso.Activo = datard.GetBoolean(posActivo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeAcceso;
            }
        }
        public List<beAcceso> listarTodos_Acceso(SqlConnection Conexion)
        {
            string sp = "Proc_Acceso_Traer_Todos";
            List<beAcceso> lbeAcceso = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdAcceso = datard.GetOrdinal("IdAcceso");
                        int posFechaAcceso = datard.GetOrdinal("FechaAcceso");
                        int posFechaAccesoTotal = datard.GetOrdinal("FechaAccesoTotal");
                        int posActivo = datard.GetOrdinal("Activo");
                        lbeAcceso = new List<beAcceso>();
                        beAcceso obeAcceso;
                        while (datard.Read())
                        {
                            obeAcceso = new beAcceso();
                            obeAcceso.IdAcceso = datard.GetInt32(posIdAcceso);
                            obeAcceso.FechaAcceso = datard.GetString(posFechaAcceso);
                            obeAcceso.FechaAccesoTotal = datard.GetString(posFechaAccesoTotal);
                            obeAcceso.Activo = datard.GetBoolean(posActivo);
                            lbeAcceso.Add(obeAcceso);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAcceso;
            }
        }
        public List<beAcceso> listar_Acceso_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_Acceso_TraerTodos_GetAll";
            List<beAcceso> lbeAcceso = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdAcceso = datard.GetOrdinal("IdAcceso");
                        int posFechaAcceso = datard.GetOrdinal("FechaAcceso");
                        int posFechaAccesoTotal = datard.GetOrdinal("FechaAccesoTotal");
                        int posActivo = datard.GetOrdinal("Activo");
                        lbeAcceso = new List<beAcceso>();
                        beAcceso obeAcceso;
                        while (datard.Read())
                        {
                            obeAcceso = new beAcceso();
                            obeAcceso.IdAcceso = datard.GetInt32(posIdAcceso);
                            obeAcceso.FechaAcceso = datard.GetString(posFechaAcceso);
                            obeAcceso.FechaAccesoTotal = datard.GetString(posFechaAccesoTotal);
                            obeAcceso.Activo = datard.GetBoolean(posActivo);
                            // debe agregar campos de la Vista
                            lbeAcceso.Add(obeAcceso);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeAcceso;
            }
        }
        public int setPaswword(SqlConnection Conexion)
        {
            //var serverConnection = new ServerConnection(Conexion);
            //serverConnection.Connect();

            //var server = new Server(serverConnection);

            //var login = new Login(server, 'someLogin')
            //{
            //    LoginType =
            //LoginType.SqlLogin
            //};
            //login.ChangePassword(oldPassword, newPassword);
            return 0;
        }
    }
}

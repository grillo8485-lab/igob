using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daConfiguracionModalidadTipoProceso
    {
        public int guardarConfiguracionModalidadTipoProceso(SqlConnection Conexion, beConfiguracionModalidadTipoProceso obeConfiguracionModalidadTipoProceso)
        {
            int Id = 0;
            string sp = "Proc_ConfiguracionModalidadTipoProcesoInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdConfiguracionModalidadTipoProceso", SqlDbType.Int).Value = obeConfiguracionModalidadTipoProceso.IdConfiguracionModalidadTipoProceso;
                    cmd.Parameters.Add("@IdTipoProceso", SqlDbType.Int).Value = obeConfiguracionModalidadTipoProceso.IdTipoProceso;
                    cmd.Parameters.Add("@IdModalidadLicitacion", SqlDbType.Int).Value = obeConfiguracionModalidadTipoProceso.IdModalidadLicitacion;
                    cmd.Parameters.Add("@MontoMinimo", SqlDbType.Decimal).Value = obeConfiguracionModalidadTipoProceso.MontoMinimo;
                    cmd.Parameters.Add("@MontoMaximo", SqlDbType.Decimal).Value = obeConfiguracionModalidadTipoProceso.MontoMaximo;

                    Id = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }




        public int actualizarConfiguracionModalidadTipoProceso(SqlConnection Conexion, beConfiguracionModalidadTipoProceso obeConfiguracionModalidadTipoProceso)
        {
            string sp = "Proc_ConfiguracionModalidadTipoProcesoActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdConfiguracionModalidadTipoProceso", SqlDbType.Int).Value = obeConfiguracionModalidadTipoProceso.IdConfiguracionModalidadTipoProceso;
                    cmd.Parameters.Add("@IdTipoProceso", SqlDbType.Int).Value = obeConfiguracionModalidadTipoProceso.IdTipoProceso;
                    cmd.Parameters.Add("@IdModalidadLicitacion", SqlDbType.Int).Value = obeConfiguracionModalidadTipoProceso.IdModalidadLicitacion;
                    cmd.Parameters.Add("@MontoMinimo", SqlDbType.Decimal).Value = obeConfiguracionModalidadTipoProceso.MontoMinimo;
                    cmd.Parameters.Add("@MontoMaximo", SqlDbType.Decimal).Value = obeConfiguracionModalidadTipoProceso.MontoMaximo;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarConfiguracionModalidadTipoProceso(SqlConnection Conexion, int pIdConfiguracionModalidadTipoProceso)
        {
            string sp = "Proc_ConfiguracionModalidadTipoProcesoEliminar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdConfiguracionModalidadTipoProceso", SqlDbType.Int).Value = pIdConfiguracionModalidadTipoProceso;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
        public beConfiguracionModalidadTipoProceso traerConfiguracionModalidadTipoProceso_x_IdConfiguracionModalidadTipoProceso(SqlConnection Conexion, int IdConfiguracionModalidadTipoProceso)
        {
            string sp = "Proc_ConfiguracionModalidadTipoProceso_x_IdConfiguracionModalidadTipoProceso";
            beConfiguracionModalidadTipoProceso obeConfiguracionModalidadTipoProceso = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdConfiguracionModalidadTipoProceso", SqlDbType.Int).Value = IdConfiguracionModalidadTipoProceso;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdConfiguracionModalidadTipoProceso = datard.GetOrdinal("IdConfiguracionModalidadTipoProceso");
                        int posIdTipoProceso = datard.GetOrdinal("IdTipoProceso");
                        int posIdModalidadLicitacion = datard.GetOrdinal("IdModalidadLicitacion");
                        int posMontoMinimo = datard.GetOrdinal("MontoMinimo");
                        int posMontoMaximo = datard.GetOrdinal("MontoMaximo");
                        obeConfiguracionModalidadTipoProceso = new beConfiguracionModalidadTipoProceso();
                        while (datard.Read())
                        {
                            obeConfiguracionModalidadTipoProceso.IdConfiguracionModalidadTipoProceso = datard.GetInt32(posIdConfiguracionModalidadTipoProceso);
                            obeConfiguracionModalidadTipoProceso.IdTipoProceso = datard.GetInt32(posIdTipoProceso);
                            obeConfiguracionModalidadTipoProceso.IdModalidadLicitacion = datard.GetInt32(posIdModalidadLicitacion);
                            obeConfiguracionModalidadTipoProceso.MontoMinimo = datard.GetDecimal(posMontoMinimo);
                            obeConfiguracionModalidadTipoProceso.MontoMaximo = datard.GetDecimal(posMontoMaximo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeConfiguracionModalidadTipoProceso;
            }
        }
        public List<beConfiguracionModalidadTipoProceso> listarTodos_ConfiguracionModalidadTipoProceso(SqlConnection Conexion)
        {
            string sp = "Proc_ConfiguracionModalidadTipoProceso_Traer_Todos";
            List<beConfiguracionModalidadTipoProceso> lbeConfiguracionModalidadTipoProceso = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdConfiguracionModalidadTipoProceso = datard.GetOrdinal("IdConfiguracionModalidadTipoProceso");
                        int posIdTipoProceso = datard.GetOrdinal("IdTipoProceso");
                        int posIdModalidadLicitacion = datard.GetOrdinal("IdModalidadLicitacion");
                        int posMontoMinimo = datard.GetOrdinal("MontoMinimo");
                        int posMontoMaximo = datard.GetOrdinal("MontoMaximo");
                        lbeConfiguracionModalidadTipoProceso = new List<beConfiguracionModalidadTipoProceso>();
                        beConfiguracionModalidadTipoProceso obeConfiguracionModalidadTipoProceso;
                        while (datard.Read())
                        {
                            obeConfiguracionModalidadTipoProceso = new beConfiguracionModalidadTipoProceso();
                            obeConfiguracionModalidadTipoProceso.IdConfiguracionModalidadTipoProceso = datard.GetInt32(posIdConfiguracionModalidadTipoProceso);
                            obeConfiguracionModalidadTipoProceso.IdTipoProceso = datard.GetInt32(posIdTipoProceso);
                            obeConfiguracionModalidadTipoProceso.IdModalidadLicitacion = datard.GetInt32(posIdModalidadLicitacion);
                            obeConfiguracionModalidadTipoProceso.MontoMinimo = datard.GetDecimal(posMontoMinimo);
                            obeConfiguracionModalidadTipoProceso.MontoMaximo = datard.GetDecimal(posMontoMaximo);
                            lbeConfiguracionModalidadTipoProceso.Add(obeConfiguracionModalidadTipoProceso);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeConfiguracionModalidadTipoProceso;
            }
        }
        public List<beConfiguracionModalidadTipoProceso> listar_ConfiguracionModalidadTipoProceso_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_ConfiguracionModalidadTipoProceso_TraerTodos_GetAll";
            List<beConfiguracionModalidadTipoProceso> lbeConfiguracionModalidadTipoProceso = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdConfiguracionModalidadTipoProceso = datard.GetOrdinal("IdConfiguracionModalidadTipoProceso");
                        int posIdTipoProceso = datard.GetOrdinal("IdTipoProceso");
                        int posIdModalidadLicitacion = datard.GetOrdinal("IdModalidadLicitacion");
                        int posMontoMinimo = datard.GetOrdinal("MontoMinimo");
                        int posMontoMaximo = datard.GetOrdinal("MontoMaximo");
                        lbeConfiguracionModalidadTipoProceso = new List<beConfiguracionModalidadTipoProceso>();
                        beConfiguracionModalidadTipoProceso obeConfiguracionModalidadTipoProceso;
                        while (datard.Read())
                        {
                            obeConfiguracionModalidadTipoProceso = new beConfiguracionModalidadTipoProceso();
                            obeConfiguracionModalidadTipoProceso.IdConfiguracionModalidadTipoProceso = datard.GetInt32(posIdConfiguracionModalidadTipoProceso);
                            obeConfiguracionModalidadTipoProceso.IdTipoProceso = datard.GetInt32(posIdTipoProceso);
                            obeConfiguracionModalidadTipoProceso.IdModalidadLicitacion = datard.GetInt32(posIdModalidadLicitacion);
                            obeConfiguracionModalidadTipoProceso.MontoMinimo = datard.GetDecimal(posMontoMinimo);
                            obeConfiguracionModalidadTipoProceso.MontoMaximo = datard.GetDecimal(posMontoMaximo);
                            // debe agregar campos de la Vista
                            lbeConfiguracionModalidadTipoProceso.Add(obeConfiguracionModalidadTipoProceso);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeConfiguracionModalidadTipoProceso;
            }
        }
        public beConfiguracionModalidadTipoProceso getConfiguracionModalidadTipoProceso_x_IdModalidadLicitacion(SqlConnection Conexion, int pIdModalidadLicitacion)
        {
            string sp = "Proc_ConfiguracionModalidadTipoProceso_x_IdModalidadLicitacion";
            beConfiguracionModalidadTipoProceso obeConfiguracionModalidadTipoProceso = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pIdModalidadLicitacion", SqlDbType.Int).Value = pIdModalidadLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdConfiguracionModalidadTipoProceso = datard.GetOrdinal("IdConfiguracionModalidadTipoProceso");
                        int posIdTipoProceso = datard.GetOrdinal("IdTipoProceso");
                        int posIdModalidadLicitacion = datard.GetOrdinal("IdModalidadLicitacion");
                        int posMontoMinimo = datard.GetOrdinal("MontoMinimo");
                        int posMontoMaximo = datard.GetOrdinal("MontoMaximo");
                        obeConfiguracionModalidadTipoProceso = new beConfiguracionModalidadTipoProceso();
                        while (datard.Read())
                        {
                            obeConfiguracionModalidadTipoProceso.IdConfiguracionModalidadTipoProceso = datard.GetInt32(posIdConfiguracionModalidadTipoProceso);
                            obeConfiguracionModalidadTipoProceso.IdTipoProceso = datard.GetInt32(posIdTipoProceso);
                            obeConfiguracionModalidadTipoProceso.IdModalidadLicitacion = datard.GetInt32(posIdModalidadLicitacion);
                            obeConfiguracionModalidadTipoProceso.MontoMinimo = datard.GetDecimal(posMontoMinimo);
                            obeConfiguracionModalidadTipoProceso.MontoMaximo = datard.GetDecimal(posMontoMaximo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeConfiguracionModalidadTipoProceso;
            }
        }
    }
}

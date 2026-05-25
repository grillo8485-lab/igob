using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daConfiguracionFirmatesPedidos
    {
        public int guardarConfiguracionFirmatesPedidos(SqlConnection Conexion, beConfiguracionFirmatesPedidos obeConfiguracionFirmatesPedidos)
        {
            int Id = 0;
            string sp = "Proc_ConfiguracionFirmatesPedidosInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdConfigFirmantePedido", SqlDbType.Int).Value = obeConfiguracionFirmatesPedidos.IdConfigFirmantePedido;
                    cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeConfiguracionFirmatesPedidos.IdGobierno;
                    cmd.Parameters.Add("@IdModalidadLicitacion", SqlDbType.Int).Value = obeConfiguracionFirmatesPedidos.IdModalidadLicitacion;
                    cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = obeConfiguracionFirmatesPedidos.IdPerfil;
                    cmd.Parameters.Add("@Ordenamiento", SqlDbType.Int).Value = obeConfiguracionFirmatesPedidos.Ordenamiento;
                    cmd.Parameters.Add("@Cargo", SqlDbType.NVarChar).Value = obeConfiguracionFirmatesPedidos.Cargo;
                    cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeConfiguracionFirmatesPedidos.Activo;
                    cmd.Parameters.Add("@IdTipoProceso", SqlDbType.Int).Value = obeConfiguracionFirmatesPedidos.IdTipoProceso;

                    Id = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarConfiguracionFirmatesPedidos(SqlConnection Conexion, beConfiguracionFirmatesPedidos obeConfiguracionFirmatesPedidos)
        {
            string sp = "Proc_ConfiguracionFirmatesPedidosActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdConfigFirmantePedido", SqlDbType.Int).Value = obeConfiguracionFirmatesPedidos.IdConfigFirmantePedido;
                    cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeConfiguracionFirmatesPedidos.IdGobierno;
                    cmd.Parameters.Add("@IdModalidadLicitacion", SqlDbType.Int).Value = obeConfiguracionFirmatesPedidos.IdModalidadLicitacion;
                    cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = obeConfiguracionFirmatesPedidos.IdPerfil;
                    cmd.Parameters.Add("@Ordenamiento", SqlDbType.Int).Value = obeConfiguracionFirmatesPedidos.Ordenamiento;
                    cmd.Parameters.Add("@Cargo", SqlDbType.NVarChar).Value = obeConfiguracionFirmatesPedidos.Cargo;
                    cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeConfiguracionFirmatesPedidos.Activo;
                    cmd.Parameters.Add("@IdTipoProceso", SqlDbType.Int).Value = obeConfiguracionFirmatesPedidos.IdTipoProceso;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarConfiguracionFirmatesPedidos(SqlConnection Conexion, int pIdConfigFirmantePedido)
        {
            string sp = "Proc_ConfiguracionFirmatesPedidosEliminar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdConfigFirmantePedido", SqlDbType.Int).Value = pIdConfigFirmantePedido;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
        public beConfiguracionFirmatesPedidos traerConfiguracionFirmatesPedidos_x_IdConfigFirmantePedido(SqlConnection Conexion, int IdConfigFirmantePedido)
        {
            string sp = "Proc_ConfiguracionFirmatesPedidos_x_IdConfigFirmantePedido";
            beConfiguracionFirmatesPedidos obeConfiguracionFirmatesPedidos = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdConfigFirmantePedido", SqlDbType.Int).Value = IdConfigFirmantePedido;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdConfigFirmantePedido = datard.GetOrdinal("IdConfigFirmantePedido");
                        int posIdGobierno = datard.GetOrdinal("IdGobierno");
                        int posIdModalidadLicitacion = datard.GetOrdinal("IdModalidadLicitacion");
                        int posIdPerfil = datard.GetOrdinal("IdPerfil");
                        int posOrdenamiento = datard.GetOrdinal("Ordenamiento");
                        int posCargo = datard.GetOrdinal("Cargo");
                        int posActivo = datard.GetOrdinal("Activo");
                        int posIdTipoProceso = datard.GetOrdinal("IdTipoProceso");
                        obeConfiguracionFirmatesPedidos = new beConfiguracionFirmatesPedidos();
                        while (datard.Read())
                        {
                            obeConfiguracionFirmatesPedidos.IdConfigFirmantePedido = datard.GetInt32(posIdConfigFirmantePedido);
                            obeConfiguracionFirmatesPedidos.IdGobierno = datard.GetInt32(posIdGobierno);
                            obeConfiguracionFirmatesPedidos.IdModalidadLicitacion = datard.GetInt32(posIdModalidadLicitacion);
                            obeConfiguracionFirmatesPedidos.IdPerfil = datard.GetInt32(posIdPerfil);
                            obeConfiguracionFirmatesPedidos.Ordenamiento = datard.GetInt32(posOrdenamiento);
                            obeConfiguracionFirmatesPedidos.Cargo = datard.GetString(posCargo);
                            obeConfiguracionFirmatesPedidos.Activo = datard.GetBoolean(posActivo);
                            obeConfiguracionFirmatesPedidos.IdTipoProceso = datard.GetInt32(posIdTipoProceso);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeConfiguracionFirmatesPedidos;
            }
        }
        public List<beConfiguracionFirmatesPedidos> listarTodos_ConfiguracionFirmatesPedidos(SqlConnection Conexion)
        {
            string sp = "Proc_ConfiguracionFirmatesPedidos_Traer_Todos";
            List<beConfiguracionFirmatesPedidos> lbeConfiguracionFirmatesPedidos = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdConfigFirmantePedido = datard.GetOrdinal("IdConfigFirmantePedido");
                        int posIdGobierno = datard.GetOrdinal("IdGobierno");
                        int posIdModalidadLicitacion = datard.GetOrdinal("IdModalidadLicitacion");
                        int posIdPerfil = datard.GetOrdinal("IdPerfil");
                        int posOrdenamiento = datard.GetOrdinal("Ordenamiento");
                        int posCargo = datard.GetOrdinal("Cargo");
                        int posActivo = datard.GetOrdinal("Activo");
                        int posIdTipoProceso = datard.GetOrdinal("IdTipoProceso");
                        lbeConfiguracionFirmatesPedidos = new List<beConfiguracionFirmatesPedidos>();
                        beConfiguracionFirmatesPedidos obeConfiguracionFirmatesPedidos;
                        while (datard.Read())
                        {
                            obeConfiguracionFirmatesPedidos = new beConfiguracionFirmatesPedidos();
                            obeConfiguracionFirmatesPedidos.IdConfigFirmantePedido = datard.GetInt32(posIdConfigFirmantePedido);
                            obeConfiguracionFirmatesPedidos.IdGobierno = datard.GetInt32(posIdGobierno);
                            obeConfiguracionFirmatesPedidos.IdModalidadLicitacion = datard.GetInt32(posIdModalidadLicitacion);
                            obeConfiguracionFirmatesPedidos.IdPerfil = datard.GetInt32(posIdPerfil);
                            obeConfiguracionFirmatesPedidos.Ordenamiento = datard.GetInt32(posOrdenamiento);
                            obeConfiguracionFirmatesPedidos.Cargo = datard.GetString(posCargo);
                            obeConfiguracionFirmatesPedidos.Activo = datard.GetBoolean(posActivo);
                            obeConfiguracionFirmatesPedidos.IdTipoProceso = datard.GetInt32(posIdTipoProceso);
                            lbeConfiguracionFirmatesPedidos.Add(obeConfiguracionFirmatesPedidos);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeConfiguracionFirmatesPedidos;
            }
        }
        public List<beConfiguracionFirmatesPedidos> listar_ConfiguracionFirmatesPedidos_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_ConfiguracionFirmatesPedidos_TraerTodos_GetAll";
            List<beConfiguracionFirmatesPedidos> lbeConfiguracionFirmatesPedidos = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdConfigFirmantePedido = datard.GetOrdinal("IdConfigFirmantePedido");
                        int posIdGobierno = datard.GetOrdinal("IdGobierno");
                        int posIdModalidadLicitacion = datard.GetOrdinal("IdModalidadLicitacion");
                        int posIdPerfil = datard.GetOrdinal("IdPerfil");
                        int posOrdenamiento = datard.GetOrdinal("Ordenamiento");
                        int posCargo = datard.GetOrdinal("Cargo");
                        int posActivo = datard.GetOrdinal("Activo");
                        int posIdTipoProceso = datard.GetOrdinal("IdTipoProceso");
                        lbeConfiguracionFirmatesPedidos = new List<beConfiguracionFirmatesPedidos>();
                        beConfiguracionFirmatesPedidos obeConfiguracionFirmatesPedidos;
                        while (datard.Read())
                        {
                            obeConfiguracionFirmatesPedidos = new beConfiguracionFirmatesPedidos();
                            obeConfiguracionFirmatesPedidos.IdConfigFirmantePedido = datard.GetInt32(posIdConfigFirmantePedido);
                            obeConfiguracionFirmatesPedidos.IdGobierno = datard.GetInt32(posIdGobierno);
                            obeConfiguracionFirmatesPedidos.IdModalidadLicitacion = datard.GetInt32(posIdModalidadLicitacion);
                            obeConfiguracionFirmatesPedidos.IdPerfil = datard.GetInt32(posIdPerfil);
                            obeConfiguracionFirmatesPedidos.Ordenamiento = datard.GetInt32(posOrdenamiento);
                            obeConfiguracionFirmatesPedidos.Cargo = datard.GetString(posCargo);
                            obeConfiguracionFirmatesPedidos.Activo = datard.GetBoolean(posActivo);
                            obeConfiguracionFirmatesPedidos.IdTipoProceso = datard.GetInt32(posIdTipoProceso);
                            // debe agregar campos de la Vista
                            lbeConfiguracionFirmatesPedidos.Add(obeConfiguracionFirmatesPedidos);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeConfiguracionFirmatesPedidos;
            }
        }
        public List<beConfiguracionFirmatesPedidos> listarConfiguracionFirmantesModalidades_x_IdModalidadLicitacion(SqlConnection Conexion,int pIdModalidadLicitacion)
        {
            string sp = "Proc_ConfiguracionFirmatesPedidos_x_IdModalidadLicitacion";
            List<beConfiguracionFirmatesPedidos> lbeConfiguracionFirmatesPedidos = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdModalidadLicitacion", SqlDbType.Int).Value = pIdModalidadLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdConfigFirmantePedido = datard.GetOrdinal("IdConfigFirmantePedido");
                        int posIdGobierno = datard.GetOrdinal("IdGobierno");
                        int posIdModalidadLicitacion = datard.GetOrdinal("IdModalidadLicitacion");
                        int posIdPerfil = datard.GetOrdinal("IdPerfil");
                        int posOrdenamiento = datard.GetOrdinal("Ordenamiento");
                        int posCargo = datard.GetOrdinal("Cargo");
                        int posActivo = datard.GetOrdinal("Activo");
                        int posIdTipoProceso = datard.GetOrdinal("IdTipoProceso");

                        int posPerfil = datard.GetOrdinal("Perfil");
                        int posModalidad = datard.GetOrdinal("Modalidad");


                        lbeConfiguracionFirmatesPedidos = new List<beConfiguracionFirmatesPedidos>();
                        beConfiguracionFirmatesPedidos obeConfiguracionFirmatesPedidos;
                        while (datard.Read())
                        {
                            obeConfiguracionFirmatesPedidos = new beConfiguracionFirmatesPedidos();
                            obeConfiguracionFirmatesPedidos.IdConfigFirmantePedido = datard.GetInt32(posIdConfigFirmantePedido);
                            obeConfiguracionFirmatesPedidos.IdGobierno = datard.GetInt32(posIdGobierno);
                            obeConfiguracionFirmatesPedidos.IdModalidadLicitacion = datard.GetInt32(posIdModalidadLicitacion);
                            obeConfiguracionFirmatesPedidos.IdPerfil = datard.GetInt32(posIdPerfil);
                            obeConfiguracionFirmatesPedidos.Ordenamiento = datard.GetInt32(posOrdenamiento);
                            obeConfiguracionFirmatesPedidos.Cargo = datard.GetString(posCargo);
                            obeConfiguracionFirmatesPedidos.Activo = datard.GetBoolean(posActivo);
                            obeConfiguracionFirmatesPedidos.IdTipoProceso = datard.GetInt32(posIdTipoProceso);
                            obeConfiguracionFirmatesPedidos.Perfil = datard.GetString(posPerfil);
                            obeConfiguracionFirmatesPedidos.Modalidad = datard.GetString(posModalidad);
                            // debe agregar campos de la Vista
                            lbeConfiguracionFirmatesPedidos.Add(obeConfiguracionFirmatesPedidos);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeConfiguracionFirmatesPedidos;
            }
        }
        public bool procesarOrdenamiento(SqlConnection Conexion, int pIdModalidadLicitacion)
        {
            string sp = "Proc_ConfiguracionFirmatesPedidosActualizarOrdenamiento";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdModalidadLicitacion", SqlDbType.Int).Value = pIdModalidadLicitacion;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
            }
        }
    }
}

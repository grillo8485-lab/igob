using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daTmpRequisicionesLicitacion
    {
        public int guardarTmpRequisicionesLicitacion(SqlConnection Conexion, beTmpRequisicionesLicitacion obeTmpRequisicionesLicitacion)
        {
            int Id = 0;
            string sp = "Proc_TmpRequisicionesLicitacionInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdGuid", SqlDbType.NVarChar).Value = obeTmpRequisicionesLicitacion.IdGuid;
                    cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeTmpRequisicionesLicitacion.IdRequisicion;
                    cmd.Parameters.Add("@IdTiempo", SqlDbType.Int).Value = obeTmpRequisicionesLicitacion.IdTiempo;
                    cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = obeTmpRequisicionesLicitacion.Total;

                    Id = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarTmpRequisicionesLicitacion(SqlConnection Conexion, beTmpRequisicionesLicitacion obeTmpRequisicionesLicitacion)
        {
            string sp = "Proc_TmpRequisicionesLicitacionActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdGuid", SqlDbType.NVarChar).Value = obeTmpRequisicionesLicitacion.IdGuid;
                    cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obeTmpRequisicionesLicitacion.IdRequisicion;
                    cmd.Parameters.Add("@IdTiempo", SqlDbType.Int).Value = obeTmpRequisicionesLicitacion.IdTiempo;
                    cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = obeTmpRequisicionesLicitacion.Total;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarTmpRequisicionesLicitacion(SqlConnection Conexion, int pIdRequisicion)
        {
            string sp = "Proc_TmpRequisicionesLicitacionEliminar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdRequisicion", SqlDbType.NVarChar).Value = pIdRequisicion;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
        public beTmpRequisicionesLicitacion traerTmpRequisicionesLicitacion_x_IdRequisicion(SqlConnection Conexion, int IdRequisicion)
        {
            string sp = "Proc_TmpRequisicionesLicitacion_x_IdRequisicion";
            beTmpRequisicionesLicitacion obeTmpRequisicionesLicitacion = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRequisicion", SqlDbType.NVarChar).Value = IdRequisicion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdGuid = datard.GetOrdinal("IdGuid");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdTiempo = datard.GetOrdinal("IdTiempo");
                        int posTotal = datard.GetOrdinal("Total");
                        obeTmpRequisicionesLicitacion = new beTmpRequisicionesLicitacion();
                        while (datard.Read())
                        {
                            obeTmpRequisicionesLicitacion.IdGuid = datard.GetString(posIdGuid);
                            obeTmpRequisicionesLicitacion.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeTmpRequisicionesLicitacion.IdTiempo = datard.GetInt32(posIdTiempo);
                            obeTmpRequisicionesLicitacion.Total = datard.GetDecimal(posTotal);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeTmpRequisicionesLicitacion;
            }
        }
        public List<beTmpRequisicionesLicitacion> listarTodos_TmpRequisicionesLicitacion(SqlConnection Conexion)
        {
            string sp = "Proc_TmpRequisicionesLicitacion_Traer_Todos";
            List<beTmpRequisicionesLicitacion> lbeTmpRequisicionesLicitacion = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdGuid = datard.GetOrdinal("IdGuid");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdTiempo = datard.GetOrdinal("IdTiempo");
                        int posTotal = datard.GetOrdinal("Total");
                        lbeTmpRequisicionesLicitacion = new List<beTmpRequisicionesLicitacion>();
                        beTmpRequisicionesLicitacion obeTmpRequisicionesLicitacion;
                        while (datard.Read())
                        {
                            obeTmpRequisicionesLicitacion = new beTmpRequisicionesLicitacion();
                            obeTmpRequisicionesLicitacion.IdGuid = datard.GetString(posIdGuid);
                            obeTmpRequisicionesLicitacion.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeTmpRequisicionesLicitacion.IdTiempo = datard.GetInt32(posIdTiempo);
                            obeTmpRequisicionesLicitacion.Total = datard.GetDecimal(posTotal);
                            lbeTmpRequisicionesLicitacion.Add(obeTmpRequisicionesLicitacion);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeTmpRequisicionesLicitacion;
            }
        }
        public List<beTmpRequisicionesLicitacion> listar_TmpRequisicionesLicitacion_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_TmpRequisicionesLicitacion_TraerTodos_GetAll";
            List<beTmpRequisicionesLicitacion> lbeTmpRequisicionesLicitacion = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdGuid = datard.GetOrdinal("IdGuid");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posIdTiempo = datard.GetOrdinal("IdTiempo");
                        int posTotal = datard.GetOrdinal("Total");
                        lbeTmpRequisicionesLicitacion = new List<beTmpRequisicionesLicitacion>();
                        beTmpRequisicionesLicitacion obeTmpRequisicionesLicitacion;
                        while (datard.Read())
                        {
                            obeTmpRequisicionesLicitacion = new beTmpRequisicionesLicitacion();
                            obeTmpRequisicionesLicitacion.IdGuid = datard.GetString(posIdGuid);
                            obeTmpRequisicionesLicitacion.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeTmpRequisicionesLicitacion.IdTiempo = datard.GetInt32(posIdTiempo);
                            obeTmpRequisicionesLicitacion.Total = datard.GetDecimal(posTotal);
                            // debe agregar campos de la Vista
                            lbeTmpRequisicionesLicitacion.Add(obeTmpRequisicionesLicitacion);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeTmpRequisicionesLicitacion;
            }
        }
        public beTmpRequisicionesLicitacion getTmpRequisicionesLicitacion_x_Guid(SqlConnection Conexion, string pGuid)
        {
            string sp = "Proc_traerModalidadTiempoLicitacion";
            beTmpRequisicionesLicitacion obeTmpRequisicionesLicitacion = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdGuid", SqlDbType.NVarChar).Value = pGuid;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        //int posIdGuid = datard.GetOrdinal("IdGuid");
                        int posIdConfiguracionModalidad = datard.GetOrdinal("IdConfiguracionModalidad");
                        int posIdTiempo = datard.GetOrdinal("IdTiempo");
                        int posTotal = datard.GetOrdinal("Total");

                        obeTmpRequisicionesLicitacion = new beTmpRequisicionesLicitacion();
                        while (datard.Read())
                        {
                            //obeTmpRequisicionesLicitacion.IdGuid = datard.GetString(posIdGuid);
                            obeTmpRequisicionesLicitacion.IdConfiguracionModalidad = datard.GetInt32(posIdConfiguracionModalidad);
                            obeTmpRequisicionesLicitacion.IdTiempo = datard.GetInt32(posIdTiempo);
                            obeTmpRequisicionesLicitacion.Total = datard.GetDecimal(posTotal);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeTmpRequisicionesLicitacion;
            }
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daModalidadesLicitaciones
    {
        public int guardarModalidadesLicitaciones(SqlConnection Conexion, beModalidadesLicitaciones obeModalidadesLicitaciones)
        {
            int Id = 0;
            string sp = "Proc_ModalidadesLicitacionesInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdModalidadLicitacion", SqlDbType.Int).Value = obeModalidadesLicitaciones.IdModalidadLicitacion;
                    cmd.Parameters.Add("@ModalidadLicitacion", SqlDbType.NVarChar).Value = obeModalidadesLicitaciones.ModalidadLicitacion;
                    cmd.Parameters.Add("@Abreviatura", SqlDbType.NChar).Value = obeModalidadesLicitaciones.Abreviatura;
                    cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeModalidadesLicitaciones.Activo;

                    Id = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarModalidadesLicitaciones(SqlConnection Conexion, beModalidadesLicitaciones obeModalidadesLicitaciones)
        {
            string sp = "Proc_ModalidadesLicitacionesActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdModalidadLicitacion", SqlDbType.Int).Value = obeModalidadesLicitaciones.IdModalidadLicitacion;
                    cmd.Parameters.Add("@ModalidadLicitacion", SqlDbType.NVarChar).Value = obeModalidadesLicitaciones.ModalidadLicitacion;
                    cmd.Parameters.Add("@Abreviatura", SqlDbType.NChar).Value = obeModalidadesLicitaciones.Abreviatura;
                    cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeModalidadesLicitaciones.Activo;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarModalidadesLicitaciones(SqlConnection Conexion, int pIdModalidadLicitacion)
        {
            string sp = "Proc_ModalidadesLicitacionesEliminar";
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
                return 0;
            }
        }
        public beModalidadesLicitaciones traerModalidadesLicitaciones_x_IdModalidadLicitacion(SqlConnection Conexion, int IdModalidadLicitacion)
        {
            string sp = "Proc_ModalidadesLicitaciones_x_IdModalidadLicitacion";
            beModalidadesLicitaciones obeModalidadesLicitaciones = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdModalidadLicitacion", SqlDbType.Int).Value = IdModalidadLicitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdModalidadLicitacion = datard.GetOrdinal("IdModalidadLicitacion");
                        int posModalidadLicitacion = datard.GetOrdinal("ModalidadLicitacion");
                        int posAbreviatura = datard.GetOrdinal("Abreviatura");
                        int posActivo = datard.GetOrdinal("Activo");
                        obeModalidadesLicitaciones = new beModalidadesLicitaciones();
                        while (datard.Read())
                        {
                            obeModalidadesLicitaciones.IdModalidadLicitacion = datard.GetInt32(posIdModalidadLicitacion);
                            obeModalidadesLicitaciones.ModalidadLicitacion = datard.GetString(posModalidadLicitacion);
                            obeModalidadesLicitaciones.Abreviatura = datard.GetString(posAbreviatura);
                            obeModalidadesLicitaciones.Activo = datard.GetBoolean(posActivo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeModalidadesLicitaciones;
            }
        }
        public List<beModalidadesLicitaciones> listarTodos_ModalidadesLicitaciones(SqlConnection Conexion)
        {
            string sp = "Proc_ModalidadesLicitaciones_Traer_Todos";
            List<beModalidadesLicitaciones> lbeModalidadesLicitaciones = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdModalidadLicitacion = datard.GetOrdinal("IdModalidadLicitacion");
                        int posModalidadLicitacion = datard.GetOrdinal("ModalidadLicitacion");
                        int posAbreviatura = datard.GetOrdinal("Abreviatura");
                        int posActivo = datard.GetOrdinal("Activo");
                        lbeModalidadesLicitaciones = new List<beModalidadesLicitaciones>();
                        beModalidadesLicitaciones obeModalidadesLicitaciones;
                        while (datard.Read())
                        {
                            obeModalidadesLicitaciones = new beModalidadesLicitaciones();
                            obeModalidadesLicitaciones.IdModalidadLicitacion = datard.GetInt32(posIdModalidadLicitacion);
                            obeModalidadesLicitaciones.ModalidadLicitacion = datard.GetString(posModalidadLicitacion);
                            obeModalidadesLicitaciones.Abreviatura = datard.GetString(posAbreviatura);
                            obeModalidadesLicitaciones.Activo = datard.GetBoolean(posActivo);
                            lbeModalidadesLicitaciones.Add(obeModalidadesLicitaciones);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeModalidadesLicitaciones;
            }
        }
        public List<beModalidadesLicitaciones> listar_ModalidadesLicitaciones_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_ModalidadesLicitaciones_TraerTodos_GetAll";
            List<beModalidadesLicitaciones> lbeModalidadesLicitaciones = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdModalidadLicitacion = datard.GetOrdinal("IdModalidadLicitacion");
                        int posModalidadLicitacion = datard.GetOrdinal("ModalidadLicitacion");
                        int posAbreviatura = datard.GetOrdinal("Abreviatura");
                        int posActivo = datard.GetOrdinal("Activo");
                        lbeModalidadesLicitaciones = new List<beModalidadesLicitaciones>();
                        beModalidadesLicitaciones obeModalidadesLicitaciones;
                        while (datard.Read())
                        {
                            obeModalidadesLicitaciones = new beModalidadesLicitaciones();
                            obeModalidadesLicitaciones.IdModalidadLicitacion = datard.GetInt32(posIdModalidadLicitacion);
                            obeModalidadesLicitaciones.ModalidadLicitacion = datard.GetString(posModalidadLicitacion);
                            obeModalidadesLicitaciones.Abreviatura = datard.GetString(posAbreviatura);
                            obeModalidadesLicitaciones.Activo = datard.GetBoolean(posActivo);
                            // debe agregar campos de la Vista
                            lbeModalidadesLicitaciones.Add(obeModalidadesLicitaciones);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeModalidadesLicitaciones;
            }
        }
        
    }
}

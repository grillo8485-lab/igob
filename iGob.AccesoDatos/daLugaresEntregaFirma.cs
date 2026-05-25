using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daLugaresEntregaFirma
    {
        public int guardarLugaresEntregaFirma(SqlConnection Conexion, beLugaresEntregaFirma obeLugaresEntregaFirma)
        {
            int Id = 0;
            string sp = "Proc_LugaresEntregaFirmaInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdLugarEntregaFirma", SqlDbType.Int).Value = obeLugaresEntregaFirma.IdLugarEntregaFirma;
                    cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeLugaresEntregaFirma.IdDependencia;
                    cmd.Parameters.Add("@Lugar", SqlDbType.NVarChar).Value = obeLugaresEntregaFirma.Lugar;
                    cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = obeLugaresEntregaFirma.Direccion;
                    cmd.Parameters.Add("@Colonia", SqlDbType.NVarChar).Value = obeLugaresEntregaFirma.Colonia;
                    cmd.Parameters.Add("@CodigoPostal", SqlDbType.NChar).Value = obeLugaresEntregaFirma.CodigoPostal;
                    cmd.Parameters.Add("@IdMunicipio", SqlDbType.Char).Value = obeLugaresEntregaFirma.IdMunicipio;
                    cmd.Parameters.Add("@Telefono", SqlDbType.NChar).Value = obeLugaresEntregaFirma.Telefono;
                    cmd.Parameters.Add("@LocalizacionGoogle", SqlDbType.NVarChar).Value = obeLugaresEntregaFirma.LocalizacionGoogle;
                    cmd.Parameters.Add("@IdTipoLugar", SqlDbType.Int).Value = obeLugaresEntregaFirma.IdTipoLugar;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeLugaresEntregaFirma.IdUsuarioRegistro;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeLugaresEntregaFirma.FechaRegistro;

                    Id = (int)cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarLugaresEntregaFirma(SqlConnection Conexion, beLugaresEntregaFirma obeLugaresEntregaFirma)
        {
            string sp = "Proc_LugaresEntregaFirmaActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdLugarEntregaFirma", SqlDbType.Int).Value = obeLugaresEntregaFirma.IdLugarEntregaFirma;
                    cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = obeLugaresEntregaFirma.IdDependencia;
                    cmd.Parameters.Add("@Lugar", SqlDbType.NVarChar).Value = obeLugaresEntregaFirma.Lugar;
                    cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = obeLugaresEntregaFirma.Direccion;
                    cmd.Parameters.Add("@Colonia", SqlDbType.NVarChar).Value = obeLugaresEntregaFirma.Colonia;
                    cmd.Parameters.Add("@CodigoPostal", SqlDbType.NChar).Value = obeLugaresEntregaFirma.CodigoPostal;
                    cmd.Parameters.Add("@IdMunicipio", SqlDbType.Char).Value = obeLugaresEntregaFirma.IdMunicipio;
                    cmd.Parameters.Add("@Telefono", SqlDbType.NChar).Value = obeLugaresEntregaFirma.Telefono;
                    cmd.Parameters.Add("@LocalizacionGoogle", SqlDbType.NVarChar).Value = obeLugaresEntregaFirma.LocalizacionGoogle;
                    cmd.Parameters.Add("@IdTipoLugar", SqlDbType.Int).Value = obeLugaresEntregaFirma.IdTipoLugar;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeLugaresEntregaFirma.IdUsuarioRegistro;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeLugaresEntregaFirma.FechaRegistro;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarLugaresEntregaFirma(SqlConnection Conexion, int pIdLugarEntregaFirma)
        {
            string sp = "Proc_LugaresEntregaFirmaEliminar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdLugarEntregaFirma", SqlDbType.Int).Value = pIdLugarEntregaFirma;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
        public beLugaresEntregaFirma traerLugaresEntregaFirma_x_IdLugarEntregaFirma(SqlConnection Conexion, int IdLugarEntregaFirma)
        {
            string sp = "Proc_LugaresEntregaFirma_x_IdLugarEntregaFirma";
            List<beLugaresEntregaFirma> lbeLugaresEntregaFirma = null;
            beLugaresEntregaFirma obeLugaresEntregaFirma = new beLugaresEntregaFirma();
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLugarEntregaFirma", SqlDbType.Int).Value = IdLugarEntregaFirma;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        lbeLugaresEntregaFirma = new List<beLugaresEntregaFirma>();
                        while (datard.Read())
                        {
                            obeLugaresEntregaFirma = new beLugaresEntregaFirma();
                            obeLugaresEntregaFirma.IdLugarEntregaFirma = datard.GetInt32(0);
                            obeLugaresEntregaFirma.IdDependencia = datard.GetInt32(1);
                            obeLugaresEntregaFirma.Lugar = datard.GetString(2);
                            obeLugaresEntregaFirma.Direccion = datard.GetString(3);
                            obeLugaresEntregaFirma.Colonia = datard.GetString(4);
                            obeLugaresEntregaFirma.CodigoPostal = datard.GetString(5);
                            obeLugaresEntregaFirma.IdMunicipio = datard.GetString(6);
                            obeLugaresEntregaFirma.Telefono = datard.GetString(7);
                            obeLugaresEntregaFirma.LocalizacionGoogle = datard.GetString(8);
                            obeLugaresEntregaFirma.IdTipoLugar = datard.GetInt32(9);
                            obeLugaresEntregaFirma.IdUsuarioRegistro = datard.GetInt32(10);
                            obeLugaresEntregaFirma.FechaRegistro = datard.GetDateTime(11);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLugaresEntregaFirma;
            }
        }
        public List<beLugaresEntregaFirma> listarTodos_LugaresEntregaFirma(SqlConnection Conexion)
        {
            string sp = "Proc_LugaresEntregaFirma_Traer_Todos";
            List<beLugaresEntregaFirma> lbeLugaresEntregaFirma = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        lbeLugaresEntregaFirma = new List<beLugaresEntregaFirma>();
                        beLugaresEntregaFirma obeLugaresEntregaFirma;
                        while (datard.Read())
                        {
                            obeLugaresEntregaFirma = new beLugaresEntregaFirma();
                            obeLugaresEntregaFirma.IdLugarEntregaFirma = datard.GetInt32(0);
                            obeLugaresEntregaFirma.IdDependencia = datard.GetInt32(1);
                            obeLugaresEntregaFirma.Lugar = datard.GetString(2);
                            obeLugaresEntregaFirma.Direccion = datard.GetString(3);
                            obeLugaresEntregaFirma.Colonia = datard.GetString(4);
                            obeLugaresEntregaFirma.CodigoPostal = datard.GetString(5);
                            obeLugaresEntregaFirma.IdMunicipio = datard.GetString(6);
                            obeLugaresEntregaFirma.Telefono = datard.GetString(7);
                            obeLugaresEntregaFirma.LocalizacionGoogle = datard.GetString(8);
                            obeLugaresEntregaFirma.IdTipoLugar = datard.GetInt32(9);
                            obeLugaresEntregaFirma.IdUsuarioRegistro = datard.GetInt32(10);
                            obeLugaresEntregaFirma.FechaRegistro = datard.GetDateTime(11);
                            lbeLugaresEntregaFirma.Add(obeLugaresEntregaFirma);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLugaresEntregaFirma;
            }
        }

        public DataTable listarLugaresEntregaFirma_x_(SqlConnection Conexion, int IdLugarEntregaFirma)
        {
            string sp = "Proc_LugaresEntregaFirma_Traer_Todos";
            DataTable dtLugaresEntregaFirma = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdLugarEntregaFirma", SqlDbType.Int).Value = IdLugarEntregaFirma;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        dtLugaresEntregaFirma = new DataTable();
                        dtLugaresEntregaFirma.Load(datard);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return dtLugaresEntregaFirma;
            }
        }

        public List<beLugaresEntregaFirma> Listar_LugaresEntregaFirma_Traer_Entrega(SqlConnection Conexion)
        {
            string sp = "Proc_LugaresEntregaFirma_Traer_Entrega";
            List<beLugaresEntregaFirma> lbeLugaresEntregaFirma = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        lbeLugaresEntregaFirma = new List<beLugaresEntregaFirma>();
                        beLugaresEntregaFirma obeLugaresEntregaFirma;
                        while (datard.Read())
                        {
                            obeLugaresEntregaFirma = new beLugaresEntregaFirma();
                            obeLugaresEntregaFirma.IdLugarEntregaFirma = datard.GetInt32(0);
                            obeLugaresEntregaFirma.IdDependencia = datard.GetInt32(1);
                            obeLugaresEntregaFirma.Dependencia = datard.GetString(2);
                            obeLugaresEntregaFirma.Lugar = datard.GetString(3);
                            obeLugaresEntregaFirma.Direccion = datard.GetString(4);
                            obeLugaresEntregaFirma.Colonia = datard.GetString(5);
                            obeLugaresEntregaFirma.CodigoPostal = datard.GetString(6);
                            obeLugaresEntregaFirma.IdMunicipio = datard.GetString(7);
                            obeLugaresEntregaFirma.Municipio = datard.GetString(8);
                            obeLugaresEntregaFirma.ClaveEstado = datard.GetString(9);
                            obeLugaresEntregaFirma.Estado = datard.GetString(10);
                            obeLugaresEntregaFirma.Telefono = datard.GetString(11);
                            obeLugaresEntregaFirma.LocalizacionGoogle = datard.GetString(12);
                            obeLugaresEntregaFirma.IdTipoLugar = datard.GetInt32(13);
                            obeLugaresEntregaFirma.IdUsuarioRegistro = datard.GetInt32(14);
                            obeLugaresEntregaFirma.FechaRegistro = datard.GetDateTime(15);
                            lbeLugaresEntregaFirma.Add(obeLugaresEntregaFirma);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLugaresEntregaFirma;
            }
        }

        public List<beLugaresEntregaFirma> Listar_LugaresEntregaFirma_Traer_Firma(SqlConnection Conexion)
        {
            string sp = "Proc_LugaresEntregaFirma_Traer_Firma";
            List<beLugaresEntregaFirma> lbeLugaresEntregaFirma = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        lbeLugaresEntregaFirma = new List<beLugaresEntregaFirma>();
                        beLugaresEntregaFirma obeLugaresEntregaFirma;
                        while (datard.Read())
                        {
                            obeLugaresEntregaFirma = new beLugaresEntregaFirma();
                            obeLugaresEntregaFirma.IdLugarEntregaFirma = datard.GetInt32(0);
                            obeLugaresEntregaFirma.IdDependencia = datard.GetInt32(1);
                            obeLugaresEntregaFirma.Dependencia = datard.GetString(2);
                            obeLugaresEntregaFirma.Lugar = datard.GetString(3);
                            obeLugaresEntregaFirma.Direccion = datard.GetString(4);
                            obeLugaresEntregaFirma.Colonia = datard.GetString(5);
                            obeLugaresEntregaFirma.CodigoPostal = datard.GetString(6);
                            obeLugaresEntregaFirma.IdMunicipio = datard.GetString(7);
                            obeLugaresEntregaFirma.Municipio = datard.GetString(8);
                            obeLugaresEntregaFirma.ClaveEstado = datard.GetString(9);
                            obeLugaresEntregaFirma.Estado = datard.GetString(10);
                            obeLugaresEntregaFirma.Telefono = datard.GetString(11);
                            obeLugaresEntregaFirma.LocalizacionGoogle = datard.GetString(12);
                            obeLugaresEntregaFirma.IdTipoLugar = datard.GetInt32(13);
                            obeLugaresEntregaFirma.IdUsuarioRegistro = datard.GetInt32(14);
                            obeLugaresEntregaFirma.FechaRegistro = datard.GetDateTime(15);
                            lbeLugaresEntregaFirma.Add(obeLugaresEntregaFirma);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLugaresEntregaFirma;
            }
        }

    }
}

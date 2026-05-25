using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daManifiestosProveedores
    {
        public int guardarManifiestosProveedores(SqlConnection Conexion, beManifiestosProveedores obeManifiestosProveedores)
        {
            int Id = 0;
            string sp = "Proc_ManifiestosProveedoresInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdManifiestoProveedor", SqlDbType.Int).Value = obeManifiestosProveedores.IdManifiestoProveedor;
                    cmd.Parameters.Add("@IdProveedorRqInvitacion", SqlDbType.Int).Value = obeManifiestosProveedores.IdProveedorRqInvitacion;
                    cmd.Parameters.Add("@AplicaCapitalContable", SqlDbType.Int).Value = obeManifiestosProveedores.AplicaCapitalContable;
                    cmd.Parameters.Add("@Infraestructura", SqlDbType.Text).Value = obeManifiestosProveedores.Infraestructura;
                    cmd.Parameters.Add("@AnnioExperiencia", SqlDbType.Int).Value = obeManifiestosProveedores.AnnioExperiencia;
                    cmd.Parameters.Add("@NumeroEmpleados", SqlDbType.Int).Value = obeManifiestosProveedores.NumeroEmpleados;
                    cmd.Parameters.Add("@Domicilio", SqlDbType.VarChar).Value = obeManifiestosProveedores.Domicilio;
                    cmd.Parameters.Add("@CapitalContable", SqlDbType.Decimal).Value = obeManifiestosProveedores.CapitalContable;
                    cmd.Parameters.Add("@IngresosUltimoAnnio", SqlDbType.Decimal).Value = obeManifiestosProveedores.IngresosUltimoAnnio;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeManifiestosProveedores.IdUsuarioRegistro;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeManifiestosProveedores.FechaRegistro;

                    Id = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarManifiestosProveedores(SqlConnection Conexion, beManifiestosProveedores obeManifiestosProveedores)
        {
            string sp = "Proc_ManifiestosProveedoresActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdManifiestoProveedor", SqlDbType.Int).Value = obeManifiestosProveedores.IdManifiestoProveedor;
                    cmd.Parameters.Add("@IdProveedorRqInvitacion", SqlDbType.Int).Value = obeManifiestosProveedores.IdProveedorRqInvitacion;
                    cmd.Parameters.Add("@AplicaCapitalContable", SqlDbType.Int).Value = obeManifiestosProveedores.AplicaCapitalContable;
                    cmd.Parameters.Add("@Infraestructura", SqlDbType.Text).Value = obeManifiestosProveedores.Infraestructura;
                    cmd.Parameters.Add("@AnnioExperiencia", SqlDbType.Int).Value = obeManifiestosProveedores.AnnioExperiencia;
                    cmd.Parameters.Add("@NumeroEmpleados", SqlDbType.Int).Value = obeManifiestosProveedores.NumeroEmpleados;
                    cmd.Parameters.Add("@Domicilio", SqlDbType.VarChar).Value = obeManifiestosProveedores.Domicilio;
                    cmd.Parameters.Add("@CapitalContable", SqlDbType.Decimal).Value = obeManifiestosProveedores.CapitalContable;
                    cmd.Parameters.Add("@IngresosUltimoAnnio", SqlDbType.Decimal).Value = obeManifiestosProveedores.IngresosUltimoAnnio;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeManifiestosProveedores.IdUsuarioRegistro;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeManifiestosProveedores.FechaRegistro;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarManifiestosProveedores(SqlConnection Conexion, int pIdManifiestoProveedor)
        {
            string sp = "Proc_ManifiestosProveedoresEliminar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdManifiestoProveedor", SqlDbType.Int).Value = pIdManifiestoProveedor;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
        public beManifiestosProveedores traerManifiestosProveedores_x_IdManifiestoProveedor(SqlConnection Conexion, int IdManifiestoProveedor)
        {
            string sp = "Proc_ManifiestosProveedores_x_IdManifiestoProveedor";
            beManifiestosProveedores obeManifiestosProveedores = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdManifiestoProveedor", SqlDbType.Int).Value = IdManifiestoProveedor;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdManifiestoProveedor = datard.GetOrdinal("IdManifiestoProveedor");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int posAplicaCapitalContable = datard.GetOrdinal("AplicaCapitalContable");
                        int posInfraestructura = datard.GetOrdinal("Infraestructura");
                        int posAnnioExperiencia = datard.GetOrdinal("AnnioExperiencia");
                        int posNumeroEmpleados = datard.GetOrdinal("NumeroEmpleados");
                        int posDomicilio = datard.GetOrdinal("Domicilio");
                        int posCapitalContable = datard.GetOrdinal("CapitalContable");
                        int posIngresosUltimoAnnio = datard.GetOrdinal("IngresosUltimoAnnio");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        obeManifiestosProveedores = new beManifiestosProveedores();
                        while (datard.Read())
                        {
                            obeManifiestosProveedores.IdManifiestoProveedor = datard.GetInt32(posIdManifiestoProveedor);
                            obeManifiestosProveedores.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);
                            obeManifiestosProveedores.AplicaCapitalContable = datard.GetInt32(posAplicaCapitalContable);
                            obeManifiestosProveedores.Infraestructura = datard[posInfraestructura] == DBNull.Value ? "" : datard.GetString(posInfraestructura);
                            obeManifiestosProveedores.AnnioExperiencia = datard.GetInt32(posAnnioExperiencia);
                            obeManifiestosProveedores.NumeroEmpleados = datard[posNumeroEmpleados] == DBNull.Value ? 0 : datard.GetInt32(posNumeroEmpleados);
                            obeManifiestosProveedores.Domicilio = datard[posDomicilio] == DBNull.Value ? "" : datard.GetString(posDomicilio);
                            obeManifiestosProveedores.CapitalContable = datard.GetDecimal(posCapitalContable);
                            obeManifiestosProveedores.IngresosUltimoAnnio = datard[posIngresosUltimoAnnio] == DBNull.Value ? 0 : datard.GetDecimal(posIngresosUltimoAnnio);
                            obeManifiestosProveedores.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeManifiestosProveedores.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeManifiestosProveedores;
            }
        }
        public List<beManifiestosProveedores> listarTodos_ManifiestosProveedores(SqlConnection Conexion)
        {
            string sp = "Proc_ManifiestosProveedores_Traer_Todos";
            List<beManifiestosProveedores> lbeManifiestosProveedores = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdManifiestoProveedor = datard.GetOrdinal("IdManifiestoProveedor");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int posAplicaCapitalContable = datard.GetOrdinal("AplicaCapitalContable");
                        int posInfraestructura = datard.GetOrdinal("Infraestructura");
                        int posAnnioExperiencia = datard.GetOrdinal("AnnioExperiencia");
                        int posNumeroEmpleados = datard.GetOrdinal("NumeroEmpleados");
                        int posDomicilio = datard.GetOrdinal("Domicilio");
                        int posCapitalContable = datard.GetOrdinal("CapitalContable");
                        int posIngresosUltimoAnnio = datard.GetOrdinal("IngresosUltimoAnnio");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        lbeManifiestosProveedores = new List<beManifiestosProveedores>();
                        beManifiestosProveedores obeManifiestosProveedores;
                        while (datard.Read())
                        {
                            obeManifiestosProveedores = new beManifiestosProveedores();
                            obeManifiestosProveedores.IdManifiestoProveedor = datard.GetInt32(posIdManifiestoProveedor);
                            obeManifiestosProveedores.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);
                            obeManifiestosProveedores.AplicaCapitalContable = datard.GetInt32(posAplicaCapitalContable);
                            obeManifiestosProveedores.Infraestructura = datard.GetString(posInfraestructura);
                            obeManifiestosProveedores.AnnioExperiencia = datard.GetInt32(posAnnioExperiencia);
                            obeManifiestosProveedores.NumeroEmpleados = datard.GetInt32(posNumeroEmpleados);
                            obeManifiestosProveedores.Domicilio = datard.GetString(posDomicilio);
                            obeManifiestosProveedores.CapitalContable = datard.GetDecimal(posCapitalContable);
                            obeManifiestosProveedores.IngresosUltimoAnnio = datard.GetDecimal(posIngresosUltimoAnnio);
                            obeManifiestosProveedores.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeManifiestosProveedores.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            lbeManifiestosProveedores.Add(obeManifiestosProveedores);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeManifiestosProveedores;
            }
        }
        public List<beManifiestosProveedores> listar_ManifiestosProveedores_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_ManifiestosProveedores_TraerTodos_GetAll";
            List<beManifiestosProveedores> lbeManifiestosProveedores = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdManifiestoProveedor = datard.GetOrdinal("IdManifiestoProveedor");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int posAplicaCapitalContable = datard.GetOrdinal("AplicaCapitalContable");
                        int posInfraestructura = datard.GetOrdinal("Infraestructura");
                        int posAnnioExperiencia = datard.GetOrdinal("AnnioExperiencia");
                        int posNumeroEmpleados = datard.GetOrdinal("NumeroEmpleados");
                        int posDomicilio = datard.GetOrdinal("Domicilio");
                        int posCapitalContable = datard.GetOrdinal("CapitalContable");
                        int posIngresosUltimoAnnio = datard.GetOrdinal("IngresosUltimoAnnio");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        lbeManifiestosProveedores = new List<beManifiestosProveedores>();
                        beManifiestosProveedores obeManifiestosProveedores;
                        while (datard.Read())
                        {
                            obeManifiestosProveedores = new beManifiestosProveedores();
                            obeManifiestosProveedores.IdManifiestoProveedor = datard.GetInt32(posIdManifiestoProveedor);
                            obeManifiestosProveedores.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);
                            obeManifiestosProveedores.AplicaCapitalContable = datard.GetInt32(posAplicaCapitalContable);
                            obeManifiestosProveedores.Infraestructura = datard.GetString(posInfraestructura);
                            obeManifiestosProveedores.AnnioExperiencia = datard.GetInt32(posAnnioExperiencia);
                            obeManifiestosProveedores.NumeroEmpleados = datard.GetInt32(posNumeroEmpleados);
                            obeManifiestosProveedores.Domicilio = datard.GetString(posDomicilio);
                            obeManifiestosProveedores.CapitalContable = datard.GetDecimal(posCapitalContable);
                            obeManifiestosProveedores.IngresosUltimoAnnio = datard.GetDecimal(posIngresosUltimoAnnio);
                            obeManifiestosProveedores.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeManifiestosProveedores.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            // debe agregar campos de la Vista
                            lbeManifiestosProveedores.Add(obeManifiestosProveedores);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeManifiestosProveedores;
            }
        }
        public beManifiestosProveedores traerManifiestoProveedore_x_IdProveedorRqInvitacion(SqlConnection Conexion, int pIdProveedorRqInvitacion)
        {
            string sp = "Proc_ManifiestosProveedores_x_IdProveedorRqInvitacion";
            beManifiestosProveedores obeManifiestosProveedores = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdProveedorRqInvitacion", SqlDbType.Int).Value = pIdProveedorRqInvitacion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdManifiestoProveedor = datard.GetOrdinal("IdManifiestoProveedor");
                        int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
                        int posAplicaCapitalContable = datard.GetOrdinal("AplicaCapitalContable");
                        int posInfraestructura = datard.GetOrdinal("Infraestructura");
                        int posAnnioExperiencia = datard.GetOrdinal("AnnioExperiencia");
                        int posNumeroEmpleados = datard.GetOrdinal("NumeroEmpleados");
                        int posDomicilio = datard.GetOrdinal("Domicilio");
                        int posCapitalContable = datard.GetOrdinal("CapitalContable");
                        int posIngresosUltimoAnnio = datard.GetOrdinal("IngresosUltimoAnnio");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        obeManifiestosProveedores = new beManifiestosProveedores();
                        while (datard.Read())
                        {
                            obeManifiestosProveedores.IdManifiestoProveedor = datard.GetInt32(posIdManifiestoProveedor);
                            obeManifiestosProveedores.IdProveedorRqInvitacion = datard.GetInt32(posIdProveedorRqInvitacion);
                            obeManifiestosProveedores.AplicaCapitalContable = datard.GetInt32(posAplicaCapitalContable);
                            obeManifiestosProveedores.Infraestructura = datard[posInfraestructura] ==DBNull.Value?"": datard.GetString(posInfraestructura);
                            obeManifiestosProveedores.AnnioExperiencia = datard.GetInt32(posAnnioExperiencia);
                            obeManifiestosProveedores.NumeroEmpleados = datard[posNumeroEmpleados] == DBNull.Value ? 0 : datard.GetInt32(posNumeroEmpleados);
                            obeManifiestosProveedores.Domicilio = datard[posDomicilio] == DBNull.Value ? "" :  datard.GetString(posDomicilio);
                            obeManifiestosProveedores.CapitalContable = datard.GetDecimal(posCapitalContable);
                            obeManifiestosProveedores.IngresosUltimoAnnio = datard[posIngresosUltimoAnnio] == DBNull.Value ? 0 : datard.GetDecimal(posIngresosUltimoAnnio);
                            obeManifiestosProveedores.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            obeManifiestosProveedores.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeManifiestosProveedores;
            }
        }
    }
}

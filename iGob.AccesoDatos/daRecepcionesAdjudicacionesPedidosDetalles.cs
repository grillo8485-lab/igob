using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daRecepcionesAdjudicacionesPedidosDetalles
    {
        public int guardarRecepcionesAdjudicacionesPedidosDetalles(SqlConnection Conexion, beRecepcionesAdjudicacionesPedidosDetalles obeRecepcionesAdjudicacionesPedidosDetalles)
        {
            int Id = 0;
            string sp = "Proc_RecepcionesAdjudicacionesPedidosDetallesInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdRecepcionAdjudicacionDetalle", SqlDbType.Int).Value = obeRecepcionesAdjudicacionesPedidosDetalles.IdRecepcionAdjudicacionDetalle;
                    cmd.Parameters.Add("@IdAdjudicacionPedidoDetalle", SqlDbType.Int).Value = obeRecepcionesAdjudicacionesPedidosDetalles.IdAdjudicacionPedidoDetalle;
                    cmd.Parameters.Add("@IdAdjCondicionEntregaDetalle", SqlDbType.Int).Value = obeRecepcionesAdjudicacionesPedidosDetalles.IdAdjCondicionEntregaDetalle;
                    cmd.Parameters.Add("@CantidadRecibida", SqlDbType.Decimal).Value = obeRecepcionesAdjudicacionesPedidosDetalles.CantidadRecibida;
                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = obeRecepcionesAdjudicacionesPedidosDetalles.Observaciones;
                    cmd.Parameters.Add("@IdLugarEntrega", SqlDbType.Int).Value = obeRecepcionesAdjudicacionesPedidosDetalles.IdLugarEntrega;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRecepcionesAdjudicacionesPedidosDetalles.FechaRegistro;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRecepcionesAdjudicacionesPedidosDetalles.IdUsuarioRegistro;

                    Id = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarRecepcionesAdjudicacionesPedidosDetalles(SqlConnection Conexion, beRecepcionesAdjudicacionesPedidosDetalles obeRecepcionesAdjudicacionesPedidosDetalles)
        {
            string sp = "Proc_RecepcionesAdjudicacionesPedidosDetallesActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdRecepcionAdjudicacionDetalle", SqlDbType.Int).Value = obeRecepcionesAdjudicacionesPedidosDetalles.IdRecepcionAdjudicacionDetalle;
                    cmd.Parameters.Add("@IdAdjudicacionPedidoDetalle", SqlDbType.Int).Value = obeRecepcionesAdjudicacionesPedidosDetalles.IdAdjudicacionPedidoDetalle;
                    cmd.Parameters.Add("@IdAdjCondicionEntregaDetalle", SqlDbType.Int).Value = obeRecepcionesAdjudicacionesPedidosDetalles.IdAdjCondicionEntregaDetalle;
                    cmd.Parameters.Add("@CantidadRecibida", SqlDbType.Decimal).Value = obeRecepcionesAdjudicacionesPedidosDetalles.CantidadRecibida;
                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = obeRecepcionesAdjudicacionesPedidosDetalles.Observaciones;
                    cmd.Parameters.Add("@IdLugarEntrega", SqlDbType.Int).Value = obeRecepcionesAdjudicacionesPedidosDetalles.IdLugarEntrega;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRecepcionesAdjudicacionesPedidosDetalles.FechaRegistro;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRecepcionesAdjudicacionesPedidosDetalles.IdUsuarioRegistro;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarRecepcionesAdjudicacionesPedidosDetalles(SqlConnection Conexion, int pIdRecepcionAdjudicacionDetalle)
        {
            string sp = "Proc_RecepcionesAdjudicacionesPedidosDetallesEliminar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdRecepcionAdjudicacionDetalle", SqlDbType.Int).Value = pIdRecepcionAdjudicacionDetalle;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
        public beRecepcionesAdjudicacionesPedidosDetalles traerRecepcionesAdjudicacionesPedidosDetalles_x_IdRecepcionAdjudicacionDetalle(SqlConnection Conexion, int IdRecepcionAdjudicacionDetalle)
        {
            string sp = "Proc_RecepcionesAdjudicacionesPedidosDetalles_x_IdRecepcionAdjudicacionDetalle";
            beRecepcionesAdjudicacionesPedidosDetalles obeRecepcionesAdjudicacionesPedidosDetalles = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRecepcionAdjudicacionDetalle", SqlDbType.Int).Value = IdRecepcionAdjudicacionDetalle;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRecepcionAdjudicacionDetalle = datard.GetOrdinal("IdRecepcionAdjudicacionDetalle");
                        int posIdAdjudicacionPedidoDetalle = datard.GetOrdinal("IdAdjudicacionPedidoDetalle");
                        int posIdAdjCondicionEntregaDetalle = datard.GetOrdinal("IdAdjCondicionEntregaDetalle");
                        int posCantidadRecibida = datard.GetOrdinal("CantidadRecibida");
                        int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posIdLugarEntrega = datard.GetOrdinal("IdLugarEntrega");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        obeRecepcionesAdjudicacionesPedidosDetalles = new beRecepcionesAdjudicacionesPedidosDetalles();
                        while (datard.Read())
                        {
                            obeRecepcionesAdjudicacionesPedidosDetalles.IdRecepcionAdjudicacionDetalle = datard.GetInt32(posIdRecepcionAdjudicacionDetalle);
                            obeRecepcionesAdjudicacionesPedidosDetalles.IdAdjudicacionPedidoDetalle = datard.GetInt32(posIdAdjudicacionPedidoDetalle);
                            obeRecepcionesAdjudicacionesPedidosDetalles.IdAdjCondicionEntregaDetalle = datard.GetInt32(posIdAdjCondicionEntregaDetalle);
                            obeRecepcionesAdjudicacionesPedidosDetalles.CantidadRecibida = datard.GetDecimal(posCantidadRecibida);
                            obeRecepcionesAdjudicacionesPedidosDetalles.Observaciones = datard.GetString(posObservaciones);
                            obeRecepcionesAdjudicacionesPedidosDetalles.IdLugarEntrega = datard.GetInt32(posIdLugarEntrega);
                            obeRecepcionesAdjudicacionesPedidosDetalles.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeRecepcionesAdjudicacionesPedidosDetalles.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRecepcionesAdjudicacionesPedidosDetalles;
            }
        }
        public List<beRecepcionesAdjudicacionesPedidosDetalles> listarTodos_RecepcionesAdjudicacionesPedidosDetalles(SqlConnection Conexion)
        {
            string sp = "Proc_RecepcionesAdjudicacionesPedidosDetalles_Traer_Todos";
            List<beRecepcionesAdjudicacionesPedidosDetalles> lbeRecepcionesAdjudicacionesPedidosDetalles = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRecepcionAdjudicacionDetalle = datard.GetOrdinal("IdRecepcionAdjudicacionDetalle");
                        int posIdAdjudicacionPedidoDetalle = datard.GetOrdinal("IdAdjudicacionPedidoDetalle");
                        int posIdAdjCondicionEntregaDetalle = datard.GetOrdinal("IdAdjCondicionEntregaDetalle");
                        int posCantidadRecibida = datard.GetOrdinal("CantidadRecibida");
                        int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posIdLugarEntrega = datard.GetOrdinal("IdLugarEntrega");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        lbeRecepcionesAdjudicacionesPedidosDetalles = new List<beRecepcionesAdjudicacionesPedidosDetalles>();
                        beRecepcionesAdjudicacionesPedidosDetalles obeRecepcionesAdjudicacionesPedidosDetalles;
                        while (datard.Read())
                        {
                            obeRecepcionesAdjudicacionesPedidosDetalles = new beRecepcionesAdjudicacionesPedidosDetalles();
                            obeRecepcionesAdjudicacionesPedidosDetalles.IdRecepcionAdjudicacionDetalle = datard.GetInt32(posIdRecepcionAdjudicacionDetalle);
                            obeRecepcionesAdjudicacionesPedidosDetalles.IdAdjudicacionPedidoDetalle = datard.GetInt32(posIdAdjudicacionPedidoDetalle);
                            obeRecepcionesAdjudicacionesPedidosDetalles.IdAdjCondicionEntregaDetalle = datard.GetInt32(posIdAdjCondicionEntregaDetalle);
                            obeRecepcionesAdjudicacionesPedidosDetalles.CantidadRecibida = datard.GetDecimal(posCantidadRecibida);
                            obeRecepcionesAdjudicacionesPedidosDetalles.Observaciones = datard.GetString(posObservaciones);
                            obeRecepcionesAdjudicacionesPedidosDetalles.IdLugarEntrega = datard.GetInt32(posIdLugarEntrega);
                            obeRecepcionesAdjudicacionesPedidosDetalles.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeRecepcionesAdjudicacionesPedidosDetalles.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            lbeRecepcionesAdjudicacionesPedidosDetalles.Add(obeRecepcionesAdjudicacionesPedidosDetalles);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRecepcionesAdjudicacionesPedidosDetalles;
            }
        }
        public List<beRecepcionesAdjudicacionesPedidosDetalles> listar_RecepcionesAdjudicacionesPedidosDetalles_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_RecepcionesAdjudicacionesPedidosDetalles_TraerTodos_GetAll";
            List<beRecepcionesAdjudicacionesPedidosDetalles> lbeRecepcionesAdjudicacionesPedidosDetalles = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRecepcionAdjudicacionDetalle = datard.GetOrdinal("IdRecepcionAdjudicacionDetalle");
                        int posIdAdjudicacionPedidoDetalle = datard.GetOrdinal("IdAdjudicacionPedidoDetalle");
                        int posIdAdjCondicionEntregaDetalle = datard.GetOrdinal("IdAdjCondicionEntregaDetalle");
                        int posCantidadRecibida = datard.GetOrdinal("CantidadRecibida");
                        int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posIdLugarEntrega = datard.GetOrdinal("IdLugarEntrega");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        lbeRecepcionesAdjudicacionesPedidosDetalles = new List<beRecepcionesAdjudicacionesPedidosDetalles>();
                        beRecepcionesAdjudicacionesPedidosDetalles obeRecepcionesAdjudicacionesPedidosDetalles;
                        while (datard.Read())
                        {
                            obeRecepcionesAdjudicacionesPedidosDetalles = new beRecepcionesAdjudicacionesPedidosDetalles();
                            obeRecepcionesAdjudicacionesPedidosDetalles.IdRecepcionAdjudicacionDetalle = datard.GetInt32(posIdRecepcionAdjudicacionDetalle);
                            obeRecepcionesAdjudicacionesPedidosDetalles.IdAdjudicacionPedidoDetalle = datard.GetInt32(posIdAdjudicacionPedidoDetalle);
                            obeRecepcionesAdjudicacionesPedidosDetalles.IdAdjCondicionEntregaDetalle = datard.GetInt32(posIdAdjCondicionEntregaDetalle);
                            obeRecepcionesAdjudicacionesPedidosDetalles.CantidadRecibida = datard.GetDecimal(posCantidadRecibida);
                            obeRecepcionesAdjudicacionesPedidosDetalles.Observaciones = datard.GetString(posObservaciones);
                            obeRecepcionesAdjudicacionesPedidosDetalles.IdLugarEntrega = datard.GetInt32(posIdLugarEntrega);
                            obeRecepcionesAdjudicacionesPedidosDetalles.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeRecepcionesAdjudicacionesPedidosDetalles.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            // debe agregar campos de la Vista
                            lbeRecepcionesAdjudicacionesPedidosDetalles.Add(obeRecepcionesAdjudicacionesPedidosDetalles);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRecepcionesAdjudicacionesPedidosDetalles;
            }
        }
    }
}

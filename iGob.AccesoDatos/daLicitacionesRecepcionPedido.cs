using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daLicitacionesRecepcionPedido
    {
        public beLicitacionesRecepcionPedido traerRecepcionPedido_x_IdRecepcion(SqlConnection Conexion, int IdRecepcion)
        {
            string sp = "Proc_Rep_RecepcionPedido_x_IdRecepcion";
            beLicitacionesRecepcionPedido obeLicitaciones = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRecepcion", SqlDbType.Int).Value = IdRecepcion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posFolio = datard.GetOrdinal("Folio");
                        int posNombreEncargado = datard.GetOrdinal("NombreEncargado");
                        int posFechaRecepcion = datard.GetOrdinal("FechaRecepcion");
                        int posFolioPedido = datard.GetOrdinal("FolioPedido");
                        int posTituloLicitacion = datard.GetOrdinal("TituloLicitacion");
                        int posPartida = datard.GetOrdinal("Partida");
                        int posLugarEntrega = datard.GetOrdinal("LugarEntrega");
                        int posRequisicionFolio = datard.GetOrdinal("RequisicionFolio");


                        obeLicitaciones = new beLicitacionesRecepcionPedido();
                        while (datard.Read())
                        {
                            obeLicitaciones.Dependencia = datard.GetString(posDependencia);
                            obeLicitaciones.Folio = datard.GetString(posFolio);
                            obeLicitaciones.NombreEncargado = datard.GetString(posNombreEncargado);
                            obeLicitaciones.FechaRecepcion = datard.GetDateTime(posFechaRecepcion);
                            obeLicitaciones.FolioPedido = datard.GetString(posFolioPedido);
                            obeLicitaciones.TituloLicitacion = datard.GetString(posTituloLicitacion);
                            obeLicitaciones.Partida = datard.GetString(posPartida);
                            obeLicitaciones.LugarEntrega = datard.GetString(posLugarEntrega);
                            obeLicitaciones.RequisicionFolio = datard.GetString(posRequisicionFolio);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeLicitaciones;
            }
        }

        public List<beLicitacionesRecepcionPedido> traerRecepcionesPedidosDetalles_x_IdRecepcion(SqlConnection Conexion, int IdRecepcion)
        {
            string sp = "Proc_Rep_RecepcionesPedidosDetalles_x_IdRecepcion";
            List<beLicitacionesRecepcionPedido> lbeLicitacionesDictamen = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRecepcion", SqlDbType.Int).Value = IdRecepcion;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posBienServicio = datard.GetOrdinal("BienServicio");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posCantidadRecibida = datard.GetOrdinal("CantidadRecibida");

                        lbeLicitacionesDictamen = new List<beLicitacionesRecepcionPedido>();
                        beLicitacionesRecepcionPedido obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesRecepcionPedido();

                            obeLicitaciones.BienServicio = datard.GetString(posBienServicio);
                            obeLicitaciones.Cantidad = datard.GetDecimal(posCantidad);
                            obeLicitaciones.CantidadRecibida = datard.GetDecimal(posCantidadRecibida);

                            lbeLicitacionesDictamen.Add(obeLicitaciones);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeLicitacionesDictamen;
            }
        }
    }
}

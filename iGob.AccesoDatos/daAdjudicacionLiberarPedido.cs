using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daAdjudicacionLiberarPedido
    {
        public List<beAdjudicacionLiberarPedido> ListadoLotesAdjudicacionesLiberarPedido(SqlConnection Conexion, int IdAdjudicacionPedido)
        {
            List<beAdjudicacionLiberarPedido> listadolotesliberarpedido = new List<beAdjudicacionLiberarPedido>();
            string sp = "Proc_AdjudicacionesPedidosLiberar_x_IdAdjudicacionPedido";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdAdjudicacionPedido", SqlDbType.Int).Value = IdAdjudicacionPedido;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdAdjudicacionPedido = datard.GetOrdinal("IdAdjudicacionPedido");
                        int posBienServicio = datard.GetOrdinal("BienServicio");
                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posUnidadMedida = datard.GetOrdinal("UnidadMedida");
                        int posPrecioUnitarioOfertado = datard.GetOrdinal("PrecioUnitarioOfertado");
                        int posImporteOfertado = datard.GetOrdinal("ImporteOfertado");
                        int posImpuestoImporte = datard.GetOrdinal("ImpuestoImporte");
                        int posTotalPeriodo = datard.GetOrdinal("TotalPeriodo");
                        int posLugar = datard.GetOrdinal("Lugar");
                        int posHorarioEntrega = datard.GetOrdinal("HorarioEntrega");
                        int posDiasEntrega = datard.GetOrdinal("DiasEntrega");

                        while (datard.Read())
                        {
                            beAdjudicacionLiberarPedido LotesPedido = new beAdjudicacionLiberarPedido();
                            LotesPedido.IdAdjudicacionPedido = datard.GetInt32(posIdAdjudicacionPedido);
                            LotesPedido.BienServicio = datard.GetString(posBienServicio);
                            LotesPedido.NoLote = datard.GetInt32(posNoLote);
                            LotesPedido.Cantidad = datard.GetDecimal(posCantidad);
                            LotesPedido.UnidadMedida = datard.GetString(posUnidadMedida);
                            LotesPedido.PrecioUnitarioOfertado = datard.GetDecimal(posPrecioUnitarioOfertado);
                            LotesPedido.ImporteOfertado = datard.GetDecimal(posImporteOfertado);
                            LotesPedido.ImpuestoImporte = datard.GetDecimal(posImpuestoImporte);
                            LotesPedido.TotalPeriodo = datard.GetDecimal(posTotalPeriodo);
                            LotesPedido.Lugar = datard.GetString(posLugar);
                            LotesPedido.HorarioEntrega = datard.GetString(posHorarioEntrega);
                            LotesPedido.DiasEntrega = datard.GetString(posDiasEntrega);
                            listadolotesliberarpedido.Add(LotesPedido);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listadolotesliberarpedido;
            }
        }

        public List<beAdjudicacionLiberarPedido> ListadoAdjudicacionPedidoEntrega(SqlConnection Conexion, int IdPedido)
        {
            List<beAdjudicacionLiberarPedido> listadolotesliberarpedido = new List<beAdjudicacionLiberarPedido>();
            string sp = "Proc_RecepcionAdjudicacionesPedidosDetalles_x_IdPedido";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = IdPedido;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdAdjudicacionPedidoDetalle = datard.GetOrdinal("IdAdjudicacionPedidoDetalle");
                        int posIdAdjudicacionPedido = datard.GetOrdinal("IdAdjudicacionPedido");
                        int posFolio = datard.GetOrdinal("Folio");
                        int posFolioNumero = datard.GetOrdinal("FolioNumero");
                        int posIdEstatusPedido = datard.GetOrdinal("IdEstatusPedido");
                        int posIdLote = datard.GetOrdinal("IdLote");
                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posCantidadRecepcionar = datard.GetOrdinal("CantidadRecepcionar");
                        int posBienServicio = datard.GetOrdinal("BienServicio");
                        int posUnidadMedida = datard.GetOrdinal("UnidadMedida");
                        int posIdLugarEntrega = datard.GetOrdinal("IdLugarEntrega");
                        int posLugarEntrega = datard.GetOrdinal("LugarEntrega");
                        int posCantidadxRecibir = datard.GetOrdinal("CantidadxRecibir");
                        int posIdAdCondicionEntregaDetalle = datard.GetOrdinal("IdAdCondicionEntregaDetalle");

                        while (datard.Read())
                        {
                            beAdjudicacionLiberarPedido LotesPedido = new beAdjudicacionLiberarPedido();
                            LotesPedido.IdAdjudicacionPedido = datard.GetInt32(posIdAdjudicacionPedido);
                            LotesPedido.BienServicio = datard.GetString(posBienServicio);
                            LotesPedido.NoLote = datard.GetInt32(posNoLote);
                            LotesPedido.Cantidad = datard.GetDecimal(posCantidad);
                            LotesPedido.UnidadMedida = datard.GetString(posUnidadMedida);
                            LotesPedido.Folio = datard.GetString(posFolio);
                            LotesPedido.FolioNumero = datard.GetInt32(posFolioNumero);
                            LotesPedido.IdEstatusPedido = datard.GetInt32(posIdEstatusPedido);
                            LotesPedido.IdLote = datard.GetInt32(posIdLote);
                            LotesPedido.LugarEntrega = datard.GetString(posLugarEntrega);
                            LotesPedido.CantidadxRecibir = datard.GetDecimal(posCantidadxRecibir);
                            LotesPedido.IdLugarEntrega = datard.GetInt32(posIdLugarEntrega);
                            LotesPedido.IdAdjudicacionPedidoDetalle = datard.GetInt32(posIdAdjudicacionPedidoDetalle);
                            LotesPedido.CantidadRecepcionar = datard.GetDecimal(posCantidadRecepcionar);
                            LotesPedido.IdAdCondicionEntregaDetalle = datard.GetInt32(posIdAdCondicionEntregaDetalle);
                            listadolotesliberarpedido.Add(LotesPedido);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listadolotesliberarpedido;
            }
        }

        public List<beAdjudicacionLiberarPedido> ListadoAdjudicacionPedidoDetalle(SqlConnection Conexion, int IdPedido)
        {
            List<beAdjudicacionLiberarPedido> listadolotesliberarpedido = new List<beAdjudicacionLiberarPedido>();
            string sp = "Proc_AdjudicacionesPedidosRecepcionados_x_IdPedido";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = IdPedido;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdAdjudicacionPedidoDetalle = datard.GetOrdinal("IdAdjudicacionPedidoDetalle");
                        int posIdAdjudicacionPedido = datard.GetOrdinal("IdAdjudicacionPedido");
                        int posFolio = datard.GetOrdinal("Folio");
                        int posFolioNumero = datard.GetOrdinal("FolioNumero");
                        int posIdEstatusPedido = datard.GetOrdinal("IdEstatusPedido");
                        int posIdLote = datard.GetOrdinal("IdLote");
                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posCantidadRecepcionar = datard.GetOrdinal("CantidadRecepcionar");
                        int posBienServicio = datard.GetOrdinal("BienServicio");
                        int posUnidadMedida = datard.GetOrdinal("UnidadMedida");
                        int posIdLugarEntrega = datard.GetOrdinal("IdLugarEntrega");
                        int posLugarEntrega = datard.GetOrdinal("LugarEntrega");
                        int posIdAdCondicionEntregaDetalle = datard.GetOrdinal("IdAdCondicionEntregaDetalle");
                        int posNombreResponsable = datard.GetOrdinal("NombreResponsable");
                        int posCantidadRecibida = datard.GetOrdinal("CantidadRecibida");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posIdLugarEntregado = datard.GetOrdinal("IdLugarEntregado");
                        int posLugarEntregado = datard.GetOrdinal("LugarEntregado");
                        int posObservaciones = datard.GetOrdinal("Observaciones");

                        while (datard.Read())
                        {
                            beAdjudicacionLiberarPedido LotesPedido = new beAdjudicacionLiberarPedido();
                            LotesPedido.IdAdjudicacionPedido = datard.GetInt32(posIdAdjudicacionPedido);
                            LotesPedido.BienServicio = datard.GetString(posBienServicio);
                            LotesPedido.NoLote = datard.GetInt32(posNoLote);
                            LotesPedido.Cantidad = datard.GetDecimal(posCantidad);
                            LotesPedido.UnidadMedida = datard.GetString(posUnidadMedida);
                            LotesPedido.Folio = datard.GetString(posFolio);
                            LotesPedido.FolioNumero = datard.GetInt32(posFolioNumero);
                            LotesPedido.IdEstatusPedido = datard.GetInt32(posIdEstatusPedido);
                            LotesPedido.IdLote = datard.GetInt32(posIdLote);
                            LotesPedido.LugarEntrega = datard.GetString(posLugarEntrega);
                            LotesPedido.IdLugarEntrega = datard.GetInt32(posIdLugarEntrega);
                            LotesPedido.IdAdjudicacionPedidoDetalle = datard.GetInt32(posIdAdjudicacionPedidoDetalle);
                            LotesPedido.CantidadRecepcionar = datard.GetDecimal(posCantidadRecepcionar);
                            LotesPedido.IdAdCondicionEntregaDetalle = datard.GetInt32(posIdAdCondicionEntregaDetalle);
                            LotesPedido.NombreResponsable = datard.GetString(posNombreResponsable);
                            LotesPedido.CantidadRecibida = datard.GetDecimal(posCantidadRecibida);
                            LotesPedido.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            LotesPedido.IdLugarEntregado = datard.GetInt32(posIdLugarEntregado);
                            LotesPedido.LugarEntregado = datard.GetString(posLugarEntregado);
                            LotesPedido.Observaciones = datard.GetString(posObservaciones);
                            listadolotesliberarpedido.Add(LotesPedido);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listadolotesliberarpedido;
            }
        }

        public int GenerarPedidosAdjudicaciones_x_IdAdjudicacion(SqlConnection Conexion, int IdAdjudicacion)
        {
            string sp = "Proc_GenerarPedidosADjudicaciones_x_IdAdjudicacion";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = IdAdjudicacion;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }

        }


    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daRepRecepcionPedidos
    {
        public beRepRecepcionPedidos traerRep_RecepcionPedidos_x_IdPedido(SqlConnection Conexion, int IdPedido)
        {
            string sp = "Proc_Rep_RecepcionPedidos_x_IdPedido";
            beRepRecepcionPedidos obeLicitaciones = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = IdPedido;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdPedido = datard.GetOrdinal("IdPedido");
                        int posFolio = datard.GetOrdinal("Folio");
                        int posFolioNumero = datard.GetOrdinal("FolioNumero");
                        int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int posRequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int posFechaPedido = datard.GetOrdinal("FechaPedido");
                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posPartida = datard.GetOrdinal("Partida");
                        int posEstatusPedido = datard.GetOrdinal("EstatusPedido");
                        int posRazonSocial = datard.GetOrdinal("RazonSocial");
                        int posModalidadLicitacion = datard.GetOrdinal("ModalidadLicitacion");


                        obeLicitaciones = new beRepRecepcionPedidos();
                        while (datard.Read())
                        {
                            obeLicitaciones.IdPedido = datard.GetInt32(posIdPedido);
                            obeLicitaciones.Folio = datard.GetString(posFolio);
                            obeLicitaciones.FolioNumero = datard.GetInt32(posFolioNumero);
                            obeLicitaciones.IdRequisicion = datard.GetInt32(posIdRequisicion);
                            obeLicitaciones.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            obeLicitaciones.FechaPedido = datard.GetDateTime(posFechaPedido);
                            obeLicitaciones.Dependencia = datard.GetString(posDependencia);
                            obeLicitaciones.Partida = datard.GetString(posPartida);
                            obeLicitaciones.EstatusPedido = datard.GetString(posEstatusPedido);
                            obeLicitaciones.RazonSocial = datard.GetString(posRazonSocial);
                            obeLicitaciones.ModalidadLicitacion = datard.GetString(posModalidadLicitacion);

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

        public List<beRepRecepcionPedidos> traerRep_RecepcionPedidosDetalles_x_IdPedido(SqlConnection Conexion, int IdPedido)
        {
            string sp = "Proc_Rep_RecepcionPedidosDetalles_x_IdPedido";
            List<beRepRecepcionPedidos> lbeRecepcion = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = IdPedido;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdPedido = datard.GetOrdinal("IdPedido");
                        int posFolio = datard.GetOrdinal("Folio");
                        int posFolioNumero = datard.GetOrdinal("FolioNumero");
                        int posIdEstatusPedido = datard.GetOrdinal("IdEstatusPedido");
                        int posIdLote = datard.GetOrdinal("IdLote");
                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posBienServicio = datard.GetOrdinal("BienServicio");
                        int posUnidadMedida = datard.GetOrdinal("UnidadMedida");
                        int posIdRecepcionDetalle = datard.GetOrdinal("IdRecepcionDetalle");
                        int posCantidadRecibida = datard.GetOrdinal("CantidadRecibida");
                        int posLugarEntrega = datard.GetOrdinal("LugarEntrega");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posNombreResponsable = datard.GetOrdinal("NombreResponsable");
                        int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posCantidadxRecibir = datard.GetOrdinal("CantidadxRecibir");


                        lbeRecepcion = new List<beRepRecepcionPedidos>();
                        beRepRecepcionPedidos obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beRepRecepcionPedidos();

                            obeLicitaciones.IdPedido = datard.GetInt32(posIdPedido);
                            obeLicitaciones.Folio = datard.GetString(posFolio);
                            obeLicitaciones.FolioNumero = datard.GetInt32(posFolioNumero);
                            obeLicitaciones.IdEstatusPedido = datard.GetInt32(posIdEstatusPedido);
                            obeLicitaciones.IdLote = datard.GetInt32(posIdLote);
                            obeLicitaciones.NoLote = datard.GetInt32(posNoLote);
                            obeLicitaciones.Cantidad = datard.GetDecimal(posCantidad);
                            obeLicitaciones.BienServicio = datard.GetString(posBienServicio);
                            obeLicitaciones.UnidadMedida = datard.GetString(posUnidadMedida);
                            obeLicitaciones.IdRecepcionDetalle = datard.GetInt32(posIdRecepcionDetalle);
                            obeLicitaciones.CantidadRecibida = datard.GetDecimal(posCantidadRecibida);
                            obeLicitaciones.LugarEntrega = datard.GetString(posLugarEntrega);
                            obeLicitaciones.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeLicitaciones.NombreResponsable = datard.GetString(posNombreResponsable);
                            obeLicitaciones.Observaciones = datard.GetString(posObservaciones);
                            obeLicitaciones.CantidadxRecibir = datard.GetDecimal(posCantidadxRecibir);

                            lbeRecepcion.Add(obeLicitaciones);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRecepcion;
            }
        }
    }
}

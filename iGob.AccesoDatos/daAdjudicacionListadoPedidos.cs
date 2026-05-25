using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daAdjudicacionListadoPedidos
    {
        public List<beAdjudicacionListadoPedidos> ListadoAdjudicacionesLotesPedidos(SqlConnection Conexion,int IdDependencia)// int IdAdjudicacion,
        {
            List<beAdjudicacionListadoPedidos> listadoAdjudicacionesLotesPedidos = new List<beAdjudicacionListadoPedidos>();
            string sp = "Proc_AdjudicacionesLiberarPedidos_IdAdjudicacionDependencia";
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = IdAdjudicacion;
            cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = IdDependencia;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posAdjudicacionFolio = datard.GetOrdinal("AdjudicacionFolio");
                        int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
                        int posFolio = datard.GetOrdinal("Folio");
                        int posFolioNumero = datard.GetOrdinal("FolioNumero");
                        int posFechaPedido = datard.GetOrdinal("FechaPedido");
                        int posEjercicio = datard.GetOrdinal("Ejercicio");
                        int posFechaAutorizacion = datard.GetOrdinal("FechaAutorizacion");
                        int posTipoAdjudicacion = datard.GetOrdinal("TipoAdjudicacion");
                        int posEstatus = datard.GetOrdinal("Estatus");
                        int posIdEstatusAdjudicacion = datard.GetOrdinal("IdEstatusAdjudicacion");
                        int posRazonSocial = datard.GetOrdinal("RazonSocial");
                        int posPartida = datard.GetOrdinal("Partida");

                        while (datard.Read())
                        {
                            beAdjudicacionListadoPedidos LotesPedido = new beAdjudicacionListadoPedidos();
                            LotesPedido.AdjudicacionFolio = datard.GetString(posAdjudicacionFolio);
                            LotesPedido.IdAdjudicacion = datard.GetInt32(posIdAdjudicacion);
                            LotesPedido.Folio = datard.GetString(posFolio);
                            LotesPedido.FolioNumero = datard.GetInt32(posFolioNumero);
                            LotesPedido.FechaPedido = datard.GetDateTime(posFechaPedido);
                            LotesPedido.Ejercicio = datard.GetInt32(posEjercicio);
                            LotesPedido.FechaAutorizacion = datard.GetDateTime(posFechaAutorizacion);
                            LotesPedido.TipoAdjudicacion = datard.GetString(posTipoAdjudicacion);
                            LotesPedido.Estatus = datard.GetString(posEstatus);
                            LotesPedido.IdEstatusAdjudicacion = datard.GetInt32(posIdEstatusAdjudicacion);
                            LotesPedido.RazonSocial = datard.GetString(posRazonSocial);
                            LotesPedido.Partida = datard.GetString(posPartida);
                            listadoAdjudicacionesLotesPedidos.Add(LotesPedido);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listadoAdjudicacionesLotesPedidos;
            }
        }
    }
}

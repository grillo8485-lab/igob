using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daRepAdjudicacionPedido
    {
        public beRepAdjudicacionPedido traerRep_AdjudicacionPedido_x_IdAdjudicacionPedido(SqlConnection Conexion, int IdAdjudicacionPedido)
        {
            string sp = "Proc_Rep_AdjudicacionPedido_x_IdAdjudicacionPedido";
            beRepAdjudicacionPedido obeLicitaciones = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdAdjudicacionPedido", SqlDbType.Int).Value = IdAdjudicacionPedido;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posFolio = datard.GetOrdinal("Folio");
                        int posAdjudicacionFolio = datard.GetOrdinal("AdjudicacionFolio");
                        int posPartida = datard.GetOrdinal("Partida");
                        int posRazonSocial = datard.GetOrdinal("RazonSocial");
                        int posRfc = datard.GetOrdinal("Rfc");
                        int posCalle = datard.GetOrdinal("Calle");
                        int posNoExterior = datard.GetOrdinal("NoExterior");
                        int posNoInterior = datard.GetOrdinal("NoInterior");
                        int posColonia = datard.GetOrdinal("Colonia");
                        int posCodigoPostal = datard.GetOrdinal("CodigoPostal");
                        int posEmail = datard.GetOrdinal("Email");
                        int posPais = datard.GetOrdinal("Pais");
                        int posEstado = datard.GetOrdinal("Estado");
                        int posMunicipio = datard.GetOrdinal("Municipio");
                        int posFechaLimite = datard.GetOrdinal("FechaLimite");
                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posTipoEntrega = datard.GetOrdinal("TipoEntrega");
                        int posPlazoPagoCantidad = datard.GetOrdinal("PlazoPagoCantidad");
                        int posPlazozTiempoPago = datard.GetOrdinal("PlazozTiempoPago");
                        int posTipoDiaPago = datard.GetOrdinal("TipoDiaPago");
                        int posCondicion = datard.GetOrdinal("Condicion");
                        int posPlazoEntregaCantidad = datard.GetOrdinal("PlazoEntregaCantidad");
                        int posPlazozTiempoEntrega = datard.GetOrdinal("PlazozTiempoEntrega");
                        int posTipoDiaEntrega = datard.GetOrdinal("TipoDiaEntrega");
                        int posPlazoEntrega = datard.GetOrdinal("PlazoEntrega");


                        obeLicitaciones = new beRepAdjudicacionPedido();
                        while (datard.Read())
                        {
                            obeLicitaciones.Folio = datard.GetString(posFolio);
                            obeLicitaciones.AdjudicacionFolio = datard.GetString(posAdjudicacionFolio);
                            obeLicitaciones.Partida = datard.GetString(posPartida);
                            obeLicitaciones.RazonSocial = datard.GetString(posRazonSocial);
                            obeLicitaciones.Rfc = datard.GetString(posRfc);
                            obeLicitaciones.Calle = datard.GetString(posCalle);
                            obeLicitaciones.NoExterior = datard.GetString(posNoExterior);
                            obeLicitaciones.NoInterior = datard.GetString(posNoInterior);
                            obeLicitaciones.Colonia = datard.GetString(posColonia);
                            obeLicitaciones.CodigoPostal = datard.GetString(posCodigoPostal);
                            obeLicitaciones.Email = datard.GetString(posEmail);
                            obeLicitaciones.Pais = datard.GetString(posPais);
                            obeLicitaciones.Estado = datard.GetString(posEstado);
                            obeLicitaciones.Municipio = datard.GetString(posMunicipio);
                            obeLicitaciones.FechaLimite = datard.GetDateTime(posFechaLimite);
                            obeLicitaciones.Dependencia = datard.GetString(posDependencia);
                            obeLicitaciones.TipoEntrega = datard.GetString(posTipoEntrega);
                            obeLicitaciones.PlazoPagoCantidad = datard.GetInt32(posPlazoPagoCantidad);
                            obeLicitaciones.PlazozTiempoPago = datard.GetString(posPlazozTiempoPago);
                            obeLicitaciones.TipoDiaPago = datard.GetString(posTipoDiaPago);
                            obeLicitaciones.Condicion = datard.GetString(posCondicion);
                            obeLicitaciones.PlazoEntregaCantidad = datard.GetInt32(posPlazoEntregaCantidad);
                            obeLicitaciones.PlazozTiempoEntrega = datard.GetString(posPlazozTiempoEntrega);
                            obeLicitaciones.TipoDiaEntrega = datard.GetString(posTipoDiaEntrega);
                            obeLicitaciones.PlazoEntrega = datard.GetString(posPlazoEntrega);

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

        public List<beRepAdjudicacionPedido> traerRep_AdjudicacionPedidoDetalles_x_IdAdjudicacionPedido(SqlConnection Conexion, int IdAdjudicacionPedido)
        {
            string sp = "Proc_Rep_AdjudicacionPedidoDetalles_x_IdAdjudicacionPedido";
            List<beRepAdjudicacionPedido> lbePedido = null;
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


                        lbePedido = new List<beRepAdjudicacionPedido>();
                        beRepAdjudicacionPedido obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beRepAdjudicacionPedido();

                            obeLicitaciones.IdAdjudicacionPedido = datard.GetInt32(posIdAdjudicacionPedido);
                            obeLicitaciones.BienServicio = datard.GetString(posBienServicio);
                            obeLicitaciones.NoLote = datard.GetInt32(posNoLote);
                            obeLicitaciones.Cantidad = datard.GetDecimal(posCantidad);
                            obeLicitaciones.UnidadMedida = datard.GetString(posUnidadMedida);
                            obeLicitaciones.PrecioUnitarioOfertado = datard.GetDecimal(posPrecioUnitarioOfertado);
                            obeLicitaciones.ImporteOfertado = datard.GetDecimal(posImporteOfertado);
                            obeLicitaciones.ImpuestoImporte = datard.GetDecimal(posImpuestoImporte);
                            obeLicitaciones.TotalPeriodo = datard.GetDecimal(posTotalPeriodo);
                            obeLicitaciones.Lugar = datard.GetString(posLugar);
                            obeLicitaciones.HorarioEntrega = datard.GetString(posHorarioEntrega);
                            obeLicitaciones.DiasEntrega = datard.GetString(posDiasEntrega);

                            lbePedido.Add(obeLicitaciones);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbePedido;
            }
        }
    }
}

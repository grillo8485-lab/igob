using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daLicitacionesPedido
    {
        public beLicitacionesPedido traerPedido_x_IdPedido(SqlConnection Conexion, int IdPedido)
        {
            string sp = "Proc_Rep_Pedido_x_IdPedido";
            beLicitacionesPedido obeLicitaciones = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = IdPedido;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posFolio = datard.GetOrdinal("Folio");
                        int posFechaPedido = datard.GetOrdinal("FechaPedido");
                        int posRequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int posPartida = datard.GetOrdinal("Partida");
                        int posRazonSocial = datard.GetOrdinal("RazonSocial");
                        int posRfc = datard.GetOrdinal("Rfc");
                        int posCalle = datard.GetOrdinal("Calle");
                        int posNoExterior = datard.GetOrdinal("NoExterior");
                        int posNoInterior = datard.GetOrdinal("NoInterior");
                        int posColonia = datard.GetOrdinal("Colonia");
                        int posPais = datard.GetOrdinal("Pais");
                        int posEstado = datard.GetOrdinal("Estado");
                        int posMunicipio = datard.GetOrdinal("Municipio");
                        int posCodigoPostal = datard.GetOrdinal("CodigoPostal");
                        int posEmail = datard.GetOrdinal("Email");
                        int posDependencia = datard.GetOrdinal("Dependencia");
                        int posTipoCondicionPago = datard.GetOrdinal("TipoCondicionPago");
                        int posPlazoEntrega = datard.GetOrdinal("PlazoEntrega");
                        int posTipoEntrega = datard.GetOrdinal("TipoEntrega");
                        int posTitulo = datard.GetOrdinal("Titulo");


                        obeLicitaciones = new beLicitacionesPedido();
                        while (datard.Read())
                        {
                            obeLicitaciones.Folio = datard.GetString(posFolio);
                            obeLicitaciones.FechaPedido = datard.GetDateTime(posFechaPedido);
                            obeLicitaciones.RequisicionFolio = datard.GetString(posRequisicionFolio);
                            obeLicitaciones.Partida = datard.GetString(posPartida);
                            obeLicitaciones.RazonSocial = datard.GetString(posRazonSocial);
                            obeLicitaciones.Rfc = datard.GetString(posRfc);
                            obeLicitaciones.Calle = datard.GetString(posCalle);
                            obeLicitaciones.NoExterior = datard.GetString(posNoExterior);
                            obeLicitaciones.NoInterior = datard.GetString(posNoInterior);
                            obeLicitaciones.Colonia = datard.GetString(posColonia);
                            obeLicitaciones.Pais = datard.GetString(posPais);
                            obeLicitaciones.Estado = datard.GetString(posEstado);
                            obeLicitaciones.Municipio = datard.GetString(posMunicipio);
                            obeLicitaciones.CodigoPostal = datard.GetString(posCodigoPostal);
                            obeLicitaciones.Email = datard.GetString(posEmail);
                            obeLicitaciones.Dependencia = datard.GetString(posDependencia);
                            obeLicitaciones.TipoCondicionPago = datard.GetString(posTipoCondicionPago);
                            obeLicitaciones.PlazoEntrega = datard.GetString(posPlazoEntrega);
                            obeLicitaciones.TipoEntrega = datard.GetString(posTipoEntrega);
                            obeLicitaciones.Titulo = datard.GetString(posTitulo);
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

        public List<beLicitacionesPedido> traerPedidoDetalles_x_IdPedido(SqlConnection Conexion, int IdPedido)
        {
            string sp = "Proc_Rep_PedidoDetalles_x_IdPedido";
            List<beLicitacionesPedido> lbeLicitacionesDictamen = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = IdPedido;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posNoLote = datard.GetOrdinal("NoLote");
                        int posBienServicio = datard.GetOrdinal("BienServicio");
                        int posCantidad = datard.GetOrdinal("Cantidad");
                        int posUnidadMedida = datard.GetOrdinal("UnidadMedida");
                        int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int posImporte = datard.GetOrdinal("Importe");
                        int posImporteIva = datard.GetOrdinal("ImporteIva");
                        int posLugar = datard.GetOrdinal("Lugar");
                        int posHorarioEntrega = datard.GetOrdinal("HorarioEntrega");
                        int posDiasEntrega = datard.GetOrdinal("DiasEntrega");

                        lbeLicitacionesDictamen = new List<beLicitacionesPedido>();
                        beLicitacionesPedido obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesPedido();

                            obeLicitaciones.NoLote = datard.GetInt32(posNoLote);
                            obeLicitaciones.BienServicio = datard.GetString(posBienServicio);
                            obeLicitaciones.Cantidad = datard.GetDecimal(posCantidad);
                            obeLicitaciones.UnidadMedida = datard.GetString(posUnidadMedida);
                            obeLicitaciones.PrecioUnitario = datard.GetDecimal(posPrecioUnitario);
                            obeLicitaciones.Importe = datard.GetDecimal(posImporte);
                            obeLicitaciones.ImporteIva = datard.GetDecimal(posImporteIva);
                            obeLicitaciones.Lugar = datard.GetString(posLugar);
                            obeLicitaciones.HorarioEntrega = datard.GetString(posHorarioEntrega);
                            obeLicitaciones.DiasEntrega = datard.GetString(posDiasEntrega);

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

        public List<beLicitacionesPedido> traerPedido_Manifiestos_x_IdPedido(SqlConnection Conexion, int IdPedido)
        {
            string sp = "Proc_Rep_Pedido_Manifiestos_x_IdPedido";
            List<beLicitacionesPedido> lbeLicitacionesDictamen = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = IdPedido;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posManifiesto = datard.GetOrdinal("Manifiesto");

                        lbeLicitacionesDictamen = new List<beLicitacionesPedido>();
                        beLicitacionesPedido obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesPedido();

                            obeLicitaciones.Manifiesto = datard.GetString(posManifiesto);

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

        public List<beLicitacionesPedido> traerPedido_Firmantes_x_IdPedido(SqlConnection Conexion, int IdPedido)
        {
            string sp = "Proc_Rep_Pedido_Firmantes_x_IdPedido";
            List<beLicitacionesPedido> lbeLicitacionesDictamen = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = IdPedido;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posCargo = datard.GetOrdinal("Cargo");
                        int posNombre = datard.GetOrdinal("Nombre");

                        lbeLicitacionesDictamen = new List<beLicitacionesPedido>();
                        beLicitacionesPedido obeLicitaciones;
                        while (datard.Read())
                        {
                            obeLicitaciones = new beLicitacionesPedido();

                            obeLicitaciones.Cargo = datard.GetString(posCargo);
                            obeLicitaciones.Nombre = datard.GetString(posNombre);

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

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daManifiestoProveedoresDeclaratorias
    {
        public int guardarManifiestoProveedoresDeclaratorias(SqlConnection Conexion, beManifiestoProveedoresDeclaratorias obeManifiestoProveedoresDeclaratorias)
        {
            int Id = 0;
            string sp = "Proc_ManifiestoProveedoresDeclaratoriasInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdManifiestoProveedorDeclaratoria", SqlDbType.Int).Value = obeManifiestoProveedoresDeclaratorias.IdManifiestoProveedorDeclaratoria;
                    cmd.Parameters.Add("@IdManifiestoProveedor", SqlDbType.Int).Value = obeManifiestoProveedoresDeclaratorias.IdManifiestoProveedor;
                    cmd.Parameters.Add("@IdManifiesto", SqlDbType.Int).Value = obeManifiestoProveedoresDeclaratorias.IdManifiesto;
                    cmd.Parameters.Add("@Aceptacion", SqlDbType.Bit).Value = obeManifiestoProveedoresDeclaratorias.Aceptacion;

                    Id = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarManifiestoProveedoresDeclaratorias(SqlConnection Conexion, beManifiestoProveedoresDeclaratorias obeManifiestoProveedoresDeclaratorias)
        {
            string sp = "Proc_ManifiestoProveedoresDeclaratoriasActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdManifiestoProveedorDeclaratoria", SqlDbType.Int).Value = obeManifiestoProveedoresDeclaratorias.IdManifiestoProveedorDeclaratoria;
                    cmd.Parameters.Add("@IdManifiestoProveedor", SqlDbType.Int).Value = obeManifiestoProveedoresDeclaratorias.IdManifiestoProveedor;
                    cmd.Parameters.Add("@IdManifiesto", SqlDbType.Int).Value = obeManifiestoProveedoresDeclaratorias.IdManifiesto;
                    cmd.Parameters.Add("@Aceptacion", SqlDbType.Bit).Value = obeManifiestoProveedoresDeclaratorias.Aceptacion;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarManifiestoProveedoresDeclaratorias(SqlConnection Conexion, int pIdManifiestoProveedorDeclaratoria)
        {
            string sp = "Proc_ManifiestoProveedoresDeclaratoriasEliminar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdManifiestoProveedorDeclaratoria", SqlDbType.Int).Value = pIdManifiestoProveedorDeclaratoria;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
        public beManifiestoProveedoresDeclaratorias traerManifiestoProveedoresDeclaratorias_x_IdManifiestoProveedorDeclaratoria(SqlConnection Conexion, int IdManifiestoProveedorDeclaratoria)
        {
            string sp = "Proc_ManifiestoProveedoresDeclaratorias_x_IdManifiestoProveedorDeclaratoria";
            beManifiestoProveedoresDeclaratorias obeManifiestoProveedoresDeclaratorias = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdManifiestoProveedorDeclaratoria", SqlDbType.Int).Value = IdManifiestoProveedorDeclaratoria;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdManifiestoProveedorDeclaratoria = datard.GetOrdinal("IdManifiestoProveedorDeclaratoria");
                        int posIdManifiestoProveedor = datard.GetOrdinal("IdManifiestoProveedor");
                        int posIdManifiesto = datard.GetOrdinal("IdManifiesto");
                        int posAceptacion = datard.GetOrdinal("Aceptacion");
                        obeManifiestoProveedoresDeclaratorias = new beManifiestoProveedoresDeclaratorias();
                        while (datard.Read())
                        {
                            obeManifiestoProveedoresDeclaratorias.IdManifiestoProveedorDeclaratoria = datard.GetInt32(posIdManifiestoProveedorDeclaratoria);
                            obeManifiestoProveedoresDeclaratorias.IdManifiestoProveedor = datard.GetInt32(posIdManifiestoProveedor);
                            obeManifiestoProveedoresDeclaratorias.IdManifiesto = datard.GetInt32(posIdManifiesto);
                            obeManifiestoProveedoresDeclaratorias.Aceptacion = datard.GetBoolean(posAceptacion);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeManifiestoProveedoresDeclaratorias;
            }
        }
        public List<beManifiestoProveedoresDeclaratorias> listarTodos_ManifiestoProveedoresDeclaratorias(SqlConnection Conexion)
        {
            string sp = "Proc_ManifiestoProveedoresDeclaratorias_Traer_Todos";
            List<beManifiestoProveedoresDeclaratorias> lbeManifiestoProveedoresDeclaratorias = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdManifiestoProveedorDeclaratoria = datard.GetOrdinal("IdManifiestoProveedorDeclaratoria");
                        int posIdManifiestoProveedor = datard.GetOrdinal("IdManifiestoProveedor");
                        int posIdManifiesto = datard.GetOrdinal("IdManifiesto");
                        int posAceptacion = datard.GetOrdinal("Aceptacion");
                        lbeManifiestoProveedoresDeclaratorias = new List<beManifiestoProveedoresDeclaratorias>();
                        beManifiestoProveedoresDeclaratorias obeManifiestoProveedoresDeclaratorias;
                        while (datard.Read())
                        {
                            obeManifiestoProveedoresDeclaratorias = new beManifiestoProveedoresDeclaratorias();
                            obeManifiestoProveedoresDeclaratorias.IdManifiestoProveedorDeclaratoria = datard.GetInt32(posIdManifiestoProveedorDeclaratoria);
                            obeManifiestoProveedoresDeclaratorias.IdManifiestoProveedor = datard.GetInt32(posIdManifiestoProveedor);
                            obeManifiestoProveedoresDeclaratorias.IdManifiesto = datard.GetInt32(posIdManifiesto);
                            obeManifiestoProveedoresDeclaratorias.Aceptacion = datard.GetBoolean(posAceptacion);
                            lbeManifiestoProveedoresDeclaratorias.Add(obeManifiestoProveedoresDeclaratorias);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeManifiestoProveedoresDeclaratorias;
            }
        }
        public List<beManifiestoProveedoresDeclaratorias> listar_ManifiestoProveedoresDeclaratorias_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_ManifiestoProveedoresDeclaratorias_TraerTodos_GetAll";
            List<beManifiestoProveedoresDeclaratorias> lbeManifiestoProveedoresDeclaratorias = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdManifiestoProveedorDeclaratoria = datard.GetOrdinal("IdManifiestoProveedorDeclaratoria");
                        int posIdManifiestoProveedor = datard.GetOrdinal("IdManifiestoProveedor");
                        int posIdManifiesto = datard.GetOrdinal("IdManifiesto");
                        int posAceptacion = datard.GetOrdinal("Aceptacion");
                        lbeManifiestoProveedoresDeclaratorias = new List<beManifiestoProveedoresDeclaratorias>();
                        beManifiestoProveedoresDeclaratorias obeManifiestoProveedoresDeclaratorias;
                        while (datard.Read())
                        {
                            obeManifiestoProveedoresDeclaratorias = new beManifiestoProveedoresDeclaratorias();
                            obeManifiestoProveedoresDeclaratorias.IdManifiestoProveedorDeclaratoria = datard.GetInt32(posIdManifiestoProveedorDeclaratoria);
                            obeManifiestoProveedoresDeclaratorias.IdManifiestoProveedor = datard.GetInt32(posIdManifiestoProveedor);
                            obeManifiestoProveedoresDeclaratorias.IdManifiesto = datard.GetInt32(posIdManifiesto);
                            obeManifiestoProveedoresDeclaratorias.Aceptacion = datard.GetBoolean(posAceptacion);
                            // debe agregar campos de la Vista
                            lbeManifiestoProveedoresDeclaratorias.Add(obeManifiestoProveedoresDeclaratorias);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeManifiestoProveedoresDeclaratorias;
            }
        }
        public List<beManifiestoProveedoresDeclaratorias> getAllManifiestoProveedoresDeclaratorias_x_IdManifiestoProveedor(SqlConnection Conexion, int pIdManifiestoProveedor)
        {
            string sp = "Proc_ManifiestoProveedoresDeclaratorias_IdManifiestoProveedor";
            List<beManifiestoProveedoresDeclaratorias> lbeManifiestoProveedoresDeclaratorias = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdManifiestoProveedor", SqlDbType.Int).Value = pIdManifiestoProveedor;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdManifiestoProveedorDeclaratoria = datard.GetOrdinal("IdManifiestoProveedorDeclaratoria");
                        int posIdManifiestoProveedor = datard.GetOrdinal("IdManifiestoProveedor");
                        int posIdManifiesto = datard.GetOrdinal("IdManifiesto");
                        int posAceptacion = datard.GetOrdinal("Aceptacion");
                        int posManifiesto = datard.GetOrdinal("Manifiesto");
                        lbeManifiestoProveedoresDeclaratorias = new List<beManifiestoProveedoresDeclaratorias>();
                        beManifiestoProveedoresDeclaratorias obeManifiestoProveedoresDeclaratorias;
                        while (datard.Read())
                        {
                            obeManifiestoProveedoresDeclaratorias = new beManifiestoProveedoresDeclaratorias();
                            obeManifiestoProveedoresDeclaratorias.IdManifiestoProveedorDeclaratoria = datard.GetInt32(posIdManifiestoProveedorDeclaratoria);
                            obeManifiestoProveedoresDeclaratorias.IdManifiestoProveedor = datard.GetInt32(posIdManifiestoProveedor);
                            obeManifiestoProveedoresDeclaratorias.IdManifiesto = datard.GetInt32(posIdManifiesto);
                            obeManifiestoProveedoresDeclaratorias.Aceptacion = datard.GetBoolean(posAceptacion);
                            obeManifiestoProveedoresDeclaratorias.Manifiesto = datard.GetString(posManifiesto);
                            lbeManifiestoProveedoresDeclaratorias.Add(obeManifiestoProveedoresDeclaratorias);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeManifiestoProveedoresDeclaratorias;
            }
        }
        public List<beManifiestoProveedoresDeclaratorias> getPedidoManifiestos_x_IdPedido(SqlConnection Conexion, int pIdPedido)
        {
            string sp = "Proc_PedidoManifiestos_x_IdPedido";
            List<beManifiestoProveedoresDeclaratorias> lbeManifiestoProveedoresDeclaratorias = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = pIdPedido;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdManifiesto = datard.GetOrdinal("Orden");
                        int posManifiesto = datard.GetOrdinal("Manifiesto");
                        lbeManifiestoProveedoresDeclaratorias = new List<beManifiestoProveedoresDeclaratorias>();
                        beManifiestoProveedoresDeclaratorias obeManifiestoProveedoresDeclaratorias;
                        while (datard.Read())
                        {
                            obeManifiestoProveedoresDeclaratorias = new beManifiestoProveedoresDeclaratorias();
                            obeManifiestoProveedoresDeclaratorias.IdManifiesto = datard.GetInt32(posIdManifiesto);
                            obeManifiestoProveedoresDeclaratorias.Manifiesto = datard.GetString(posManifiesto);
                            lbeManifiestoProveedoresDeclaratorias.Add(obeManifiestoProveedoresDeclaratorias);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeManifiestoProveedoresDeclaratorias;
            }
        }
        public List<bePedidoDetallesLotesEntregas> getPedidoDetallesLotesEntregas_x_IdPedido(SqlConnection Conexion, int pIdPedido)
        {
            string sp = "Proc_PedidoDetallesLotesEntregas_x_IdPedido";
            List<bePedidoDetallesLotesEntregas> lbeManifiestoProveedoresDeclaratorias = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = pIdPedido;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int BienServicio = datard.GetOrdinal("BienServicio");
                        int NoLote = datard.GetOrdinal("NoLote");
                        int Cantidad = datard.GetOrdinal("Cantidad");
                        int UnidadMedida = datard.GetOrdinal("UnidadMedida");
                        int PrecioUnitario = datard.GetOrdinal("PrecioUnitario");
                        int Importe = datard.GetOrdinal("Importe");
                        int ImporteIva = datard.GetOrdinal("ImporteIva");
                        int Lugar = datard.GetOrdinal("Lugar");
                        int HorarioEntrega = datard.GetOrdinal("HorarioEntrega");
                        int DiasEntrega = datard.GetOrdinal("DiasEntrega");
                        int Total = datard.GetOrdinal("Total");
                        int Frecuencia = datard.GetOrdinal("Frecuencia");
                        lbeManifiestoProveedoresDeclaratorias = new List<bePedidoDetallesLotesEntregas>();
                        
                        while (datard.Read())
                        {
                            bePedidoDetallesLotesEntregas obeManifiestoProveedoresDeclaratorias = new bePedidoDetallesLotesEntregas();
                            obeManifiestoProveedoresDeclaratorias.BienServicio = datard.GetString(BienServicio);
                            obeManifiestoProveedoresDeclaratorias.NoLote = datard.GetInt32(NoLote);
                            obeManifiestoProveedoresDeclaratorias.Cantidad = datard.GetDecimal(Cantidad);
                            obeManifiestoProveedoresDeclaratorias.UnidadMedida = datard.GetString(UnidadMedida);
                            obeManifiestoProveedoresDeclaratorias.PrecioUnitario = datard.GetDecimal(PrecioUnitario);
                            obeManifiestoProveedoresDeclaratorias.Importe = datard.GetDecimal(Importe);
                            obeManifiestoProveedoresDeclaratorias.ImporteIva = datard.GetDecimal(ImporteIva);
                            obeManifiestoProveedoresDeclaratorias.Lugar = datard.GetString(Lugar);
                            obeManifiestoProveedoresDeclaratorias.HorarioEntrega = datard.GetString(HorarioEntrega);
                            obeManifiestoProveedoresDeclaratorias.DiasEntrega = datard.GetString(DiasEntrega);
                            obeManifiestoProveedoresDeclaratorias.Total = datard.GetDecimal(Total);
                            obeManifiestoProveedoresDeclaratorias.Frecuencia = datard.GetInt32(Frecuencia);
                            lbeManifiestoProveedoresDeclaratorias.Add(obeManifiestoProveedoresDeclaratorias);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeManifiestoProveedoresDeclaratorias;
            }
        }
    }
}

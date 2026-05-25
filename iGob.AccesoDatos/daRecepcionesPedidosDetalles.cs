using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
    public class daRecepcionesPedidosDetalles
    {
        public int guardarRecepcionesPedidosDetalles(SqlConnection Conexion, beRecepcionesPedidosDetalles obeRecepcionesPedidosDetalles)
        {
            int Id = 0;
            string sp = "Proc_RecepcionesPedidosDetallesInsertar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdRecepcionDetalle", SqlDbType.Int).Value = obeRecepcionesPedidosDetalles.IdRecepcionDetalle;
                    cmd.Parameters.Add("@IdPedidoDetalle", SqlDbType.Int).Value = obeRecepcionesPedidosDetalles.IdPedidoDetalle;
                    cmd.Parameters.Add("@IdCondicionEntregaDetalle", SqlDbType.Int).Value = obeRecepcionesPedidosDetalles.IdCondicionEntregaDetalle;
                    cmd.Parameters.Add("@CantidadRecibida", SqlDbType.Decimal).Value = obeRecepcionesPedidosDetalles.CantidadRecibida;
                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = obeRecepcionesPedidosDetalles.Observaciones;
                    cmd.Parameters.Add("@IdLugarEntrega", SqlDbType.Int).Value = obeRecepcionesPedidosDetalles.IdLugarEntrega;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRecepcionesPedidosDetalles.FechaRegistro;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRecepcionesPedidosDetalles.IdUsuarioRegistro;

                    Id = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Id;
            }
        }

        public int actualizarRecepcionesPedidosDetalles(SqlConnection Conexion, beRecepcionesPedidosDetalles obeRecepcionesPedidosDetalles)
        {
            string sp = "Proc_RecepcionesPedidosDetallesActualizar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdRecepcionDetalle", SqlDbType.Int).Value = obeRecepcionesPedidosDetalles.IdRecepcionDetalle;
                    cmd.Parameters.Add("@IdPedidoDetalle", SqlDbType.Int).Value = obeRecepcionesPedidosDetalles.IdPedidoDetalle;
                    cmd.Parameters.Add("@IdCondicionEntregaDetalle", SqlDbType.Int).Value = obeRecepcionesPedidosDetalles.IdCondicionEntregaDetalle;
                    cmd.Parameters.Add("@CantidadRecibida", SqlDbType.Decimal).Value = obeRecepcionesPedidosDetalles.CantidadRecibida;
                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = obeRecepcionesPedidosDetalles.Observaciones;
                    cmd.Parameters.Add("@IdLugarEntrega", SqlDbType.Int).Value = obeRecepcionesPedidosDetalles.IdLugarEntrega;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRecepcionesPedidosDetalles.FechaRegistro;
                    cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRecepcionesPedidosDetalles.IdUsuarioRegistro;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }

        public int eliminarRecepcionesPedidosDetalles(SqlConnection Conexion, int pIdRecepcionDetalle)
        {
            string sp = "Proc_RecepcionesPedidosDetallesEliminar";
            using (SqlCommand cmd = new SqlCommand(sp, Conexion))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdRecepcionDetalle", SqlDbType.Int).Value = pIdRecepcionDetalle;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return 0;
            }
        }
        public beRecepcionesPedidosDetalles traerRecepcionesPedidosDetalles_x_IdRecepcionDetalle(SqlConnection Conexion, int IdRecepcionDetalle)
        {
            string sp = "Proc_RecepcionesPedidosDetalles_x_IdRecepcionDetalle";
            beRecepcionesPedidosDetalles obeRecepcionesPedidosDetalles = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdRecepcionDetalle", SqlDbType.Int).Value = IdRecepcionDetalle;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRecepcionDetalle = datard.GetOrdinal("IdRecepcionDetalle");
                        int posIdPedidoDetalle = datard.GetOrdinal("IdPedidoDetalle");
                        int posIdCondicionEntregaDetalle = datard.GetOrdinal("IdCondicionEntregaDetalle");
                        int posCantidadRecibida = datard.GetOrdinal("CantidadRecibida");
                        int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posIdLugarEntrega = datard.GetOrdinal("IdLugarEntrega");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        obeRecepcionesPedidosDetalles = new beRecepcionesPedidosDetalles();
                        while (datard.Read())
                        {
                            obeRecepcionesPedidosDetalles.IdRecepcionDetalle = datard.GetInt32(posIdRecepcionDetalle);
                            obeRecepcionesPedidosDetalles.IdPedidoDetalle = datard.GetInt32(posIdPedidoDetalle);
                            obeRecepcionesPedidosDetalles.IdCondicionEntregaDetalle = datard.GetInt32(posIdCondicionEntregaDetalle);
                            obeRecepcionesPedidosDetalles.CantidadRecibida = datard.GetDecimal(posCantidadRecibida);
                            obeRecepcionesPedidosDetalles.Observaciones = datard.GetString(posObservaciones);
                            obeRecepcionesPedidosDetalles.IdLugarEntrega = datard.GetInt32(posIdLugarEntrega);
                            obeRecepcionesPedidosDetalles.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeRecepcionesPedidosDetalles.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRecepcionesPedidosDetalles;
            }
        }
        public List<beRecepcionesPedidosDetalles> listarTodos_RecepcionesPedidosDetalles(SqlConnection Conexion)
        {
            string sp = "Proc_RecepcionesPedidosDetalles_Traer_Todos";
            List<beRecepcionesPedidosDetalles> lbeRecepcionesPedidosDetalles = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRecepcionDetalle = datard.GetOrdinal("IdRecepcionDetalle");
                        int posIdPedidoDetalle = datard.GetOrdinal("IdPedidoDetalle");
                        int posIdCondicionEntregaDetalle = datard.GetOrdinal("IdCondicionEntregaDetalle");
                        int posCantidadRecibida = datard.GetOrdinal("CantidadRecibida");
                        int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posIdLugarEntrega = datard.GetOrdinal("IdLugarEntrega");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        lbeRecepcionesPedidosDetalles = new List<beRecepcionesPedidosDetalles>();
                        beRecepcionesPedidosDetalles obeRecepcionesPedidosDetalles;
                        while (datard.Read())
                        {
                            obeRecepcionesPedidosDetalles = new beRecepcionesPedidosDetalles();
                            obeRecepcionesPedidosDetalles.IdRecepcionDetalle = datard.GetInt32(posIdRecepcionDetalle);
                            obeRecepcionesPedidosDetalles.IdPedidoDetalle = datard.GetInt32(posIdPedidoDetalle);
                            obeRecepcionesPedidosDetalles.IdCondicionEntregaDetalle = datard[posIdCondicionEntregaDetalle]==DBNull.Value?0: datard.GetInt32(posIdCondicionEntregaDetalle);
                            obeRecepcionesPedidosDetalles.CantidadRecibida = datard.GetDecimal(posCantidadRecibida);
                            obeRecepcionesPedidosDetalles.Observaciones = datard.GetString(posObservaciones);
                            obeRecepcionesPedidosDetalles.IdLugarEntrega = datard.GetInt32(posIdLugarEntrega);
                            obeRecepcionesPedidosDetalles.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeRecepcionesPedidosDetalles.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            lbeRecepcionesPedidosDetalles.Add(obeRecepcionesPedidosDetalles);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRecepcionesPedidosDetalles;
            }
        }
        public List<beRecepcionesPedidosDetalles> listar_RecepcionesPedidosDetalles_GetAll(SqlConnection Conexion)
        {
            string sp = "Proc_RecepcionesPedidosDetalles_TraerTodos_GetAll";
            List<beRecepcionesPedidosDetalles> lbeRecepcionesPedidosDetalles = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int posIdRecepcionDetalle = datard.GetOrdinal("IdRecepcionDetalle");
                        int posIdPedidoDetalle = datard.GetOrdinal("IdPedidoDetalle");
                        int posIdCondicionEntregaDetalle = datard.GetOrdinal("IdCondicionEntregaDetalle");
                        int posCantidadRecibida = datard.GetOrdinal("CantidadRecibida");
                        int posObservaciones = datard.GetOrdinal("Observaciones");
                        int posIdLugarEntrega = datard.GetOrdinal("IdLugarEntrega");
                        int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
                        lbeRecepcionesPedidosDetalles = new List<beRecepcionesPedidosDetalles>();
                        beRecepcionesPedidosDetalles obeRecepcionesPedidosDetalles;
                        while (datard.Read())
                        {
                            obeRecepcionesPedidosDetalles = new beRecepcionesPedidosDetalles();
                            obeRecepcionesPedidosDetalles.IdRecepcionDetalle = datard.GetInt32(posIdRecepcionDetalle);
                            obeRecepcionesPedidosDetalles.IdPedidoDetalle = datard.GetInt32(posIdPedidoDetalle);
                            obeRecepcionesPedidosDetalles.IdCondicionEntregaDetalle = datard.GetInt32(posIdCondicionEntregaDetalle);
                            obeRecepcionesPedidosDetalles.CantidadRecibida = datard.GetDecimal(posCantidadRecibida);
                            obeRecepcionesPedidosDetalles.Observaciones = datard.GetString(posObservaciones);
                            obeRecepcionesPedidosDetalles.IdLugarEntrega = datard.GetInt32(posIdLugarEntrega);
                            obeRecepcionesPedidosDetalles.FechaRegistro = datard.GetDateTime(posFechaRegistro);
                            obeRecepcionesPedidosDetalles.IdUsuarioRegistro = datard.GetInt32(posIdUsuarioRegistro);
                            // debe agregar campos de la Vista
                            lbeRecepcionesPedidosDetalles.Add(obeRecepcionesPedidosDetalles);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRecepcionesPedidosDetalles;
            }
        }
        public List<beListadoPedidosLicitaciones> listarTodos_RecepcionesPedidos_Licitacion(SqlConnection Conexion, int pIdDependnecia)
        {
            string sp = "Proc_PedidosRecepcionesLicitaciones_x_IdDependencia";
            List<beListadoPedidosLicitaciones> lbeRecepcionesPedidos = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdDependencia", SqlDbType.Int).Value = pIdDependnecia;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int IdPedido = datard.GetOrdinal("IdPedido");
                        int Folio = datard.GetOrdinal("Folio");
                        int FolioNumero = datard.GetOrdinal("FolioNumero");
                        int IdEstatusPedido = datard.GetOrdinal("IdEstatusPedido");
                        int EstatusPedido = datard.GetOrdinal("EstatusPedido");
                        int IdRequisicion = datard.GetOrdinal("IdRequisicion");
                        int RequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int Rfc = datard.GetOrdinal("Rfc");
                        int RazonSocial = datard.GetOrdinal("RazonSocial");
                        int IdLicitacion = datard.GetOrdinal("IdLicitacion");
                        int IdProveedor = datard.GetOrdinal("IdProveedor");
                        int FolioOficial = datard.GetOrdinal("FolioOficial");
                        int Partida = datard.GetOrdinal("Partida");
                        //int IdCondicionEntregaDetalle = datard.GetOrdinal("IdCondicionEntregaDetalle");

                        lbeRecepcionesPedidos = new List<beListadoPedidosLicitaciones>();
                        beListadoPedidosLicitaciones obeRecepcionesPedidos;
                        while (datard.Read())
                        {
                            obeRecepcionesPedidos = new beListadoPedidosLicitaciones();
                            obeRecepcionesPedidos.IdPedido = datard.GetInt32(IdPedido);
                            obeRecepcionesPedidos.Folio = datard.GetString(Folio);
                            obeRecepcionesPedidos.FolioNumero = datard.GetInt32(FolioNumero);
                            obeRecepcionesPedidos.IdEstatusPedido = datard.GetInt32(IdEstatusPedido);
                            obeRecepcionesPedidos.EstatusPedido = datard.GetString(EstatusPedido);
                            obeRecepcionesPedidos.IdRequisicion = datard.GetInt32(IdRequisicion);
                            obeRecepcionesPedidos.RequisicionFolio = datard.GetString(RequisicionFolio);
                            obeRecepcionesPedidos.Rfc = datard.GetString(Rfc);
                            obeRecepcionesPedidos.RazonSocial = datard.GetString(RazonSocial);
                            obeRecepcionesPedidos.IdLicitacion = datard.GetInt32(IdLicitacion);
                            obeRecepcionesPedidos.IdProveedor = datard.GetInt32(IdProveedor);
                            obeRecepcionesPedidos.FolioOficial = datard.GetString(FolioOficial);
                            obeRecepcionesPedidos.Partida = datard.GetString(Partida);
                            //obeRecepcionesPedidos.IdCondicionEntregaDetalle = datard.GetInt32(IdCondicionEntregaDetalle);
                            // debe agregar campos de la Vista
                            lbeRecepcionesPedidos.Add(obeRecepcionesPedidos);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRecepcionesPedidos;
            }
        }

        public List<beListadoPedidosLicitaciones> ListadoPedidosLicitaciones_IdPedido(SqlConnection Conexion, int pIdPedido)
        {
            string sp = "Proc_PedidosDetallesLotes_x_IdPedido";
            List<beListadoPedidosLicitaciones> lbeRecepcionesPedidos = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = pIdPedido;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int IdPedido = datard.GetOrdinal("IdPedido");
                        int Folio = datard.GetOrdinal("Folio");
                        int IdPedidoDetalle = datard.GetOrdinal("IdPedidoDetalle");
                        int Cantidad = datard.GetOrdinal("Cantidad");
                        int CantidadRecibida = datard.GetOrdinal("CantidadRecibida");
                        int CantidadxRecibir = datard.GetOrdinal("CantidadxRecibir");
                        int BienServicio = datard.GetOrdinal("BienServicio");
                        int IdLugarEntrega = datard.GetOrdinal("IdLugarEntrega");
                        int Lugar = datard.GetOrdinal("Lugar");
                        int NoLote = datard.GetOrdinal("NoLote");
                        int RequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int UnidadMedida = datard.GetOrdinal("UnidadMedida");
                        int IdCondicionEntregaDetalle = datard.GetOrdinal("IdCondicionEntregaDetalle");


                        lbeRecepcionesPedidos = new List<beListadoPedidosLicitaciones>();
                        beListadoPedidosLicitaciones obeRecepcionesPedidos;
                        while (datard.Read())
                        {
                            obeRecepcionesPedidos = new beListadoPedidosLicitaciones();
                            obeRecepcionesPedidos.IdPedido = datard.GetInt32(IdPedido);
                            obeRecepcionesPedidos.Folio = datard.GetString(Folio);
                            obeRecepcionesPedidos.IdPedidoDetalle = datard.GetInt32(IdPedidoDetalle);
                            obeRecepcionesPedidos.Cantidad = datard.GetDecimal(Cantidad);
                            obeRecepcionesPedidos.CantidadRecibida = datard.GetDecimal(CantidadRecibida);
                            obeRecepcionesPedidos.CantidadxRecibir = datard.GetDecimal(CantidadxRecibir);
                            obeRecepcionesPedidos.BienServicio = datard.GetString(BienServicio);
                            obeRecepcionesPedidos.IdLugarEntrega = datard.GetInt32(IdLugarEntrega);
                            obeRecepcionesPedidos.Lugar = datard.GetString(Lugar);
                            obeRecepcionesPedidos.NoLote = datard.GetInt32(NoLote);
                            obeRecepcionesPedidos.RequisicionFolio = datard.GetString(RequisicionFolio);
                            obeRecepcionesPedidos.UnidadMedida = datard.GetString(UnidadMedida);
                            obeRecepcionesPedidos.IdCondicionEntregaDetalle = datard.GetInt32(IdCondicionEntregaDetalle);
                            // debe agregar campos de la Vista
                            lbeRecepcionesPedidos.Add(obeRecepcionesPedidos);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRecepcionesPedidos;
            }
        }

        public bePedidoDetalleCabezera getCabezeraPedidoDetalles(SqlConnection Conexion, int pIdPedido)
        {
            string sp = "Proc_RecepcionPedidos_x_IdPedido";
            bePedidoDetalleCabezera obeRecepcionesPedidos = new bePedidoDetalleCabezera();
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = pIdPedido;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int IdPedido = datard.GetOrdinal("IdPedido");
                        int Folio = datard.GetOrdinal("Folio");
                        int RequisicionFolio = datard.GetOrdinal("RequisicionFolio");
                        int Fecha = datard.GetOrdinal("FechaPedido");
                        int Dependencia = datard.GetOrdinal("Dependencia");
                        int Partida = datard.GetOrdinal("Partida");
                        int EstatusPedido = datard.GetOrdinal("EstatusPedido");
                        int RazonSocial = datard.GetOrdinal("RazonSocial");
                        int Licitacion = datard.GetOrdinal("ModalidadLicitacion");
                        int FolioLicitacion = datard.GetOrdinal("FolioLicitacion");
                        //int IdCondicionEntregaDetalle = datard.GetOrdinal("IdCondicionEntregaDetalle");
                        while (datard.Read())
                        {

                            obeRecepcionesPedidos.IdPedido = datard.GetInt32(IdPedido);
                            obeRecepcionesPedidos.Folio = datard.GetString(Folio);
                            obeRecepcionesPedidos.RequisicionFolio = datard.GetString(RequisicionFolio);
                            obeRecepcionesPedidos.Fecha = datard.GetDateTime(Fecha);
                            obeRecepcionesPedidos.Dependencia = datard.GetString(Dependencia);
                            obeRecepcionesPedidos.Partida = datard.GetString(Partida);
                            obeRecepcionesPedidos.EstatusPedido = datard.GetString(EstatusPedido);
                            obeRecepcionesPedidos.RazonSocial = datard.GetString(RazonSocial);
                            obeRecepcionesPedidos.Licitacion = datard.GetString(Licitacion);
                            obeRecepcionesPedidos.FolioLicitacion = datard.GetString(FolioLicitacion);
                            //obeRecepcionesPedidos.IdCondicionEntregaDetalle = datard.GetInt32(IdCondicionEntregaDetalle);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return obeRecepcionesPedidos;
            }
        }
        public List<beListadoPedidosLicitaciones> getDetallePedidoLotes(SqlConnection Conexion, int pIdPedido)
        {
            string sp = "Proc_RecepcionPedidosDetalles_x_IdPedido";
            List<beListadoPedidosLicitaciones> lbeRecepcionesPedidos = null;
            SqlCommand cmd = new SqlCommand(sp, Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = pIdPedido;
            using (SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                try
                {
                    if (datard != null)
                    {
                        int IdPedido = datard.GetOrdinal("IdPedido");
                        int Folio = datard.GetOrdinal("Folio");
                        int FolioNumero = datard.GetOrdinal("FolioNumero");
                        int IdEstatusPedido = datard.GetOrdinal("IdEstatusPedido");
                        int Cantidad = datard.GetOrdinal("Cantidad");
                        int CantidadRecibida = datard.GetOrdinal("CantidadRecibida");
                        int CantidadxRecibir = datard.GetOrdinal("CantidadxRecibir");
                        int BienServicio = datard.GetOrdinal("BienServicio");
                        int FechaRegistro = datard.GetOrdinal("FechaRegistro");
                        int Lugar = datard.GetOrdinal("LugarEntrega");
                        int NoLote = datard.GetOrdinal("NoLote");
                        int NombreResponsable = datard.GetOrdinal("NombreResponsable");
                        int Observaciones = datard.GetOrdinal("Observaciones");
                        int UnidadMedida = datard.GetOrdinal("UnidadMedida");
                        int IdCondicionEntregaDetalle = datard.GetOrdinal("IdCondicionEntregaDetalle");
                        lbeRecepcionesPedidos = new List<beListadoPedidosLicitaciones>();
                        beListadoPedidosLicitaciones obeRecepcionesPedidos;
                        while (datard.Read())
                        {
                            obeRecepcionesPedidos = new beListadoPedidosLicitaciones();
                            obeRecepcionesPedidos.IdPedido = datard.GetInt32(IdPedido);
                            obeRecepcionesPedidos.Folio = datard.GetString(Folio);
                            obeRecepcionesPedidos.FolioNumero = datard.GetInt32(FolioNumero);
                            obeRecepcionesPedidos.IdEstatusPedido = datard.GetInt32(IdEstatusPedido);
                            obeRecepcionesPedidos.Cantidad = datard.GetDecimal(Cantidad);
                            obeRecepcionesPedidos.CantidadRecibida = datard.GetDecimal(CantidadRecibida);
                            obeRecepcionesPedidos.CantidadxRecibir = datard.GetDecimal(CantidadxRecibir);
                            obeRecepcionesPedidos.BienServicio = datard.GetString(BienServicio);
                            //obeRecepcionesPedidos.IdLugarEntrega = datard.GetInt32(IdLugarEntrega);
                            obeRecepcionesPedidos.Lugar = datard.GetString(Lugar);
                            obeRecepcionesPedidos.NoLote = datard.GetInt32(NoLote);
                            obeRecepcionesPedidos.EncargadoRecepcion = datard.GetString(NombreResponsable);
                            obeRecepcionesPedidos.Observaciones = datard.GetString(Observaciones);
                            obeRecepcionesPedidos.FechaRegistro = datard.GetDateTime(FechaRegistro);
                            obeRecepcionesPedidos.UnidadMedida = datard.GetString(UnidadMedida);
                            obeRecepcionesPedidos.IdCondicionEntregaDetalle = datard.GetInt32(IdCondicionEntregaDetalle);
                            // debe agregar campos de la Vista
                            lbeRecepcionesPedidos.Add(obeRecepcionesPedidos);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lbeRecepcionesPedidos;
            }
        }
    }
}
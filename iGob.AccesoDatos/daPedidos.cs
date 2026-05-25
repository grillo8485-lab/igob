using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daPedidos
 {
	public int guardarPedidos(SqlConnection Conexion, bePedidos obePedidos)
	{
		int Id=0;
		string sp = "Proc_PedidosInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = obePedidos.IdPedido;
				cmd.Parameters.Add("@IdProveedorRqInvitacion", SqlDbType.Int).Value = obePedidos.IdProveedorRqInvitacion;
				cmd.Parameters.Add("@FolioNumero", SqlDbType.Int).Value = obePedidos.FolioNumero;
				cmd.Parameters.Add("@Folio", SqlDbType.NChar).Value = obePedidos.Folio;
				cmd.Parameters.Add("@FechaPedido", SqlDbType.DateTime).Value = obePedidos.FechaPedido;
				cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obePedidos.IdProveedor;
				cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obePedidos.IdRequisicion;
				cmd.Parameters.Add("@Importe", SqlDbType.Decimal).Value = obePedidos.Importe;
				cmd.Parameters.Add("@ImporteIva", SqlDbType.Decimal).Value = obePedidos.ImporteIva;
				cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = obePedidos.Total;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obePedidos.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obePedidos.FechaRegistro;
				cmd.Parameters.Add("@IdEstatusPedido", SqlDbType.Int).Value = obePedidos.IdEstatusPedido;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarPedidos(SqlConnection Conexion, bePedidos obePedidos)
	{
		string sp = "Proc_PedidosActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = obePedidos.IdPedido;
				cmd.Parameters.Add("@IdProveedorRqInvitacion", SqlDbType.Int).Value = obePedidos.IdProveedorRqInvitacion;
				cmd.Parameters.Add("@FolioNumero", SqlDbType.Int).Value = obePedidos.FolioNumero;
				cmd.Parameters.Add("@Folio", SqlDbType.NChar).Value = obePedidos.Folio;
				cmd.Parameters.Add("@FechaPedido", SqlDbType.DateTime).Value = obePedidos.FechaPedido;
				cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obePedidos.IdProveedor;
				cmd.Parameters.Add("@IdRequisicion", SqlDbType.Int).Value = obePedidos.IdRequisicion;
				cmd.Parameters.Add("@Importe", SqlDbType.Decimal).Value = obePedidos.Importe;
				cmd.Parameters.Add("@ImporteIva", SqlDbType.Decimal).Value = obePedidos.ImporteIva;
				cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = obePedidos.Total;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obePedidos.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obePedidos.FechaRegistro;
				cmd.Parameters.Add("@IdEstatusPedido", SqlDbType.Int).Value = obePedidos.IdEstatusPedido;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarPedidos(SqlConnection Conexion,int pIdPedido)
	{
		string sp = "Proc_PedidosEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = pIdPedido;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public bePedidos traerPedidos_x_IdPedido(SqlConnection Conexion,int IdPedido)
	{
		string sp = "Proc_Pedidos_x_IdPedido";
				bePedidos obePedidos=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = IdPedido;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdPedido = datard.GetOrdinal("IdPedido");
						int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
						int posFolioNumero = datard.GetOrdinal("FolioNumero");
						int posFolio = datard.GetOrdinal("Folio");
						int posFechaPedido = datard.GetOrdinal("FechaPedido");
						int posIdProveedor = datard.GetOrdinal("IdProveedor");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posImporte = datard.GetOrdinal("Importe");
						int posImporteIva = datard.GetOrdinal("ImporteIva");
						int posTotal = datard.GetOrdinal("Total");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdEstatusPedido = datard.GetOrdinal("IdEstatusPedido");
					 obePedidos = new bePedidos();
				while (datard.Read())
					{
						obePedidos.IdPedido =  datard.GetInt32(posIdPedido);
						obePedidos.IdProveedorRqInvitacion =  datard.GetInt32(posIdProveedorRqInvitacion);
						obePedidos.FolioNumero =  datard.GetInt32(posFolioNumero);
						obePedidos.Folio =  datard.GetString(posFolio);
						obePedidos.FechaPedido =  datard.GetDateTime(posFechaPedido);
						obePedidos.IdProveedor =  datard.GetInt32(posIdProveedor);
						obePedidos.IdRequisicion =  datard.GetInt32(posIdRequisicion);
						obePedidos.Importe =  datard.GetDecimal(posImporte);
						obePedidos.ImporteIva =  datard.GetDecimal(posImporteIva);
						obePedidos.Total =  datard.GetDecimal(posTotal);
						obePedidos.IdUsuarioRegistro = datard[posIdUsuarioRegistro] ==DBNull.Value?0:  datard.GetInt32(posIdUsuarioRegistro);
						obePedidos.FechaRegistro = datard[posIdUsuarioRegistro] == DBNull.Value ? DateTime.MinValue : datard.GetDateTime(posFechaRegistro);
						obePedidos.IdEstatusPedido =  datard.GetInt32(posIdEstatusPedido);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obePedidos;
			}
	}
	public List< bePedidos> listarTodos_Pedidos(SqlConnection Conexion)
	 {
		string sp = "Proc_Pedidos_Traer_Todos";
		List<bePedidos> lbePedidos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdPedido = datard.GetOrdinal("IdPedido");
						int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
						int posFolioNumero = datard.GetOrdinal("FolioNumero");
						int posFolio = datard.GetOrdinal("Folio");
						int posFechaPedido = datard.GetOrdinal("FechaPedido");
						int posIdProveedor = datard.GetOrdinal("IdProveedor");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posImporte = datard.GetOrdinal("Importe");
						int posImporteIva = datard.GetOrdinal("ImporteIva");
						int posTotal = datard.GetOrdinal("Total");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdEstatusPedido = datard.GetOrdinal("IdEstatusPedido");
				lbePedidos = new List<bePedidos>();
				bePedidos obePedidos;
				while (datard.Read())
				{
					 obePedidos = new bePedidos();
					obePedidos.IdPedido =  datard.GetInt32(posIdPedido);
					obePedidos.IdProveedorRqInvitacion =  datard.GetInt32(posIdProveedorRqInvitacion);
					obePedidos.FolioNumero =  datard.GetInt32(posFolioNumero);
					obePedidos.Folio =  datard.GetString(posFolio);
					obePedidos.FechaPedido =  datard.GetDateTime(posFechaPedido);
					obePedidos.IdProveedor =  datard.GetInt32(posIdProveedor);
					obePedidos.IdRequisicion =  datard.GetInt32(posIdRequisicion);
					obePedidos.Importe =  datard.GetDecimal(posImporte);
					obePedidos.ImporteIva =  datard.GetDecimal(posImporteIva);
					obePedidos.Total =  datard.GetDecimal(posTotal);
					obePedidos.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obePedidos.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					obePedidos.IdEstatusPedido =  datard.GetInt32(posIdEstatusPedido);
					lbePedidos.Add(obePedidos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePedidos;
		}
	}
	public List< bePedidos> listar_Pedidos_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_Pedidos_TraerTodos_GetAll";
		List<bePedidos> lbePedidos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdPedido = datard.GetOrdinal("IdPedido");
						int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
						int posFolioNumero = datard.GetOrdinal("FolioNumero");
						int posFolio = datard.GetOrdinal("Folio");
						int posFechaPedido = datard.GetOrdinal("FechaPedido");
						int posIdProveedor = datard.GetOrdinal("IdProveedor");
						int posIdRequisicion = datard.GetOrdinal("IdRequisicion");
						int posImporte = datard.GetOrdinal("Importe");
						int posImporteIva = datard.GetOrdinal("ImporteIva");
						int posTotal = datard.GetOrdinal("Total");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdEstatusPedido = datard.GetOrdinal("IdEstatusPedido");
				lbePedidos = new List<bePedidos>();
				bePedidos obePedidos;
				while (datard.Read())
				{
					 obePedidos = new bePedidos();
					obePedidos.IdPedido =  datard.GetInt32(posIdPedido);
					obePedidos.IdProveedorRqInvitacion =  datard.GetInt32(posIdProveedorRqInvitacion);
					obePedidos.FolioNumero =  datard.GetInt32(posFolioNumero);
					obePedidos.Folio =  datard.GetString(posFolio);
					obePedidos.FechaPedido =  datard.GetDateTime(posFechaPedido);
					obePedidos.IdProveedor =  datard.GetInt32(posIdProveedor);
					obePedidos.IdRequisicion =  datard.GetInt32(posIdRequisicion);
					obePedidos.Importe =  datard.GetDecimal(posImporte);
					obePedidos.ImporteIva =  datard.GetDecimal(posImporteIva);
					obePedidos.Total =  datard.GetDecimal(posTotal);
					obePedidos.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obePedidos.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					obePedidos.IdEstatusPedido =  datard.GetInt32(posIdEstatusPedido);
			// debe agregar campos de la Vista
					lbePedidos.Add(obePedidos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePedidos;
		}
	}
}
}

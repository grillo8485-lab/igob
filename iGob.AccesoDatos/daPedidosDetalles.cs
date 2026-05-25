using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daPedidosDetalles
 {
	public int guardarPedidosDetalles(SqlConnection Conexion, bePedidosDetalles obePedidosDetalles)
	{
		int Id=0;
		string sp = "Proc_PedidosDetallesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPedidoDetalle", SqlDbType.Int).Value = obePedidosDetalles.IdPedidoDetalle;
				cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = obePedidosDetalles.IdPedido;
				cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = obePedidosDetalles.IdBienServicio;
				cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = obePedidosDetalles.Cantidad;
				cmd.Parameters.Add("@CantidadRecibida", SqlDbType.Decimal).Value = obePedidosDetalles.CantidadRecibida;
				cmd.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = obePedidosDetalles.PrecioUnitario;
				cmd.Parameters.Add("@Importe", SqlDbType.Decimal).Value = obePedidosDetalles.Importe;
				cmd.Parameters.Add("@ImporteIva", SqlDbType.Decimal).Value = obePedidosDetalles.ImporteIva;
				cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = obePedidosDetalles.Total;
				cmd.Parameters.Add("@IdCondicionEntregaDetalle", SqlDbType.Int).Value = obePedidosDetalles.IdCondicionEntregaDetalle;
				cmd.Parameters.Add("@IdRequisicionLote", SqlDbType.Int).Value = obePedidosDetalles.IdRequisicionLote;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarPedidosDetalles(SqlConnection Conexion, bePedidosDetalles obePedidosDetalles)
	{
		string sp = "Proc_PedidosDetallesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPedidoDetalle", SqlDbType.Int).Value = obePedidosDetalles.IdPedidoDetalle;
				cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = obePedidosDetalles.IdPedido;
				cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = obePedidosDetalles.IdBienServicio;
				cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = obePedidosDetalles.Cantidad;
				cmd.Parameters.Add("@CantidadRecibida", SqlDbType.Decimal).Value = obePedidosDetalles.CantidadRecibida;
				cmd.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = obePedidosDetalles.PrecioUnitario;
				cmd.Parameters.Add("@Importe", SqlDbType.Decimal).Value = obePedidosDetalles.Importe;
				cmd.Parameters.Add("@ImporteIva", SqlDbType.Decimal).Value = obePedidosDetalles.ImporteIva;
				cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = obePedidosDetalles.Total;
				cmd.Parameters.Add("@IdCondicionEntregaDetalle", SqlDbType.Int).Value = obePedidosDetalles.IdCondicionEntregaDetalle;
				cmd.Parameters.Add("@IdRequisicionLote", SqlDbType.Int).Value = obePedidosDetalles.IdRequisicionLote;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarPedidosDetalles(SqlConnection Conexion,int pIdPedidoDetalle)
	{
		string sp = "Proc_PedidosDetallesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPedidoDetalle", SqlDbType.Int).Value = pIdPedidoDetalle;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public bePedidosDetalles traerPedidosDetalles_x_IdPedidoDetalle(SqlConnection Conexion,int IdPedidoDetalle)
	{
		string sp = "Proc_PedidosDetalles_x_IdPedidoDetalle";
				bePedidosDetalles obePedidosDetalles=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdPedidoDetalle", SqlDbType.Int).Value = IdPedidoDetalle;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdPedidoDetalle = datard.GetOrdinal("IdPedidoDetalle");
						int posIdPedido = datard.GetOrdinal("IdPedido");
						int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
						int posCantidad = datard.GetOrdinal("Cantidad");
						int posCantidadRecibida = datard.GetOrdinal("CantidadRecibida");
						int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
						int posImporte = datard.GetOrdinal("Importe");
						int posImporteIva = datard.GetOrdinal("ImporteIva");
						int posTotal = datard.GetOrdinal("Total");
						int posIdCondicionEntregaDetalle = datard.GetOrdinal("IdCondicionEntregaDetalle");
						int posIdRequisicionLote = datard.GetOrdinal("IdRequisicionLote");
					 obePedidosDetalles = new bePedidosDetalles();
				while (datard.Read())
					{
						obePedidosDetalles.IdPedidoDetalle =  datard.GetInt32(posIdPedidoDetalle);
						obePedidosDetalles.IdPedido =  datard.GetInt32(posIdPedido);
						obePedidosDetalles.IdBienServicio =  datard.GetInt32(posIdBienServicio);
						obePedidosDetalles.Cantidad =  datard.GetDecimal(posCantidad);
						obePedidosDetalles.CantidadRecibida =  datard.GetDecimal(posCantidadRecibida);
						obePedidosDetalles.PrecioUnitario =  datard.GetDecimal(posPrecioUnitario);
						obePedidosDetalles.Importe =  datard.GetDecimal(posImporte);
						obePedidosDetalles.ImporteIva =  datard.GetDecimal(posImporteIva);
						obePedidosDetalles.Total =  datard.GetDecimal(posTotal);
						obePedidosDetalles.IdCondicionEntregaDetalle =  datard.GetInt32(posIdCondicionEntregaDetalle);
						obePedidosDetalles.IdRequisicionLote =  datard.GetInt32(posIdRequisicionLote);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obePedidosDetalles;
			}
	}
	public List< bePedidosDetalles> listarTodos_PedidosDetalles(SqlConnection Conexion)
	 {
		string sp = "Proc_PedidosDetalles_Traer_Todos";
		List<bePedidosDetalles> lbePedidosDetalles = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdPedidoDetalle = datard.GetOrdinal("IdPedidoDetalle");
						int posIdPedido = datard.GetOrdinal("IdPedido");
						int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
						int posCantidad = datard.GetOrdinal("Cantidad");
						int posCantidadRecibida = datard.GetOrdinal("CantidadRecibida");
						int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
						int posImporte = datard.GetOrdinal("Importe");
						int posImporteIva = datard.GetOrdinal("ImporteIva");
						int posTotal = datard.GetOrdinal("Total");
						int posIdCondicionEntregaDetalle = datard.GetOrdinal("IdCondicionEntregaDetalle");
						int posIdRequisicionLote = datard.GetOrdinal("IdRequisicionLote");
				lbePedidosDetalles = new List<bePedidosDetalles>();
				bePedidosDetalles obePedidosDetalles;
				while (datard.Read())
				{
					 obePedidosDetalles = new bePedidosDetalles();
					obePedidosDetalles.IdPedidoDetalle =  datard.GetInt32(posIdPedidoDetalle);
					obePedidosDetalles.IdPedido =  datard.GetInt32(posIdPedido);
					obePedidosDetalles.IdBienServicio =  datard.GetInt32(posIdBienServicio);
					obePedidosDetalles.Cantidad =  datard.GetDecimal(posCantidad);
					obePedidosDetalles.CantidadRecibida =  datard.GetDecimal(posCantidadRecibida);
					obePedidosDetalles.PrecioUnitario =  datard.GetDecimal(posPrecioUnitario);
					obePedidosDetalles.Importe =  datard.GetDecimal(posImporte);
					obePedidosDetalles.ImporteIva =  datard.GetDecimal(posImporteIva);
					obePedidosDetalles.Total =  datard.GetDecimal(posTotal);
					obePedidosDetalles.IdCondicionEntregaDetalle =  datard.GetInt32(posIdCondicionEntregaDetalle);
					obePedidosDetalles.IdRequisicionLote =  datard.GetInt32(posIdRequisicionLote);
					lbePedidosDetalles.Add(obePedidosDetalles);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePedidosDetalles;
		}
	}
	public List< bePedidosDetalles> listar_PedidosDetalles_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_PedidosDetalles_TraerTodos_GetAll";
		List<bePedidosDetalles> lbePedidosDetalles = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdPedidoDetalle = datard.GetOrdinal("IdPedidoDetalle");
						int posIdPedido = datard.GetOrdinal("IdPedido");
						int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
						int posCantidad = datard.GetOrdinal("Cantidad");
						int posCantidadRecibida = datard.GetOrdinal("CantidadRecibida");
						int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
						int posImporte = datard.GetOrdinal("Importe");
						int posImporteIva = datard.GetOrdinal("ImporteIva");
						int posTotal = datard.GetOrdinal("Total");
						int posIdCondicionEntregaDetalle = datard.GetOrdinal("IdCondicionEntregaDetalle");
						int posIdRequisicionLote = datard.GetOrdinal("IdRequisicionLote");
				lbePedidosDetalles = new List<bePedidosDetalles>();
				bePedidosDetalles obePedidosDetalles;
				while (datard.Read())
				{
					 obePedidosDetalles = new bePedidosDetalles();
					obePedidosDetalles.IdPedidoDetalle =  datard.GetInt32(posIdPedidoDetalle);
					obePedidosDetalles.IdPedido =  datard.GetInt32(posIdPedido);
					obePedidosDetalles.IdBienServicio =  datard.GetInt32(posIdBienServicio);
					obePedidosDetalles.Cantidad =  datard.GetDecimal(posCantidad);
					obePedidosDetalles.CantidadRecibida =  datard.GetDecimal(posCantidadRecibida);
					obePedidosDetalles.PrecioUnitario =  datard.GetDecimal(posPrecioUnitario);
					obePedidosDetalles.Importe =  datard.GetDecimal(posImporte);
					obePedidosDetalles.ImporteIva =  datard.GetDecimal(posImporteIva);
					obePedidosDetalles.Total =  datard.GetDecimal(posTotal);
					obePedidosDetalles.IdCondicionEntregaDetalle =  datard.GetInt32(posIdCondicionEntregaDetalle);
					obePedidosDetalles.IdRequisicionLote =  datard.GetInt32(posIdRequisicionLote);
			// debe agregar campos de la Vista
					lbePedidosDetalles.Add(obePedidosDetalles);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePedidosDetalles;
		}
	}
}
}

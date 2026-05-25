using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daAdjudicacionesPedidosDetalles
 {
	public int guardarAdjudicacionesPedidosDetalles(SqlConnection Conexion, beAdjudicacionesPedidosDetalles obeAdjudicacionesPedidosDetalles)
	{
		int Id=0;
		string sp = "Proc_AdjudicacionesPedidosDetallesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionPedidoDetalle", SqlDbType.Int).Value = obeAdjudicacionesPedidosDetalles.IdAdjudicacionPedidoDetalle;
				cmd.Parameters.Add("@IdAdjudicacionPedido", SqlDbType.Int).Value = obeAdjudicacionesPedidosDetalles.IdAdjudicacionPedido;
				cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = obeAdjudicacionesPedidosDetalles.IdBienServicio;
				cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = obeAdjudicacionesPedidosDetalles.Cantidad;
				cmd.Parameters.Add("@CantidadRecibida", SqlDbType.Decimal).Value = obeAdjudicacionesPedidosDetalles.CantidadRecibida;
				cmd.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = obeAdjudicacionesPedidosDetalles.PrecioUnitario;
				cmd.Parameters.Add("@Importe", SqlDbType.Decimal).Value = obeAdjudicacionesPedidosDetalles.Importe;
				cmd.Parameters.Add("@ImporteIva", SqlDbType.Decimal).Value = obeAdjudicacionesPedidosDetalles.ImporteIva;
				cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = obeAdjudicacionesPedidosDetalles.Total;
				cmd.Parameters.Add("@IdCondicionEntregaDetalle", SqlDbType.Int).Value = obeAdjudicacionesPedidosDetalles.IdCondicionEntregaDetalle;
				cmd.Parameters.Add("@IdAdjudicacionLote", SqlDbType.Int).Value = obeAdjudicacionesPedidosDetalles.IdAdjudicacionLote;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarAdjudicacionesPedidosDetalles(SqlConnection Conexion, beAdjudicacionesPedidosDetalles obeAdjudicacionesPedidosDetalles)
	{
		string sp = "Proc_AdjudicacionesPedidosDetallesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionPedidoDetalle", SqlDbType.Int).Value = obeAdjudicacionesPedidosDetalles.IdAdjudicacionPedidoDetalle;
				cmd.Parameters.Add("@IdAdjudicacionPedido", SqlDbType.Int).Value = obeAdjudicacionesPedidosDetalles.IdAdjudicacionPedido;
				cmd.Parameters.Add("@IdBienServicio", SqlDbType.Int).Value = obeAdjudicacionesPedidosDetalles.IdBienServicio;
				cmd.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = obeAdjudicacionesPedidosDetalles.Cantidad;
				cmd.Parameters.Add("@CantidadRecibida", SqlDbType.Decimal).Value = obeAdjudicacionesPedidosDetalles.CantidadRecibida;
				cmd.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal).Value = obeAdjudicacionesPedidosDetalles.PrecioUnitario;
				cmd.Parameters.Add("@Importe", SqlDbType.Decimal).Value = obeAdjudicacionesPedidosDetalles.Importe;
				cmd.Parameters.Add("@ImporteIva", SqlDbType.Decimal).Value = obeAdjudicacionesPedidosDetalles.ImporteIva;
				cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = obeAdjudicacionesPedidosDetalles.Total;
				cmd.Parameters.Add("@IdCondicionEntregaDetalle", SqlDbType.Int).Value = obeAdjudicacionesPedidosDetalles.IdCondicionEntregaDetalle;
				cmd.Parameters.Add("@IdAdjudicacionLote", SqlDbType.Int).Value = obeAdjudicacionesPedidosDetalles.IdAdjudicacionLote;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarAdjudicacionesPedidosDetalles(SqlConnection Conexion,int pIdAdjudicacionPedidoDetalle)
	{
		string sp = "Proc_AdjudicacionesPedidosDetallesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionPedidoDetalle", SqlDbType.Int).Value = pIdAdjudicacionPedidoDetalle;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beAdjudicacionesPedidosDetalles traerAdjudicacionesPedidosDetalles_x_IdAdjudicacionPedidoDetalle(SqlConnection Conexion,int IdAdjudicacionPedidoDetalle)
	{
		string sp = "Proc_AdjudicacionesPedidosDetalles_x_IdAdjudicacionPedidoDetalle";
				beAdjudicacionesPedidosDetalles obeAdjudicacionesPedidosDetalles=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdAdjudicacionPedidoDetalle", SqlDbType.Int).Value = IdAdjudicacionPedidoDetalle;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdAdjudicacionPedidoDetalle = datard.GetOrdinal("IdAdjudicacionPedidoDetalle");
						int posIdAdjudicacionPedido = datard.GetOrdinal("IdAdjudicacionPedido");
						int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
						int posCantidad = datard.GetOrdinal("Cantidad");
						int posCantidadRecibida = datard.GetOrdinal("CantidadRecibida");
						int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
						int posImporte = datard.GetOrdinal("Importe");
						int posImporteIva = datard.GetOrdinal("ImporteIva");
						int posTotal = datard.GetOrdinal("Total");
						int posIdCondicionEntregaDetalle = datard.GetOrdinal("IdCondicionEntregaDetalle");
						int posIdAdjudicacionLote = datard.GetOrdinal("IdAdjudicacionLote");
					 obeAdjudicacionesPedidosDetalles = new beAdjudicacionesPedidosDetalles();
				while (datard.Read())
					{
						obeAdjudicacionesPedidosDetalles.IdAdjudicacionPedidoDetalle =  datard.GetInt32(posIdAdjudicacionPedidoDetalle);
						obeAdjudicacionesPedidosDetalles.IdAdjudicacionPedido =  datard.GetInt32(posIdAdjudicacionPedido);
						obeAdjudicacionesPedidosDetalles.IdBienServicio =  datard.GetInt32(posIdBienServicio);
						obeAdjudicacionesPedidosDetalles.Cantidad =  datard.GetDecimal(posCantidad);
						obeAdjudicacionesPedidosDetalles.CantidadRecibida =  datard.GetDecimal(posCantidadRecibida);
						obeAdjudicacionesPedidosDetalles.PrecioUnitario =  datard.GetDecimal(posPrecioUnitario);
						obeAdjudicacionesPedidosDetalles.Importe =  datard.GetDecimal(posImporte);
						obeAdjudicacionesPedidosDetalles.ImporteIva =  datard.GetDecimal(posImporteIva);
						obeAdjudicacionesPedidosDetalles.Total =  datard.GetDecimal(posTotal);
						obeAdjudicacionesPedidosDetalles.IdCondicionEntregaDetalle =  datard.GetInt32(posIdCondicionEntregaDetalle);
						obeAdjudicacionesPedidosDetalles.IdAdjudicacionLote =  datard.GetInt32(posIdAdjudicacionLote);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesPedidosDetalles;
			}
	}
	public List< beAdjudicacionesPedidosDetalles> listarTodos_AdjudicacionesPedidosDetalles(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesPedidosDetalles_Traer_Todos";
		List<beAdjudicacionesPedidosDetalles> lbeAdjudicacionesPedidosDetalles = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacionPedidoDetalle = datard.GetOrdinal("IdAdjudicacionPedidoDetalle");
						int posIdAdjudicacionPedido = datard.GetOrdinal("IdAdjudicacionPedido");
						int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
						int posCantidad = datard.GetOrdinal("Cantidad");
						int posCantidadRecibida = datard.GetOrdinal("CantidadRecibida");
						int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
						int posImporte = datard.GetOrdinal("Importe");
						int posImporteIva = datard.GetOrdinal("ImporteIva");
						int posTotal = datard.GetOrdinal("Total");
						int posIdCondicionEntregaDetalle = datard.GetOrdinal("IdCondicionEntregaDetalle");
						int posIdAdjudicacionLote = datard.GetOrdinal("IdAdjudicacionLote");
				lbeAdjudicacionesPedidosDetalles = new List<beAdjudicacionesPedidosDetalles>();
				beAdjudicacionesPedidosDetalles obeAdjudicacionesPedidosDetalles;
				while (datard.Read())
				{
					 obeAdjudicacionesPedidosDetalles = new beAdjudicacionesPedidosDetalles();
					obeAdjudicacionesPedidosDetalles.IdAdjudicacionPedidoDetalle =  datard.GetInt32(posIdAdjudicacionPedidoDetalle);
					obeAdjudicacionesPedidosDetalles.IdAdjudicacionPedido =  datard.GetInt32(posIdAdjudicacionPedido);
					obeAdjudicacionesPedidosDetalles.IdBienServicio =  datard.GetInt32(posIdBienServicio);
					obeAdjudicacionesPedidosDetalles.Cantidad =  datard.GetDecimal(posCantidad);
					obeAdjudicacionesPedidosDetalles.CantidadRecibida =  datard.GetDecimal(posCantidadRecibida);
					obeAdjudicacionesPedidosDetalles.PrecioUnitario =  datard.GetDecimal(posPrecioUnitario);
					obeAdjudicacionesPedidosDetalles.Importe =  datard.GetDecimal(posImporte);
					obeAdjudicacionesPedidosDetalles.ImporteIva =  datard.GetDecimal(posImporteIva);
					obeAdjudicacionesPedidosDetalles.Total =  datard.GetDecimal(posTotal);
					obeAdjudicacionesPedidosDetalles.IdCondicionEntregaDetalle =  datard.GetInt32(posIdCondicionEntregaDetalle);
					obeAdjudicacionesPedidosDetalles.IdAdjudicacionLote =  datard.GetInt32(posIdAdjudicacionLote);
					lbeAdjudicacionesPedidosDetalles.Add(obeAdjudicacionesPedidosDetalles);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesPedidosDetalles;
		}
	}
	public List< beAdjudicacionesPedidosDetalles> listar_AdjudicacionesPedidosDetalles_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesPedidosDetalles_TraerTodos_GetAll";
		List<beAdjudicacionesPedidosDetalles> lbeAdjudicacionesPedidosDetalles = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacionPedidoDetalle = datard.GetOrdinal("IdAdjudicacionPedidoDetalle");
						int posIdAdjudicacionPedido = datard.GetOrdinal("IdAdjudicacionPedido");
						int posIdBienServicio = datard.GetOrdinal("IdBienServicio");
						int posCantidad = datard.GetOrdinal("Cantidad");
						int posCantidadRecibida = datard.GetOrdinal("CantidadRecibida");
						int posPrecioUnitario = datard.GetOrdinal("PrecioUnitario");
						int posImporte = datard.GetOrdinal("Importe");
						int posImporteIva = datard.GetOrdinal("ImporteIva");
						int posTotal = datard.GetOrdinal("Total");
						int posIdCondicionEntregaDetalle = datard.GetOrdinal("IdCondicionEntregaDetalle");
						int posIdAdjudicacionLote = datard.GetOrdinal("IdAdjudicacionLote");
				lbeAdjudicacionesPedidosDetalles = new List<beAdjudicacionesPedidosDetalles>();
				beAdjudicacionesPedidosDetalles obeAdjudicacionesPedidosDetalles;
				while (datard.Read())
				{
					 obeAdjudicacionesPedidosDetalles = new beAdjudicacionesPedidosDetalles();
					obeAdjudicacionesPedidosDetalles.IdAdjudicacionPedidoDetalle =  datard.GetInt32(posIdAdjudicacionPedidoDetalle);
					obeAdjudicacionesPedidosDetalles.IdAdjudicacionPedido =  datard.GetInt32(posIdAdjudicacionPedido);
					obeAdjudicacionesPedidosDetalles.IdBienServicio =  datard.GetInt32(posIdBienServicio);
					obeAdjudicacionesPedidosDetalles.Cantidad =  datard.GetDecimal(posCantidad);
					obeAdjudicacionesPedidosDetalles.CantidadRecibida =  datard.GetDecimal(posCantidadRecibida);
					obeAdjudicacionesPedidosDetalles.PrecioUnitario =  datard.GetDecimal(posPrecioUnitario);
					obeAdjudicacionesPedidosDetalles.Importe =  datard.GetDecimal(posImporte);
					obeAdjudicacionesPedidosDetalles.ImporteIva =  datard.GetDecimal(posImporteIva);
					obeAdjudicacionesPedidosDetalles.Total =  datard.GetDecimal(posTotal);
					obeAdjudicacionesPedidosDetalles.IdCondicionEntregaDetalle =  datard.GetInt32(posIdCondicionEntregaDetalle);
					obeAdjudicacionesPedidosDetalles.IdAdjudicacionLote =  datard.GetInt32(posIdAdjudicacionLote);
			// debe agregar campos de la Vista
					lbeAdjudicacionesPedidosDetalles.Add(obeAdjudicacionesPedidosDetalles);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesPedidosDetalles;
		}
	}
}
}

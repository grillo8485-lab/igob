using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daAdjudicacionesPedidos
 {
	public int guardarAdjudicacionesPedidos(SqlConnection Conexion, beAdjudicacionesPedidos obeAdjudicacionesPedidos)
	{
		int Id=0;
		string sp = "Proc_AdjudicacionesPedidosInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionPedido", SqlDbType.Int).Value = obeAdjudicacionesPedidos.IdAdjudicacionPedido;
				cmd.Parameters.Add("@IdAdjudicacionProveedor", SqlDbType.Int).Value = obeAdjudicacionesPedidos.IdAdjudicacionProveedor;
				cmd.Parameters.Add("@FolioNumero", SqlDbType.Int).Value = obeAdjudicacionesPedidos.FolioNumero;
				cmd.Parameters.Add("@Folio", SqlDbType.NChar).Value = obeAdjudicacionesPedidos.Folio;
				cmd.Parameters.Add("@FechaPedido", SqlDbType.DateTime).Value = obeAdjudicacionesPedidos.FechaPedido;
				cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeAdjudicacionesPedidos.IdProveedor;
				cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesPedidos.IdAdjudicacion;
				cmd.Parameters.Add("@Importe", SqlDbType.Decimal).Value = obeAdjudicacionesPedidos.Importe;
				cmd.Parameters.Add("@ImporteIva", SqlDbType.Decimal).Value = obeAdjudicacionesPedidos.ImporteIva;
				cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = obeAdjudicacionesPedidos.Total;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeAdjudicacionesPedidos.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeAdjudicacionesPedidos.FechaRegistro;
				cmd.Parameters.Add("@IdEstatusPedido", SqlDbType.Int).Value = obeAdjudicacionesPedidos.IdEstatusPedido;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarAdjudicacionesPedidos(SqlConnection Conexion, beAdjudicacionesPedidos obeAdjudicacionesPedidos)
	{
		string sp = "Proc_AdjudicacionesPedidosActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionPedido", SqlDbType.Int).Value = obeAdjudicacionesPedidos.IdAdjudicacionPedido;
				cmd.Parameters.Add("@IdAdjudicacionProveedor", SqlDbType.Int).Value = obeAdjudicacionesPedidos.IdAdjudicacionProveedor;
				cmd.Parameters.Add("@FolioNumero", SqlDbType.Int).Value = obeAdjudicacionesPedidos.FolioNumero;
				cmd.Parameters.Add("@Folio", SqlDbType.NChar).Value = obeAdjudicacionesPedidos.Folio;
				cmd.Parameters.Add("@FechaPedido", SqlDbType.DateTime).Value = obeAdjudicacionesPedidos.FechaPedido;
				cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = obeAdjudicacionesPedidos.IdProveedor;
				cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesPedidos.IdAdjudicacion;
				cmd.Parameters.Add("@Importe", SqlDbType.Decimal).Value = obeAdjudicacionesPedidos.Importe;
				cmd.Parameters.Add("@ImporteIva", SqlDbType.Decimal).Value = obeAdjudicacionesPedidos.ImporteIva;
				cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = obeAdjudicacionesPedidos.Total;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeAdjudicacionesPedidos.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeAdjudicacionesPedidos.FechaRegistro;
				cmd.Parameters.Add("@IdEstatusPedido", SqlDbType.Int).Value = obeAdjudicacionesPedidos.IdEstatusPedido;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarAdjudicacionesPedidos(SqlConnection Conexion,int pIdAdjudicacionPedido)
	{
		string sp = "Proc_AdjudicacionesPedidosEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionPedido", SqlDbType.Int).Value = pIdAdjudicacionPedido;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beAdjudicacionesPedidos traerAdjudicacionesPedidos_x_IdAdjudicacionPedido(SqlConnection Conexion,int IdAdjudicacionPedido)
	{
		string sp = "Proc_AdjudicacionesPedidos_x_IdAdjudicacionPedido";
				beAdjudicacionesPedidos obeAdjudicacionesPedidos=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdAdjudicacionPedido", SqlDbType.Int).Value = IdAdjudicacionPedido;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdAdjudicacionPedido = datard.GetOrdinal("IdAdjudicacionPedido");
						int posIdAdjudicacionProveedor = datard.GetOrdinal("IdAdjudicacionProveedor");
						int posFolioNumero = datard.GetOrdinal("FolioNumero");
						int posFolio = datard.GetOrdinal("Folio");
						int posFechaPedido = datard.GetOrdinal("FechaPedido");
						int posIdProveedor = datard.GetOrdinal("IdProveedor");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posImporte = datard.GetOrdinal("Importe");
						int posImporteIva = datard.GetOrdinal("ImporteIva");
						int posTotal = datard.GetOrdinal("Total");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdEstatusPedido = datard.GetOrdinal("IdEstatusPedido");
					 obeAdjudicacionesPedidos = new beAdjudicacionesPedidos();
				while (datard.Read())
					{
						obeAdjudicacionesPedidos.IdAdjudicacionPedido =  datard.GetInt32(posIdAdjudicacionPedido);
						obeAdjudicacionesPedidos.IdAdjudicacionProveedor =  datard.GetInt32(posIdAdjudicacionProveedor);
						obeAdjudicacionesPedidos.FolioNumero =  datard.GetInt32(posFolioNumero);
						obeAdjudicacionesPedidos.Folio =  datard.GetString(posFolio);
						obeAdjudicacionesPedidos.FechaPedido =  datard.GetDateTime(posFechaPedido);
						obeAdjudicacionesPedidos.IdProveedor =  datard.GetInt32(posIdProveedor);
						obeAdjudicacionesPedidos.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
						obeAdjudicacionesPedidos.Importe =  datard.GetDecimal(posImporte);
						obeAdjudicacionesPedidos.ImporteIva =  datard.GetDecimal(posImporteIva);
						obeAdjudicacionesPedidos.Total =  datard.GetDecimal(posTotal);
						obeAdjudicacionesPedidos.IdUsuarioRegistro = datard[posIdUsuarioRegistro] == DBNull.Value ? Int32.MinValue : datard.GetInt32(posIdUsuarioRegistro); //datard.GetInt32(posIdUsuarioRegistro);
                            obeAdjudicacionesPedidos.FechaRegistro = datard[posFechaRegistro] == DBNull.Value ? DateTime.Now : datard.GetDateTime(posFechaRegistro); //datard.GetDateTime(posFechaRegistro);
						obeAdjudicacionesPedidos.IdEstatusPedido =  datard.GetInt32(posIdEstatusPedido);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesPedidos;
			}
	}
	public List< beAdjudicacionesPedidos> listarTodos_AdjudicacionesPedidos(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesPedidos_Traer_Todos";
		List<beAdjudicacionesPedidos> lbeAdjudicacionesPedidos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacionPedido = datard.GetOrdinal("IdAdjudicacionPedido");
						int posIdAdjudicacionProveedor = datard.GetOrdinal("IdAdjudicacionProveedor");
						int posFolioNumero = datard.GetOrdinal("FolioNumero");
						int posFolio = datard.GetOrdinal("Folio");
						int posFechaPedido = datard.GetOrdinal("FechaPedido");
						int posIdProveedor = datard.GetOrdinal("IdProveedor");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posImporte = datard.GetOrdinal("Importe");
						int posImporteIva = datard.GetOrdinal("ImporteIva");
						int posTotal = datard.GetOrdinal("Total");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdEstatusPedido = datard.GetOrdinal("IdEstatusPedido");
				lbeAdjudicacionesPedidos = new List<beAdjudicacionesPedidos>();
				beAdjudicacionesPedidos obeAdjudicacionesPedidos;
				while (datard.Read())
				{
					 obeAdjudicacionesPedidos = new beAdjudicacionesPedidos();
					obeAdjudicacionesPedidos.IdAdjudicacionPedido =  datard.GetInt32(posIdAdjudicacionPedido);
					obeAdjudicacionesPedidos.IdAdjudicacionProveedor =  datard.GetInt32(posIdAdjudicacionProveedor);
					obeAdjudicacionesPedidos.FolioNumero =  datard.GetInt32(posFolioNumero);
					obeAdjudicacionesPedidos.Folio =  datard.GetString(posFolio);
					obeAdjudicacionesPedidos.FechaPedido =  datard.GetDateTime(posFechaPedido);
					obeAdjudicacionesPedidos.IdProveedor =  datard.GetInt32(posIdProveedor);
					obeAdjudicacionesPedidos.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
					obeAdjudicacionesPedidos.Importe =  datard.GetDecimal(posImporte);
					obeAdjudicacionesPedidos.ImporteIva =  datard.GetDecimal(posImporteIva);
					obeAdjudicacionesPedidos.Total =  datard.GetDecimal(posTotal);
					obeAdjudicacionesPedidos.IdUsuarioRegistro = datard[posIdUsuarioRegistro] == DBNull.Value ? Int32.MinValue : datard.GetInt32(posIdUsuarioRegistro);// datard.GetInt32(posIdUsuarioRegistro);
					obeAdjudicacionesPedidos.FechaRegistro = datard[posFechaRegistro] == DBNull.Value ? DateTime.Now : datard.GetDateTime(posFechaRegistro);// datard.GetDateTime(posFechaRegistro);
					obeAdjudicacionesPedidos.IdEstatusPedido =  datard.GetInt32(posIdEstatusPedido);
					lbeAdjudicacionesPedidos.Add(obeAdjudicacionesPedidos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesPedidos;
		}
	}
	public List< beAdjudicacionesPedidos> listar_AdjudicacionesPedidos_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesPedidos_TraerTodos_GetAll";
		List<beAdjudicacionesPedidos> lbeAdjudicacionesPedidos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacionPedido = datard.GetOrdinal("IdAdjudicacionPedido");
						int posIdAdjudicacionProveedor = datard.GetOrdinal("IdAdjudicacionProveedor");
						int posFolioNumero = datard.GetOrdinal("FolioNumero");
						int posFolio = datard.GetOrdinal("Folio");
						int posFechaPedido = datard.GetOrdinal("FechaPedido");
						int posIdProveedor = datard.GetOrdinal("IdProveedor");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posImporte = datard.GetOrdinal("Importe");
						int posImporteIva = datard.GetOrdinal("ImporteIva");
						int posTotal = datard.GetOrdinal("Total");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdEstatusPedido = datard.GetOrdinal("IdEstatusPedido");
				lbeAdjudicacionesPedidos = new List<beAdjudicacionesPedidos>();
				beAdjudicacionesPedidos obeAdjudicacionesPedidos;
				while (datard.Read())
				{
					 obeAdjudicacionesPedidos = new beAdjudicacionesPedidos();
					obeAdjudicacionesPedidos.IdAdjudicacionPedido =  datard.GetInt32(posIdAdjudicacionPedido);
					obeAdjudicacionesPedidos.IdAdjudicacionProveedor =  datard.GetInt32(posIdAdjudicacionProveedor);
					obeAdjudicacionesPedidos.FolioNumero =  datard.GetInt32(posFolioNumero);
					obeAdjudicacionesPedidos.Folio =  datard.GetString(posFolio);
					obeAdjudicacionesPedidos.FechaPedido =  datard.GetDateTime(posFechaPedido);
					obeAdjudicacionesPedidos.IdProveedor =  datard.GetInt32(posIdProveedor);
					obeAdjudicacionesPedidos.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
					obeAdjudicacionesPedidos.Importe =  datard.GetDecimal(posImporte);
					obeAdjudicacionesPedidos.ImporteIva =  datard.GetDecimal(posImporteIva);
					obeAdjudicacionesPedidos.Total =  datard.GetDecimal(posTotal);
					obeAdjudicacionesPedidos.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeAdjudicacionesPedidos.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					obeAdjudicacionesPedidos.IdEstatusPedido =  datard.GetInt32(posIdEstatusPedido);
			// debe agregar campos de la Vista
					lbeAdjudicacionesPedidos.Add(obeAdjudicacionesPedidos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesPedidos;
		}
	}
}
}

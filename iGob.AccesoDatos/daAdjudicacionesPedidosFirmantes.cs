using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daAdjudicacionesPedidosFirmantes
 {
	public int guardarAdjudicacionesPedidosFirmantes(SqlConnection Conexion, beAdjudicacionesPedidosFirmantes obeAdjudicacionesPedidosFirmantes)
	{
		int Id=0;
		string sp = "Proc_AdjudicacionesPedidosFirmantesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionPedidoFirmante", SqlDbType.Int).Value = obeAdjudicacionesPedidosFirmantes.IdAdjudicacionPedidoFirmante;
				cmd.Parameters.Add("@IdAdjudicacionPedido", SqlDbType.Int).Value = obeAdjudicacionesPedidosFirmantes.IdAdjudicacionPedido;
				cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = obeAdjudicacionesPedidosFirmantes.IdPerfil;
				cmd.Parameters.Add("@Ordenamiento", SqlDbType.Int).Value = obeAdjudicacionesPedidosFirmantes.Ordenamiento;
				cmd.Parameters.Add("@Cargo", SqlDbType.NVarChar).Value = obeAdjudicacionesPedidosFirmantes.Cargo;
				cmd.Parameters.Add("@IdEstatusFirmaPedido", SqlDbType.Int).Value = obeAdjudicacionesPedidosFirmantes.IdEstatusFirmaPedido;
				cmd.Parameters.Add("@IdUsuarioFirmante", SqlDbType.Int).Value = obeAdjudicacionesPedidosFirmantes.IdUsuarioFirmante;
				cmd.Parameters.Add("@FechaFirma", SqlDbType.DateTime).Value = obeAdjudicacionesPedidosFirmantes.FechaFirma;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarAdjudicacionesPedidosFirmantes(SqlConnection Conexion, beAdjudicacionesPedidosFirmantes obeAdjudicacionesPedidosFirmantes)
	{
		string sp = "Proc_AdjudicacionesPedidosFirmantesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionPedidoFirmante", SqlDbType.Int).Value = obeAdjudicacionesPedidosFirmantes.IdAdjudicacionPedidoFirmante;
				cmd.Parameters.Add("@IdAdjudicacionPedido", SqlDbType.Int).Value = obeAdjudicacionesPedidosFirmantes.IdAdjudicacionPedido;
				cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = obeAdjudicacionesPedidosFirmantes.IdPerfil;
				cmd.Parameters.Add("@Ordenamiento", SqlDbType.Int).Value = obeAdjudicacionesPedidosFirmantes.Ordenamiento;
				cmd.Parameters.Add("@Cargo", SqlDbType.NVarChar).Value = obeAdjudicacionesPedidosFirmantes.Cargo;
				cmd.Parameters.Add("@IdEstatusFirmaPedido", SqlDbType.Int).Value = obeAdjudicacionesPedidosFirmantes.IdEstatusFirmaPedido;
				cmd.Parameters.Add("@IdUsuarioFirmante", SqlDbType.Int).Value = obeAdjudicacionesPedidosFirmantes.IdUsuarioFirmante;
				cmd.Parameters.Add("@FechaFirma", SqlDbType.DateTime).Value = obeAdjudicacionesPedidosFirmantes.FechaFirma;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarAdjudicacionesPedidosFirmantes(SqlConnection Conexion,int pIdAdjudicacionPedidoFirmante)
	{
		string sp = "Proc_AdjudicacionesPedidosFirmantesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionPedidoFirmante", SqlDbType.Int).Value = pIdAdjudicacionPedidoFirmante;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beAdjudicacionesPedidosFirmantes traerAdjudicacionesPedidosFirmantes_x_IdAdjudicacionPedidoFirmante(SqlConnection Conexion,int IdAdjudicacionPedidoFirmante)
	{
		string sp = "Proc_AdjudicacionesPedidosFirmantes_x_IdAdjudicacionPedidoFirmante";
				beAdjudicacionesPedidosFirmantes obeAdjudicacionesPedidosFirmantes=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdAdjudicacionPedidoFirmante", SqlDbType.Int).Value = IdAdjudicacionPedidoFirmante;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdAdjudicacionPedidoFirmante = datard.GetOrdinal("IdAdjudicacionPedidoFirmante");
						int posIdAdjudicacionPedido = datard.GetOrdinal("IdAdjudicacionPedido");
						int posIdPerfil = datard.GetOrdinal("IdPerfil");
						int posOrdenamiento = datard.GetOrdinal("Ordenamiento");
						int posCargo = datard.GetOrdinal("Cargo");
						int posIdEstatusFirmaPedido = datard.GetOrdinal("IdEstatusFirmaPedido");
						int posIdUsuarioFirmante = datard.GetOrdinal("IdUsuarioFirmante");
						int posFechaFirma = datard.GetOrdinal("FechaFirma");
					 obeAdjudicacionesPedidosFirmantes = new beAdjudicacionesPedidosFirmantes();
				while (datard.Read())
					{
						obeAdjudicacionesPedidosFirmantes.IdAdjudicacionPedidoFirmante =  datard.GetInt32(posIdAdjudicacionPedidoFirmante);
						obeAdjudicacionesPedidosFirmantes.IdAdjudicacionPedido =  datard.GetInt32(posIdAdjudicacionPedido);
						obeAdjudicacionesPedidosFirmantes.IdPerfil =  datard.GetInt32(posIdPerfil);
						obeAdjudicacionesPedidosFirmantes.Ordenamiento =  datard.GetInt32(posOrdenamiento);
						obeAdjudicacionesPedidosFirmantes.Cargo =  datard.GetString(posCargo);
						obeAdjudicacionesPedidosFirmantes.IdEstatusFirmaPedido =  datard.GetInt32(posIdEstatusFirmaPedido);
						obeAdjudicacionesPedidosFirmantes.IdUsuarioFirmante =  datard.GetInt32(posIdUsuarioFirmante);
						obeAdjudicacionesPedidosFirmantes.FechaFirma =  datard.GetDateTime(posFechaFirma);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesPedidosFirmantes;
			}
	}
	public List< beAdjudicacionesPedidosFirmantes> listarTodos_AdjudicacionesPedidosFirmantes(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesPedidosFirmantes_Traer_Todos";
		List<beAdjudicacionesPedidosFirmantes> lbeAdjudicacionesPedidosFirmantes = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacionPedidoFirmante = datard.GetOrdinal("IdAdjudicacionPedidoFirmante");
						int posIdAdjudicacionPedido = datard.GetOrdinal("IdAdjudicacionPedido");
						int posIdPerfil = datard.GetOrdinal("IdPerfil");
						int posOrdenamiento = datard.GetOrdinal("Ordenamiento");
						int posCargo = datard.GetOrdinal("Cargo");
						int posIdEstatusFirmaPedido = datard.GetOrdinal("IdEstatusFirmaPedido");
						int posIdUsuarioFirmante = datard.GetOrdinal("IdUsuarioFirmante");
						int posFechaFirma = datard.GetOrdinal("FechaFirma");
				lbeAdjudicacionesPedidosFirmantes = new List<beAdjudicacionesPedidosFirmantes>();
				beAdjudicacionesPedidosFirmantes obeAdjudicacionesPedidosFirmantes;
				while (datard.Read())
				{
					 obeAdjudicacionesPedidosFirmantes = new beAdjudicacionesPedidosFirmantes();
					obeAdjudicacionesPedidosFirmantes.IdAdjudicacionPedidoFirmante =  datard.GetInt32(posIdAdjudicacionPedidoFirmante);
					obeAdjudicacionesPedidosFirmantes.IdAdjudicacionPedido =  datard.GetInt32(posIdAdjudicacionPedido);
					obeAdjudicacionesPedidosFirmantes.IdPerfil =  datard.GetInt32(posIdPerfil);
					obeAdjudicacionesPedidosFirmantes.Ordenamiento =  datard.GetInt32(posOrdenamiento);
					obeAdjudicacionesPedidosFirmantes.Cargo =  datard.GetString(posCargo);
					obeAdjudicacionesPedidosFirmantes.IdEstatusFirmaPedido =  datard.GetInt32(posIdEstatusFirmaPedido);
					obeAdjudicacionesPedidosFirmantes.IdUsuarioFirmante = datard[posIdUsuarioFirmante] == DBNull.Value ? Int32.MinValue : datard.GetInt32(posIdUsuarioFirmante);// datard.GetInt32(posIdUsuarioFirmante);
					obeAdjudicacionesPedidosFirmantes.FechaFirma = datard[posFechaFirma] == DBNull.Value ? DateTime.Now : datard.GetDateTime(posFechaFirma);// datard.GetDateTime(posFechaFirma);
					lbeAdjudicacionesPedidosFirmantes.Add(obeAdjudicacionesPedidosFirmantes);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesPedidosFirmantes;
		}
	}
	public List< beAdjudicacionesPedidosFirmantes> listar_AdjudicacionesPedidosFirmantes_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesPedidosFirmantes_TraerTodos_GetAll";
		List<beAdjudicacionesPedidosFirmantes> lbeAdjudicacionesPedidosFirmantes = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacionPedidoFirmante = datard.GetOrdinal("IdAdjudicacionPedidoFirmante");
						int posIdAdjudicacionPedido = datard.GetOrdinal("IdAdjudicacionPedido");
						int posIdPerfil = datard.GetOrdinal("IdPerfil");
						int posOrdenamiento = datard.GetOrdinal("Ordenamiento");
						int posCargo = datard.GetOrdinal("Cargo");
						int posIdEstatusFirmaPedido = datard.GetOrdinal("IdEstatusFirmaPedido");
						int posIdUsuarioFirmante = datard.GetOrdinal("IdUsuarioFirmante");
						int posFechaFirma = datard.GetOrdinal("FechaFirma");
				lbeAdjudicacionesPedidosFirmantes = new List<beAdjudicacionesPedidosFirmantes>();
				beAdjudicacionesPedidosFirmantes obeAdjudicacionesPedidosFirmantes;
				while (datard.Read())
				{
					 obeAdjudicacionesPedidosFirmantes = new beAdjudicacionesPedidosFirmantes();
					obeAdjudicacionesPedidosFirmantes.IdAdjudicacionPedidoFirmante =  datard.GetInt32(posIdAdjudicacionPedidoFirmante);
					obeAdjudicacionesPedidosFirmantes.IdAdjudicacionPedido =  datard.GetInt32(posIdAdjudicacionPedido);
					obeAdjudicacionesPedidosFirmantes.IdPerfil =  datard.GetInt32(posIdPerfil);
					obeAdjudicacionesPedidosFirmantes.Ordenamiento =  datard.GetInt32(posOrdenamiento);
					obeAdjudicacionesPedidosFirmantes.Cargo =  datard.GetString(posCargo);
					obeAdjudicacionesPedidosFirmantes.IdEstatusFirmaPedido =  datard.GetInt32(posIdEstatusFirmaPedido);
					obeAdjudicacionesPedidosFirmantes.IdUsuarioFirmante =  datard.GetInt32(posIdUsuarioFirmante);
					obeAdjudicacionesPedidosFirmantes.FechaFirma =  datard.GetDateTime(posFechaFirma);
			// debe agregar campos de la Vista
					lbeAdjudicacionesPedidosFirmantes.Add(obeAdjudicacionesPedidosFirmantes);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesPedidosFirmantes;
		}
	}
}
}

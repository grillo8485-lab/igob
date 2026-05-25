using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daPedidosFirmantes
 {
	public int guardarPedidosFirmantes(SqlConnection Conexion, bePedidosFirmantes obePedidosFirmantes)
	{
		int Id=0;
		string sp = "Proc_PedidosFirmantesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPedidoFirmante", SqlDbType.Int).Value = obePedidosFirmantes.IdPedidoFirmante;
				cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = obePedidosFirmantes.IdPedido;
				cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = obePedidosFirmantes.IdPerfil;
				cmd.Parameters.Add("@Ordenamiento", SqlDbType.Int).Value = obePedidosFirmantes.Ordenamiento;
				cmd.Parameters.Add("@Cargo", SqlDbType.NVarChar).Value = obePedidosFirmantes.Cargo;
				cmd.Parameters.Add("@IdEstatusFirmaPedido", SqlDbType.Int).Value = obePedidosFirmantes.IdEstatusFirmaPedido;
				cmd.Parameters.Add("@IdUsuarioFirmante", SqlDbType.Int).Value = obePedidosFirmantes.IdUsuarioFirmante;
				cmd.Parameters.Add("@FechaFirma", SqlDbType.DateTime).Value = obePedidosFirmantes.FechaFirma;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarPedidosFirmantes(SqlConnection Conexion, bePedidosFirmantes obePedidosFirmantes)
	{
		string sp = "Proc_PedidosFirmantesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPedidoFirmante", SqlDbType.Int).Value = obePedidosFirmantes.IdPedidoFirmante;
				cmd.Parameters.Add("@IdPedido", SqlDbType.Int).Value = obePedidosFirmantes.IdPedido;
				cmd.Parameters.Add("@IdPerfil", SqlDbType.Int).Value = obePedidosFirmantes.IdPerfil;
				cmd.Parameters.Add("@Ordenamiento", SqlDbType.Int).Value = obePedidosFirmantes.Ordenamiento;
				cmd.Parameters.Add("@Cargo", SqlDbType.NVarChar).Value = obePedidosFirmantes.Cargo;
				cmd.Parameters.Add("@IdEstatusFirmaPedido", SqlDbType.Int).Value = obePedidosFirmantes.IdEstatusFirmaPedido;
				cmd.Parameters.Add("@IdUsuarioFirmante", SqlDbType.Int).Value = obePedidosFirmantes.IdUsuarioFirmante;
				cmd.Parameters.Add("@FechaFirma", SqlDbType.DateTime).Value = obePedidosFirmantes.FechaFirma;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarPedidosFirmantes(SqlConnection Conexion,int pIdPedidoFirmante)
	{
		string sp = "Proc_PedidosFirmantesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPedidoFirmante", SqlDbType.Int).Value = pIdPedidoFirmante;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public bePedidosFirmantes traerPedidosFirmantes_x_IdPedidoFirmante(SqlConnection Conexion,int IdPedidoFirmante)
	{
		string sp = "Proc_PedidosFirmantes_x_IdPedidoFirmante";
				bePedidosFirmantes obePedidosFirmantes=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdPedidoFirmante", SqlDbType.Int).Value = IdPedidoFirmante;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdPedidoFirmante = datard.GetOrdinal("IdPedidoFirmante");
						int posIdPedido = datard.GetOrdinal("IdPedido");
						int posIdPerfil = datard.GetOrdinal("IdPerfil");
						int posOrdenamiento = datard.GetOrdinal("Ordenamiento");
						int posCargo = datard.GetOrdinal("Cargo");
						int posIdEstatusFirmaPedido = datard.GetOrdinal("IdEstatusFirmaPedido");
						int posIdUsuarioFirmante = datard.GetOrdinal("IdUsuarioFirmante");
						int posFechaFirma = datard.GetOrdinal("FechaFirma");
					 obePedidosFirmantes = new bePedidosFirmantes();
				while (datard.Read())
					{
						obePedidosFirmantes.IdPedidoFirmante =  datard.GetInt32(posIdPedidoFirmante);
						obePedidosFirmantes.IdPedido =  datard.GetInt32(posIdPedido);
						obePedidosFirmantes.IdPerfil =  datard.GetInt32(posIdPerfil);
						obePedidosFirmantes.Ordenamiento =  datard.GetInt32(posOrdenamiento);
						obePedidosFirmantes.Cargo =  datard.GetString(posCargo);
						obePedidosFirmantes.IdEstatusFirmaPedido =  datard.GetInt32(posIdEstatusFirmaPedido);
						obePedidosFirmantes.IdUsuarioFirmante = datard[posIdUsuarioFirmante]== DBNull.Value?0: datard.GetInt32(posIdUsuarioFirmante);
						obePedidosFirmantes.FechaFirma = datard[posFechaFirma] == DBNull.Value ? DateTime.Now : datard.GetDateTime(posFechaFirma);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obePedidosFirmantes;
			}
	}
	public List< bePedidosFirmantes> listarTodos_PedidosFirmantes(SqlConnection Conexion)
	 {
		string sp = "Proc_PedidosFirmantes_Traer_Todos";
		List<bePedidosFirmantes> lbePedidosFirmantes = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdPedidoFirmante = datard.GetOrdinal("IdPedidoFirmante");
						int posIdPedido = datard.GetOrdinal("IdPedido");
						int posIdPerfil = datard.GetOrdinal("IdPerfil");
						int posOrdenamiento = datard.GetOrdinal("Ordenamiento");
						int posCargo = datard.GetOrdinal("Cargo");
						int posIdEstatusFirmaPedido = datard.GetOrdinal("IdEstatusFirmaPedido");
						int posIdUsuarioFirmante = datard.GetOrdinal("IdUsuarioFirmante");
						int posFechaFirma = datard.GetOrdinal("FechaFirma");
				lbePedidosFirmantes = new List<bePedidosFirmantes>();
				bePedidosFirmantes obePedidosFirmantes;
				while (datard.Read())
				{
					 obePedidosFirmantes = new bePedidosFirmantes();
					obePedidosFirmantes.IdPedidoFirmante =  datard.GetInt32(posIdPedidoFirmante);
					obePedidosFirmantes.IdPedido =  datard.GetInt32(posIdPedido);
					obePedidosFirmantes.IdPerfil =  datard.GetInt32(posIdPerfil);
					obePedidosFirmantes.Ordenamiento =  datard.GetInt32(posOrdenamiento);
					obePedidosFirmantes.Cargo =  datard.GetString(posCargo);
					obePedidosFirmantes.IdEstatusFirmaPedido =  datard.GetInt32(posIdEstatusFirmaPedido);
					obePedidosFirmantes.IdUsuarioFirmante =  datard.GetInt32(posIdUsuarioFirmante);
					obePedidosFirmantes.FechaFirma =  datard.GetDateTime(posFechaFirma);
					lbePedidosFirmantes.Add(obePedidosFirmantes);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePedidosFirmantes;
		}
	}
	public List< bePedidosFirmantes> listar_PedidosFirmantes_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_PedidosFirmantes_TraerTodos_GetAll";
		List<bePedidosFirmantes> lbePedidosFirmantes = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdPedidoFirmante = datard.GetOrdinal("IdPedidoFirmante");
						int posIdPedido = datard.GetOrdinal("IdPedido");
						int posIdPerfil = datard.GetOrdinal("IdPerfil");
						int posOrdenamiento = datard.GetOrdinal("Ordenamiento");
						int posCargo = datard.GetOrdinal("Cargo");
						int posIdEstatusFirmaPedido = datard.GetOrdinal("IdEstatusFirmaPedido");
						int posIdUsuarioFirmante = datard.GetOrdinal("IdUsuarioFirmante");
						int posFechaFirma = datard.GetOrdinal("FechaFirma");
				lbePedidosFirmantes = new List<bePedidosFirmantes>();
				bePedidosFirmantes obePedidosFirmantes;
				while (datard.Read())
				{
					 obePedidosFirmantes = new bePedidosFirmantes();
					obePedidosFirmantes.IdPedidoFirmante =  datard.GetInt32(posIdPedidoFirmante);
					obePedidosFirmantes.IdPedido =  datard.GetInt32(posIdPedido);
					obePedidosFirmantes.IdPerfil =  datard.GetInt32(posIdPerfil);
					obePedidosFirmantes.Ordenamiento =  datard.GetInt32(posOrdenamiento);
					obePedidosFirmantes.Cargo =  datard.GetString(posCargo);
					obePedidosFirmantes.IdEstatusFirmaPedido =  datard.GetInt32(posIdEstatusFirmaPedido);
					obePedidosFirmantes.IdUsuarioFirmante =  datard.GetInt32(posIdUsuarioFirmante);
					obePedidosFirmantes.FechaFirma =  datard.GetDateTime(posFechaFirma);
			// debe agregar campos de la Vista
					lbePedidosFirmantes.Add(obePedidosFirmantes);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbePedidosFirmantes;
		}
	}
}
}

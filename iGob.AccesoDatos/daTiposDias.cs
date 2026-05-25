using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daTiposDias
 {
	public int guardarTiposDias(SqlConnection Conexion, beTiposDias obeTiposDias)
	{
		int Id=0;
		string sp = "Proc_TiposDiasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoDia", SqlDbType.Int).Value = obeTiposDias.IdTipoDia;
				cmd.Parameters.Add("@TipoDia", SqlDbType.NVarChar).Value = obeTiposDias.TipoDia;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarTiposDias(SqlConnection Conexion, beTiposDias obeTiposDias)
	{
		string sp = "Proc_TiposDiasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoDia", SqlDbType.Int).Value = obeTiposDias.IdTipoDia;
				cmd.Parameters.Add("@TipoDia", SqlDbType.NVarChar).Value = obeTiposDias.TipoDia;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarTiposDias(SqlConnection Conexion,int pIdTipoDia)
	{
		string sp = "Proc_TiposDiasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoDia", SqlDbType.Int).Value = pIdTipoDia;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beTiposDias traerTiposDias_x_IdTipoDia(SqlConnection Conexion,int IdTipoDia)
	{
		string sp = "Proc_TiposDias_x_IdTipoDia";
				beTiposDias obeTiposDias=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoDia", SqlDbType.Int).Value = IdTipoDia;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdTipoDia = datard.GetOrdinal("IdTipoDia");
						int posTipoDia = datard.GetOrdinal("TipoDia");
					 obeTiposDias = new beTiposDias();
				while (datard.Read())
					{
						obeTiposDias.IdTipoDia =  datard.GetInt32(posIdTipoDia);
						obeTiposDias.TipoDia =  datard.GetString(posTipoDia);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposDias;
			}
	}
	public List< beTiposDias> listarTodos_TiposDias(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposDias_Traer_Todos";
		List<beTiposDias> lbeTiposDias = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdTipoDia = datard.GetOrdinal("IdTipoDia");
						int posTipoDia = datard.GetOrdinal("TipoDia");
				lbeTiposDias = new List<beTiposDias>();
				beTiposDias obeTiposDias;
				while (datard.Read())
				{
					 obeTiposDias = new beTiposDias();
					obeTiposDias.IdTipoDia =  datard.GetInt32(posIdTipoDia);
					obeTiposDias.TipoDia =  datard.GetString(posTipoDia);
					lbeTiposDias.Add(obeTiposDias);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposDias;
		}
	}
	public List< beTiposDias> listar_TiposDias_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposDias_TraerTodos_GetAll";
		List<beTiposDias> lbeTiposDias = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdTipoDia = datard.GetOrdinal("IdTipoDia");
						int posTipoDia = datard.GetOrdinal("TipoDia");
				lbeTiposDias = new List<beTiposDias>();
				beTiposDias obeTiposDias;
				while (datard.Read())
				{
					 obeTiposDias = new beTiposDias();
					obeTiposDias.IdTipoDia =  datard.GetInt32(posIdTipoDia);
					obeTiposDias.TipoDia =  datard.GetString(posTipoDia);
			// debe agregar campos de la Vista
					lbeTiposDias.Add(obeTiposDias);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposDias;
		}
	}
}
}

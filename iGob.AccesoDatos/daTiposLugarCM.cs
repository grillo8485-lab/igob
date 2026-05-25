using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daTiposLugarCM
 {
	public int guardarTiposLugarCM(SqlConnection Conexion, beTiposLugarCM obeTiposLugarCM)
	{
		int Id=0;
		string sp = "Proc_TiposLugarCMInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoLugarCM", SqlDbType.Int).Value = obeTiposLugarCM.IdTipoLugarCM;
				cmd.Parameters.Add("@TipoLugar", SqlDbType.NChar).Value = obeTiposLugarCM.TipoLugar;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposLugarCM.Activo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarTiposLugarCM(SqlConnection Conexion, beTiposLugarCM obeTiposLugarCM)
	{
		string sp = "Proc_TiposLugarCMActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoLugarCM", SqlDbType.Int).Value = obeTiposLugarCM.IdTipoLugarCM;
				cmd.Parameters.Add("@TipoLugar", SqlDbType.NChar).Value = obeTiposLugarCM.TipoLugar;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposLugarCM.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarTiposLugarCM(SqlConnection Conexion,int pIdTipoLugarCM)
	{
		string sp = "Proc_TiposLugarCMEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoLugarCM", SqlDbType.Int).Value = pIdTipoLugarCM;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beTiposLugarCM traerTiposLugarCM_x_IdTipoLugarCM(SqlConnection Conexion,int IdTipoLugarCM)
	{
		string sp = "Proc_TiposLugarCM_x_IdTipoLugarCM";
				beTiposLugarCM obeTiposLugarCM=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoLugarCM", SqlDbType.Int).Value = IdTipoLugarCM;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdTipoLugarCM = datard.GetOrdinal("IdTipoLugarCM");
						int posTipoLugar = datard.GetOrdinal("TipoLugar");
						int posActivo = datard.GetOrdinal("Activo");
					 obeTiposLugarCM = new beTiposLugarCM();
				while (datard.Read())
					{
						obeTiposLugarCM.IdTipoLugarCM =  datard.GetInt32(posIdTipoLugarCM);
						obeTiposLugarCM.TipoLugar =  datard.GetString(posTipoLugar);
						obeTiposLugarCM.Activo =  datard.GetBoolean(posActivo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposLugarCM;
			}
	}
	public List< beTiposLugarCM> listarTodos_TiposLugarCM(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposLugarCM_Traer_Todos";
		List<beTiposLugarCM> lbeTiposLugarCM = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdTipoLugarCM = datard.GetOrdinal("IdTipoLugarCM");
						int posTipoLugar = datard.GetOrdinal("TipoLugar");
						int posActivo = datard.GetOrdinal("Activo");
				lbeTiposLugarCM = new List<beTiposLugarCM>();
				beTiposLugarCM obeTiposLugarCM;
				while (datard.Read())
				{
					 obeTiposLugarCM = new beTiposLugarCM();
					obeTiposLugarCM.IdTipoLugarCM =  datard.GetInt32(posIdTipoLugarCM);
					obeTiposLugarCM.TipoLugar =  datard.GetString(posTipoLugar);
					obeTiposLugarCM.Activo =  datard.GetBoolean(posActivo);
					lbeTiposLugarCM.Add(obeTiposLugarCM);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposLugarCM;
		}
	}
	public List< beTiposLugarCM> listar_TiposLugarCM_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposLugarCM_TraerTodos_GetAll";
		List<beTiposLugarCM> lbeTiposLugarCM = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdTipoLugarCM = datard.GetOrdinal("IdTipoLugarCM");
						int posTipoLugar = datard.GetOrdinal("TipoLugar");
						int posActivo = datard.GetOrdinal("Activo");
				lbeTiposLugarCM = new List<beTiposLugarCM>();
				beTiposLugarCM obeTiposLugarCM;
				while (datard.Read())
				{
					 obeTiposLugarCM = new beTiposLugarCM();
					obeTiposLugarCM.IdTipoLugarCM =  datard.GetInt32(posIdTipoLugarCM);
					obeTiposLugarCM.TipoLugar =  datard.GetString(posTipoLugar);
					obeTiposLugarCM.Activo =  datard.GetBoolean(posActivo);
			// debe agregar campos de la Vista
					lbeTiposLugarCM.Add(obeTiposLugarCM);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposLugarCM;
		}
	}
}
}

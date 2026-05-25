using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daTiempos
 {
	public int guardarTiempos(SqlConnection Conexion, beTiempos obeTiempos)
	{
		int Id=0;
		string sp = "Proc_TiemposInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTiempo", SqlDbType.Int).Value = obeTiempos.IdTiempo;
				cmd.Parameters.Add("@Tiempo", SqlDbType.VarChar).Value = obeTiempos.Tiempo;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiempos.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarTiempos(SqlConnection Conexion, beTiempos obeTiempos)
	{
		string sp = "Proc_TiemposActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTiempo", SqlDbType.Int).Value = obeTiempos.IdTiempo;
				cmd.Parameters.Add("@Tiempo", SqlDbType.VarChar).Value = obeTiempos.Tiempo;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiempos.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarTiempos(SqlConnection Conexion,int pIdTiempo)
	{
		string sp = "Proc_TiemposEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTiempo", SqlDbType.Int).Value = pIdTiempo;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beTiempos traerTiempos_x_IdTiempo(SqlConnection Conexion,int IdTiempo)
	{
		string sp = "Proc_Tiempos_x_IdTiempo";
		List<beTiempos> lbeTiempos = null;
				beTiempos obeTiempos=new beTiempos();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTiempo", SqlDbType.Int).Value = IdTiempo;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeTiempos = new List<beTiempos>();
				while (datard.Read())
					{
					 obeTiempos = new beTiempos();
						obeTiempos.IdTiempo =  datard.GetInt32(0);
						obeTiempos.Tiempo =  datard.GetString(1);
						obeTiempos.Activo =  datard.GetBoolean(2);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiempos;
			}
	}
	public List< beTiempos> listarTodos_Tiempos(SqlConnection Conexion)
	 {
		string sp = "Proc_Tiempos_Traer_Todos";
		List<beTiempos> lbeTiempos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeTiempos = new List<beTiempos>();
				beTiempos obeTiempos;
				while (datard.Read())
				{
					 obeTiempos = new beTiempos();
					obeTiempos.IdTiempo =  datard.GetInt32(0);
					obeTiempos.Tiempo =  datard.GetString(1);
					obeTiempos.Activo =  datard.GetBoolean(2);
					lbeTiempos.Add(obeTiempos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiempos;
		}
	}
	public DataTable listarTiempos_x_(SqlConnection Conexion,int IdTiempo)
	 {
		string sp = "Proc_Tiempos_Traer_Todos";
		DataTable dtTiempos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTiempo", SqlDbType.Int).Value = IdTiempo;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtTiempos = new DataTable();
				dtTiempos.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtTiempos;
		}
	}
}
}

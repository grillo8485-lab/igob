using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daTiposLugar
 {
	public int guardarTiposLugar(SqlConnection Conexion, beTiposLugar obeTiposLugar)
	{
		int Id=0;
		string sp = "Proc_TiposLugarInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoLugar", SqlDbType.Int).Value = obeTiposLugar.IdTipoLugar;
				cmd.Parameters.Add("@TipoLugar", SqlDbType.NChar).Value = obeTiposLugar.TipoLugar;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposLugar.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarTiposLugar(SqlConnection Conexion, beTiposLugar obeTiposLugar)
	{
		string sp = "Proc_TiposLugarActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoLugar", SqlDbType.Int).Value = obeTiposLugar.IdTipoLugar;
				cmd.Parameters.Add("@TipoLugar", SqlDbType.NChar).Value = obeTiposLugar.TipoLugar;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposLugar.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarTiposLugar(SqlConnection Conexion,int pIdTipoLugar)
	{
		string sp = "Proc_TiposLugarEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoLugar", SqlDbType.Int).Value = pIdTipoLugar;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beTiposLugar traerTiposLugar_x_IdTipoLugar(SqlConnection Conexion,int IdTipoLugar)
	{
		string sp = "Proc_TiposLugar_x_IdTipoLugar";
		List<beTiposLugar> lbeTiposLugar = null;
				beTiposLugar obeTiposLugar=new beTiposLugar();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoLugar", SqlDbType.Int).Value = IdTipoLugar;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeTiposLugar = new List<beTiposLugar>();
				while (datard.Read())
					{
					 obeTiposLugar = new beTiposLugar();
						obeTiposLugar.IdTipoLugar =  datard.GetInt32(0);
						obeTiposLugar.TipoLugar =  datard.GetString(1);
						obeTiposLugar.Activo =  datard.GetBoolean(2);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposLugar;
			}
	}
	public List< beTiposLugar> listarTodos_TiposLugar(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposLugar_Traer_Todos";
		List<beTiposLugar> lbeTiposLugar = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeTiposLugar = new List<beTiposLugar>();
				beTiposLugar obeTiposLugar;
				while (datard.Read())
				{
					 obeTiposLugar = new beTiposLugar();
					obeTiposLugar.IdTipoLugar =  datard.GetInt32(0);
					obeTiposLugar.TipoLugar =  datard.GetString(1);
					obeTiposLugar.Activo =  datard.GetBoolean(2);
					lbeTiposLugar.Add(obeTiposLugar);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposLugar;
		}
	}
	public DataTable listarTiposLugar_x_(SqlConnection Conexion,int IdTipoLugar)
	 {
		string sp = "Proc_TiposLugar_Traer_Todos";
		DataTable dtTiposLugar = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoLugar", SqlDbType.Int).Value = IdTipoLugar;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtTiposLugar = new DataTable();
				dtTiposLugar.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtTiposLugar;
		}
	}
}
}

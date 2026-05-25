using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daTiposCondiciones
 {
	public int guardarTiposCondiciones(SqlConnection Conexion, beTiposCondiciones obeTiposCondiciones)
	{
		int Id=0;
		string sp = "Proc_TiposCondicionesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoCondicion", SqlDbType.Int).Value = obeTiposCondiciones.IdTipoCondicion;
				cmd.Parameters.Add("@TipoCondicion", SqlDbType.NChar).Value = obeTiposCondiciones.TipoCondicion;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposCondiciones.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarTiposCondiciones(SqlConnection Conexion, beTiposCondiciones obeTiposCondiciones)
	{
		string sp = "Proc_TiposCondicionesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoCondicion", SqlDbType.Int).Value = obeTiposCondiciones.IdTipoCondicion;
				cmd.Parameters.Add("@TipoCondicion", SqlDbType.NChar).Value = obeTiposCondiciones.TipoCondicion;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposCondiciones.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarTiposCondiciones(SqlConnection Conexion,int pIdTipoCondicion)
	{
		string sp = "Proc_TiposCondicionesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoCondicion", SqlDbType.Int).Value = pIdTipoCondicion;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beTiposCondiciones traerTiposCondiciones_x_IdTipoCondicion(SqlConnection Conexion,int IdTipoCondicion)
	{
		string sp = "Proc_TiposCondiciones_x_IdTipoCondicion";
		List<beTiposCondiciones> lbeTiposCondiciones = null;
				beTiposCondiciones obeTiposCondiciones=new beTiposCondiciones();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoCondicion", SqlDbType.Int).Value = IdTipoCondicion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeTiposCondiciones = new List<beTiposCondiciones>();
				while (datard.Read())
					{
					 obeTiposCondiciones = new beTiposCondiciones();
						obeTiposCondiciones.IdTipoCondicion =  datard.GetInt32(0);
						obeTiposCondiciones.TipoCondicion =  datard.GetString(1);
						obeTiposCondiciones.Activo =  datard.GetBoolean(2);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposCondiciones;
			}
	}
	public List< beTiposCondiciones> listarTodos_TiposCondiciones(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposCondiciones_Traer_Todos";
		List<beTiposCondiciones> lbeTiposCondiciones = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeTiposCondiciones = new List<beTiposCondiciones>();
				beTiposCondiciones obeTiposCondiciones;
				while (datard.Read())
				{
					 obeTiposCondiciones = new beTiposCondiciones();
					obeTiposCondiciones.IdTipoCondicion =  datard.GetInt32(0);
					obeTiposCondiciones.TipoCondicion =  datard.GetString(1);
					obeTiposCondiciones.Activo =  datard.GetBoolean(2);
					lbeTiposCondiciones.Add(obeTiposCondiciones);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposCondiciones;
		}
	}
	public DataTable listarTiposCondiciones_x_(SqlConnection Conexion,int IdTipoCondicion)
	 {
		string sp = "Proc_TiposCondiciones_Traer_Todos";
		DataTable dtTiposCondiciones = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoCondicion", SqlDbType.Int).Value = IdTipoCondicion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtTiposCondiciones = new DataTable();
				dtTiposCondiciones.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtTiposCondiciones;
		}
	}
}
}

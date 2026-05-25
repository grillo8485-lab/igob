using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daTiposLicitaciones
 {
	public int guardarTiposLicitaciones(SqlConnection Conexion, beTiposLicitaciones obeTiposLicitaciones)
	{
		int Id=0;
		string sp = "Proc_TiposLicitacionesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoLicitacion", SqlDbType.Int).Value = obeTiposLicitaciones.IdTipoLicitacion;
				cmd.Parameters.Add("@TipoLicitacion", SqlDbType.NVarChar).Value = obeTiposLicitaciones.TipoLicitacion;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarTiposLicitaciones(SqlConnection Conexion, beTiposLicitaciones obeTiposLicitaciones)
	{
		string sp = "Proc_TiposLicitacionesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoLicitacion", SqlDbType.Int).Value = obeTiposLicitaciones.IdTipoLicitacion;
				cmd.Parameters.Add("@TipoLicitacion", SqlDbType.NVarChar).Value = obeTiposLicitaciones.TipoLicitacion;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarTiposLicitaciones(SqlConnection Conexion,int pIdTipoLicitacion)
	{
		string sp = "Proc_TiposLicitacionesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoLicitacion", SqlDbType.Int).Value = pIdTipoLicitacion;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beTiposLicitaciones traerTiposLicitaciones_x_IdTipoLicitacion(SqlConnection Conexion,int IdTipoLicitacion)
	{
		string sp = "Proc_TiposLicitaciones_x_IdTipoLicitacion";
				beTiposLicitaciones obeTiposLicitaciones=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoLicitacion", SqlDbType.Int).Value = IdTipoLicitacion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdTipoLicitacion = datard.GetOrdinal("IdTipoLicitacion");
						int posTipoLicitacion = datard.GetOrdinal("TipoLicitacion");
					 obeTiposLicitaciones = new beTiposLicitaciones();
				while (datard.Read())
					{
						obeTiposLicitaciones.IdTipoLicitacion =  datard.GetInt32(posIdTipoLicitacion);
						obeTiposLicitaciones.TipoLicitacion =  datard.GetString(posTipoLicitacion);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposLicitaciones;
			}
	}
	public List< beTiposLicitaciones> listarTodos_TiposLicitaciones(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposLicitaciones_Traer_Todos";
		List<beTiposLicitaciones> lbeTiposLicitaciones = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdTipoLicitacion = datard.GetOrdinal("IdTipoLicitacion");
						int posTipoLicitacion = datard.GetOrdinal("TipoLicitacion");
				lbeTiposLicitaciones = new List<beTiposLicitaciones>();
				beTiposLicitaciones obeTiposLicitaciones;
				while (datard.Read())
				{
					 obeTiposLicitaciones = new beTiposLicitaciones();
					obeTiposLicitaciones.IdTipoLicitacion =  datard.GetInt32(posIdTipoLicitacion);
					obeTiposLicitaciones.TipoLicitacion =  datard.GetString(posTipoLicitacion);
					lbeTiposLicitaciones.Add(obeTiposLicitaciones);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposLicitaciones;
		}
	}
	public List< beTiposLicitaciones> listar_TiposLicitaciones_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposLicitaciones_TraerTodos_GetAll";
		List<beTiposLicitaciones> lbeTiposLicitaciones = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdTipoLicitacion = datard.GetOrdinal("IdTipoLicitacion");
						int posTipoLicitacion = datard.GetOrdinal("TipoLicitacion");
				lbeTiposLicitaciones = new List<beTiposLicitaciones>();
				beTiposLicitaciones obeTiposLicitaciones;
				while (datard.Read())
				{
					 obeTiposLicitaciones = new beTiposLicitaciones();
					obeTiposLicitaciones.IdTipoLicitacion =  datard.GetInt32(posIdTipoLicitacion);
					obeTiposLicitaciones.TipoLicitacion =  datard.GetString(posTipoLicitacion);
			// debe agregar campos de la Vista
					lbeTiposLicitaciones.Add(obeTiposLicitaciones);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposLicitaciones;
		}
	}
}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daTiposRepresentacion
 {
	public int guardarTiposRepresentacion(SqlConnection Conexion, beTiposRepresentacion obeTiposRepresentacion)
	{
		int Id=0;
		string sp = "Proc_TiposRepresentacionInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoRepresentacion", SqlDbType.Int).Value = obeTiposRepresentacion.IdTipoRepresentacion;
				cmd.Parameters.Add("@TipoRepresentacion", SqlDbType.NVarChar).Value = obeTiposRepresentacion.TipoRepresentacion;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposRepresentacion.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarTiposRepresentacion(SqlConnection Conexion, beTiposRepresentacion obeTiposRepresentacion)
	{
		string sp = "Proc_TiposRepresentacionActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoRepresentacion", SqlDbType.Int).Value = obeTiposRepresentacion.IdTipoRepresentacion;
				cmd.Parameters.Add("@TipoRepresentacion", SqlDbType.NVarChar).Value = obeTiposRepresentacion.TipoRepresentacion;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposRepresentacion.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarTiposRepresentacion(SqlConnection Conexion,int pIdTipoRepresentacion)
	{
		string sp = "Proc_TiposRepresentacionEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoRepresentacion", SqlDbType.Int).Value = pIdTipoRepresentacion;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beTiposRepresentacion traerTiposRepresentacion_x_IdTipoRepresentacion(SqlConnection Conexion,int IdTipoRepresentacion)
	{
		string sp = "Proc_TiposRepresentacion_x_IdTipoRepresentacion";
		List<beTiposRepresentacion> lbeTiposRepresentacion = null;
				beTiposRepresentacion obeTiposRepresentacion=new beTiposRepresentacion();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoRepresentacion", SqlDbType.Int).Value = IdTipoRepresentacion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeTiposRepresentacion = new List<beTiposRepresentacion>();
				while (datard.Read())
					{
					 obeTiposRepresentacion = new beTiposRepresentacion();
						obeTiposRepresentacion.IdTipoRepresentacion =  datard.GetInt32(0);
						obeTiposRepresentacion.TipoRepresentacion =  datard.GetString(1);
						obeTiposRepresentacion.Activo =  datard.GetBoolean(2);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposRepresentacion;
			}
	}
	public List< beTiposRepresentacion> listarTodos_TiposRepresentacion(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposRepresentacion_Traer_Todos";
		List<beTiposRepresentacion> lbeTiposRepresentacion = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeTiposRepresentacion = new List<beTiposRepresentacion>();
				beTiposRepresentacion obeTiposRepresentacion;
				while (datard.Read())
				{
					 obeTiposRepresentacion = new beTiposRepresentacion();
					obeTiposRepresentacion.IdTipoRepresentacion =  datard.GetInt32(0);
					obeTiposRepresentacion.TipoRepresentacion =  datard.GetString(1);
					obeTiposRepresentacion.Activo =  datard.GetBoolean(2);
					lbeTiposRepresentacion.Add(obeTiposRepresentacion);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposRepresentacion;
		}
	}
	public DataTable listarTiposRepresentacion_x_(SqlConnection Conexion,int IdTipoRepresentacion)
	 {
		string sp = "Proc_TiposRepresentacion_Traer_Todos";
		DataTable dtTiposRepresentacion = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoRepresentacion", SqlDbType.Int).Value = IdTipoRepresentacion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtTiposRepresentacion = new DataTable();
				dtTiposRepresentacion.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtTiposRepresentacion;
		}
	}
}
}

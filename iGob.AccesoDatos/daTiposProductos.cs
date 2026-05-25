using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daTiposProductos
 {
	public int guardarTiposProductos(SqlConnection Conexion, beTiposProductos obeTiposProductos)
	{
		int Id=0;
		string sp = "Proc_TiposProductosInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoProducto", SqlDbType.Int).Value = obeTiposProductos.IdTipoProducto;
				cmd.Parameters.Add("@TipoProducto", SqlDbType.NVarChar).Value = obeTiposProductos.TipoProducto;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposProductos.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarTiposProductos(SqlConnection Conexion, beTiposProductos obeTiposProductos)
	{
		string sp = "Proc_TiposProductosActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoProducto", SqlDbType.Int).Value = obeTiposProductos.IdTipoProducto;
				cmd.Parameters.Add("@TipoProducto", SqlDbType.NVarChar).Value = obeTiposProductos.TipoProducto;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeTiposProductos.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarTiposProductos(SqlConnection Conexion,int pIdTipoProducto)
	{
		string sp = "Proc_TiposProductosEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdTipoProducto", SqlDbType.Int).Value = pIdTipoProducto;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beTiposProductos traerTiposProductos_x_IdTipoProducto(SqlConnection Conexion,int IdTipoProducto)
	{
		string sp = "Proc_TiposProductos_x_IdTipoProducto";
		List<beTiposProductos> lbeTiposProductos = null;
				beTiposProductos obeTiposProductos=new beTiposProductos();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoProducto", SqlDbType.Int).Value = IdTipoProducto;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeTiposProductos = new List<beTiposProductos>();
				while (datard.Read())
					{
					 obeTiposProductos = new beTiposProductos();
						obeTiposProductos.IdTipoProducto =  datard.GetInt32(0);
						obeTiposProductos.TipoProducto =  datard.GetString(1);
						obeTiposProductos.Activo =  datard.GetBoolean(2);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeTiposProductos;
			}
	}
	public List< beTiposProductos> listarTodos_TiposProductos(SqlConnection Conexion)
	 {
		string sp = "Proc_TiposProductos_Traer_Todos";
		List<beTiposProductos> lbeTiposProductos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeTiposProductos = new List<beTiposProductos>();
				beTiposProductos obeTiposProductos;
				while (datard.Read())
				{
					 obeTiposProductos = new beTiposProductos();
					obeTiposProductos.IdTipoProducto =  datard.GetInt32(0);
					obeTiposProductos.TipoProducto =  datard.GetString(1);
					obeTiposProductos.Activo =  datard.GetBoolean(2);
					lbeTiposProductos.Add(obeTiposProductos);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeTiposProductos;
		}
	}
	public DataTable listarTiposProductos_x_(SqlConnection Conexion,int IdTipoProducto)
	 {
		string sp = "Proc_TiposProductos_Traer_Todos";
		DataTable dtTiposProductos = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdTipoProducto", SqlDbType.Int).Value = IdTipoProducto;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtTiposProductos = new DataTable();
				dtTiposProductos.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtTiposProductos;
		}
	}
}
}

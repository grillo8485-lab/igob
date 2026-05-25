using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daProductosScian
 {
	public int guardarProductosScian(SqlConnection Conexion, beProductosScian obeProductosScian)
	{
		int Id=0;
		string sp = "Proc_ProductosScianInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdCodigoScian", SqlDbType.Int).Value = obeProductosScian.IdCodigoScian;
				cmd.Parameters.Add("@CodigoScian", SqlDbType.Int).Value = obeProductosScian.CodigoScian;
				cmd.Parameters.Add("@Titulo", SqlDbType.NVarChar).Value = obeProductosScian.Titulo;
				cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = obeProductosScian.Descripcion;
				cmd.Parameters.Add("@Incluye", SqlDbType.NVarChar).Value = obeProductosScian.Incluye;
				cmd.Parameters.Add("@Excluye", SqlDbType.NVarChar).Value = obeProductosScian.Excluye;
				cmd.Parameters.Add("@Productos", SqlDbType.NVarChar).Value = obeProductosScian.Productos;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarProductosScian(SqlConnection Conexion, beProductosScian obeProductosScian)
	{
		string sp = "Proc_ProductosScianActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdCodigoScian", SqlDbType.Int).Value = obeProductosScian.IdCodigoScian;
				cmd.Parameters.Add("@CodigoScian", SqlDbType.Int).Value = obeProductosScian.CodigoScian;
				cmd.Parameters.Add("@Titulo", SqlDbType.NVarChar).Value = obeProductosScian.Titulo;
				cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = obeProductosScian.Descripcion;
				cmd.Parameters.Add("@Incluye", SqlDbType.NVarChar).Value = obeProductosScian.Incluye;
				cmd.Parameters.Add("@Excluye", SqlDbType.NVarChar).Value = obeProductosScian.Excluye;
				cmd.Parameters.Add("@Productos", SqlDbType.NVarChar).Value = obeProductosScian.Productos;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarProductosScian(SqlConnection Conexion,int pIdCodigoScian)
	{
		string sp = "Proc_ProductosScianEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdCodigoScian", SqlDbType.Int).Value = pIdCodigoScian;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beProductosScian traerProductosScian_x_IdCodigoScian(SqlConnection Conexion,int IdCodigoScian)
	{
		string sp = "Proc_ProductosScian_x_IdCodigoScian";
				beProductosScian obeProductosScian=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdCodigoScian", SqlDbType.Int).Value = IdCodigoScian;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdCodigoScian = datard.GetOrdinal("IdCodigoScian");
						int posCodigoScian = datard.GetOrdinal("CodigoScian");
						int posTitulo = datard.GetOrdinal("Titulo");
						int posDescripcion = datard.GetOrdinal("Descripcion");
						int posIncluye = datard.GetOrdinal("Incluye");
						int posExcluye = datard.GetOrdinal("Excluye");
						int posProductos = datard.GetOrdinal("Productos");
					 obeProductosScian = new beProductosScian();
				while (datard.Read())
					{
						obeProductosScian.IdCodigoScian =  datard.GetInt32(posIdCodigoScian);
						obeProductosScian.CodigoScian =  datard.GetInt32(posCodigoScian);
						obeProductosScian.Titulo =  datard.GetString(posTitulo);
						obeProductosScian.Descripcion =  datard.GetString(posDescripcion);
						obeProductosScian.Incluye =  datard.GetString(posIncluye);
						obeProductosScian.Excluye =  datard.GetString(posExcluye);
						obeProductosScian.Productos =  datard.GetString(posProductos);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeProductosScian;
			}
	}
	public List< beProductosScian> listarTodos_ProductosScian(SqlConnection Conexion)
	 {
		string sp = "Proc_ProductosScian_Traer_Todos";
		List<beProductosScian> lbeProductosScian = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdCodigoScian = datard.GetOrdinal("IdCodigoScian");
						int posCodigoScian = datard.GetOrdinal("CodigoScian");
						int posTitulo = datard.GetOrdinal("Titulo");
						int posDescripcion = datard.GetOrdinal("Descripcion");
						int posIncluye = datard.GetOrdinal("Incluye");
						int posExcluye = datard.GetOrdinal("Excluye");
						int posProductos = datard.GetOrdinal("Productos");
				lbeProductosScian = new List<beProductosScian>();
				beProductosScian obeProductosScian;
				while (datard.Read())
				{
					 obeProductosScian = new beProductosScian();
					obeProductosScian.IdCodigoScian =  datard.GetInt32(posIdCodigoScian);
					obeProductosScian.CodigoScian =  datard.GetInt32(posCodigoScian);
					obeProductosScian.Titulo =  datard.GetString(posTitulo);
					obeProductosScian.Descripcion =  datard.GetString(posDescripcion);
					obeProductosScian.Incluye =  datard.GetString(posIncluye);
					obeProductosScian.Excluye =  datard.GetString(posExcluye);
					obeProductosScian.Productos =  datard.GetString(posProductos);
					lbeProductosScian.Add(obeProductosScian);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProductosScian;
		}
	}
	public List< beProductosScian> listar_ProductosScian_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_ProductosScian_TraerTodos_GetAll";
		List<beProductosScian> lbeProductosScian = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdCodigoScian = datard.GetOrdinal("IdCodigoScian");
						int posCodigoScian = datard.GetOrdinal("CodigoScian");
						int posTitulo = datard.GetOrdinal("Titulo");
						int posDescripcion = datard.GetOrdinal("Descripcion");
						int posIncluye = datard.GetOrdinal("Incluye");
						int posExcluye = datard.GetOrdinal("Excluye");
						int posProductos = datard.GetOrdinal("Productos");
				lbeProductosScian = new List<beProductosScian>();
				beProductosScian obeProductosScian;
				while (datard.Read())
				{
					 obeProductosScian = new beProductosScian();
					obeProductosScian.IdCodigoScian =  datard.GetInt32(posIdCodigoScian);
					obeProductosScian.CodigoScian =  datard.GetInt32(posCodigoScian);
					obeProductosScian.Titulo =  datard.GetString(posTitulo);
					obeProductosScian.Descripcion =  datard.GetString(posDescripcion);
					obeProductosScian.Incluye =  datard.GetString(posIncluye);
					obeProductosScian.Excluye =  datard.GetString(posExcluye);
					obeProductosScian.Productos =  datard.GetString(posProductos);
			// debe agregar campos de la Vista
					lbeProductosScian.Add(obeProductosScian);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProductosScian;
		}
	}
}
}

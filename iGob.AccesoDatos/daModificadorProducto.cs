using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daModificadorProducto
 {
	public int guardarModificadorProducto(SqlConnection Conexion, beModificadorProducto obeModificadorProducto)
	{
		int Id=0;
		string sp = "Proc_ModificadorProductoInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdModificador", SqlDbType.Int).Value = obeModificadorProducto.IdModificador;
				cmd.Parameters.Add("@Modificador", SqlDbType.VarChar).Value = obeModificadorProducto.Modificador;
				cmd.Parameters.Add("@ImagenPdf", SqlDbType.VarChar).Value = obeModificadorProducto.ImagenPdf;
				cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = obeModificadorProducto.Codigo;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obeModificadorProducto.Descripcion;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeModificadorProducto.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarModificadorProducto(SqlConnection Conexion, beModificadorProducto obeModificadorProducto)
	{
		string sp = "Proc_ModificadorProductoActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdModificador", SqlDbType.Int).Value = obeModificadorProducto.IdModificador;
				cmd.Parameters.Add("@Modificador", SqlDbType.VarChar).Value = obeModificadorProducto.Modificador;
				cmd.Parameters.Add("@ImagenPdf", SqlDbType.VarChar).Value = obeModificadorProducto.ImagenPdf;
				cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = obeModificadorProducto.Codigo;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obeModificadorProducto.Descripcion;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeModificadorProducto.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarModificadorProducto(SqlConnection Conexion,int pIdModificador)
	{
		string sp = "Proc_ModificadorProductoEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdModificador", SqlDbType.Int).Value = pIdModificador;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beModificadorProducto traerModificadorProducto_x_IdModificador(SqlConnection Conexion,int IdModificador)
	{
		string sp = "Proc_ModificadorProducto_x_IdModificador";
		List<beModificadorProducto> lbeModificadorProducto = null;
				beModificadorProducto obeModificadorProducto=new beModificadorProducto();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdModificador", SqlDbType.Int).Value = IdModificador;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeModificadorProducto = new List<beModificadorProducto>();
				while (datard.Read())
					{
					 obeModificadorProducto = new beModificadorProducto();
						obeModificadorProducto.IdModificador =  datard.GetInt32(0);
						obeModificadorProducto.Modificador =  datard.GetString(1);
						obeModificadorProducto.ImagenPdf =  datard.GetString(2);
						obeModificadorProducto.Codigo =  datard.GetString(3);
						obeModificadorProducto.Descripcion =  datard.GetString(4);
						obeModificadorProducto.Activo =  datard.GetBoolean(5);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeModificadorProducto;
			}
	}
	public List< beModificadorProducto> listarTodos_ModificadorProducto(SqlConnection Conexion)
	 {
		string sp = "Proc_ModificadorProducto_Traer_Todos";
		List<beModificadorProducto> lbeModificadorProducto = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeModificadorProducto = new List<beModificadorProducto>();
				beModificadorProducto obeModificadorProducto;
				while (datard.Read())
				{
					 obeModificadorProducto = new beModificadorProducto();
					obeModificadorProducto.IdModificador =  datard.GetInt32(0);
					obeModificadorProducto.Modificador =  datard.GetString(1);
					obeModificadorProducto.ImagenPdf =  datard.GetString(2);
					obeModificadorProducto.Codigo =  datard.GetString(3);
					obeModificadorProducto.Descripcion =  datard.GetString(4);
					obeModificadorProducto.Activo =  datard.GetBoolean(5);
					lbeModificadorProducto.Add(obeModificadorProducto);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeModificadorProducto;
		}
	}
	public DataTable listarModificadorProducto_x_(SqlConnection Conexion,int IdModificador)
	 {
		string sp = "Proc_ModificadorProducto_Traer_Todos";
		DataTable dtModificadorProducto = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdModificador", SqlDbType.Int).Value = IdModificador;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtModificadorProducto = new DataTable();
				dtModificadorProducto.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtModificadorProducto;
		}
	}
}
}

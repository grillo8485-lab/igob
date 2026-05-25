using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daUnidadesMedidas
 {
	public int guardarUnidadesMedidas(SqlConnection Conexion, beUnidadesMedidas obeUnidadesMedidas)
	{
		int Id=0;
		string sp = "Proc_UnidadesMedidasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdUnidadMedida", SqlDbType.Int).Value = obeUnidadesMedidas.IdUnidadMedida;
				cmd.Parameters.Add("@ClaveUnidadMedida", SqlDbType.Char).Value = obeUnidadesMedidas.ClaveUnidadMedida;
				cmd.Parameters.Add("@UnidadMedida", SqlDbType.VarChar).Value = obeUnidadesMedidas.UnidadMedida;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obeUnidadesMedidas.Descripcion;
				cmd.Parameters.Add("@FechaVigenciaInicial", SqlDbType.DateTime).Value = obeUnidadesMedidas.FechaVigenciaInicial;
				cmd.Parameters.Add("@Simbolo", SqlDbType.NChar).Value = obeUnidadesMedidas.Simbolo;
				cmd.Parameters.Add("@Version", SqlDbType.Char).Value = obeUnidadesMedidas.Version;
				cmd.Parameters.Add("@Formato", SqlDbType.NChar).Value = obeUnidadesMedidas.Formato;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeUnidadesMedidas.Activo;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarUnidadesMedidas(SqlConnection Conexion, beUnidadesMedidas obeUnidadesMedidas)
	{
		string sp = "Proc_UnidadesMedidasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdUnidadMedida", SqlDbType.Int).Value = obeUnidadesMedidas.IdUnidadMedida;
				cmd.Parameters.Add("@ClaveUnidadMedida", SqlDbType.Char).Value = obeUnidadesMedidas.ClaveUnidadMedida;
				cmd.Parameters.Add("@UnidadMedida", SqlDbType.VarChar).Value = obeUnidadesMedidas.UnidadMedida;
				cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = obeUnidadesMedidas.Descripcion;
				cmd.Parameters.Add("@FechaVigenciaInicial", SqlDbType.DateTime).Value = obeUnidadesMedidas.FechaVigenciaInicial;
				cmd.Parameters.Add("@Simbolo", SqlDbType.NChar).Value = obeUnidadesMedidas.Simbolo;
				cmd.Parameters.Add("@Version", SqlDbType.Char).Value = obeUnidadesMedidas.Version;
				cmd.Parameters.Add("@Formato", SqlDbType.NChar).Value = obeUnidadesMedidas.Formato;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeUnidadesMedidas.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarUnidadesMedidas(SqlConnection Conexion,int pIdUnidadMedida)
	{
		string sp = "Proc_UnidadesMedidasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdUnidadMedida", SqlDbType.Int).Value = pIdUnidadMedida;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beUnidadesMedidas traerUnidadesMedidas_x_IdUnidadMedida(SqlConnection Conexion,int IdUnidadMedida)
	{
		string sp = "Proc_UnidadesMedidas_x_IdUnidadMedida";
		List<beUnidadesMedidas> lbeUnidadesMedidas = null;
				beUnidadesMedidas obeUnidadesMedidas=new beUnidadesMedidas();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdUnidadMedida", SqlDbType.Int).Value = IdUnidadMedida;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeUnidadesMedidas = new List<beUnidadesMedidas>();
				while (datard.Read())
					{
					 obeUnidadesMedidas = new beUnidadesMedidas();
						obeUnidadesMedidas.IdUnidadMedida =  datard.GetInt32(0);
						obeUnidadesMedidas.ClaveUnidadMedida =  datard.GetString(1);
						obeUnidadesMedidas.UnidadMedida =  datard.GetString(2);
						obeUnidadesMedidas.Descripcion =  datard.GetString(3);
						obeUnidadesMedidas.FechaVigenciaInicial =  datard.GetDateTime(4);
						obeUnidadesMedidas.Simbolo =  datard.GetString(5);
						obeUnidadesMedidas.Version =  datard.GetString(6);
						obeUnidadesMedidas.Formato =  datard.GetString(7);
						obeUnidadesMedidas.Activo =  datard.GetBoolean(8);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeUnidadesMedidas;
			}
	}
	public List< beUnidadesMedidas> listarTodos_UnidadesMedidas(SqlConnection Conexion)
	 {
		string sp = "Proc_UnidadesMedidas_Traer_Todos";
		List<beUnidadesMedidas> lbeUnidadesMedidas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeUnidadesMedidas = new List<beUnidadesMedidas>();
				beUnidadesMedidas obeUnidadesMedidas;
				while (datard.Read())
				{
					 obeUnidadesMedidas = new beUnidadesMedidas();
					obeUnidadesMedidas.IdUnidadMedida =  datard.GetInt32(0);
					obeUnidadesMedidas.ClaveUnidadMedida =  datard.GetString(1);
					obeUnidadesMedidas.UnidadMedida =  datard.GetString(2);
					obeUnidadesMedidas.Descripcion =  datard.GetString(3);
					obeUnidadesMedidas.FechaVigenciaInicial =  datard.GetDateTime(4);
					obeUnidadesMedidas.Simbolo =  datard.GetString(5);
					obeUnidadesMedidas.Version =  datard.GetString(6);
					obeUnidadesMedidas.Formato =  datard.GetString(7);
					obeUnidadesMedidas.Activo =  datard.GetBoolean(8);
					lbeUnidadesMedidas.Add(obeUnidadesMedidas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeUnidadesMedidas;
		}
	}
	public DataTable listarUnidadesMedidas_x_(SqlConnection Conexion,int IdUnidadMedida)
	 {
		string sp = "Proc_UnidadesMedidas_Traer_Todos";
		DataTable dtUnidadesMedidas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdUnidadMedida", SqlDbType.Int).Value = IdUnidadMedida;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtUnidadesMedidas = new DataTable();
				dtUnidadesMedidas.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtUnidadesMedidas;
		}
	}
}
}

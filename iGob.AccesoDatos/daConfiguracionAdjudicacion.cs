using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SoftHomeDeco.Entidades;

namespace SoftHomeDeco.AccesoDatos
{
public class daConfiguracionAdjudicacion
 {
	public int guardarConfiguracionAdjudicacion(SqlConnection Conexion, beConfiguracionAdjudicacion obeConfiguracionAdjudicacion)
	{
		int Id=0;
		string sp = "Proc_ConfiguracionAdjudicacionInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdConfiguracionAdjudicacion", SqlDbType.Int).Value = obeConfiguracionAdjudicacion.IdConfiguracionAdjudicacion;
				cmd.Parameters.Add("@ConfiguracionAdjudicacion", SqlDbType.NChar).Value = obeConfiguracionAdjudicacion.ConfiguracionAdjudicacion;
				cmd.Parameters.Add("@MontoMinimo", SqlDbType.Decimal).Value = obeConfiguracionAdjudicacion.MontoMinimo;
				cmd.Parameters.Add("@MontoMaximo", SqlDbType.Decimal).Value = obeConfiguracionAdjudicacion.MontoMaximo;
				cmd.Parameters.Add("@IdModalidadRequisicion", SqlDbType.Int).Value = obeConfiguracionAdjudicacion.IdModalidadRequisicion;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarConfiguracionAdjudicacion(SqlConnection Conexion, beConfiguracionAdjudicacion obeConfiguracionAdjudicacion)
	{
		string sp = "Proc_ConfiguracionAdjudicacionActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdConfiguracionAdjudicacion", SqlDbType.Int).Value = obeConfiguracionAdjudicacion.IdConfiguracionAdjudicacion;
				cmd.Parameters.Add("@ConfiguracionAdjudicacion", SqlDbType.NChar).Value = obeConfiguracionAdjudicacion.ConfiguracionAdjudicacion;
				cmd.Parameters.Add("@MontoMinimo", SqlDbType.Decimal).Value = obeConfiguracionAdjudicacion.MontoMinimo;
				cmd.Parameters.Add("@MontoMaximo", SqlDbType.Decimal).Value = obeConfiguracionAdjudicacion.MontoMaximo;
				cmd.Parameters.Add("@IdModalidadRequisicion", SqlDbType.Int).Value = obeConfiguracionAdjudicacion.IdModalidadRequisicion;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarConfiguracionAdjudicacion(SqlConnection Conexion,int pIdConfiguracionAdjudicacion)
	{
		string sp = "Proc_ConfiguracionAdjudicacionEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdConfiguracionAdjudicacion", SqlDbType.Int).Value = pIdConfiguracionAdjudicacion;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beConfiguracionAdjudicacion traerConfiguracionAdjudicacion_x_IdConfiguracionAdjudicacion(SqlConnection Conexion,int IdConfiguracionAdjudicacion)
	{
		string sp = "Proc_ConfiguracionAdjudicacion_x_IdConfiguracionAdjudicacion";
		List<beConfiguracionAdjudicacion> lbeConfiguracionAdjudicacion = null;
				beConfiguracionAdjudicacion obeConfiguracionAdjudicacion=new beConfiguracionAdjudicacion();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdConfiguracionAdjudicacion", SqlDbType.Int).Value = IdConfiguracionAdjudicacion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeConfiguracionAdjudicacion = new List<beConfiguracionAdjudicacion>();
				while (datard.Read())
					{
					 obeConfiguracionAdjudicacion = new beConfiguracionAdjudicacion();
						obeConfiguracionAdjudicacion.IdConfiguracionAdjudicacion =  datard.GetInt32(0);
						obeConfiguracionAdjudicacion.ConfiguracionAdjudicacion =  datard.GetString(1);
						obeConfiguracionAdjudicacion.MontoMinimo =  datard.GetDecimal(2);
						obeConfiguracionAdjudicacion.MontoMaximo =  datard.GetDecimal(3);
						obeConfiguracionAdjudicacion.IdModalidadRequisicion =  datard.GetInt32(4);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeConfiguracionAdjudicacion;
			}
	}
	public List< beConfiguracionAdjudicacion> listarTodos_ConfiguracionAdjudicacion(SqlConnection Conexion)
	 {
		string sp = "Proc_ConfiguracionAdjudicacion_Traer_Todos";
		List<beConfiguracionAdjudicacion> lbeConfiguracionAdjudicacion = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeConfiguracionAdjudicacion = new List<beConfiguracionAdjudicacion>();
				beConfiguracionAdjudicacion obeConfiguracionAdjudicacion;
				while (datard.Read())
				{
					 obeConfiguracionAdjudicacion = new beConfiguracionAdjudicacion();
					obeConfiguracionAdjudicacion.IdConfiguracionAdjudicacion =  datard.GetInt32(0);
					obeConfiguracionAdjudicacion.ConfiguracionAdjudicacion =  datard.GetString(1);
					obeConfiguracionAdjudicacion.MontoMinimo =  datard.GetDecimal(2);
					obeConfiguracionAdjudicacion.MontoMaximo =  datard.GetDecimal(3);
					obeConfiguracionAdjudicacion.IdModalidadRequisicion =  datard.GetInt32(4);
					lbeConfiguracionAdjudicacion.Add(obeConfiguracionAdjudicacion);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeConfiguracionAdjudicacion;
		}
	}
	public DataTable listarConfiguracionAdjudicacion_x_(SqlConnection Conexion,int IdConfiguracionAdjudicacion)
	 {
		string sp = "Proc_ConfiguracionAdjudicacion_Traer_Todos";
		DataTable dtConfiguracionAdjudicacion = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdConfiguracionAdjudicacion", SqlDbType.Int).Value = IdConfiguracionAdjudicacion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtConfiguracionAdjudicacion = new DataTable();
				dtConfiguracionAdjudicacion.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtConfiguracionAdjudicacion;
		}
	}
}
}

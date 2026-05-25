using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daConfiguracionModalidad
 {
	public int guardarConfiguracionModalidad(SqlConnection Conexion, beConfiguracionModalidad obeConfiguracionModalidad)
	{
		int Id=0;
		string sp = "Proc_ConfiguracionModalidadInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdConfiguracionModalidad", SqlDbType.Int).Value = obeConfiguracionModalidad.IdConfiguracionModalidad;
				cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeConfiguracionModalidad.IdGobierno;
				cmd.Parameters.Add("@IdModalidad", SqlDbType.Int).Value = obeConfiguracionModalidad.IdModalidad;
				cmd.Parameters.Add("@MontoMinimo", SqlDbType.Decimal).Value = obeConfiguracionModalidad.MontoMinimo;
				cmd.Parameters.Add("@MontoMaximo", SqlDbType.Decimal).Value = obeConfiguracionModalidad.MontoMaximo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarConfiguracionModalidad(SqlConnection Conexion, beConfiguracionModalidad obeConfiguracionModalidad)
	{
		string sp = "Proc_ConfiguracionModalidadActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdConfiguracionModalidad", SqlDbType.Int).Value = obeConfiguracionModalidad.IdConfiguracionModalidad;
				cmd.Parameters.Add("@IdGobierno", SqlDbType.Int).Value = obeConfiguracionModalidad.IdGobierno;
				cmd.Parameters.Add("@IdModalidad", SqlDbType.Int).Value = obeConfiguracionModalidad.IdModalidad;
				cmd.Parameters.Add("@MontoMinimo", SqlDbType.Decimal).Value = obeConfiguracionModalidad.MontoMinimo;
				cmd.Parameters.Add("@MontoMaximo", SqlDbType.Decimal).Value = obeConfiguracionModalidad.MontoMaximo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarConfiguracionModalidad(SqlConnection Conexion,int pIdConfiguracionModalidad)
	{
		string sp = "Proc_ConfiguracionModalidadEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdConfiguracionModalidad", SqlDbType.Int).Value = pIdConfiguracionModalidad;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beConfiguracionModalidad traerConfiguracionModalidad_x_IdConfiguracionModalidad(SqlConnection Conexion,int IdConfiguracionModalidad)
	{
		string sp = "Proc_ConfiguracionModalidad_x_IdConfiguracionModalidad";
		List<beConfiguracionModalidad> lbeConfiguracionModalidad = null;
				beConfiguracionModalidad obeConfiguracionModalidad=new beConfiguracionModalidad();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdConfiguracionModalidad", SqlDbType.Int).Value = IdConfiguracionModalidad;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeConfiguracionModalidad = new List<beConfiguracionModalidad>();
						int posIdConfiguracionModalidad = datard.GetOrdinal("IdConfiguracionModalidad");
						int posIdGobierno = datard.GetOrdinal("IdGobierno");
						int posIdModalidad = datard.GetOrdinal("IdModalidad");
						int posMontoMinimo = datard.GetOrdinal("MontoMinimo");
						int posMontoMaximo = datard.GetOrdinal("MontoMaximo");
				while (datard.Read())
					{
					 obeConfiguracionModalidad = new beConfiguracionModalidad();
						obeConfiguracionModalidad.IdConfiguracionModalidad =  datard.GetInt32(posIdConfiguracionModalidad);
						obeConfiguracionModalidad.IdGobierno =  datard.GetInt32(posIdGobierno);
						obeConfiguracionModalidad.IdModalidad =  datard.GetInt32(posIdModalidad);
						obeConfiguracionModalidad.MontoMinimo =  datard.GetDecimal(posMontoMinimo);
						obeConfiguracionModalidad.MontoMaximo =  datard.GetDecimal(posMontoMaximo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeConfiguracionModalidad;
			}
	}
	public List< beConfiguracionModalidad> listarTodos_ConfiguracionModalidad(SqlConnection Conexion)
	 {
		string sp = "Proc_ConfiguracionModalidad_Traer_Todos";
		List<beConfiguracionModalidad> lbeConfiguracionModalidad = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdConfiguracionModalidad = datard.GetOrdinal("IdConfiguracionModalidad");
						int posIdGobierno = datard.GetOrdinal("IdGobierno");
						int posIdModalidad = datard.GetOrdinal("IdModalidad");
						int posMontoMinimo = datard.GetOrdinal("MontoMinimo");
						int posMontoMaximo = datard.GetOrdinal("MontoMaximo");
				lbeConfiguracionModalidad = new List<beConfiguracionModalidad>();
				beConfiguracionModalidad obeConfiguracionModalidad;
				while (datard.Read())
				{
					 obeConfiguracionModalidad = new beConfiguracionModalidad();
					obeConfiguracionModalidad.IdConfiguracionModalidad =  datard.GetInt32(posIdConfiguracionModalidad);
					obeConfiguracionModalidad.IdGobierno =  datard.GetInt32(posIdGobierno);
					obeConfiguracionModalidad.IdModalidad =  datard.GetInt32(posIdModalidad);
					obeConfiguracionModalidad.MontoMinimo =  datard.GetDecimal(posMontoMinimo);
					obeConfiguracionModalidad.MontoMaximo =  datard.GetDecimal(posMontoMaximo);
					lbeConfiguracionModalidad.Add(obeConfiguracionModalidad);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeConfiguracionModalidad;
		}
	}
	public List< beConfiguracionModalidad> listar_ConfiguracionModalidad_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_ConfiguracionModalidad_TraerTodos_GetAll";
		List<beConfiguracionModalidad> lbeConfiguracionModalidad = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdConfiguracionModalidad = datard.GetOrdinal("IdConfiguracionModalidad");
						int posIdGobierno = datard.GetOrdinal("IdGobierno");
						int posIdModalidad = datard.GetOrdinal("IdModalidad");
						int posMontoMinimo = datard.GetOrdinal("MontoMinimo");
						int posMontoMaximo = datard.GetOrdinal("MontoMaximo");


				lbeConfiguracionModalidad = new List<beConfiguracionModalidad>();
				beConfiguracionModalidad obeConfiguracionModalidad;
				while (datard.Read())
				{
					 obeConfiguracionModalidad = new beConfiguracionModalidad();
					obeConfiguracionModalidad.IdConfiguracionModalidad =  datard.GetInt32(posIdConfiguracionModalidad);
					obeConfiguracionModalidad.IdGobierno =  datard.GetInt32(posIdGobierno);
					obeConfiguracionModalidad.IdModalidad =  datard.GetInt32(posIdModalidad);
					obeConfiguracionModalidad.MontoMinimo =  datard.GetDecimal(posMontoMinimo);
					obeConfiguracionModalidad.MontoMaximo =  datard.GetDecimal(posMontoMaximo);
			// debe agregar campos de la Vista
					lbeConfiguracionModalidad.Add(obeConfiguracionModalidad);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeConfiguracionModalidad;
		}
	}
}
}

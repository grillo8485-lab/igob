using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daAdjudicacionesSeguimiento
 {
	public int guardarAdjudicacionesSeguimiento(SqlConnection Conexion, beAdjudicacionesSeguimiento obeAdjudicacionesSeguimiento)
	{
		int Id=0;
		string sp = "Proc_AdjudicacionesSeguimientoInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionSeguimiento", SqlDbType.Int).Value = obeAdjudicacionesSeguimiento.IdAdjudicacionSeguimiento;
				cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesSeguimiento.IdAdjudicacion;
				cmd.Parameters.Add("@IdEstatusAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesSeguimiento.IdEstatusAdjudicacion;
				cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = obeAdjudicacionesSeguimiento.Fecha;
				cmd.Parameters.Add("@Token", SqlDbType.VarChar).Value = obeAdjudicacionesSeguimiento.Token;
				cmd.Parameters.Add("@IdUsarioRegistro", SqlDbType.Int).Value = obeAdjudicacionesSeguimiento.IdUsarioRegistro;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarAdjudicacionesSeguimiento(SqlConnection Conexion, beAdjudicacionesSeguimiento obeAdjudicacionesSeguimiento)
	{
		string sp = "Proc_AdjudicacionesSeguimientoActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionSeguimiento", SqlDbType.Int).Value = obeAdjudicacionesSeguimiento.IdAdjudicacionSeguimiento;
				cmd.Parameters.Add("@IdAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesSeguimiento.IdAdjudicacion;
				cmd.Parameters.Add("@IdEstatusAdjudicacion", SqlDbType.Int).Value = obeAdjudicacionesSeguimiento.IdEstatusAdjudicacion;
				cmd.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = obeAdjudicacionesSeguimiento.Fecha;
				cmd.Parameters.Add("@Token", SqlDbType.VarChar).Value = obeAdjudicacionesSeguimiento.Token;
				cmd.Parameters.Add("@IdUsarioRegistro", SqlDbType.Int).Value = obeAdjudicacionesSeguimiento.IdUsarioRegistro;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarAdjudicacionesSeguimiento(SqlConnection Conexion,int pIdAdjudicacionSeguimiento)
	{
		string sp = "Proc_AdjudicacionesSeguimientoEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdAdjudicacionSeguimiento", SqlDbType.Int).Value = pIdAdjudicacionSeguimiento;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beAdjudicacionesSeguimiento traerAdjudicacionesSeguimiento_x_IdAdjudicacionSeguimiento(SqlConnection Conexion,int IdAdjudicacionSeguimiento)
	{
		string sp = "Proc_AdjudicacionesSeguimiento_x_IdAdjudicacionSeguimiento";
				beAdjudicacionesSeguimiento obeAdjudicacionesSeguimiento=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdAdjudicacionSeguimiento", SqlDbType.Int).Value = IdAdjudicacionSeguimiento;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdAdjudicacionSeguimiento = datard.GetOrdinal("IdAdjudicacionSeguimiento");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posIdEstatusAdjudicacion = datard.GetOrdinal("IdEstatusAdjudicacion");
						int posFecha = datard.GetOrdinal("Fecha");
						int posToken = datard.GetOrdinal("Token");
						int posIdUsarioRegistro = datard.GetOrdinal("IdUsarioRegistro");
					 obeAdjudicacionesSeguimiento = new beAdjudicacionesSeguimiento();
				while (datard.Read())
					{
						obeAdjudicacionesSeguimiento.IdAdjudicacionSeguimiento =  datard.GetInt32(posIdAdjudicacionSeguimiento);
						obeAdjudicacionesSeguimiento.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
						obeAdjudicacionesSeguimiento.IdEstatusAdjudicacion =  datard.GetInt32(posIdEstatusAdjudicacion);
						obeAdjudicacionesSeguimiento.Fecha =  datard.GetDateTime(posFecha);
						obeAdjudicacionesSeguimiento.Token =  datard.GetString(posToken);
						obeAdjudicacionesSeguimiento.IdUsarioRegistro =  datard.GetInt32(posIdUsarioRegistro);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeAdjudicacionesSeguimiento;
			}
	}
	public List< beAdjudicacionesSeguimiento> listarTodos_AdjudicacionesSeguimiento(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesSeguimiento_Traer_Todos";
		List<beAdjudicacionesSeguimiento> lbeAdjudicacionesSeguimiento = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacionSeguimiento = datard.GetOrdinal("IdAdjudicacionSeguimiento");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posIdEstatusAdjudicacion = datard.GetOrdinal("IdEstatusAdjudicacion");
						int posFecha = datard.GetOrdinal("Fecha");
						int posToken = datard.GetOrdinal("Token");
						int posIdUsarioRegistro = datard.GetOrdinal("IdUsarioRegistro");
				lbeAdjudicacionesSeguimiento = new List<beAdjudicacionesSeguimiento>();
				beAdjudicacionesSeguimiento obeAdjudicacionesSeguimiento;
				while (datard.Read())
				{
					 obeAdjudicacionesSeguimiento = new beAdjudicacionesSeguimiento();
					obeAdjudicacionesSeguimiento.IdAdjudicacionSeguimiento =  datard.GetInt32(posIdAdjudicacionSeguimiento);
					obeAdjudicacionesSeguimiento.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
					obeAdjudicacionesSeguimiento.IdEstatusAdjudicacion =  datard.GetInt32(posIdEstatusAdjudicacion);
					obeAdjudicacionesSeguimiento.Fecha =  datard.GetDateTime(posFecha);
					obeAdjudicacionesSeguimiento.Token =  datard.GetString(posToken);
					obeAdjudicacionesSeguimiento.IdUsarioRegistro =  datard.GetInt32(posIdUsarioRegistro);
					lbeAdjudicacionesSeguimiento.Add(obeAdjudicacionesSeguimiento);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesSeguimiento;
		}
	}
	public List< beAdjudicacionesSeguimiento> listar_AdjudicacionesSeguimiento_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_AdjudicacionesSeguimiento_TraerTodos_GetAll";
		List<beAdjudicacionesSeguimiento> lbeAdjudicacionesSeguimiento = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdAdjudicacionSeguimiento = datard.GetOrdinal("IdAdjudicacionSeguimiento");
						int posIdAdjudicacion = datard.GetOrdinal("IdAdjudicacion");
						int posIdEstatusAdjudicacion = datard.GetOrdinal("IdEstatusAdjudicacion");
						int posFecha = datard.GetOrdinal("Fecha");
						int posToken = datard.GetOrdinal("Token");
						int posIdUsarioRegistro = datard.GetOrdinal("IdUsarioRegistro");
				lbeAdjudicacionesSeguimiento = new List<beAdjudicacionesSeguimiento>();
				beAdjudicacionesSeguimiento obeAdjudicacionesSeguimiento;
				while (datard.Read())
				{
					 obeAdjudicacionesSeguimiento = new beAdjudicacionesSeguimiento();
					obeAdjudicacionesSeguimiento.IdAdjudicacionSeguimiento =  datard.GetInt32(posIdAdjudicacionSeguimiento);
					obeAdjudicacionesSeguimiento.IdAdjudicacion =  datard.GetInt32(posIdAdjudicacion);
					obeAdjudicacionesSeguimiento.IdEstatusAdjudicacion =  datard.GetInt32(posIdEstatusAdjudicacion);
					obeAdjudicacionesSeguimiento.Fecha =  datard.GetDateTime(posFecha);
					obeAdjudicacionesSeguimiento.Token =  datard.GetString(posToken);
					obeAdjudicacionesSeguimiento.IdUsarioRegistro =  datard.GetInt32(posIdUsarioRegistro);
			// debe agregar campos de la Vista
					lbeAdjudicacionesSeguimiento.Add(obeAdjudicacionesSeguimiento);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeAdjudicacionesSeguimiento;
		}
	}
}
}

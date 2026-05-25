using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daEstatusPreguntas
 {
	public int guardarEstatusPreguntas(SqlConnection Conexion, beEstatusPreguntas obeEstatusPreguntas)
	{
		int Id=0;
		string sp = "Proc_EstatusPreguntasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdEstatusPregunta", SqlDbType.Int).Value = obeEstatusPreguntas.IdEstatusPregunta;
				cmd.Parameters.Add("@Estatus", SqlDbType.NChar).Value = obeEstatusPreguntas.Estatus;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeEstatusPreguntas.Activo;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarEstatusPreguntas(SqlConnection Conexion, beEstatusPreguntas obeEstatusPreguntas)
	{
		string sp = "Proc_EstatusPreguntasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdEstatusPregunta", SqlDbType.Int).Value = obeEstatusPreguntas.IdEstatusPregunta;
				cmd.Parameters.Add("@Estatus", SqlDbType.NChar).Value = obeEstatusPreguntas.Estatus;
				cmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = obeEstatusPreguntas.Activo;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarEstatusPreguntas(SqlConnection Conexion,int pIdEstatusPregunta)
	{
		string sp = "Proc_EstatusPreguntasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdEstatusPregunta", SqlDbType.Int).Value = pIdEstatusPregunta;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beEstatusPreguntas traerEstatusPreguntas_x_IdEstatusPregunta(SqlConnection Conexion,int IdEstatusPregunta)
	{
		string sp = "Proc_EstatusPreguntas_x_IdEstatusPregunta";
				beEstatusPreguntas obeEstatusPreguntas=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdEstatusPregunta", SqlDbType.Int).Value = IdEstatusPregunta;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdEstatusPregunta = datard.GetOrdinal("IdEstatusPregunta");
						int posEstatus = datard.GetOrdinal("Estatus");
						int posActivo = datard.GetOrdinal("Activo");
					 obeEstatusPreguntas = new beEstatusPreguntas();
				while (datard.Read())
					{
						obeEstatusPreguntas.IdEstatusPregunta =  datard.GetInt32(posIdEstatusPregunta);
						obeEstatusPreguntas.Estatus =  datard.GetString(posEstatus);
						obeEstatusPreguntas.Activo =  datard.GetBoolean(posActivo);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeEstatusPreguntas;
			}
	}
	public List< beEstatusPreguntas> listarTodos_EstatusPreguntas(SqlConnection Conexion)
	 {
		string sp = "Proc_EstatusPreguntas_Traer_Todos";
		List<beEstatusPreguntas> lbeEstatusPreguntas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdEstatusPregunta = datard.GetOrdinal("IdEstatusPregunta");
						int posEstatus = datard.GetOrdinal("Estatus");
						int posActivo = datard.GetOrdinal("Activo");
				lbeEstatusPreguntas = new List<beEstatusPreguntas>();
				beEstatusPreguntas obeEstatusPreguntas;
				while (datard.Read())
				{
					 obeEstatusPreguntas = new beEstatusPreguntas();
					obeEstatusPreguntas.IdEstatusPregunta =  datard.GetInt32(posIdEstatusPregunta);
					obeEstatusPreguntas.Estatus =  datard.GetString(posEstatus);
					obeEstatusPreguntas.Activo =  datard.GetBoolean(posActivo);
					lbeEstatusPreguntas.Add(obeEstatusPreguntas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEstatusPreguntas;
		}
	}
	public List< beEstatusPreguntas> listar_EstatusPreguntas_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_EstatusPreguntas_TraerTodos_GetAll";
		List<beEstatusPreguntas> lbeEstatusPreguntas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdEstatusPregunta = datard.GetOrdinal("IdEstatusPregunta");
						int posEstatus = datard.GetOrdinal("Estatus");
						int posActivo = datard.GetOrdinal("Activo");
				lbeEstatusPreguntas = new List<beEstatusPreguntas>();
				beEstatusPreguntas obeEstatusPreguntas;
				while (datard.Read())
				{
					 obeEstatusPreguntas = new beEstatusPreguntas();
					obeEstatusPreguntas.IdEstatusPregunta =  datard.GetInt32(posIdEstatusPregunta);
					obeEstatusPreguntas.Estatus =  datard.GetString(posEstatus);
					obeEstatusPreguntas.Activo =  datard.GetBoolean(posActivo);
			// debe agregar campos de la Vista
					lbeEstatusPreguntas.Add(obeEstatusPreguntas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeEstatusPreguntas;
		}
	}
}
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daRespuestasRechazadas
 {
	public int guardarRespuestasRechazadas(SqlConnection Conexion, beRespuestasRechazadas obeRespuestasRechazadas)
	{
		int Id=0;
		string sp = "Proc_RespuestasRechazadasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRespuestaRechazada", SqlDbType.Int).Value = obeRespuestasRechazadas.IdRespuestaRechazada;
				cmd.Parameters.Add("@IdRespuesta", SqlDbType.Int).Value = obeRespuestasRechazadas.IdRespuesta;
				cmd.Parameters.Add("@IdPregunta", SqlDbType.Int).Value = obeRespuestasRechazadas.IdPregunta;
				cmd.Parameters.Add("@IdEstatusRespuesta", SqlDbType.Int).Value = obeRespuestasRechazadas.IdEstatusRespuesta;
				cmd.Parameters.Add("@Respuesta", SqlDbType.Text).Value = obeRespuestasRechazadas.Respuesta;
				cmd.Parameters.Add("@Observaciones", SqlDbType.Text).Value = obeRespuestasRechazadas.Observaciones;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRespuestasRechazadas.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRespuestasRechazadas.FechaRegistro;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarRespuestasRechazadas(SqlConnection Conexion, beRespuestasRechazadas obeRespuestasRechazadas)
	{
		string sp = "Proc_RespuestasRechazadasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRespuestaRechazada", SqlDbType.Int).Value = obeRespuestasRechazadas.IdRespuestaRechazada;
				cmd.Parameters.Add("@IdRespuesta", SqlDbType.Int).Value = obeRespuestasRechazadas.IdRespuesta;
				cmd.Parameters.Add("@IdPregunta", SqlDbType.Int).Value = obeRespuestasRechazadas.IdPregunta;
				cmd.Parameters.Add("@IdEstatusRespuesta", SqlDbType.Int).Value = obeRespuestasRechazadas.IdEstatusRespuesta;
				cmd.Parameters.Add("@Respuesta", SqlDbType.Text).Value = obeRespuestasRechazadas.Respuesta;
				cmd.Parameters.Add("@Observaciones", SqlDbType.Text).Value = obeRespuestasRechazadas.Observaciones;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRespuestasRechazadas.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRespuestasRechazadas.FechaRegistro;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarRespuestasRechazadas(SqlConnection Conexion,int pIdRespuestaRechazada)
	{
		string sp = "Proc_RespuestasRechazadasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRespuestaRechazada", SqlDbType.Int).Value = pIdRespuestaRechazada;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beRespuestasRechazadas traerRespuestasRechazadas_x_IdRespuestaRechazada(SqlConnection Conexion,int IdRespuestaRechazada)
	{
		string sp = "Proc_RespuestasRechazadas_x_IdRespuestaRechazada";
				beRespuestasRechazadas obeRespuestasRechazadas=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdRespuestaRechazada", SqlDbType.Int).Value = IdRespuestaRechazada;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdRespuestaRechazada = datard.GetOrdinal("IdRespuestaRechazada");
						int posIdRespuesta = datard.GetOrdinal("IdRespuesta");
						int posIdPregunta = datard.GetOrdinal("IdPregunta");
						int posIdEstatusRespuesta = datard.GetOrdinal("IdEstatusRespuesta");
						int posRespuesta = datard.GetOrdinal("Respuesta");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
					 obeRespuestasRechazadas = new beRespuestasRechazadas();
				while (datard.Read())
					{
						obeRespuestasRechazadas.IdRespuestaRechazada =  datard.GetInt32(posIdRespuestaRechazada);
						obeRespuestasRechazadas.IdRespuesta =  datard.GetInt32(posIdRespuesta);
						obeRespuestasRechazadas.IdPregunta =  datard.GetInt32(posIdPregunta);
						obeRespuestasRechazadas.IdEstatusRespuesta =  datard.GetInt32(posIdEstatusRespuesta);
						obeRespuestasRechazadas.Respuesta =  datard.GetString(posRespuesta);
						obeRespuestasRechazadas.Observaciones =  datard.GetString(posObservaciones);
						obeRespuestasRechazadas.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
						obeRespuestasRechazadas.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRespuestasRechazadas;
			}
	}
	public List< beRespuestasRechazadas> listarTodos_RespuestasRechazadas(SqlConnection Conexion)
	 {
		string sp = "Proc_RespuestasRechazadas_Traer_Todos";
		List<beRespuestasRechazadas> lbeRespuestasRechazadas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdRespuestaRechazada = datard.GetOrdinal("IdRespuestaRechazada");
						int posIdRespuesta = datard.GetOrdinal("IdRespuesta");
						int posIdPregunta = datard.GetOrdinal("IdPregunta");
						int posIdEstatusRespuesta = datard.GetOrdinal("IdEstatusRespuesta");
						int posRespuesta = datard.GetOrdinal("Respuesta");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				lbeRespuestasRechazadas = new List<beRespuestasRechazadas>();
				beRespuestasRechazadas obeRespuestasRechazadas;
				while (datard.Read())
				{
					 obeRespuestasRechazadas = new beRespuestasRechazadas();
					obeRespuestasRechazadas.IdRespuestaRechazada =  datard.GetInt32(posIdRespuestaRechazada);
					obeRespuestasRechazadas.IdRespuesta =  datard.GetInt32(posIdRespuesta);
					obeRespuestasRechazadas.IdPregunta =  datard.GetInt32(posIdPregunta);
					obeRespuestasRechazadas.IdEstatusRespuesta =  datard.GetInt32(posIdEstatusRespuesta);
					obeRespuestasRechazadas.Respuesta =  datard.GetString(posRespuesta);
					obeRespuestasRechazadas.Observaciones =  datard.GetString(posObservaciones);
					obeRespuestasRechazadas.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeRespuestasRechazadas.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					lbeRespuestasRechazadas.Add(obeRespuestasRechazadas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRespuestasRechazadas;
		}
	}
	public List< beRespuestasRechazadas> listar_RespuestasRechazadas_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_RespuestasRechazadas_TraerTodos_GetAll";
		List<beRespuestasRechazadas> lbeRespuestasRechazadas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdRespuestaRechazada = datard.GetOrdinal("IdRespuestaRechazada");
						int posIdRespuesta = datard.GetOrdinal("IdRespuesta");
						int posIdPregunta = datard.GetOrdinal("IdPregunta");
						int posIdEstatusRespuesta = datard.GetOrdinal("IdEstatusRespuesta");
						int posRespuesta = datard.GetOrdinal("Respuesta");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				lbeRespuestasRechazadas = new List<beRespuestasRechazadas>();
				beRespuestasRechazadas obeRespuestasRechazadas;
				while (datard.Read())
				{
					 obeRespuestasRechazadas = new beRespuestasRechazadas();
					obeRespuestasRechazadas.IdRespuestaRechazada =  datard.GetInt32(posIdRespuestaRechazada);
					obeRespuestasRechazadas.IdRespuesta =  datard.GetInt32(posIdRespuesta);
					obeRespuestasRechazadas.IdPregunta =  datard.GetInt32(posIdPregunta);
					obeRespuestasRechazadas.IdEstatusRespuesta =  datard.GetInt32(posIdEstatusRespuesta);
					obeRespuestasRechazadas.Respuesta =  datard.GetString(posRespuesta);
					obeRespuestasRechazadas.Observaciones =  datard.GetString(posObservaciones);
					obeRespuestasRechazadas.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeRespuestasRechazadas.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
			// debe agregar campos de la Vista
					lbeRespuestasRechazadas.Add(obeRespuestasRechazadas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRespuestasRechazadas;
		}
	}
}
}

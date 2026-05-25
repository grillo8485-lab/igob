using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daRespuestas
 {
	public int guardarRespuestas(SqlConnection Conexion, beRespuestas obeRespuestas)
	{
		int Id=0;
		string sp = "Proc_RespuestasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRespuesta", SqlDbType.Int).Value = obeRespuestas.IdRespuesta;
				cmd.Parameters.Add("@IdPregunta", SqlDbType.Int).Value = obeRespuestas.IdPregunta;
				cmd.Parameters.Add("@IdEstatusRespuesta", SqlDbType.Int).Value = obeRespuestas.IdEstatusRespuesta;
				cmd.Parameters.Add("@IdEstatusRespuestaGeneral", SqlDbType.Int).Value = obeRespuestas.IdEstatusRespuestaGeneral;
				cmd.Parameters.Add("@Respuesta", SqlDbType.Text).Value = obeRespuestas.Respuesta;
				cmd.Parameters.Add("@Observaciones", SqlDbType.Text).Value = obeRespuestas.Observaciones;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRespuestas.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRespuestas.FechaRegistro;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarRespuestas(SqlConnection Conexion, beRespuestas obeRespuestas)
	{
		string sp = "Proc_RespuestasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRespuesta", SqlDbType.Int).Value = obeRespuestas.IdRespuesta;
				cmd.Parameters.Add("@IdPregunta", SqlDbType.Int).Value = obeRespuestas.IdPregunta;
				cmd.Parameters.Add("@IdEstatusRespuesta", SqlDbType.Int).Value = obeRespuestas.IdEstatusRespuesta;
				cmd.Parameters.Add("@IdEstatusRespuestaGeneral", SqlDbType.Int).Value = obeRespuestas.IdEstatusRespuestaGeneral;
				cmd.Parameters.Add("@Respuesta", SqlDbType.Text).Value = obeRespuestas.Respuesta;
				cmd.Parameters.Add("@Observaciones", SqlDbType.Text).Value = obeRespuestas.Observaciones;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeRespuestas.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeRespuestas.FechaRegistro;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarRespuestas(SqlConnection Conexion,int pIdRespuesta)
	{
		string sp = "Proc_RespuestasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdRespuesta", SqlDbType.Int).Value = pIdRespuesta;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beRespuestas traerRespuestas_x_IdRespuesta(SqlConnection Conexion,int IdRespuesta)
	{
		string sp = "Proc_Respuestas_x_IdRespuesta";
				beRespuestas obeRespuestas=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdRespuesta", SqlDbType.Int).Value = IdRespuesta;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdRespuesta = datard.GetOrdinal("IdRespuesta");
						int posIdPregunta = datard.GetOrdinal("IdPregunta");
						int posIdEstatusRespuesta = datard.GetOrdinal("IdEstatusRespuesta");
						int posIdEstatusRespuestaGeneral = datard.GetOrdinal("IdEstatusRespuestaGeneral");
						int posRespuesta = datard.GetOrdinal("Respuesta");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
					 obeRespuestas = new beRespuestas();
				while (datard.Read())
					{
						obeRespuestas.IdRespuesta =  datard.GetInt32(posIdRespuesta);
						obeRespuestas.IdPregunta =  datard.GetInt32(posIdPregunta);
						obeRespuestas.IdEstatusRespuesta =  datard.GetInt32(posIdEstatusRespuesta);
						obeRespuestas.IdEstatusRespuestaGeneral = datard[posIdEstatusRespuestaGeneral]== DBNull.Value? 0: datard.GetInt32(posIdEstatusRespuestaGeneral);
						obeRespuestas.Respuesta = datard[posRespuesta] == DBNull.Value ? "" : datard.GetString(posRespuesta);
						obeRespuestas.Observaciones = datard[posObservaciones] == DBNull.Value ? "" : datard.GetString(posObservaciones);
						obeRespuestas.IdUsuarioRegistro = datard[posIdEstatusRespuestaGeneral] == DBNull.Value ? 0 : datard.GetInt32(posIdUsuarioRegistro);
						obeRespuestas.FechaRegistro = datard[posFechaRegistro] == DBNull.Value ? DateTime.Now : datard.GetDateTime(posFechaRegistro);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeRespuestas;
			}
	}
	public List< beRespuestas> listarTodos_Respuestas(SqlConnection Conexion)
	 {
		string sp = "Proc_Respuestas_Traer_Todos";
		List<beRespuestas> lbeRespuestas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdRespuesta = datard.GetOrdinal("IdRespuesta");
						int posIdPregunta = datard.GetOrdinal("IdPregunta");
						int posIdEstatusRespuesta = datard.GetOrdinal("IdEstatusRespuesta");
						int posIdEstatusRespuestaGeneral = datard.GetOrdinal("IdEstatusRespuestaGeneral");
						int posRespuesta = datard.GetOrdinal("Respuesta");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				lbeRespuestas = new List<beRespuestas>();
				beRespuestas obeRespuestas;
				while (datard.Read())
				{
					 obeRespuestas = new beRespuestas();
					obeRespuestas.IdRespuesta =  datard.GetInt32(posIdRespuesta);
					obeRespuestas.IdPregunta =  datard.GetInt32(posIdPregunta);
					obeRespuestas.IdEstatusRespuesta =  datard.GetInt32(posIdEstatusRespuesta);
					obeRespuestas.IdEstatusRespuestaGeneral =  datard.GetInt32(posIdEstatusRespuestaGeneral);
					obeRespuestas.Respuesta =  datard.GetString(posRespuesta);
					obeRespuestas.Observaciones =  datard.GetString(posObservaciones);
					obeRespuestas.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeRespuestas.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					lbeRespuestas.Add(obeRespuestas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRespuestas;
		}
	}
	public List< beRespuestas> listar_Respuestas_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_Respuestas_TraerTodos_GetAll";
		List<beRespuestas> lbeRespuestas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdRespuesta = datard.GetOrdinal("IdRespuesta");
						int posIdPregunta = datard.GetOrdinal("IdPregunta");
						int posIdEstatusRespuesta = datard.GetOrdinal("IdEstatusRespuesta");
						int posIdEstatusRespuestaGeneral = datard.GetOrdinal("IdEstatusRespuestaGeneral");
						int posRespuesta = datard.GetOrdinal("Respuesta");
						int posObservaciones = datard.GetOrdinal("Observaciones");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
				lbeRespuestas = new List<beRespuestas>();
				beRespuestas obeRespuestas;
				while (datard.Read())
				{
					 obeRespuestas = new beRespuestas();
					obeRespuestas.IdRespuesta =  datard.GetInt32(posIdRespuesta);
					obeRespuestas.IdPregunta =  datard.GetInt32(posIdPregunta);
					obeRespuestas.IdEstatusRespuesta =  datard.GetInt32(posIdEstatusRespuesta);
					obeRespuestas.IdEstatusRespuestaGeneral =  datard.GetInt32(posIdEstatusRespuestaGeneral);
					obeRespuestas.Respuesta =  datard.GetString(posRespuesta);
					obeRespuestas.Observaciones =  datard.GetString(posObservaciones);
					obeRespuestas.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					obeRespuestas.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
			// debe agregar campos de la Vista
					lbeRespuestas.Add(obeRespuestas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeRespuestas;
		}
	}
}
}

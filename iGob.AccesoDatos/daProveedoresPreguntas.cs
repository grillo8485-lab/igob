using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daProveedoresPreguntas
 {
	public int guardarProveedoresPreguntas(SqlConnection Conexion, beProveedoresPreguntas obeProveedoresPreguntas)
	{
		int Id=0;
		string sp = "Proc_ProveedoresPreguntasInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPregunta", SqlDbType.Int).Value = obeProveedoresPreguntas.IdPregunta;
				cmd.Parameters.Add("@IdProveedorRqInvitacion", SqlDbType.Int).Value = obeProveedoresPreguntas.IdProveedorRqInvitacion;
				cmd.Parameters.Add("@NoPregunta", SqlDbType.Int).Value = obeProveedoresPreguntas.NoPregunta;
				cmd.Parameters.Add("@Pregunta", SqlDbType.VarChar).Value = obeProveedoresPreguntas.Pregunta;
				cmd.Parameters.Add("@IdEstatusPregunta", SqlDbType.Int).Value = obeProveedoresPreguntas.IdEstatusPregunta;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeProveedoresPreguntas.FechaRegistro;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeProveedoresPreguntas.IdUsuarioRegistro;
			
				Id =(int)cmd.ExecuteScalar();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarProveedoresPreguntas(SqlConnection Conexion, beProveedoresPreguntas obeProveedoresPreguntas)
	{
		string sp = "Proc_ProveedoresPreguntasActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPregunta", SqlDbType.Int).Value = obeProveedoresPreguntas.IdPregunta;
				cmd.Parameters.Add("@IdProveedorRqInvitacion", SqlDbType.Int).Value = obeProveedoresPreguntas.IdProveedorRqInvitacion;
				cmd.Parameters.Add("@NoPregunta", SqlDbType.Int).Value = obeProveedoresPreguntas.NoPregunta;
				cmd.Parameters.Add("@Pregunta", SqlDbType.VarChar).Value = obeProveedoresPreguntas.Pregunta;
				cmd.Parameters.Add("@IdEstatusPregunta", SqlDbType.Int).Value = obeProveedoresPreguntas.IdEstatusPregunta;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeProveedoresPreguntas.FechaRegistro;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeProveedoresPreguntas.IdUsuarioRegistro;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarProveedoresPreguntas(SqlConnection Conexion,int pIdPregunta)
	{
		string sp = "Proc_ProveedoresPreguntasEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdPregunta", SqlDbType.Int).Value = pIdPregunta;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beProveedoresPreguntas traerProveedoresPreguntas_x_IdPregunta(SqlConnection Conexion,int IdPregunta)
	{
		string sp = "Proc_ProveedoresPreguntas_x_IdPregunta";
				beProveedoresPreguntas obeProveedoresPreguntas=null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdPregunta", SqlDbType.Int).Value = IdPregunta;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
						int posIdPregunta = datard.GetOrdinal("IdPregunta");
						int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
						int posNoPregunta = datard.GetOrdinal("NoPregunta");
						int posPregunta = datard.GetOrdinal("Pregunta");
						int posIdEstatusPregunta = datard.GetOrdinal("IdEstatusPregunta");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
					 obeProveedoresPreguntas = new beProveedoresPreguntas();
				while (datard.Read())
					{
						obeProveedoresPreguntas.IdPregunta =  datard.GetInt32(posIdPregunta);
						obeProveedoresPreguntas.IdProveedorRqInvitacion =  datard.GetInt32(posIdProveedorRqInvitacion);
						obeProveedoresPreguntas.NoPregunta =  datard.GetInt32(posNoPregunta);
						obeProveedoresPreguntas.Pregunta =  datard.GetString(posPregunta);
						obeProveedoresPreguntas.IdEstatusPregunta =  datard.GetInt32(posIdEstatusPregunta);
						obeProveedoresPreguntas.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
						obeProveedoresPreguntas.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeProveedoresPreguntas;
			}
	}
	public List< beProveedoresPreguntas> listarTodos_ProveedoresPreguntas(SqlConnection Conexion)
	 {
		string sp = "Proc_ProveedoresPreguntas_Traer_Todos";
		List<beProveedoresPreguntas> lbeProveedoresPreguntas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdPregunta = datard.GetOrdinal("IdPregunta");
						int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
						int posNoPregunta = datard.GetOrdinal("NoPregunta");
						int posPregunta = datard.GetOrdinal("Pregunta");
						int posIdEstatusPregunta = datard.GetOrdinal("IdEstatusPregunta");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
				lbeProveedoresPreguntas = new List<beProveedoresPreguntas>();
				beProveedoresPreguntas obeProveedoresPreguntas;
				while (datard.Read())
				{
					 obeProveedoresPreguntas = new beProveedoresPreguntas();
					obeProveedoresPreguntas.IdPregunta =  datard.GetInt32(posIdPregunta);
					obeProveedoresPreguntas.IdProveedorRqInvitacion =  datard.GetInt32(posIdProveedorRqInvitacion);
					obeProveedoresPreguntas.NoPregunta =  datard.GetInt32(posNoPregunta);
					obeProveedoresPreguntas.Pregunta =  datard.GetString(posPregunta);
					obeProveedoresPreguntas.IdEstatusPregunta =  datard.GetInt32(posIdEstatusPregunta);
					obeProveedoresPreguntas.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					obeProveedoresPreguntas.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
					lbeProveedoresPreguntas.Add(obeProveedoresPreguntas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProveedoresPreguntas;
		}
	}
	public List< beProveedoresPreguntas> listar_ProveedoresPreguntas_GetAll(SqlConnection Conexion)
	 {
		string sp = "Proc_ProveedoresPreguntas_TraerTodos_GetAll";
		List<beProveedoresPreguntas> lbeProveedoresPreguntas = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
						int posIdPregunta = datard.GetOrdinal("IdPregunta");
						int posIdProveedorRqInvitacion = datard.GetOrdinal("IdProveedorRqInvitacion");
						int posNoPregunta = datard.GetOrdinal("NoPregunta");
						int posPregunta = datard.GetOrdinal("Pregunta");
						int posIdEstatusPregunta = datard.GetOrdinal("IdEstatusPregunta");
						int posFechaRegistro = datard.GetOrdinal("FechaRegistro");
						int posIdUsuarioRegistro = datard.GetOrdinal("IdUsuarioRegistro");
				lbeProveedoresPreguntas = new List<beProveedoresPreguntas>();
				beProveedoresPreguntas obeProveedoresPreguntas;
				while (datard.Read())
				{
					 obeProveedoresPreguntas = new beProveedoresPreguntas();
					obeProveedoresPreguntas.IdPregunta =  datard.GetInt32(posIdPregunta);
					obeProveedoresPreguntas.IdProveedorRqInvitacion =  datard.GetInt32(posIdProveedorRqInvitacion);
					obeProveedoresPreguntas.NoPregunta =  datard.GetInt32(posNoPregunta);
					obeProveedoresPreguntas.Pregunta =  datard.GetString(posPregunta);
					obeProveedoresPreguntas.IdEstatusPregunta =  datard.GetInt32(posIdEstatusPregunta);
					obeProveedoresPreguntas.FechaRegistro =  datard.GetDateTime(posFechaRegistro);
					obeProveedoresPreguntas.IdUsuarioRegistro =  datard.GetInt32(posIdUsuarioRegistro);
			// debe agregar campos de la Vista
					lbeProveedoresPreguntas.Add(obeProveedoresPreguntas);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeProveedoresPreguntas;
		}
	}
}
}

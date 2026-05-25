using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;

namespace iGob.AccesoDatos
{
public class daCertificaciones
 {
	public int guardarCertificaciones(SqlConnection Conexion, beCertificaciones obeCertificaciones)
	{
		int Id=0;
		string sp = "Proc_CertificacionesInsertar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
			{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdCertificacion", SqlDbType.Int).Value = obeCertificaciones.IdCertificacion;
				cmd.Parameters.Add("@Certificacion", SqlDbType.NVarChar).Value = obeCertificaciones.Certificacion;
				cmd.Parameters.Add("@NoCertificacion", SqlDbType.NVarChar).Value = obeCertificaciones.NoCertificacion;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeCertificaciones.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeCertificaciones.FechaRegistro;
			
				Id =(int)cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return Id;
			}
	}

	public int actualizarCertificaciones(SqlConnection Conexion, beCertificaciones obeCertificaciones)
	{
		string sp = "Proc_CertificacionesActualizar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdCertificacion", SqlDbType.Int).Value = obeCertificaciones.IdCertificacion;
				cmd.Parameters.Add("@Certificacion", SqlDbType.NVarChar).Value = obeCertificaciones.Certificacion;
				cmd.Parameters.Add("@NoCertificacion", SqlDbType.NVarChar).Value = obeCertificaciones.NoCertificacion;
				cmd.Parameters.Add("@IdUsuarioRegistro", SqlDbType.Int).Value = obeCertificaciones.IdUsuarioRegistro;
				cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = obeCertificaciones.FechaRegistro;
			
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex) {
				throw ex;
			}
			return 0;
			}
	}

	public int eliminarCertificaciones(SqlConnection Conexion,int pIdCertificacion)
	{
		string sp = "Proc_CertificacionesEliminar";
		using (SqlCommand cmd = new SqlCommand(sp,Conexion))
		{
			try {
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IdCertificacion", SqlDbType.Int).Value = pIdCertificacion;
				cmd.ExecuteNonQuery();
				}
				catch (Exception ex) {
					throw ex;
				}
			return 0;
			}
	}
	public beCertificaciones traerCertificaciones_x_IdCertificacion(SqlConnection Conexion,int IdCertificacion)
	{
		string sp = "Proc_Certificaciones_x_IdCertificacion";
		List<beCertificaciones> lbeCertificaciones = null;
				beCertificaciones obeCertificaciones=new beCertificaciones();
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdCertificacion", SqlDbType.Int).Value = IdCertificacion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
			try {
				if (datard != null)
				{
				lbeCertificaciones = new List<beCertificaciones>();
				while (datard.Read())
					{
					 obeCertificaciones = new beCertificaciones();
						obeCertificaciones.IdCertificacion =  datard.GetInt32(0);
						obeCertificaciones.Certificacion =  datard.GetString(1);
						obeCertificaciones.NoCertificacion =  datard.GetString(2);
						obeCertificaciones.IdUsuarioRegistro =  datard.GetInt32(3);
						obeCertificaciones.FechaRegistro =  datard.GetDateTime(4);
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeCertificaciones;
			}
	}
	public List< beCertificaciones> listarTodos_Certificaciones(SqlConnection Conexion)
	 {
		string sp = "Proc_Certificaciones_Traer_Todos";
		List<beCertificaciones> lbeCertificaciones = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				lbeCertificaciones = new List<beCertificaciones>();
				beCertificaciones obeCertificaciones;
				while (datard.Read())
				{
					 obeCertificaciones = new beCertificaciones();
					obeCertificaciones.IdCertificacion =  datard.GetInt32(0);
					obeCertificaciones.Certificacion =  datard.GetString(1);
					obeCertificaciones.NoCertificacion =  datard.GetString(2);
					obeCertificaciones.IdUsuarioRegistro =  datard.GetInt32(3);
					obeCertificaciones.FechaRegistro =  datard.GetDateTime(4);
					lbeCertificaciones.Add(obeCertificaciones);
				}
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeCertificaciones;
		}
	}
	public DataTable listarCertificaciones_x_(SqlConnection Conexion,int IdCertificacion)
	 {
		string sp = "Proc_Certificaciones_Traer_Todos";
		DataTable dtCertificaciones = null;
		SqlCommand cmd = new SqlCommand(sp,Conexion);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add("@IdCertificacion", SqlDbType.Int).Value = IdCertificacion;
		using(SqlDataReader datard = cmd.ExecuteReader(CommandBehavior.SingleResult))
		{
		try {
			if (datard != null)
			{
				dtCertificaciones = new DataTable();
				dtCertificaciones.Load(datard);
			}
			}
			catch (Exception ex) {
			throw ex;
			}
			return dtCertificaciones;
		}
	}
}
}

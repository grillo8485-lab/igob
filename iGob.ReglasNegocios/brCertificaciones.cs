using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using iGob.Entidades;
using iGob.AccesoDatos;

namespace iGob.ReglasNegocios
	{
		public class brCertificaciones:brConexion
		 {
	public int guardarCertificaciones(beCertificaciones obeCertificaciones)
	{
		int IdCertificacion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daCertificaciones odaCertificaciones= new daCertificaciones();
			IdCertificacion =  odaCertificaciones.guardarCertificaciones(con, obeCertificaciones);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdCertificacion;
			}
	}

	public int actualizarCertificaciones(beCertificaciones obeCertificaciones)
	{
		int IdCertificacion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daCertificaciones odaCertificaciones= new daCertificaciones();
				IdCertificacion =  odaCertificaciones.actualizarCertificaciones(con, obeCertificaciones);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdCertificacion;
			}
	}

	public int eliminarCertificaciones(int IdCertificacion)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daCertificaciones odaCertificaciones= new daCertificaciones();
				IdCertificacion =  odaCertificaciones.eliminarCertificaciones(con, IdCertificacion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdCertificacion;
			}
	}

	public beCertificaciones traerCertificaciones_x_IdCertificacion (int IdCertificacion)
	{
		beCertificaciones obeCertificaciones=new beCertificaciones();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daCertificaciones odaCertificaciones= new daCertificaciones();
				 obeCertificaciones =  odaCertificaciones.traerCertificaciones_x_IdCertificacion(con, IdCertificacion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeCertificaciones;
			}
	}

	public List<beCertificaciones> listarTodos_Certificaciones()
	 {
		List<beCertificaciones> lbeCertificaciones =new List<beCertificaciones>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daCertificaciones odaCertificaciones= new daCertificaciones();
				 lbeCertificaciones =  odaCertificaciones.listarTodos_Certificaciones(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeCertificaciones;
		}
	}
}
}

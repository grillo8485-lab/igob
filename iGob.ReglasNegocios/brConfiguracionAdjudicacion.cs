using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SoftHomeDeco.Entidades;
using SoftHomeDeco.AccesoDatos;
using iGob.ReglasNegocios;

namespace SoftHomeDeco.ReglasNegocios
	{
		public class brConfiguracionAdjudicacion:brConexion
		 {
	public int guardarConfiguracionAdjudicacion(beConfiguracionAdjudicacion obeConfiguracionAdjudicacion)
	{
		int IdConfiguracionAdjudicacion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
		daConfiguracionAdjudicacion odaConfiguracionAdjudicacion= new daConfiguracionAdjudicacion();
			IdConfiguracionAdjudicacion =  odaConfiguracionAdjudicacion.guardarConfiguracionAdjudicacion(con, obeConfiguracionAdjudicacion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return IdConfiguracionAdjudicacion;
			}
	}

	public int actualizarConfiguracionAdjudicacion(beConfiguracionAdjudicacion obeConfiguracionAdjudicacion)
	{
		int IdConfiguracionAdjudicacion;
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daConfiguracionAdjudicacion odaConfiguracionAdjudicacion= new daConfiguracionAdjudicacion();
				IdConfiguracionAdjudicacion =  odaConfiguracionAdjudicacion.actualizarConfiguracionAdjudicacion(con, obeConfiguracionAdjudicacion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdConfiguracionAdjudicacion;
			}
	}

	public int eliminarConfiguracionAdjudicacion(int IdConfiguracionAdjudicacion)
	{
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daConfiguracionAdjudicacion odaConfiguracionAdjudicacion= new daConfiguracionAdjudicacion();
				IdConfiguracionAdjudicacion =  odaConfiguracionAdjudicacion.eliminarConfiguracionAdjudicacion(con, IdConfiguracionAdjudicacion);
				}
			catch (Exception ex) {
				throw ex;
			}
			return IdConfiguracionAdjudicacion;
			}
	}

	public beConfiguracionAdjudicacion traerConfiguracionAdjudicacion_x_IdConfiguracionAdjudicacion (int IdConfiguracionAdjudicacion)
	{
		beConfiguracionAdjudicacion obeConfiguracionAdjudicacion=new beConfiguracionAdjudicacion();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daConfiguracionAdjudicacion odaConfiguracionAdjudicacion= new daConfiguracionAdjudicacion();
				 obeConfiguracionAdjudicacion =  odaConfiguracionAdjudicacion.traerConfiguracionAdjudicacion_x_IdConfiguracionAdjudicacion(con, IdConfiguracionAdjudicacion);
			}
			catch (Exception ex) {
				throw ex;
			}
			return obeConfiguracionAdjudicacion;
			}
	}

	public List<beConfiguracionAdjudicacion> listarTodos_ConfiguracionAdjudicacion()
	 {
		List<beConfiguracionAdjudicacion> lbeConfiguracionAdjudicacion =new List<beConfiguracionAdjudicacion>();
		using (SqlConnection con = new SqlConnection(CadenaConexion))
			{
			try {
				con.Open();
				daConfiguracionAdjudicacion odaConfiguracionAdjudicacion= new daConfiguracionAdjudicacion();
				 lbeConfiguracionAdjudicacion =  odaConfiguracionAdjudicacion.listarTodos_ConfiguracionAdjudicacion(con);
			}
			catch (Exception ex) {
			throw ex;
			}
			return lbeConfiguracionAdjudicacion;
		}
	}
}
}
